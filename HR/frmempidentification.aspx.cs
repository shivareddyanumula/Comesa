using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using SMHR;
using System.IO;
using System.Text;
using Telerik.Web.UI;

public partial class HR_frmempidentification : System.Web.UI.Page
{
    SMHR_EMPBNKDTLS _obj_smhr_empbnkdetails;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_MASTERS _obj_Smhr_Masters;
    SMHR_BANKBRANCH _obj_Smhr_BankBanch;

    static string _lbl_ID = "";
    static string _lblEmpID = "";

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RMP_Identification.SelectedIndex = 0;
                LoadData();
                RG_Identification.DataBind();
                MarkData();
                tr1.Visible = false;
            }
            default1.Visible = false;

            Session.Remove("WRITEFACILITY");

            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("IDENTIFICATION");
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
                RG_Identification.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Add.Visible = false;
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
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempidentification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadData()
    {
        try
        {
            if (Session["SELFSERVICE"] == "")
            {
                _obj_smhr_empbnkdetails = new SMHR_EMPBNKDTLS();
                _obj_smhr_empbnkdetails.OPERATION = operation.Select;
                _obj_smhr_empbnkdetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_Identification(_obj_smhr_empbnkdetails);
                RG_Identification.DataSource = dt;
            }
            else
            {
                _obj_smhr_empbnkdetails = new SMHR_EMPBNKDTLS();
                _obj_smhr_empbnkdetails.OPERATION = operation.Check;
                _obj_smhr_empbnkdetails.EMPBNKDTLS_EMPID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_smhr_empbnkdetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_BankDetCheck(_obj_smhr_empbnkdetails);
                RG_Identification.DataSource = dt;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempidentification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Click(object sender, EventArgs e)
    {
        try
        {

            RMP_Identification.SelectedIndex = 1;
            btn_Correct.Visible = false;
            btn_Add.Visible = true;
            LoadCombos();
            rcmb_BusinessUnit.Enabled = true;
            rcmb_Employee.Enabled = true;
            clearFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempidentification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            RMP_Identification.SelectedIndex = 1;

            LoadCombos();
            _lbl_ID = Convert.ToString(e.CommandArgument);
            getDetails(_lbl_ID);
            rcmb_BusinessUnit.Enabled = false;
            rcmb_Employee.Enabled = false;
            btn_Add.Visible = false;

            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {

                btn_Correct.Visible = false;

            }

            else
            {
                btn_Correct.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempidentification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Identification_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        LoadData();

    }

    private void LoadCombos()
    {
        try
        {
            rcmb_Employee.Items.Clear();
            rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
            //Business Unit
            rcmb_BusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BusinessUnit.DataSource = dt_BUDetails;
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));

            rcmb_Bank.Items.Clear();
            _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.MASTER_TYPE = "BANK";
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Masters.OPERATION = operation.Select;
            DataTable dt_Details = new DataTable();
            dt_Details = BLL.get_MasterRecords(_obj_Smhr_Masters);
            rcmb_Bank.DataSource = dt_Details;
            rcmb_Bank.DataTextField = "HR_MASTER_CODE";
            rcmb_Bank.DataValueField = "HR_MASTER_ID";
            rcmb_Bank.DataBind();
            rcmb_Bank.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempidentification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void LoadEmployees()
    {
        try
        {
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            _obj_smhr_emp_payitems.OPERATION = operation.Empty;
            if (rcmb_BusinessUnit.SelectedItem.Value != "")
            {
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                DataTable DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                if (DT_Details.Rows.Count != 0)
                {
                    rcmb_Employee.DataSource = DT_Details;
                    rcmb_Employee.DataTextField = "EMPNAME";
                    rcmb_Employee.DataValueField = "EMP_ID";
                    rcmb_Employee.DataBind();
                    rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                else
                {
                    rcmb_Employee.DataSource = DT_Details;
                    rcmb_Employee.DataTextField = "EMPNAME";
                    rcmb_Employee.DataValueField = "EMP_ID";
                    rcmb_Employee.DataBind();
                    rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                }
            }
            else
            {
                rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempidentification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Add_Click(object sender, EventArgs e)
    {
        try
        {
            bool status1 = chkAcctNo();
            if (status1 == false)
            {
                if (rtxt_AccountNo.Text.Length != 12)
                {
                    BLL.ShowMessage(this, "Account Number Should be 12 Chars Length");
                    return;
                }
                _obj_smhr_empbnkdetails = new SMHR_EMPBNKDTLS();
                _obj_smhr_empbnkdetails.OPERATION = operation.Insert;
                _obj_smhr_empbnkdetails.EMPBNKDTLS_EMPID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
                _obj_smhr_empbnkdetails.BUSUNITBANK_BANKID = Convert.ToInt32(rcmb_Bank.SelectedItem.Value);
                _obj_smhr_empbnkdetails.BUSUNITBANK_BRANCHID = Convert.ToInt32(rcmb_Branch.SelectedItem.Value);
                _obj_smhr_empbnkdetails.BUSUNTBANK_ADDRESS = Convert.ToString(rtxt_Address.Text.Replace("'", "''"));
                _obj_smhr_empbnkdetails.BUSUNTBANK_ACCOUNTNO = Convert.ToString(rtxt_AccountNo.Text);
                _obj_smhr_empbnkdetails.BUSUNTBANK_SWIFT = Convert.ToString(rtxt_SwiftCode.Text.Replace("'", "''"));
                if (rcmb_Active.SelectedValue == "1")
                    _obj_smhr_empbnkdetails.BUSUNTBANK_ISACTIVE = true;
                else
                    _obj_smhr_empbnkdetails.BUSUNTBANK_ISACTIVE = false;

                if (chk_Default.Checked)
                    _obj_smhr_empbnkdetails.BUSUNTBANK_ISDEFAULT = true;
                else
                    _obj_smhr_empbnkdetails.BUSUNTBANK_ISDEFAULT = false;
                _obj_smhr_empbnkdetails.BUSUNTBANK_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_empbnkdetails.BUSUNTBANK_CREATEDDATE = DateTime.Now;
                _obj_smhr_empbnkdetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                bool status = BLL.set_Identification(_obj_smhr_empbnkdetails);
                if (status == true)
                {
                    BLL.ShowMessage(this, "Employee Bank Details Saved Successfully");
                    LoadData();
                    RG_Identification.DataBind();
                    MarkData();
                    RMP_Identification.SelectedIndex = 0;
                    return;
                }
                else
                {
                    BLL.ShowMessage(this, "Error Occured while doing the Process");
                    return;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Account Number is already Defined");
                rtxt_AccountNo.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempidentification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            if (rtxt_AccountNo.Text.Length != 12)
            {
                BLL.ShowMessage(this, "Account Number Should be 12 Chars Length");
                return;
            }
            _obj_smhr_empbnkdetails = new SMHR_EMPBNKDTLS();
            _obj_smhr_empbnkdetails.OPERATION = operation.Update;
            _obj_smhr_empbnkdetails.EMPBNKDTLS_EMPID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
            _obj_smhr_empbnkdetails.BUSUNITBANK_BANKID = Convert.ToInt32(rcmb_Bank.SelectedItem.Value);
            _obj_smhr_empbnkdetails.BUSUNITBANK_BRANCHID = Convert.ToInt32(rcmb_Branch.SelectedItem.Value);
            _obj_smhr_empbnkdetails.BUSUNTBANK_ADDRESS = Convert.ToString(rtxt_Address.Text.Replace("'", "''"));
            _obj_smhr_empbnkdetails.BUSUNTBANK_ACCOUNTNO = Convert.ToString(rtxt_AccountNo.Text);
            _obj_smhr_empbnkdetails.BUSUNTBANK_SWIFT = Convert.ToString(rtxt_SwiftCode.Text.Replace("'", "''"));
            if (rcmb_Active.SelectedValue == "1")
                _obj_smhr_empbnkdetails.BUSUNTBANK_ISACTIVE = true;
            else
                _obj_smhr_empbnkdetails.BUSUNTBANK_ISACTIVE = false;

            if (chk_Default.Checked)
                _obj_smhr_empbnkdetails.BUSUNTBANK_ISDEFAULT = true;
            else
                _obj_smhr_empbnkdetails.BUSUNTBANK_ISDEFAULT = false;
            _obj_smhr_empbnkdetails.BUSUNTBANK_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_empbnkdetails.BUSUNTBANK_LASTMDFDATE = DateTime.Now;
            _obj_smhr_empbnkdetails.EMPBNKDTLS_ID = Convert.ToInt32(_lbl_ID);
            _obj_smhr_empbnkdetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            bool status = BLL.set_Identification(_obj_smhr_empbnkdetails);
            if (status == true)
            {
                BLL.ShowMessage(this, "Employee Bank Details Updated Successfully");
                LoadData();
                RG_Identification.DataBind();
                MarkData();
                RMP_Identification.SelectedIndex = 0;
                return;
            }
            else
            {
                BLL.ShowMessage(this, "Error Occured while doing the Process");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempidentification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void getDetails(string ID)
    {
        try
        {
            _obj_smhr_empbnkdetails = new SMHR_EMPBNKDTLS();
            _obj_smhr_empbnkdetails.OPERATION = operation.Select;
            _obj_smhr_empbnkdetails.EMPBNKDTLS_ID = Convert.ToInt32(ID);
            _obj_smhr_empbnkdetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_Identification(_obj_smhr_empbnkdetails);
            if (dt.Rows.Count != 0)
            {
                SMHR_EMPASSETDOC _obj_smhr_empassetdoc = new SMHR_EMPASSETDOC();
                _obj_smhr_empassetdoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(dt.Rows[0]["EMPBNKDTLS_EMPID"]);
                _obj_smhr_empassetdoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Details = BLL.get_EmpAssetDocBU(_obj_smhr_empassetdoc);
                rcmb_BusinessUnit.SelectedValue = Convert.ToString(dt_Details.Rows[0][0]);
                LoadEmployees();
                _lblEmpID = Convert.ToString(dt.Rows[0]["EMPBNKDTLS_EMPID"]);
                rcmb_Employee.SelectedIndex = rcmb_Employee.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPBNKDTLS_EMPID"]));
                rcmb_Bank.SelectedIndex = rcmb_Bank.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSUNTBANK_ID"]));
                rcmb_Bank_SelectedIndexChanged(null, null);
                rtxt_Address.Text = Convert.ToString(dt.Rows[0]["BRANCH_ADDRESS"]);
                rcmb_Branch.SelectedIndex = rcmb_Branch.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSUNTBANK_BRANCHID"]));
                rtxt_AccountNo.Text = Convert.ToString(dt.Rows[0]["BUSUNTBANK_ACCOUNTNO"]);
                rtxt_SwiftCode.Text = Convert.ToString(dt.Rows[0]["BUSUNTBANK_SWIFT"]);
                if (Convert.ToBoolean(dt.Rows[0]["BUSUNTBANK_ISACTIVE"]) == true)
                    rcmb_Active.SelectedValue = "1";
                else
                    rcmb_Active.SelectedValue = "0";
                //chk_Active.Checked = Convert.ToBoolean(dt.Rows[0]["BUSUNTBANK_ISACTIVE"]);
                chk_Default.Checked = Convert.ToBoolean(dt.Rows[0]["BUSUNTBANK_ISDEFAULT"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempidentification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RMP_Identification.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempidentification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearFields()
    {
        rcmb_Employee.SelectedIndex = 0;
        rcmb_BusinessUnit.SelectedIndex = 0;
        rtxt_AccountNo.Text = null;
        rtxt_Address.Text = string.Empty;
        rcmb_Bank.SelectedIndex = 0;
        //chk_Active.Checked = false;
        rcmb_Active.SelectedValue = "1";
        chk_Default.Checked = false;
        rtxt_SwiftCode.Text = string.Empty;
        rcmb_Branch.SelectedIndex = 0;
        rcmb_Employee.Enabled = true;
    }

    private void MarkData()
    {
        try
        {
            int index;
            for (index = 0; index < RG_Identification.Items.Count; index++)
            {
                string str = Convert.ToString(RG_Identification.Items[index].Cells[6].Text);
                string str1 = str.Substring(str.Length - 4);
                string str2 = str.Substring(0, str.Length - 4);
                string str3 = "";
                for (int i = 0; i < str2.Length; i++)
                {
                    if (str3 == "")
                        str3 = "X";
                    else
                        str3 = str3 + "X";
                }
                string Final = str3 + str1;
                RG_Identification.Items[index].Cells[6].Text = Convert.ToString(Final);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempidentification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private bool chkAcctNo()
    {
        
        try
        {
            _obj_smhr_empbnkdetails = new SMHR_EMPBNKDTLS();
            _obj_smhr_empbnkdetails.OPERATION = operation.Empty;
            _obj_smhr_empbnkdetails.BUSUNTBANK_ACCOUNTNO = Convert.ToString(rtxt_AccountNo.Text.Replace("'", "''"));
            DataTable dt = new DataTable();
            _obj_smhr_empbnkdetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt = BLL.get_BankDetCheck(_obj_smhr_empbnkdetails);
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            

        }
           
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempidentification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return false;
        }
        
    }

    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_Employee.Items.Clear();
            LoadEmployees();
            if (Session["SELFSERVICE"] != "")
            {
                rcmb_Employee.SelectedIndex = rcmb_Employee.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));
                rcmb_Employee.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempidentification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void rcmb_Bank_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Bank.SelectedIndex != 0)
            {
                _obj_Smhr_BankBanch = new SMHR_BANKBRANCH();
                _obj_Smhr_BankBanch.BRANCH_BANK_ID = Convert.ToInt32(rcmb_Bank.SelectedItem.Value);
                _obj_Smhr_BankBanch.OPERATION = operation.Empty;
                DataTable DT = new DataTable();
                rcmb_Branch.Items.Clear();
                _obj_Smhr_BankBanch.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                rcmb_Branch.DataSource = BLL.get_BankBranch(_obj_Smhr_BankBanch);
                rcmb_Branch.DataTextField = "BRANCH_CODE";
                rcmb_Branch.DataValueField = "BRANCH_ID";
                rcmb_Branch.DataBind();
                rcmb_Branch.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempidentification", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
