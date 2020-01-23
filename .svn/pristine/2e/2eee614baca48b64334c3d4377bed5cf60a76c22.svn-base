using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using System.Text;
using Telerik.Web.UI;

public partial class Payroll_frm_emploantran : System.Web.UI.Page
{
    static int Currency;
    static string Cur = "";
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    static int popVal = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            RWOrgDetails.VisibleOnPageLoad = false;
            if (!Page.IsPostBack)
            {
                popVal = 0;
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Loan/Advances");//LOAN_ADVANCES");

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
                    Rg_Loandet.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Calculate.Visible = false;
                    btn_process.Visible = false;
                    btn_RSchedProcess.Visible = false;
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

                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdtp_IssueDate, rdtp_EffectiveDate);
                BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), Rg_Loandet, "LOANTRANS_ISSUEDATE");
                Loaddropdowns();
                //LoadGrid();
                cheque.Visible = false;
                LoadDetails();
                Rm_Loan_page.SelectedIndex = 0;
               //rdtp_EffectiveDate.MaxDate = DateTime.Now;
                //if(Session["LOANTRANS_LOANINSTALL"]==null)
                //{

                //}
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    //protected void lnk_Add_Command(object sender, CommandEventArgs e)
    //{
    //    Rm_Loan_page.SelectedIndex = 1;
    //    //rd_LOANTRANS.Tabs[1].Enabled = false;
    //    //rd_LOANTRANS.Tabs[2].Enabled = false;
    //    rcmb_Employee.Enabled = true;
    //    btn_Save.Visible = true;
    //    btn_Save.Enabled = true;
    //    btn_Update.Visible = false;
    //    Session["datatable"] = null;

    //}

    protected void Loaddropdowns()
    {
        try
        {
            rcmb_BusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BusinessUnit.DataSource = dt_BUDetails;
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            //Load PayItem Type
            rcmb_loantype.Items.Clear();
            SMHR_PAYITEMS _obj_Payitems = new SMHR_PAYITEMS();
            _obj_Payitems.OPERATION = operation.Check1;
            _obj_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            if (!string.IsNullOrEmpty(hdn_LoanProcessType.Value))
            {
                _obj_Payitems.PAYITEM_LOAN_PROCESSTYPE = Convert.ToInt32(hdn_LoanProcessType.Value);
            }
            rcmb_loantype.DataSource = BLL.get_PayItems(_obj_Payitems);
            rcmb_loantype.DataTextField = "PAYITEM_PAYITEMNAME";
            rcmb_loantype.DataValueField = "PAYITEM_ID";
            rcmb_loantype.DataBind();
            rcmb_loantype.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_Employee.Items.Clear();
            SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
            _obj_Smhr_LeaveApp.MODE = 2;
            _obj_Smhr_LeaveApp.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            DataTable dtemp = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
            rcmb_Employee.DataSource = dtemp;
            if (rcmb_BusinessUnit.SelectedIndex > 0)
            {
                if (dtemp.Rows.Count != 0)
                {
                    Cur = Convert.ToString(dtemp.Rows[0]["CURRENCY"]);
                    rcmb_Employee.DataTextField = "EMPNAME";
                    rcmb_Employee.DataValueField = "EMP_ID";
                    rcmb_Employee.DataBind();
                    rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                    LoadPaymentType();
                }
                else
                {
                    BLL.ShowMessage(this, "There are No employees in this Business Unit, Please select another");
                }
            }
            else
            {
                rcmb_Employee.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Employee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Employee.SelectedIndex > 0)
            {
                DataTable dtdoj = new DataTable();
                SMHR_EMPOTTRANS _obj_Smhr_EmpOTTrans = new SMHR_EMPOTTRANS();
                _obj_Smhr_EmpOTTrans.OPERATION = operation.Check;
                _obj_Smhr_EmpOTTrans.EMPOTTRANS_EMPID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
                dtdoj = BLL.getValues_EmpOTTrans(_obj_Smhr_EmpOTTrans);
                lbl_LoanDetEmpDOJ.Text = Convert.ToString(dtdoj.Rows[0]["EMP_DOJ"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
            _obj_smhr_loantrans.OPERATION = operation.Select1;
            _obj_smhr_loantrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_loantrans.LOANTRAN_TYPE = Convert.ToBoolean(0);
            _obj_smhr_loantrans.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            Rg_Loandet.DataSource = BLL.get_EmpLoanTran(_obj_smhr_loantrans);
            //}
            //else
            //{
            //   
            //    SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
            //    _obj_smhr_loantrans.OPERATION = operation.Select_Self;
            //    _obj_smhr_loantrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    _obj_smhr_loantrans.LOANTRAN_TYPE = Convert.ToBoolean(0);
            //    _obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            //    Rg_Loandet.DataSource = BLL.get_EmpLoanTran(_obj_smhr_loantrans);
            //    Rg_Loandet.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void getLoanNo()
    {
        try
        {
            DataTable dt_code;
            string code = string.Empty;
            string str = string.Empty;
            string Series = string.Empty;
            SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
            _obj_smhr_loantrans.OPERATION = operation.Empty;
            _obj_smhr_loantrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_code = BLL.get_EmpLoanTran(_obj_smhr_loantrans);
            if (dt_code.Rows.Count != 0)
            {
                str = dt_code.Rows[0][0].ToString().Trim();
                if (str.Length == 1)
                {
                    Series = "000";
                }
                else if (str.Length == 2)
                {
                    Series = "00";
                }
                else if (str.Length == 3)
                {
                    Series = "00";
                }
                else if (str.Length == 4)
                {
                    Series = "0";
                }
                SMHR_GLOBALCONFIG _obj_smhr_globalconfig = new SMHR_GLOBALCONFIG();
                _obj_smhr_globalconfig.OPERATION = operation.Select;
                _obj_smhr_globalconfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_ConfigDetails(_obj_smhr_globalconfig);
                if (dt.Rows.Count != 0)
                {
                    rtxt_loanno.Text = dt.Rows[0]["GLOBALCONFIG_LOAN_NO"].ToString().Trim() + Convert.ToString(Series) + Convert.ToString(str);
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Calculate1_Click(object sender, EventArgs e)
    {
        try
        {
            // getLoanNo();
            if (Convert.ToInt32(ddl_PayMode.SelectedIndex) == 0 && Convert.ToString(ViewState["LOANTRANS_PROCESS_TYPE"]) != "Standard")
            {
                BLL.ShowMessage(this, "Please Select PayItem Mode");
                return;

            }

            if (Convert.ToInt32(rtxt_installments.Value) == 0)
            {
                BLL.ShowMessage(this, "No. of Instalments should be greater than 0");
                return;
            }


            if (ViewState["LOANTRANS_PROCESS_TYPE"] != null && Convert.ToString(ViewState["LOANTRANS_PROCESS_TYPE"]) == "Standard" && ViewState["LOANTRANS_INTERESTRATE"] != null)
            {
                #region Calculation for Standard Loan

                SMHR_LOANTRANSDTL _obj_SMHR_LOANTRANSDTL = new SMHR_LOANTRANSDTL();

                _obj_SMHR_LOANTRANSDTL.LOANTRADTL_LOANTRAN_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
                _obj_SMHR_LOANTRANSDTL.OPERATION = operation.Select_New;

                DataTable dtLnTrnDtl = BLL.get_EmpLoanTranDetail(_obj_SMHR_LOANTRANSDTL);

                if (rtxt_loanno.Text == string.Empty || Convert.ToInt32(ViewState["LoanStatus"]) == 0)
                {
                    int i = 0;
                    double defaultEMI, noOFInstall, totalAmount, interestAmount;
                    string lnEmiStatus = string.Empty; 

                    DataTable dtStdLn = new DataTable();

                    dtStdLn.Columns.Add("LOANTRANDTL_CURR_EMINO", typeof(int));
                    dtStdLn.Columns.Add("LOANTRANS_INTERESTRATE", typeof(double));
                    dtStdLn.Columns.Add("LOANTRANDTL_EMIPAYMENTDUEDATE", typeof(string));
                    dtStdLn.Columns.Add("LOANTRANDTL_EMIAMOUNT", typeof(double));
                    dtStdLn.Columns.Add("LOANTRANDTL_INTEREST", typeof(double));
                    dtStdLn.Columns.Add("LOANTRANDTL_CURRENTLOANAMOUNt", typeof(double));
                    dtStdLn.Columns.Add("LOANTRANDTL_EMISTATUS", typeof(string));

                    totalAmount = Convert.ToDouble(rtxt_Amount.Text);
                    noOFInstall = Convert.ToDouble(rtxt_installments.Text);
                    interestAmount = 0;
                    defaultEMI = 0;

                    defaultEMI = Math.Round((totalAmount / noOFInstall), 2);
                    interestAmount = Math.Round(((defaultEMI * (Convert.ToDouble(ViewState["LOANTRANS_INTERESTRATE"]))) / 100), 2);

                    //if((dtLnTrnDtl.Rows.Count == noOFInstall)&& noOFInstall > 0)
                    // {
                    while (i <= noOFInstall)
                    {
                        if (dtLnTrnDtl.Rows.Count > 0 && i != noOFInstall)
                        {
                            if (Convert.ToInt32(dtLnTrnDtl.Rows[i]["LOANTRANDTL_EMISTATUS"]) == 0)
                            {
                                lnEmiStatus = "OPEN";
                            }
                            else if (Convert.ToInt32(dtLnTrnDtl.Rows[i]["LOANTRANDTL_EMISTATUS"]) == 2)
                            {
                                lnEmiStatus = "POSTPONED";
                            }
                            else
                                lnEmiStatus = "CLOSED";
                        }

                        else
                            lnEmiStatus = "OPEN";

                        if (i == 0)
                            dtStdLn.Rows.Add(i, null, null, null, null, totalAmount, null);
                        else
                        {
                            DateTime date;
                            if (i == 1)
                            {
                                if (Convert.ToInt32(Convert.ToDateTime(rdtp_EffectiveDate.SelectedDate).Day) <= 25)
                                    date = Convert.ToDateTime(rdtp_EffectiveDate.SelectedDate);
                                else
                                    date = Convert.ToDateTime(rdtp_EffectiveDate.SelectedDate).AddMonths(i);
                            }
                            else
                            {
                                if (Convert.ToInt32(Convert.ToDateTime(rdtp_EffectiveDate.SelectedDate).Day) <= 25)
                                    date = Convert.ToDateTime(rdtp_EffectiveDate.SelectedDate).AddMonths(i - 1);
                                else
                                    date = Convert.ToDateTime(rdtp_EffectiveDate.SelectedDate).AddMonths(i);
                            }
                            //date = Convert.ToDateTime(rdtp_EffectiveDate.SelectedDate).AddMonths(i);
                            var firstDayOfEveryMonth = new DateTime(date.Year, date.Month, 25);

                            if (i == noOFInstall)
                                dtStdLn.Rows.Add(i, Convert.ToString(ViewState["LOANTRANS_INTERESTRATE"]), firstDayOfEveryMonth.ToString("dd/MM/yyyy"), defaultEMI, interestAmount, 0, lnEmiStatus);
                            else if ((i + 1) == noOFInstall)
                                dtStdLn.Rows.Add(i, Convert.ToString(ViewState["LOANTRANS_INTERESTRATE"]), firstDayOfEveryMonth.ToString("dd/MM/yyyy"), defaultEMI, interestAmount, defaultEMI, lnEmiStatus);
                            else
                                dtStdLn.Rows.Add(i, Convert.ToString(ViewState["LOANTRANS_INTERESTRATE"]), firstDayOfEveryMonth.ToString("dd/MM/yyyy"), defaultEMI, interestAmount, totalAmount, lnEmiStatus);
                        }
                        totalAmount = Math.Round((totalAmount - defaultEMI), 2);
                        i++;

                    }
                    //}
                    //else
                    //{
                    //    BLL.ShowMessage(this,"...");
                    //    return;
                    //}

                    Session["stdLoanEMI"] = dtStdLn;

                    rgStdLoan.DataSource = dtStdLn;
                    rgStdLoan.DataBind();

                    rtxt_MonthlyEMI.Text = Convert.ToString(defaultEMI);
                }
                else
                {
                    Session["stdLoanEMI"] = dtLnTrnDtl;
                    rgStdLoan.DataSource = dtLnTrnDtl;
                    rgStdLoan.DataBind();
                    if (rtxt_MonthlyEMI.Text != "")
                    {
                        rtxt_MonthlyEMI.Text = Convert.ToString(dtLnTrnDtl.Rows[0]["LOANTRANDTL_EMIAMOUNT"]);
                    }
                    else
                        rtxt_MonthlyEMI.Text = "";
                }

                if (popVal == 0)
                {
                    RWOrgDetails.Height = 400;
                    RWOrgDetails.Width = 600;
                    RWOrgDetails.Visible = true;
                    RWOrgDetails.VisibleOnPageLoad = true;
                }

                popVal = 0;
                lnkbtn_EMIDATA.Visible = false;

                hdnMaxTenureMonths.Value = Convert.ToString(ViewState["LOANSETUP_MAXTENUREMONTHS"]);
                hdnMinTenureMonths.Value = Convert.ToString(ViewState["LOANSETUP_MINTENUREMONTHS"]);

                #endregion
            }
            else
            {


                SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
                _obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
                //_obj_smhr_loantrans.LOANTRANS_LOANNO = Convert.ToString(1);
                _obj_smhr_loantrans.LOANTRANS_LOANNO = Convert.ToString(rtxt_loanno.Text);
                _obj_smhr_loantrans.LOANTRANS_LOANTYPE_ID = Convert.ToInt32(rcmb_loantype.SelectedItem.Value);
                _obj_smhr_loantrans.LOANTRANS_ISSUEDATE = Convert.ToDateTime(rdtp_IssueDate.SelectedDate);
                _obj_smhr_loantrans.LOANTRANS_LOANAMOUNT = Convert.ToDouble(rtxt_Amount.Value);
                _obj_smhr_loantrans.LOANTRANS_LOANINSTALL = Convert.ToInt32(rtxt_installments.Value);
                _obj_smhr_loantrans.LOANTRANS_INTERESTAMT = Convert.ToDouble(rtxt_InterestAmt.Value);
                _obj_smhr_loantrans.LOANTRAN_LOANPURPOSE = BLL.ReplaceQuote(Convert.ToString(rtxt_purpose.Text));
                _obj_smhr_loantrans.LOANTRANS_EFFDATE = Convert.ToDateTime(rdtp_EffectiveDate.SelectedDate);
                _obj_smhr_loantrans.LOANTRAN_CREATEDDATE = System.DateTime.Now;
                _obj_smhr_loantrans.LOANTRAN_CHEQUENUM = Convert.ToDouble(txt_ChequeNumber.Value);

                _obj_smhr_loantrans.LOANTRAN_TYPE = false;
                _obj_smhr_loantrans.LOANTRAN_PAYMODE = Convert.ToInt32(ddl_PayMode.SelectedValue);
                _obj_smhr_loantrans.LOANTRAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_loantrans.LOANTRAN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_loantrans.LOANTRAN_LASTMDFDATE = System.DateTime.Now;
                _obj_smhr_loantrans.CONFIRM = "n";
                if (Convert.ToInt32(ViewState["LoanStatus"]) == 0)
                {
                    _obj_smhr_loantrans.LOANTRAN_STATUS = 0;
                }
                else if (Convert.ToInt32(ViewState["LoanStatus"]) == 1)
                {
                    _obj_smhr_loantrans.LOANTRAN_STATUS = 1;
                }
                //   _obj_smhr_loantrans.LOANTRAN_STATUS = 0; 
                DataTable dtvalues = new DataTable();
                _obj_smhr_loantrans.LOANTRANS_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
                //if (string.Compare(rcmb_loantype.SelectedItem.Text, "Deposits-Kenya", true) == 0
                //    || string.Compare(rcmb_loantype.SelectedItem.Text, "Bucoso-Accrued Interest", true) == 0
                //    || string.Compare(rcmb_loantype.SelectedItem.Text, "Bucoso-Sinking Fund", true) == 0
                //    || string.Compare(rcmb_loantype.SelectedItem.Text, "Bucoso-Entrance Fee", true) == 0)
                //{
                //    SMHR_LOANREQUEST _obj_Smhr_Loanrequest = new SMHR_LOANREQUEST();
                //    _obj_Smhr_Loanrequest.OPERATION = operation.USERLOANTRANEMI;
                //    _obj_Smhr_Loanrequest.SMHR_LOANREQUEST_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
                //    dtvalues = BLL.get_LoanRequest(_obj_Smhr_Loanrequest);
                //}
                if (!string.IsNullOrEmpty(hdn_LoanProcessType.Value) && string.Compare(hdn_LoanProcessType.Value, "1", true) == 0)
                {
                    //SMHR_LOANREQUEST _obj_Smhr_Loanrequest = new SMHR_LOANREQUEST();
                    //_obj_Smhr_Loanrequest.OPERATION = operation.USERLOANTRANEMI;
                    //_obj_Smhr_Loanrequest.SMHR_LOANREQUEST_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
                    //dtvalues = BLL.get_LoanRequest(_obj_Smhr_Loanrequest);

                    /* Fetching details from "SMHR_LOANTRANDTL" table, because the records in "SMHR_USERLOANEMI" gets deleted once the loan is closed */
                    SMHR_LOANTRANSDTL objLoanTransDtl = new SMHR_LOANTRANSDTL();
                    objLoanTransDtl.OPERATION = operation.Select_New;
                    objLoanTransDtl.LOANTRADTL_LOANTRAN_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
                    dtvalues = BLL.get_LoanDetails(objLoanTransDtl);
                }
                else if (!string.IsNullOrEmpty(hdn_IsLoanSanctioned.Value) && string.Compare(hdn_IsLoanSanctioned.Value, "1", true) == 0) //if loan is already sanctioned
                {
                    SMHR_LOANTRANSDTL objLoanTransDtl = new SMHR_LOANTRANSDTL();
                    objLoanTransDtl.OPERATION = operation.Select_New;
                    objLoanTransDtl.LOANTRADTL_LOANTRAN_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
                    dtvalues = BLL.get_LoanDetails(objLoanTransDtl);
                }
                else
                {
                    dtvalues = BLL.Calculate_EMI(_obj_smhr_loantrans);
                }
                rtxt_MonthlyEMI.Text = Convert.ToString(dtvalues.Rows[0]["EMI AMOUNT"]);
                lnkbtn_EMIDATA.Visible = true;
                //ViewState["EMIData"] = dtvalues;
                Session["datatable"] = dtvalues;
                //lnkbtn_EMIDATA.OnClientClick ="  openRadWin('frm_loanemidata.aspx?tranid=" + Convert.ToInt32(dtvalues.Rows[0]["LOANTRADTL_LOANTRAN_ID"]) + "'); return false;";
                lnkbtn_EMIDATA.OnClientClick = "openRadWin('frm_loanemidata.aspx'); return false;";
                // btn_Save.Visible = false;

                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {

                    btn_Save.Visible = false;
                    btn_Save.Enabled = false;

                }

                else
                {
                    //   btn_Save.Visible = true;
                    //btn_Save.Enabled = true;
                }
            }

            //btn_Calculate.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmiData()
    {
        try
        {
            SMHR_LOANTRANSDTL _obj_smhr_loantransdtl = new SMHR_LOANTRANSDTL();
            if (Convert.ToString(Request.QueryString["tranid"]) != null)
            {
                _obj_smhr_loantransdtl.OPERATION = operation.Select;
                _obj_smhr_loantransdtl.LOANTRADTL_LOANTRAN_ID = Convert.ToInt32(Request.QueryString["tranid"]);
                DataTable dt = new DataTable();
                dt = BLL.get_EmpLoanTranDetail(_obj_smhr_loantransdtl);
                if (dt.Rows.Count != 0)
                {
                    //R.DataSource = dt;
                    //RG_EMIDate.DataBind();
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (lblissue.Text != string.Empty)
            {
                if (rdtp_IssueDate.SelectedDate < Convert.ToDateTime(lblissue.Text))
                {
                    BLL.ShowMessage(this, "Loan Issue Date cannot be ahead of Applied Date.");
                    return;
                }
            }
            if (Convert.ToInt32(rtxt_installments.Value) == 0)
            {
                BLL.ShowMessage(this, "No. of Instalments should be greater than 0");
                return;
            }
            if (Convert.ToInt32(ddl_PayMode.SelectedIndex) == 0)
            {
                BLL.ShowMessage(this, "Please Select PayItem Mode");
                return;

            }
            SMHR_LOANTRANS _obj_smhr_LoanTrans = new SMHR_LOANTRANS();
            SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
            _obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
            _obj_smhr_loantrans.LOANTRANS_LOANNO = Convert.ToString(rtxt_loanno.Text);
            _obj_smhr_loantrans.LOANTRANS_LOANTYPE_ID = Convert.ToInt32(rcmb_loantype.SelectedItem.Value);
            _obj_smhr_loantrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            if (lbl_LoanDetEmpDOJ.Text != string.Empty)
            {
                if (rdtp_IssueDate.SelectedDate < Convert.ToDateTime(lbl_LoanDetEmpDOJ.Text))
                {
                    BLL.ShowMessage(this, "Loan Issue Date cannot be ahead of Employee Joining Date");
                    return;
                }
            }
            else if (rdtp_IssueDate.SelectedDate > System.DateTime.Now)
            {
                BLL.ShowMessage(this, "Loan Issue Date cannot be ahead of Todays Date");
                return;
            }
            else
            {
                _obj_smhr_loantrans.LOANTRANS_ISSUEDATE = Convert.ToDateTime(rdtp_IssueDate.SelectedDate);
            }
            _obj_smhr_loantrans.LOANTRANS_INTERESTRATE = Convert.ToDouble(ViewState["LOANTRANS_INTERESTRATE"]);
            _obj_smhr_loantrans.LOANTRANS_LOANAMOUNT = Convert.ToDouble(rtxt_Amount.Value);
            _obj_smhr_loantrans.LOANTRANS_LOANINSTALL = Convert.ToInt32(rtxt_installments.Value);
            _obj_smhr_loantrans.LOANTRANS_INTERESTAMT = Convert.ToDouble(rtxt_InterestAmt.Value);
            _obj_smhr_loantrans.LOANTRAN_LOANPURPOSE = BLL.ReplaceQuote(Convert.ToString(rtxt_purpose.Text));
            _obj_smhr_loantrans.LOANTRANS_EFFDATE = Convert.ToDateTime(rdtp_EffectiveDate.SelectedDate);
            _obj_smhr_loantrans.LOANTRAN_PAYMODE = Convert.ToInt32(ddl_PayMode.SelectedValue);
            if (txt_ChequeNumber.Value != null)
                _obj_smhr_loantrans.LOANTRAN_CHEQUENUM = Convert.ToDouble(txt_ChequeNumber.Value);
            else
                _obj_smhr_loantrans.LOANTRAN_CHEQUENUM = 0;
            _obj_smhr_loantrans.LOANTRAN_CREATEDDATE = System.DateTime.Now;
            _obj_smhr_loantrans.LOANTRAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_loantrans.LOANTRAN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_loantrans.LOANTRAN_LASTMDFDATE = System.DateTime.Now;
            //  _obj_smhr_loantrans.CONFIRM = "Y";

            _obj_smhr_loantrans.LOANTRAN_TYPE = false;
            //  _obj_smhr_loantrans.LOANTRAN_STATUS = 0; 
            _obj_smhr_loantrans.LOANTRANS_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
            _obj_smhr_loantrans.LOANNAME = rcmb_loantype.SelectedItem.Text;
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":

                    bool result1;
                    //      SMHR_LOANTRANS _obj_smhr_LoanTrans = new SMHR_LOANTRANS();
                    _obj_smhr_loantrans.LOANTRAN_STATUS = 0;
                    _obj_smhr_loantrans.CONFIRM = "n";
                    _obj_smhr_loantrans.OPERATION = operation.Update;
                    _obj_smhr_LoanTrans.LOANTRANS_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
                    result1 = BLL.set_EmpLoanTrans(_obj_smhr_loantrans);
                    if (result1 == true)
                    {
                        BLL.ShowMessage(this, "Information Updated Successfully.");
                    }
                    else
                        BLL.ShowMessage(this, "Information not Updated ");
                    ClearControls();
                    Rm_Loan_page.SelectedIndex = 0;
                    LoadGrid();
                    Rg_Loandet.DataBind();

                    break;
                case "BTN_SAVE":

                    getLoanNo();
                    bool result;
                    _obj_smhr_LoanTrans.LOANTRANS_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
                    _obj_smhr_loantrans.OPERATION = operation.Insert;
                    _obj_smhr_loantrans.CONFIRM = "n";
                    _obj_smhr_loantrans.LOANTRAN_STATUS = 0;
                    _obj_smhr_LoanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_loantrans.LOANTRANS_LOANNO = Convert.ToString(rtxt_loanno.Text);
                    result = BLL.set_EmpLoanTrans(_obj_smhr_loantrans);
                    if (result == true)
                    {
                        BLL.ShowMessage(this, "Information Saved successfully");
                    }
                    else
                        BLL.ShowMessage(this, "Loan Transaction failed");

                    ClearControls();
                    Rm_Loan_page.SelectedIndex = 0;
                    LoadGrid();
                    Rg_Loandet.DataBind();

                    break;
                default:
                    break;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }

    protected void Rg_Loandet_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            hdn_IsLoanSanctioned.Value = null;  //To clear hidden field before editing
            btn_Calculate.Text = "Calculate EMI";

            Rm_Loan_page.SelectedIndex = 1;
            RPV_Loans.Selected = true;
            //Rm_Loan_page.SelectedIndex = 1;
            //RPV_RPTDetails.Selected = true;
            //rd_LOANTRANS.SelectedIndex = 0;
            //rd_LOANTRANS.Tabs[0].Enabled = true;

            //  SMHR_LOANTRANDTL_POSTPONE obj_postpone = new SMHR_LOANTRANDTL_POSTPONE();



            SMHR_LOANTRANS _obj_smhr_LoanTrans = new SMHR_LOANTRANS();
            Loaddropdowns();
            _obj_smhr_LoanTrans.LOANTRANS_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            lbl_loantrans_ID.Text = Convert.ToString(Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            _obj_smhr_LoanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_LoanTrans.OPERATION = operation.Validate;
            DataTable dt_check = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);
            if (dt_check.Rows.Count > 0)
            {
                ViewState["LOANTRANS_PROCESS_TYPE"] = Convert.ToString(dt_check.Rows[0]["LOANTRANS_PROCESS_TYPE"]);
                ViewState["LOANTRANS_INTERESTRATE"] = Convert.ToString(dt_check.Rows[0]["LOANTRANS_INTERESTRATE"]);
                hfLoanProcessType.Value = Convert.ToString(dt_check.Rows[0]["LOANSETUP_LOANPROCESSTYPE"]);
                ViewState["LOANSETUP_MINTENUREMONTHS"] = Convert.ToString(dt_check.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                ViewState["LOANSETUP_MAXTENUREMONTHS"] = Convert.ToString(dt_check.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);
                rcbLoanPrcsType.SelectedValue = Convert.ToString(dt_check.Rows[0]["LOANTRANS_PROCESS_TYPE"]);
                if (Convert.ToString(dt_check.Rows[0]["LOANTRAN_STATUS"]) == "0")
                {
                    //BLL.ShowMessage(this, "Please first Sanction the Loan.");
                    //return;
                    ViewState["LoanStatus"] = 0;
                    rcmb_BusinessUnit.Enabled = false;
                    rcmb_Employee.Enabled = false;
                    rcmb_loantype.Enabled = false;
                    rdtp_IssueDate.Enabled = false;
                    rtxt_RloanNo.Enabled = false;
                    btn_Update.Visible = false;
                    //btn_Save.Visible = true;
                    //btn_Save.Enabled = true;
                    btn_Sanction.Enabled = true;
                    if (dt_check.Rows[0]["LOANTRANS_LOANNO"] != System.DBNull.Value)
                    {
                        btn_Update.Visible = true;
                        btn_Update.Enabled = true;
                        btn_Save.Visible = false;
                        btn_Save.Enabled = false;
                    }
                    else
                    {
                        btn_Save.Visible = true;
                        btn_Save.Enabled = true;
                        btn_Update.Visible = false;
                        btn_Update.Enabled = false;
                        lnkbtn_EMIDATA.Visible = false;
                        rdtp_EffectiveDate.SelectedDate = null;

                    }
                    //  btn_Update.Enabled = true; 
                }
                else if (Convert.ToString(dt_check.Rows[0]["LOANTRAN_STATUS"]) == "1")
                {
                    if (Convert.ToString(dt_check.Rows[0]["IsLoanStarted"]) == "0" && Convert.ToInt32(dt_check.Rows[0]["IsIncreasingLoan"]) == 0)
                    {
                        ViewState["LoanStatus"] = 1;

                        btn_Save.Visible = true;
                        btn_Save.Enabled = false;
                        btn_Sanction.Enabled = true;
                        btn_Update.Visible = false;
                        btn_Update.Enabled = false;
                        EnabledFields(true);
                        rcmb_BusinessUnit.Enabled = false;
                        rcmb_Employee.Enabled = false;
                        rcmb_loantype.Enabled = false;
                        rdtp_IssueDate.Enabled = false;
                        rtxt_RloanNo.Enabled = false;
                        ddl_PayMode.Enabled = false;

                    }
                    else
                    {
                        ViewState["LoanStatus"] = 1;
                        btn_Save.Visible = true;
                        btn_Save.Enabled = false;
                        btn_Sanction.Enabled = false;
                        btn_Update.Visible = false;
                        btn_Update.Enabled = false;
                        EnabledFields(false);
                    }
                }
            }
            if (Convert.ToString(dt_check.Rows[0]["LOANSETUP_LOANPROCESSTYPE"]) != "Standard")
            {
                lnkbtn_EMIDATA.Visible = true;
                //btn_Calculate.Text = "Calcualte EMI";
                popVal = 0;
            }
            else
            {
                lnkbtn_EMIDATA.Visible = false;
                //btn_Calculate.Text = "View EMI";
                popVal++;
            }
            Rm_Loan_page.SelectedIndex = 1;
            //rd_LOANTRANS.Tabs[1].Enabled = false;
            // _obj_smhr_LoanTrans.LOANTRANS_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            // _obj_smhr_LoanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_LoanTrans.OPERATION = operation.Select;
            DataTable dt = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);

            /* To check whether atleast one EMI is closed (payroll has run) */
            if (Convert.ToBoolean(dt.Rows[0]["IsLoanStarted"]))
            {
                btn_Delete.Visible = false;
            }
            else
            {
                btn_Delete.Visible = true;
            }
            /* To check whether atleast one EMI is closed (payroll has run) */

            //btn_Save.Visible = true;
            //btn_Update.Visible = false; 
            //  btn_Sanction.Enabled = false; 
            //    EnabledFields(false);
            hdn_LoanProcessType.Value = Convert.ToString(dt.Rows[0]["PAYITEM_LOAN_PROCESSTYPE"]);
            hdn_IsLoanSanctioned.Value = Convert.ToString(dt.Rows[0]["IsLoanSanctioned"]);
            hdnClosedEMICount.Value = Convert.ToString(dt.Rows[0]["ClosedEmiCount"]);   //To hold Closed EMI's count
            Loaddropdowns();
            // Getting Employee Name
            if ((Convert.ToInt32(dt_check.Rows[0]["EMP_STATUS"]) == 0) || (Convert.ToInt32(dt_check.Rows[0]["EMP_STATUS"]) == 1))
            {
                _obj_smhr_LoanTrans.BUSINESSUNIT_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
                _obj_smhr_LoanTrans.LOANTRANS_EMP_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["LOANTRANS_EMP_ID"]));
                _obj_smhr_LoanTrans.OPERATION = operation.Empty;
                DataTable dtemp = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);
                rcmb_Employee.DataSource = dtemp;
                rcmb_Employee.DataTextField = "EMPNAME";
                rcmb_Employee.DataValueField = "EMP_ID";
                rcmb_Employee.DataBind();
                rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_EMP_ID"]));
            }
            else if ((Convert.ToInt32(dt_check.Rows[0]["EMP_STATUS"]) == 2) || (Convert.ToInt32(dt_check.Rows[0]["EMP_STATUS"]) == 3))  // || (Convert.ToInt32(dt_check.Rows[0]["EMP_STATUS"]) == 4))
            {
                _obj_smhr_LoanTrans.BUSINESSUNIT_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
                _obj_smhr_LoanTrans.LOANTRANS_EMP_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["LOANTRANS_EMP_ID"]));
                _obj_smhr_LoanTrans.OPERATION = operation.EMPTY_R;
                DataTable dtemp = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);
                rcmb_Employee.DataSource = dtemp;
                rcmb_Employee.DataTextField = "EMPNAME";
                rcmb_Employee.DataValueField = "EMP_ID";
                rcmb_Employee.DataBind();
                rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_EMP_ID"]));
            }
            rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            //lbl_Curr.Text = Convert.ToString(dtemp.Rows[0]["CURRENCY"]);
            LoadPaymentType();


            //   ddl_PayMode_SelectedIndexChanged(null, null);

            ddl_PayMode.SelectedIndex = ddl_PayMode.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRAN_PAYMODE"]));
            if (ddl_PayMode.SelectedItem.Text.ToUpper() == "CHEQUE")
            {
                cheque.Visible = true;
                // txt_ChequeNumber.Text = string.Empty;
                txt_ChequeNumber.Value = Convert.ToDouble(dt.Rows[0]["LOANTRAN_CHEQUENUM"]);
            }
            else
            {
                cheque.Visible = false;
            }

            ////////if (dt.Rows[0]["LOANTRAN_CHEQUENUM"] != System.DBNull.Value)
            ////////{
            ////////    txt_ChequeNumber.Value = Convert.ToDouble(dt.Rows[0]["LOANTRAN_CHEQUENUM"]);
            ////////    ViewState["ChequeNo"] = txt_ChequeNumber.Value;
            ////////    // txt_ChequeNumber.Value = dt.Rows[0]["LOANTRAN_CHEQUENUM"];
            ////////    cheque.Visible = true;
            ////////}
            //////else
            //////{
            //////    if (ddl_PayMode.SelectedItem.Text.ToUpper() == "CHEQUE")
            //////    {
            //////        cheque.Visible = true;
            //////        txt_ChequeNumber.Text = string.Empty;
            //////        ViewState["LoanPayMode"] = ddl_PayMode.SelectedItem.Text;
            //////    }
            //////}
            rtxt_loanno.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_LOANNO"]);
            rtxt_Amount.Value = Convert.ToDouble(dt.Rows[0]["LOANTRANS_LOANAMOUNT"]);
            rcmb_loantype.SelectedIndex = rcmb_loantype.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_LOANTYPE_ID"]));
            if (dt.Rows[0]["LOANTRANS_ISSUEDATE"] != System.DBNull.Value)
            {
                lblissue.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_ISSUEDATE"]);
                rdtp_IssueDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_ISSUEDATE"]);
            }
            else
            {
                lblissue.Text = string.Empty;
                rdtp_IssueDate.SelectedDate = null;
            }

            //if(dt.Rows[0]["LOANTRANS_ISSUEDATE"]!= System.DBNull.Value)
            //{
            //  rdtp_IssueDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_ISSUEDATE"]);
            //}
            if (dt.Rows[0]["LOANTRANS_LOANINSTALL"] != System.DBNull.Value)
            {
                rtxt_installments.Value = Convert.ToInt32(dt.Rows[0]["LOANTRANS_LOANINSTALL"]);
            }
            //  rtxt_installments.Value = Convert.ToInt32(dt.Rows[0]["LOANTRANS_LOANINSTALL"]);

            if (dt.Rows[0]["LOANTRANS_INTERESTRATE"] != System.DBNull.Value)
            {
                rtxt_InterestAmt.Value = Convert.ToDouble(dt.Rows[0]["LOANTRANS_INTERESTRATE"]);
            }
            else
            {
                rtxt_InterestAmt.Value = null;
            }

            rtxt_purpose.Text = Convert.ToString(dt.Rows[0]["LOANTRAN_LOANPURPOSE"]);
            if (dt.Rows[0]["LOANTRANS_EFFDATE"] != System.DBNull.Value)
            {
                ////if (dtLnTrnDtl.Rows[0]["LOANTRANDTL_EMISTATUS"] == "2")
                ////{
                ////    rdtp_EffectiveDate.SelectedDate = Convert.ToDateTime(dtStdLn.Rows[0]["STDLOAN_EMD"]);
                ////}
                ////    else
                rdtp_EffectiveDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_EFFDATE"]);
            }


            SMHR_LOANTRANSDTL _obj_smhr_loantrandtl = new SMHR_LOANTRANSDTL();
            _obj_smhr_loantrandtl.LOANTRADTL_LOANTRAN_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            DataTable dt_repay = BLL.get_EmpLoanTranDetail(_obj_smhr_loantrandtl);
            if (dt_repay.Rows.Count != 0)
            {
                if (ViewState["LOANTRANS_PROCESS_TYPE"] == null)
                    rtxt_MonthlyEMI.Text = Convert.ToString(dt_repay.Rows[0]["LOANTRANDTL_EMIAMOUNT"]);
                rtxt_RloanTrasnID.Text = (Convert.ToString(e.CommandArgument));
                rtxt_RloanNo.Text = Convert.ToString(dt_repay.Rows[0]["LOANTRANDTL_LOANNO"]);
                rtxt_RLoanBalanceAmt.Text = Convert.ToString(dt_repay.Rows[0]["REMAINING_LOAN"]);
                rtxt_Rinstallments.Text = Convert.ToString(dt_repay.Rows[0]["EMIS"]);
                if (dt.Rows[0]["LOANTRANS_INTERESTRATE"] != System.DBNull.Value)
                {
                    rtxt_RInterestRate.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_INTERESTRATE"]);
                }

                rtxt_RPrincipalBalanceAmt.Text = Convert.ToString(dt_repay.Rows[0]["REMAINING_PRINCIPAL"]);
                btn_Calculate1_Click(null, null);

            }
            else if (Convert.ToInt32(ddl_PayMode.SelectedIndex) == 0)
            {
                btn_Calculate1_Click(null, null);

            }
            else
            {
                btn_Calculate1_Click(null, null);
            }
            //   btn_Save.Visible = true;
            //  btn_Update.Visible = true;
            //return;

            //btn_Save.Visible = false;
            //btn_Update.Visible = true;


            if (Convert.ToString(dt_check.Rows[0]["LOANTRAN_STATUS"]) == "1")
            {
                btn_Delete.Visible = false;
                btn_Sanction.Enabled = false;
            }

            /* To find loan max eligibility */
            if (string.Compare(hdn_LoanProcessType.Value, "0", true) == 0)
            {
                #region Reducing Balance
                if (rcmb_loantype.SelectedIndex > 0)
                {
                    if (rcmb_Employee.SelectedItem == null || string.Compare(rcmb_Employee.SelectedItem.Text.ToLower(), "select", true) == 0)
                    {
                        BLL.ShowMessage(this, "Please select Employee");
                        rcmb_loantype.ClearSelection();
                        return;
                    }
                    else
                    {
                        SMHR_LOANSETUP oSMHR_LOANSETUP = new SMHR_LOANSETUP();
                        oSMHR_LOANSETUP.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        oSMHR_LOANSETUP.LOGIN_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                        oSMHR_LOANSETUP.LOANSETUP_LOANTYPE_ID = Convert.ToInt32(rcmb_loantype.SelectedValue);
                        oSMHR_LOANSETUP.LOANTRANS_ID = Convert.ToInt32(e.CommandArgument);
                        if (string.Compare(rcmb_loantype.SelectedItem.Text, "Salary Advance", true) == 0)//|| string.Compare(rcmb_LoanType.SelectedItem.Text, "Salary in Advance", true) != 0)
                        {
                            #region Salary Advance
                            //trBrowse.Visible = false;
                            oSMHR_LOANSETUP.OPERATION = operation.Select;
                            DataTable dtLoanSetup = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                            if (dtLoanSetup.Rows.Count > 0)
                            {
                                //trRateOfInterest.Visible = true;
                                //trLoanEligibleAmount.Visible = true;
                                lblLoanEligibleAmount.Text = Convert.ToInt32(dtLoanSetup.Rows[0]["EMP_BASIC"]).ToString();
                                //lblRateofInterest.Text = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_LOANINTEREST"]);
                                hdnMinTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                                hdnMaxTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);
                                hdnMaxeligibleMonthsforEmp.Value = Convert.ToString(dtLoanSetup.Rows[0]["MAXELIGIBLEMONTHSFOREMPLOYEE"]);
                            }
                            #endregion
                        }
                        else if (string.Compare(rcmb_loantype.SelectedItem.Text, "Salary in Advance", true) == 0)
                        {
                            #region Salary In Advance
                            //trBrowse.Visible = false;
                            oSMHR_LOANSETUP.OPERATION = operation.Validate;
                            oSMHR_LOANSETUP.Amount = 0;
                            oSMHR_LOANSETUP.EffectiveDate = DateTime.Now;
                            DataTable dtLoan = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                            oSMHR_LOANSETUP.OPERATION = operation.Select;
                            DataTable dtLoanSetup = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                            if (dtLoan.Rows.Count > 0 && dtLoanSetup.Rows.Count > 0)
                            {
                                if (Convert.ToBoolean(dtLoan.Rows[0]["FINAL"]))
                                {
                                    lblLoanEligibleAmount.Text = Convert.ToInt32(dtLoan.Rows[0]["AMOUNT"]).ToString();
                                    hdnMinTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                                    hdnMaxTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);
                                    hdnMaxeligibleMonthsforEmp.Value = Convert.ToString(dtLoanSetup.Rows[0]["MAXELIGIBLEMONTHSFOREMPLOYEE"]);
                                }
                            }
                            #endregion
                        }
                        #region Car Life Loans
                        #endregion
                        else
                        {
                            #region All Loans
                            oSMHR_LOANSETUP.OPERATION = operation.Check;
                            DataTable dtLoan = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                            if (dtLoan.Rows.Count > 0)
                            {
                                lblLoanEligibleAmount.Text = Convert.ToString(Math.Round(Convert.ToDecimal(dtLoan.Rows[0]["LOANELIGIBLEAMOUNT_MAXAMOUNT"]), 2));
                                hdnMinTenureMonths.Value = Convert.ToString(dtLoan.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                                hdnMaxTenureMonths.Value = Convert.ToString(dtLoan.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);
                                hdnMaxeligibleMonthsforEmp.Value = Convert.ToString(dtLoan.Rows[0]["MAXELIGIBLEMONTHSFOREMPLOYEE"]);
                            }
                            #endregion
                        }
                    }
                }
                #endregion
            }
            /* To find loan max eligibility */
            //rtxt_InterestRate.Text = rtxt_RInterestRate.Text = Convert.ToString(dt_check.Rows[0]["LOANTRANS_INTERESTRATE"]);
            rntbIR.Value = Convert.ToDouble(dt_check.Rows[0]["LOANTRANS_INTERESTRATE"]);
            rtxt_LoanNumber.Enabled = rtxt_installments.Enabled = rtxt_Amount.Enabled = false;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_Sanction_Command(object sender, CommandEventArgs e)
    {
        try
        {
            SMHR_LOANTRANS _obj_smhr_LoanTrans = new SMHR_LOANTRANS();
            Loaddropdowns();

            _obj_smhr_LoanTrans.LOANTRANS_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            lbl_loantrans_ID.Text = Convert.ToString(Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            _obj_smhr_LoanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_LoanTrans.OPERATION = operation.Validate;
            DataTable dt_check = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);
            if (dt_check.Rows.Count > 0)
            {
                if (Convert.ToString(dt_check.Rows[0]["LOANTRAN_STATUS"]) == "1")
                {
                    BLL.ShowMessage(this, "Loan already Sanctioned for this Employee.");
                    return;
                }
            }
            Rm_Loan_page.SelectedIndex = 1;
            _obj_smhr_LoanTrans.LOANTRANS_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            _obj_smhr_LoanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_LoanTrans.OPERATION = operation.Select;
            DataTable dt = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);
            if (dt.Rows[0]["LOANTRANS_ISSUEDATE"] != System.DBNull.Value)
            {
                lblissue.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_ISSUEDATE"]);
                rdtp_IssueDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_ISSUEDATE"]);
            }
            else
            {
                lblissue.Text = string.Empty;
                rdtp_IssueDate.SelectedDate = null;
            }
            // Getting Employee Name
            _obj_smhr_LoanTrans.BUSINESSUNIT_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            _obj_smhr_LoanTrans.LOANTRANS_EMP_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["LOANTRANS_EMP_ID"]));
            _obj_smhr_LoanTrans.OPERATION = operation.Empty;
            DataTable dtemp = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);
            rcmb_Employee.DataSource = dtemp;
            //lbl_Curr.Text = Convert.ToString(dtemp.Rows[0]["CURRENCY"]);
            rcmb_Employee.DataTextField = "EMPNAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            LoadPaymentType();
            rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_EMP_ID"]));
            ddl_PayMode.SelectedIndex = ddl_PayMode.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRAN_PAYMODE"]));
            // ddl_PayMode.SelectedIndex = ddl_PayMode.Items.FindItemIndexByValue(Convert.ToInt32(dt.Rows[0]["LOANTRAN_PAYMODE"]));   
            rcmb_Employee_SelectedIndexChanged(null, null);
            rtxt_Amount.Value = Convert.ToDouble(dt.Rows[0]["LOANTRANS_LOANAMOUNT"]);
            rcmb_loantype.SelectedIndex = rcmb_loantype.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_LOANTYPE_ID"]));
            rtxt_installments.Value = Convert.ToInt32(dt.Rows[0]["LOANTRANS_LOANINSTALL"]);
            rcmb_BusinessUnit.Enabled = false;
            rcmb_Employee.Enabled = false;
            btn_Save.Visible = true;
            btn_Save.Enabled = true;
            btn_Update.Visible = false;
            Session["datatable"] = null;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearControls()
    {
        try
        {
            rcmb_BusinessUnit.SelectedIndex = -1;
            rcmb_Employee.SelectedIndex = -1;
            rcmb_Employee.Items.Clear();
            rcmb_Employee.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_loantype.SelectedIndex = -1;
            rdtp_EffectiveDate.SelectedDate = null;
            rdtp_IssueDate.SelectedDate = null;
            rtxt_loanno.Text = string.Empty;
            rtxt_Amount.Text = string.Empty;
            rtxt_installments.Text = string.Empty;
            rtxt_InterestAmt.Text = string.Empty;
            rtxt_MonthlyEMI.Text = string.Empty;
            rtxt_purpose.Text = string.Empty;
            Rm_Loan_page.SelectedIndex = 0;
            EnabledFields(true);
            btn_Save.Visible = false;
            btn_Update.Enabled = true;
            btn_Sanction.Enabled = true;
            btn_Calculate.Enabled = true;
            lbl_loantrans_ID.Text = string.Empty;
            txt_ChequeNumber.Text = string.Empty;

            //To clear loan maxeligiblity controls
            lblLoanEligibleAmount.Text = string.Empty;
            hdnMinTenureMonths.Value = null;
            hdnMaxTenureMonths.Value = null;
            hdnMaxeligibleMonthsforEmp.Value = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void EnabledFields(bool b)
    {
        try
        {
            rcmb_BusinessUnit.Enabled = b;
            rcmb_Employee.Enabled = b; ;
            rcmb_loantype.Enabled = b; ;
            rdtp_EffectiveDate.Enabled = b;
            //rdtp_IssueDate.Enabled = b;
            //rtxt_loanno.Enabled = b;
            rtxt_Amount.Enabled = b;
            rtxt_installments.Enabled = b;
            //rtxt_InterestAmt.Enabled = b;
            //rtxt_MonthlyEMI.Enabled = b;
            rtxt_purpose.Enabled = b;
            //Rm_Loan_page.Enabled = b;
            ddl_PayMode.Enabled = b;
            txt_ChequeNumber.Enabled = b;
            rtxt_RloanNo.Enabled = b;
            rtxt_RLoanBalanceAmt.Enabled = b;
            rtxt_RInterestRate.Enabled = b;
            rtxt_Rinstallments.Enabled = b;
            rtxt_RevisedEMI.Enabled = b;
            //btn_Calculate.Enabled = b;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_process_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_LOANTRANSDTL _obj_smhr_loantransdtl = new SMHR_LOANTRANSDTL();
            SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
            SMHR_LOANRPT _obj_smhr_loanrpt = new SMHR_LOANRPT();

            _obj_smhr_loantransdtl.LOANTRANDTL_LOANNO = rtxt_RloanNo.Text;
            _obj_smhr_loantransdtl.LOANTRADTL_LOANTRAN_ID = Convert.ToInt32(rtxt_RloanTrasnID.Text);
            _obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
            _obj_smhr_loantransdtl.LOANTRANDTL_CURRENTLOANAMOUNT = Convert.ToDouble(rtxt_RLoanBalanceAmt.Text);
            _obj_smhr_loantransdtl.LOANTRANDTL_CURRENTBALANCEAMOUNT = Convert.ToDouble(rtxt_RPrincipalBalanceAmt.Text);
            _obj_smhr_loanrpt.LOANRPT_REPAYMENTAMOUNT = Convert.ToDouble(rtxt_Ramount.Text);
            //In case of Loan repayment by Cash Mode
            if (rtxt_ChequeNo.Text != string.Empty)
            {
                _obj_smhr_loanrpt.LOANRPT_CHEQUENO = Convert.ToString(rtxt_ChequeNo.Text);
            }
            else
                _obj_smhr_loanrpt.LOANRPT_CHEQUENO = "cash";
            _obj_smhr_loanrpt.LOANRPT_BRANCHNAME = Convert.ToString(rtxt_branchname.Text);
            _obj_smhr_loanrpt.LOANRPT_BANKNAME = Convert.ToString(rtxt_bankname.Text);
            _obj_smhr_loanrpt.LOANRPT_INSTALLMENTS = Convert.ToInt32(rtxt_Rinstallments.Text);
            _obj_smhr_loanrpt.LOANRPT_INTERESTRATE = Convert.ToInt32(rtxt_RInterestRate.Text);
            _obj_smhr_loanrpt.LOANRPT_DATEOFTRANS = Convert.ToDateTime(rdtp_DateofTRans.SelectedDate);
            _obj_smhr_loantrans.LOANTRAN_LASTMDFBY = 1;
            _obj_smhr_loantrans.LOANTRAN_LASTMDFDATE = System.DateTime.Now;

            DataTable dt_val = BLL.Loan_Repayment(_obj_smhr_loantrans, _obj_smhr_loantransdtl, _obj_smhr_loanrpt);
            rtxt_RevisedEMI.Text = Convert.ToString(dt_val.Rows[1]["LOANTRANDTL_EMIAMOUNT"]);
            StringBuilder strQry = new StringBuilder();
            _obj_smhr_loantransdtl.OPERATION = operation.Insert;
            if (dt_val.Rows.Count != 0)
            {

                for (int i = 0; i < dt_val.Rows.Count; i++)
                {
                    strQry.Append("EXEC USP_SMHR_LOANTRANDTL ");
                    _obj_smhr_loantransdtl.OPERATION = operation.Insert;
                    _obj_smhr_loantransdtl.LOANTRADTL_LOANTRAN_ID = Convert.ToInt32(rtxt_RloanTrasnID.Text);
                    _obj_smhr_loantransdtl.LOANTRANDTL_LOANNO = rtxt_RloanNo.Text;
                    _obj_smhr_loantransdtl.LOANTRANDTL_EMIPAYMENTDUEDATE = Convert.ToDateTime(dt_val.Rows[i]["DUE DATE"]);
                    _obj_smhr_loantransdtl.LOANTRANDTL_EMIAMOUNT = Convert.ToDouble(dt_val.Rows[i]["LOANTRANDTL_EMIAMOUNT"]);
                    _obj_smhr_loantransdtl.LOANTRANDTL_EMISTATUS = 0;
                    _obj_smhr_loantransdtl.LOANTRANDTL_CURRENTBALANCEAMOUNT = Convert.ToDouble(dt_val.Rows[i]["REMAINING PRINCIPAL"]);
                    _obj_smhr_loantransdtl.LOANTRANDTL_CURRENTLOANAMOUNT = Convert.ToDouble(dt_val.Rows[i]["REMAINING LAON"]);
                    _obj_smhr_loantransdtl.LOANTRANDTL_CURR_EMINO = Convert.ToInt32(dt_val.Rows[i]["NO.OF EMIS"]);
                    string str = "@Operation = 'Insert'" +
                                 ",@LOANTRADTL_LOANTRAN_ID = '" + _obj_smhr_loantransdtl.LOANTRADTL_LOANTRAN_ID + "'" +
                                 ",@LOANTRANDTL_LOANNO = '" + _obj_smhr_loantransdtl.LOANTRANDTL_LOANNO + "'" +
                                 ",@LOANTRANDTL_EMIPAYMENTDUEDATE = '" + _obj_smhr_loantransdtl.LOANTRANDTL_EMIPAYMENTDUEDATE + "'" +
                                 ",@LOANTRANDTL_EMIAMOUNT = '" + _obj_smhr_loantransdtl.LOANTRANDTL_EMIAMOUNT + "'" +
                                 ",@LOANTRANDTL_EMISTATUS = '" + _obj_smhr_loantransdtl.LOANTRANDTL_EMISTATUS + "'" +
                                 ",@LOANTRANDTL_CURRENTBALANCEAMOUNT = '" + _obj_smhr_loantransdtl.LOANTRANDTL_CURRENTBALANCEAMOUNT + "'" +
                                 ",@LOANTRANDTL_CURRENTLOANAMOUNt = '" + _obj_smhr_loantransdtl.LOANTRANDTL_CURRENTLOANAMOUNT + "'" +
                                 ",@LOANTRANDTL_CURR_EMINO = '" + _obj_smhr_loantransdtl.LOANTRANDTL_CURR_EMINO + "'";
                    strQry.Append(str);

                }

                bool rs = BLL.set_EmpLoanTranDtl(_obj_smhr_loantransdtl, strQry.ToString());
                if (rs == true)
                    BLL.ShowMessage(this, "Revised Loan Calculation Done Successfully");
                else
                    BLL.ShowMessage(this, "Error found");
                Rm_Loan_page.SelectedIndex = 0;
                LoadGrid();
                Rg_Loandet.DataBind();

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_PayType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_PayType.SelectedItem.Value == "1")
            {
                Cheqtr.Visible = false;
                branchtr.Visible = false;
                banktr.Visible = false;
            }
            else
            {
                Cheqtr.Visible = true;
                branchtr.Visible = true;
                banktr.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_1_Command(object sender, CommandEventArgs e)
    {
        try
        {

            //Rm_Loan_page.SelectedIndex = 1;
            //RPV_RPTReschedule.Selected = true;
            ////rd_LOANTRANS.SelectedIndex = 1;
            ////rd_LOANTRANS.Tabs[2].Enabled = false;
            ////rd_LOANTRANS.Tabs[1].Enabled = true;
            //SMHR_LOANTRANS _obj_smhr_LoanTrans = new SMHR_LOANTRANS();
            //Loaddropdowns();
            //_obj_smhr_LoanTrans.LOANTRANS_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));


            //DataTable dt = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);
            //ViewState["rescdata"] = dt;
            //EnabledFields(false);

            //// Getting Employee Name


            //_obj_smhr_LoanTrans.BUSINESSUNIT_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            //_obj_smhr_LoanTrans.LOANTRANS_EMP_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["LOANTRANS_EMP_ID"]));
            //_obj_smhr_LoanTrans.OPERATION = operation.Empty;
            //DataTable dtemp = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);
            //rcmb_Employee.DataSource = dtemp;
            ////lbl_Curr.Text = Convert.ToString(dtemp.Rows[0]["CURRENCY"]);
            //rcmb_Employee.DataTextField = "EMPNAME";
            //rcmb_Employee.DataValueField = "EMP_ID";
            //rcmb_Employee.DataBind();
            //rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            //rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            //rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_EMP_ID"]));

            //rtxt_loanno.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_LOANNO"]);
            //rtxt_Amount.Value = Convert.ToInt32(dt.Rows[0]["LOANTRANS_LOANAMOUNT"]);
            //rcmb_loantype.SelectedIndex = rcmb_loantype.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_LOANTYPE_ID"]));
            //rdtp_IssueDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_ISSUEDATE"]);
            //rtxt_installments.Value = Convert.ToInt32(dt.Rows[0]["LOANTRANS_LOANINSTALL"]);
            //rtxt_InterestAmt.Value = Convert.ToInt32(dt.Rows[0]["LOANTRANS_INTERESTRATE"]);
            //rtxt_purpose.Text = Convert.ToString(dt.Rows[0]["LOANTRAN_LOANPURPOSE"]);
            //rdtp_EffectiveDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_EFFDATE"]);

            //SMHR_LOANTRANSDTL _obj_smhr_loantrandtl = new SMHR_LOANTRANSDTL();
            //_obj_smhr_loantrandtl.LOANTRADTL_LOANTRAN_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            //DataTable dt_repay = BLL.get_EmpLoanTranDetail(_obj_smhr_loantrandtl);

            //rtxt_MonthlyEMI.Text = Convert.ToString(dt_repay.Rows[0]["LOANTRANDTL_EMIAMOUNT"]);
            //rtxt_RloanTrasnID.Text = (Convert.ToString(e.CommandArgument));
            //rtxt_RloanNo.Text = Convert.ToString(dt_repay.Rows[0]["LOANTRANDTL_LOANNO"]);
            //rtxt_RLoanBalanceAmt.Text = Convert.ToString(dt_repay.Rows[0]["REMAINING_LOAN"]);
            //rtxt_Rinstallments.Text = Convert.ToString(dt_repay.Rows[0]["EMIS"]);
            //rtxt_RInterestRate.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_INTERESTRATE"]);
            //rtxt_RPrincipalBalanceAmt.Text = Convert.ToString(dt_repay.Rows[0]["REMAINING_PRINCIPAL"]);

            //_obj_smhr_loantrandtl.OPERATION = operation.Check;
            //_obj_smhr_loantrandtl.LOANTRADTL_LOANTRAN_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            //DataTable dt_reschd = BLL.get_EmpLoanTranDetail(_obj_smhr_loantrandtl);
            //rg_loantrandetails.DataSource = dt_reschd;
            //rg_loantrandetails.DataBind();
            Rm_Loan_page.SelectedIndex = 1;
            RPV_RPTReschedule.Selected = true;
            //rd_LOANTRANS.SelectedIndex = 1;
            //rd_LOANTRANS.Tabs[2].Enabled = false;
            //rd_LOANTRANS.Tabs[1].Enabled = true;
            SMHR_LOANTRANS _obj_smhr_LoanTrans = new SMHR_LOANTRANS();
            Loaddropdowns();
            _obj_smhr_LoanTrans.LOANTRANS_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));

            _obj_smhr_LoanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);
            ViewState["rescdata"] = dt;
            EnabledFields(false);
            // Getting Employee Name


            _obj_smhr_LoanTrans.BUSINESSUNIT_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            _obj_smhr_LoanTrans.LOANTRANS_EMP_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["LOANTRANS_EMP_ID"]));
            _obj_smhr_LoanTrans.OPERATION = operation.Empty;
            DataTable dtemp = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);
            rcmb_Employee.DataSource = dtemp;
            //lbl_Curr.Text = Convert.ToString(dtemp.Rows[0]["CURRENCY"]);
            rcmb_Employee.DataTextField = "EMPNAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_EMP_ID"]));

            rtxt_loanno.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_LOANNO"]);
            rtxt_Amount.Value = Convert.ToDouble(dt.Rows[0]["LOANTRANS_LOANAMOUNT"]);
            rcmb_loantype.SelectedIndex = rcmb_loantype.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_LOANTYPE_ID"]));
            rdtp_IssueDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_ISSUEDATE"]);
            rtxt_installments.Value = Convert.ToInt32(dt.Rows[0]["LOANTRANS_LOANINSTALL"]);
            rtxt_InterestAmt.Value = Convert.ToInt32(dt.Rows[0]["LOANTRANS_INTERESTRATE"]);
            rtxt_purpose.Text = Convert.ToString(dt.Rows[0]["LOANTRAN_LOANPURPOSE"]);
            rdtp_EffectiveDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_EFFDATE"]);
            //rdtp_EffectiveDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["ResheduleEffDate"]);

            SMHR_LOANTRANSDTL _obj_smhr_loantrandtl = new SMHR_LOANTRANSDTL();
            _obj_smhr_loantrandtl.LOANTRADTL_LOANTRAN_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            DataTable dt_repay = BLL.get_EmpLoanTranDetail(_obj_smhr_loantrandtl);

            rtxt_MonthlyEMI.Text = Convert.ToString(dt_repay.Rows[0]["LOANTRANDTL_EMIAMOUNT"]);
            rtxt_RloanTrasnID.Text = (Convert.ToString(e.CommandArgument));
            rtxt_RloanNo.Text = Convert.ToString(dt_repay.Rows[0]["LOANTRANDTL_LOANNO"]);
            rtxt_RLoanBalanceAmt.Text = Convert.ToString(dt_repay.Rows[0]["REMAINING_LOAN"]);
            rtxt_Rinstallments.Text = Convert.ToString(dt_repay.Rows[0]["EMIS"]);
            rtxt_RInterestRate.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_INTERESTRATE"]);
            rtxt_RPrincipalBalanceAmt.Text = Convert.ToString(dt_repay.Rows[0]["REMAINING_PRINCIPAL"]);

            _obj_smhr_loantrandtl.OPERATION = operation.Check;
            _obj_smhr_loantrandtl.LOANTRADTL_LOANTRAN_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            DataTable dt_reschd = BLL.get_EmpLoanTranDetail(_obj_smhr_loantrandtl);
            rg_loantrandetails.DataSource = dt_reschd;
            rg_loantrandetails.DataBind();
            ViewState["rescdata"] = dt_reschd;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_RSchedProcess_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
            SMHR_LOANTRANSDTL _obj_smhr_loantransdtl = new SMHR_LOANTRANSDTL();
            string str = string.Empty;
            StringBuilder strloantrandtlid = new StringBuilder();
            _obj_smhr_loantrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_loantrans.LOANTRANS_ID = Convert.ToInt32(rg_loantrandetails.Items[0]["LOANTRADTL_LOANTRAN_ID"].Text);
            DataTable dt2 = BLL.get_EmpLoanTran(_obj_smhr_loantrans);
            _obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(dt2.Rows[0]["LOANTRANS_EMP_ID"]);
            _obj_smhr_loantransdtl.LOANTRANDTLS_CREATEDDATE = System.DateTime.Now;
            _obj_smhr_loantransdtl.LOANTRANDTLS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_loantransdtl.LOANTRANDTLS_MDFYBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_loantransdtl.LOANTRANDTLS_MDFYDATE =System.DateTime.Now;
            for (int i = 0; i < rg_loantrandetails.Items.Count; i++)
            {
                RadComboBox ddlDoc;
                ddlDoc = (RadComboBox)rg_loantrandetails.Items[i].FindControl("rcmb_Status");
                int x = Convert.ToInt32(ddlDoc.SelectedItem.Value);
                while (x == 2)
                {
                    //_obj_smhr_loantransdtl.LOANTRANDTL_ID = Convert.ToInt32(rg_loantrandetails.Items[i]["LOANTRANDTL_ID"].Text);
                    if (Convert.ToString(strloantrandtlid) != string.Empty)
                    {
                        str = ",''" + Convert.ToInt32(rg_loantrandetails.Items[i]["LOANTRANDTL_ID"].Text) + "''";
                        strloantrandtlid.Append(str);
                    }
                    else
                    {
                        str = "''" + Convert.ToInt32(rg_loantrandetails.Items[i]["LOANTRANDTL_ID"].Text) + "''";
                        strloantrandtlid.Append(str);
                    }
                    _obj_smhr_loantransdtl.LOANTRANDTL_LOANNO = Convert.ToString(strloantrandtlid);
                    break;
                }

            }
            if (str != string.Empty)
            {
                bool rs = BLL.ProcessReshcdule(_obj_smhr_loantransdtl, _obj_smhr_loantrans);
                if (rs == true)
                {
                    BLL.ShowMessage(this, "Information Saved Successfully");
                    rg_loantrandetails.DataBind();
                    Rm_Loan_page.SelectedIndex = 0;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Nothing to Process. No Selection Happened");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_RSCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_Loan_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rg_loantrandetails_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            DataTable dt_needds = (DataTable)ViewState["rescdata"];
            rg_loantrandetails.DataSource = dt_needds;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadPaymentType()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_businessunit.OPERATION = operation.Empty;
            _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            DataTable dt = BLL.get_BusinessUnit(_obj_smhr_businessunit);
            ddl_PayMode.DataSource = dt;
            ddl_PayMode.DataTextField = "HR_MASTER_CODE";
            ddl_PayMode.DataValueField = "HR_MASTER_ID";
            ddl_PayMode.DataBind();
            ddl_PayMode.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ddl_PayMode_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_PayMode.SelectedItem.Text.ToUpper() == "CHEQUE")
            {
                cheque.Visible = true;
            }
            else
            {
                cheque.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadEmployee()
    {
        try
        {
            SMHR_LOANREQUEST _obj_Smhr_BusinessUnit = new SMHR_LOANREQUEST();
            _obj_Smhr_BusinessUnit.OPERATION = operation.Validate;
            _obj_Smhr_BusinessUnit.LOANREQUEST_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            rcmb_Employee.Items.Clear();
            rcmb_Employee.DataSource = BLL.get_Employee(_obj_Smhr_BusinessUnit);
            rcmb_Employee.DataTextField = "employeename";
            rcmb_Employee.DataValueField = "emp_id";
            rcmb_Employee.DataBind();
            rcmb_Employee.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadDetails()
    {
        try
        {
            if (Session["USER_ID"] != null)
            {
                Loaddropdowns();
                //LoadEmployee();
                DataTable dt = new DataTable();
                SMHR_LOANREQUEST obj = new SMHR_LOANREQUEST();
                obj.OPERATION = operation.Approve;
                obj.lOANREQUEST_EMPLOYEEID = Convert.ToInt32(Session["EMP_ID"]);
                dt = BLL.get_Employeedetails(obj);
                if (dt.Rows.Count > 0)
                {

                    rtxt_Amount.Value = Convert.ToDouble(dt.Rows[0]["Amount"]);
                    rtxt_installments.Value = Convert.ToInt32(dt.Rows[0]["noofinstallments"]);
                    rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByText(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_CODE"]));
                    //rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByText(Convert.ToString(dt.Rows[0]["EMP_NAME"]));
                    rcmb_Employee.DataSource = dt;
                    rcmb_Employee.DataTextField = "EMP_NAME";
                    rcmb_Employee.DataBind();
                    rcmb_loantype.SelectedIndex = rcmb_loantype.Items.FindItemIndexByText(Convert.ToString(dt.Rows[0]["PAYITEM_PAYITEMNAME"]));
                }
                //SMHR_LOANREQUEST _obj_Smhr_BusinessUnit = new SMHR_LOANREQUEST();
                //_obj_Smhr_BusinessUnit.OPERATION = operation.Validate;
                //_obj_Smhr_BusinessUnit.LOANREQUEST_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                //rcmb_Employee.Items.Clear();
                //rcmb_Employee.DataSource = BLL.get_Employee(_obj_Smhr_BusinessUnit);
                //rcmb_Employee.DataTextField = "employeename";
                //rcmb_Employee.DataValueField = "emp_id";
                //rcmb_Employee.DataBind();
                Rm_Loan_page.SelectedIndex = 1;
                //btn_Update.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Sanction_Click(object sender, EventArgs e)
    {
        try
        {

            if (lblissue.Text != string.Empty)
            {
                if (rdtp_IssueDate.SelectedDate < Convert.ToDateTime(lblissue.Text))
                {
                    BLL.ShowMessage(this, "Loan Issue Date cannot be ahead of Applied Date.");
                    return;
                }
            }
            if (Convert.ToInt32(ddl_PayMode.SelectedIndex) == 0)
            {
                BLL.ShowMessage(this, "Please Select PayItem Mode");
                return;

            }
            if (Convert.ToInt32(rtxt_installments.Value) == 0)
            {
                BLL.ShowMessage(this, "No. of Instalments should be greater than 0");
                return;
            }
            if (string.IsNullOrEmpty(rtxt_MonthlyEMI.Text))
            {
                BLL.ShowMessage(this, "Please click on Calculate");
                return;
            }

            /* To calculate loan max eligiblity amt and tenure period */
            //rtxt_EMI.Text = string.Empty;
            //Session.Remove("datatable");
            //lnkViewEMI.Visible = false;
            if (!string.IsNullOrEmpty(lblLoanEligibleAmount.Text))
            {
                if (Convert.ToDecimal(lblLoanEligibleAmount.Text) < Convert.ToDecimal(rtxt_Amount.Value))
                {
                    BLL.ShowMessage(this, "Maximum eligible amount for the loan is " + lblLoanEligibleAmount.Text);
                    return;
                }
            }

            if (hdnMinTenureMonths.Value != null && Convert.ToInt32(hdnMinTenureMonths.Value) > (Convert.ToInt32(rtxt_installments.Text) + Convert.ToInt32(hdnClosedEMICount.Value)))
            {
                BLL.ShowMessage(this, "Minimum " + hdnMinTenureMonths.Value + " months required for this loan");
                return;
            }
            if (hdnMaxTenureMonths.Value != null && ((Convert.ToInt32(hdnMaxTenureMonths.Value)) < (Convert.ToInt32(rtxt_installments.Text) + Convert.ToInt32(hdnClosedEMICount.Value))))
            {
                BLL.ShowMessage(this, "Maximum " + hdnMaxTenureMonths.Value + " months required for this loan");
                return;
            }
            /* To calculate loan max eligiblity amt and tenure period */


            SMHR_VOLUNTARY_DEDUCTION_ARREARS _obj_smhr_voluntary_deduction_arrears = new SMHR_VOLUNTARY_DEDUCTION_ARREARS();
            _obj_smhr_voluntary_deduction_arrears.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_BU_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            _obj_smhr_voluntary_deduction_arrears.ENDDATE = Convert.ToDateTime(rdtp_EffectiveDate.SelectedDate);

            DataTable chkEmpSalDtlsData = BLL.CheckEmpSalDtlsData(_obj_smhr_voluntary_deduction_arrears);

            if (chkEmpSalDtlsData.Rows.Count > 0)
            {
                BLL.ShowMessage(this, "Payroll is already generated for the Effective Date");
                return;
            }
            if (string.IsNullOrEmpty(rtxt_loanno.Text.Trim()))
            {
                getLoanNo();
            }
            SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
            _obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
            _obj_smhr_loantrans.LOANTRANS_LOANNO = Convert.ToString(rtxt_loanno.Text);
            _obj_smhr_loantrans.LOANTRANS_LOANTYPE_ID = Convert.ToInt32(rcmb_loantype.SelectedItem.Value);
            _obj_smhr_loantrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            if (lbl_LoanDetEmpDOJ.Text != string.Empty)
            {

                if (rdtp_IssueDate.SelectedDate < Convert.ToDateTime(lbl_LoanDetEmpDOJ.Text))
                {
                    BLL.ShowMessage(this, "Loan Issue Date cannot be ahead of Employee Joining Date");
                    return;
                }
            }
            else if (rdtp_IssueDate.SelectedDate > System.DateTime.Now)
            {
                BLL.ShowMessage(this, "Loan Issue Date cannot be ahead of Todays Date");
                return;
            }
            else
            {
                _obj_smhr_loantrans.LOANTRANS_ISSUEDATE = Convert.ToDateTime(rdtp_IssueDate.SelectedDate);
            }
            _obj_smhr_loantrans.LOANTRANS_LOANAMOUNT = Convert.ToDouble(rtxt_Amount.Value);
            _obj_smhr_loantrans.LOANTRANS_LOANINSTALL = Convert.ToInt32(rtxt_installments.Value);
            _obj_smhr_loantrans.LOANTRANS_INTERESTAMT = Convert.ToDouble(rtxt_InterestAmt.Value);
            _obj_smhr_loantrans.LOANTRAN_LOANPURPOSE = BLL.ReplaceQuote(Convert.ToString(rtxt_purpose.Text));
            _obj_smhr_loantrans.LOANTRANS_EFFDATE = Convert.ToDateTime(rdtp_EffectiveDate.SelectedDate);
            //   LoadPaymentType();
            _obj_smhr_loantrans.LOANTRAN_PAYMODE = Convert.ToInt32(ddl_PayMode.SelectedValue);
            if (txt_ChequeNumber.Value != null)
                _obj_smhr_loantrans.LOANTRAN_CHEQUENUM = Convert.ToDouble(txt_ChequeNumber.Value);
            else
                _obj_smhr_loantrans.LOANTRAN_CHEQUENUM = 0;
            _obj_smhr_loantrans.LOANTRAN_CREATEDDATE = System.DateTime.Now;
            _obj_smhr_loantrans.LOANTRAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_loantrans.LOANTRAN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_loantrans.LOANTRAN_LASTMDFDATE = System.DateTime.Now;
            //  _obj_smhr_loantrans.CONFIRM = "N";
            _obj_smhr_loantrans.CONFIRM = "Y";
            _obj_smhr_loantrans.OPERATION = operation.Insert;
            _obj_smhr_loantrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_loantrans.LOANTRAN_TYPE = false;
            _obj_smhr_loantrans.LOANTRAN_STATUS = 1;
            _obj_smhr_loantrans.LOANTRANS_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
            _obj_smhr_loantrans.LOANNAME = Convert.ToString(rcmb_loantype.SelectedItem.Text).Replace("'", "''");
            _obj_smhr_loantrans.LOANTRANS_INTERESTRATE = Convert.ToDouble(rntbIR.Value);
            bool result;
            SMHR_LOANTRANS _obj_smhr_LoanTrans = new SMHR_LOANTRANS();
            _obj_smhr_LoanTrans.LOANTRANS_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
            _obj_smhr_LoanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            result = BLL.set_EmpLoanTrans(_obj_smhr_loantrans);

            if (result == true)
            {
                BLL.ShowMessage(this, "Loan Sanctioned Successfully");
            }
            else
                BLL.ShowMessage(this, "Loan Transaction failed");

            ClearControls();
            Rm_Loan_page.SelectedIndex = 0;
            LoadGrid();
            Rg_Loandet.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnReschedule_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(rtxt_InstallmentNo.Value) == 0)
            {
                BLL.ShowMessage(this, "No. of Instalments should be greater than 0");
                return;
            }
            if (string.IsNullOrEmpty(rtxt_EMI.Text))
            {
                BLL.ShowMessage(this, "Please click on Calculate");
                return;
            }
            SMHR_VOLUNTARY_DEDUCTION_ARREARS _obj_smhr_voluntary_deduction_arrears = new SMHR_VOLUNTARY_DEDUCTION_ARREARS();
            _obj_smhr_voluntary_deduction_arrears.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_EMP_ID = Convert.ToInt32(rcmb_RescheduleEmployee.SelectedItem.Value);
            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_BU_ID = Convert.ToInt32(rcmb_RescheduleBU.SelectedValue);
            _obj_smhr_voluntary_deduction_arrears.ENDDATE = Convert.ToDateTime(rdp_EffectiveDate.SelectedDate);

            DataTable chkEmpSalDtlsData = BLL.CheckEmpSalDtlsData(_obj_smhr_voluntary_deduction_arrears);

            if (chkEmpSalDtlsData.Rows.Count > 0)
            {
                BLL.ShowMessage(this, "Payroll is already generated for the Effective Date");
                return;
            }


            SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
            _obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(rcmb_RescheduleEmployee.SelectedValue);
            _obj_smhr_loantrans.LOANTRANS_LOANNO = Convert.ToString(rtxt_LoanNumber.Text);
            _obj_smhr_loantrans.LOANTRANS_LOANTYPE_ID = Convert.ToInt32(rcmb_RescheduleLoanType.SelectedItem.Value);
            _obj_smhr_loantrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            if (rdp_IssueDate.SelectedDate > System.DateTime.Now)
            {
                BLL.ShowMessage(this, "Loan Issue Date cannot be ahead of Todays Date");
                return;
            }
            else
            {
                _obj_smhr_loantrans.LOANTRANS_ISSUEDATE = Convert.ToDateTime(rdp_IssueDate.SelectedDate);
            }

            //_obj_smhr_loantrans.LOANTRANS_LOANAMOUNT = Convert.ToDouble(rtxt_LoanAmount.Value);
            _obj_smhr_loantrans.LOANTRANS_LOANAMOUNT = Convert.ToDouble(rtxt_LoanBalance.Value);    //To hold loan balance
            _obj_smhr_loantrans.LOANTRANS_LOANINSTALL = Convert.ToInt32(rtxt_InstallmentNo.Value);
            _obj_smhr_loantrans.LOANTRANS_INTERESTAMT = Convert.ToDouble(rtxt_InterestRate.Value);
            //_obj_smhr_loantrans.LOANTRAN_LOANPURPOSE = BLL.ReplaceQuote(Convert.ToString(rtxt_purpose.Text));
            _obj_smhr_loantrans.LOANTRANS_EFFDATE = Convert.ToDateTime(rdp_EffectiveDate.SelectedDate);
            //   LoadPaymentType();
            //_obj_smhr_loantrans.LOANTRAN_PAYMODE = Convert.ToInt32(ddl_PayMode.SelectedValue);
            //if (txt_ChequeNumber.Value != null)
            //    _obj_smhr_loantrans.LOANTRAN_CHEQUENUM = Convert.ToDouble(txt_ChequeNumber.Value);
            //else
            //    _obj_smhr_loantrans.LOANTRAN_CHEQUENUM = 0;
            _obj_smhr_loantrans.LOANTRAN_CREATEDDATE = System.DateTime.Now;
            _obj_smhr_loantrans.LOANTRAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_loantrans.LOANTRAN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_loantrans.LOANTRAN_LASTMDFDATE = System.DateTime.Now;
            //  _obj_smhr_loantrans.CONFIRM = "N";
            //_obj_smhr_loantrans.CONFIRM = "Y";
            _obj_smhr_loantrans.CONFIRM = "R";
            _obj_smhr_loantrans.OPERATION = operation.Insert;
            _obj_smhr_loantrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_loantrans.LOANTRAN_TYPE = false;
            _obj_smhr_loantrans.LOANTRAN_STATUS = 1;
            _obj_smhr_loantrans.LOANTRANS_ID = Convert.ToInt32(lblLoanTransID.Text);
            _obj_smhr_loantrans.LOANNAME = rcmb_RescheduleLoanType.SelectedItem.Text;
            bool result;
            //SMHR_LOANTRANS _obj_smhr_LoanTrans = new SMHR_LOANTRANS();
            //_obj_smhr_LoanTrans.LOANTRANS_ID = Convert.ToInt32(lblLoanTransID.Text);
            //_obj_smhr_LoanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            result = BLL.set_EmpLoanTrans(_obj_smhr_loantrans);

            if (result == true)
            {
                BLL.ShowMessage(this, "Loan Rescheduled Successfully");
            }
            else
            {
                BLL.ShowMessage(this, "Loan Transaction failed");
            }

            ClearRescheduleControls();
            Rm_Loan_page.SelectedIndex = 0;
            LoadGrid();
            Rg_Loandet.DataBind();
            Session.Remove("datatable");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearRescheduleControls()
    {
        try
        {
            //To clear rescheduling page values
            Rm_Loan_page.SelectedIndex = 0;
            rcmb_RescheduleBU.Items.Clear();
            rcmb_RescheduleBU.Text = string.Empty;
            rcmb_RescheduleEmployee.Items.Clear();
            rcmb_RescheduleEmployee.Text = string.Empty;
            rtxt_LoanNumber.Text = string.Empty;
            rdp_IssueDate.Clear();
            rtxt_LoanAmount.Text = string.Empty;
            rtxt_InstallmentNo.Text = string.Empty;
            rtxt_InterestRate.Text = string.Empty;
            rtxt_EMI.Text = string.Empty;
            rdp_EffectiveDate.Clear();
            hdn_IsLoanSanctioned.Value = null;
            Session.Remove("datatable");

            //To clear hiddenfield values
            lblLoanEligibleAmount.Text = string.Empty;
            hdnMinTenureMonths.Value = null;
            hdnMaxTenureMonths.Value = null;
            hdnMaxeligibleMonthsforEmp.Value = null;
            hdnClosedEMICount.Value = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnCancelRescehdule_Click(object sender, EventArgs e)
    {
        try
        {
            ClearRescheduleControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnRescheduleCal_Click(object sender, EventArgs e)
    {
        try
        {
            //// getLoanNo();
            //if (Convert.ToInt32(ddl_PayMode.SelectedIndex) == 0)
            //{
            //    BLL.ShowMessage(this, "Please Select PayItem Mode");
            //    return;

            //}
            if (Convert.ToInt32(rtxt_InstallmentNo.Value) == 0)
            {
                BLL.ShowMessage(this, "No. of Instalments should be greater than 0");
                return;
            }

            SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
            _obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(rcmb_RescheduleEmployee.SelectedValue);
            _obj_smhr_loantrans.LOANTRANS_LOANNO = Convert.ToString(rtxt_LoanNumber.Text);
            _obj_smhr_loantrans.LOANTRANS_LOANTYPE_ID = Convert.ToInt32(rcmb_RescheduleLoanType.SelectedValue);
            _obj_smhr_loantrans.LOANTRANS_ISSUEDATE = Convert.ToDateTime(rdp_IssueDate.SelectedDate);
            //_obj_smhr_loantrans.LOANTRANS_LOANAMOUNT = Convert.ToDouble(rtxt_LoanAmount.Value);
            _obj_smhr_loantrans.LOANTRANS_LOANAMOUNT = Convert.ToDouble(rtxt_LoanBalance.Value);    //To hold current loan balance
            _obj_smhr_loantrans.LOANTRANS_LOANINSTALL = Convert.ToInt32(rtxt_InstallmentNo.Value);
            _obj_smhr_loantrans.LOANTRANS_INTERESTAMT = Convert.ToDouble(rtxt_InterestRate.Value);
            _obj_smhr_loantrans.LOANTRAN_LOANPURPOSE = BLL.ReplaceQuote(Convert.ToString(rtxt_ReschedulePurpose.Text));
            _obj_smhr_loantrans.LOANTRANS_EFFDATE = Convert.ToDateTime(rdp_EffectiveDate.SelectedDate);
            _obj_smhr_loantrans.LOANTRAN_CREATEDDATE = System.DateTime.Now;
            _obj_smhr_loantrans.LOANTRAN_CHEQUENUM = Convert.ToDouble(rtxt_ChequeNumber.Value);

            _obj_smhr_loantrans.LOANTRAN_TYPE = false;
            _obj_smhr_loantrans.LOANTRAN_PAYMODE = Convert.ToInt32(rcmb_PaymentMode.SelectedValue);
            _obj_smhr_loantrans.LOANTRAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_loantrans.LOANTRAN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_loantrans.LOANTRAN_LASTMDFDATE = System.DateTime.Now;
            //_obj_smhr_loantrans.CONFIRM = "n";
            _obj_smhr_loantrans.CONFIRM = "C";
            //if (Convert.ToInt32(ViewState["LoanStatus"]) == 0)
            //{
            //    _obj_smhr_loantrans.LOANTRAN_STATUS = 0;
            //}
            //else if (Convert.ToInt32(ViewState["LoanStatus"]) == 1)
            //{
            //    _obj_smhr_loantrans.LOANTRAN_STATUS = 1;
            //}
            _obj_smhr_loantrans.LOANTRAN_STATUS = 1;

            DataTable dtvalues = new DataTable();
            _obj_smhr_loantrans.LOANTRANS_ID = Convert.ToInt32(lblLoanTransID.Text);
            //if (string.Compare(rcmb_loantype.SelectedItem.Text, "Deposits-Kenya", true) == 0
            //    || string.Compare(rcmb_loantype.SelectedItem.Text, "Bucoso-Accrued Interest", true) == 0
            //    || string.Compare(rcmb_loantype.SelectedItem.Text, "Bucoso-Sinking Fund", true) == 0
            //    || string.Compare(rcmb_loantype.SelectedItem.Text, "Bucoso-Entrance Fee", true) == 0)
            //{
            //    SMHR_LOANREQUEST _obj_Smhr_Loanrequest = new SMHR_LOANREQUEST();
            //    _obj_Smhr_Loanrequest.OPERATION = operation.USERLOANTRANEMI;
            //    _obj_Smhr_Loanrequest.SMHR_LOANREQUEST_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
            //    dtvalues = BLL.get_LoanRequest(_obj_Smhr_Loanrequest);
            //}
            if (!string.IsNullOrEmpty(hdn_LoanProcessType.Value) && string.Compare(hdn_LoanProcessType.Value, "1", true) == 0)
            {
                //SMHR_LOANREQUEST _obj_Smhr_Loanrequest = new SMHR_LOANREQUEST();
                //_obj_Smhr_Loanrequest.OPERATION = operation.USERLOANTRANEMI;
                //_obj_Smhr_Loanrequest.SMHR_LOANREQUEST_ID = Convert.ToInt32(lblLoanTransID.Text);
                //dtvalues = BLL.get_LoanRequest(_obj_Smhr_Loanrequest);

                BLL.ShowMessage(this, "Cannot Reschedule loan \"" + rcmb_RescheduleLoanType.SelectedItem.Text + "\"");
                return;
            }
            else
            {
                dtvalues = BLL.Calculate_EMI(_obj_smhr_loantrans);
            }
            rtxt_EMI.Text = Convert.ToString(dtvalues.Rows[0]["EMI AMOUNT"]);
            lnkViewEMI.Visible = true;
            Session["datatable"] = dtvalues;
            //lnkbtn_EMIDATA.OnClientClick ="  openRadWin('frm_loanemidata.aspx?tranid=" + Convert.ToInt32(dtvalues.Rows[0]["LOANTRADTL_LOANTRAN_ID"]) + "'); return false;";
            lnkViewEMI.OnClientClick = "  openRadWin('frm_loanemidata.aspx'); return false;";

            //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            //{
            //    btnReschedule.Visible = false;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Reschedule_Command(object sender, CommandEventArgs e)
    {
        try
        {
            lnkbtn_EMIDATA.Visible = false;
            Rm_Loan_page.SelectedIndex = 1;
            RPV_Reschedule.Selected = true;

            SMHR_LOANTRANS _obj_smhr_LoanTrans = new SMHR_LOANTRANS();
            _obj_smhr_LoanTrans.LOANTRANS_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            lblLoanTransID.Text = Convert.ToString(Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            _obj_smhr_LoanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_LoanTrans.OPERATION = operation.Select;
            DataTable dt = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);

            /* To bind values to controls */
            rcmb_RescheduleBU.DataSource = dt;
            rcmb_RescheduleBU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_RescheduleBU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_RescheduleBU.DataBind();

            rcmb_RescheduleEmployee.DataSource = dt;
            rcmb_RescheduleEmployee.DataTextField = "EMPNAME";
            rcmb_RescheduleEmployee.DataValueField = "LOANTRANS_EMP_ID";
            rcmb_RescheduleEmployee.DataBind();

            rtxt_LoanNumber.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_LOANNO"]);
            hdn_LoanProcessType.Value = Convert.ToString(dt.Rows[0]["PAYITEM_LOAN_PROCESSTYPE"]);

            //To populate PayMode
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_businessunit.OPERATION = operation.Empty;
            _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_RescheduleBU.SelectedValue);
            DataTable dtPayMode = BLL.get_BusinessUnit(_obj_smhr_businessunit);
            rcmb_PaymentMode.DataSource = dtPayMode;
            rcmb_PaymentMode.DataTextField = "HR_MASTER_CODE";
            rcmb_PaymentMode.DataValueField = "HR_MASTER_ID";
            rcmb_PaymentMode.DataBind();
            rcmb_PaymentMode.Items.Insert(0, new RadComboBoxItem("Select"));

            //To select payment mode
            rcmb_PaymentMode.SelectedIndex = rcmb_PaymentMode.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRAN_PAYMODE"]));
            if (rcmb_PaymentMode.SelectedItem.Text.ToUpper() == "CHEQUE")
            {
                trChequeNo.Visible = true;
                rtxt_ChequeNumber.Value = Convert.ToDouble(dt.Rows[0]["LOANTRAN_CHEQUENUM"]);
            }
            else
            {
                trChequeNo.Visible = false;
                rtxt_ChequeNumber.Value = 0;
            }
            //hdn_IsLoanSanctioned.Value = Convert.ToString(dt.Rows[0]["IsLoanSanctioned"]);

            //To populate loan type
            //Load PayItem Type
            rcmb_loantype.Items.Clear();
            SMHR_PAYITEMS _obj_Payitems = new SMHR_PAYITEMS();
            _obj_Payitems.OPERATION = operation.Check1;
            _obj_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PAYITEM_LOAN_PROCESSTYPE"])))
            {
                _obj_Payitems.PAYITEM_LOAN_PROCESSTYPE = Convert.ToInt32(hdn_LoanProcessType.Value);
            }
            //if (!string.IsNullOrEmpty(hdn_LoanProcessType.Value))
            //{
            //    _obj_Payitems.PAYITEM_LOAN_PROCESSTYPE = Convert.ToInt32(hdn_LoanProcessType.Value);
            //}
            rcmb_RescheduleLoanType.DataSource = BLL.get_PayItems(_obj_Payitems);
            rcmb_RescheduleLoanType.DataTextField = "PAYITEM_PAYITEMNAME";
            rcmb_RescheduleLoanType.DataValueField = "PAYITEM_ID";
            rcmb_RescheduleLoanType.DataBind();
            rcmb_RescheduleLoanType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            rcmb_RescheduleLoanType.SelectedIndex = rcmb_RescheduleLoanType.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_LOANTYPE_ID"]));
            rdp_IssueDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_ISSUEDATE"]);
            rtxt_LoanAmount.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_LOANAMOUNT"]);
            rtxt_LoanBalance.Text = Convert.ToString(dt.Rows[0]["LOANTRANDTL_CURRENTBALANCEAMOUNT"]);
            rtxt_InterestRate.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_INTERESTRATE"]);
            rtxt_EMI.Text = string.Empty;
            //rdp_EffectiveDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_EFFDATE"]);      //rdtp_EffectiveDate.SelectedDate;
            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["RescheduleEffDate"])))
            {
                rdp_EffectiveDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["RescheduleEffDate"]);      //rdtp_EffectiveDate.SelectedDate;
            }
            rtxt_ReschedulePurpose.Text = Convert.ToString(dt.Rows[0]["LOANTRAN_LOANPURPOSE"]);
            hdnClosedEMICount.Value = Convert.ToString(dt.Rows[0]["ClosedEmiCount"]);   //To hold Closed EMI's count
            //return;
            /* To bind values to controls */

            /* To find loan max eligibility */
            if (string.Compare(hdn_LoanProcessType.Value, "0", true) == 0)
            {
                #region Reducing Balance
                if (rcmb_RescheduleLoanType.SelectedIndex > 0)
                {
                    if (rcmb_RescheduleEmployee.SelectedItem == null || string.Compare(rcmb_RescheduleEmployee.SelectedItem.Text.ToLower(), "select", true) == 0)
                    {
                        BLL.ShowMessage(this, "Please select Employee");
                        rcmb_RescheduleLoanType.ClearSelection();
                        return;
                    }
                    else
                    {
                        SMHR_LOANSETUP oSMHR_LOANSETUP = new SMHR_LOANSETUP();
                        oSMHR_LOANSETUP.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        oSMHR_LOANSETUP.LOGIN_ID = Convert.ToInt32(rcmb_RescheduleEmployee.SelectedValue);
                        oSMHR_LOANSETUP.LOANSETUP_LOANTYPE_ID = Convert.ToInt32(rcmb_RescheduleLoanType.SelectedValue);
                        if (string.Compare(rcmb_RescheduleLoanType.SelectedItem.Text, "Salary Advance", true) == 0)//|| string.Compare(rcmb_LoanType.SelectedItem.Text, "Salary in Advance", true) != 0)
                        {
                            #region Salary Advance
                            //trBrowse.Visible = false;
                            oSMHR_LOANSETUP.OPERATION = operation.Select;
                            DataTable dtLoanSetup = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                            if (dtLoanSetup.Rows.Count > 0)
                            {
                                //trRateOfInterest.Visible = true;
                                //trLoanEligibleAmount.Visible = true;
                                lblLoanEligibleAmount.Text = Convert.ToInt32(dtLoanSetup.Rows[0]["EMP_BASIC"]).ToString();
                                //lblRateofInterest.Text = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_LOANINTEREST"]);
                                hdnMinTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                                hdnMaxTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);
                                hdnMaxeligibleMonthsforEmp.Value = Convert.ToString(dtLoanSetup.Rows[0]["MAXELIGIBLEMONTHSFOREMPLOYEE"]);
                            }
                            #endregion
                        }
                        else if (string.Compare(rcmb_RescheduleLoanType.SelectedItem.Text, "Salary in Advance", true) == 0)
                        {
                            #region Salary In Advance
                            //trBrowse.Visible = false;
                            oSMHR_LOANSETUP.OPERATION = operation.Validate;
                            oSMHR_LOANSETUP.Amount = 0;
                            oSMHR_LOANSETUP.EffectiveDate = DateTime.Now;
                            DataTable dtLoan = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                            oSMHR_LOANSETUP.OPERATION = operation.Select;
                            DataTable dtLoanSetup = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                            if (dtLoan.Rows.Count > 0 && dtLoanSetup.Rows.Count > 0)
                            {
                                if (Convert.ToBoolean(dtLoan.Rows[0]["FINAL"]))
                                {
                                    lblLoanEligibleAmount.Text = Convert.ToInt32(dtLoan.Rows[0]["AMOUNT"]).ToString();
                                    hdnMinTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                                    hdnMaxTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);
                                    hdnMaxeligibleMonthsforEmp.Value = Convert.ToString(dtLoanSetup.Rows[0]["MAXELIGIBLEMONTHSFOREMPLOYEE"]);
                                }
                            }
                            #endregion
                        }
                        #region Car Life Loans
                        #endregion
                        else
                        {
                            #region All Loans
                            oSMHR_LOANSETUP.OPERATION = operation.Check;
                            DataTable dtLoan = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                            if (dtLoan.Rows.Count > 0)
                            {
                                lblLoanEligibleAmount.Text = Convert.ToString(Math.Round(Convert.ToDecimal(dtLoan.Rows[0]["LOANELIGIBLEAMOUNT_MAXAMOUNT"]), 2));
                                hdnMinTenureMonths.Value = Convert.ToString(dtLoan.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                                hdnMaxTenureMonths.Value = Convert.ToString(dtLoan.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);
                                hdnMaxeligibleMonthsforEmp.Value = Convert.ToString(dtLoan.Rows[0]["MAXELIGIBLEMONTHSFOREMPLOYEE"]);
                            }
                            #endregion
                        }
                    }
                }
                #endregion
            }
            else
            {
                SMHR_LOANSETUP oSMHR_LOANSETUP = new SMHR_LOANSETUP();
                oSMHR_LOANSETUP.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                oSMHR_LOANSETUP.LOGIN_ID = Convert.ToInt32(rcmb_RescheduleEmployee.SelectedValue);
                oSMHR_LOANSETUP.LOANSETUP_LOANTYPE_ID = Convert.ToInt32(rcmb_RescheduleLoanType.SelectedValue);

                #region Salary Advance
                //trBrowse.Visible = false;
                oSMHR_LOANSETUP.OPERATION = operation.Select;
                DataTable dtLoanSetup = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                if (dtLoanSetup.Rows.Count > 0)
                {
                    //trRateOfInterest.Visible = true;
                    //trLoanEligibleAmount.Visible = true;
                    //lblLoanEligibleAmount.Text = Convert.ToInt32(dtLoanSetup.Rows[0]["EMP_BASIC"]).ToString();
                    //lblRateofInterest.Text = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_LOANINTEREST"]);
                    hdnMinTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                    hdnMaxTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);
                    //hdnMaxeligibleMonthsforEmp.Value = Convert.ToString(dtLoanSetup.Rows[0]["MAXELIGIBLEMONTHSFOREMPLOYEE"]);
                }
                #endregion
            }
            /* To find loan max eligibility */
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void lnkViewEMI_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (!string.IsNullOrEmpty(hdn_LoanProcessType.Value) && string.Compare(hdn_LoanProcessType.Value, "1", true) == 0)
    //        {
    //            SMHR_LOANREQUEST _obj_Smhr_Loanrequest = new SMHR_LOANREQUEST();
    //            _obj_Smhr_Loanrequest.OPERATION = operation.USERLOANTRANEMI;
    //            _obj_Smhr_Loanrequest.SMHR_LOANREQUEST_ID = Convert.ToInt32(lblLoanTransID.Text);

    //            //dtvalues = BLL.get_LoanRequest(_obj_Smhr_Loanrequest);
    //        }
    //        else if (!string.IsNullOrEmpty(hdn_IsLoanSanctioned.Value) && string.Compare(hdn_IsLoanSanctioned.Value, "True", true) == 0) //if loan is already sanctioned
    //        {
    //            SMHR_LOANTRANSDTL objLoanTransDtl = new SMHR_LOANTRANSDTL();
    //            objLoanTransDtl.OPERATION = operation.Select_New;
    //            objLoanTransDtl.LOANTRADTL_LOANTRAN_ID = Convert.ToInt32(lblLoanTransID.Text);
    //            dtvalues = BLL.get_LoanDetails(objLoanTransDtl);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    protected void lnk_PreClosure_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //lnkbtn_EMIDATA.Visible = false;
            Rm_Loan_page.SelectedIndex = 1;
            RPV_Preclosure.Selected = true;

            SMHR_LOANTRANS _obj_smhr_LoanTrans = new SMHR_LOANTRANS();
            _obj_smhr_LoanTrans.LOANTRANS_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            lblPreClosureTransID.Text = Convert.ToString(Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            _obj_smhr_LoanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_LoanTrans.OPERATION = operation.Select;
            DataTable dt = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);

            /* To bind values to controls */
            rcmb_PreClosureBU.DataSource = dt;
            rcmb_PreClosureBU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_PreClosureBU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_PreClosureBU.DataBind();

            rcmb_PreClosureEmp.DataSource = dt;
            rcmb_PreClosureEmp.DataTextField = "EMPNAME";
            rcmb_PreClosureEmp.DataValueField = "LOANTRANS_EMP_ID";
            rcmb_PreClosureEmp.DataBind();

            rtxt_PreClosureLoanNo.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_LOANNO"]);

            //hdn_LoanProcessType.Value = Convert.ToString(dt.Rows[0]["PAYITEM_LOAN_PROCESSTYPE"]);

            //To populate PayMode
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_businessunit.OPERATION = operation.Empty;
            _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_PreClosureBU.SelectedValue);
            DataTable dtPayMode = BLL.get_BusinessUnit(_obj_smhr_businessunit);
            rcmb_PreClosurePayMode.DataSource = dtPayMode;
            rcmb_PreClosurePayMode.DataTextField = "HR_MASTER_CODE";
            rcmb_PreClosurePayMode.DataValueField = "HR_MASTER_ID";
            rcmb_PreClosurePayMode.DataBind();
            rcmb_PreClosurePayMode.Items.Insert(0, new RadComboBoxItem("Select"));

            //To select payment mode
            rcmb_PreClosurePayMode.SelectedIndex = rcmb_PreClosurePayMode.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRAN_PAYMODE"]));
            if (rcmb_PreClosurePayMode.SelectedItem.Text.ToUpper() == "CHEQUE")
            {
                trPreClosureCheque.Visible = true;
                rtxt_PreClosureChequeNo.Value = Convert.ToDouble(dt.Rows[0]["LOANTRAN_CHEQUENUM"]);
            }
            else
            {
                trPreClosureCheque.Visible = false;
                rtxt_PreClosureChequeNo.Value = 0;
            }

            //hdn_IsLoanSanctioned.Value = Convert.ToString(dt.Rows[0]["IsLoanSanctioned"]);

            //To populate loan type
            rcmb_PreClosureLoanType.Items.Clear();
            SMHR_PAYITEMS _obj_Payitems = new SMHR_PAYITEMS();
            _obj_Payitems.OPERATION = operation.Check1;
            _obj_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PAYITEM_LOAN_PROCESSTYPE"])))
            {
                //_obj_Payitems.PAYITEM_LOAN_PROCESSTYPE = Convert.ToInt32(hdn_LoanProcessType.Value);
            }

            rcmb_PreClosureLoanType.DataSource = BLL.get_PayItems(_obj_Payitems);
            rcmb_PreClosureLoanType.DataTextField = "PAYITEM_PAYITEMNAME";
            rcmb_PreClosureLoanType.DataValueField = "PAYITEM_ID";
            rcmb_PreClosureLoanType.DataBind();
            rcmb_PreClosureLoanType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            rcmb_PreClosureLoanType.SelectedIndex = rcmb_PreClosureLoanType.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_LOANTYPE_ID"]));
            rdtp_PreClosureIssueDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_ISSUEDATE"]);

            rtxt_PreClosureLoanAmt.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_LOANAMOUNT"]);

            rtxt_PreClosureLoanBalance.Value = Convert.ToDouble(dt.Rows[0]["LOANTRANDTL_CURRENTBALANCEAMOUNT"]);
            rtxt_IntrestOnLoanBal.Value = Convert.ToDouble(dt.Rows[0]["LOANTRANDTL_INTEREST"]);
            rtxt_PreClosureIntRate.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_INTERESTRATE"]);

            rtxt_PreClosureTotalAmt.Value = Convert.ToDouble(dt.Rows[0]["LOANTRANDTL_CURRENTBALANCEAMOUNT"]) + Convert.ToDouble(dt.Rows[0]["LOANTRANDTL_INTEREST"]);

            //rtxt_EMI.Text = string.Empty;
            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["RescheduleEffDate"])))
            {
                rdtp_PreClosureEffDt.SelectedDate = Convert.ToDateTime(dt.Rows[0]["RescheduleEffDate"]);      //rdtp_EffectiveDate.SelectedDate;
            }

            rtxt_PreClosurePurpose.Text = Convert.ToString(dt.Rows[0]["LOANTRAN_LOANPURPOSE"]);

            lblPreClosureTransID.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_ID"]);
            lblPreClosureEMINo.Text = Convert.ToString(dt.Rows[0]["LOANTRANDTL_CURR_EMINO"]);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void btnPreClosureCal_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    protected void btnPreClosure_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_LOANTRANSDTL objLoanTransDtl = new SMHR_LOANTRANSDTL();
            objLoanTransDtl.LOANTRADTL_LOANTRAN_ID = Convert.ToInt32(lblPreClosureTransID.Text);
            objLoanTransDtl.LOANTRANDTL_LOANNO = rtxt_PreClosureLoanNo.Text;
            //objLoanTransDtl.LOANTRANDTL_EMIPAYMENTDUEDATE = Convert.ToDateTime(rdtp_PreClosureEffDt.SelectedDate);
            objLoanTransDtl.LOANTRANDTL_EMIPAYMENTDUEDATE = Convert.ToDateTime(DateTime.Today);
            objLoanTransDtl.LOANTRANDTL_EMIAMOUNT = Convert.ToDouble(rtxt_PreClosureTotalAmt.Value);
            objLoanTransDtl.LOANTRANDTL_EMISTATUS = 1;
            objLoanTransDtl.LOANTRANDTL_CURRENTBALANCEAMOUNT = Convert.ToDouble(rtxt_PreClosureLoanBalance.Value);
            objLoanTransDtl.LOANTRANDTL_CURRENTLOANAMOUNT = Convert.ToDouble(0);
            objLoanTransDtl.LOANTRANDTL_CURR_EMINO = Convert.ToInt32(lblPreClosureEMINo.Text);
            objLoanTransDtl.LOANTRANDTL_INTEREST = Convert.ToDouble(rtxt_IntrestOnLoanBal.Value);
            //objLoanTransDtl.LOANTRANDTL_PRINCIPLEAMT = Convert.ToDouble()
            objLoanTransDtl.OPERATION = operation.Insert_New;
            if (BLL.set_EmpLoanTranDtl(objLoanTransDtl, string.Empty))
            {
                BLL.ShowMessage(this, "Loan Pre-Closed Successfully");
            }
            else
            {
                BLL.ShowMessage(this, "Information Not Saved");
            }

            ClearPreClosureControls();
            LoadGrid();
            Rg_Loandet.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearPreClosureControls()
    {
        try
        {
            //To clear rescheduling page values
            Rm_Loan_page.SelectedIndex = 0;
            rcmb_PreClosureBU.Items.Clear();
            rcmb_PreClosureBU.Text = string.Empty;
            rcmb_PreClosureEmp.Items.Clear();
            rcmb_PreClosureEmp.Text = string.Empty;
            rtxt_PreClosureLoanNo.Text = string.Empty;
            rcmb_PreClosureLoanType.Items.Clear();
            rcmb_PreClosureLoanType.Text = string.Empty;
            rdtp_PreClosureIssueDate.Clear();
            rtxt_PreClosureLoanAmt.Text = string.Empty;
            rtxt_PreClosureLoanBalance.Text = string.Empty;
            rtxt_IntrestOnLoanBal.Text = string.Empty;
            //rtxt_InstallmentNo.Text = string.Empty;
            rtxt_PreClosureIntRate.Text = string.Empty;
            rtxt_PreClosureTotalAmt.Text = string.Empty;
            rcmb_PreClosurePayMode.Items.Clear();
            rcmb_PreClosurePayMode.Text = string.Empty;
            //rtxt_EMI.Text = string.Empty;
            rdtp_PreClosureEffDt.Clear();
            rtxt_PreClosurePurpose.Text = string.Empty;
            //hdn_IsLoanSanctioned.Value = null;
            lblPreClosureTransID.Text = string.Empty;
            lblPreClosureEMINo.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnPreClosureCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearPreClosureControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rtxt_InstallmentNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            rtxt_EMI.Text = string.Empty;
            Session.Remove("datatable");
            lnkViewEMI.Visible = false;

            if (hdnMinTenureMonths.Value != null && Convert.ToInt32(hdnMinTenureMonths.Value) > (Convert.ToInt32(rtxt_InstallmentNo.Text) + Convert.ToInt32(hdnClosedEMICount.Value)))
            {
                BLL.ShowMessage(this, "Minimum " + hdnMinTenureMonths.Value + " months required for this loan");
                rtxt_InstallmentNo.Text = string.Empty;
                return;
            }
            if (hdnMaxTenureMonths.Value != null && Convert.ToInt32(hdnMaxTenureMonths.Value) < (Convert.ToInt32(rtxt_InstallmentNo.Text) + Convert.ToInt32(hdnClosedEMICount.Value)))
            {
                BLL.ShowMessage(this, "Maximum " + hdnMaxTenureMonths.Value + " months required for this loan/Already you have used " + hdnClosedEMICount.Value + " installments for this loan");
                rtxt_InstallmentNo.Text = string.Empty;
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void lnk_WithDrawl_Command(object sender, CommandEventArgs e)
    //{
    //    try
    //    {
    //        //lnkbtn_EMIDATA.Visible = false;
    //        Rm_Loan_page.SelectedIndex = 1;
    //        RPV_PreClosOrWithdrawl.Selected = true;

    //        SMHR_LOANTRANS _obj_smhr_LoanTrans = new SMHR_LOANTRANS();
    //        _obj_smhr_LoanTrans.LOANTRANS_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
    //        lblPreClosureTransID.Text = Convert.ToString(Convert.ToInt32(Convert.ToString(e.CommandArgument)));
    //        _obj_smhr_LoanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        _obj_smhr_LoanTrans.OPERATION = operation.Select;
    //        DataTable dt = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);

    //        /* To bind values to controls */
    //        rcmb_PreClosOrWithdrawlBU.DataSource = dt;
    //        rcmb_PreClosOrWithdrawlBU.DataTextField = "BUSINESSUNIT_CODE";
    //        rcmb_PreClosOrWithdrawlBU.DataValueField = "BUSINESSUNIT_ID";
    //        rcmb_PreClosOrWithdrawlBU.DataBind();

    //        rcmb_PreClosOrWithdrawlEmp.DataSource = dt;
    //        rcmb_PreClosOrWithdrawlEmp.DataTextField = "EMPNAME";
    //        rcmb_PreClosOrWithdrawlEmp.DataValueField = "LOANTRANS_EMP_ID";
    //        rcmb_PreClosOrWithdrawlEmp.DataBind();

    //        rtxt_PreClosOrWithdrawlLoanNo.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_LOANNO"]);

    //        //To populate loan type
    //        rcmb_PreClosOrWithdrawlLoanType.Items.Clear();
    //        SMHR_PAYITEMS _obj_Payitems = new SMHR_PAYITEMS();
    //        _obj_Payitems.OPERATION = operation.Check1;
    //        _obj_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

    //        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PAYITEM_LOAN_PROCESSTYPE"])))
    //        {
    //            //_obj_Payitems.PAYITEM_LOAN_PROCESSTYPE = Convert.ToInt32(hdn_LoanProcessType.Value);
    //        }

    //        rcmb_PreClosOrWithdrawlLoanType.DataSource = BLL.get_PayItems(_obj_Payitems);
    //        rcmb_PreClosOrWithdrawlLoanType.DataTextField = "PAYITEM_PAYITEMNAME";
    //        rcmb_PreClosOrWithdrawlLoanType.DataValueField = "PAYITEM_ID";
    //        rcmb_PreClosOrWithdrawlLoanType.DataBind();
    //        rcmb_PreClosOrWithdrawlLoanType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

    //        rcmb_PreClosOrWithdrawlLoanType.SelectedIndex = rcmb_PreClosureLoanType.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_LOANTYPE_ID"]));
    //        rdtp_PreClosOrWithdrawlIssueDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_ISSUEDATE"]);

    //        rtxt_PreClosOrWithdrawlLoanAmt.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_LOANAMOUNT"]);

    //        // rtxt_withdrawalLoanBalance.Value = Convert.ToDouble(dt.Rows[0]["LOANTRANDTL_CURRENTBALANCEAMOUNT"]);


    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    /* --------------------------------------- */
    #region "Pre-Closure Or Withdrawal fucntionality"

    private void ClearPreClosOrWithdrawlControls()
    {
        try
        {
            //To clear rescheduling page values
            Rm_Loan_page.SelectedIndex = 0;
            rcmb_PreClosOrWithdrawlBU.Items.Clear();
            rcmb_PreClosOrWithdrawlBU.Text = string.Empty;
            rcmb_PreClosOrWithdrawlEmp.Items.Clear();
            rcmb_PreClosOrWithdrawlEmp.Text = string.Empty;
            rtxt_PreClosOrWithdrawlLoanNo.Text = string.Empty;
            rcmb_PreClosOrWithdrawlLoanType.Items.Clear();
            rcmb_PreClosOrWithdrawlLoanType.Text = string.Empty;
            rdtp_PreClosOrWithdrawlIssueDate.Clear();
            rtxt_PreClosOrWithdrawlLoanAmt.Text = string.Empty;
            //rtxt_PreClosureLoanBalance.Text = string.Empty;

            //rbtnPreClosOrWithdrawlType.ClearSelection();
            rtxt_PreClosOrWithdrawlLoanBalance.Text = string.Empty;
            rtxt_PreClosWithdrwlLoanBalance.Text = string.Empty;
            hdn_PreClosOrWithdrawl_LoanProcessType.Value = null;

            //To clear hidden field values for loan max eligibility
            lblLoanEligibleAmount.Text = string.Empty;
            hdnMinTenureMonths.Value = null;
            hdnMaxTenureMonths.Value = null;
            hdnMaxeligibleMonthsforEmp.Value = null;
            hdnClosedEMICount.Value = null;
            Session.Remove("datatable");

            lblPreClosOrWithdrawlTransID.Text = string.Empty;
            lblPreClosOrWithdrawlEMINo.Text = string.Empty;

            rtxt_PreClosurePartialAmt.Text = string.Empty;
            rtxt_ParitalPreClosureBalance.Text = string.Empty;
            rtxt_PreClosOrWithdrwlTnstallments.Text = string.Empty;
            rtxt_PreClosOrWithdrwlEMIAmount.Text = string.Empty;
            rtxt_PreClosIntrestOnLoanBal.Text = string.Empty;
            rtxt_PrecClosOrWithdrwlIntRate.Text = string.Empty;
            rtxt_PreClosOrWithdrwlTotAmt.Text = string.Empty;
            rcmb_PreClosOrWithdrwlPayMode.Items.Clear();
            rcmb_PreClosOrWithdrwlPayMode.Text = string.Empty;
            rtxt_PreClosOrWithdrwlChequeNo.Text = string.Empty;
            rdtp_PreClosOrWithdrwlEffDt.Clear();
            rtxt_PreClosWithdrwlPurpose.Text = string.Empty;
            txtPreClosOrWithdrwlComments.Text = string.Empty;

            //To show/hide default controls
            trPreClosurePartialAmt.Visible = false;
            pnlPartialPreClosure.Visible = false;
            btnPreClosOrWithdrwlCal.Visible = false;
            //trPreClosIntrestOnLoanBal.Visible = true;   //To show interest on current loan balance
            trPreClosOrWithdrwlTotAmt.Visible = true;   //To hide total amt to pay
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_PreClosOrWithdrawl_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //lnkbtn_EMIDATA.Visible = false;
            Rm_Loan_page.SelectedIndex = 1;
            RPV_PreClosOrWithdrawl.Selected = true;

            SMHR_LOANTRANS _obj_smhr_LoanTrans = new SMHR_LOANTRANS();
            _obj_smhr_LoanTrans.LOANTRANS_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            lblPreClosOrWithdrawlTransID.Text = Convert.ToString(Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            _obj_smhr_LoanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_LoanTrans.OPERATION = operation.Select;
            DataTable dt = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);

            /* To bind values to controls */
            rcmb_PreClosOrWithdrawlBU.DataSource = dt;
            rcmb_PreClosOrWithdrawlBU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_PreClosOrWithdrawlBU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_PreClosOrWithdrawlBU.DataBind();

            rcmb_PreClosOrWithdrawlEmp.DataSource = dt;
            rcmb_PreClosOrWithdrawlEmp.DataTextField = "EMPNAME";
            rcmb_PreClosOrWithdrawlEmp.DataValueField = "LOANTRANS_EMP_ID";
            rcmb_PreClosOrWithdrawlEmp.DataBind();

            rtxt_PreClosOrWithdrawlLoanNo.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_LOANNO"]);

            //To populate loan type
            rcmb_PreClosOrWithdrawlLoanType.Items.Clear();
            SMHR_PAYITEMS _obj_Payitems = new SMHR_PAYITEMS();
            _obj_Payitems.OPERATION = operation.Check1;
            _obj_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PAYITEM_LOAN_PROCESSTYPE"])))
            {
                _obj_Payitems.PAYITEM_LOAN_PROCESSTYPE = Convert.ToInt32(dt.Rows[0]["PAYITEM_LOAN_PROCESSTYPE"]);
                hdn_PreClosOrWithdrawl_LoanProcessType.Value = Convert.ToString(dt.Rows[0]["PAYITEM_LOAN_PROCESSTYPE"]);
                rcmb_PrClosWithdrwlLoanProcessType.SelectedIndex = rcmb_PrClosWithdrwlLoanProcessType.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["PAYITEM_LOAN_PROCESSTYPE"]));
                //  if (Convert.ToInt32(dt.Rows[0]["PAYITEM_LOAN_PROCESSTYPE"]) == 0)   //Reducing Balance Loan
                if (Convert.ToInt32(dt.Rows[0]["PAYITEM_LOAN_PROCESSTYPE"]) == 2)
                {
                    lblPreClosOrWithdrawl.Text = "Loan Pre-Closure";    //heading
                    lblPreClosOrWithdrawlType.Text = "Pre-Closure Type";
                    lblPreClosOrWithdrawlCurrLoanBal.Text = "Current Loan Balance";  //to change the label text for Increasin bal loan
                    rbtnPreClosOrWithdrawlType.Items[0].Text = "Partial Payment";
                    rbtnPreClosOrWithdrawlType.Items[1].Text = "Complete Payment";
                    btnPreClosOrWithdrawl.Text = "Pre-Closure";

                    trWithdrawalAmt.Visible = false;
                    rbtnPreClosOrWithdrawlType.SelectedValue = "1";
                    trPreClosOrWithdrwlComments.Visible = true;
                    //trPreClosIntrestOnLoanBal.Visible = true;
                    trPrecClosOrWithdrwlIntRate.Visible = true;
                    trPreClosOrWithdrwlTotAmt.Visible = true;
                    if (dt.Rows[0]["LOANTRANDTL_CURRENTBALANCEAMOUNT"] != System.DBNull.Value)
                    {
                        rtxt_PreClosWithdrwlLoanBalance.Value = Convert.ToDouble(dt.Rows[0]["LOANTRANDTL_CURRENTBALANCEAMOUNT"]);
                        rtxt_PreClosOrWithdrwlTotAmt.Value = Convert.ToDouble(dt.Rows[0]["LOANTRANDTL_CURRENTBALANCEAMOUNT"]);// +Convert.ToDouble(dt.Rows[0]["LOANTRANDTL_INTEREST"]);   //To calculate interest + loan_balance
                    }
                    else
                    {
                        if (dt.Rows[0]["LOANTRANS_LOANAMOUNT"] != System.DBNull.Value)
                        {
                            rtxt_PreClosWithdrwlLoanBalance.Value = Convert.ToDouble(dt.Rows[0]["LOANTRANS_LOANAMOUNT"]);
                            rtxt_PreClosOrWithdrwlTotAmt.Value = Convert.ToDouble(dt.Rows[0]["LOANTRANS_LOANAMOUNT"]);// +Convert.ToDouble(dt.Rows[0]["LOANTRANDTL_INTEREST"]);   //To calculate interest + loan_balance
                        }
                    }
                }
                else if (Convert.ToInt32(dt.Rows[0]["PAYITEM_LOAN_PROCESSTYPE"]) == 1)  //Increasing Balance loan
                {
                    lblPreClosOrWithdrawl.Text = "Loan Withdrawal"; //heading
                    lblPreClosOrWithdrawlType.Text = "Withdrawal Type";
                    lblPreClosOrWithdrawlCurrLoanBal.Text = "Current Deposit Balance";  //to change the label text for Increasin bal loan
                    rbtnPreClosOrWithdrawlType.Items[0].Text = "Partial Withdrawal";
                    rbtnPreClosOrWithdrawlType.Items[1].Text = "Complete Withdrawal";
                    btnPreClosOrWithdrawl.Text = "Withdraw";

                    trWithdrawalAmt.Visible = true;
                    rbtnPreClosOrWithdrawlType.SelectedValue = "1";
                    trPreClosOrWithdrwlComments.Visible = true;
                    btnPreClosOrWithdrwlCal.Visible = false;
                    //trPreClosIntrestOnLoanBal.Visible = false;
                    trPrecClosOrWithdrwlIntRate.Visible = false;
                    trPreClosOrWithdrwlTotAmt.Visible = false;
                    rtxt_PreClosWithdrwlLoanBalance.Value = Convert.ToDouble(dt.Rows[0]["IncreasingLoanBalance"]);
                    rtxt_PreClosOrWithdrawlLoanBalance.Value = Convert.ToDouble(dt.Rows[0]["IncreasingLoanBalance"]);
                    rtxt_PreClosOrWithdrawlLoanBalance.Enabled = false;
                }
            }

            rcmb_PreClosOrWithdrawlLoanType.DataSource = BLL.get_PayItems(_obj_Payitems);
            rcmb_PreClosOrWithdrawlLoanType.DataTextField = "PAYITEM_PAYITEMNAME";
            rcmb_PreClosOrWithdrawlLoanType.DataValueField = "PAYITEM_ID";
            rcmb_PreClosOrWithdrawlLoanType.DataBind();
            rcmb_PreClosOrWithdrawlLoanType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            rcmb_PreClosOrWithdrawlLoanType.SelectedIndex = rcmb_PreClosOrWithdrawlLoanType.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_LOANTYPE_ID"]));
            rdtp_PreClosOrWithdrawlIssueDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_ISSUEDATE"]);

            rtxt_PreClosOrWithdrawlLoanAmt.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_LOANAMOUNT"]);
            //rtxt_PreClosWithdrwlLoanBalance.Value = Convert.ToDouble(dt.Rows[0]["LOANTRANDTL_CURRENTBALANCEAMOUNT"]);






            rtxt_PreClosIntrestOnLoanBal.Value = Convert.ToDouble(dt.Rows[0]["LOANTRANDTL_INTEREST"]);
            rtxt_PrecClosOrWithdrwlIntRate.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_INTERESTRATE"]);

            //rtxt_PreClosOrWithdrwlTotAmt.Value = Convert.ToDouble(dt.Rows[0]["LOANTRANDTL_CURRENTBALANCEAMOUNT"]) + Convert.ToDouble(dt.Rows[0]["LOANTRANDTL_INTEREST"]);

            //rtxt_EMI.Text = string.Empty;
            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["RescheduleEffDate"])))
            {
                rdtp_PreClosOrWithdrwlEffDt.SelectedDate = Convert.ToDateTime(dt.Rows[0]["RescheduleEffDate"]);      //rdtp_EffectiveDate.SelectedDate;
            }

            rtxt_PreClosWithdrwlPurpose.Text = Convert.ToString(dt.Rows[0]["LOANTRAN_LOANPURPOSE"]);

            lblPreClosOrWithdrawlTransID.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_ID"]);
            lblPreClosOrWithdrawlEMINo.Text = Convert.ToString(dt.Rows[0]["LOANTRANDTL_CURR_EMINO"]);
            hdnClosedEMICount.Value = Convert.ToString(dt.Rows[0]["ClosedEmiCount"]);   //To hold Closed EMI's count










            // rtxt_withdrawalLoanBalance.Value = Convert.ToDouble(dt.Rows[0]["LOANTRANDTL_CURRENTBALANCEAMOUNT"]);

            //To populate PayMode
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_businessunit.OPERATION = operation.Empty;
            _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_PreClosOrWithdrawlBU.SelectedValue);
            DataTable dtPayMode = BLL.get_BusinessUnit(_obj_smhr_businessunit);
            rcmb_PreClosOrWithdrwlPayMode.DataSource = dtPayMode;
            rcmb_PreClosOrWithdrwlPayMode.DataTextField = "HR_MASTER_CODE";
            rcmb_PreClosOrWithdrwlPayMode.DataValueField = "HR_MASTER_ID";
            rcmb_PreClosOrWithdrwlPayMode.DataBind();
            rcmb_PreClosOrWithdrwlPayMode.Items.Insert(0, new RadComboBoxItem("Select"));

            //To select payment mode
            rcmb_PreClosOrWithdrwlPayMode.SelectedIndex = rcmb_PreClosOrWithdrwlPayMode.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRAN_PAYMODE"]));
            if (rcmb_PreClosOrWithdrwlPayMode.SelectedItem.Text.ToUpper() == "CHEQUE")
            {
                trPreClosOrWithdrwlCheque.Visible = true;
                rtxt_PreClosOrWithdrwlChequeNo.Value = Convert.ToDouble(dt.Rows[0]["LOANTRAN_CHEQUENUM"]);
            }
            else
            {
                trPreClosOrWithdrwlCheque.Visible = false;
                rtxt_PreClosOrWithdrwlChequeNo.Value = 0;
            }




            /* To find loan max eligibility */
            if (string.Compare(hdn_PreClosOrWithdrawl_LoanProcessType.Value, "0", true) == 0)
            {
                #region Reducing Balance
                if (rcmb_PreClosOrWithdrawlLoanType.SelectedIndex > 0)
                {
                    if (rcmb_PreClosOrWithdrawlEmp.SelectedItem == null || string.Compare(rcmb_PreClosOrWithdrawlEmp.SelectedItem.Text.ToLower(), "select", true) == 0)
                    {
                        BLL.ShowMessage(this, "Please select Employee");
                        rcmb_PreClosOrWithdrawlLoanType.ClearSelection();
                        return;
                    }
                    else
                    {
                        SMHR_LOANSETUP oSMHR_LOANSETUP = new SMHR_LOANSETUP();
                        oSMHR_LOANSETUP.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        oSMHR_LOANSETUP.LOGIN_ID = Convert.ToInt32(rcmb_PreClosOrWithdrawlEmp.SelectedValue);
                        oSMHR_LOANSETUP.LOANSETUP_LOANTYPE_ID = Convert.ToInt32(rcmb_PreClosOrWithdrawlLoanType.SelectedValue);
                        if (string.Compare(rcmb_PreClosOrWithdrawlLoanType.SelectedItem.Text, "Salary Advance", true) == 0)//|| string.Compare(rcmb_LoanType.SelectedItem.Text, "Salary in Advance", true) != 0)
                        {
                            #region Salary Advance
                            //trBrowse.Visible = false;
                            oSMHR_LOANSETUP.OPERATION = operation.Select;
                            DataTable dtLoanSetup = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                            if (dtLoanSetup.Rows.Count > 0)
                            {
                                //trRateOfInterest.Visible = true;
                                //trLoanEligibleAmount.Visible = true;
                                lblLoanEligibleAmount.Text = Convert.ToInt32(dtLoanSetup.Rows[0]["EMP_BASIC"]).ToString();
                                //lblRateofInterest.Text = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_LOANINTEREST"]);
                                hdnMinTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                                hdnMaxTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);
                                hdnMaxeligibleMonthsforEmp.Value = Convert.ToString(dtLoanSetup.Rows[0]["MAXELIGIBLEMONTHSFOREMPLOYEE"]);
                            }
                            #endregion
                        }
                        else if (string.Compare(rcmb_PreClosOrWithdrawlLoanType.SelectedItem.Text, "Salary in Advance", true) == 0)
                        {
                            #region Salary In Advance
                            //trBrowse.Visible = false;
                            oSMHR_LOANSETUP.OPERATION = operation.Validate;
                            oSMHR_LOANSETUP.Amount = 0;
                            oSMHR_LOANSETUP.EffectiveDate = DateTime.Now;
                            DataTable dtLoan = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                            oSMHR_LOANSETUP.OPERATION = operation.Select;
                            DataTable dtLoanSetup = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                            if (dtLoan.Rows.Count > 0 && dtLoanSetup.Rows.Count > 0)
                            {
                                if (Convert.ToBoolean(dtLoan.Rows[0]["FINAL"]))
                                {
                                    lblLoanEligibleAmount.Text = Convert.ToInt32(dtLoan.Rows[0]["AMOUNT"]).ToString();
                                    hdnMinTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                                    hdnMaxTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);
                                    hdnMaxeligibleMonthsforEmp.Value = Convert.ToString(dtLoanSetup.Rows[0]["MAXELIGIBLEMONTHSFOREMPLOYEE"]);
                                }
                            }
                            #endregion
                        }
                        #region Car Life Loans
                        #endregion
                        else
                        {
                            #region All Loans
                            oSMHR_LOANSETUP.OPERATION = operation.Check;
                            DataTable dtLoan = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                            if (dtLoan.Rows.Count > 0)
                            {
                                lblLoanEligibleAmount.Text = Convert.ToString(Math.Round(Convert.ToDecimal(dtLoan.Rows[0]["LOANELIGIBLEAMOUNT_MAXAMOUNT"]), 2));
                                hdnMinTenureMonths.Value = Convert.ToString(dtLoan.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                                hdnMaxTenureMonths.Value = Convert.ToString(dtLoan.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);
                                hdnMaxeligibleMonthsforEmp.Value = Convert.ToString(dtLoan.Rows[0]["MAXELIGIBLEMONTHSFOREMPLOYEE"]);
                            }
                            #endregion
                        }
                    }
                }
                #endregion
            }
            /* To find loan max eligibility */


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rbtnPreClosOrWithdrawlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(hdn_PreClosOrWithdrawl_LoanProcessType.Value))
            {
                // if (Convert.ToInt32(hdn_PreClosOrWithdrawl_LoanProcessType.Value) == 0)////To check if the loan type is Reducing Balance
                if (Convert.ToInt32(hdn_PreClosOrWithdrawl_LoanProcessType.Value) == 2)
                {
                    if (rbtnPreClosOrWithdrawlType.SelectedValue == "0") //To check if the selected partial payment
                    {
                        trPreClosurePartialAmt.Visible = true;
                        pnlPartialPreClosure.Visible = true;
                        btnPreClosOrWithdrwlCal.Visible = true;
                        //trPreClosIntrestOnLoanBal.Visible = false;  //To hide interest on current loan balance
                        trPreClosOrWithdrwlTotAmt.Visible = false;  //To hide total amt to pay
                        trPreClosOrWithdrwlComments.Visible = false;    //To hide comments textbox when selected partial payment
                        txtPreClosOrWithdrwlComments.Text = string.Empty;
                    }
                    else if (rbtnPreClosOrWithdrawlType.SelectedValue == "1") //To check if the selected Complete payment
                    {
                        trPreClosurePartialAmt.Visible = false;
                        pnlPartialPreClosure.Visible = false;
                        btnPreClosOrWithdrwlCal.Visible = false;
                        //trPreClosIntrestOnLoanBal.Visible = true;   //To show interest on current loan balance
                        trPreClosOrWithdrwlTotAmt.Visible = true;   //To hide total amt to pay
                        trPreClosOrWithdrwlComments.Visible = true;    //To show comments textbox when selected complete payment
                    }
                }
                else if (Convert.ToInt32(hdn_PreClosOrWithdrawl_LoanProcessType.Value) == 1)  //To check if the loan type is Increasing Balance
                {
                    if (rbtnPreClosOrWithdrawlType.SelectedValue == "0") //To check if the selected partial payment
                    {
                        rtxt_PreClosOrWithdrawlLoanBalance.Enabled = true;
                        trPreClosOrWithdrwlComments.Visible = false;    //To hide comments textbox when selected partial payment
                        txtPreClosOrWithdrwlComments.Text = string.Empty;
                    }
                    else if (rbtnPreClosOrWithdrawlType.SelectedValue == "1") //To check if the selected Complete payment
                    {
                        rtxt_PreClosOrWithdrawlLoanBalance.Value = rtxt_PreClosWithdrwlLoanBalance.Value;
                        rtxt_PreClosOrWithdrawlLoanBalance.Enabled = false;
                        trPreClosOrWithdrwlComments.Visible = true;    //To show comments textbox when selected complete payment
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rtxt_PreClosurePartialAmt_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToDouble(rtxt_PreClosWithdrwlLoanBalance.Value) < Convert.ToDouble(rtxt_PreClosurePartialAmt.Value))
            {
                BLL.ShowMessage(this, "Pre-Closure Amount cannot be more than Current Loan Balance");
                //rtxt_PreClosurePartialAmt.Value = 0;
                // rtxt_ParitalPreClosureBalance.Value = 0;
                return;
            }
            rtxt_PreClosOrWithdrwlTnstallments.Text = string.Empty;
            rtxt_PreClosOrWithdrwlEMIAmount.Text = string.Empty;



            if (!string.IsNullOrEmpty(rtxt_PreClosurePartialAmt.Text))
            {
                //To calculate interest for one month, for the remaining balance after partial re-payment
                SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
                _obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(rcmb_PreClosOrWithdrawlEmp.SelectedValue);
                _obj_smhr_loantrans.LOANTRANS_LOANNO = Convert.ToString(rtxt_PreClosOrWithdrawlLoanNo.Text);
                _obj_smhr_loantrans.LOANTRANS_LOANTYPE_ID = Convert.ToInt32(rcmb_PreClosOrWithdrawlLoanType.SelectedValue);
                _obj_smhr_loantrans.LOANTRANS_ISSUEDATE = Convert.ToDateTime(rdtp_PreClosOrWithdrawlIssueDate.SelectedDate);
                _obj_smhr_loantrans.LOANTRANS_LOANAMOUNT = Convert.ToDouble(rtxt_PreClosurePartialAmt.Value);    //To hold current loan balance



                _obj_smhr_loantrans.LOANTRANS_LOANINSTALL = Convert.ToInt32(1); //To calculate interest for one month
                _obj_smhr_loantrans.LOANTRANS_INTERESTAMT = Convert.ToDouble(rtxt_PrecClosOrWithdrwlIntRate.Value);
                _obj_smhr_loantrans.LOANTRAN_LOANPURPOSE = BLL.ReplaceQuote(Convert.ToString(rtxt_PreClosWithdrwlPurpose.Text));
                _obj_smhr_loantrans.LOANTRANS_EFFDATE = Convert.ToDateTime(rdtp_PreClosOrWithdrwlEffDt.SelectedDate);
                _obj_smhr_loantrans.LOANTRAN_CREATEDDATE = System.DateTime.Now;
                _obj_smhr_loantrans.LOANTRAN_CHEQUENUM = Convert.ToDouble(rtxt_PreClosOrWithdrwlChequeNo.Value);
                _obj_smhr_loantrans.LOANTRAN_TYPE = false;
                _obj_smhr_loantrans.LOANTRAN_PAYMODE = Convert.ToInt32(rcmb_PreClosOrWithdrwlPayMode.SelectedValue);
                _obj_smhr_loantrans.LOANTRAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_loantrans.LOANTRAN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_loantrans.LOANTRAN_LASTMDFDATE = System.DateTime.Now;
                //_obj_smhr_loantrans.CONFIRM = "n";
                _obj_smhr_loantrans.CONFIRM = "C";
                _obj_smhr_loantrans.LOANTRAN_STATUS = 1;

                DataTable dtvalues = new DataTable();
                _obj_smhr_loantrans.LOANTRANS_ID = Convert.ToInt32(lblPreClosOrWithdrawlTransID.Text);

                if (!string.IsNullOrEmpty(hdn_PreClosOrWithdrawl_LoanProcessType.Value) && string.Compare(hdn_PreClosOrWithdrawl_LoanProcessType.Value, "1", true) == 0)
                {
                    BLL.ShowMessage(this, "Cannot Reschedule loan \"" + rcmb_PreClosOrWithdrawlLoanType.SelectedItem.Text + "\"");
                    return;
                }
                else
                {
                    dtvalues = BLL.Calculate_EMI(_obj_smhr_loantrans);


                }

                if (dtvalues.Rows.Count > 0)
                {
                    rtxt_ParitalPreClosureBalance.Value = (Convert.ToDouble(rtxt_PreClosWithdrwlLoanBalance.Value) - Convert.ToDouble(rtxt_PreClosurePartialAmt.Value));//+Convert.ToDouble(dtvalues.Rows[0]["INTEREST AMOUNT"]);
                }
                //rtxt_PreClosOrWithdrwlEMIAmount.Text = Convert.ToString(dtvalues.Rows[0]["EMI AMOUNT"]);















                //rtxt_ParitalPreClosureBalance.Value = (Convert.ToDouble(rtxt_PreClosWithdrwlLoanBalance.Value) - Convert.ToDouble(rtxt_PreClosurePartialAmt.Value));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnPreClosOrWithdrwlCal_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(rtxt_PreClosOrWithdrwlTnstallments.Value) == 0)
            {
                BLL.ShowMessage(this, "No. of Instalments should be greater than 0");
                return;
            }

            /* To validate loan tenure */
            rtxt_PreClosOrWithdrwlEMIAmount.Text = string.Empty;
            Session.Remove("datatable");
            lnkPreClosOrWithdrwlEMI.Visible = false;
            SMHR_LOANSETUP oSMHR_LOANSETUP = new SMHR_LOANSETUP();
            //   SMHR_LOANSETUP oSMHR_LOANSETUP = new SMHR_LOANSETUP();
            oSMHR_LOANSETUP.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            oSMHR_LOANSETUP.LOGIN_ID = Convert.ToInt32(rcmb_PreClosOrWithdrawlEmp.SelectedValue);
            oSMHR_LOANSETUP.LOANSETUP_LOANTYPE_ID = Convert.ToInt32(rcmb_PreClosOrWithdrawlLoanType.SelectedValue);
            oSMHR_LOANSETUP.OPERATION = operation.Select;
            DataTable dtLoanSetup = BLL.get_LoanSetup(oSMHR_LOANSETUP);
            if (dtLoanSetup.Rows.Count > 0)
            {
                //trRateOfInterest.Visible = true;
                //trLoanEligibleAmount.Visible = true;
                lblLoanEligibleAmount.Text = Convert.ToInt32(dtLoanSetup.Rows[0]["EMP_BASIC"]).ToString();
                //lblRateofInterest.Text = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_LOANINTEREST"]);
                hdnMinTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                hdnMaxTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);
                hdnMaxeligibleMonthsforEmp.Value = Convert.ToString(dtLoanSetup.Rows[0]["MAXELIGIBLEMONTHSFOREMPLOYEE"]);
            }
            if (hdnMinTenureMonths.Value != null && Convert.ToInt32(hdnMinTenureMonths.Value) > (Convert.ToInt32(rtxt_PreClosOrWithdrwlTnstallments.Text) + Convert.ToInt32(hdnClosedEMICount.Value)))
            {
                BLL.ShowMessage(this, "Minimum " + hdnMinTenureMonths.Value + " months required for this loan");
                return;
            }
            if (hdnMaxTenureMonths.Value != null && Convert.ToInt32(hdnMaxTenureMonths.Value) < (Convert.ToInt32(rtxt_PreClosOrWithdrwlTnstallments.Text) + Convert.ToInt32(hdnClosedEMICount.Value)))
            {
                BLL.ShowMessage(this, "Maximum " + hdnMaxTenureMonths.Value + " months required for this loan/Already you have used " + hdnClosedEMICount.Value + " installments for this loan");
                return;
            }

          

            /*To validate loan tenure */



            SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
            _obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(rcmb_PreClosOrWithdrawlEmp.SelectedValue);
            _obj_smhr_loantrans.LOANTRANS_LOANNO = Convert.ToString(rtxt_PreClosOrWithdrawlLoanNo.Text);
            _obj_smhr_loantrans.LOANTRANS_LOANTYPE_ID = Convert.ToInt32(rcmb_PreClosOrWithdrawlLoanType.SelectedValue);




            _obj_smhr_loantrans.LOANTRANS_ISSUEDATE = Convert.ToDateTime(rdtp_PreClosOrWithdrawlIssueDate.SelectedDate);
            //_obj_smhr_loantrans.LOANTRANS_LOANAMOUNT = Convert.ToDouble(rtxt_LoanAmount.Value);
            _obj_smhr_loantrans.LOANTRANS_LOANAMOUNT = Convert.ToDouble(rtxt_ParitalPreClosureBalance.Value);    //To hold current loan balance



            _obj_smhr_loantrans.LOANTRANS_LOANINSTALL = Convert.ToInt32(rtxt_PreClosOrWithdrwlTnstallments.Value);
            _obj_smhr_loantrans.LOANTRANS_INTERESTAMT = Convert.ToDouble(rtxt_PrecClosOrWithdrwlIntRate.Value);
            _obj_smhr_loantrans.LOANTRAN_LOANPURPOSE = BLL.ReplaceQuote(Convert.ToString(rtxt_PreClosWithdrwlPurpose.Text));
            _obj_smhr_loantrans.LOANTRANS_EFFDATE = Convert.ToDateTime(rdtp_PreClosOrWithdrwlEffDt.SelectedDate);
            _obj_smhr_loantrans.LOANTRAN_CREATEDDATE = System.DateTime.Now;
            _obj_smhr_loantrans.LOANTRAN_CHEQUENUM = Convert.ToDouble(rtxt_PreClosOrWithdrwlChequeNo.Value);

            _obj_smhr_loantrans.LOANTRAN_TYPE = false;
            _obj_smhr_loantrans.LOANTRAN_PAYMODE = Convert.ToInt32(rcmb_PreClosOrWithdrwlPayMode.SelectedValue);
            _obj_smhr_loantrans.LOANTRAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_loantrans.LOANTRAN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_loantrans.LOANTRAN_LASTMDFDATE = System.DateTime.Now;
            //_obj_smhr_loantrans.CONFIRM = "n";
            _obj_smhr_loantrans.CONFIRM = "C";
            //if (Convert.ToInt32(ViewState["LoanStatus"]) == 0)
            //{
            //    _obj_smhr_loantrans.LOANTRAN_STATUS = 0;
            //}
            //else if (Convert.ToInt32(ViewState["LoanStatus"]) == 1)
            //{
            //    _obj_smhr_loantrans.LOANTRAN_STATUS = 1;
            //}
            _obj_smhr_loantrans.LOANTRAN_STATUS = 1;

            DataTable dtvalues = new DataTable();
            _obj_smhr_loantrans.LOANTRANS_ID = Convert.ToInt32(lblPreClosOrWithdrawlTransID.Text);
            //if (string.Compare(rcmb_loantype.SelectedItem.Text, "Deposits-Kenya", true) == 0
            //    || string.Compare(rcmb_loantype.SelectedItem.Text, "Bucoso-Accrued Interest", true) == 0
            //    || string.Compare(rcmb_loantype.SelectedItem.Text, "Bucoso-Sinking Fund", true) == 0
            //    || string.Compare(rcmb_loantype.SelectedItem.Text, "Bucoso-Entrance Fee", true) == 0)
            //{
            //    SMHR_LOANREQUEST _obj_Smhr_Loanrequest = new SMHR_LOANREQUEST();
            //    _obj_Smhr_Loanrequest.OPERATION = operation.USERLOANTRANEMI;
            //    _obj_Smhr_Loanrequest.SMHR_LOANREQUEST_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
            //    dtvalues = BLL.get_LoanRequest(_obj_Smhr_Loanrequest);
            //}
            if (!string.IsNullOrEmpty(hdn_PreClosOrWithdrawl_LoanProcessType.Value) && string.Compare(hdn_PreClosOrWithdrawl_LoanProcessType.Value, "1", true) == 0)
            {
                //SMHR_LOANREQUEST _obj_Smhr_Loanrequest = new SMHR_LOANREQUEST();
                //_obj_Smhr_Loanrequest.OPERATION = operation.USERLOANTRANEMI;
                //_obj_Smhr_Loanrequest.SMHR_LOANREQUEST_ID = Convert.ToInt32(lblLoanTransID.Text);
                //dtvalues = BLL.get_LoanRequest(_obj_Smhr_Loanrequest);

                BLL.ShowMessage(this, "Cannot Reschedule loan \"" + rcmb_PreClosOrWithdrawlLoanType.SelectedItem.Text + "\"");
                return;
            }
            else
            {
                dtvalues = BLL.Calculate_EMI(_obj_smhr_loantrans);
            }
            rtxt_PreClosOrWithdrwlEMIAmount.Text = Convert.ToString(dtvalues.Rows[0]["EMI AMOUNT"]);
            //rtxt_MonthlyEMI.Text = Convert.ToString(dtvalues.Rows[0]["EMI AMOUNT"]);
            lnkPreClosOrWithdrwlEMI.Visible = true;
            Session["datatable"] = dtvalues;
            lnkPreClosOrWithdrwlEMI.OnClientClick = "  openRadWin('frm_loanemidata.aspx'); return false;";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rtxt_PreClosOrWithdrwlTnstallments_TextChanged(object sender, EventArgs e)
    {
        try
        {
            rtxt_PreClosOrWithdrwlEMIAmount.Text = string.Empty;
            Session.Remove("datatable");
            lnkPreClosOrWithdrwlEMI.Visible = false;
            /*if (hdnMinTenureMonths.Value != null && Convert.ToInt32(hdnMinTenureMonths.Value) > (Convert.ToInt32(rtxt_PreClosOrWithdrwlTnstallments.Text) + Convert.ToInt32(hdnClosedEMICount.Value)))
            {
                BLL.ShowMessage(this, "Minimum " + hdnMinTenureMonths.Value + " months required for this loan");
                return;
            }
            if (hdnMaxTenureMonths.Value != null && Convert.ToInt32(hdnMaxTenureMonths.Value) < (Convert.ToInt32(rtxt_PreClosOrWithdrwlTnstallments.Text) + Convert.ToInt32(hdnClosedEMICount.Value)))
            {
                BLL.ShowMessage(this, "Maximum " + hdnMaxTenureMonths.Value + " months required for this loan/already u have used" + hdnClosedEMICount.Value + " installements for this loan");
                return;
            }*/

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnPreClosOrWithdrawl_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(hdn_PreClosOrWithdrawl_LoanProcessType.Value))
            {
                //if (Convert.ToInt32(hdn_PreClosOrWithdrawl_LoanProcessType.Value) == 0)   //To check if the loan type is Reducing Balance
                if (Convert.ToInt32(hdn_PreClosOrWithdrawl_LoanProcessType.Value) == 2)
                {
                    if (rbtnPreClosOrWithdrawlType.SelectedValue == "0") //To check if the selected partial payment
                    {
                        if (string.IsNullOrEmpty(rtxt_PreClosOrWithdrwlTnstallments.Text))
                        {
                            BLL.ShowMessage(this, "Please Enter No. of Installments");
                            return;
                        }
                        if (string.IsNullOrEmpty(rtxt_PreClosOrWithdrwlEMIAmount.Text))
                        {
                            BLL.ShowMessage(this, "Please Click on Calculate button");
                            return;
                        }
                        SMHR_VOLUNTARY_DEDUCTION_ARREARS _obj_smhr_voluntary_deduction_arrears = new SMHR_VOLUNTARY_DEDUCTION_ARREARS();
                        _obj_smhr_voluntary_deduction_arrears.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_EMP_ID = Convert.ToInt32(rcmb_PreClosOrWithdrawlEmp.SelectedValue);
                        _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_BU_ID = Convert.ToInt32(rcmb_PreClosOrWithdrawlBU.SelectedValue);
                        _obj_smhr_voluntary_deduction_arrears.ENDDATE = Convert.ToDateTime(rdtp_PreClosOrWithdrwlEffDt.SelectedDate);

                        DataTable chkEmpSalDtlsData = BLL.CheckEmpSalDtlsData(_obj_smhr_voluntary_deduction_arrears);
                        if (chkEmpSalDtlsData.Rows.Count > 0)
                        {
                            BLL.ShowMessage(this, "Payroll is already generated for the Effective Date");
                            return;
                        }



                        SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
                        _obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(rcmb_PreClosOrWithdrawlEmp.SelectedValue);
                        _obj_smhr_loantrans.LOANTRANS_LOANNO = Convert.ToString(rtxt_PreClosOrWithdrawlLoanNo.Text);
                        _obj_smhr_loantrans.LOANTRANS_LOANTYPE_ID = Convert.ToInt32(rcmb_PreClosOrWithdrawlLoanType.SelectedValue);
                        _obj_smhr_loantrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                        if (rdtp_PreClosOrWithdrawlIssueDate.SelectedDate > System.DateTime.Now)
                        {
                            BLL.ShowMessage(this, "Loan Issue Date cannot be ahead of Todays Date");
                            return;
                        }
                        else
                        {
                            _obj_smhr_loantrans.LOANTRANS_ISSUEDATE = Convert.ToDateTime(rdtp_PreClosOrWithdrawlIssueDate.SelectedDate);
                        }

                        _obj_smhr_loantrans.LOANTRANS_LOANAMOUNT = Convert.ToDouble(rtxt_ParitalPreClosureBalance.Value);    //To hold loan balance
                        _obj_smhr_loantrans.LOANTRANS_LOANINSTALL = Convert.ToInt32(rtxt_PreClosOrWithdrwlTnstallments.Value);
                        _obj_smhr_loantrans.LOANTRANS_INTERESTAMT = Convert.ToDouble(rtxt_PrecClosOrWithdrwlIntRate.Value);
                        //_obj_smhr_loantrans.LOANTRAN_LOANPURPOSE = BLL.ReplaceQuote(Convert.ToString(rtxt_purpose.Text));
                        _obj_smhr_loantrans.LOANTRANS_EFFDATE = Convert.ToDateTime(rdtp_PreClosOrWithdrwlEffDt.SelectedDate);
                        _obj_smhr_loantrans.LOANTRAN_CREATEDDATE = System.DateTime.Now;
                        _obj_smhr_loantrans.LOANTRAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_smhr_loantrans.LOANTRAN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_smhr_loantrans.LOANTRAN_LASTMDFDATE = System.DateTime.Now;
                        //  _obj_smhr_loantrans.CONFIRM = "N";
                        //_obj_smhr_loantrans.CONFIRM = "Y";
                        _obj_smhr_loantrans.CONFIRM = "R";
                        _obj_smhr_loantrans.OPERATION = operation.Insert;
                        _obj_smhr_loantrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_smhr_loantrans.LOANTRAN_TYPE = false;
                        _obj_smhr_loantrans.LOANTRAN_STATUS = 1;
                        _obj_smhr_loantrans.LOANTRANS_ID = Convert.ToInt32(lblPreClosOrWithdrawlTransID.Text);
                        _obj_smhr_loantrans.LOANNAME = rcmb_PreClosOrWithdrawlLoanType.SelectedItem.Text;
                        //bool result;
                        //result = BLL.set_EmpLoanTrans(_obj_smhr_loantrans);
                        //if (result == true)
                        //{
                        //    BLL.ShowMessage(this, "Loan Rescheduled Successfully");
                        //}
                        //else
                        //{
                        //    BLL.ShowMessage(this, "Loan Transaction failed");
                        //}

                        //ClearPreClosOrWithdrawlControls();
                        //Rm_Loan_page.SelectedIndex = 0;
                        //LoadGrid();
                        //Rg_Loandet.DataBind();
                        //Session.Remove("datatable");



                        /* Loan Pre-Closure functionality */
                        SMHR_LOANTRANSDTL objLoanTransDtl = new SMHR_LOANTRANSDTL();
                        objLoanTransDtl.LOANTRADTL_LOANTRAN_ID = Convert.ToInt32(lblPreClosOrWithdrawlTransID.Text);
                        objLoanTransDtl.LOANTRANDTL_LOANNO = rtxt_PreClosOrWithdrawlLoanNo.Text;
                        //objLoanTransDtl.LOANTRANDTL_EMIPAYMENTDUEDATE = Convert.ToDateTime(rdtp_PreClosureEffDt.SelectedDate);
                        objLoanTransDtl.LOANTRANDTL_EMIPAYMENTDUEDATE = Convert.ToDateTime(DateTime.Today);
                        objLoanTransDtl.LOANTRANDTL_EMIAMOUNT = Convert.ToDouble(rtxt_PreClosurePartialAmt.Value);
                        objLoanTransDtl.LOANTRANDTL_EMISTATUS = 1;
                        objLoanTransDtl.LOANTRANDTL_CURRENTBALANCEAMOUNT = Convert.ToDouble(rtxt_ParitalPreClosureBalance.Value);
                        objLoanTransDtl.LOANTRANDTL_CURRENTLOANAMOUNT = Convert.ToDouble(0);
                        objLoanTransDtl.LOANTRANDTL_CURR_EMINO = Convert.ToInt32(lblPreClosOrWithdrawlEMINo.Text);
                        //objLoanTransDtl.LOANTRANDTL_INTEREST = Convert.ToDouble(rtxt_PreClosIntrestOnLoanBal.Value);
                        objLoanTransDtl.LOANTRANDTL_INTEREST = Convert.ToDouble(0); //There won't be any interest for partial Pre-Closure
                        //objLoanTransDtl.LOANTRANDTL_PRINCIPLEAMT = Convert.ToDouble()
                        objLoanTransDtl.OPERATION = operation.Insert_New;
                        //if (BLL.set_EmpLoanTranDtl(objLoanTransDtl, string.Empty))
                        //{
                        //    BLL.ShowMessage(this, "Loan Pre-Closed Successfully");
                        //}
                        //else
                        //{
                        //    BLL.ShowMessage(this, "Information Not Saved");
                        //}

                        /* If Pre-Closure is sucess then go for Rescheduling */

                        if (BLL.set_EmpLoanTranDtl(objLoanTransDtl, string.Empty))  //Pre-Closure status
                        {
                            bool result;
                            result = BLL.set_EmpLoanTrans(_obj_smhr_loantrans);
                            if (result == true)
                            {
                                BLL.ShowMessage(this, "Loan Processed Successfully");
                            }
                            else
                            {
                                BLL.ShowMessage(this, "Loan Transaction failed");
                            }
                        }

                        ClearPreClosOrWithdrawlControls();
                        Rm_Loan_page.SelectedIndex = 0;
                        LoadGrid();
                        Rg_Loandet.DataBind();
                        Session.Remove("datatable");
                        /* If Pre-Closure is Success then go for ReSchedule */



                        /* Loan Pre-Closure functionality */
                    }
                    else if (rbtnPreClosOrWithdrawlType.SelectedValue == "1") //To check if the selected Complete payment
                    {
                        //Loan Pre-Closure Process
                        SMHR_LOANTRANSDTL objLoanTransDtl = new SMHR_LOANTRANSDTL();
                        objLoanTransDtl.LOANTRADTL_LOANTRAN_ID = Convert.ToInt32(lblPreClosOrWithdrawlTransID.Text);
                        objLoanTransDtl.LOANTRANDTL_LOANNO = rtxt_PreClosOrWithdrawlLoanNo.Text;
                        //objLoanTransDtl.LOANTRANDTL_EMIPAYMENTDUEDATE = Convert.ToDateTime(rdtp_PreClosureEffDt.SelectedDate);
                        objLoanTransDtl.LOANTRANDTL_EMIPAYMENTDUEDATE = Convert.ToDateTime(DateTime.Today);
                        objLoanTransDtl.LOANTRANDTL_EMIAMOUNT = Convert.ToDouble(rtxt_PreClosOrWithdrwlTotAmt.Value);
                        objLoanTransDtl.LOANTRANDTL_EMISTATUS = 1;
                        objLoanTransDtl.LOANTRANDTL_CURRENTBALANCEAMOUNT = Convert.ToDouble(rtxt_PreClosWithdrwlLoanBalance.Value);
                        objLoanTransDtl.LOANTRANDTL_CURRENTLOANAMOUNT = Convert.ToDouble(0);
                        //objLoanTransDtl.LOANTRANDTL_CURR_EMINO = Convert.ToInt32(lblPreClosOrWithdrawlEMINo.Text);
                        objLoanTransDtl.LOANTRANDTL_CURR_EMINO = Convert.ToInt32(0);    //Inserting EMI no. as zero for pre-closure
                        objLoanTransDtl.LOANTRANDTL_INTEREST = Convert.ToDouble(rtxt_PreClosIntrestOnLoanBal.Value);
                        objLoanTransDtl.LOANTRANS_COMMENTS = Convert.ToString(txtPreClosOrWithdrwlComments.Text.Trim()).Replace("'", "''");
                        //objLoanTransDtl.LOANTRANDTL_PRINCIPLEAMT = Convert.ToDouble()
                        objLoanTransDtl.OPERATION = operation.Insert_New;
                        if (BLL.set_EmpLoanTranDtl(objLoanTransDtl, string.Empty))
                        {
                            BLL.ShowMessage(this, "Loan Pre-Closed Successfully");
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Information Not Saved");
                        }

                        ClearPreClosOrWithdrawlControls();
                        LoadGrid();
                        Rg_Loandet.DataBind();
                    }
                }
                else if (Convert.ToInt32(hdn_PreClosOrWithdrawl_LoanProcessType.Value) == 1)  //To check if the loan type is Increasing Balance
                {
                    SMHR_LOANWITHDRAWL objLoanWithdrawl = new SMHR_LOANWITHDRAWL();

                    if (rtxt_PreClosOrWithdrawlLoanBalance.Value == 0)
                    {
                        BLL.ShowMessage(this, "Withdrawal Amount must be greater than 0");
                        return;
                    }
                    if (rbtnPreClosOrWithdrawlType.SelectedValue == "0") //To check if the selected partial payment
                    {
                        if (Convert.ToDouble(rtxt_PreClosWithdrwlLoanBalance.Value) < Convert.ToDouble(rtxt_PreClosOrWithdrawlLoanBalance.Value))
                        {
                            BLL.ShowMessage(this, "Withdrawal Amount must be less than Current Deposit Balance");
                            return;
                        }
                        objLoanWithdrawl.OPERATION = operation.Update;
                    }
                    else if (rbtnPreClosOrWithdrawlType.SelectedValue == "1") //To check if the selected Complete payment
                    {
                        objLoanWithdrawl.OPERATION = operation.Insert;
                        objLoanWithdrawl.LOANTRANS_COMMENTS = Convert.ToString(txtPreClosOrWithdrwlComments.Text.Trim()).Replace("'", "''");
                    }

                    objLoanWithdrawl.LOANWITHDRAWL_LAONTRANS_ID = Convert.ToInt32(lblPreClosOrWithdrawlTransID.Text);
                    objLoanWithdrawl.LOANWITHDRAWL_LOANNO = rtxt_PreClosOrWithdrawlLoanNo.Text;
                    objLoanWithdrawl.LOANWITHDRAWL_AMOUNT = Convert.ToDecimal(rtxt_PreClosOrWithdrawlLoanBalance.Value);
                    objLoanWithdrawl.LOANWITHDRAWL_DATE = DateTime.Now;
                    objLoanWithdrawl.LOANWITHDRAWL_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    objLoanWithdrawl.LOANWITHDRAWL_CREATEDDATE = DateTime.Now;
                    if (BLL.set_LoanWithdrawl(objLoanWithdrawl))
                    {
                        BLL.ShowMessage(this, "Loan amount has successfull withdrawn");
                    }

                    ClearPreClosOrWithdrawlControls();
                    LoadGrid();
                    Rg_Loandet.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnPreClosOrWithdrawlControls_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearPreClosOrWithdrawlControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_LOANTRANS objLoanTrans = new SMHR_LOANTRANS();
            objLoanTrans.LOANTRANS_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
            objLoanTrans.LOANTRANS_LOANISDELETED = true;
            objLoanTrans.LOANTRAN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            objLoanTrans.LOANTRAN_LASTMDFDATE = DateTime.Now;
            objLoanTrans.OPERATION = operation.Delete1;
            if (BLL.set_EmpLoanTrans(objLoanTrans))
            {
                BLL.ShowMessage(this, "Loan has been deleted Successfully");
            }

            ClearControls();
            Rm_Loan_page.SelectedIndex = 0;
            LoadGrid();
            Rg_Loandet.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rtxt_installments_TextChanged(object sender, EventArgs e)
    {
        try
        {
            rtxt_MonthlyEMI.Text = string.Empty;
            lnkbtn_EMIDATA.Visible = false;
            hdn_IsLoanSanctioned.Value = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rtxt_Amount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            rtxt_MonthlyEMI.Text = string.Empty;
            lnkbtn_EMIDATA.Visible = false;
            hdn_IsLoanSanctioned.Value = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnkUpdateRefID_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //lnkbtn_EMIDATA.Visible = false;
            Rm_Loan_page.SelectedIndex = 1;
            RPV_UpdRefId.Selected = true;

            SMHR_LOANTRANS _obj_smhr_LoanTrans = new SMHR_LOANTRANS();
            _obj_smhr_LoanTrans.LOANTRANS_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            lblRefLoanTransID.Text = Convert.ToString(Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            _obj_smhr_LoanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_LoanTrans.OPERATION = operation.Select;
            DataTable dt = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);

            /* To bind values to controls */
            rcmbRefIdBU.DataSource = dt;
            rcmbRefIdBU.DataTextField = "BUSINESSUNIT_CODE";
            rcmbRefIdBU.DataValueField = "BUSINESSUNIT_ID";
            rcmbRefIdBU.DataBind();

            rcmbRefIdEmp.DataSource = dt;
            rcmbRefIdEmp.DataTextField = "EMPNAME";
            rcmbRefIdEmp.DataValueField = "LOANTRANS_EMP_ID";
            rcmbRefIdEmp.DataBind();

            rtxtRefIdLoanNo.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_LOANNO"]);

            //To populate Loan Type
            //Load PayItem Type
            rcmbRefIdLoanType.Items.Clear();
            SMHR_PAYITEMS _obj_Payitems = new SMHR_PAYITEMS();
            _obj_Payitems.OPERATION = operation.Check1;
            _obj_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PAYITEM_LOAN_PROCESSTYPE"])))
            {
                _obj_Payitems.PAYITEM_LOAN_PROCESSTYPE = Convert.ToInt32(dt.Rows[0]["PAYITEM_LOAN_PROCESSTYPE"]);
            }
            rcmbRefIdLoanType.DataSource = BLL.get_PayItems(_obj_Payitems);
            rcmbRefIdLoanType.DataTextField = "PAYITEM_PAYITEMNAME";
            rcmbRefIdLoanType.DataValueField = "PAYITEM_ID";
            rcmbRefIdLoanType.DataBind();
            rcmbRefIdLoanType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            rcmbRefIdLoanType.SelectedIndex = rcmbRefIdLoanType.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_LOANTYPE_ID"]));

            rdpUpdRefIssueDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_ISSUEDATE"]);
            rtxtUpdRefIdLoanAmt.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_LOANAMOUNT"]);
            rtxtUpdRefIntrstAmt.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_INTERESTRATE"]);

            //To populate PayMode
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_businessunit.OPERATION = operation.Empty;
            _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(rcmbRefIdBU.SelectedValue);
            DataTable dtPayMode = BLL.get_BusinessUnit(_obj_smhr_businessunit);
            rcmbUpdRefPayMode.DataSource = dtPayMode;
            rcmbUpdRefPayMode.DataTextField = "HR_MASTER_CODE";
            rcmbUpdRefPayMode.DataValueField = "HR_MASTER_ID";
            rcmbUpdRefPayMode.DataBind();
            rcmbUpdRefPayMode.Items.Insert(0, new RadComboBoxItem("Select"));

            //To select payment mode
            rcmbUpdRefPayMode.SelectedIndex = rcmbUpdRefPayMode.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRAN_PAYMODE"]));
            if (rcmbUpdRefPayMode.SelectedItem.Text.ToUpper() == "CHEQUE")
            {
                trUpdRefCheque.Visible = true;
                rtxtUpdRefCheque.Value = Convert.ToDouble(dt.Rows[0]["LOANTRAN_CHEQUENUM"]);
            }
            else
            {
                trUpdRefCheque.Visible = false;
                rtxtUpdRefCheque.Value = 0;
            }

            rtxtUpdRefPurpose.Text = Convert.ToString(dt.Rows[0]["LOANTRAN_LOANPURPOSE"]);
            if (dt.Rows[0]["LOANTRANS_EFFDATE"] != System.DBNull.Value)
            {
                rdpUpdRefEffDt.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_EFFDATE"]);
            }

            rtxtReferenceId.Text = Convert.ToString(dt.Rows[0]["ReferenceId"]);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx", false);
        }
    }
    protected void btnUpdateRefId_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(lblRefLoanTransID.Text))
            {
                //if(string.IsNullOrEmpty(rtxtReferenceId.Text))
                //{
                //    BLL.ShowMessage(this, "Please Enter Reference ID");
                //    return;
                //}
                SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
                _obj_smhr_loantrans.LOANTRANS_ID = Convert.ToInt32(lblRefLoanTransID.Text);
                _obj_smhr_loantrans.ReferenceId = Convert.ToString(rtxtReferenceId.Text).Replace("'", "''");
                ////_obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(rcmb_RescheduleEmployee.SelectedValue);
                //_obj_smhr_loantrans.LOANTRANS_LOANNO = Convert.ToString(rtxt_LoanNumber.Text);
                //_obj_smhr_loantrans.LOANTRANS_LOANTYPE_ID = Convert.ToInt32(rcmb_RescheduleLoanType.SelectedItem.Value);
                _obj_smhr_loantrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_loantrans.LOANTRAN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_loantrans.LOANTRAN_LASTMDFDATE = System.DateTime.Now;

                _obj_smhr_loantrans.OPERATION = operation.Check1;
                DataTable dtIsExists = BLL.get_EmpLoanTran(_obj_smhr_loantrans);

                if (Convert.ToBoolean(dtIsExists.Rows[0]["IsExists"]))
                {
                    BLL.ShowMessage(this, "ReferenceId already exists.");
                    rtxtReferenceId.Text = string.Empty;
                    rtxtReferenceId.Focus();
                    return;
                }

                _obj_smhr_loantrans.OPERATION = operation.UpdateSTATUS;
                if (BLL.set_EmpLoanTrans(_obj_smhr_loantrans))
                {
                    BLL.ShowMessage(this, "Reference Id Updated Successfully");
                }

                ClearReferenceIdControls();
                Rm_Loan_page.SelectedIndex = 0;
                LoadGrid();
                Rg_Loandet.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx", false);
        }
    }
    protected void btnCancelRefId_Click(object sender, EventArgs e)
    {
        try
        {
            ClearReferenceIdControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx", false);
        }
    }

    private void ClearReferenceIdControls()
    {
        try
        {
            //To clear rescheduling page values
            Rm_Loan_page.SelectedIndex = 0;
            lblRefLoanTransID.Text = string.Empty;
            rcmbRefIdBU.Items.Clear();
            rcmbRefIdBU.Text = string.Empty;
            rcmbRefIdEmp.Items.Clear();
            rcmbRefIdEmp.Text = string.Empty;
            rtxtRefIdLoanNo.Text = string.Empty;
            rcmbRefIdLoanprocType.ClearSelection();
            rcmbRefIdLoanType.Items.Clear();
            rcmbRefIdLoanType.Text = string.Empty;
            rdpUpdRefIssueDate.Clear();
            rtxtUpdRefIdLoanAmt.Text = string.Empty;
            //rtxtUpdRefIdLoanBal.Text = string.Empty;
            rtxtUpdRefIntrstAmt.Text = string.Empty;
            rcmbUpdRefPayMode.Items.Clear();
            rcmbUpdRefPayMode.Text = string.Empty;
            rtxtUpdRefCheque.Text = string.Empty;
            rdpUpdRefEffDt.Clear();
            rtxtUpdRefPurpose.Text = string.Empty;
            rtxtReferenceId.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_emploantran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx", false);
        }
    }


    //protected void Rg_Loandet_ItemDataBound(object sender, GridItemEventArgs e)
    //{

    //      SMHR_LOANTRANS _obj_smhr_LoanTrans = new SMHR_LOANTRANS();
    //     //   _obj_smhr_LoanTrans.LOANTRANS_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
    //      //  lblPreClosOrWithdrawlTransID.Text = Convert.ToString(Convert.ToInt32(Convert.ToString(e.CommandArgument)));
    //        _obj_smhr_LoanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        _obj_smhr_LoanTrans.OPERATION = operation.Select;
    //        DataTable dt = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);
    //        GridDataItem item = e.Item as GridDataItem;
    //        LinkButton lnkEdit = item.FindControl("lnk_Edit_1") as LinkButton;
    //    if (dt.Rows[0]["LOANTRANS_LOANINSTALL"]==null)
    //    {
    //        lnkEdit.Enabled = false;
    //    }
    //    //Rg_Loandet.MasterTableView.Columns
    // }
}