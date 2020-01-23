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


public partial class Payroll_frm_EmpReducingLoanTran : System.Web.UI.Page
{
    static int Currency;
    static string Cur = "";
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdtp_IssueDate, rdtp_EffectiveDate);
                BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), Rg_Loandet, "LOANTRANS_ISSUEDATE");
                Loaddropdowns();
                LoadGrid();
                cheque.Visible = false;
                LoadDetails();

                Rm_Loan_page.SelectedIndex = 0;
            }
            Session.Remove("WRITEFACILITY");

            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("LOAN_ADVANCES");
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



            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                Rg_Loandet.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Save.Visible = false;
                btn_Calculate.Visible = false;
                btn_process.Visible = false;
                btn_Update.Visible = false;

                btn_RSchedProcess.Visible = false;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
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
    //    ClearControls();
    //    Rm_Loan_page.SelectedIndex = 1;
    //    //rd_LOANTRANS.Tabs[1].Enabled = false;
    //    //rd_LOANTRANS.Tabs[2].Enabled = false;
    //    btn_Save.Visible = true;
    //    btn_Save.Enabled = true;
    //    rtxt_MonthlyEMI.Enabled = false;
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

            rcmb_loantype.Items.Clear();
            SMHR_PAYITEMS _obj_Payitems = new SMHR_PAYITEMS();
            _obj_Payitems.OPERATION = operation.Check1;
            _obj_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_loantype.DataSource = BLL.get_PayItems(_obj_Payitems);
            rcmb_loantype.DataTextField = "PAYITEM_PAYITEMNAME";
            rcmb_loantype.DataValueField = "PAYITEM_ID";
            rcmb_loantype.DataBind();
            rcmb_loantype.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
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
                rcmb_Employee.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmb_Employee.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            //if (Convert.ToInt32(Session["EMP_ID"]) == 0)
            //{
              
                SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
                _obj_smhr_loantrans.OPERATION = operation.Select1;
                _obj_smhr_loantrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_loantrans.LOANTRAN_TYPE = Convert.ToBoolean(1);
                _obj_smhr_loantrans.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
              //  _obj_smhr_loantrans.LOANTRAN_TYPE = true;
                Rg_Loandet.DataSource = BLL.get_EmpRedBalLoanTran(_obj_smhr_loantrans);
            //}
            //else
            //{
            //    //FOR SELF-EMPLOYEE
            //    SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
            //    _obj_smhr_loantrans.OPERATION = operation.Select_Self;
            //    _obj_smhr_loantrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    _obj_smhr_loantrans.LOANTRAN_TYPE = Convert.ToBoolean(1);
            //    _obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            //    Rg_Loandet.DataSource = BLL.get_EmpLoanTran(_obj_smhr_loantrans);
            //    Rg_Loandet.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Calculate1_Click(object sender, EventArgs e)
    {
        try
        {
            // getLoanNo();
            //    ClearControls();
            
            if (btn_Save.Enabled == true)
            {
                if (Convert.ToInt32(ddl_PayMode.SelectedIndex) == 0)
                {
                    BLL.ShowMessage(this, "Please Select PayItem Mode");
                    return;

                }
            }
            else
            { 
            }
            if (Convert.ToInt32(rtxt_installments.Value) == 0)
            {
                BLL.ShowMessage(this, "No. of Instalments should be greater than 0");
                return;
            }
            
            SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
            _obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
         //   _obj_smhr_loantrans.LOANTRANS_LOANNO = Convert.ToString(1);
            _obj_smhr_loantrans.LOANTRANS_LOANNO = Convert.ToString(rtxt_loanno.Text);
            _obj_smhr_loantrans.LOANTRANS_LOANTYPE_ID = Convert.ToInt32(rcmb_loantype.SelectedItem.Value);
            _obj_smhr_loantrans.LOANTRANS_ISSUEDATE = Convert.ToDateTime(rdtp_IssueDate.SelectedDate);
            _obj_smhr_loantrans.LOANTRANS_LOANAMOUNT = Convert.ToInt32(rtxt_Amount.Value);
            _obj_smhr_loantrans.LOANTRANS_LOANINSTALL = Convert.ToInt32(rtxt_installments.Value);
            _obj_smhr_loantrans.LOANTRANS_INTERESTAMT = Convert.ToDouble(rtxt_InterestAmt.Value);
            _obj_smhr_loantrans.LOANTRAN_LOANPURPOSE = Convert.ToString(rtxt_purpose.Text);
            _obj_smhr_loantrans.LOANTRANS_EFFDATE = Convert.ToDateTime(rdtp_EffectiveDate.SelectedDate);
            _obj_smhr_loantrans.LOANTRAN_CREATEDDATE = System.DateTime.Now;
            _obj_smhr_loantrans.LOANTRAN_CHEQUENUM = Convert.ToDouble(txt_ChequeNumber.Value);
            _obj_smhr_loantrans.LOANTRAN_TYPE = true;
            _obj_smhr_loantrans.LOANTRAN_PAYMODE = Convert.ToInt32(ddl_PayMode.SelectedValue); 
            _obj_smhr_loantrans.LOANTRAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_loantrans.LOANTRAN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_loantrans.LOANTRAN_LASTMDFDATE = System.DateTime.Now;
            _obj_smhr_loantrans.CONFIRM = "n";
             if (Convert.ToInt32( ViewState["LoanStatus"]) == 0)
            {
                _obj_smhr_loantrans.LOANTRAN_STATUS = 0; 
            }
            else
                if (Convert.ToInt32(ViewState["LoanStatus"]) == 1)
                {
                   
                    _obj_smhr_loantrans.LOANTRAN_STATUS = 1;
                   
                }

            _obj_smhr_loantrans.LOANTRANS_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
            DataTable dtvalues = BLL.Calculate_RedBal(_obj_smhr_loantrans);

            rtxt_MonthlyEMI.Text = Convert.ToString(Convert.ToDouble(dtvalues.Rows[0]["EMI Amount"]));
            lnkbtn_EMIDATA.Visible = true;
            //ViewState["EMIData"] = dtvalues;
            Session["datatable"] = dtvalues;
            //lnkbtn_EMIDATA.OnClientClick ="  openRadWin('frm_loanemidata.aspx?tranid=" + Convert.ToInt32(dtvalues.Rows[0]["LOANTRADTL_LOANTRAN_ID"]) + "'); return false;";
            lnkbtn_EMIDATA.OnClientClick = "  openRadWin('frm_loan_emidata.aspx'); return false;";
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {

                btn_Save.Visible = false;
                btn_Save.Enabled = false;
               


            }

            else
            {
              //  btn_Save.Visible = true;

            }

            //btn_Save.Enabled = true;
           // btn_Calculate.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void btn_Save_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (lblissue.Text != string.Empty)
    //        {
    //            if (rdtp_IssueDate.SelectedDate < Convert.ToDateTime(lblissue.Text))
    //            {
    //                BLL.ShowMessage(this, "Loan Issue Date cannot be ahead of Applied Date.");
    //                return;
    //            }
    //        }
    //        getLoanNo();
    //        SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
    //        _obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
    //        _obj_smhr_loantrans.LOANTRANS_LOANNO = Convert.ToString(rtxt_loanno.Text);
    //        _obj_smhr_loantrans.LOANTRANS_LOANTYPE_ID = Convert.ToInt32(rcmb_loantype.SelectedValue);
    //        if (rdtp_IssueDate.SelectedDate < Convert.ToDateTime(lbl_LoanDetEmpDOJ.Text))
    //        {
    //            BLL.ShowMessage(this, "Loan Issue Date cannot be ahead of Employee Joining Date");
    //            return;
    //        }
    //        else if (rdtp_IssueDate.SelectedDate > System.DateTime.Now)
    //        {
    //            BLL.ShowMessage(this, "Loan Issue Date cannot be ahead of Todays Date");
    //            return;
    //        }
    //        else
    //        {
    //            _obj_smhr_loantrans.LOANTRANS_ISSUEDATE = Convert.ToDateTime(rdtp_IssueDate.SelectedDate);
    //        }
    //        _obj_smhr_loantrans.LOANTRANS_LOANAMOUNT = Convert.ToInt32(rtxt_Amount.Value);
    //        _obj_smhr_loantrans.LOANTRANS_LOANINSTALL = Convert.ToInt32(rtxt_installments.Value);
    //        _obj_smhr_loantrans.LOANTRANS_INTERESTAMT = Convert.ToDouble(rtxt_InterestAmt.Value);
    //        _obj_smhr_loantrans.LOANTRAN_LOANPURPOSE = Convert.ToString(rtxt_purpose.Text);
    //        _obj_smhr_loantrans.LOANTRANS_EFFDATE = Convert.ToDateTime(rdtp_EffectiveDate.SelectedDate);
    //        _obj_smhr_loantrans.LOANTRAN_PAYMODE = Convert.ToInt32(ddl_PayMode.SelectedValue);
    //        if (txt_ChequeNumber.Value != null)
    //            _obj_smhr_loantrans.LOANTRAN_CHEQUENUM = Convert.ToDouble(txt_ChequeNumber.Value);
    //        else
    //            _obj_smhr_loantrans.LOANTRAN_CHEQUENUM = 0;
    //        _obj_smhr_loantrans.LOANTRAN_CREATEDDATE = DateTime.Now;
    //        _obj_smhr_loantrans.LOANTRAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
    //        _obj_smhr_loantrans.LOANTRAN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
    //        _obj_smhr_loantrans.LOANTRAN_LASTMDFDATE = System.DateTime.Now;
    //        _obj_smhr_loantrans.CONFIRM = "Y";
    //        _obj_smhr_loantrans.OPERATION = operation.Insert;
    //        _obj_smhr_loantrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        _obj_smhr_loantrans.LOANTRAN_TYPE = true;
    //        _obj_smhr_loantrans.LOANTRANS_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
    //        bool result;
    //        result = BLL.set_EmpRedBalLoanTrans(_obj_smhr_loantrans);
    //        if (result == true)
    //        {
    //            BLL.ShowMessage(this, "Loan Transaction completed successfully");
    //        }
    //        else
    //            BLL.ShowMessage(this, "Loan Transaction failed");
    //        Rm_Loan_page.SelectedIndex = 0;
    //        LoadGrid();
    //        Rg_Loandet.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }



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
            //////if (lbl_LoanDetEmpDOJ.Text != string.Empty)
            //////{

            //////    if (rdtp_IssueDate.SelectedDate < Convert.ToDateTime(lbl_LoanDetEmpDOJ.Text))
            //////    {
            //////        BLL.ShowMessage(this, "Loan Issue Date cannot be ahead of Employee Joining Date");
            //////        return;
            //////    }
            //////}
            //else 
            if (rdtp_IssueDate.SelectedDate > System.DateTime.Now)
            {
                BLL.ShowMessage(this, "Loan Issue Date cannot be ahead of Todays Date");
                return;
            }
            else
            {
                _obj_smhr_loantrans.LOANTRANS_ISSUEDATE = Convert.ToDateTime(rdtp_IssueDate.SelectedDate);
            }
            _obj_smhr_loantrans.LOANTRANS_LOANAMOUNT = Convert.ToInt32(rtxt_Amount.Value);
            _obj_smhr_loantrans.LOANTRANS_LOANINSTALL = Convert.ToInt32(rtxt_installments.Value);
            _obj_smhr_loantrans.LOANTRANS_INTERESTAMT = Convert.ToDouble(rtxt_InterestAmt.Value);
            _obj_smhr_loantrans.LOANTRAN_LOANPURPOSE = Convert.ToString(rtxt_purpose.Text);
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
            
            _obj_smhr_loantrans.LOANTRAN_TYPE = true;

          //  _obj_smhr_loantrans.LOANTRAN_STATUS = 0; 
            _obj_smhr_loantrans.LOANTRANS_ID = Convert.ToInt32(lbl_loantrans_ID.Text);

            switch (((Button)sender).ID.ToUpper())
            {
                 case "BTN_UPDATE":

                        bool result1;
                  //      SMHR_LOANTRANS _obj_smhr_LoanTrans = new SMHR_LOANTRANS();
                        _obj_smhr_loantrans.LOANTRAN_STATUS = 0;
                        _obj_smhr_loantrans.CONFIRM = "n";
                        _obj_smhr_loantrans.OPERATION = operation.Update ;
                     _obj_smhr_LoanTrans.LOANTRANS_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
                    // _obj_smhr_loantrans.LOANTRAN_TYPE = true;
                    
                                    
                     //_obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
                     //_obj_smhr_loantrans.LOANTRANS_LOANNO = Convert.ToString(rtxt_loanno.Text);
                     //_obj_smhr_loantrans.LOANTRANS_LOANTYPE_ID = Convert.ToInt32(rcmb_loantype.SelectedItem.Value);
                     //_obj_smhr_loantrans.LOANTRANS_ISSUEDATE = Convert.ToDateTime(rdtp_IssueDate.SelectedDate);
                     //_obj_smhr_loantrans.LOANTRANS_INTERESTAMT= Convert.ToDouble(rtxt_InterestAmt.Value);
                     //_obj_smhr_loantrans.LOANTRANS_LOANAMOUNT = Convert.ToInt32(rtxt_Amount.Value);
                     //_obj_smhr_loantrans.LOANTRANS_LOANINSTALL = Convert.ToInt32(rtxt_installments.Value);
                     //_obj_smhr_loantrans.LOANTRANS_INTERESTAMT = Convert.ToDouble(rtxt_InterestAmt.Value);
                     //_obj_smhr_loantrans.LOANTRAN_LOANPURPOSE = Convert.ToString(rtxt_purpose.Text);
                     //_obj_smhr_loantrans.LOANTRANS_EFFDATE = Convert.ToDateTime(rdtp_EffectiveDate.SelectedDate);
                     //_obj_smhr_loantrans.LOANTRAN_PAYMODE = Convert.ToInt32(ddl_PayMode.SelectedValue);
                     //_obj_smhr_loantrans.LOANTRAN_CHEQUENUM = 0;
                     //_obj_smhr_loantrans.LOANTRAN_CREATEDDATE = System.DateTime.Now;
                     //_obj_smhr_loantrans.LOANTRAN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                     //_obj_smhr_loantrans.LOANTRAN_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                     //_obj_smhr_loantrans.LOANTRAN_LASTMDFDATE = System.DateTime.Now;

                     result1 = BLL.set_EmpRedBalLoanTrans(_obj_smhr_loantrans);
                          if(result1== true)
                          {
                              BLL.ShowMessage (this,"Information Updated Successfully.") ;
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
          //   _obj_smhr_loantrans.LOANTRAN_TYPE = true;

             result = BLL.set_EmpRedBalLoanTrans(_obj_smhr_loantrans);
                   
                    if (result == true)
                   {
                        BLL.ShowMessage(this, "Record Saved successfully");
                        
                        //btn_Save.Enabled = true;
                        //btn_Sanction.Enabled = true; 
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
           
            //RPV_RPTDetails.Selected = true;
            //rd_LOANTRANS.SelectedIndex = 0;
            //rd_LOANTRANS.Tabs[2].Enabled = true;
            //btn_Update.Visible = true;
            //btn_Save.Visible = true;
            SMHR_LOANTRANS _obj_smhr_LoanTrans = new SMHR_LOANTRANS();
            Loaddropdowns();
            _obj_smhr_LoanTrans.LOANTRANS_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            lbl_loantrans_ID.Text = Convert.ToString(Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            _obj_smhr_LoanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_LoanTrans.OPERATION = operation.Validate;
            DataTable dt_check = BLL.get_EmpLoanTran(_obj_smhr_LoanTrans);
            if (dt_check.Rows.Count > 0)
            {
                if (Convert.ToString(dt_check.Rows[0]["LOANTRAN_STATUS"]) == "0")
                {
            //        BLL.ShowMessage(this, "Please first Sanction the Loan.");
            //        return;
                     ViewState["LoanStatus"] = 0;
                     rcmb_BusinessUnit.Enabled = false;
                     rcmb_Employee.Enabled = false;
                     rcmb_loantype.Enabled = false;
                     rdtp_IssueDate.Enabled = false;
                     rtxt_RloanNo.Enabled = false;

                 //   btn_Save.Visible = true; 
                //    btn_Save.Enabled = true;
                    btn_Sanction.Enabled = true;
                    if (dt_check.Rows[0]["LOANTRANS_LOANNO"] != System.DBNull.Value)
                    {
                        btn_Update.Visible = true;
                        btn_Update.Enabled = true;
                        btn_Save.Visible = false;
                        btn_Save.Enabled = false;
                        lnkbtn_EMIDATA.Visible = true;
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
                    ViewState["LoanStatus"] = 1;
                    btn_Save.Visible = true; 
                    btn_Save.Enabled = false;
                    btn_Sanction.Enabled = false;
                    btn_Update.Visible = false;
                    btn_Update.Enabled  = false;
                    EnabledFields(false);
                }
            
            }
            
            Rm_Loan_page.SelectedIndex = 1;           
            _obj_smhr_LoanTrans.LOANTRANS_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            _obj_smhr_LoanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //rd_LOANTRANS.Tabs[1].Enabled = false;
            _obj_smhr_LoanTrans.OPERATION = operation.Select;
            DataTable dt = BLL.get_EmpRedBalLoanTran(_obj_smhr_LoanTrans);

            //EnabledFields(false);

            // Getting Employee Name
            if((Convert.ToInt32(dt_check.Rows[0]["EMP_STATUS"])==0) || (Convert.ToInt32(dt_check.Rows[0]["EMP_STATUS"])==1))
            {
            _obj_smhr_LoanTrans.BUSINESSUNIT_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            _obj_smhr_LoanTrans.LOANTRANS_EMP_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["LOANTRANS_EMP_ID"]));
            _obj_smhr_LoanTrans.OPERATION = operation.Empty;
            DataTable dtemp = BLL.get_EmpRedBalLoanTran(_obj_smhr_LoanTrans);
            rcmb_Employee.DataSource = dtemp;
            //lbl_Curr.Text = Convert.ToString(dtemp.Rows[0]["CURRENCY"]);
            rcmb_Employee.DataTextField = "EMPNAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_EMP_ID"]));
            }
            else if ((Convert.ToInt32(dt_check.Rows[0]["EMP_STATUS"]) == 2) || (Convert.ToInt32(dt_check.Rows[0]["EMP_STATUS"]) == 3))
            {
                _obj_smhr_LoanTrans.BUSINESSUNIT_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            _obj_smhr_LoanTrans.LOANTRANS_EMP_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["LOANTRANS_EMP_ID"]));
            _obj_smhr_LoanTrans.OPERATION = operation.EMPTY_R;
            DataTable dtemp = BLL.get_EmpRedBalLoanTran(_obj_smhr_LoanTrans);
            rcmb_Employee.DataSource = dtemp;
            //lbl_Curr.Text = Convert.ToString(dtemp.Rows[0]["CURRENCY"]);
            rcmb_Employee.DataTextField = "EMPNAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_EMP_ID"]));
            }
            rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            LoadPaymentType();
           // ddl_PayMode_SelectedIndexChanged(null, null);
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
            
            //ddl_PayMode.SelectedIndex = ddl_PayMode.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRAN_PAYMODE"]));
            //if (dt.Rows[0]["LOANTRAN_CHEQUENUM"] != System.DBNull.Value)
            //{
            //    txt_ChequeNumber.Value = Convert.ToDouble(dt.Rows[0]["LOANTRAN_CHEQUENUM"]);
            //    cheque.Visible = true;
            //}
            //else
            //{
            //    if (ddl_PayMode.SelectedItem.Text.ToUpper() == "CHEQUE")
            //    {
            //        cheque.Visible = true;
            //        txt_ChequeNumber.Text = string.Empty;
            //    }
            //}
            rtxt_loanno.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_LOANNO"]);
            rtxt_Amount.Value = Convert.ToInt32(dt.Rows[0]["LOANTRANS_LOANAMOUNT"]);
            rcmb_loantype.SelectedIndex = rcmb_loantype.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_LOANTYPE_ID"]));
            if (dt.Rows[0]["LOANTRANS_ISSUEDATE"] != System.DBNull.Value)
            {
                rdtp_IssueDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_ISSUEDATE"]);
            }
            rtxt_installments.Value = Convert.ToInt32(dt.Rows[0]["LOANTRANS_LOANINSTALL"]);
            if (dt.Rows[0]["LOANTRANS_INTERESTRATE"] != System.DBNull.Value)
            {
                rtxt_InterestAmt.Value = Convert.ToDouble(dt.Rows[0]["LOANTRANS_INTERESTRATE"]);
            }
            rtxt_purpose.Text = Convert.ToString(dt.Rows[0]["LOANTRAN_LOANPURPOSE"]);
            if (dt.Rows[0]["LOANTRANS_EFFDATE"] != System.DBNull.Value)
            {
                rdtp_EffectiveDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_EFFDATE"]);
            }

            SMHR_LOANTRANSDTL _obj_smhr_loantrandtl = new SMHR_LOANTRANSDTL();
            _obj_smhr_loantrandtl.LOANTRADTL_LOANTRAN_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            DataTable dt_repay = BLL.get_EmpLoanTranDetail(_obj_smhr_loantrandtl);
            if (dt_repay.Rows.Count != 0)
            {
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
            else
                if (Convert.ToInt32(ddl_PayMode.SelectedIndex) == 0)
                {


                }
                else
                btn_Calculate1_Click(null, null);
              //  btn_Save.Visible = false;
                //btn_Update.Visible = true;
                return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Sanction_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();
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
            rcmb_Employee_SelectedIndexChanged(null, null);
            rtxt_Amount.Value = Convert.ToInt32(dt.Rows[0]["LOANTRANS_LOANAMOUNT"]);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
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
            rcmb_Employee.Items.Insert(0, new RadComboBoxItem());
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
            btn_Calculate.Enabled = true;
            ddl_PayMode.Items.Clear();
            ddl_PayMode.Items.Insert(0, new RadComboBoxItem());
            txt_ChequeNumber.Text = string.Empty;
            lbl_loantrans_ID.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    private void EnabledFields(bool b)
    {
        try
        {
            rcmb_BusinessUnit.Enabled = b;
            rcmb_Employee.Enabled = b; ;
            rcmb_loantype.Enabled = b; ;
            rdtp_EffectiveDate.Enabled = b;
            rdtp_IssueDate.Enabled = b;
            rtxt_loanno.Enabled = b;
            rtxt_Amount.Enabled = b;
            rtxt_installments.Enabled = b;
            rtxt_InterestAmt.Enabled = b;
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
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_1_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Rm_Loan_page.SelectedIndex = 1;
            RPV_RPTReschedule.Selected = true;           
            //rd_LOANTRANS.SelectedIndex = 1;
            //rd_LOANTRANS.Tabs[2].Enabled = false;
            //rd_LOANTRANS.Tabs[1].Enabled = true;
            SMHR_LOANTRANS _obj_smhr_LoanTrans = new SMHR_LOANTRANS();
            Loaddropdowns();

            _obj_smhr_LoanTrans.LOANTRANS_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));


            DataTable dt = BLL.get_EmpRedBalLoanTran(_obj_smhr_LoanTrans);

            EnabledFields(false);

            // Getting Employee Name


            _obj_smhr_LoanTrans.BUSINESSUNIT_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            _obj_smhr_LoanTrans.LOANTRANS_EMP_ID = Convert.ToInt32(Convert.ToString(dt.Rows[0]["LOANTRANS_EMP_ID"]));
            _obj_smhr_LoanTrans.OPERATION = operation.Empty;
            DataTable dtemp = BLL.get_EmpRedBalLoanTran(_obj_smhr_LoanTrans);
            rcmb_Employee.DataSource = dtemp;
            //lbl_Curr.Text = Convert.ToString(dtemp.Rows[0]["CURRENCY"]);
            rcmb_Employee.DataTextField = "EMPNAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));
            rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_EMP_ID"]));

            rtxt_loanno.Text = Convert.ToString(dt.Rows[0]["LOANTRANS_LOANNO"]);
            rtxt_Amount.Value = Convert.ToInt32(dt.Rows[0]["LOANTRANS_LOANAMOUNT"]);
            rcmb_loantype.SelectedIndex = rcmb_loantype.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOANTRANS_LOANTYPE_ID"]));
            rdtp_IssueDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_ISSUEDATE"]);
            rtxt_installments.Value = Convert.ToInt32(dt.Rows[0]["LOANTRANS_LOANINSTALL"]);
            rtxt_InterestAmt.Value = Convert.ToInt32(dt.Rows[0]["LOANTRANS_INTERESTRATE"]);
            rtxt_purpose.Text = Convert.ToString(dt.Rows[0]["LOANTRAN_LOANPURPOSE"]);
            rdtp_EffectiveDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LOANTRANS_EFFDATE"]);

            SMHR_LOANTRANSDTL _obj_smhr_loantrandtl = new SMHR_LOANTRANSDTL();
            _obj_smhr_loantrandtl.LOANTRADTL_LOANTRAN_ID = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            DataTable dt_repay = BLL.get_EmpLoanTranDetail(_obj_smhr_loantrandtl);
            ViewState["rescdata"] = dt_repay;
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
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
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

            _obj_smhr_loantrans.LOANTRANS_ID = Convert.ToInt32(rg_loantrandetails.Items[0]["LOANTRADTL_LOANTRAN_ID"].Text);
            DataTable dt2 = BLL.get_EmpRedBalLoanTran(_obj_smhr_loantrans);
            _obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(dt2.Rows[0]["LOANTRANS_EMP_ID"]);
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
                    BLL.ShowMessage(this, "Loan Re-Schedule Processed Successfully");
                    rg_loantrandetails.DataBind();
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadPaymentType()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_businessunit.OPERATION = operation.Empty;
            _obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_BusinessUnit(_obj_smhr_businessunit);
            ddl_PayMode.DataSource = dt;
            ddl_PayMode.DataTextField = "HR_MASTER_CODE";
            ddl_PayMode.DataValueField = "HR_MASTER_ID";
            ddl_PayMode.DataBind();
            ddl_PayMode.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
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

                    rtxt_Amount.Value = Convert.ToInt32(dt.Rows[0]["Amount"]);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
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
                getLoanNo();
            SMHR_LOANTRANS _obj_smhr_loantrans = new SMHR_LOANTRANS();
            _obj_smhr_loantrans.LOANTRANS_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
            _obj_smhr_loantrans.LOANTRANS_LOANNO = Convert.ToString(rtxt_loanno.Text);
            _obj_smhr_loantrans.LOANTRANS_LOANTYPE_ID = Convert.ToInt32(rcmb_loantype.SelectedItem.Value);
            _obj_smhr_loantrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //if (lbl_LoanDetEmpDOJ.Text != string.Empty)
            //{

            //    if (rdtp_IssueDate.SelectedDate < Convert.ToDateTime(lbl_LoanDetEmpDOJ.Text))
            //    {
            //        BLL.ShowMessage(this, "Loan Issue Date cannot be ahead of Employee Joining Date");
            //        return;
            //    }
            //}
            //else 
            if (rdtp_IssueDate.SelectedDate > System.DateTime.Now)
            {
                BLL.ShowMessage(this, "Loan Issue Date cannot be ahead of Todays Date");
                return;
            }
            else
            {
                _obj_smhr_loantrans.LOANTRANS_ISSUEDATE = Convert.ToDateTime(rdtp_IssueDate.SelectedDate);
            }
            _obj_smhr_loantrans.LOANTRANS_LOANAMOUNT = Convert.ToInt32(rtxt_Amount.Value);
            _obj_smhr_loantrans.LOANTRANS_LOANINSTALL = Convert.ToInt32(rtxt_installments.Value);
            _obj_smhr_loantrans.LOANTRANS_INTERESTAMT = Convert.ToDouble(rtxt_InterestAmt.Value);
            _obj_smhr_loantrans.LOANTRAN_LOANPURPOSE = Convert.ToString(rtxt_purpose.Text);
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
            _obj_smhr_loantrans.LOANTRAN_TYPE = true;
            _obj_smhr_loantrans.LOANTRAN_STATUS = 1;
            _obj_smhr_loantrans.LOANTRANS_ID = Convert.ToInt32(lbl_loantrans_ID.Text);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpReducingLoanTran", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    
}