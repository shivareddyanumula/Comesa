using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class Masters_FORM16 : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_BUSINESSUNITBANK _obj_Smhr_BusinessUnitBank = new SMHR_BUSINESSUNITBANK();
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    SMHR_PERIOD _obj_smhr_period;
    static DataTable dt_Details;
    static DataTable dt_new = new DataTable();
    smhr_Bonus_trans _OBJ_BONUS_TRANS = new smhr_Bonus_trans();
    SMHR_FORMSIXTN _obj_smhr_formsixtn = new SMHR_FORMSIXTN();

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();

    }
    protected void TextValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = (args.Value.Length >= 8);
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("TDS Payment Voucher Information");//Payment Of Form16");

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
                    RG_Formsixtn.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
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
                    return;
                }
                clearFields();
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), txt_Receiveddate);
                BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), RG_Formsixtn, "SMHR_FRMSIXTN_DATEOFPAYMENT");
               }
            }
            catch (Exception ex)
            {
                SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FORM16", ex.StackTrace, DateTime.Now);
                Response.Redirect("~/Frm_ErrorPage.aspx");
                return;
            }

        }

    

    private void LoadCombos()
    {

        try
        {
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BusinessUnit.DataSource = dt_BUDetails;
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FORM16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }

    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BusinessUnit.SelectedIndex != 0)
            {
                _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                _obj_smhr_emp_payitems.OPERATION = operation.Empty;
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                _obj_Smhr_BusinessUnitBank.OPERATION = operation.Empty;
                _obj_Smhr_BusinessUnitBank.BUSUNTBANK_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);

                DataTable dt = BLL.get_BusinessUnitBank(_obj_Smhr_BusinessUnitBank);
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_Employee.Items.Clear();
                    rcmb_Employee.DataSource = dt_Details;
                    rcmb_Employee.DataTextField = "Empname";
                    rcmb_Employee.DataValueField = "EMP_ID";
                    rcmb_Employee.DataBind();
                    rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));

                }
                else
                {
                    rcmb_Employee.Items.Clear();
                    rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                rcmb_Bank.DataSource = dt;
                rcmb_Bank.DataTextField = "BUSUNTBANK_NAME";
                rcmb_Bank.DataValueField = "BUSUNTBANK_ID";
                rcmb_Bank.DataBind();
            }
            else
            {
                rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FORM16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_Employee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            _obj_smhr_period = new SMHR_PERIOD();
            dt_Details = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_SMHR_LoginInfo.LOGIN_ID = 53;
            dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmb_Period.DataSource = dt_Details;
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select"));
            _OBJ_BONUS_TRANS.OPERATION = operation.Login;
            _OBJ_BONUS_TRANS.APPRCYCLE_ID = Convert.ToInt32(Session["EMP_TYPE"]);
            DataTable dt_login = BLL.Get_SMHR_BONUS_TRANS1(_OBJ_BONUS_TRANS);

            if (dt_login.Rows.Count > 0)
            {
                Session["USER_NAME"] = Convert.ToString(dt_login.Rows[0]["LOGTYP_CODE"]);
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FORM16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            bool status = false;
            _obj_smhr_formsixtn.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            _obj_smhr_formsixtn.EMPLOYEE = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
            _obj_smhr_formsixtn.PERIOD = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
            _obj_smhr_formsixtn.AMOUNT = rtxt_Amount.Text;
            if (Convert.ToDateTime(txt_Receiveddate.SelectedDate.Value) <= System.DateTime.Now)
            {
                _obj_smhr_formsixtn.PAYMENT_DATE = Convert.ToDateTime(txt_Receiveddate.SelectedDate.Value);
            }
            else
            {
                BLL.ShowMessage(this, "Payment date cannot be ahead of Today Date");
                return;
            }
            //_obj_smhr_formsixtn._PAYMENT_DATE = Convert.ToDateTime(txt_Receiveddate.SelectedDate.Value);
            _obj_smhr_formsixtn.CHALLAN_NUMBER = rtxt_ChalanNumber.Text;
            _obj_smhr_formsixtn.BANK = Convert.ToInt32(rcmb_Bank.SelectedItem.Value);
            _obj_smhr_formsixtn.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_formsixtn.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_formsixtn.CREATEDDATE = DateTime.Now;
            _obj_smhr_formsixtn.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_formsixtn.LASTMDFDATE = DateTime.Now;
            _obj_smhr_formsixtn.STATUS = Convert.ToInt16(rcmb_Status.SelectedItem.Value);
            _obj_smhr_formsixtn.OPERATION = operation.Select;
            dt_new = BLL.set_Selectnew(_obj_smhr_formsixtn);
            if (Convert.ToString(dt_new.Rows[0][0]) == "TRUE")
            {
                BLL.ShowMessage(this, "Employee Chalan Details Already Exists");
                RMP_Formsixtn.SelectedIndex = 0;
                LoadGrid();
                RMP_Formsixtn.DataBind();
                return;
            }

            else
            {
                _obj_smhr_formsixtn.OPERATION = operation.Insert;
                status = BLL.set_TDSPAYMENTVOUCHER(_obj_smhr_formsixtn);
                if (status == true)
                {
                    BLL.ShowMessage(this, "Employee Chalan Details Inserted Successfully");
                    RMP_Formsixtn.SelectedIndex = 0;
                    LoadGrid();
                    RMP_Formsixtn.DataBind();
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FORM16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void lnk_AssetDoc_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            btn_Save.Visible = false;
            btn_Update.Visible = true;
            RMP_Formsixtn.SelectedIndex = 1;
            clearFields();
            int id = Convert.ToInt32(e.CommandArgument);
            lbl_Id.Text = Convert.ToString(id);
            _obj_smhr_formsixtn.Id = id;
            _obj_smhr_formsixtn.OPERATION = operation.Edit;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            dt = BLL.get_TDSPAYMENTVOUCHER(_obj_smhr_formsixtn);
            // rcmb_BusinessUnit.DataSource = dt;
            // rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            // rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_CODE";
            // rcmb_BusinessUnit.DataBind();
            // rcmb_BusinessUnit.Enabled = false;
            LoadCombos();
            rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SMHR_FRMSIXTN_BUSINESSUNIT"]));
            rcmb_BusinessUnit.Enabled = false;
            rcmb_Employee.DataSource = dt;
            rcmb_Employee.DataTextField = "EMPLOYEENAME";
            rcmb_Employee.DataValueField = "EMPLOYEENAME";
            rcmb_Employee.DataBind();
            rcmb_Employee.Enabled = false;
            rcmb_Period.DataSource = dt;
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataValueField = "PERIOD_NAME";
            rcmb_Period.DataBind();
            rtxt_Amount.Text = Convert.ToString(dt.Rows[0]["SMHR_FRMSIXTN_AMOUNT"]);
            string str = Convert.ToString(dt.Rows[0]["SMHR_FRMSIXTN_DATEOFPAYMENT"]);

            if (string.IsNullOrEmpty(str))
            {


            }
            else
            {
                txt_Receiveddate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["SMHR_FRMSIXTN_DATEOFPAYMENT"]);
            }
            rcmb_Bank.DataSource = dt;
            rcmb_Bank.DataTextField = "BUSUNTBANK_NAME";
            rcmb_Bank.DataValueField = "BUSUNTBANK_NAME";
            rcmb_Bank.DataBind();
            rcmb_Bank.Enabled = false;
            rtxt_ChalanNumber.Text = Convert.ToString(dt.Rows[0]["SMHR_FRMSIXTN_CHALAN_NO"]);
            string str2 = Convert.ToString(dt.Rows[0]["SMHR_FRMSIXTN_STATUS"]);
            if (string.IsNullOrEmpty(str))
            {

            }
            else
            {
                if (Convert.ToBoolean(dt.Rows[0]["SMHR_FRMSIXTN_STATUS"]) == false)
                {
                    rcmb_Status.SelectedValue = "0";

                }

                else
                {
                    rcmb_Status.SelectedValue = "1";
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FORM16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    protected void RG_FormSixtn_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FORM16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rcmb_Bank.Enabled = true;
            btn_Save.Visible = true;
            btn_Update.Visible = false;
            rcmb_BusinessUnit.Enabled = true;
            rcmb_Employee.Enabled = true;
            clearFields();
            RMP_Formsixtn.SelectedIndex = 1;
            LoadCombos();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FORM16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    public void LoadGrid()
    {
        try
        {
            _obj_smhr_formsixtn.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_formsixtn.OPERATION = operation.Select;
            DataTable dt = new DataTable();
            dt = BLL.get_TDSPAYMENTVOUCHER(_obj_smhr_formsixtn);
            RG_Formsixtn.DataSource = dt;
            //BLL.set_Insert(_obj_smhr_formsixtn);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FORM16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {

            bool status = false;
            _obj_smhr_formsixtn.AMOUNT = rtxt_Amount.Text;
            _obj_smhr_formsixtn.Id = Convert.ToInt32(lbl_Id.Text);
            if (Convert.ToDateTime(txt_Receiveddate.SelectedDate.Value) <= System.DateTime.Now)
            {
                _obj_smhr_formsixtn.PAYMENT_DATE = Convert.ToDateTime(txt_Receiveddate.SelectedDate.Value);
            }
            else
            {
                BLL.ShowMessage(this, "Payment date cannot be ahead of Today Date");
                return;
            }
            //_obj_smhr_formsixtn._PAYMENT_DATE = Convert.ToDateTime(txt_Receiveddate.SelectedDate.Value);
            _obj_smhr_formsixtn.CHALLAN_NUMBER = Convert.ToString(rtxt_ChalanNumber.Text);
            // _obj_smhr_formsixtn._BANK = Convert.ToInt32(rcmb_Bank.SelectedItem.Value);
            _obj_smhr_formsixtn.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_formsixtn.OPERATION = operation.Update;
            _obj_smhr_formsixtn.STATUS = Convert.ToInt16(rcmb_Status.SelectedItem.Value);
            status = BLL.set_TDSPAYMENTVOUCHER(_obj_smhr_formsixtn);
            if (status == true)
            {
                BLL.ShowMessage(this, "Employee Chalan Details Updated Successfully");
                RMP_Formsixtn.SelectedIndex = 0;
                LoadGrid();
                RMP_Formsixtn.DataBind();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FORM16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    public void clearFields()
    {
        try
        {
            rcmb_BusinessUnit.SelectedIndex = -1;
            rcmb_Employee.Items.Clear();
            rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
            rcmb_Status.SelectedIndex = -1;
            rtxt_Amount.Text = "";
            rcmb_Period.Items.Clear();
            rcmb_Bank.Items.Clear();
            rtxt_ChalanNumber.Text = "";
            txt_Receiveddate.SelectedDate = null;
            rcmb_Employee.ClearSelection();//newly
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FORM16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RMP_Formsixtn.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FORM16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }



}



