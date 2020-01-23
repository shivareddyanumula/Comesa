using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;

public partial class Payroll_frm_DirectPay : System.Web.UI.Page
{
    SMHR_DIRECTPAYMENTS _obj_smhr_Directpmts;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    static string _lbl_ID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("DIRECT PAYMENTS");
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
                    RG_DirectPayments.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Correct.Visible = false;
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
                btn_Correct.Visible = false;
                cheque.Visible = false;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DirectPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    private void LoadDetails()
    {
        try
        {
            _obj_smhr_Directpmts = new SMHR_DIRECTPAYMENTS();
            _obj_smhr_Directpmts.Mode = 1;
            _obj_smhr_Directpmts.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_DirectPayments(_obj_smhr_Directpmts);
            RG_DirectPayments.DataSource = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DirectPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_DirectPayments_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadDetails();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DirectPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Click(object sender, EventArgs e)
    {
        try
        {
            RMP_DirectPayments.SelectedIndex = 1;
            btn_Correct.Visible = false;
            btn_Save.Visible = true;
            LoadCombos();
            ClearFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DirectPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearFields();
            RMP_DirectPayments.SelectedIndex = 1;

            _lbl_ID = Convert.ToString(e.CommandArgument);
            LoadCombos();
            getDetails(_lbl_ID);
            if (ddl_paymentType.SelectedItem.Text.ToUpper() != "CHEQUE")
            {
                cheque.Visible = false;
            }

            _obj_smhr_Directpmts = new SMHR_DIRECTPAYMENTS();
            _obj_smhr_Directpmts.Mode = 2;
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_ID = Convert.ToInt32(_lbl_ID);
            DataTable dt = BLL.get_DirectPayments(_obj_smhr_Directpmts);
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Correct.Visible = false;

            }

            else
            {
                if ((Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 2) || (Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 3))
                {
                    btn_Correct.Visible = false;
                }
                else
                {
                    btn_Correct.Visible = true;
                }
            }
            if (ddl_Employee.SelectedItem.Text == "Select")
            {

                BLL.ShowMessage(this, "You Cannot Update Resigned Employee");
                btn_Correct.Visible = false;

            }

            btn_Save.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DirectPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_Directpmts = new SMHR_DIRECTPAYMENTS();
            _obj_smhr_Directpmts.Mode = 3;
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_EMPID = Convert.ToInt32(ddl_Employee.SelectedValue);
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_ISSUEDT = Convert.ToDateTime(rdp_Issuedate.SelectedDate.Value);
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_AMOUNT = Convert.ToDouble(rntxt_Amount.Value);
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_REMARKS = Convert.ToString(txt_Remarks.Text.Replace("'", "''"));
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_TYPE = Convert.ToInt32(ddl_paymentType.SelectedValue);
            if (txt_ChequeNumber.Value != null)
                _obj_smhr_Directpmts.SMHR_CHEQUENUMBER = Convert.ToDouble(txt_ChequeNumber.Value);
            else
                _obj_smhr_Directpmts.SMHR_CHEQUENUMBER = 0;
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_CREATEDBY = Convert.ToInt32(Convert.ToString(Session["USER_ID"]));
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_CREATEDDATE = DateTime.Now;
            _obj_smhr_Directpmts.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            bool status = BLL.set_DirectPayments(_obj_smhr_Directpmts);
            if (status == true)
            {
                BLL.ShowMessage(this, "Information Saved Successfully");
                RMP_DirectPayments.SelectedIndex = 0;
                LoadDetails();
                RG_DirectPayments.DataBind();
                ClearFields();
                return;
            }
            else
            {
                BLL.ShowMessage(this, "An Error Occured while doing the process");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DirectPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_Directpmts = new SMHR_DIRECTPAYMENTS();
            _obj_smhr_Directpmts.Mode = 4;
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_ID = Convert.ToInt32(_lbl_ID);
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_EMPID = Convert.ToInt32(ddl_Employee.SelectedValue);
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_ISSUEDT = Convert.ToDateTime(rdp_Issuedate.SelectedDate.Value);
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_AMOUNT = Convert.ToDouble(rntxt_Amount.Value);
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_REMARKS = Convert.ToString(txt_Remarks.Text.Replace("'", "''"));
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_TYPE = Convert.ToInt32(ddl_paymentType.SelectedValue);
            if (txt_ChequeNumber.Value != null)
                _obj_smhr_Directpmts.SMHR_CHEQUENUMBER = Convert.ToDouble(txt_ChequeNumber.Value);
            else
                _obj_smhr_Directpmts.SMHR_CHEQUENUMBER = 0;
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_LASTMDFBY = Convert.ToInt32(Convert.ToString(Session["USER_ID"]));
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_LASTMDFDATE = DateTime.Now;
            bool status = BLL.set_DirectPayments(_obj_smhr_Directpmts);
            if (status == true)
            {
                BLL.ShowMessage(this, "Information Updated Successfully");
                RMP_DirectPayments.SelectedIndex = 0;
                LoadDetails();
                RG_DirectPayments.DataBind();
                ClearFields();
                return;
            }
            else
            {
                BLL.ShowMessage(this, "An Error Occured while doing the process");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DirectPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RMP_DirectPayments.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DirectPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            ddl_BusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            ddl_BusinessUnit.DataSource = dt_BUDetails;
            ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            ddl_BusinessUnit.DataBind();
            ddl_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DirectPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ddl_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_BusinessUnit.SelectedIndex != 0)
            {
                LoadEmployee(Convert.ToString(ddl_BusinessUnit.SelectedValue));
                LoadPaymentType();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DirectPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearFields()
    {
        try
        {
            ddl_BusinessUnit.SelectedIndex = -1;
            ddl_Employee.Items.Clear();
            ddl_Employee.Items.Insert(0, new RadComboBoxItem());
            txt_Remarks.Text = string.Empty;
            rntxt_Amount.Value = null;
            rdp_Issuedate.SelectedDate = null;
            ddl_Employee.Enabled = true;
            ddl_paymentType.Items.Clear();
            ddl_paymentType.Items.Insert(0, new RadComboBoxItem());
            ddl_BusinessUnit.Enabled = true;
            rntxt_Amount.Enabled = true;
            rdp_Issuedate.Enabled = true;
            ddl_paymentType.Enabled = true;
            txt_ChequeNumber.Enabled = true;
            txt_ChequeNumber.Text = string.Empty;
            cheque.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DirectPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void getDetails(string ID)
    {
        try
        {
            _obj_smhr_Directpmts = new SMHR_DIRECTPAYMENTS();
            _obj_smhr_Directpmts.Mode = 2;
            _obj_smhr_Directpmts.SMHR_DIRECTPMT_ID = Convert.ToInt32(ID);
            DataTable dt = BLL.get_DirectPayments(_obj_smhr_Directpmts);
            if (dt.Rows.Count != 0)
            {
                ddl_BusinessUnit.SelectedIndex = ddl_BusinessUnit.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SMHR_DIRECTPMT_BUID"]));
                LoadPaymentType();
                if ((Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 0) || (Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 1))
                {
                    LoadEmployee(Convert.ToString(dt.Rows[0]["SMHR_DIRECTPMT_BUID"]));
                    ddl_Employee.SelectedIndex = ddl_Employee.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SMHR_DIRECTPMT_EMPID"]));
                }
                else if ((Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 2) || (Convert.ToInt32(dt.Rows[0]["EMP_STATUS"]) == 3))
                {
                    _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                    _obj_smhr_emp_payitems.OPERATION = operation.EMPTY_R;
                    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(ID);
                    _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                    if (dt_Details.Rows.Count != 0)
                    {
                        ddl_Employee.Items.Clear();
                        ddl_Employee.DataSource = dt_Details;
                        ddl_Employee.DataTextField = "Empname";
                        ddl_Employee.DataValueField = "EMP_ID";
                        ddl_Employee.DataBind();
                        ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                        rdp_Issuedate.SelectedDate = DateTime.Now;
                    }
                    ddl_Employee.SelectedIndex = ddl_Employee.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SMHR_DIRECTPMT_EMPID"]));
                }

                rdp_Issuedate.SelectedDate = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["SMHR_DIRECTPMT_ISSUEDT"]));
                rntxt_Amount.Value = Convert.ToDouble(Convert.ToString(dt.Rows[0]["SMHR_DIRECTPMT_AMOUNT"]));
                txt_Remarks.Text = Convert.ToString(dt.Rows[0]["SMHR_DIRECTPMT_REMARKS"]);
                ddl_paymentType.SelectedIndex = ddl_paymentType.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SMHR_DIRECTPMT_TYPE"]));
                if (dt.Rows[0]["SMHR_DIRECTPMT_CHEQUE"] != null)
                {
                    txt_ChequeNumber.Value = Convert.ToDouble(dt.Rows[0]["SMHR_DIRECTPMT_CHEQUE"]);
                    cheque.Visible = true;
                }
                ddl_Employee.Enabled = false;
                ddl_BusinessUnit.Enabled = false;
                rntxt_Amount.Enabled = false;
                rdp_Issuedate.Enabled = false;
                ddl_paymentType.Enabled = false;
                txt_ChequeNumber.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DirectPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployee(string ID)
    {
        try
        {
            _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            _obj_smhr_emp_payitems.OPERATION = operation.Empty;
            _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(ID);
            _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
            if (dt_Details.Rows.Count != 0)
            {
                ddl_Employee.Items.Clear();
                ddl_Employee.DataSource = dt_Details;
                ddl_Employee.DataTextField = "Empname";
                ddl_Employee.DataValueField = "EMP_ID";
                ddl_Employee.DataBind();
                ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                rdp_Issuedate.SelectedDate = DateTime.Now;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DirectPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadPaymentType()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_businessunit.OPERATION = operation.Empty;
            _obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_BusinessUnit(_obj_smhr_businessunit);

            ddl_paymentType.DataSource = dt;
            ddl_paymentType.DataTextField = "HR_MASTER_CODE";
            ddl_paymentType.DataValueField = "HR_MASTER_ID";
            ddl_paymentType.DataBind();
            ddl_paymentType.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DirectPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void ddl_paymentType_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_paymentType.SelectedItem.Text.ToUpper() == "CHEQUE")
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DirectPay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
