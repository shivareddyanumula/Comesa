using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMHR;
using System.Text;
using Telerik.Web.UI;
public partial class Masters_LoanRequest : System.Web.UI.Page
{
    string Control;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            RWOrgDetails.VisibleOnPageLoad = false;
            RW_VoucherDtls.VisibleOnPageLoad = false;
            Control = Convert.ToString(Request.QueryString["Control"]);

            if (!IsPostBack)
            {


                //if (Convert.ToString(Request.QueryString["lnkType"]) == "DBLink")
                //{
                //    LoadData();

                //}
                //else
                //{
                //    Response.Redirect("~/Security/frm_Dashboard.aspx?ctrl=SS", false);
                //    return;
                //}
                //if (Convert.ToInt32(Session["EMP_ID"]) == 0)
                //    Response.Redirect("~/Security/frm_Dashboard.aspx?ctrl=SS", false);
                //else
                //{ 
                //    //LoadGrid();
                //    LoadData();
                //    rg_loandetails.DataBind();
                //}
                //if (Convert.ToString(Request.QueryString["Control"]) != null)
                //{
                //if (Convert.ToString(Request.QueryString["Control"]) == "SELFSERVICE")
                //{
                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                if (Control != null)
                {
                    if (Control.ToUpper() == "SELFLOANREQUEST")
                    {
                        if (Convert.ToString(Request.QueryString["lnkType"]) == "DBLink")
                            _obj_Smhr_LoginInfo.LOGIN_ID = 12;
                        else
                            _obj_Smhr_LoginInfo.LOGIN_ID = 20;
                        //_obj_Smhr_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("LOAN REQUEST EMP");
                    }
                }
                else
                {
                    if ((Convert.ToInt32(Session["EMP_ID"]) == 0) || string.IsNullOrEmpty(Convert.ToString(Request.QueryString["lnkType"])) == true)
                    {
                        _obj_Smhr_LoginInfo.LOGIN_ID = 20;
                        //_obj_Smhr_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("LOAN REQUEST");
                    }
                    else
                    {
                        _obj_Smhr_LoginInfo.LOGIN_ID = 2;
                        _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("LOAN REQUEST EMP");
                    }
                }

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("LOAN REQUEST");
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
                    rg_loandetails.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    //btn_Cancel.Visible = false;
                }
                else if (Convert.ToInt32(Session["WRITEFACILITY"]) == 3)
                {
                    if (Convert.ToString(Request.QueryString["lnkType"]) == "DBLink")
                    {

                        Response.Redirect("~/Security/frm_Dashboard.aspx?ctrl=SS", false);
                        return;
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
                }
                txt_ApprovedDate.MaxDate = DateTime.Now;
                trParentLoan.Visible = false;
                trCreateVoucher.Visible = false;    //To hide "CreateVoucher" link
                // modalPopup.OpenerElementID = rbShowDialog.ClientID;

                trRateOfInterest.Visible = false;
                Control = Convert.ToString(Request.QueryString["Control"]);

                //if (Convert.ToString(Request.QueryString["Control"]) == "SELFLOANREQUEST")
                // {
                ///  LoadData();
                //}

                LoadData();
                LoadBusinessUint();
                //LoadLoanType();
                LoadTermsAndCond();
                //LoadEmployee();
                //txt_StartDate.MinDate = DateTime.Now;
                //txt_StartDate.Enabled = false;
                //}
                // }

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    private void LoadTermsAndCond()
    {
        try
        {
            SMHR_LOAN_TERMS _obj_SMHR_TC = new SMHR_LOAN_TERMS();
            _obj_SMHR_TC.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_TC.OPERATION = operation.Select;
            DataTable dt = BLL.get_LoanTerms(_obj_SMHR_TC);
            if (dt.Rows.Count > 0)
            {
                rtxtTermsAndCond.Text = dt.Rows[0]["LOAN_TC"].ToString();
                btn_Save.Visible = false;
                btn_Update.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void LoadGrid()
    {
        try
        {
            //if (Convert.ToInt32(Session["EMP_ID"]) == 0)
            //{
            //    SMHR_LOANREQUEST _obj_Smhr_Loanrequest = new SMHR_LOANREQUEST();
            //    _obj_Smhr_Loanrequest.ORGANISATION_ID =Convert.ToInt32( Session["ORG_ID"]);
            //    _obj_Smhr_Loanrequest.lOANREQUEST_EMPLOYEEID = Convert.ToInt32(Session["EMP_ID"]);
            //    _obj_Smhr_Loanrequest.mode = 0;
            //    rg_loandetails.DataSource = BLL.get_LoanRequest(_obj_Smhr_Loanrequest);


            //}
            if (string.Compare(rb_loanprocesstype.SelectedItem.Value, "1", true) == 0)
            {
                btnEMISave.Visible = true;
                DataTable table;
                if (Session["GenerateEMI"] == null && string.IsNullOrEmpty(HF_ID.Value))
                {
                    int i = 1;
                    double defaultEMI, noOFInstall, totalAmount, currBalanceamount, currLoanAmount;
                    table = GetGenrateEMIDT();
                    noOFInstall = Convert.ToInt32(rtxt_NOI.Text);
                    totalAmount = Convert.ToDouble(txt_Amount.Text);
                    defaultEMI = Math.Round((totalAmount / noOFInstall), 2);
                    //DataRow row;
                    DateTime approvedDate = (DateTime)txt_ApprovedDate.SelectedDate;
                    currBalanceamount = totalAmount;
                    currLoanAmount = totalAmount;
                    while (i <= noOFInstall)
                    {
                        currBalanceamount = currBalanceamount - defaultEMI;
                        table.Rows.Add(i, approvedDate, currBalanceamount, currLoanAmount, approvedDate.ToString("yyyy"), approvedDate.ToString("MMM"), defaultEMI, totalAmount, 0);
                        currLoanAmount = currLoanAmount - defaultEMI;
                        approvedDate = approvedDate.AddMonths(1);
                        i++;
                    }
                    Session["GenerateEMI"] = table;
                }
                else if (!string.IsNullOrEmpty(HF_ID.Value))
                {

                    SMHR_LOANREQUEST _obj_Smhr_Loanrequest = new SMHR_LOANREQUEST();
                    _obj_Smhr_Loanrequest.OPERATION = operation.USERLOANEMI;
                    _obj_Smhr_Loanrequest.SMHR_LOANREQUEST_ID = Convert.ToInt32(HF_ID.Value);
                    //  _obj_Smhr_Loanrequest.MODE = 0;
                    table = BLL.get_LoanRequest(_obj_Smhr_Loanrequest);

                    Session["GenerateEMI"] = table;

                }
                else
                {
                    table = (DataTable)Session["GenerateEMI"];
                }
                RG_GenarateEMI.DataSource = table;
                RG_GenarateEMI.DataBind();
                if (table.Rows.Count > 0)
                {
                    lblEMI.Text = Convert.ToString(Math.Round(Convert.ToDouble(table.Rows[0]["USERLOANEMI_EMIAMOUNT"]), 0));
                }
                RG_EMI.Visible = false;
                RG_GenarateEMI.Visible = true;
                rbShowDialog.Visible = true;
                txt_StartDate.Enabled = false;
                txt_ApprovedDate.Enabled = false;
                rb_loanprocesstype.Enabled = false;
            }
            else if (string.Compare(rb_loanprocesstype.SelectedItem.Value, "2", true) == 0)
            {

            }
            else
            {
                btnEMISave.Visible = false;
                RG_EMI.Visible = true;
                RG_GenarateEMI.Visible = false;
                SMHR_LOANSETUP oSMHR_LOANSETUP = new SMHR_LOANSETUP();
                oSMHR_LOANSETUP.LOANSETUP_MINTENUREMONTHS = Convert.ToInt32(rtxt_NOI.Text);
                oSMHR_LOANSETUP.LOANSETUP_LOANINTEREST = Convert.ToDecimal(lblRateofInterest.Text);
                oSMHR_LOANSETUP.Amount = Convert.ToDecimal(txt_Amount.Text);
                oSMHR_LOANSETUP.OPERATION = operation.Get;
                DataTable dt = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                RG_EMI.DataSource = dt;
                RG_EMI.DataBind();
                lblEMI.Text = Convert.ToString(dt.Rows[1]["EMI"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private string getLoanNo()
    {
        string loanNumber = string.Empty;
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
                    loanNumber = dt.Rows[0]["GLOBALCONFIG_LOAN_NO"].ToString().Trim() + Convert.ToString(Series) + Convert.ToString(str);
                }
            }
            return loanNumber;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "loanrequest", ex.StackTrace, DateTime.Now);
            //Response.Redirect("~/Frm_ErrorPage.aspx");
            return loanNumber;
        }
    }
    private static DataTable GetGenrateEMIDT()
    {
        DataTable table = new DataTable();  // New data table.
        try
        {
           

            table.Columns.Add("USERLOANEMI_CURR_EMINO", typeof(int));
            table.Columns.Add("USERLOANEMI_EMIPAYMENTDUEDATE", typeof(DateTime));
            table.Columns.Add("USERLOANEMI_CURRENTBALANCEAMOUNT", typeof(double));
            table.Columns.Add("USERLOANEMI_CURRENTLOANAMOUNT", typeof(double));
            table.Columns.Add("USERLOANEMI_YEAR", typeof(string));
            table.Columns.Add("USERLOANEMI_MONTH", typeof(string));
            table.Columns.Add("USERLOANEMI_EMIAMOUNT", typeof(double));
            table.Columns.Add("USERLOANEMI_PRINCIPLEAMT", typeof(double));
            table.Columns.Add("USERLOANEMI_EMI_STATUS", typeof(int));

            return table;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "loanrequest", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
            return table;
        }
    }
    protected void btnEMISave_Click(object sender, EventArgs e)
    {
        try
        {
            RadNumericTextBox tAmount = new RadNumericTextBox();

            double sno = 0;
            double noOFInstall, totalAmount = 0, currBalanceamount = 0, currLoanAmount = 0, maxEMIAmount;
            DataTable dt = GetGenrateEMIDT();
            //noOFInstall = Convert.ToInt32(rtxt_NOI.Text);
            //totalAmount = Convert.ToDouble(txt_Amount.Text);
            DateTime approvedDate = (DateTime)txt_ApprovedDate.SelectedDate;
            //currBalanceamount = totalAmount;
            //currLoanAmount = totalAmount;
            maxEMIAmount = Convert.ToDouble(lblEMI.Text);
            foreach (GridDataItem d in RG_GenarateEMI.Items)
            {
                tAmount = new RadNumericTextBox();
                tAmount = d.FindControl("txt_EMI") as RadNumericTextBox;
                currLoanAmount = currLoanAmount + Convert.ToDouble(tAmount.Text);
                //sno += Convert.ToDouble(tAmount.Text);

                dt.Rows.Add(Convert.ToInt32(d.Cells[2].Text), approvedDate, currBalanceamount, currLoanAmount, d.Cells[3].Text, d.Cells[4].Text, Convert.ToDouble(tAmount.Text), Convert.ToDouble(tAmount.Text), !tAmount.Enabled);
                currBalanceamount = currBalanceamount + Convert.ToDouble(tAmount.Text);
                approvedDate = approvedDate.AddMonths(1);
                //totalAmount = currLoanAmount;
                if (Convert.ToDouble(tAmount.Text) > maxEMIAmount)
                {
                    maxEMIAmount = Convert.ToDouble(tAmount.Text);
                }
            }
            //if (Convert.ToDouble(txt_Amount.Text) != Math.Round(sno,0))
            //{
            //    BLL.ShowMessage(this, "EMI Amount not matched with Loan Amount");
            //    return;
            //}
            //else
            //{
            //    lblEMI.Text = Convert.ToString(Math.Round(maxEMIAmount, 0));
            //    Session["GenerateEMI"] = dt;
            //}
            if (currLoanAmount > 0)
            {
                txt_Amount.Text = currLoanAmount.ToString();
                lblEMI.Text = Convert.ToString(Math.Round(maxEMIAmount, 2));
                Session["GenerateEMI"] = dt;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rbShowDialog_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.Compare(rb_loanprocesstype.SelectedItem.Value, "0", true) == 0)
            {
                if (hdnMinTenureMonths.Value != null && Convert.ToInt32(hdnMinTenureMonths.Value) > Convert.ToInt32(rtxt_NOI.Text))
                {
                    BLL.ShowMessage(this, "Minimum " + hdnMinTenureMonths.Value + " months required for this loan");
                    return;
                }
                if (hdnMaxTenureMonths.Value != null && Convert.ToInt32(hdnMaxTenureMonths.Value) < Convert.ToInt32(rtxt_NOI.Text))
                {
                    BLL.ShowMessage(this, "Maximum " + hdnMaxTenureMonths.Value + " months required for this loan");
                    return;
                }
                //if (hdnMaxeligibleMonthsforEmp.Value != null && !string.IsNullOrEmpty(hdnMaxeligibleMonthsforEmp.Value) && Convert.ToInt32(hdnMaxeligibleMonthsforEmp.Value) < Convert.ToInt32(rtxt_NOI.Text))
                //{
                //    BLL.ShowMessage(this, "Contract will expire in " + hdnMaxeligibleMonthsforEmp.Value + " months");
                //    return;
                //}
                if (Convert.ToDouble(lblLoanEligibleAmount.Text) < Convert.ToDouble(txt_Amount.Text))
                {
                    BLL.ShowMessage(this, "Loan amount should be less than or equal to max eligible");
                    return;
                }
                btnEMISave.Visible = true;
                LoadGrid();
            }
            else if (string.Compare(rb_loanprocesstype.SelectedItem.Value, "1", true) == 0)
            {

                btnEMISave.Visible = true;
                DataTable table;

                if (Session["GenerateEMI"] == null && string.IsNullOrEmpty(HF_ID.Value))
                {
                    int i = 1;
                    double defaultEMI, noOFInstall, totalAmount, currBalanceamount, currLoanAmount;
                    table = GetGenrateEMIDT();
                    noOFInstall = Convert.ToInt32(rtxt_NOI.Text);
                    totalAmount = 0;//Convert.ToDouble(txt_Amount.Text);
                    defaultEMI = 0;//Math.Round((totalAmount / noOFInstall), 2);
                    //DataRow row;
                    DateTime approvedDate = (DateTime)txt_ApprovedDate.SelectedDate;
                    currBalanceamount = totalAmount;
                    currLoanAmount = totalAmount;
                    while (i <= noOFInstall)
                    {
                        currBalanceamount = currBalanceamount - defaultEMI;
                        table.Rows.Add(i, approvedDate, currBalanceamount, currLoanAmount, approvedDate.ToString("yyyy"), approvedDate.ToString("MMM"), defaultEMI, totalAmount, 0);
                        currLoanAmount = currLoanAmount - defaultEMI;
                        approvedDate = approvedDate.AddMonths(1);
                        i++;
                    }
                    Session["GenerateEMI"] = table;
                }
                else if (!string.IsNullOrEmpty(HF_ID.Value))
                {
                    if (Session["GenerateEMI"] == null)
                    {
                        SMHR_LOANREQUEST _obj_Smhr_Loanrequest = new SMHR_LOANREQUEST();
                        _obj_Smhr_Loanrequest.OPERATION = operation.USERLOANEMI;
                        _obj_Smhr_Loanrequest.SMHR_LOANREQUEST_ID = Convert.ToInt32(HF_ID.Value);
                        table = BLL.get_LoanRequest(_obj_Smhr_Loanrequest);
                    }
                    else
                        table = (DataTable)Session["GenerateEMI"];
                    double currLoanAmount = 0, currBalanceamount = 0;
                    DataRow dr = table.Rows[table.Rows.Count - 1];
                    int newEMICount = Convert.ToInt32(rtxt_NOI.Text);   //To hold new EMI's count
                    int oldEMICount = Convert.ToInt32(table.Rows.Count); //To hold old EMI's count

                    if (newEMICount > oldEMICount)
                    {
                        currLoanAmount = Convert.ToDouble(dr["USERLOANEMI_CURRENTLOANAMOUNT"]);
                        currBalanceamount = Convert.ToDouble(dr["USERLOANEMI_CURRENTBALANCEAMOUNT"]);
                        DateTime approvedDate = (DateTime)(dr["USERLOANEMI_EMIPAYMENTDUEDATE"]);
                        approvedDate = approvedDate.AddMonths(1);
                        for (int i = oldEMICount; i < newEMICount; i++)
                        {
                            table.Rows.Add(i + 1, approvedDate, currBalanceamount, currLoanAmount, approvedDate.ToString("yyyy"), approvedDate.ToString("MMM"), 0, 0, 0);
                            approvedDate = approvedDate.AddMonths(1);
                        }
                    }
                    else if (newEMICount < oldEMICount)
                    {
                        rtxt_NOI.Text = oldEMICount.ToString();
                        BLL.ShowMessage(this, "Tenure months cannot be decrease");
                        return;
                    }
                    Session["GenerateEMI"] = table;
                }
                else
                {
                    //To calculate accordingly if user changes the EMI months/ EMI amounts

                    table = (DataTable)Session["GenerateEMI"]; //To store old data into table

                    double currLoanAmount = 0, currBalanceamount = 0;
                    DataRow dr = table.Rows[table.Rows.Count - 1];
                    int newEMICount = Convert.ToInt32(rtxt_NOI.Text);   //To hold new EMI's count
                    int oldEMICount = Convert.ToInt32(table.Rows.Count); //To hold old EMI's count

                    if (newEMICount > oldEMICount)
                    {
                        currLoanAmount = Convert.ToDouble(dr["USERLOANEMI_CURRENTLOANAMOUNT"]);
                        currBalanceamount = Convert.ToDouble(dr["USERLOANEMI_CURRENTBALANCEAMOUNT"]);
                        DateTime approvedDate = (DateTime)(dr["USERLOANEMI_EMIPAYMENTDUEDATE"]);
                        approvedDate = approvedDate.AddMonths(1);
                        for (int i = oldEMICount; i < newEMICount; i++)
                        {
                            table.Rows.Add(i, approvedDate, currBalanceamount, currLoanAmount, approvedDate.ToString("yyyy"), approvedDate.ToString("MMM"), 0, 0, 0);
                            approvedDate = approvedDate.AddMonths(1);
                        }
                    }
                    else if (newEMICount < oldEMICount)
                    {
                        int i = 1;
                        double defaultEMI, noOFInstall, totalAmount;
                        currBalanceamount = 0; currLoanAmount = 0;
                        table = GetGenrateEMIDT();
                        noOFInstall = Convert.ToInt32(rtxt_NOI.Text);
                        totalAmount = 0;//Convert.ToDouble(txt_Amount.Text);
                        defaultEMI = 0;//Math.Round((totalAmount / noOFInstall), 2);
                        //DataRow row;
                        DateTime approvedDate = (DateTime)txt_ApprovedDate.SelectedDate;
                        currBalanceamount = totalAmount;
                        currLoanAmount = totalAmount;
                        while (i <= noOFInstall)
                        {
                            table.Rows.Add(i, approvedDate, currBalanceamount, currLoanAmount, approvedDate.ToString("yyyy"), approvedDate.ToString("MMM"), defaultEMI, totalAmount, 0);
                            approvedDate = approvedDate.AddMonths(1);
                            i++;
                        }
                        Session["GenerateEMI"] = table;
                        txt_Amount.Text = "0";
                        //BLL.ShowMessage(this.Page, "Tenure months cannot be decrease");
                        //return;
                    }

                    Session["GenerateEMI"] = table;
                }
                RG_GenarateEMI.DataSource = table;
                RG_GenarateEMI.DataBind();
                lblEMI.Text = Convert.ToString(Math.Round(Convert.ToDouble(table.Rows[0]["USERLOANEMI_EMIAMOUNT"]), 0));
                RG_EMI.Visible = false;
                RG_GenarateEMI.Visible = true;
                btnEMISave.Visible = true;
            }
            else if ((string.Compare(rb_loanprocesstype.SelectedItem.Value, "2", true) == 0) && lblRateofInterest.Text != string.Empty)    //for Standard Loan
            {

                int i = 0;
                double defaultEMI, noOFInstall, totalAmount, interestAmount;
                DataTable dtStdLn = new DataTable();

                dtStdLn.Columns.Add("STDLOAN_SLNO", typeof(int));
                dtStdLn.Columns.Add("STDLOAN_EIR", typeof(double));
                dtStdLn.Columns.Add("STDLOAN_EMD", typeof(string));
                dtStdLn.Columns.Add("STDLOAN_EMI", typeof(double));
                dtStdLn.Columns.Add("STDLOAN_ROI", typeof(double));
                dtStdLn.Columns.Add("STDLOAN_BAL", typeof(double));

                totalAmount = Convert.ToDouble(txt_Amount.Text);
                noOFInstall = Convert.ToDouble(rtxt_NOI.Text);
                interestAmount = 0;
                defaultEMI = 0;

                DateTime approvedDate = (DateTime)txt_ApprovedDate.SelectedDate;

                defaultEMI = Math.Round((totalAmount / noOFInstall), 2);
                interestAmount = Math.Round(((defaultEMI * (Convert.ToDouble(lblRateofInterest.Text))) / 100), 2);

                while (i <= noOFInstall)
                {
                    if (i == 0)
                        dtStdLn.Rows.Add(i, null, null, null, null, totalAmount);
                    else
                    {
                        DateTime date;
                        if (i == 1)
                        {
                            if (Convert.ToInt32(Convert.ToDateTime(txt_StartDate.SelectedDate).Day) < 25)
                                date = Convert.ToDateTime(txt_StartDate.SelectedDate);
                            else
                                date = Convert.ToDateTime(txt_StartDate.SelectedDate).AddMonths(i);
                        }
                        else
                        {
                            if (Convert.ToInt32(Convert.ToDateTime(txt_StartDate.SelectedDate).Day) < 25)
                                date = Convert.ToDateTime(txt_StartDate.SelectedDate).AddMonths(i - 1);
                            else
                                date = Convert.ToDateTime(txt_StartDate.SelectedDate).AddMonths(i);
                        }
                        //DateTime date = Convert.ToDateTime(txt_StartDate.SelectedDate).AddMonths(i);
                        var firstDayOfEveryMonth = new DateTime(date.Year, date.Month, 25);

                        if (i == noOFInstall)
                            dtStdLn.Rows.Add(i, lblRateofInterest.Text, firstDayOfEveryMonth.ToString("dd/MM/yyyy"), defaultEMI, interestAmount, 0);
                        else if ((i + 1) == noOFInstall)
                            dtStdLn.Rows.Add(i, lblRateofInterest.Text, firstDayOfEveryMonth.ToString("dd/MM/yyyy"), defaultEMI, interestAmount, defaultEMI);
                        else
                            dtStdLn.Rows.Add(i, lblRateofInterest.Text, firstDayOfEveryMonth.ToString("dd/MM/yyyy"), defaultEMI, interestAmount, totalAmount);
                    }
                    totalAmount = Math.Round((totalAmount - defaultEMI), 2);
                    i++;
                }

                Session["stdLoanEMI"] = dtStdLn;

                rgStdLoan.DataSource = dtStdLn;
                rgStdLoan.DataBind();
                rgStdLoan.Visible = true;

                RG_GenarateEMI.Visible = RG_EMI.Visible = false;
                lblEMI.Text = Convert.ToString(Math.Round((Convert.ToDouble(txt_Amount.Text) / Convert.ToDouble(rtxt_NOI.Text)), 2));
                btnEMISave.Visible = false;
            }

            RWOrgDetails.Height = 400;
            RWOrgDetails.Width = 600;
            RWOrgDetails.Visible = true;
            RWOrgDetails.VisibleOnPageLoad = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {

            //TO VALIDATE LOAN REQUEST BASED ON NET PAY
          
            SMHR_LOANREQUEST _obj_Smhr_Loanrequest = new SMHR_LOANREQUEST();
           _obj_Smhr_Loanrequest.LOANREQUEST_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
           _obj_Smhr_Loanrequest.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
          _obj_Smhr_Loanrequest.lOANREQUEST_EMPLOYEEID = Convert.ToInt32(rcmb_EmployeeName.SelectedValue);
          _obj_Smhr_Loanrequest.AMOUNT = Convert.ToDouble(txt_Amount.Text);
          _obj_Smhr_Loanrequest.NOOFINSTALLMENTS = Convert.ToDouble(rtxt_NOI.Text);
          _obj_Smhr_Loanrequest.APPLIEDDATE = Convert.ToDateTime(txt_StartDate.SelectedDate);
          _obj_Smhr_Loanrequest.LOANTYPE = Convert.ToInt32(rcmb_LoanType.SelectedValue);
          _obj_Smhr_Loanrequest.OPERATION = operation.loaneligibility;
          DataTable dt = BLL.get_LoanRequest(_obj_Smhr_Loanrequest);
         
          if (dt.Rows[0]["Result"]!="")
          {
              BLL.ShowMessage(this, "Please contact Administration, as you are not eligible to apply for Loan..!");
             return;
          }

            //To validate loan applied date with Employee DOJ

            SMHR_EMPLOYEE objEmployee = new SMHR_EMPLOYEE();
            objEmployee.EMP_ID = Convert.ToInt32(rcmb_EmployeeName.SelectedValue);
            objEmployee.OPERATION = operation.details;
            DataTable dtEmpDOJ = BLL.get_Employeedetail(objEmployee);

            if (dtEmpDOJ.Rows.Count > 0)
            {
                if (Convert.ToDateTime(dtEmpDOJ.Rows[0]["EMP_DOJ"]) > Convert.ToDateTime(txt_StartDate.SelectedDate))
                {
                    BLL.ShowMessage(this, "Applied Date cannot be earlier than Employee DOJ");
                    return;
                }
            }


            SMHR_LOANREQUEST _obj_Smhr_Loan = new SMHR_LOANREQUEST();
            if (string.Compare(rbtnAgree.SelectedValue, "0", true) != 0)
            {
                BLL.ShowMessage(this, "Please Check I Agree for Terms and Conditions");
                return;
            }
            if (string.Compare(rb_loanprocesstype.SelectedItem.Value, "0", true) == 0)
            {
                if (hdnMinTenureMonths.Value != null && Convert.ToInt32(hdnMinTenureMonths.Value) > Convert.ToInt32(rtxt_NOI.Text))
                {
                    BLL.ShowMessage(this, "Minimum " + hdnMinTenureMonths.Value + " months required for this loan");
                    return;
                }
                if (hdnMaxTenureMonths.Value != null && Convert.ToInt32(hdnMaxTenureMonths.Value) < Convert.ToInt32(rtxt_NOI.Text))
                {
                    BLL.ShowMessage(this, "Maximum " + hdnMaxTenureMonths.Value + " months required for this loan");
                    return;
                }
                //if (hdnMaxeligibleMonthsforEmp.Value != null && !string.IsNullOrEmpty(hdnMaxeligibleMonthsforEmp.Value) && Convert.ToInt32(hdnMaxeligibleMonthsforEmp.Value) < Convert.ToInt32(rtxt_NOI.Text))
                //{
                //    BLL.ShowMessage(this, "Maximum tenure months is less than your contract expiry date");//,contrat will expire in " + hdnMaxeligibleMonthsforEmp.Value + " months");
                //    return;
                //}
                if (lblLoanEligibleAmount.Text != string.Empty)
                {
                    if (Convert.ToDouble(lblLoanEligibleAmount.Text) < Convert.ToDouble(txt_Amount.Text))
                    {
                        BLL.ShowMessage(this, "Loan amount should be less than or equal to max eligible");
                        return;
                    }
                }
                //if (string.Compare(rcmb_LoanType.SelectedItem.Text, "Salary Advance", true) == 0 || string.Compare(rcmb_LoanType.SelectedItem.Text, "Salary in Advance", true) == 0)
                //{
                //    if (Session["VoucherData"] == null)
                //    {
                //        BLL.ShowMessage(this, "Please Fill Voucher");
                //        return;
                //    }
                //    else
                //    {
                //        _obj_Smhr_Loan.LOANVOUCHER = (DataTable)Session["VoucherData"];
                //    }
                //}
            }
            else if (string.Compare(rb_loanprocesstype.SelectedItem.Value, "1", true) == 0)
            {

                if (Session["GenerateEMI"] != null)
                {
                    DataTable dtnew = (DataTable)Session["GenerateEMI"];
                    if (Convert.ToInt32(rtxt_NOI.Text) == dtnew.Rows.Count)
                    {
                        _obj_Smhr_Loan.USERLOANEMI = dtnew;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Please click on Calculate EMI,as tenure months modified");
                        return;
                    }

                }
                else
                {
                    BLL.ShowMessage(this, "Please Click on Calculate EMI");
                    return;
                }
            }
            //if(Session["EMP_ID"]!=null)

            //{
            //    BLL.ShowMessage(this,"Please enter email id in employee details screen");
            //    return;
            //}

            SMHR_Module_MailID _obj_smhr_Module_MailID = new SMHR_Module_MailID();
            _obj_smhr_Module_MailID.OPERATION = operation.Get;
            _obj_smhr_Module_MailID.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DTemailconfig = BLL.get_MailID(_obj_smhr_Module_MailID);

            if (Convert.ToInt32(DTemailconfig.Rows[0]["Result"]) > 0)
            {
                BLL.ShowMessage(this, "Please configure all email ids in Email Configure screen");
                return;
            }



            //if (string.Compare(rcmb_LoanType.SelectedItem.Text, "Bucoso-Deposits", true) == 0
            //    || string.Compare(rcmb_LoanType.SelectedItem.Text, "Bucoso-Accrued Interest", true) == 0
            //    || string.Compare(rcmb_LoanType.SelectedItem.Text, "Bucoso-Sinking Fund", true) == 0
            //    || string.Compare(rcmb_LoanType.SelectedItem.Text, "Bucoso-Entrance Fee", true) == 0)
            //{
            //    if (Session["GenerateEMI"] != null)
            //    {
            //        _obj_Smhr_Loan.USERLOANEMI = (DataTable)Session["GenerateEMI"];
            //    }
            //}
            SMHR_LOANSETUP oSMHR_LOANSETUP = new SMHR_LOANSETUP();
            oSMHR_LOANSETUP.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            oSMHR_LOANSETUP.LOGIN_ID = Convert.ToInt32(rcmb_EmployeeName.SelectedValue);
            oSMHR_LOANSETUP.LOANSETUP_LOANTYPE_ID = Convert.ToInt32(rcmb_LoanType.SelectedValue);
            //oSMHR_LOANSETUP.OPERATION = operation.Select1;
            //DataTable dtPendingEMis = BLL.get_LoanSetup(oSMHR_LOANSETUP);
            //if (Convert.ToBoolean(dtPendingEMis.Rows[0]["PendingEMIs"]))
            //{
            //    BLL.ShowMessage(this, "already you have this loan");
            //    return;
            //}
            if (string.IsNullOrEmpty(lblEMI.Text))
            {
                BLL.ShowMessage(this, "Please Click on Calculate EMI");
                return;
            }
            oSMHR_LOANSETUP.Amount = Convert.ToDecimal(lblEMI.Text);
            oSMHR_LOANSETUP.EffectiveDate = (DateTime)txt_StartDate.SelectedDate;

            ////To validate 1/3 rd rule on basic salary
            //oSMHR_LOANSETUP.OPERATION = operation.Validate;
            //DataTable dt = BLL.get_LoanSetup(oSMHR_LOANSETUP);
            //if (dt.Rows.Count > 0)
            //{
            //    if (!Convert.ToBoolean(dt.Rows[0]["FINAL"]))
            //    {
            //        BLL.ShowMessage(this, Convert.ToString(dt.Rows[0]["ErrorMessage"]));
            //        return;
            //    }
            //}            
            _obj_Smhr_Loan.OPERATION = operation.Get_ID;
            _obj_Smhr_Loan.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Loan.status_type = "Applied";
            DataTable dt_id = BLL.get_EmployeeStatus1(_obj_Smhr_Loan);
            _obj_Smhr_Loan.OPERATION = operation.Insert;
            _obj_Smhr_Loan.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            _obj_Smhr_Loan.APPLIEDDATE = Convert.ToDateTime(txt_StartDate.SelectedDate);
            _obj_Smhr_Loan.APPLIEDBY = Convert.ToInt32(Session["EMP_ID"]);
            if (Convert.ToInt32(rtxt_NOI.Value) == 0)
            {
                BLL.ShowMessage(this, "No. of Instalments should be greater than 0");
                return;
            }
            //  rtxt_NOI.Value = Math.Round(Convert.ToDouble(rtxt_NOI.Value));
            _obj_Smhr_Loan.NOOFINSTALLMENTS = Convert.ToDouble(rtxt_NOI.Text);
            _obj_Smhr_Loan.LOANREQUEST_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Loan.LOANTYPE = Convert.ToInt32(rcmb_LoanType.SelectedItem.Value);
            _obj_Smhr_Loan.lOANREQUEST_EMPLOYEEID = Convert.ToInt32(rcmb_EmployeeName.SelectedItem.Value);
            _obj_Smhr_Loan.LOAN_PROCESS_TYPE = rb_loanprocesstype.SelectedItem.Text;   //Convert.ToInt32(rb_loanprocesstype.SelectedItem.Value);
            if (dt_id.Rows.Count > 0)
            {
                _obj_Smhr_Loan.STATUS = Convert.ToInt32(dt_id.Rows[0]["HR_MASTER_ID"]);
            }
            _obj_Smhr_Loan.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_Loan.CREATEDDATE = DateTime.Now;
            if (Convert.ToDouble(txt_Amount.Value) == 0)
            {
                BLL.ShowMessage(this, "Loan Amount should be greater than 0");
                return;
            }
            _obj_Smhr_Loan.AMOUNT = Convert.ToDouble(txt_Amount.Value);
            _obj_Smhr_Loan.MODIFIEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_Loan.MODIFIEDDATE = DateTime.Now;
            if (string.Compare(rcmb_LoanType.SelectedItem.Text, "Salary Advance", true) != 0 && string.Compare(rcmb_LoanType.SelectedItem.Text, "Salary in Advance", true) != 0)
            {
                if (FBrowse.HasFile)
                {
                    string pdfName = Convert.ToInt32(Session["USER_ID"]).ToString() + "_" + Guid.NewGuid().ToString() + "_" + FBrowse.FileName;
                    string strPath = "~/EmpUploads/" + pdfName;
                    FBrowse.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
                    _obj_Smhr_Loan.LOANREQUEST_VALUATIONDOC = strPath;
                }
                //else
                //{
                //    BLL.ShowMessage(this, "please select Valuation Report");
                //    return;
                //}
            }

            _obj_Smhr_Loan.LOANNAME = rcmb_LoanType.SelectedItem.Text;

            if (HF_ID.Value != string.Empty)
                _obj_Smhr_Loan.SMHR_LOANREQUEST_ID = Convert.ToInt32(HF_ID.Value);

            _obj_Smhr_Loan.APPROVEDDATE = Convert.ToDateTime(txt_ApprovedDate.SelectedDate);
            _obj_Smhr_Loan.APPROVEDBY = Convert.ToInt32(Session["USER_ID"]);

            //if selected loanType has parent loan
            if (rcmb_LoanType.SelectedIndex > 0)
            {
                if (string.Compare(rcmb_LoanType.SelectedItem.Text, "Car Advance-Life Ins", true) == 0
                    || string.Compare(rcmb_LoanType.SelectedItem.Text, "Car Advance-Fire Ins", true) == 0
                    || string.Compare(rcmb_LoanType.SelectedItem.Text, "Car Advance-Over Haul", true) == 0
                    || string.Compare(rcmb_LoanType.SelectedItem.Text, "Mortgage-Fire Ins", true) == 0
                    || string.Compare(rcmb_LoanType.SelectedItem.Text, "Mortgage-Life Ins", true) == 0)
                {
                    _obj_Smhr_Loan.PARENT_LOANNO = Convert.ToString(rcmb_ParentLoanNo.SelectedItem.Text);
                }
            }

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_Loan.OPERATION = operation.Update_New;
                    if (BLL.set_LoanRequest(_obj_Smhr_Loan))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");

                    break;
                case "BTN_SAVE":
                    _obj_Smhr_Loan.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_LoanRequest(_obj_Smhr_Loan).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Loan Request Already Exists");
                        return;
                    }

                    if (string.Compare(rb_loanprocesstype.SelectedItem.Value, "1", true) == 0)
                    {
                        SMHR_VOLUNTARY_DEDUCTION_ARREARS _obj_smhr_voluntary_deduction_arrears = new SMHR_VOLUNTARY_DEDUCTION_ARREARS();
                        _obj_smhr_voluntary_deduction_arrears.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_EMP_ID = Convert.ToInt32(rcmb_EmployeeName.SelectedItem.Value);
                        _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_BU_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                        _obj_smhr_voluntary_deduction_arrears.ENDDATE = Convert.ToDateTime(txt_ApprovedDate.SelectedDate);

                        DataTable chkEmpSalDtlsData = BLL.CheckEmpSalDtlsData(_obj_smhr_voluntary_deduction_arrears);

                        if (chkEmpSalDtlsData.Rows.Count > 0)
                        {
                            BLL.ShowMessage(this, "Payroll is already generated for the Approved Date");
                            return;
                        }
                        _obj_Smhr_Loan.PARENT_LOANNO = getLoanNo();
                    }

                    _obj_Smhr_Loan.OPERATION = operation.Insert;

                    if (BLL.set_LoanRequest(_obj_Smhr_Loan))
                    {

                        if (rb_loanprocesstype.SelectedValue == "1")    //For Increasing balance
                        {
                            BLL.ShowMessage(this, "Loan has been sanctioned");
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Loan request has been sent for approval");
                        }
                    }
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_HDPT_page.SelectedIndex = 0;
            ClearControls();
            LoadData();
            rg_loandetails.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            LoadData();
            Rm_HDPT_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadBusinessUint()
    {
        try
        {
            if (Control != null)
            {
                if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFLOANREQUEST") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFLOANREQUEST"))
                {
                    SMHR_LOGININFO _obj_LoginInfo = new SMHR_LOGININFO();
                    _obj_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                    rcmb_BusinessUnit.Items.Clear();
                    rcmb_BusinessUnit.DataSource = BLL.get_Business_Units(_obj_LoginInfo);
                    rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                    rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                    rcmb_BusinessUnit.DataBind();
                    //rcmb_BusinessUnit.Enabled = false;
                    //rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                    _obj_smhr_emp_payitems.OPERATION = operation.Self;
                    _obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable DT_SELF = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                    if (DT_SELF.Rows.Count > 0)
                    {
                        rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.FindItemIndexByValue(DT_SELF.Rows[0]["EMP_BUSINESSUNIT_ID"].ToString());
                        LoadEmployee();
                        rcmb_EmployeeName.SelectedIndex = rcmb_EmployeeName.FindItemIndexByValue(DT_SELF.Rows[0]["EMP_ID"].ToString());
                    }
                    rcmb_BusinessUnit.Enabled = false;
                    rcmb_EmployeeName.Enabled = false;
                    ////To make Employee DOJ as Mindate
                    //SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                    //_obj_smhr_logininfo.OPERATION = operation.Select3;
                    //_obj_smhr_logininfo.LOGIN_EMP_ID = Convert.ToInt32(rcmb_EmployeeName.SelectedItem.Value);
                    //_obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //DataTable dt_emp = BLL.get_LoginInfo(_obj_smhr_logininfo);
                    //if (dt_emp.Rows.Count > 0)
                    //{
                    //    txt_StartDate.MinDate = Convert.ToDateTime(dt_emp.Rows[0]["EMP_DOJ"]);
                    //}
                }
                else
                {
                    BLL.ShowMessage(this, "You do not have Access on this Screen!");
                    return;
                }
            }
            else
            {
                SMHR_LOGININFO _obj_LoginInfo = new SMHR_LOGININFO();
                _obj_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                rcmb_BusinessUnit.Items.Clear();
                rcmb_BusinessUnit.DataSource = BLL.get_Business_Units(_obj_LoginInfo);
                rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BusinessUnit.DataBind();
                rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rcmb_BusinessUnit.Enabled = true;
                rcmb_EmployeeName.Enabled = true;
                rcmb_EmployeeName.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        //rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
    }
    private void LoadEmployee()
    {
        try
        {
            SMHR_LOANREQUEST _obj_Smhr_BusinessUnit = new SMHR_LOANREQUEST();
            _obj_Smhr_BusinessUnit.OPERATION = operation.Validate;
            _obj_Smhr_BusinessUnit.LOANREQUEST_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            //_obj_Smhr_BusinessUnit.lOANREQUEST_EMPLOYEEID = Convert.ToInt32(Session["USER_ID"]);
            rcmb_EmployeeName.Items.Clear();
            rcmb_EmployeeName.DataSource = BLL.get_Employee(_obj_Smhr_BusinessUnit);
            rcmb_EmployeeName.DataTextField = "employeename";
            rcmb_EmployeeName.DataValueField = "emp_id";
            rcmb_EmployeeName.DataBind();
            rcmb_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //rcmb_EmployeeName.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rg_loandetails_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadEmployee_Edit()
    {
        try
        {
            SMHR_LOANREQUEST _obj_Smhr_BusinessUnit = new SMHR_LOANREQUEST();
            _obj_Smhr_BusinessUnit.OPERATION = operation.Validate1;
            _obj_Smhr_BusinessUnit.LOANREQUEST_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            //_obj_Smhr_BusinessUnit.lOANREQUEST_EMPLOYEEID = Convert.ToInt32(Session["USER_ID"]);
            rcmb_EmployeeName.Items.Clear();
            rcmb_EmployeeName.DataSource = BLL.get_Employee(_obj_Smhr_BusinessUnit);
            rcmb_EmployeeName.DataTextField = "employeename";
            rcmb_EmployeeName.DataValueField = "emp_id";
            rcmb_EmployeeName.DataBind();
            rcmb_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void ClearControls()
    {
        try
        {
            txt_Amount.Text = string.Empty;
            rtxt_NOI.Text = string.Empty;
            txt_StartDate.SelectedDate = null;
            lblEMI.Text = string.Empty;
            rcmb_LoanType.SelectedIndex = -1;
            txt_Amount.Text = string.Empty;
            rtxt_NOI.Text = string.Empty;
            rb_loanprocesstype.SelectedIndex = -1;
            // txt_StartDate.MinDate =DateTime.Now;
            HF_ID.Value = "";
            if (Control != null)
            {
                if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFLOANREQUEST") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFLOANREQUEST"))
                {
                    //rcmb_EmployeeName.SelectedIndex = 0;
                }
            }
            else
            {
                rcmb_BusinessUnit.SelectedIndex = 0;
                rcmb_EmployeeName.Items.Clear();
                rcmb_EmployeeName.Items.Insert(0, new RadComboBoxItem("Select"));
                rcmb_EmployeeName.ClearSelection();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void LoadLoanType()
    {
        try
        {
            SMHR_PAYITEMS _obj_SMHR_PAYITEMS = new SMHR_PAYITEMS();
            _obj_SMHR_PAYITEMS.OPERATION = operation.Check1;
            _obj_SMHR_PAYITEMS.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_PAYITEMS.PAYITEM_LOAN_PROCESSTYPE = Convert.ToInt32(rb_loanprocesstype.SelectedItem.Value);
            rcmb_LoanType.Items.Clear();
            rcmb_LoanType.DataSource = BLL.get_PayItems(_obj_SMHR_PAYITEMS);
            rcmb_LoanType.DataTextField = "PAYITEM_PAYITEMNAME";
            rcmb_LoanType.DataValueField = "PAYITEM_ID";
            rcmb_LoanType.DataBind();
            rcmb_LoanType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            if (rb_loanprocesstype.SelectedIndex > 0)
            {
                if (rb_loanprocesstype.SelectedValue == "1")
                {
                    trRateOfInterest.Visible = false;
                    trLoanEligibleAmount.Visible = false;
                }
                txt_Amount.Text = string.Empty;
                txt_Amount.Enabled = true;
            }
            rcmb_LoanType.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            trParentLoan.Visible = false;
            trCreateVoucher.Visible = false;    //To hide "CreateVoucher" link
            rcmb_LoanType.ClearSelection();
            trRateOfInterest.Visible = false;
            trLoanEligibleAmount.Visible = false;
            txt_Amount.Text = string.Empty;
            lblEMI.Text = string.Empty;
            rtxt_NOI.Text = string.Empty;
            txt_StartDate.SelectedDate = null;
            trCreateVoucher.Visible = false;    //To hide "CreateVoucher" link

            if (rcmb_BusinessUnit.SelectedIndex > 0)
            {
                LoadEmployee();
            }
            else
            {
                rcmb_EmployeeName.ClearSelection();
                rcmb_EmployeeName.Items.Clear();
                rcmb_EmployeeName.Text = string.Empty;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_EmployeeName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_LoanType.ClearSelection();
            trParentLoan.Visible = false;
            trCreateVoucher.Visible = false;    //To hide "CreateVoucher" link
            trRateOfInterest.Visible = false;
            trLoanEligibleAmount.Visible = false;
            txt_Amount.Text = string.Empty;
            lblEMI.Text = string.Empty;
            rtxt_NOI.Text = string.Empty;
            txt_StartDate.SelectedDate = null;
            //if (rcmb_EmployeeName.SelectedIndex > 0)
            //{

            ////To make Employee DOJ as Mindate
            //SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            //_obj_smhr_logininfo.OPERATION = operation.Select3;
            //_obj_smhr_logininfo.LOGIN_EMP_ID = Convert.ToInt32(rcmb_EmployeeName.SelectedItem.Value);
            //_obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt_emp = BLL.get_LoginInfo(_obj_smhr_logininfo);
            //if (dt_emp.Rows.Count > 0)
            //{
            //    txt_StartDate.MinDate = Convert.ToDateTime(dt_emp.Rows[0]["EMP_DOJ"]);
            //}
            // }
            // else
            // {
            //txt_StartDate.MinDate = Convert.ToDateTime("01-01-1900");
            // }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void LoadData()
    {
        try
        {
            DataTable dt;

            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                rg_loandetails.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Save.Visible = false;
                btn_Cancel.Visible = false;
            }
            //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 3)
            //{
            //    rg_loandetails.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
            //    btn_Save.Visible = false;
            //    btn_Cancel.Visible = false;

            //    if (Convert.ToString(Session["SELFSERVICE"]) == "true" && Convert.ToString(Request.QueryString["Control"]) == "SELFLOANREQUEST")
            //    {
            //        BLL.ShowMessage(this, "You do not have Access on this Screen!");
            //        return;
            //    }
            if (Control != null)
            {
                if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFLOANREQUEST") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFLOANREQUEST"))
                {
                    SMHR_LOANREQUEST _obj_smhr_empcompoff = new SMHR_LOANREQUEST();
                    _obj_smhr_empcompoff.OPERATION = operation.Select_Self;
                    _obj_smhr_empcompoff.lOANREQUEST_EMPLOYEEID = Convert.ToInt32(Session["EMP_ID"]);
                    dt = BLL.get_EmployeeLoanFinalstatus(_obj_smhr_empcompoff);
                    rg_loandetails.DataSource = dt;
                    //rg_loandetails.DataBind();
                }
                else
                {
                    BLL.ShowMessage(this, "You do not have Access on this Screen!");
                    return;
                }
            }

        //}
            else
            {
                if (((Convert.ToString(Request.QueryString["lnkType"]) == "DBLink") || Convert.ToInt32(Session["EMP_ID"]) != 0) && string.IsNullOrEmpty(Convert.ToString(Request.QueryString["lnkType"])) == false)
                {
                    SMHR_LOANREQUEST _obj_smhr_empcompoff = new SMHR_LOANREQUEST();
                    _obj_smhr_empcompoff.OPERATION = operation.Select_Self;
                    _obj_smhr_empcompoff.lOANREQUEST_EMPLOYEEID = Convert.ToInt32(Session["EMP_ID"]);
                    dt = BLL.get_EmployeeLoanFinalstatus(_obj_smhr_empcompoff);
                    rg_loandetails.DataSource = dt;
                }
                else
                {
                    SMHR_LOANREQUEST _obj_smhr_empcompoff = new SMHR_LOANREQUEST();
                    _obj_smhr_empcompoff.OPERATION = operation.Select3;
                    _obj_smhr_empcompoff.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                    //_obj_smhr_empcompoff.lOANREQUEST_EMPLOYEEID = 57;// Convert.ToInt32(Session["EMP_ID"]);
                    dt = BLL.get_EmployeeLoanFinalstatus(_obj_smhr_empcompoff);
                    rg_loandetails.DataSource = dt;
                    //rg_loandetails.DataBind();
                }
            }
        }
        //}


        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    protected void lnk_add(object sender, EventArgs e)
    {
        try
        {
            txt_ApprovedDate.Enabled = true;
            txt_StartDate.Enabled = true;
            txt_Amount.Enabled = true;
            rbShowDialog.Visible = true;
            rb_loanprocesstype.Enabled = true;
            lnkCreateVoucher.Text = "Create Voucher";
            Session["VoucherData"] = null;
            Session["GenerateEMI"] = null;
            trParentLoan.Visible = false;
            trCreateVoucher.Visible = false;
            LoadBusinessUint();
            LoadLoanType();
            Rm_HDPT_page.SelectedIndex = 1;
            btn_Update.Visible = false;
            btn_Save.Visible = true;
            lblRateofInterest.Text = string.Empty;
            lblLoanEligibleAmount.Text = string.Empty;
            txt_ApprovedDate.SelectedDate = null;
            trLoanEligibleAmount.Visible = false;
            trRateOfInterest.Visible = false;
            HF_ID.Value = string.Empty;
            //rcmb_BusinessUnit.Enabled = true;
            //rcmb_EmployeeName.Enabled = true;
            rcmb_LoanType.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lbtn_Edit_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            lblLoanEligibleAmount.Text = string.Empty;
            lblRateofInterest.Text = string.Empty;
            LoadBusinessUint();
            LoadLoanType();
            SMHR_LOANREQUEST _obj_Smhr_Loanrequest = new SMHR_LOANREQUEST();
            _obj_Smhr_Loanrequest.SMHR_LOANREQUEST_ID = Convert.ToInt32(e.CommandArgument);
            HF_ID.Value = Convert.ToString(e.CommandArgument);
            _obj_Smhr_Loanrequest.OPERATION = operation.Select;
            DataTable dt = BLL.get_LoanRequest(_obj_Smhr_Loanrequest);
            if (dt.Rows.Count > 0)
            {
                //if (Convert.ToString(dt.Rows[0]["HR_MASTER_DESC"]).Trim() != "Applied")
                //{
                //    BLL.ShowMessage(this, "You can not edit this record.");
                //    return;
                //}
                rbShowDialog.Visible = false;
                rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.FindItemIndexByValue(dt.Rows[0]["BUSINESSUNITID"].ToString());
                LoadEmployee_Edit();
                rcmb_EmployeeName.SelectedIndex = rcmb_EmployeeName.FindItemIndexByValue(dt.Rows[0]["EMPLOYEEID"].ToString());
                rcmb_EmployeeName_SelectedIndexChanged(null, null);
                rb_loanprocesstype.SelectedIndex = rb_loanprocesstype.FindItemIndexByValue(dt.Rows[0]["PAYITEM_LOAN_PROCESSTYPE"].ToString());
                rb_loanprocesstype_SelectedIndexChanged(null, null);
                rcmb_LoanType.SelectedIndex = rcmb_LoanType.FindItemIndexByValue(dt.Rows[0]["LOANTYPE"].ToString());
                rcmb_LoanType_SelectedIndexChanged(null, null);
                if (string.Compare(rcmb_LoanType.SelectedItem.Text, "Car Advance-Life Ins", true) == 0
                                            || string.Compare(rcmb_LoanType.SelectedItem.Text, "Car Advance-Fire Ins", true) == 0
                                            || string.Compare(rcmb_LoanType.SelectedItem.Text, "Car Advance-Over Haul", true) == 0
                                            || string.Compare(rcmb_LoanType.SelectedItem.Text, "Mortgage-Life Ins", true) == 0
                                            || string.Compare(rcmb_LoanType.SelectedItem.Text, "Mortgage-Fire Ins", true) == 0)    //To show parent loan dropdown
                {
                    rcmb_ParentLoanNo.SelectedIndex = rcmb_ParentLoanNo.FindItemIndexByText(dt.Rows[0]["PARENT_LOANNO"].ToString());
                }
                txt_Amount.Text = Convert.ToString(dt.Rows[0]["AMOUNT"]);
                rtxt_NOI.Text = Convert.ToString(dt.Rows[0]["NOOFINSTALLMENTS"]);
                txt_StartDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["APPLIEDDATE"]);
                txt_ApprovedDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["APPROVEDATE"]);
                rb_loanprocesstype.SelectedIndex = rb_loanprocesstype.Items.FindItemIndexByText(Convert.ToString(dt.Rows[0]["LOAN_PROCESS_TYPE"]));

                LoadGrid();
                if (string.Compare(rcmb_LoanType.SelectedItem.Text, "Salary Advance", true) == 0 || string.Compare(rcmb_LoanType.SelectedItem.Text, "Salary in Advance", true) == 0)
                {
                    _obj_Smhr_Loanrequest.OPERATION = operation.LoanVoucher;
                    DataTable dtLoanVocher = BLL.get_LoanRequest(_obj_Smhr_Loanrequest);
                    Session["VoucherData"] = dtLoanVocher;
                    lnkCreateVoucher.Text = "View Voucher";
                }

                if (rb_loanprocesstype.SelectedItem.Text == "Standard")
                {
                    lblEMI.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_Amount.Text) / Convert.ToDecimal(rtxt_NOI.Text),2));
                }
            }
            Rm_HDPT_page.SelectedIndex = 1;
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;

            }

            else
            {
                btn_Update.Visible = true;
            }
            btn_Save.Visible = false;
            btn_Update.Visible = true;
            rcmb_BusinessUnit.Enabled = false;
            rcmb_EmployeeName.Enabled = false;
            rcmb_LoanType.Enabled = false;
            rbtnAgree.SelectedIndex = 0;

            if (Convert.ToString(dt.Rows[0]["HR_MASTER_DESC"]).Trim() != "Applied")
            {
                btn_Save.Visible = false;
                btn_Update.Visible = false;
            }
            if (string.Compare(rb_loanprocesstype.SelectedItem.Value, "1", true) == 0) //To check if loan type is Increasing balance
            {
                if (Convert.ToInt32(dt.Rows[0]["IsIncreasingLoanClosed"]) == 1) //To check whether loan is closed, if closed then hide update, and calculate buttons
                {
                    btn_Update.Visible = false;
                    rbShowDialog.Visible = false;
                }
                else
                {
                    btn_Update.Visible = true;
                }
            }
            //To show interest rate for approved loan from LoanTrans table, as interest rate may change in loan setup after loan approval
            _obj_Smhr_Loanrequest.OPERATION = operation.Available;
            DataTable dtLoanApprDtls = BLL.get_LoanRequest(_obj_Smhr_Loanrequest);

            if (dtLoanApprDtls.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dtLoanApprDtls.Rows[0]["LOANTRAN_STATUS"])))
                {
                    if (Convert.ToInt32(dtLoanApprDtls.Rows[0]["LOANTRAN_STATUS"]) == 1)
                    {
                        lblRateofInterest.Text = Convert.ToString(dtLoanApprDtls.Rows[0]["LOANTRANS_INTERESTRATE"]);
                    }
                }
            }
            if (rcmb_LoanType.SelectedIndex > 0)
            {
                SMHR_LOANSETUP _obj_SMHRLOANSETUP = new SMHR_LOANSETUP();

                _obj_SMHRLOANSETUP.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHRLOANSETUP.LOANSETUP_LOANTYPE_ID = Convert.ToInt32(rcmb_LoanType.SelectedValue);
                _obj_SMHRLOANSETUP.LOANSETUP_LOANPROCESSTYPE = rb_loanprocesstype.SelectedItem.Text;

                DataTable dtLS = BLL.GetLoanSetupData(_obj_SMHRLOANSETUP);

                if (dtLS.Rows.Count > 0)
                {
                    hdnMinTenureMonths.Value = Convert.ToString(dtLS.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                    hdnMaxTenureMonths.Value = Convert.ToString(dtLS.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);
                }

                if (rb_loanprocesstype.SelectedItem.Text == "Standard")
                    rbShowDialog.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rtxt_NOI_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (rtxt_NOI.Text != string.Empty)
            {
                //rtxt_NOI.Value = Math.Round(Convert.ToDouble(rtxt_NOI.Value));

                if (rcmb_LoanType.SelectedIndex > 0)
                {
                    SMHR_LOANSETUP _obj_SMHRLOANSETUP = new SMHR_LOANSETUP();

                    _obj_SMHRLOANSETUP.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_SMHRLOANSETUP.LOANSETUP_LOANTYPE_ID = Convert.ToInt32(rcmb_LoanType.SelectedValue);
                    _obj_SMHRLOANSETUP.LOANSETUP_LOANPROCESSTYPE = rb_loanprocesstype.SelectedItem.Text;

                    DataTable dt = BLL.GetLoanSetupData(_obj_SMHRLOANSETUP);

                    if (dt.Rows.Count > 0)
                    {
                        hdnMinTenureMonths.Value = Convert.ToString(dt.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                        hdnMaxTenureMonths.Value = Convert.ToString(dt.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);

                        if (Convert.ToInt32(dt.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]) < Convert.ToInt32(rtxt_NOI.Text))
                        {
                            BLL.ShowMessage(this, "Max Tenuring months for selected Loan Type & Loan Process Type is " + Convert.ToString(dt.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]));
                            rtxt_NOI.Text = string.Empty;
                            rtxt_NOI.Focus();
                            return;
                        }
                        if (Convert.ToInt32(dt.Rows[0]["LOANSETUP_MINTENUREMONTHS"]) > Convert.ToInt32(rtxt_NOI.Text))
                        {
                            BLL.ShowMessage(this, "Minimum Tenuring months for selected Loan Type & Loan Process Type is " + Convert.ToString(dt.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]));
                            rtxt_NOI.Text = string.Empty;
                            rtxt_NOI.Focus();
                            return;
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Loan Setup was not yet done for selected Loan Type & Loan Process Type");
                        return;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Please select Loan Type before entering No of Installments..!");
                    rtxt_NOI.Text = string.Empty;
                    rcmb_LoanType.Focus();
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_LoanType_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            ClearVoucher();
            Session["VoucherData"] = null;
            Session["GenerateEMI"] = null;
            trCreateVoucher.Visible = false;    //To hide "CreateVoucher" link
            trParentLoan.Visible = false;
            rcmb_ParentLoanNo.Items.Clear();    //To clear 
            rcmb_ParentLoanNo.Text = string.Empty;
            txt_Amount.Enabled = true;
            txt_Amount.Text = string.Empty;
            rtxt_NOI.Text = string.Empty;
            txt_StartDate.SelectedDate = null;
            lblEMI.Text = string.Empty;
            //txt_StartDate.MinDate = DateTime.Now;
            rfv_rtxt_DName2.Visible = true;

            if (rcmb_LoanType.SelectedIndex > 0)
            {
                SMHR_LOANSETUP _obj_SMHRLOANSETUP = new SMHR_LOANSETUP();

                _obj_SMHRLOANSETUP.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHRLOANSETUP.LOANSETUP_LOANTYPE_ID = Convert.ToInt32(rcmb_LoanType.SelectedValue);
                _obj_SMHRLOANSETUP.LOANSETUP_LOANPROCESSTYPE = rb_loanprocesstype.SelectedItem.Text;

                DataTable dtLS = BLL.GetLoanSetupData(_obj_SMHRLOANSETUP);

                if (dtLS.Rows.Count == 0)
                {
                    BLL.ShowMessage(this, "Loan Setup was not done for Loan Type: " + rcmb_LoanType.SelectedItem.Text);
                    rcmb_LoanType.SelectedIndex = 0;
                    rcmb_LoanType.Focus();
                    trRateOfInterest.Visible = false;
                    return;
                }
                else
                {
                    if (string.Compare(rb_loanprocesstype.SelectedItem.Value, "0", true) == 0)
                    {
                        #region Reducing Balance
                        txt_Amount.Enabled = true;
                        if (rcmb_LoanType.SelectedIndex > 0)
                        {
                            if (rcmb_EmployeeName.SelectedItem == null || string.Compare(rcmb_EmployeeName.SelectedItem.Text.ToLower(), "select", true) == 0)
                            {
                                BLL.ShowMessage(this, "Please select Employee");
                                rcmb_LoanType.ClearSelection();
                                return;
                            }
                            else
                            {
                                SMHR_LOANSETUP oSMHR_LOANSETUP = new SMHR_LOANSETUP();
                                oSMHR_LOANSETUP.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                oSMHR_LOANSETUP.LOGIN_ID = Convert.ToInt32(rcmb_EmployeeName.SelectedValue);
                                oSMHR_LOANSETUP.LOANSETUP_LOANTYPE_ID = Convert.ToInt32(rcmb_LoanType.SelectedValue);
                                if (string.Compare(rcmb_LoanType.SelectedItem.Text, "Salary Advance", true) == 0)//|| string.Compare(rcmb_LoanType.SelectedItem.Text, "Salary in Advance", true) != 0)
                                {
                                    #region Salary Advance
                                    trBrowse.Visible = false;
                                    oSMHR_LOANSETUP.OPERATION = operation.Select;
                                    DataTable dt = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                                    if (dt.Rows.Count > 0)
                                    {
                                        //if (Convert.ToBoolean(dt.Rows[0]["IsConatrctExpired"]))
                                        //{
                                        trRateOfInterest.Visible = true;
                                        trLoanEligibleAmount.Visible = true;
                                        lblLoanEligibleAmount.Text = Convert.ToInt32(dt.Rows[0]["EMP_BASIC"]).ToString();
                                        lblRateofInterest.Text = Convert.ToString(dt.Rows[0]["LOANSETUP_LOANINTEREST"]);
                                        hdnMinTenureMonths.Value = Convert.ToString(dt.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                                        hdnMaxTenureMonths.Value = Convert.ToString(dt.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);
                                        hdnMaxeligibleMonthsforEmp.Value = Convert.ToString(dt.Rows[0]["MAXELIGIBLEMONTHSFOREMPLOYEE"]);
                                        txt_Amount.Text = Convert.ToInt32(dt.Rows[0]["EMP_BASIC"]).ToString();
                                        if (Convert.ToInt32(dt.Rows[0]["EMP_BASIC"]) == 0 && o != null)
                                        {
                                            trRateOfInterest.Visible = false;
                                            trLoanEligibleAmount.Visible = false;
                                            trBrowse.Visible = false;
                                            BLL.ShowMessage(this, "Already you have this loan");
                                            rcmb_LoanType.ClearSelection();
                                            return;
                                        }

                                        txt_Amount.Enabled = false;
                                        trCreateVoucher.Visible = true; //To show "Create Voucher" link
                                        //}
                                        //else
                                        //{
                                        //    trRateOfInterest.Visible = false;
                                        //    trLoanEligibleAmount.Visible = false;
                                        //    trBrowse.Visible = false;
                                        //    BLL.ShowMessage(this, "Minimum tenure months is greater than your contract expiry date");
                                        //    rcmb_LoanType.ClearSelection();
                                        //    return;
                                        //}
                                    }
                                    else
                                    {
                                        trRateOfInterest.Visible = false;
                                        trLoanEligibleAmount.Visible = false;
                                        trBrowse.Visible = false;
                                        BLL.ShowMessage(this, "Loan Setup not done for this loan");
                                        rcmb_LoanType.ClearSelection();
                                        return;
                                    }
                                    #endregion
                                }
                                else if (string.Compare(rcmb_LoanType.SelectedItem.Text, "Salary in Advance", true) == 0)
                                {
                                    #region Salary In Advance
                                    trBrowse.Visible = false;
                                    oSMHR_LOANSETUP.OPERATION = operation.Validate;
                                    oSMHR_LOANSETUP.Amount = 0;
                                    oSMHR_LOANSETUP.EffectiveDate = DateTime.Now;
                                    DataTable dt = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                                    oSMHR_LOANSETUP.OPERATION = operation.Select;
                                    DataTable dtLoanSetup = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                                    if (dt.Rows.Count > 0 && dtLoanSetup.Rows.Count > 0)
                                    {
                                        trRateOfInterest.Visible = true;
                                        trLoanEligibleAmount.Visible = true;
                                        if (Convert.ToBoolean(dt.Rows[0]["FINAL"]))
                                        {
                                            //if (Convert.ToBoolean(dtLoanSetup.Rows[0]["IsConatrctExpired"]))
                                            //{
                                            lblLoanEligibleAmount.Text = Convert.ToInt32(dt.Rows[0]["AMOUNT"]).ToString();
                                            lblRateofInterest.Text = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_LOANINTEREST"]);
                                            hdnMinTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                                            hdnMaxTenureMonths.Value = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);
                                            hdnMaxeligibleMonthsforEmp.Value = Convert.ToString(dtLoanSetup.Rows[0]["MAXELIGIBLEMONTHSFOREMPLOYEE"]);
                                            trCreateVoucher.Visible = true;    //To show "CreateVoucher" link
                                            //}
                                            //else
                                            //{
                                            //    trRateOfInterest.Visible = false;
                                            //    trLoanEligibleAmount.Visible = false;
                                            //    trBrowse.Visible = false;
                                            //    BLL.ShowMessage(this, "Minimum tenure months is greater than your contract expiry date");
                                            //    rcmb_LoanType.ClearSelection();
                                            //    return;
                                            //}
                                        }
                                        else
                                        {
                                            trRateOfInterest.Visible = false;
                                            trLoanEligibleAmount.Visible = false;
                                            trBrowse.Visible = false;
                                            BLL.ShowMessage(this, Convert.ToString(dt.Rows[0]["ErrorMessage"]));
                                            rcmb_LoanType.ClearSelection();
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        trRateOfInterest.Visible = false;
                                        trLoanEligibleAmount.Visible = false;
                                        trBrowse.Visible = false;
                                        BLL.ShowMessage(this, "Loan Setup not done for this loan");
                                        rcmb_LoanType.ClearSelection();
                                        return;
                                    }
                                    #endregion
                                }
                                //else if (string.Compare(rcmb_LoanType.SelectedItem.Text, "Car Advance-Life Ins", true) == 0)    //To show parent loan dropdown
                                //{

                                #region Car Life Loans
                                //    trBrowse.Visible = true;
                                //    oSMHR_LOANSETUP.OPERATION = operation.Check;
                                //    DataTable dt = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                                //    if (dt.Rows.Count > 0)
                                //    {
                                //        if (Convert.ToBoolean(dt.Rows[0]["IsElisgible"]))
                                //        {
                                //            if (Convert.ToBoolean(dt.Rows[0]["IsConatrctExpired"]))
                                //            {
                                //                trRateOfInterest.Visible = true;
                                //                trLoanEligibleAmount.Visible = true;
                                //                if (Convert.ToInt32(dt.Rows[0]["LOANELIGIBLEAMOUNT_MAXAMOUNT"]) == 0)
                                //                {
                                //                    trRateOfInterest.Visible = false;
                                //                    trLoanEligibleAmount.Visible = false;
                                //                    trBrowse.Visible = false;
                                //                    BLL.ShowMessage(this, "Loan Setup not done for this loan or Employee Reached Max Amount");
                                //                    rcmb_LoanType.ClearSelection();
                                //                    return;
                                //                }
                                //                SMHR_PAYITEMS _obj_payitems = new SMHR_PAYITEMS();
                                //                _obj_payitems.OPERATION = operation.Select_New;
                                //                _obj_payitems.LOGIN_ID = Convert.ToInt32(rcmb_EmployeeName.SelectedValue);
                                //                _obj_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                //                _obj_payitems.PAYITEM_PAYITEMNAME = Convert.ToString(rcmb_LoanType.SelectedItem.Text);
                                //                DataTable dtParentLoanNo = BLL.get_PayItems(_obj_payitems);
                                //                rcmb_ParentLoanNo.Items.Clear();
                                //                rcmb_ParentLoanNo.Text = string.Empty;
                                //                if (dtParentLoanNo.Rows.Count > 0)
                                //                {
                                //                    trParentLoan.Visible = true;
                                //                    rcmb_ParentLoanNo.DataSource = dtParentLoanNo;
                                //                    rcmb_ParentLoanNo.DataTextField = "LOANTRANS_LOANNO";
                                //                    rcmb_ParentLoanNo.DataValueField = "LOANTRANS_ID";
                                //                    rcmb_ParentLoanNo.DataBind();
                                //                    rcmb_ParentLoanNo.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                                //                }
                                //                else
                                //                {
                                //                    trRateOfInterest.Visible = false;
                                //                    trLoanEligibleAmount.Visible = false;
                                //                    trBrowse.Visible = false;
                                //                    trParentLoan.Visible = false;
                                //                    BLL.ShowMessage(this, "you are not eligible for this loan type");
                                //                    rcmb_LoanType.ClearSelection();
                                //                    return;
                                //                }
                                //                lblLoanEligibleAmount.Text = Convert.ToInt32(dt.Rows[0]["LOANELIGIBLEAMOUNT_MAXAMOUNT"]).ToString();
                                //                lblRateofInterest.Text = Convert.ToString(dt.Rows[0]["LOANSETUP_LOANINTEREST"]);
                                //                hdnMinTenureMonths.Value = Convert.ToString(dt.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                                //                hdnMaxTenureMonths.Value = Convert.ToString(dt.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);
                                //                hdnMaxeligibleMonthsforEmp.Value = Convert.ToString(dt.Rows[0]["MAXELIGIBLEMONTHSFOREMPLOYEE"]);
                                //            }
                                //            else
                                //            {
                                //                trRateOfInterest.Visible = false;
                                //                trLoanEligibleAmount.Visible = false;
                                //                trBrowse.Visible = false;
                                //                BLL.ShowMessage(this, "Minimum tenure months is greater than your contract expiry date");
                                //                rcmb_LoanType.ClearSelection();
                                //                return;
                                //            }
                                //        }
                                //        else
                                //        {
                                //            trRateOfInterest.Visible = false;
                                //            trLoanEligibleAmount.Visible = false;
                                //            trBrowse.Visible = false;
                                //            BLL.ShowMessage(this, Convert.ToString(dt.Rows[0]["Errormessage"]));
                                //            rcmb_LoanType.ClearSelection();
                                //            return;
                                //        }
                                //    }
                                //    else
                                //    {
                                //        trRateOfInterest.Visible = false;
                                //        trLoanEligibleAmount.Visible = false;
                                //        trBrowse.Visible = false;
                                //        BLL.ShowMessage(this, "Loan Setup not done for this loan");
                                //        rcmb_LoanType.ClearSelection();
                                //        return;
                                //    }

                                #endregion
                                //    //LoadParentLoans();
                                //}
                                else
                                {
                                    #region All Loans
                                    trBrowse.Visible = true;
                                    oSMHR_LOANSETUP.OPERATION = operation.Check;
                                    DataTable dt = BLL.get_LoanSetup(oSMHR_LOANSETUP);
                                    if (dt.Rows.Count > 0)
                                    {
                                        //if (Convert.ToBoolean(dt.Rows[0]["IsElisgible"]))
                                        //{
                                        //    if (Convert.ToBoolean(dt.Rows[0]["IsConatrctExpired"]))
                                        //    {
                                        trRateOfInterest.Visible = true;
                                        trLoanEligibleAmount.Visible = true;
                                        if (Convert.ToDouble(dt.Rows[0]["LOANELIGIBLEAMOUNT_MAXAMOUNT"]) == 0 && o != null)
                                        {
                                            trRateOfInterest.Visible = false;
                                            trLoanEligibleAmount.Visible = false;
                                            trBrowse.Visible = false;
                                            BLL.ShowMessage(this, "Loan Setup not done for this loan or Employee Reached Max Amount");
                                            rcmb_LoanType.ClearSelection();
                                            return;
                                        }
                                        else
                                        {
                                            //rbShowDialog.Visible = true;
                                            if (string.Compare(rcmb_LoanType.SelectedItem.Text, "Car Advance-Life Ins", true) == 0
                                                || string.Compare(rcmb_LoanType.SelectedItem.Text, "Car Advance-Fire Ins", true) == 0
                                                || string.Compare(rcmb_LoanType.SelectedItem.Text, "Car Advance-Over Haul", true) == 0
                                                || string.Compare(rcmb_LoanType.SelectedItem.Text, "Mortgage-Life Ins", true) == 0
                                                || string.Compare(rcmb_LoanType.SelectedItem.Text, "Mortgage-Fire Ins", true) == 0)    //To show parent loan dropdown
                                            {
                                                SMHR_PAYITEMS _obj_payitems = new SMHR_PAYITEMS();
                                                _obj_payitems.OPERATION = operation.Select_New;
                                                _obj_payitems.LOGIN_ID = Convert.ToInt32(rcmb_EmployeeName.SelectedValue);
                                                _obj_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                                                _obj_payitems.PAYITEM_PAYITEMNAME = Convert.ToString(rcmb_LoanType.SelectedItem.Text);
                                                DataTable dtParentLoanNo = BLL.get_PayItems(_obj_payitems);
                                                rcmb_ParentLoanNo.Items.Clear();
                                                rcmb_ParentLoanNo.Text = string.Empty;
                                                if (dtParentLoanNo.Rows.Count > 0)
                                                {
                                                    trParentLoan.Visible = true;
                                                    rcmb_ParentLoanNo.DataSource = dtParentLoanNo;
                                                    rcmb_ParentLoanNo.DataTextField = "LOANTRANS_LOANNO";
                                                    rcmb_ParentLoanNo.DataValueField = "LOANTRANS_ID";
                                                    rcmb_ParentLoanNo.DataBind();
                                                    rcmb_ParentLoanNo.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                                                }
                                                else
                                                {
                                                    trRateOfInterest.Visible = false;
                                                    trLoanEligibleAmount.Visible = false;
                                                    trBrowse.Visible = false;
                                                    trParentLoan.Visible = false;
                                                    BLL.ShowMessage(this, "you are not eligible for this loan type");
                                                    rcmb_LoanType.ClearSelection();
                                                    return;
                                                }
                                            }
                                            //else if (string.Compare(rcmb_LoanType.SelectedItem.Text, "Deposits", true) == 0
                                            //    || string.Compare(rcmb_LoanType.SelectedItem.Text, "Accrued Interest", true) == 0
                                            //    || string.Compare(rcmb_LoanType.SelectedItem.Text, "Sinking Fund", true) == 0)
                                            //{
                                            //    rbShowDialog.Visible = false;
                                            //}

                                            lblLoanEligibleAmount.Text = Convert.ToString(Math.Round(Convert.ToDecimal(dt.Rows[0]["LOANELIGIBLEAMOUNT_MAXAMOUNT"]), 2));
                                            lblRateofInterest.Text = Convert.ToString(dt.Rows[0]["LOANSETUP_LOANINTEREST"]);
                                            hdnMinTenureMonths.Value = Convert.ToString(dt.Rows[0]["LOANSETUP_MINTENUREMONTHS"]);
                                            hdnMaxTenureMonths.Value = Convert.ToString(dt.Rows[0]["LOANSETUP_MAXTENUREMONTHS"]);
                                            hdnMaxeligibleMonthsforEmp.Value = Convert.ToString(dt.Rows[0]["MAXELIGIBLEMONTHSFOREMPLOYEE"]);

                                        }
                                        //    }
                                        //    else
                                        //    {
                                        //        trRateOfInterest.Visible = false;
                                        //        trLoanEligibleAmount.Visible = false;
                                        //        trBrowse.Visible = false;
                                        //        BLL.ShowMessage(this, "Minimum tenure months is greater than your contract expiry date");
                                        //        rcmb_LoanType.ClearSelection();
                                        //        return;
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    trRateOfInterest.Visible = false;
                                        //    trLoanEligibleAmount.Visible = false;
                                        //    trBrowse.Visible = false;
                                        //    BLL.ShowMessage(this, Convert.ToString(dt.Rows[0]["Errormessage"]));
                                        //    rcmb_LoanType.ClearSelection();
                                        //    return;
                                        //}
                                    }
                                    else
                                    {
                                        trRateOfInterest.Visible = false;
                                        trLoanEligibleAmount.Visible = false;
                                        trBrowse.Visible = false;
                                        BLL.ShowMessage(this, "Loan Setup not done for this loan");
                                        rcmb_LoanType.ClearSelection();
                                        return;
                                    }
                                    //trRateOfInterest.Visible = false;
                                    //trLoanEligibleAmount.Visible = false;
                                    //trBrowse.Visible = false;
                                    //BLL.ShowMessage(this, "Loan Setup not done for this loan");
                                    //rcmb_LoanType.ClearSelection();
                                    //return;
                                    #endregion
                                }
                            }

                        }
                        else
                        {
                            trRateOfInterest.Visible = false;
                            trLoanEligibleAmount.Visible = false;
                            trBrowse.Visible = false;
                        }
                        #endregion
                    }
                    else if (string.Compare(rb_loanprocesstype.SelectedItem.Value, "1", true) == 0)
                    {
                        txt_Amount.Enabled = false;
                        rfv_rtxt_DName2.Visible = false;
                    }
                    else if ((string.Compare(rb_loanprocesstype.SelectedItem.Value, "2", true) == 0) && rcmb_LoanType.SelectedIndex > 0)//if (rb_loanprocesstype.SelectedItem.Text.ToUpper() == "STANDARD")
                    {
                        SMHR_LOANSETUP _obj_SMHR_LOANSETUP = new SMHR_LOANSETUP();

                        _obj_SMHR_LOANSETUP.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_SMHR_LOANSETUP.LOANSETUP_LOANPROCESSTYPE = rb_loanprocesstype.SelectedItem.Text;
                        _obj_SMHR_LOANSETUP.LOANSETUP_LOANTYPE_ID = Convert.ToInt32(rcmb_LoanType.SelectedValue);

                        DataTable dtLoanSetup = BLL.GetLoanSetupData(_obj_SMHR_LOANSETUP);

                        if (dtLoanSetup.Rows.Count > 0)
                        {
                            trRateOfInterest.Visible = true;
                            lblRateofInterest.Text = Convert.ToString(dtLoanSetup.Rows[0]["LOANSETUP_LOANINTEREST"]);
                        }
                        else
                        {
                            trRateOfInterest.Visible = false;
                            lblRateofInterest.Text = lblEMI.Text = string.Empty;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void LoadParentLoans()
    {
        try
        {
            if (rcmb_LoanType.SelectedIndex > 0 && rcmb_EmployeeName.SelectedIndex > 0)
            {
                if (string.Compare(rcmb_LoanType.SelectedItem.Text, "Car Advance-Life Ins", true) == 0)
                {
                    SMHR_PAYITEMS _obj_payitems = new SMHR_PAYITEMS();
                    _obj_payitems.OPERATION = operation.Select_New;
                    _obj_payitems.LOGIN_ID = Convert.ToInt32(rcmb_EmployeeName.SelectedValue);
                    _obj_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_payitems.PAYITEM_PAYITEMNAME = Convert.ToString(rcmb_LoanType.SelectedItem.Text);
                    DataTable dtParentLoanNo = BLL.get_PayItems(_obj_payitems);
                    rcmb_ParentLoanNo.Items.Clear();
                    rcmb_ParentLoanNo.Text = string.Empty;
                    if (dtParentLoanNo.Rows.Count > 0)
                    {
                        trParentLoan.Visible = true;
                        rcmb_ParentLoanNo.DataSource = dtParentLoanNo;
                        rcmb_ParentLoanNo.DataTextField = "LOANTRANS_LOANNO";
                        rcmb_ParentLoanNo.DataValueField = "LOANTRANS_ID";
                        rcmb_ParentLoanNo.DataBind();
                        rcmb_ParentLoanNo.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    }
                    else
                    {
                        trParentLoan.Visible = false;
                        BLL.ShowMessage(this, "you are not eligible for this loan type");
                        rcmb_LoanType.ClearSelection();
                        return;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void lnkCreateVoucher_Click(object sender, EventArgs e)
    {
        try
        {
            ClearVoucher();
            if (Session["VoucherData"] != null)
            {
                FillVoucherDetails((DataTable)Session["VoucherData"]);
            }
            RW_VoucherDtls.Height = 600;
            RW_VoucherDtls.Width = 650;
            RW_VoucherDtls.Visible = true;
            RW_VoucherDtls.VisibleOnPageLoad = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void ClearVoucher()
    {
        try
        {
            txtAmountinKSH.Text = txtPayeeName.Text = txtBankCode.Text = txtBranchcode.Text = txtAccountno.Text = txtNet.Text = txtVat.Text = txtAmountpayableinwords.Text = txtAuthorityreferencenumber.Text = txtvoucherexaminedby.Text = string.Empty;
            txtDate.SelectedDate = null;
            txtDepositAccountNo.Text = txtNetDepositAccountno.Text = txtNetDepositMonthKSH.Text = txtCurrentMonthKSH.Text = txtBalanceKSH.Text = txtEntryVoucher.Text = string.Empty;
            txtDepositDate.SelectedDate = null;
            txtAuthDate.SelectedDate = null;
            txtVote.Text = txtHead.Text = txtSubHead.Text = txtSource.Text = txtProgramme.Text = txtGeographical.Text = txtItem.Text = txtAccountOthNo.Text = txtDeptVch.Text = txtStation.Text = txtCashBookVchNo.Text = string.Empty;
            txtCashBookDate.SelectedDate = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void FillVoucherDetails(DataTable dt)
    {
        try
        {
            txtPayeeName.Text = dt.Rows[0]["VOUCHER_PAYEENAME"].ToString();
            txtBankCode.Text = dt.Rows[0]["VOUCHER_BANKCODE"].ToString();
            txtBranchcode.Text = dt.Rows[0]["VOUCHER_BRANCHCODE"].ToString();
            txtAccountno.Text = dt.Rows[0]["VOUCHER_PARTICULARSACCOUNTNO"].ToString();
            txtNet.Text = dt.Rows[0]["VOUCHER_NET"].ToString();
            txtVat.Text = dt.Rows[0]["VOUCHER_VAT"].ToString();
            txtAmountpayableinwords.Text = dt.Rows[0]["VOUCHER_AMOUNTINWORDS"].ToString();
            txtAuthorityreferencenumber.Text = dt.Rows[0]["VOUCHER_AUTHORITYREFNUMBER"].ToString();
            txtvoucherexaminedby.Text = dt.Rows[0]["VOUCHER_VOUCHEREXAMINEDBY"].ToString();
            txtDate.SelectedDate = GetDateTime(dt.Rows[0]["VOUCHER_EXAMINATIONDATE"].ToString());
            txtDepositAccountNo.Text = dt.Rows[0]["VOUCHER_DEPOSITACCOUNTNO"].ToString();
            txtNetDepositAccountno.Text = dt.Rows[0]["VOUCHER_NETDEPOSITPREVIOUSACCOUNTNO"].ToString();
            txtNetDepositMonthKSH.Text = dt.Rows[0]["VOUCHER_NETDEPOSITPREVIOUSKSH"].ToString();
            txtCurrentMonthKSH.Text = dt.Rows[0]["VOUCHER_CURRENTMONTHKSH"].ToString();
            txtBalanceKSH.Text = dt.Rows[0]["VOUCHER_BALANCEKSH"].ToString();
            txtEntryVoucher.Text = dt.Rows[0]["VOUCHER_VOUCHERNOKSH"].ToString();
            txtDepositDate.SelectedDate = GetDateTime(dt.Rows[0]["VOUCHER_DEPOSITDATE"].ToString());
            txtAuthDate.SelectedDate = GetDateTime(dt.Rows[0]["VOUCHER_AUTHORIZATIONDATE"].ToString());
            txtVote.Text = dt.Rows[0]["VOUCHER_VOTE"].ToString();
            txtHead.Text = dt.Rows[0]["VOUCHER_HEAD"].ToString();
            txtSubHead.Text = dt.Rows[0]["VOUCHER_SUBHEAD"].ToString();
            txtSource.Text = dt.Rows[0]["VOUCHER_SOURCE"].ToString();
            txtProgramme.Text = dt.Rows[0]["VOUCHER_PROGRAMME"].ToString();
            txtGeographical.Text = dt.Rows[0]["VOUCHER_GEOGRAPHICAL"].ToString();
            txtItem.Text = dt.Rows[0]["VOUCHER_ITEM"].ToString();
            txtAccountOthNo.Text = dt.Rows[0]["VOUCHER_OTHERACCOUNTNO"].ToString();
            txtDeptVch.Text = dt.Rows[0]["VOUCHER_DEPTVCH"].ToString();
            txtStation.Text = dt.Rows[0]["VOUCHER_STATION"].ToString();
            txtCashBookVchNo.Text = dt.Rows[0]["VOUCHER_CASHBOOKVCHNO"].ToString();
            txtCashBookDate.SelectedDate = GetDateTime(dt.Rows[0]["VOUCHER_CASHBOOKDATE"].ToString());
            txtAmountinKSH.Text = dt.Rows[0]["VOUCHER_AMOUNTINKSH"].ToString();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = GetEmptyDataTAble();
            dt.Rows.Add(txtPayeeName.Text, txtBankCode.Text, txtBranchcode.Text, txtAccountno.Text, txtNet.Text, txtVat.Text,
                txtAmountpayableinwords.Text, txtAuthorityreferencenumber.Text, txtvoucherexaminedby.Text, txtDate.SelectedDate.ToString(),
                txtDepositAccountNo.Text, txtNetDepositAccountno.Text, txtNetDepositMonthKSH.Text, txtCurrentMonthKSH.Text,
                txtBalanceKSH.Text, txtEntryVoucher.Text, txtDepositDate.SelectedDate.ToString(), txtAuthDate.SelectedDate.ToString(), txtVote.Text, txtHead.Text,
                txtSubHead.Text, txtSource.Text, txtProgramme.Text, txtGeographical.Text, txtItem.Text, txtAccountOthNo.Text, txtDeptVch.Text,
                txtStation.Text, txtCashBookVchNo.Text, txtCashBookDate.SelectedDate.ToString(), txtAmountinKSH.Text);
            Session["VoucherData"] = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private DataTable GetEmptyDataTAble()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add("VOUCHER_PAYEENAME", typeof(string));
            dt.Columns.Add("VOUCHER_BANKCODE", typeof(string));
            dt.Columns.Add("VOUCHER_BRANCHCODE", typeof(string));
            dt.Columns.Add("VOUCHER_PARTICULARSACCOUNTNO", typeof(string));
            dt.Columns.Add("VOUCHER_NET", typeof(string));
            dt.Columns.Add("VOUCHER_VAT", typeof(string));
            dt.Columns.Add("VOUCHER_AMOUNTINWORDS", typeof(string));
            dt.Columns.Add("Voucher_AuthorityRefNumber", typeof(string));
            dt.Columns.Add("Voucher_VoucherExaminedBy", typeof(string));
            dt.Columns.Add("Voucher_ExaminationDate", typeof(string));
            dt.Columns.Add("Voucher_DepositAccountNo", typeof(string));
            dt.Columns.Add("Voucher_NetDepositPreviousAccountNo", typeof(string));
            dt.Columns.Add("Voucher_NetDepositPreviousKSH", typeof(string));
            dt.Columns.Add("Voucher_CurrentMonthKSH", typeof(string));
            dt.Columns.Add("Voucher_BalanceKSH", typeof(string));
            dt.Columns.Add("Voucher_VoucherNoKSH", typeof(string));
            dt.Columns.Add("Voucher_DepositDate", typeof(string));
            dt.Columns.Add("Voucher_AuthorizationDate", typeof(string));
            dt.Columns.Add("Voucher_Vote", typeof(string));
            dt.Columns.Add("Voucher_Head", typeof(string));
            dt.Columns.Add("Voucher_SubHead", typeof(string));
            dt.Columns.Add("Voucher_Source", typeof(string));
            dt.Columns.Add("Voucher_Programme", typeof(string));
            dt.Columns.Add("Voucher_Geographical", typeof(string));
            dt.Columns.Add("Voucher_Item", typeof(string));
            dt.Columns.Add("Voucher_OtherAccountNo", typeof(string));
            dt.Columns.Add("Voucher_DeptVch", typeof(string));
            dt.Columns.Add("Voucher_Station", typeof(string));
            dt.Columns.Add("Voucher_CashBookVchNo", typeof(string));
            dt.Columns.Add("Voucher_CashBookDate", typeof(string));
            dt.Columns.Add("Voucher_AmountinKSH", typeof(string));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
    }
    private DateTime GetDateTime(string p)
    {
        DateTime dt;
        try
        {
            dt = DateTime.ParseExact(p, "dd/MM/yyyy", null);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            dt = Convert.ToDateTime(p);
        }
        return dt;
    }
    protected void rb_loanprocesstype_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadLoanType();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void txt_ApprovedDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            lblEMI.Text = string.Empty;
            Session.Remove("GenerateEMI");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void chkEMI_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox Chk_All = (CheckBox)sender;
            if (Chk_All.Checked)
            {
                for (int index = 0; index < RG_GenarateEMI.Items.Count; index++)
                {
                    RadNumericTextBox t = (RadNumericTextBox)RG_GenarateEMI.Items[index].FindControl("txt_EMI");
                    if (t.Enabled)
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(ViewState["EmiValue"])))
                        {
                            ViewState["EmiValue"] = t.Text;
                        }
                        else
                        {
                            t.Text = Convert.ToString(ViewState["EmiValue"]);
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["EmiValue"])))
            {
                ViewState.Remove("EmiValue");
            }
            string script = "function f(){$find(\"" + RWOrgDetails.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}