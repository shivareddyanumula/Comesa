using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class Masters_frm_BankBranch : System.Web.UI.Page
{
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    SMHR_MASTERS _obj_Smhr_Masters;
    SMHR_BANKBRANCH _obj_Smhr_BankBanch;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {


                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Bank Branch Code");//BANKS");
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
                    Rg_BankBranch.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                }
                lbl_BranchHeader.Visible = true;

            }

            //Page.Validate();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BankBranch", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //lbl_BranchHeader.Visible = false;
            SMHR_BANKBRANCH _obj_Smhr_BankBanch = new SMHR_BANKBRANCH();
            //loadDropdown();
            clearControls();
            LoadCombos();
            rtxt_BranchCode.Enabled = false;
            rcmb_BankCode.Enabled = false;
            _obj_Smhr_BankBanch.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_BankBanch.BRANCH_ID = Convert.ToInt32(e.CommandArgument);
            //DataTable dt = BLL.get_BankBranch(new SMHR_BANKBRANCH(Convert.ToInt32(Convert.ToString(e.CommandArgument))));
            DataTable dt = BLL.get_BankBranch(_obj_Smhr_BankBanch);
            if (dt.Rows.Count > 0)
            {
                lbl_BranchId.Text = Convert.ToString(dt.Rows[0]["BRANCH_ID"]);
                rtxt_BranchCode.Text = Convert.ToString(dt.Rows[0]["BRANCH_CODE"]);
                rtxt_BranchName.Text = Convert.ToString(dt.Rows[0]["BRANCH_NAME"]);
                rcmb_BankCode.SelectedIndex = rcmb_BankCode.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BRANCH_BANK_ID"]));
                //}
                //code for security
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Update.Visible = false;

                }

                else
                {
                    btn_Update.Visible = true;
                }
                Rm_BB_page.SelectedIndex = 1;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BankBranch", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            lbl_BranchHeader.Visible = true;
            //loadDropdown();
            clearControls();
            LoadCombos();
            btn_Save.Visible = true;
            rtxt_BranchCode.Enabled = true;
            rcmb_BankCode.Enabled = true;
            Rm_BB_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BankBranch", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void loadDropdown()
    //{
    //    rcmb_BankCode.Items.Clear();
    //    rcmb_BankCode.SelectedItem = "HDFC";

    //    //rcmb_BankCode.DataSource = BLL.get_Bank(new SMHR_BANKBRANCH());
    //    //rcmb_BankCode.DataTextField = "BANK_CODE";
    //    //rcmb_BankCode.DataValueField = "BANK_ID";
    //    //rcmb_BankCode.DataBind();
    //    //rcmb_BankCode.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
    //}

    public void LoadGrid()
    {
        try
        {
            SMHR_BANKBRANCH _obj_Smhr_BankBanch = new SMHR_BANKBRANCH();
            _obj_Smhr_BankBanch.OPERATION = operation.Check1;
            _obj_Smhr_BankBanch.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable DT = BLL.get_BankBranch(new SMHR_BANKBRANCH());BHARADWAJ
            DataTable DT = BLL.get_BankBranch(_obj_Smhr_BankBanch);
            Rg_BankBranch.DataSource = DT;
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BankBranch", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Smhr_BankBanch = new SMHR_BANKBRANCH();


            _obj_Smhr_BankBanch.BRANCH_NAME = BLL.ReplaceQuote(rtxt_BranchName.Text);
            _obj_Smhr_BankBanch.BRANCH_BANK_ID = Convert.ToInt32(rcmb_BankCode.SelectedItem.Value);
            //    _obj_Smhr_Masters.ORGANISATION_ID  = Convert.ToInt32(Session["ORG_ID"]);


            _obj_Smhr_BankBanch.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); //1; // ### Need to Get the Session
            _obj_Smhr_BankBanch.CREATEDDATE = DateTime.Now;

            _obj_Smhr_BankBanch.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);//1; // ### Need to Get the Session
            _obj_Smhr_BankBanch.LASTMDFDATE = DateTime.Now;
            _obj_Smhr_BankBanch.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.MASTER_ID = Convert.ToInt32(rcmb_BankCode.SelectedItem.Value);
            _obj_Smhr_Masters.MASTER_TYPE = "Bank";
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            _obj_Smhr_Masters.OPERATION = operation.Select;
            DataTable dtBankCode = BLL.get_MasterRecords(_obj_Smhr_Masters);
            string strBankCode = string.Empty;
            if (dtBankCode.Rows.Count > 0)
            {
                strBankCode = Convert.ToString(dtBankCode.Rows[0]["HR_MASTER_CODE"]);
            }
            string strBranchCode = BLL.ReplaceQuote(rtxt_BranchCode.Text.ToUpper());
            //_obj_Smhr_BankBanch.BRANCH_CODE = strBankCode + strBranchCode;
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_BankBanch.BRANCH_ID = Convert.ToInt32(lbl_BranchId.Text);
                    //_obj_Smhr_BankBanch.OPERATION = operation.Check;
                    _obj_Smhr_BankBanch.OPERATION = operation.Validate1;
                    if (Convert.ToString(BLL.get_BankBranch(_obj_Smhr_BankBanch).Rows[0]["Count"]) != "1")
                    {
                        BLL.ShowMessage(this, "Branch with this Code Already Exists");
                        return;
                    }
                    _obj_Smhr_BankBanch.BRANCH_CODE = strBranchCode;
                    _obj_Smhr_BankBanch.OPERATION = operation.Update;
                    _obj_Smhr_BankBanch.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    if (BLL.set_BankBranch(_obj_Smhr_BankBanch))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                case "BTN_SAVE":
                    //_obj_Smhr_BankBanch.OPERATION = operation.Check;
                    //_obj_Smhr_BankBanch.BRANCH_CODE = strBankCode + strBranchCode;
                    _obj_Smhr_BankBanch.BRANCH_CODE = strBranchCode;
                    _obj_Smhr_BankBanch.OPERATION = operation.Validate1;
                    if (Convert.ToString(BLL.get_BankBranch(_obj_Smhr_BankBanch).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Branch with this Code Already Exists");
                        return;
                    }
                    //  _obj_Smhr_BankBanch.BRANCH_CODE = strBankCode + strBranchCode;
                    _obj_Smhr_BankBanch.OPERATION = operation.Insert;
                    _obj_Smhr_BankBanch.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    if (BLL.set_BankBranch(_obj_Smhr_BankBanch))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_BB_page.SelectedIndex = 0;
            LoadGrid();
            Rg_BankBranch.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BankBranch", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BankBranch", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_BankBranch_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BankBranch", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadCombos()
    {
        try
        {
            _obj_Smhr_Masters = new SMHR_MASTERS();
            //Load PayItem Type
            rcmb_BankCode.Items.Clear();
            _obj_Smhr_Masters.MASTER_TYPE = "BANK";
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_BankCode.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
            rcmb_BankCode.DataTextField = "NAME";
            rcmb_BankCode.DataValueField = "HR_MASTER_ID";
            rcmb_BankCode.DataBind();
            rcmb_BankCode.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BankBranch", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void clearControls()
    {
        try
        {
            rtxt_BranchCode.Text = string.Empty;
            rtxt_BranchName.Text = string.Empty;
            rcmb_BankCode.SelectedIndex = -1;
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_BB_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_BankBranch", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
