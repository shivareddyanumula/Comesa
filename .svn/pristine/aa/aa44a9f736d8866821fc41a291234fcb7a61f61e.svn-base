using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
public partial class Payroll_frm_LoanDeposits : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_LOANTRANS _obj_smhr_loanTrans;
    string control = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Loan Boosting");//LOAN_ADVANCES");
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
                    Rg_Loandeposits.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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


            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanDeposits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadBusinessUint()
    {
        try
        {
            SMHR_LOGININFO _obj_LoginInfo = new SMHR_LOGININFO();
            control = Convert.ToString(Request.QueryString["Control"]);
            if (control != null)
            {

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


            }
            else
            {


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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanDeposits", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanDeposits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
    private void LoanType()
    {
        try
        {
            _obj_smhr_loanTrans = new SMHR_LOANTRANS();
            if (rcmb_EmployeeName.SelectedIndex > 0)
            {
                _obj_smhr_loanTrans.LOANTRANS_EMP_ID = Convert.ToInt32(rcmb_EmployeeName.SelectedValue);
                _obj_smhr_loanTrans.OPERATION = operation.Get;
                DataTable dt_loantype = BLL.get_EmpLoanDeposits(_obj_smhr_loanTrans);
                if (dt_loantype.Rows.Count > 0)
                {
                    rcmb_loantype.DataSource = dt_loantype;
                    rcmb_loantype.DataTextField = "PAYITEM_PAYITEMNAME";
                    rcmb_loantype.DataValueField = "PAYITEM_ID";
                    rcmb_loantype.DataBind();
                    rcmb_loantype.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
                else
                {
                    rcmb_loantype.Items.Clear();
                    rcmb_loantype.ClearSelection();
                    rcmb_loantype.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    rcmb_loanno.Items.Clear();
                    rcmb_loanno.Text = string.Empty;
                    rcmb_loanno.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    rtxt_Amount.Text = string.Empty;
                    rad_AccumulativeBalance.Text = string.Empty;
                    rad_UpdatedLoanBalance.Text = string.Empty;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanDeposits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    private void Loanno()
    {
        try
        {
            _obj_smhr_loanTrans = new SMHR_LOANTRANS();
            if (rcmb_loantype.SelectedIndex > 0)
            {
                _obj_smhr_loanTrans.LOANTRANS_EMP_ID = Convert.ToInt32(rcmb_EmployeeName.SelectedValue);
                _obj_smhr_loanTrans.LOANTRANS_LOANTYPE_ID = Convert.ToInt32(rcmb_loantype.SelectedValue);
                _obj_smhr_loanTrans.OPERATION = operation.Check1;
                DataTable dt_loanno = BLL.get_EmpLoanDeposits(_obj_smhr_loanTrans);
                if (dt_loanno.Rows.Count > 0)
                {
                    rcmb_loanno.DataSource = dt_loanno;
                    rcmb_loanno.DataTextField = "LOANTRANS_LOANNO";
                    rcmb_loanno.DataValueField = "LOANTRANS_ID";
                    rcmb_loanno.DataBind();
                    rcmb_loanno.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
                else
                {
                    rcmb_loanno.Items.Clear();
                    rcmb_loanno.ClearSelection();
                    rcmb_loanno.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    rtxt_Amount.Text = string.Empty;
                    rad_AccumulativeBalance.Text = string.Empty;
                    rad_UpdatedLoanBalance.Text = string.Empty;
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanDeposits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Command(object sender, EventArgs e)
    {
        try
        {
            clearControls();
            LoadBusinessUint();
            control = Convert.ToString(Request.QueryString["Control"]);
            if (control != null)
            {
            }
            else
            {
                LoadEmployee();
            }
            LoanType();
            Loanno();
            //rdpt_boostdate.MinDate = System.DateTime.Now;
            //rdpt_boostdate.MaxDate = System.DateTime.Now;
            rdpt_boostdate.SelectedDate = System.DateTime.Now;
            rdpt_boostdate.Enabled = false;
            rcmb_BusinessUnit.Enabled = true;
            rcmb_EmployeeName.Enabled = true;
            rcmb_loantype.Enabled = true;
            rcmb_loanno.Enabled = true;
            rtxt_Amount.Enabled = true;
            btn_Save.Visible = true;
            lnk_Apply.Visible = true;

            Rm_LoanDep_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanDeposits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

       
    }
    protected void lnk_View_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Rm_LoanDep_page.SelectedIndex = 1;
            RPV_Loans.Selected = true;
            _obj_smhr_loanTrans = new SMHR_LOANTRANS();

            LoadBusinessUint();
            // LoadEmployee();
            //LoanType();
            //Loanno();
            _obj_smhr_loanTrans.DepositsId = (Convert.ToInt32(Convert.ToString(e.CommandArgument)));
            _obj_smhr_loanTrans.OPERATION = operation.Check_New;
            DataTable dtview = BLL.get_EmpLoanDeposits(_obj_smhr_loanTrans);
            rcmb_BusinessUnit.Enabled = false;
            rcmb_EmployeeName.Enabled = false;
            rcmb_loantype.Enabled = false;
            rcmb_loanno.Enabled = false;
            rtxt_Amount.Enabled = false;
            btn_Save.Visible = false;
            lnk_Apply.Visible = false;
            rdpt_boostdate.Enabled = false;
            if (dtview.Rows.Count > 0)
            {
                rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.FindItemIndexByValue(dtview.Rows[0]["EMP_BUSINESSUNIT_ID"].ToString());
                rcmb_EmployeeName.Text = (dtview.Rows[0]["EmployeeName"].ToString());
                rcmb_loantype.Text = (dtview.Rows[0]["PAYITEM_PAYITEMNAME"].ToString());
                rcmb_loanno.Text = (dtview.Rows[0]["LOANTRANS_LOANNO"].ToString());
                rdpt_boostdate.SelectedDate = Convert.ToDateTime(dtview.Rows[0]["DepositDate"]);
                rtxt_Amount.Value = Convert.ToDouble(dtview.Rows[0]["DepositAmount"]);
                rad_AccumulativeBalance.Value = Convert.ToDouble(dtview.Rows[0]["AccumulativeBal"]);
                rad_UpdatedLoanBalance.Value = Convert.ToDouble(dtview.Rows[0]["UpdatedLoanAmt"]);

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanDeposits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_Apply_Command(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_loanno.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Loan No");
                return;
            }
            if (rad_AccumulativeBalance.Text != string.Empty && rtxt_Amount.Text != string.Empty)
            {
                rad_UpdatedLoanBalance.Text = (Convert.ToDouble(rad_AccumulativeBalance.Text) + Convert.ToDouble(rtxt_Amount.Text)).ToString();
            }
            else
            {
                BLL.ShowMessage(this, "Please enter Boosting Amount");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanDeposits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
     protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (rad_UpdatedLoanBalance.Text != string.Empty)
            {
                _obj_smhr_loanTrans = new SMHR_LOANTRANS();
                _obj_smhr_loanTrans.LOANTRANS_EMP_ID = Convert.ToInt32(rcmb_EmployeeName.SelectedValue);
                _obj_smhr_loanTrans.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                _obj_smhr_loanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_loanTrans.LOANTRANS_LOANNO = Convert.ToString(rcmb_loanno.SelectedItem.Text);
                _obj_smhr_loanTrans.LOANTRANS_LOANTYPE_ID = Convert.ToInt32(rcmb_loantype.SelectedValue);
                _obj_smhr_loanTrans.LOANTRANS_ID = Convert.ToInt32(rcmb_loanno.SelectedValue);
                _obj_smhr_loanTrans.LOANTRANS_LOANAMOUNT = Convert.ToDouble(rtxt_Amount.Text);
                _obj_smhr_loanTrans.CREATEDDATE = System.DateTime.Now;
                //_obj_smhr_loanTrans.CREATEDBY = Convert.ToInt32(Session["EMP_ID"]);
                _obj_smhr_loanTrans.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_loanTrans.UpdatedLoanAmt = Convert.ToDouble(rad_UpdatedLoanBalance.Text);
                _obj_smhr_loanTrans.AccumulativeBalance = Convert.ToDouble(rad_AccumulativeBalance.Text);
                _obj_smhr_loanTrans.OPERATION = operation.Insert;
                if (BLL.set_LoanDeposits(_obj_smhr_loanTrans))
                {
                    BLL.ShowMessage(this, "Record Inserted Successfully");
                }
                else
                {
                    BLL.ShowMessage(this, "Record Not Inserted");
                }
                clearControls();
                LoadGrid();
                Rg_Loandeposits.DataBind();
                Rm_LoanDep_page.SelectedIndex = 0;
            }
            else
            {
                BLL.ShowMessage(this, "Please Click on Apply Link Button");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanDeposits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
     protected void btn_Cancel_Click(object sender, EventArgs e)
     {
         try
         {
             clearControls();
             LoadGrid();
             Rg_Loandeposits.DataBind();
             Rm_LoanDep_page.SelectedIndex = 0;
         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanDeposits", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
        

     }
   
    
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
           if(rcmb_BusinessUnit.SelectedIndex>0)
           {
               LoadEmployee();
               rcmb_loantype.Items.Clear();
               rcmb_loantype.ClearSelection();
               rcmb_loantype.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
               rcmb_loanno.Items.Clear();
               rcmb_loanno.Text = string.Empty;
               rcmb_loanno.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
               rtxt_Amount.Text = string.Empty;
               rad_AccumulativeBalance.Text = string.Empty;
               rad_UpdatedLoanBalance.Text = string.Empty;

           }
           else
           {
               rcmb_EmployeeName.Items.Clear();
               rcmb_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
               rcmb_loantype.Items.Clear();
               rcmb_loantype.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
               rcmb_loanno.Items.Clear();
               rcmb_loanno.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
               rtxt_Amount.Text = string.Empty;
               rad_AccumulativeBalance.Text = string.Empty;
               rad_UpdatedLoanBalance.Text = string.Empty;

           }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
     
   
    protected void rcmb_Employee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_EmployeeName.SelectedIndex > 0)
            {
                LoanType();
                rcmb_loanno.Items.Clear();
                rcmb_loanno.Text = string.Empty;
                rcmb_loanno.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rtxt_Amount.Text = string.Empty;
                rad_AccumulativeBalance.Text = string.Empty;
                rad_UpdatedLoanBalance.Text = string.Empty;
            }
            else
            {
                rcmb_loantype.Items.Clear();
                rcmb_loantype.Text = string.Empty;
                rcmb_loantype.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                
                rcmb_loanno.Items.Clear();
                rcmb_loanno.Text = string.Empty;
                rcmb_loanno.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rtxt_Amount.Text = string.Empty;
                rad_AccumulativeBalance.Text = string.Empty;
                rad_UpdatedLoanBalance.Text = string.Empty;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanDeposits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
   
    protected void rcmb_loantype_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_loantype.SelectedIndex > 0)
            {
                Loanno();
                rtxt_Amount.Text = string.Empty;
                rad_AccumulativeBalance.Text = string.Empty;
                rad_UpdatedLoanBalance.Text = string.Empty;
            }
            else
            {
                rcmb_loanno.Items.Clear();
                rcmb_loanno.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rtxt_Amount.Text = string.Empty;
                rad_AccumulativeBalance.Text = string.Empty;
                rad_UpdatedLoanBalance.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanDeposits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
       

      
    }
    protected void rcmb_loanno_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_loanno.SelectedIndex > 0)
            {
                _obj_smhr_loanTrans = new SMHR_LOANTRANS();
                _obj_smhr_loanTrans.LOANTRANS_ID = Convert.ToInt32(rcmb_loanno.SelectedValue);
                _obj_smhr_loanTrans.OPERATION = operation.Select_New;
                DataTable dtaccbalance = BLL.get_EmpLoanDeposits(_obj_smhr_loanTrans);
                if (dtaccbalance.Rows.Count > 0)
                {
                    rad_AccumulativeBalance.Text = (dtaccbalance.Rows[0]["AccumulativeBalance"].ToString());
                    rad_AccumulativeBalance.Enabled = false;
                }
                else
                {
                    rad_AccumulativeBalance.Value = 0;
                }
                rtxt_Amount.Text = string.Empty;
                rad_UpdatedLoanBalance.Text = string.Empty;



            }
            else
            {
                rtxt_Amount.Text = string.Empty;
                rad_AccumulativeBalance.Text = string.Empty;
                rad_UpdatedLoanBalance.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanDeposits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rtxt_Amount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            rad_UpdatedLoanBalance.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanDeposits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    
    protected void Rg_Loandeposits_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanDeposits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadGrid()
    {
      try
      { 
        control = Convert.ToString(Request.QueryString["Control"]);
        _obj_smhr_loanTrans = new SMHR_LOANTRANS();
        if (Convert.ToInt32(Session["ORG_ID"]) != null)
        {
            _obj_smhr_loanTrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            if (control != null)
            {
                _obj_smhr_loanTrans.LOANTRANS_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            }
            else
           
            _obj_smhr_loanTrans.OPERATION = operation.Select;
            DataTable dtgrid = BLL.get_EmpLoanDeposits(_obj_smhr_loanTrans);
            if(dtgrid.Rows.Count>0)
            Rg_Loandeposits.DataSource = dtgrid;
            else
            {
                DataTable dt = new DataTable();
                Rg_Loandeposits.DataSource = dt;
            }
        }
      }
      catch (Exception ex)
      {
          SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanDeposits", ex.StackTrace, DateTime.Now);
          Response.Redirect("~/Frm_ErrorPage.aspx");
      }


     }
     protected void clearControls()
    {
        try
        {
            rcmb_BusinessUnit.Items.Clear();
            rcmb_EmployeeName.Items.Clear();
            rcmb_loantype.Items.Clear();
            rcmb_loantype.Text = string.Empty;
            rcmb_loanno.Items.Clear();
            rcmb_loanno.Text = string.Empty;
            rtxt_Amount.Text = string.Empty;
            rad_AccumulativeBalance.Text = string.Empty;
            rad_UpdatedLoanBalance.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_LoanDeposits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

}