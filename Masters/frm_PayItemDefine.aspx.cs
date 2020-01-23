﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;
using System.Text;

public partial class Masters_frm_PayItemDefine : System.Web.UI.Page
{
    SMHR_PAYITEMS _obj_Smhr_Payitems;
    SMHR_MASTERS _obj_Smhr_Masters;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    DataTable dtpriority = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Page.Validate();
            if (!Page.IsPostBack)
            {


                //code for security privilagezzz
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Pay Item");//PAYITEMDEFINE");
                DataTable dtformdtls = BLL.get_LoginInfo(_obj_Smhr_LoginInfo);
                rcmb_PayItemType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //rcmb_PayItemMode.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
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
                    Rg_PayItems.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Edit.Visible = false;
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
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdt_PayItemStartDate, rdtp_PayItemEnddate);
                LoadMainGrid();
                Rg_PayItems.DataBind();
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    for (int i = 0; i < Rg_PayItems.Items.Count; i++)
                    {
                        LinkButton lnkview = new LinkButton();
                        lnkview = (LinkButton)Rg_PayItems.Items[i].FindControl("lnk_View") as LinkButton;
                        lnkview.Visible = false;

                    }
                }

                if (Convert.ToString(Request.QueryString["value"]) == "save")
                    BLL.ShowMessage(this, "Information Saved successfully");
                if (Convert.ToString(Request.QueryString["value"]) == "update")
                    BLL.ShowMessage(this, "Information Updated successfully");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayItemDefine", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            _obj_Smhr_Masters = new SMHR_MASTERS();
            //Load PayItem Type
            rcmb_PayItemType.Items.Clear();
            _obj_Smhr_Masters.MASTER_TYPE = "PAYITEMTYPE";
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_PayItemType.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
            rcmb_PayItemType.DataTextField = "HR_MASTER_CODE";
            rcmb_PayItemType.DataValueField = "HR_MASTER_ID";
            rcmb_PayItemType.DataBind();
            rcmb_PayItemType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            //Load PayItem Mode
            rcmb_PayItemMode.Items.Clear();
            _obj_Smhr_Masters.MASTER_TYPE = "PAYITEMMODE";
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_PayItemMode.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
            rcmb_PayItemMode.DataTextField = "HR_MASTER_CODE";
            rcmb_PayItemMode.DataValueField = "HR_MASTER_ID";
            rcmb_PayItemMode.DataBind();
            rcmb_PayItemMode.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            rcmb_PayItemMode.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayItemDefine", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            string str = string.Empty;
            _obj_Smhr_Payitems = new SMHR_PAYITEMS();

            _obj_Smhr_Payitems.PAYITEM_PAYITEMNAME = BLL.ReplaceQuote(rtxt_PayItemCode.Text);
            _obj_Smhr_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Smhr_Payitems.PAYITEM_PAYDESC = BLL.ReplaceQuote(rtxt_PayItemDesc.Text);
            _obj_Smhr_Payitems.PAYITEM_ITEMTYPE_ID = Convert.ToInt32(rcmb_PayItemType.SelectedItem.Value);
            _obj_Smhr_Payitems.PAYITEM_ITEMMODE_ID = Convert.ToInt32(rcmb_PayItemMode.SelectedItem.Value);
            _obj_Smhr_Payitems.PAYITEM_CALMODE = Convert.ToString(rcmb_PayCalMode.SelectedItem.Text);
            _obj_Smhr_Payitems.PAYITEM_STARTDATE = Convert.ToDateTime(rdt_PayItemStartDate.SelectedDate);
            if (rdtp_PayItemEnddate.SelectedDate != null)
            {
                _obj_Smhr_Payitems.PAYITEM_ENDDATE = Convert.ToDateTime(rdtp_PayItemEnddate.SelectedDate);
            }
            else
            {
                _obj_Smhr_Payitems.PAYITEM_ENDDATE = null;
            }
            _obj_Smhr_Payitems.PAYITEM_PRINTINPAYREG = Convert.ToBoolean(chk_PrintinPayRegister.Checked);
            _obj_Smhr_Payitems.PAYITEM_PRINTINPAYSLIP = Convert.ToBoolean(chk_PrintPaySlip.Checked);
            _obj_Smhr_Payitems.PAYITEM_ISLOANVAILDATE = Convert.ToBoolean(chk_loanval.Checked);
            // _obj_Smhr_Payitems.PAYITEM_PROJECTID = Convert.ToInt32(rcmb_Project.SelectedValue);

            _obj_Smhr_Payitems.PAYITEM_ISNULLIFY = Convert.ToBoolean(chkISNullify.Checked);

            ShowCheckedItems(rlb_Project, lbl_projectlist);  //for project list box
            _obj_Smhr_Payitems.PAYITEM_PROJECTID = Convert.ToString(lbl_projectlist.Text);

            //if (chk_PrintPaySlip.Checked)
            //{
            //    _obj_Smhr_Payitems.PAYITEM_PRINTINPAYSLIP = true;
            //}
            //else
            //{
            //    _obj_Smhr_Payitems.PAYITEM_PRINTINPAYSLIP = false;
            //}
            _obj_Smhr_Payitems.PAYITEM_AUTOMATIC = Convert.ToBoolean(chk_Automatic.Checked);
            _obj_Smhr_Payitems.PAYITEM_CTC = Convert.ToBoolean(chk_CTC.Checked);
            _obj_Smhr_Payitems.PAYITEM_INDIVIDUAL = Convert.ToBoolean(chk_IndividualPrint.Checked);
            _obj_Smhr_Payitems.PAYITEM_PROCESSTYPE = Convert.ToBoolean(rbtn_ProcessingType.SelectedItem.Value.ToString() == "0" ? "TRUE" : "FALSE");
            _obj_Smhr_Payitems.PAYITEM_PROCESSTYPE = Convert.ToBoolean(rbtn_ProcessingType.SelectedItem.Value.ToString() == "1" ? "TRUE" : "FALSE");

            _obj_Smhr_Payitems.PAYITEM_ACCOUNTHEAD = Convert.ToString(rtxt_AccountHead.Text);
            _obj_Smhr_Payitems.PAYITEM_VOTENAME = Convert.ToString(rtxtVoteName.Text).Replace("'", "''");
            //  _obj_Smhr_Payitems.PAYITEM_YTD = Convert.ToString(rcmb_YTDType.SelectedItem.Text.Trim());
            _obj_Smhr_Payitems.PAYITEM_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);// Need to Change
            _obj_Smhr_Payitems.PAYITEM_CREATEDDATE = DateTime.Now;
            _obj_Smhr_Payitems.PAYITEM_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // Need to Change
            _obj_Smhr_Payitems.PAYITEM_LASTMDFDATE = DateTime.Now;
            _obj_Smhr_Payitems.PAYITEM_ISBENFITABLE = chk_Benfit.Checked;
            _obj_Smhr_Payitems.PAYITEM_ISTAXABLE = chk_Istaxable.Checked;
            _obj_Smhr_Payitems.PAYITEM_ISOA_INCLUDED = chk_Oaincluded.Checked;
            _obj_Smhr_Payitems.PAYITEM_MINIMUM_PERCENTAGE_VALUE = Convert.ToDouble(RNT_MinimumValue.Text);
            if (trProcessType.Visible == true)  //if ((string.Compare(rcmb_PayItemMode.SelectedItem.Text, "Loan", true) == 0) || (string.Compare(rcmb_PayItemMode.SelectedItem.Text, "Insurance", true) == 0))
                _obj_Smhr_Payitems.PAYITEM_LOAN_PROCESS_TYPE = rb_loanprocesstype.SelectedItem.Text;
            else
                _obj_Smhr_Payitems.PAYITEM_LOAN_PROCESS_TYPE = null;
            //_obj_Smhr_Payitems.PAYITEM_ACCOUNTTYPE = Convert.ToString(ddl_AccountType.SelectedItem.Text.Trim());
            //if (Convert.ToString(ddl_AccountType.SelectedItem.Text.Trim()) == "Vendor")
            //    _obj_Smhr_Payitems.PAYITEM_POSTINGPROFILE = Convert.ToString(txt_PostingProfile.Text.Trim());
            //  else
            _obj_Smhr_Payitems.PAYITEM_ACCOUNTTYPE = string.Empty;
            _obj_Smhr_Payitems.PAYITEM_POSTINGPROFILE = string.Empty;
            _obj_Smhr_Payitems.PAYITEM_ISAFFECTLOP = Convert.ToBoolean(chk_AffectLop.Checked);

            if (string.Compare(rcmb_PayItemMode.SelectedItem.Text, "Loan", true) == 0)
            {
                _obj_Smhr_Payitems.PAYITEM_LOAN_PROCESSTYPE = Convert.ToInt32(rb_loanprocesstype.SelectedItem.Value);
            }
            else if (string.Compare(rcmb_PayItemMode.SelectedItem.Text, "Insurance", true) == 0)
            {
                _obj_Smhr_Payitems.PAYITEM_INSTAXRELIEF = Convert.ToDecimal(rtxtTaxRelief.Value);
            }
            else if ((string.Compare(rcmb_PayItemMode.SelectedItem.Text, "Loan Interest", true) == 0) && rcbLoanInterest.SelectedValue != string.Empty)
            {
                _obj_Smhr_Payitems.PAYITEM_LOAN_INTEREST = Convert.ToInt32(rcbLoanInterest.SelectedValue);
            }

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":
                    _obj_Smhr_Payitems.OPERATION = operation.Check;
                    _obj_Smhr_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    if (Convert.ToString(BLL.get_PayItems(_obj_Smhr_Payitems).Rows[0][0]) != "0")
                    {
                        BLL.ShowMessage(this, "Pay Item with this Name Already Exists");
                        rtxt_PayItemCode.Text = String.Empty;
                        return;
                    }
                    _obj_Smhr_Payitems.PAYITEM_ACCOUNTHEAD = Convert.ToString(rtxt_AccountHead.Text);
                    _obj_Smhr_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                    _obj_Smhr_Payitems.OPERATION = operation.CHECKDUPLICATE;
                    DataTable dt = BLL.get_PayItems(_obj_Smhr_Payitems);
                    if (dt.Rows.Count != 0)
                    {
                        //if (Convert.ToString(dt.Rows[0][0]) != "0")
                        //{
                        //    BLL.ShowMessage(this, "Voter Code Has Been Already Assigned.");
                        //    rtxt_AccountHead.Text = string.Empty;
                        //    rtxt_AccountHead.Focus();
                        //    return;
                        //}
                    }
                    _obj_Smhr_Payitems.OPERATION = operation.Insert;
                    if (BLL.set_PayItems(_obj_Smhr_Payitems))
                    {
                        dtpriority = null;
                        str = "save";
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    }
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;

                case "BTN_EDIT":

                    _obj_Smhr_Payitems.PAYITEM_ID = Convert.ToInt32(lbl_PayItemID.Text);
                    _obj_Smhr_Payitems.OPERATION = operation.Check;
                    _obj_Smhr_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    if (Convert.ToString(BLL.get_PayItems(_obj_Smhr_Payitems).Rows[0][0]) != "1")
                    {
                        BLL.ShowMessage(this, "Pay Item with this Name Already Exists");
                        rtxt_PayItemCode.Text = String.Empty;
                        return;
                    }
                    if (Convert.ToString(lbl_Request.Text) != Convert.ToString(rtxt_AccountHead.Text))
                    {
                        _obj_Smhr_Payitems.PAYITEM_ACCOUNTHEAD = Convert.ToString(rtxt_AccountHead.Text);
                        _obj_Smhr_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                        _obj_Smhr_Payitems.OPERATION = operation.CHECKDUPLICATE;
                        DataTable dt_check = BLL.get_PayItems(_obj_Smhr_Payitems);
                        if (dt_check.Rows.Count != 0)
                        {
                            //if (Convert.ToString(dt_check.Rows[0][0]) != "0")
                            //{
                            //    BLL.ShowMessage(this, "Voter Code Has Been Already Assigned.");
                            //    rtxt_AccountHead.Text = string.Empty;
                            //    rtxt_AccountHead.Focus();
                            //    return;
                            //}
                        }
                    }
                    _obj_Smhr_Payitems.OPERATION = operation.Update;
                    if (BLL.set_PayItems(_obj_Smhr_Payitems))
                    {
                        dtpriority = null;
                        str = "update";
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    }
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
            }
            //Rm_PayItem_page.SelectedIndex = 0;
            //LoadMainGrid();
            //Rg_PayItems.DataBind();
            Response.Redirect("~/Masters/frm_PayItemDefine.aspx?value=" + str, false);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayItemDefine", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {

            //rbtn_ProcessingType.ClearSelection();
            rbtn_ProcessingType.SelectedIndex = -1;  //to clear radiobuttonlist items
            trConfig.Visible = false;
            ClearControls();
            trProcessType.Visible = false;
            trInsurance.Visible = false;
            chk_Istaxable.Checked = true;
            chk_Oaincluded.Checked = true;
            chk_AffectLop.Checked = false;
            chk_loanval.Checked = false;

            chkISNullify.Checked = false;

            LoadCombos();
            LoadProject();   //to load project
           // rcmb_Project.SelectedIndex = 0;
            //LoadBU();
            RNT_MinimumValue.Text = Convert.ToString(0.0);
            //lbl_Request.Visible = true;
            btn_Save.Visible = true;
            Rm_PayItem_page.SelectedIndex = 1;
            
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayItemDefine", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadMainGrid()
    {
        try
        {
            _obj_Smhr_Payitems = new SMHR_PAYITEMS();
            _obj_Smhr_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //Rg_PayItems.DataSource = BLL.get_PayItems(_obj_Smhr_Payitems);
            if (BLL.get_PayItems(_obj_Smhr_Payitems).Rows.Count > 0)
            {
                Rg_PayItems.DataSource = BLL.get_PayItems(_obj_Smhr_Payitems);
            }
            else
            {
                DataTable dt = new DataTable();
                Rg_PayItems.DataSource = dt;
            }
            ///Please donot change the sequence in the binded values, there is a big functionality ahead, be careful :0///
            Rm_PayItem_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayItemDefine", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void Rg_PayItems_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadMainGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayItemDefine", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ClearControls()
    {
        try
        {

            rtxt_PayItemCode.Text = string.Empty;
            rtxt_PayItemDesc.Text = string.Empty;
            rtxt_AccountHead.Text = string.Empty;
            rtxtVoteName.Text = string.Empty;
            rcmb_PayItemType.SelectedIndex = 0;
            rcmb_PayItemMode.SelectedIndex = 0;
            rcmb_PayCalMode.ClearSelection();
            //commented by bharath
            //rcmb_PayCalMode.SelectedItem.Text="Select";
            RNT_MinimumValue.Text = string.Empty;
            rbtn_ProcessingType.SelectedIndex = -1;
            //rblConfigure.SelectedIndex = 0;
            rdt_PayItemStartDate.SelectedDate = null;
            rdtp_PayItemEnddate.SelectedDate = null;
            btn_Edit.Visible = false;
            btn_Save.Visible = false;
            chk_PrintPaySlip.Checked = false;
            chk_loanval.Checked = false;

            chkISNullify.Checked = false;

           // rcmb_Project.SelectedIndex = 0;
            chk_PrintinPayRegister.Checked = false;
            chk_CTC.Checked = false;
            //lbl_Request.Visible = true;
            txt_PostingProfile.Text = string.Empty;
            ddl_AccountType.ClearSelection();
            chk_Oaincluded.Checked = false;
            chk_Istaxable.Checked = false;
            chk_Benfit.Checked = false;
            chk_AffectLop.Checked = false;
            lbl_Request.Text = string.Empty;
            rtxtTaxRelief.Text = string.Empty;
            //rcmb_YTDType.SelectedIndex = 0;
            //commented by bharath
            //ddl_AccountType.SelectedItem.Text = "Select";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayItemDefine", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {

            rblConfigure.ClearSelection();
            trLoanInterest.Visible = false;
            trConfig.Visible = true;
            trProcessType.Visible = false;
            trInsurance.Visible = false;
            LoadCombos();
            LoadProject(); //to load project
            // LoadBU();
            ClearControls();
            DataTable dt;
            _obj_Smhr_Payitems = new SMHR_PAYITEMS();
            //lbl_Request.Visible = true;
            _obj_Smhr_Payitems.PAYITEM_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            lbl_PayItemID.Text = Convert.ToString(e.CommandArgument);
            dt = BLL.get_PayItems(_obj_Smhr_Payitems);
            if (dt.Rows.Count > 0)
            {
                //PAYITEM_LOAN_PROCESSTYPE
                rtxt_PayItemCode.Text = Convert.ToString(dt.Rows[0]["PAYITEM_PAYITEMNAME"]);
                rtxt_PayItemDesc.Text = Convert.ToString(dt.Rows[0]["PAYITEM_PAYDESC"]);
                rcmb_PayItemType.SelectedIndex = rcmb_PayItemType.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["PAYITEM_ITEMTYPE_ID"]));
                rcmb_PayItemMode.SelectedIndex = rcmb_PayItemMode.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["PAYITEM_ITEMMODE_ID"]));
                //rcmb_PayCalMode.SelectedItem.Text = Convert.ToString(dt.Rows[0]["PAYITEM_CALMODE"]);
                rcmb_PayCalMode.SelectedIndex = rcmb_PayCalMode.Items.FindItemIndexByText(Convert.ToString(dt.Rows[0]["PAYITEM_CALMODE"]));
                //    rcmb_YTDType.SelectedIndex = rcmb_YTDType.Items.FindItemIndexByText(Convert.ToString(dt.Rows[0]["PAYITEM_YTD"]));
                //rbtn_ProcessingType.SelectedIndex = (Convert.ToString(dt.Rows[0]["PAYITEM_PROCESSTYPE"]).ToUpper() == "FALSE" ? 1 : 2);
                rbtn_ProcessingType.SelectedIndex = Convert.ToInt32(dt.Rows[0]["PAYITEM_PROCESSTYPE"]);
                //rblConfigure.SelectedIndex = (Convert.ToString(dt.Rows[0]["ALLOWANCE_CONFG_ID"]).ToUpper() == "FALSE" ? 1:0);
                rdt_PayItemStartDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["PAYITEM_STARTDATE"]);
                RNT_MinimumValue.Text = Convert.ToString(dt.Rows[0]["PAYITEM_MINIMUM_PERCENTAGE_VALUE"]);
                if (dt.Rows[0]["PAYITEM_ENDDATE"] == DBNull.Value)
                    rdtp_PayItemEnddate.SelectedDate = null;
                else
                    rdtp_PayItemEnddate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["PAYITEM_ENDDATE"]);

                chk_PrintinPayRegister.Checked = Convert.ToBoolean(dt.Rows[0]["PAYITEM_PRINTINPAYREG"]);
                if (Convert.ToString(dt.Rows[0]["PAYITEM_ISBENEFITABLE"]) != "")
                    chk_Benfit.Checked = Convert.ToBoolean(dt.Rows[0]["PAYITEM_ISBENEFITABLE"].ToString());
                if (Convert.ToString(dt.Rows[0]["PAYITEM_ISTAXABLE"]) != "")
                    chk_Istaxable.Checked = Convert.ToBoolean(dt.Rows[0]["PAYITEM_ISTAXABLE"]);
                if (Convert.ToString(dt.Rows[0]["PAYITEM_ISOA_INCLUDED"]) != "")
                    chk_Oaincluded.Checked = Convert.ToBoolean(dt.Rows[0]["PAYITEM_ISOA_INCLUDED"]);
                if (Convert.ToString(dt.Rows[0]["PAYITEM_ISAFFECTLOP"]) != "")
                    chk_AffectLop.Checked = Convert.ToBoolean(dt.Rows[0]["PAYITEM_ISAFFECTLOP"]);
                chk_Automatic.Checked = Convert.ToBoolean(dt.Rows[0]["PAYITEM_AUTOMATIC"]);
                chk_CTC.Checked = Convert.ToBoolean(dt.Rows[0]["PAYITEM_CTC"]);
                chk_IndividualPrint.Checked = Convert.ToBoolean(dt.Rows[0]["PAYITEM_INDIVIDUAL"]);
                //chk_PrintPaySlip.Checked = Convert.ToBoolean(dt.Rows[0]["PAYITEM_PRINTINPAYSLIP"]);
                if (Convert.ToString(dt.Rows[0]["PAYITEM_PRINTINPAYSLIP"]) != null)
                {
                    chk_PrintPaySlip.Checked = Convert.ToBoolean(dt.Rows[0]["PAYITEM_PRINTINPAYSLIP"]);
                }
                if (dt.Rows[0]["PAYITEM_ISLOANVAILDATE"] != System.DBNull.Value)
                {
                    chk_loanval.Checked = Convert.ToBoolean(dt.Rows[0]["PAYITEM_ISLOANVAILDATE"]);
                }

                if (dt.Rows[0]["PAYITEM_ISNULLIFY"] != System.DBNull.Value)
                {
                    chkISNullify.Checked = Convert.ToBoolean(dt.Rows[0]["PAYITEM_ISNULLIFY"]);
                }

                /*if (dt.Rows[0]["PAYITEM_PROJECTID"] != System.DBNull.Value)
                {
                    //rcmb_Project.SelectedIndex = Convert.ToInt32(dt.Rows[0]["PAYITEM_PROJECTID"]);
                    //rcmb_Project.SelectedIndex = rcmb_Project.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["PAYITEM_PROJECTID"]));
                }*/
                lbl_projectlist.Text = Convert.ToString(dt.Rows[0]["PAYITEM_PROJECTID"]);  //for project listbox
                getCheckedItems(rlb_Project, lbl_projectlist);  

                rtxt_AccountHead.Text = Convert.ToString(dt.Rows[0]["PAYITEM_ACCOUNTHEAD"]);
                rtxtVoteName.Text = Convert.ToString(dt.Rows[0]["PAYITEM_VOTENAME"]);
                lbl_Request.Text = Convert.ToString(dt.Rows[0]["PAYITEM_ACCOUNTHEAD"]);
                if (string.Compare(rcmb_PayItemMode.SelectedItem.Text, "Loan", true) == 0)
                {
                    trProcessType.Visible = true;
                    rb_loanprocesstype.SelectedIndex = rb_loanprocesstype.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["PAYITEM_LOAN_PROCESSTYPE"]));
                }
                else if (string.Compare(rcmb_PayItemMode.SelectedItem.Text, "Loan Interest", true) == 0)
                {
                    LoadLoanInterest();
                    trProcessType.Visible = trLoanInterest.Visible = true;
                    rb_loanprocesstype.SelectedIndex = rb_loanprocesstype.Items.FindItemIndexByText(Convert.ToString(dt.Rows[0]["PAYITEM_LOAN_PROCESS_TYPE"]));
                    rcbLoanInterest.SelectedIndex = rcbLoanInterest.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["PAYITEM_LOAN_INTEREST"]));
                }

                else if (string.Compare(rcmb_PayItemMode.SelectedItem.Text, "Insurance", true) == 0)
                {
                    trInsurance.Visible = true;
                    rtxtTaxRelief.Text = Convert.ToString(dt.Rows[0]["PAYITEM_INSTAXRELIEF"]);
                }
                else
                {
                    trProcessType.Visible = false;
                    trInsurance.Visible = false;
                }
            }

            btn_Save.Visible = false;

            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Edit.Visible = false;

            }

            else
            {
                btn_Edit.Visible = true;
            }

            Rm_PayItem_page.SelectedIndex = 1;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), "<script>OnAccountType();</script>", false);
            if (Convert.ToString(dt.Rows[0]["PAYITEM_ACCOUNTTYPE"]) != "" || dt.Rows[0]["PAYITEM_ACCOUNTTYPE"] != System.DBNull.Value)
                ddl_AccountType.SelectedIndex = ddl_AccountType.Items.FindItemIndexByText(Convert.ToString(dt.Rows[0]["PAYITEM_ACCOUNTTYPE"]));
            else
                ddl_AccountType.SelectedIndex = 0;
            if (Convert.ToString(dt.Rows[0]["PAYITEM_POSTINGPROFILE"]) != "")
            {
                txt_PostingProfile.Text = Convert.ToString(dt.Rows[0]["PAYITEM_POSTINGPROFILE"]);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), "<script> document.getElementById('Posting_Profile').style.display = '';</script>", false);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), "<script> document.getElementById('Posting_Profile').style.display = 'none';</script>", false);

            #region Check Loan Setup Data
            if (rcmb_PayItemMode.SelectedItem.Text == "Loan")
            {
                SMHR_LOANSETUP _obj_SMHRLOANSETUP = new SMHR_LOANSETUP();

                _obj_SMHRLOANSETUP.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHRLOANSETUP.LOANSETUP_LOANTYPE_ID = Convert.ToInt32(lbl_PayItemID.Text);
                _obj_SMHRLOANSETUP.LOANSETUP_LOANPROCESSTYPE = rb_loanprocesstype.SelectedItem.Text;

                DataTable dtLS = BLL.GetLoanSetupData(_obj_SMHRLOANSETUP);

                if (dtLS.Rows.Count > 0)
                {
                    BLL.ShowMessage(this, "You are not supposed to modify this Pay Item, because it is already in use in Loan module");
                    btn_Edit.Visible = false;
                }
                else
                {
                    btn_Edit.Visible = true;
                }
            }
            #endregion
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayItemDefine", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Delete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            _obj_Smhr_Payitems = new SMHR_PAYITEMS();
            _obj_Smhr_Payitems.PAYITEM_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _obj_Smhr_Payitems.ISDELETED = true;
            _obj_Smhr_Payitems.PAYITEM_LASTMDFBY = 1; // Need to Change
            _obj_Smhr_Payitems.PAYITEM_LASTMDFDATE = DateTime.Now;
            //TO CHECK WHETHER THE PAYITEM IS BEING USED OR NOT BEOFRE DELETE IT, BY SRAVANI 28.03.2011
            _obj_Smhr_Payitems.OPERATION = operation.Check_New;
            if (Convert.ToString(BLL.get_PayItems(_obj_Smhr_Payitems).Rows[0]["Count"]) != "0")
            {
                BLL.ShowMessage(this, "You can not Delete this Pay Item");
                return;
            }
            _obj_Smhr_Payitems.OPERATION = operation.Delete;
            _obj_Smhr_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            if (BLL.set_PayItems(_obj_Smhr_Payitems))
                BLL.ShowMessage(this, "Record deleted Successfully");
            else
                BLL.ShowMessage(this, "Record not deleted");
            LoadMainGrid();
            Rg_PayItems.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayItemDefine", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Masters/frm_PayItemDefine.aspx", false);
            ClearControls();
            Rm_PayItem_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayItemDefine", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void cmb_PayitemPriority_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddSender = (DropDownList)sender;
            _obj_Smhr_Payitems = new SMHR_PAYITEMS();
            _obj_Smhr_Payitems.OPERATION = operation.Check;
            _obj_Smhr_Payitems.PAYITEM_ID = Convert.ToInt32(((Label)ddSender.Parent.FindControl("lblPayitemID")).Text);
            _obj_Smhr_Payitems.PAYITEM_PROCESSPRIORITY = Convert.ToInt32(ddSender.SelectedItem.Value);
            _obj_Smhr_Payitems.PAYITEM_LASTMDFBY = 1; // Need to Change
            _obj_Smhr_Payitems.PAYITEM_LASTMDFDATE = DateTime.Now;

            BLL.set_PayItems(_obj_Smhr_Payitems);
            LoadMainGrid();
            Rg_PayItems.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayItemDefine", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_PayItems_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item.Cells.Count > 6)
        {
            //DropDownList cmb_payitempriority = (DropDownList)e.Item.Cells[7].FindControl("cmb_PayitemPriority");

            //if (cmb_payitempriority != null)
            //{
            //    if (dtpriority == null)
            //        dtpriority = BLL.ExecuteQuery("SELECT DISTINCT PAYITEM_PRIORITY  FROM SMHR_PAYITEMS");
            //    cmb_payitempriority.DataSource = dtpriority;
            //    cmb_payitempriority.DataTextField = "PAYITEM_PRIORITY";
            //    cmb_payitempriority.DataValueField = "PAYITEM_PRIORITY";
            //    cmb_payitempriority.DataBind();
            //}
        }
    }

    protected void Rg_PayItems_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        //if (e.Item.Cells.Count > 6)
        //{

        //    DropDownList cmb_payitempriority = (DropDownList)e.Item.Cells[7].FindControl("cmb_PayitemPriority");

        //    if (cmb_payitempriority != null)
        //    {
        //        cmb_payitempriority.SelectedIndex = cmb_payitempriority.Items.IndexOf(cmb_payitempriority.Items.FindByValue(((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[8].ToString()));
        //    }
        //}
    }

    //private void LoadBU()
    //{
    //    //Business Unit
    //    rcmb_PayBU.Items.Clear();
    //    _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
    //    _obj_smhr_businessunit.OPERATION = operation.Check1;
    //    _obj_smhr_businessunit.BU_LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
    //    _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    DataTable dt_BUDetails = BLL.get_BusinessUnit(_obj_smhr_businessunit);
    //    rcmb_PayBU.DataSource = dt_BUDetails;
    //    rcmb_PayBU.DataValueField = "BUSINESSUNIT_ID";
    //    rcmb_PayBU.DataTextField = "BUSINESSUNIT_CODE";
    //    rcmb_PayBU.DataBind();
    //    rcmb_PayBU.Items.Insert(0, new RadComboBoxItem("Select"));
    //}

    protected void rtxt_AccountHead_TextChanged(object sender, EventArgs e)
    {
        try
        {
            _obj_Smhr_Payitems = new SMHR_PAYITEMS();
            _obj_Smhr_Payitems.PAYITEM_ACCOUNTHEAD = Convert.ToString(rtxt_AccountHead.Text);
            _obj_Smhr_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Smhr_Payitems.OPERATION = operation.Check1;
            DataTable dt = BLL.get_PayItems(_obj_Smhr_Payitems);
            //if (dt.Rows.Count != 0)
            //{
            //    if (Convert.ToString(dt.Rows[0][0]) != "0")
            //    {
            //        BLL.ShowMessage(this, "Voter Code Has Been Already Assigned.");
            //        rtxt_AccountHead.Text = string.Empty;
            //        rtxt_AccountHead.Focus();
            //        return;
            //    }
            //}
            //for (int i = 0; i < dt.Rows.Count - 1; i++)
            //{
            //    //System.Threading.Thread.Sleep(1000);
            //    if (Convert.ToString(rtxt_AccountHead.Text) == Convert.ToString(dt.Rows[i]["PAYITEM_ACCOUNTHEAD"]))
            //    {
            //        lbl_Request.Visible = true;
            //        lbl_Request.Text = "Account Head is already assigned";
            //        rtxt_AccountHead.BackColor = System.Drawing.Color.Yellow;
            //        rtxt_AccountHead.Text = string.Empty;
            //        break;
            //    }
            //    else
            //    {
            //        lbl_Request.Visible = false;
            //        rtxt_AccountHead.BackColor = System.Drawing.Color.White;
            //        lbl_Request.Text = string.Empty;
            //    }
            //}
            //if (lbl_Request.Text == string.Empty)
            //{
            //    rdt_PayItemStartDate.Focus();
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayItemDefine", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_PayItemMode_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            trInsurance.Visible = false;
            trProcessType.Visible = false;

            if (rcmb_PayItemMode.SelectedIndex > 0)
            {
                if (string.Compare(rcmb_PayItemMode.SelectedItem.Text, "Salary", true) == 0)
                {
                    trProcessType.Visible = false;
                    trLoanInterest.Visible = false;
                }
                if (string.Compare(rcmb_PayItemMode.SelectedItem.Text, "Loan", true) == 0)
                {
                    trProcessType.Visible = true;
                    trLoanInterest.Visible = false;
                }
                else if (string.Compare(rcmb_PayItemMode.SelectedItem.Text, "Insurance", true) == 0)
                {
                    trInsurance.Visible = true;
                    trLoanInterest.Visible = false;
                }
                else if (string.Compare(rcmb_PayItemMode.SelectedItem.Text, "Loan Interest", true) == 0)
                {
                    trLoanInterest.Visible = true;
                    LoadLoanInterest();
                }
                else
                {
                    trProcessType.Visible = false;
                    trInsurance.Visible = false;
                    trLoanInterest.Visible = false;
                }
            }
            else
            {
                trProcessType.Visible = false;
                trInsurance.Visible = false;
                trLoanInterest.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayItemDefine", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadLoanInterest()
    {
        try
        {
            SMHR_PAYITEMS _obj_Smhr_Payitems = new SMHR_PAYITEMS();

            _obj_Smhr_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Payitems.OPERATION = operation.Finalized;

            rcbLoanInterest.DataSource = BLL.get_PayItems(_obj_Smhr_Payitems);
            rcbLoanInterest.DataTextField = "PAYITEM_PAYITEMNAME";
            rcbLoanInterest.DataValueField = "PAYITEM_ID";
            rcbLoanInterest.DataBind();
            rcbLoanInterest.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayItemDefine", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadProject()
    {
        try
        {

            SMHR_PROJECT smhrPorject = new SMHR_PROJECT();           
            smhrPorject.PROJECT_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            smhrPorject.OPERATION = operation.Get;
            rlb_Project.DataSource = BLL.GetProject(smhrPorject);
            rlb_Project.DataTextField = "PROJECT_NAME";
            rlb_Project.DataValueField = "PROJECT_ID";
            rlb_Project.DataBind();
            //rlb_Project.Items.Insert(0, new RadComboBoxItem("Select", "0"));

        }
        catch(Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayItemDefine", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }
    }

    protected void configure_Click(object sender, EventArgs e)
    {
        try
        {
            if (rblConfigure.SelectedIndex == -1)
            {
                BLL.ShowMessage(this, "Please select Configure radio button..!");
                rblConfigure.Focus();
                return;
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){  ShowPopForm(" + Convert.ToInt32(rblConfigure.SelectedValue) + "," + Convert.ToInt32(lbl_PayItemID.Text) + "); }", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayItemDefine", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }
    }

    protected void rcbLoanInterest_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcbLoanInterest.SelectedIndex > 0)
                trProcessType.Visible = true;
            else
                trProcessType.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayItemDefine", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private static void ShowCheckedItems(RadListBox listBox, Label label)
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            IList<RadListBoxItem> collection = listBox.CheckedItems;
            foreach (RadListBoxItem item in collection)
            {
                if (sb.Length == 0)
                {
                    sb.Append(item.Value);
                }
                else
                {
                    sb.Append("," + item.Value);
                }
            }

            label.Text = sb.ToString();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void getCheckedItems(RadListBox listBox, Label label)
    {
        try
        {
            string strVal = label.Text;
            string[] Ar = strVal.Split(new Char[] { ',' });
            for (int i = 0; i < Ar.Length; i++)
            {
                string strTemp = Ar[i].Trim();

                if (listBox.FindItemByValue(strTemp) != null)
                    listBox.FindItemByValue(strTemp).Checked = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Positions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}