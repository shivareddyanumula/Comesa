using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class Reportss_EmployeeDueIncrement_ : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT obj_smhr_Businessunit;
    SMHR_LOGININFO obj_smhr_Logininfo;
    SMHR_PERIOD obj_smhr_Period;
    SMHR_MASTERS _obj_Smhr_Masters;
    SMHR_PAYITEMS _obj_Payitems;
    SMHR_SALARYSTRUCT _obj_smhr_salaryStruct;

    protected void Page_Load(object sender, EventArgs e)
    {
        string control = string.Empty;
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

                if (Request.QueryString.HasKeys())
                {
                    control = Convert.ToString(Request.QueryString["Control"]);
                    if (control == "1") // for Employee Due Increment  Report
                    {
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Due For Increment");
                    }
                    else if (control == "2") //for TransferDueByBank Report
                    {
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employees Due By Bank");
                    }
                    else if (control == "3" || control == "4" || control == "5" || control == "6") // 
                    {
                        if (control == "3")//for  AllocationSummary Report
                        {
                            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Benefit Summary");
                        }
                        else if (control == "4")//for  AllocationSummary Report
                        {
                            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Deduction Summary");
                        }
                        else if (control == "5")// for EmployeeBenefitDeduction  Report
                        {
                            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Deduction");
                        }
                        else if (control == "6")// for EmployeeBenefitDeduction  Report
                        {
                            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Benefit");
                        }

                    }
                    else if (control == "7")//for  DeductionGroupSummary  Report
                    {
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Deduction Group Summary");

                    }
                    else if (control == "8")//for EmployeeGrossBasicNetSalary  Report
                    {

                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Gross Salary Report");
                    }
                    else if (control == "9")//for  EmployeeGrossBasicNetSalary  Report
                    {
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Net Salary Report");
                    }
                    else if (control == "10")//for EmployeeGrossBasicNetSalary Report
                    {
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Basic Salary Report");
                    }
                    else if (control == "11")//for StatuatoryDeduction Report
                    {
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Statutory Deduction");
                    }
                    else if (control == "12")//for StatuatoryDeduction Report
                    {
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee List By Gross Annual Salary");
                    }
                    else if (control == "13")
                    {
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employees On Payroll");
                    }
                    else if (control == "14")
                    {
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employees Excluded From Payroll");
                    }
                }

                if (control == "4" || control == "5" || control == "9" || control == "10"||control == "3")
                {
                    lblStatus.Visible = lbl.Visible = rcbStatus.Visible = true;
                }
                else
                {
                    lblStatus.Visible = lbl.Visible = rcbStatus.Visible = false;
                }

                //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Income Department Wise");
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
                    return;
                }

                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    // Rg_Countries.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Generate.Visible = false;
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
                    return;

                }
                //control = Convert.ToString(Request.QueryString["Control"]);

                if (control == "1") // for Employee Due Increment  Report d
                {
                    lbl_header.Text = "Employee Due Increment";
                    //trFinancialperiod.Visible = true;
                    trIncrementMonth.Visible = true;
                }
                else if (control == "2") //for TransferDueByBank Report d
                {
                    lbl_header.Text = "Transfer Due by Bank";
                    //trFinancialperiod.Visible = true;
                    trPeriodElements.Visible = true;
                    trBank.Visible = true;
                    trBranch.Visible = true;

                }
                else if (control == "3" || control == "4" || control == "5" || control == "6") // d
                {
                    if (control == "3")//for  AllocationSummary Report
                    {
                        lbl_header.Text = "Benefit Summary";
                    }
                    else if (control == "4")//for  AllocationSummary Report
                    {
                        lbl_header.Text = "Deduction Summary";
                    }
                    else if (control == "5")// for EmployeeBenefitDeduction  Report
                    {
                        lbl_header.Text = "Employee Deduction";
                    }
                    else if (control == "6")// for EmployeeBenefitDeduction  Report
                    {
                        lbl_header.Text = "Employee Benefits";
                    }
                    //trFinancialperiod.Visible = true;
                    trIncrementMonth.Visible = false;
                    trPeriodElements.Visible = true;
                    trPayItem.Visible = true;
                    trBank.Visible = false;
                    trVoteCode.Visible = false;
                    LoadPayItem();

                }
                else if (control == "7")//for  DeductionGroupSummary  Report d
                {
                    lbl_header.Text = "Deduction Group Summary";
                   ////////// rcmb_VoteCode.SelectedIndex = ;
                    trPeriodElements.Visible = true;
                    trVoteCode.Visible = true;
                }
                else if (control == "8")//for EmployeeGrossBasicNetSalary  Report
                {
                    lbl_header.Text = "Employee List By Gross Monthly Salary";
                    trSalStruct.Visible = true;
                    trPeriodElements.Visible = true;

                }
                else if (control == "9")//for  EmployeeGrossBasicNetSalary  Report
                {
                    lbl_header.Text = "Employee List By Net Salary";
                    trSalStruct.Visible = true;
                    trPeriodElements.Visible = true;
                }
                else if (control == "10")//for EmployeeGrossBasicNetSalary Report
                {
                    lbl_header.Text = "Employee List By Basic Salary";
                    trSalStruct.Visible = true;
                }
                else if (control == "11")//for StatuatoryDeduction Report
                {
                    lbl_header.Text = "Statutory Deduction";
                    trPayItem.Visible = true;
                    trPeriodElements.Visible = true;
                }
                else if (control == "12")//for StatuatoryDeduction Report
                {
                    lbl_header.Text = "Employee List By Gross Annual Salary";
                    trSalStruct.Visible = true;
                    trPeriodElements.Visible = false;
                }
                else if (control == "13")//for Employees On Payroll Report
                {
                    lbl_header.Text = "Employees On Payroll";
                    trFinancialperiod.Visible = true;
                    trPeriodElements.Visible = true;
                }
                else if (control == "14")//for Employees Excluded From Payroll Report
                {
                    lbl_header.Text = "Employees Excluded From Payroll";
                    trFinancialperiod.Visible = true;
                    trPeriodElements.Visible = true;
                }


                LoadBusinessUnit();
                LoadFinancialPeriod();
                LoadIncrementMonth();
                LoadBank();

                LoadSalStruct();
                LoadVoteCode();
            }
            Page.Validate();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeDueIncrement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadBusinessUnit()
    {
        try
        {
            string control = Convert.ToString(Request.QueryString["Control"]);
            obj_smhr_Businessunit = new SMHR_BUSINESSUNIT();
            obj_smhr_Period = new SMHR_PERIOD();
            obj_smhr_Logininfo = new SMHR_LOGININFO();
            obj_smhr_Logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            obj_smhr_Logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(obj_smhr_Logininfo);
            rcmb_BusinessUnit.DataSource = dt_BUDetails;
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataBind();
            if (control == "11")
            {
                rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
               // rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem(Convert.ToString(Session["ORG_NAME"])));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeDueIncrement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadPayItem()
    {
        try
        {
            string control = Convert.ToString(Request.QueryString["Control"]);
            _obj_Payitems = new SMHR_PAYITEMS();
            _obj_Payitems.OPERATION = operation.details;
            _obj_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            if (control == "3" || control == "6")
            {
                _obj_Payitems.MODE = Convert.ToInt32("1");
            }
            if (control == "4" || control == "5")
            {
                _obj_Payitems.MODE = Convert.ToInt32("2");
            }

            DataTable dt_Details = BLL.get_PayItems(_obj_Payitems);
            rcmb_PayItem.DataSource = dt_Details;
            rcmb_PayItem.DataTextField = "PAYITEM_PAYITEMNAME";
            rcmb_PayItem.DataValueField = "PAYITEM_ID";
            rcmb_PayItem.DataBind();
            if (control == "4" || control == "5" || control == "6")
            {
                rcmb_PayItem.Items.Insert(0, new RadComboBoxItem("All", "-1"));
            }
            else
            {
                rcmb_PayItem.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeDueIncrement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadSalStruct()
    {
        try
        {
            //Salary Structure
            rcmb_SalStruct.Items.Clear();
            _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
            _obj_smhr_salaryStruct.ISDELETED = false;
            _obj_smhr_salaryStruct.OPERATION = operation.Select;
            _obj_smhr_salaryStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
            rcmb_SalStruct.DataSource = dt_Details;
            rcmb_SalStruct.DataTextField = "SALARYSTRUCT_CODE";
            rcmb_SalStruct.DataValueField = "SALARYSTRUCT_ID";
            rcmb_SalStruct.DataBind();
            string control = Convert.ToString(Request.QueryString["Control"]);
            rcmb_SalStruct.Items.Insert(0, new RadComboBoxItem("All", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeDueIncrement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadFinancialPeriod()
    {
        try
        {
            rcmb_FinancialPeriod.Items.Clear();
            obj_smhr_Period = new SMHR_PERIOD();
            obj_smhr_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_FinPrd = BLL.GET_FIN_PERIOD(obj_smhr_Period);
            if (dt_FinPrd.Rows.Count > 0)
            {
                rcmb_FinancialPeriod.DataSource = dt_FinPrd;
                rcmb_FinancialPeriod.DataTextField = "PERIOD_NAME";
                rcmb_FinancialPeriod.DataValueField = "PERIOD_ID";
                rcmb_FinancialPeriod.DataBind();
            }
            rcmb_FinancialPeriod.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeDueIncrement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadIncrementMonth()
    {
        try
        {
            SMHR_EMPLOYEE objEmployee = new SMHR_EMPLOYEE();
            objEmployee.OPERATION = operation.Select_New;
            rcmb_IncrementMonth.Items.Clear();
            rcmb_IncrementMonth.DataSource = BLL.get_IncrementMonth(objEmployee);
            rcmb_IncrementMonth.DataTextField = "INCR_MONTH";
            rcmb_IncrementMonth.DataValueField = "INCR_ID";
            rcmb_IncrementMonth.DataBind();
            rcmb_IncrementMonth.Items.Insert(0, new RadComboBoxItem("All"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeDueIncrement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadBank()
    {
        try
        {
            rcmb_Bank.Items.Clear();
            rcmb_Branch.Items.Clear();
            _obj_Smhr_Masters = new SMHR_MASTERS();
            //_obj_Smhr_Masters.MASTER_TYPE = "BANK";
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Masters.OPERATION = operation.Select4;
            DataTable dt_Details = new DataTable();
            dt_Details = BLL.get_MasterRecords(_obj_Smhr_Masters);
            rcmb_Bank.DataSource = dt_Details;
            rcmb_Bank.DataTextField = "NAME";
            rcmb_Bank.DataValueField = "HR_MASTER_ID";
            rcmb_Bank.DataBind();
            rcmb_Bank.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("All", "-1"));
            rcmb_Branch.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("All", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeDueIncrement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadVoteCode()
    {
        try
        {
            _obj_Payitems = new SMHR_PAYITEMS();
            _obj_Payitems.OPERATION = operation.Chk;
            _obj_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_PayItems(_obj_Payitems);
            rcmb_VoteCode.DataSource = dt_Details;
            rcmb_VoteCode.DataTextField = "PAYITEM_ACCOUNTHEAD";
            rcmb_VoteCode.DataValueField = "PAYITEM_ID";
            rcmb_VoteCode.DataBind();
            rcmb_VoteCode.Items.Insert(0, new RadComboBoxItem("All"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeDueIncrement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_FinancialPeriod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_FinancialPeriod.SelectedIndex != 0)
            {
                SMHR_PERIODDTL _obj_smhr_perioddtl = new SMHR_PERIODDTL();
                _obj_smhr_perioddtl.OPERATION = operation.Select;
                _obj_smhr_perioddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(rcmb_FinancialPeriod.SelectedItem.Value);
                DataTable dt_Details = BLL.get_PeriodDetails(_obj_smhr_perioddtl);
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_PeriodElements.DataSource = dt_Details;
                    rcmb_PeriodElements.DataValueField = "PRDDTL_ID";
                    rcmb_PeriodElements.DataTextField = "PRDDTL_NAME";
                    rcmb_PeriodElements.DataBind();
                    rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                else
                {
                    rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select"));
                }
            }
            else
            {
                rcmb_PeriodElements.Items.Clear();
                rcmb_PeriodElements.Text = string.Empty;
                //rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeDueIncrement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            string control = Convert.ToString(Request.QueryString["Control"]);
            if (control == "11")
            {
                if (rcmb_BusinessUnit.SelectedIndex != 0 & control == "11")
                {
                    _obj_Payitems = new SMHR_PAYITEMS();
                    _obj_Payitems.OPERATION = operation.Select4;
                    _obj_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Payitems.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                    DataTable dt_Details = BLL.get_PayItems(_obj_Payitems);
                    if (dt_Details.Rows.Count != 0)
                    {
                        rcmb_PayItem.DataSource = dt_Details;
                        rcmb_PayItem.DataTextField = "PAYITEM_PAYITEMNAME";
                        rcmb_PayItem.DataValueField = "PAYITEM_ID";
                        rcmb_PayItem.DataBind();
                        rcmb_PayItem.Items.Insert(0, new RadComboBoxItem("Select"));
                    }
                    else
                    {
                        rcmb_PayItem.Items.Clear();
                        rcmb_PayItem.Items.Insert(0, new RadComboBoxItem("Select"));
                    }

                }
                else
                {
                    rcmb_PayItem.Items.Clear();
                    rcmb_PayItem.Text = string.Empty;

                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeDueIncrement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Bank_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Bank.SelectedIndex > 0)
            {
                rcmb_Branch.Items.Clear();
                _obj_Smhr_Masters = new SMHR_MASTERS();
                //_obj_Smhr_Masters.MASTER_TYPE = "BANK";
                _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Masters.OPERATION = operation.Get_ID;
                _obj_Smhr_Masters.BANKID = Convert.ToInt32(rcmb_Bank.SelectedValue);
                DataTable dt_Details = new DataTable();
                dt_Details = BLL.get_MasterRecords(_obj_Smhr_Masters);
                rcmb_Branch.DataSource = dt_Details;
                rcmb_Branch.DataTextField = "BRANCH";
                rcmb_Branch.DataValueField = "BRANCH_ID";
                rcmb_Branch.DataBind();
                rcmb_Branch.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("All", "-1"));
            }
            else
            {
                rcmb_Branch.Items.Clear();
                rcmb_Branch.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeDueIncrement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            string control = Convert.ToString(Request.QueryString["Control"]);
            if (control == "1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToInt32(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_FinancialPeriod.SelectedValue) + "','" + Convert.ToString(rcmb_IncrementMonth.SelectedValue) + "','" + Convert.ToString(Request.QueryString["Control"]) + "');", true);
            }
            else if (control == "2")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPopB('" + Convert.ToInt32(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_Bank.SelectedValue) + "','" + Convert.ToString(rcmb_Branch.SelectedValue) + "','" + Convert.ToString(rcmb_FinancialPeriod.SelectedValue) + "','" + Convert.ToString(rcmb_PeriodElements.SelectedValue) + "','" + Convert.ToString(Request.QueryString["Control"]) + "');", true);
            }
            else if (control == "3" || control == "4" || control == "5" || control == "6")
            {
                if (control == "4" || control == "5" || control == "3")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPopSts45('" + Convert.ToInt32(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_PayItem.SelectedValue) + "','" + Convert.ToString(rcmb_FinancialPeriod.SelectedValue) + "','" + Convert.ToString(rcmb_PeriodElements.SelectedValue) + "','" + Convert.ToString(rcbStatus.SelectedValue) + "','" + Convert.ToString(Request.QueryString["Control"]) + "','" + Convert.ToString(Request.QueryString["Control"]) + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPopS('" + Convert.ToInt32(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_PayItem.SelectedValue) + "','" + Convert.ToString(rcmb_FinancialPeriod.SelectedValue) + "','" + Convert.ToString(rcmb_PeriodElements.SelectedValue) + "','" + Convert.ToString(Request.QueryString["Control"]) + "','" + Convert.ToString(Request.QueryString["Control"]) + "');", true);
                }
            }
            else if (control == "7")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPopD('" + Convert.ToInt32(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_VoteCode.SelectedValue) + "','" + Convert.ToString(rcmb_FinancialPeriod.SelectedValue) + "','" + Convert.ToString(rcmb_PeriodElements.SelectedValue) + "','" + Convert.ToString(Request.QueryString["Control"]) + "');", true);
            }
            else if (control == "8" || control == "9")
            {
                if (control == "9")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPopSts9('" + Convert.ToInt32(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_SalStruct.SelectedValue) + "','" + Convert.ToString(rcmb_FinancialPeriod.SelectedValue) + "','" + Convert.ToString(rcmb_PeriodElements.SelectedValue) + "','" + rcbStatus.SelectedValue + "','" + Convert.ToString(Request.QueryString["Control"]) + "','" + Convert.ToString(Request.QueryString["Control"]) + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPopGN('" + Convert.ToInt32(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_SalStruct.SelectedValue) + "','" + Convert.ToString(rcmb_FinancialPeriod.SelectedValue) + "','" + Convert.ToString(rcmb_PeriodElements.SelectedValue) + "','" + Convert.ToString(Request.QueryString["Control"]) + "','" + Convert.ToString(Request.QueryString["Control"]) + "');", true);
                }
            }
            else if (control == "10" || control == "12")
            {
                if (control == "10")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPopSts10('" + Convert.ToInt32(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_SalStruct.SelectedValue) + "','" + Convert.ToString(rcmb_FinancialPeriod.SelectedValue) + "','" + rcbStatus.SelectedValue + "','" + Convert.ToString(Request.QueryString["Control"]) + "','" + Convert.ToString(Request.QueryString["Control"]) + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPopBS('" + Convert.ToInt32(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_SalStruct.SelectedValue) + "','" + Convert.ToString(rcmb_FinancialPeriod.SelectedValue) + "','" + Convert.ToString(Request.QueryString["Control"]) + "','" + Convert.ToString(Request.QueryString["Control"]) + "');", true);
                }
            }
            else if (control == "11")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPopST('" + Convert.ToInt32(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_PayItem.SelectedValue) + "','" + Convert.ToString(rcmb_FinancialPeriod.SelectedValue) + "','" + Convert.ToString(rcmb_PeriodElements.SelectedValue) + "','" + Convert.ToString(Request.QueryString["Control"]) + "');", true);
            }
            else if (control == "13" || control == "14")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPopEOP('" + Convert.ToInt32(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_FinancialPeriod.SelectedValue) + "','" + Convert.ToString(rcmb_PeriodElements.SelectedValue) + "','" + Convert.ToString(Request.QueryString["Control"]) + "');", true);
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeDueIncrement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_BusinessUnit.SelectedIndex = 0;
            rcmb_IncrementMonth.SelectedIndex = 0;
            rcmb_FinancialPeriod.SelectedIndex = 0;
            rcmb_PeriodElements.Items.Clear();
            rcmb_PeriodElements.Text = string.Empty;
            rcmb_Branch.Items.Clear();
            rcmb_Branch.Text = string.Empty;
            rcbStatus.SelectedValue = null;

            rcmb_Bank.SelectedIndex = 0;
            rcmb_VoteCode.SelectedIndex = 0;
            rcmb_SalStruct.SelectedIndex = 0;
            string control = Convert.ToString(Request.QueryString["Control"]);
            if (control == "11")
            {
                rcmb_PayItem.Items.Clear();
                rcmb_PayItem.Text = string.Empty;

                //rcmb_PayItem.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else if (control == "3" || control == "4" || control == "5" || control == "6")
            {
                rcmb_PayItem.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeDueIncrement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}