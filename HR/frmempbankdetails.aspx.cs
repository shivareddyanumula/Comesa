﻿using System;
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
    SMHR_BUSINESSUNIT _obj_smhr_BusinessUnit;
    string Control;
    static string _lbl_ID = "";
    static string _lblEmpID = "";

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Control = Convert.ToString(Request.QueryString["Control"]);
        try
        {
            if (!Page.IsPostBack)
            {
                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                if (Control != null)
                {
                    if (Control.ToUpper() == "SELFBANKDETAILS")
                    {
                        _obj_Smhr_LoginInfo.LOGIN_ID = 12;
                        _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE BANK DETAILS");
                    }

                }
                else
                {
                    _obj_Smhr_LoginInfo.LOGIN_ID = 2;
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE BANK DETAILS");
                }
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE BANK DETAILS");
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
                    btn_Correct.Visible = false;
                    // btn_Update.Visible = false;
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

                RMP_Identification.SelectedIndex = 0;
                if (Control != null && Convert.ToInt32(Session["EMP_ID"]) == 0)
                    BLL.ShowMessage(this, "You do not have Access on this Screen.");
                LoadData();
                MarkData();
                RG_Identification.DataBind();
                tr1.Visible = false;


            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }



        //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
        //{
        //    RG_Identification.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
        //    btn_Add.Visible = false;
        //    btn_Correct.Visible = false;
        //}
        //default1.Visible = false;
    }
    #region Loaddata
    /// <summary>
    /// Loading The Previously Added Bank Information
    /// </summary>
    private void LoadData()
    {
        try
        {
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                RG_Identification.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Add.Visible = false;
                btn_Correct.Visible = false;
            }
            if (Control != null)
            {
                if ((Convert.ToString(Session["SELFSERVICE"]) == "true" && Control.ToUpper() == "SELFBANKDETAILS") || (Convert.ToString(Session["SELFSERVICE"]) == "" && Control.ToUpper() == "SELFBANKDETAILS"))
                {
                    _obj_smhr_empbnkdetails = new SMHR_EMPBNKDTLS();
                    _obj_smhr_empbnkdetails.OPERATION = operation.Check;
                    _obj_smhr_empbnkdetails.EMPBNKDTLS_EMPID = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_smhr_empbnkdetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt = BLL.get_BankDetCheck(_obj_smhr_empbnkdetails);
                    RG_Identification.DataSource = dt;
                    
                    Session["BANK"] = string.Empty;
                }
                else
                {
                    RG_Identification.DataSource = null;
                    RG_Identification.Visible = false;
                    //BLL.ShowMessage(this, "You do not have Access on this Screen.");
                    return;
                }
            }
            else
            {
                _obj_smhr_empbnkdetails = new SMHR_EMPBNKDTLS();
                _obj_smhr_empbnkdetails.OPERATION = operation.Select;
                _obj_smhr_empbnkdetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_empbnkdetails.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                DataTable dt = BLL.get_Identification(_obj_smhr_empbnkdetails);
                Session["BANK"] = dt;
                //RG_Identification.DataSource = dt;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

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
            rcmb_Bank.Enabled = true;
            rcmb_Branch.Enabled = true;
            rtxt_AccountNo.Enabled = true;
            rtxt_SwiftCode.Enabled = true;
            clearFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {

            RMP_Identification.SelectedIndex = 1;
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Correct.Visible = false;

            }

            else
            {
                //if (Convert.ToInt32(Session["EMP_ID"]) > 0)
                //if (Convert.ToString(Session["SELFSERVICE"]) == "true")
                if (Control != null)
                {
                    btn_Correct.Visible = false;
                }
                else
                {
                    btn_Correct.Visible = true;
                }
            }

            LoadCombos();
            //_lbl_ID = Convert.ToString(e.CommandArgument);
            HF_ID.Value = Convert.ToString(e.CommandArgument);
            getDetails(HF_ID.Value);
            rcmb_BusinessUnit.Enabled = false;
            rcmb_Employee.Enabled = false;
            rcmb_Bank.Enabled = false;
            rcmb_Branch.Enabled = false;
            rtxt_AccountNo.Enabled = true;
            rtxt_SwiftCode.Enabled = false;
            btn_Add.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Identification_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadData();
            MarkData();
            //RG_Identification.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
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
            rcmb_Bank.DataTextField = "NAME";
            rcmb_Bank.DataValueField = "HR_MASTER_ID";
            rcmb_Bank.DataBind();
            rcmb_Bank.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void LoadEmployees()
    {
        try  //sravani 05.02.2011
        {
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            //_obj_smhr_emp_payitems.OPERATION = operation.Empty;
            if (rcmb_BusinessUnit.SelectedItem.Value != "")
            {
                //FOR MANAGER
                //if (Convert.ToString(Session["SELFSERVICE"]) == "")
                //{
                //    _obj_smhr_emp_payitems.OPERATION = operation.Empty_Self;
                //    _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                //    _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    _obj_smhr_emp_payitems.REPORTING_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                //    DataTable DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                //    if (DT_Details.Rows.Count != 0)
                //    {
                //        rcmb_Employee.DataSource = DT_Details;
                //        rcmb_Employee.DataTextField = "EMPNAME";
                //        rcmb_Employee.DataValueField = "EMP_ID";
                //        rcmb_Employee.DataBind();
                //        rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                //    }
                //    else
                //    {
                //        rcmb_Employee.DataSource = DT_Details;
                //        rcmb_Employee.DataTextField = "EMPNAME";
                //        rcmb_Employee.DataValueField = "EMP_ID";
                //        rcmb_Employee.DataBind();
                //        rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                //    }
                //}
                //else
                //{
                //FOR ADMIN
                _obj_smhr_emp_payitems.OPERATION = operation.Empty;
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
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
                //}
            }
            else
            {
                rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployees_Edit()
    {
        try  //sravani 05.02.2011
        {
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            //_obj_smhr_emp_payitems.OPERATION = operation.Empty;
            if (rcmb_BusinessUnit.SelectedItem.Value != "")
            {

                _obj_smhr_emp_payitems.OPERATION = operation.Empty1;
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
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
                //}
            }
            else
            {
                rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Add_Click(object sender, EventArgs e)
    {
        try
        {
            if(rcmb_BusinessUnit.SelectedValue=="")
            {
                BLL.ShowMessage(this, "Please Select Business Unit");
                return;
            }
            if (rcmb_Employee.SelectedValue == "")
            {
                BLL.ShowMessage(this, "Please Select Employee");
                return;
            }
            if (rcmb_Bank.SelectedValue == "")
            {
                BLL.ShowMessage(this, "Please Select Bank");
                return;
            }
            if(rcmb_Branch.SelectedValue=="")
            {
                BLL.ShowMessage(this, "Please Select Branch");
                return;
            }
           
            if(rtxt_AccountNo.Text=="")
            {
                BLL.ShowMessage(this, "Please Provide Account No");
                return;
            }
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "checkboxClick(this);", true);
            bool status1 = chkAcctNo();
            string Localisation = string.Empty;
            if (status1 == false)
            {
                _obj_smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
                _obj_smhr_BusinessUnit.OPERATION = operation.Get_BULocalization;
                _obj_smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                _obj_smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtBuLocalization = BLL.get_BusinessUnit(_obj_smhr_BusinessUnit);
                if (Convert.ToString(lbl_SwiftCode.Text).Trim() == "BSB Number" && rtxt_SwiftCode.Text == string.Empty)
                {
                    BLL.ShowMessage(this, "Please Enter " + lbl_SwiftCode.Text);
                    return;
                }
                if (dtBuLocalization.Rows.Count > 0)
                {
                    if (!(Convert.ToString(dtBuLocalization.Rows[0]["HR_MASTER_CODE"]).ToUpper() == "KENYA"))
                    {
                        if (rtxt_AccountNo.Text.Length > 20)
                        {
                            BLL.ShowMessage(this, "Account Number Should be Less Than 20 Chars Length");
                            return;
                        }
                    }
                    else
                    {

                    }

                }
                //if (rtxt_AccountNo.Text.Length != 12)
                //{
                //    BLL.ShowMessage(this, "Account Number Should be 12 Chars Length");
                //    return;
                //}
                if (rcmb_Branch.SelectedIndex > 0)
                {
                    _obj_smhr_empbnkdetails = new SMHR_EMPBNKDTLS();
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
                    if (Convert.ToString(_obj_smhr_empbnkdetails.BUSUNTBANK_SWIFT) != string.Empty)
                    {
                        _obj_smhr_empbnkdetails.OPERATION = operation.Validate1;
                        DataTable dt_Check = BLL.get_BankDetCheck(_obj_smhr_empbnkdetails);
                        if (dt_Check.Rows.Count > 0)
                        {
                            if (Convert.ToString(dt_Check.Rows[0]["COUNT"]) != "0")
                            {
                                if (Convert.ToString(dtBuLocalization.Rows[0]["HR_MASTER_CODE"]).ToUpper() == "AUSTRALIA")
                                    BLL.ShowMessage(this, "BSB Code Already Exist for the Employee");
                                else
                                    BLL.ShowMessage(this, "Swift Code Already Exist for the Employee");
                                return;
                            }
                        }
                    }
                    if (rcmb_Active.SelectedItem.Text == "Active")
                    {
                        _obj_smhr_empbnkdetails.OPERATION = operation.Validate;
                        DataTable dt = new DataTable();
                        dt = BLL.get_BankDetCheck(_obj_smhr_empbnkdetails);
                        if (Convert.ToInt32(dt.Rows[0][0]) >= 1)
                        {
                            BLL.ShowMessage(this, "Employee Bank Details Already Exist");
                            return;
                        }
                    }
                    _obj_smhr_empbnkdetails.OPERATION = operation.Insert;
                    bool status = BLL.set_Identification(_obj_smhr_empbnkdetails);
                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Employee Bank Details Saved Successfully");
                        LoadData();
                        MarkData();
                        RG_Identification.DataBind();//Modified By Me Grid Is Loading In Mask data 
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
                    BLL.ShowMessage(this, "Select Branch Name");
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Correct_Click(object sender, EventArgs e)
    {
        try
        {
            //chk_Default.Attributes.Add("onclick", "return checkboxClick(this)");
            //btn_Correct.Attributes.Add("onclick", "return checkbox();");
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "checkbox();", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "checkbox();", true);
            _obj_smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            _obj_smhr_BusinessUnit.OPERATION = operation.Get_BULocalization;
            _obj_smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            _obj_smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtBuLocalization = BLL.get_BusinessUnit(_obj_smhr_BusinessUnit);
            if (Convert.ToString(lbl_SwiftCode.Text).Trim() == "BSB Number" && rtxt_SwiftCode.Text == string.Empty)
            {
                BLL.ShowMessage(this, "Please Enter " + lbl_SwiftCode.Text);
                return;
            }
            if (dtBuLocalization.Rows.Count > 0)
            {
                if (!(Convert.ToString(dtBuLocalization.Rows[0]["HR_MASTER_CODE"]).ToUpper() == "KENYA"))
                {
                    if (rtxt_AccountNo.Text.Length > 20)
                    {
                        BLL.ShowMessage(this, "Account Number Should be Less Than 20 Chars Length");
                        return;
                    }
                }
                else
                {

                }

            }
            //if (rtxt_AccountNo.Text.Length != 12)
            //{
            //    BLL.ShowMessage(this, "Account Number Should be 12 Chars Length");
            //    return;
            //}

            if (rcmb_Branch.SelectedIndex > 0)
            {
                if (rcmb_Active.SelectedItem.Text == "Active")
                {
                    if (lbl_acc.Text != Convert.ToString(rtxt_AccountNo.Text.Replace("'", "''")))
                    {
                        bool status1 = chkAcctNo();
                        if (status1 == true)
                        {
                            BLL.ShowMessage(this, "Employee Details Exist Already");
                            return;
                        }
                    }
                    //DataTable dt = new DataTable();
                    //_obj_smhr_empbnkdetails.EMPBNKDTLS_ID = Convert.ToInt32(HF_ID.Value);//Convert.ToInt32(_lbl_ID);
                    //_obj_smhr_empbnkdetails.OPERATION = operation.Validate;
                    //dt = BLL.get_BankDetCheck(_obj_smhr_empbnkdetails);
                    //if (Convert.ToInt32(dt.Rows[0][0]) >= 1)
                    //{

                    //    BLL.ShowMessage(this, "Employee Details Exist Already");
                    //    return;
                    //}
                    //_obj_smhr_empbnkdetails.OPERATION = operation.Update;

                }

                _obj_smhr_empbnkdetails = new SMHR_EMPBNKDTLS();
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
                _obj_smhr_empbnkdetails.EMPBNKDTLS_ID = Convert.ToInt32(HF_ID.Value);//Convert.ToInt32(_lbl_ID);
                _obj_smhr_empbnkdetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                _obj_smhr_empbnkdetails.OPERATION = operation.Update;
                _obj_smhr_empbnkdetails.BUSUNTBANK_LASTMDFDATE = DateTime.Now;
                bool status = BLL.set_Identification(_obj_smhr_empbnkdetails);

                if (status == true)
                {
                    BLL.ShowMessage(this, "Employee Bank Details Updated Successfully");
                    LoadData();
                    MarkData();
                    RG_Identification.DataBind();
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
                BLL.ShowMessage(this, "Select Branch Name");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
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
                LoadEmployees_Edit();
                _lblEmpID = Convert.ToString(dt.Rows[0]["EMPBNKDTLS_EMPID"]);
                rcmb_Employee.SelectedIndex = rcmb_Employee.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPBNKDTLS_EMPID"]));
                //rcmb_Bank.SelectedIndex = rcmb_Bank.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSUNTBANK_ID"]));
                rcmb_Bank.SelectedIndex = rcmb_Bank.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPBNKDTLS_BANK_ID"]));
                rcmb_Bank_SelectedIndexChanged(null, null);
                rtxt_Address.Text = Convert.ToString(dt.Rows[0]["BRANCH_ADDRESS"]);
                //rcmb_Branch.SelectedIndex = rcmb_Branch.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSUNTBANK_BRANCHID"]));
                rcmb_Branch.SelectedIndex = rcmb_Branch.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPBNKDTLS_BRANCHID"]));
                //rtxt_AccountNo.Text = Convert.ToString(dt.Rows[0]["BUSUNTBANK_ACCOUNTNO"]);
                rtxt_AccountNo.Text = Convert.ToString(dt.Rows[0]["EMPBNKDTLS_ACCOUNTNO"]);
                lbl_acc.Text = Convert.ToString(dt.Rows[0]["EMPBNKDTLS_ACCOUNTNO"]);
                //rtxt_SwiftCode.Text = Convert.ToString(dt.Rows[0]["BUSUNTBANK_SWIFT"]);
                rtxt_SwiftCode.Text = Convert.ToString(dt.Rows[0]["EMPBNKDTLS_SWIFT"]);
                //if (Convert.ToBoolean(dt.Rows[0]["BUSUNTBANK_ISACTIVE"]) == true)
                if (Convert.ToBoolean(dt.Rows[0]["EMPBNKDTLS_ISACTIVE"]) == true)
                    rcmb_Active.SelectedValue = "1";
                else
                    rcmb_Active.SelectedValue = "0";
                //chk_Active.Checked = Convert.ToBoolean(dt.Rows[0]["BUSUNTBANK_ISACTIVE"]);
                //chk_Default.Checked = Convert.ToBoolean(dt.Rows[0]["BUSUNTBANK_ISDEFAULT"]);
                chk_Default.Checked = Convert.ToBoolean(dt.Rows[0]["EMPBNKDTLS_ISDEFAULT"]);
                //TO CHANGE THE SWIFT CODE TEXT BASED ON LOCALISATION,23.11.2012
                SMHR_BUSINESSUNIT _obj_smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
                _obj_smhr_BusinessUnit.OPERATION = operation.Get_BULocalization;
                _obj_smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                _obj_smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_BULocalization = BLL.get_BusinessUnit(_obj_smhr_BusinessUnit);
                if (dt_BULocalization.Rows.Count != 0)
                {
                    if (Convert.ToString(dt_BULocalization.Rows[0]["HR_MASTER_CODE"]).ToUpper() == "AUSTRALIA")
                        lbl_SwiftCode.Text = "BSB Number";
                    else
                        lbl_SwiftCode.Text = "Swift Codde";
                }
                tr_Swift.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void clearFields()
    {
        try
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
            lbl_acc.Text = string.Empty;
            tr_Swift.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #region Maskdata
    /// <summary>
    /// To Set The Account no. Mark With xxxx except last four digits
    /// </summary>
    private void MarkData()
    {
        try
        {
            //string str2="";
            //string str1="";
            //  string str3="";
            if (Convert.ToString(Session["BANK"]) != string.Empty)
            {
                DataTable dt = Session["BANK"] as DataTable;
                int index;
                for (index = 0; index < dt.Rows.Count; index++)
                {
                    string str2 = "";
                    string str1 = "";
                    string str3 = "";
                    string str = "";
                    //string str = Convert.ToString(RG_Identification.Items[index].Cells[6].Text);
                    if (dt.Rows[index]["EMPBNKDTLS_ACCOUNTNO"] != System.DBNull.Value)
                    {
                        str = Convert.ToString(dt.Rows[index]["EMPBNKDTLS_ACCOUNTNO"].ToString());
                    }
                    if (str != "")
                    {
                        if (str.Length > 4) // added for a/c no. field less than or equal to 4 characters.
                        {
                            if (str1 == "")
                            {
                                str1 = str.Substring(str.Length - 4);
                            }

                            if (str2 == "")

                                str2 = str.Substring(0, str.Length - 4);

                            for (int i = 0; i < str2.Length; i++)
                            {
                                if (str3 == "")
                                    str3 = "X";
                                else
                                    str3 = str3 + "X";
                            }
                        }
                        else
                        {
                            for (int i = 0; i < str.Length; i++)
                            {
                                if (str3 == "")
                                    str3 = "X";
                                else
                                    str3 = str3 + "X";
                            }
                        }
                        string Final = str3 + str1;
                        //RG_Identification.Items[index].Cells[6].Text = Convert.ToString(Final);
                        dt.Rows[index]["EMPBNKDTLS_ACCOUNTNO"] = Convert.ToString(Final);
                    }
                }
                RG_Identification.DataSource = dt;
            }
            else
            {
                //RG_Identification.DataSource = null;
                LoadData();
                RG_Identification.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    private bool chkAcctNo()
    {
        bool flag = false;
        try
        {
            _obj_smhr_empbnkdetails = new SMHR_EMPBNKDTLS();
            _obj_smhr_empbnkdetails.OPERATION = operation.Empty;
            _obj_smhr_empbnkdetails.BUSUNTBANK_ACCOUNTNO = Convert.ToString(rtxt_AccountNo.Text.Replace("'", "''"));
            //_obj_smhr_empbnkdetails.BUSUNTBANK_SWIFT = Convert.ToString(rtxt_SwiftCode.Text);
            DataTable dt = new DataTable();
            _obj_smhr_empbnkdetails.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt = BLL.get_BankDetCheck(_obj_smhr_empbnkdetails);
            if (dt.Rows.Count == 0)
            {
                flag = false;
            }
            else
            {
                flag = true;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return flag;

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
                //rcmb_Employee.Enabled = false;
                rcmb_Employee.Enabled = true;
            }
            if (rcmb_BusinessUnit.SelectedIndex > 0)
            {
                tr_Swift.Visible = true;
                SMHR_BUSINESSUNIT _obj_smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
                _obj_smhr_BusinessUnit.OPERATION = operation.Get_BULocalization;
                _obj_smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                _obj_smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_BULocalization = BLL.get_BusinessUnit(_obj_smhr_BusinessUnit);
                if (dt_BULocalization.Rows.Count != 0)
                {
                    if (Convert.ToString(dt_BULocalization.Rows[0]["HR_MASTER_CODE"]).ToUpper() == "AUSTRALIA")
                        lbl_SwiftCode.Text = "BSB Number";
                    else
                        lbl_SwiftCode.Text = "Swift Codde";
                }
            }
            else
            {
                tr_Swift.Visible = false;
               

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    
    protected void chk_Default_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_Employee.SelectedValue != string.Empty)
            {
                int empID = Convert.ToInt32(rcmb_Employee.SelectedValue);

                if (empID > 0)
                {
                    DataTable dt = BLL.Check(empID.ToString());

                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dt.Rows[0]["CNT"]) > 0)
                            hfEmpCnt.Value = Convert.ToString(dt.Rows[0]["CNT"]);
                        else
                            hfEmpCnt.Value = "0";
                    }
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please select Employee..!");
                chk_Default.Checked = false;
                rcmb_Employee.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmempbankdetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
