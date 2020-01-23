using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SMHR;
using Telerik.Web.UI;

public partial class bonus : System.Web.UI.Page
{
    int chkstatus = 0;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_BONUSMASTER1 _obj_smhr_bonusmaster = new SMHR_BONUSMASTER1();
    SMHR_PAYITEMS _obj_Smhr_Payitems;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE BONUS");
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
                    RadGrid1.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btnSave.Visible = false;
                    btn_update.Visible = false;
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
                LoadGrid();
                Page.Validate();
                LoadCombos();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "bonus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            for (int k = 0; k < chck_Payitems.Items.Count; k++)
            {
                if (chck_Payitems.Items[k].Selected == false)
                {
                    chkstatus++;
                }
            }
            if (chkstatus == chck_Payitems.Items.Count)
            {
                BLL.ShowMessage(this, "Please Select Payitem");
                return;
            }
            _obj_smhr_bonusmaster.OPERATION = operation.Select2;
            _obj_smhr_bonusmaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt1 = BLL.Get_SMHR_BONUSMASTER1(_obj_smhr_bonusmaster);
            int flag = 0;
            int s1 = Convert.ToInt32(rcmb_businessunit.SelectedValue.ToString());
            int s3 = Convert.ToInt32(rcmb_selectpayitemhead.SelectedItem.Value);
            if (Convert.ToDecimal(rtxt_minimumbonus.Text) <= Convert.ToDecimal(rtxt_maximumbonus.Text))
            {
                for (int INDEX = 0; INDEX < dt1.Rows.Count; INDEX++)
                {
                    if ((Convert.ToString(s1) == dt1.Rows[INDEX]["BUSINESSUNIT"].ToString()))// && (Convert.ToString(s3) == dt1.Rows[INDEX]["PAYITEM_HEAD"].ToString()))
                    {
                        flag = 1;
                        BLL.ShowMessage(this, "Master for Bonus Already Exists for this Businessunit");
                        rcmb_businessunit.SelectedIndex = -1;
                        rcmb_selectpayitemhead.SelectedIndex = -1;
                        return;
                    }
                }
                if (flag != 1)
                {
                    _obj_smhr_bonusmaster.OPERATION = operation.Insert;
                    _obj_smhr_bonusmaster.BUSINESSUNIT = Convert.ToInt32(rcmb_businessunit.SelectedValue.ToString());
                    _obj_smhr_bonusmaster.RESTRICTION_AMOUNT = Convert.ToDecimal(rtxt_restrictionamount.Text);
                    _obj_smhr_bonusmaster.MINIMUM_BONUS_PERCENTAGE = Convert.ToDecimal(rtxt_minimumbonus.Text);
                    _obj_smhr_bonusmaster.MAXIMUM_BONUS_PERCENTAGE = Convert.ToDecimal(rtxt_maximumbonus.Text);
                    _obj_smhr_bonusmaster.PAYITEM_HEAD = Convert.ToInt32(rcmb_selectpayitemhead.SelectedItem.Value);
                    _obj_smhr_bonusmaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_bonusmaster.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_bonusmaster.CREATEDDATE = DateTime.Now;
                    _obj_smhr_bonusmaster.MODIFIED_BY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_bonusmaster.MODIFIED_DATE = DateTime.Now;
                    if (BLL.insert(_obj_smhr_bonusmaster))
                    {
                        _obj_smhr_bonusmaster.OPERATION = operation.Select1;
                        DataTable DT_ID = new DataTable();
                        DT_ID = BLL.Get_SMHR_BONUSMASTER1(_obj_smhr_bonusmaster);
                        int count = chck_Payitems.Items.Count;
                        for (int i = 0; i < count; i++)
                        {
                            _obj_smhr_bonusmaster.OPERATION = operation.Insert1;
                            _obj_smhr_bonusmaster.BONUS_PAYITEM_BONUS_ID = Convert.ToInt32(DT_ID.Rows[0][0]);
                            _obj_smhr_bonusmaster.BONUS_PAYITEM_PAYITEMID = Convert.ToInt32(chck_Payitems.Items[i].Value);
                            _obj_smhr_bonusmaster.BONUS_PAYITEM_CHECKED = Convert.ToBoolean(chck_Payitems.Items[i].Selected);
                            if (BLL.insert(_obj_smhr_bonusmaster))
                            {
                                //BLL.ShowMessage(this, "Information Saved successfully");
                            }

                        }
                        BLL.ShowMessage(this, "Information Saved successfully");
                        RadMultiPage1.SelectedIndex = 0;
                        LoadGrid();
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Information Not Saved");
                    }
                }
            }
            else
            {
                BLL.ShowMessage(this, "Minimum Bonus Should be less than maximum bonus");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "bonus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
            DataTable dt_PeriodDetails = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //To load Business unit
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_businessunit.DataSource = dt_BUDetails;
            rcmb_businessunit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_businessunit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_businessunit.DataBind();
            rcmb_businessunit.Items.Insert(0, new RadComboBoxItem("Select"));
            chck_Payitems.Items.Clear();
            //to load payitem head
            _obj_Smhr_Payitems = new SMHR_PAYITEMS();
            _obj_Smhr_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Payitems.OPERATION = operation.Select1;
            //_obj_Smhr_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_PayItemDetails = BLL.fetch_PayItems(_obj_Smhr_Payitems);
            ViewState["payitems"] = dt_PayItemDetails;
            rcmb_selectpayitemhead.DataSource = dt_PayItemDetails;
            rcmb_selectpayitemhead.DataValueField = "PAYITEM_ID";
            rcmb_selectpayitemhead.DataTextField = "PAYITEM_PAYITEMNAME";
            rcmb_selectpayitemhead.DataBind();
            rcmb_selectpayitemhead.Items.Insert(0, new RadComboBoxItem("Select"));
            rcmb_selectpayitemhead.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "bonus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_selectpayitemhead_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //to load payitems
            _obj_Smhr_Payitems = new SMHR_PAYITEMS();
            DataTable dt_Recurring = new DataTable();
            _obj_Smhr_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Smhr_Payitems.OPERATION = operation.Select1;
            dt_Recurring = BLL.fetch_PayItems(_obj_Smhr_Payitems);
            DataTable dt_rec_new = new DataTable();
            for (int i = 0; i < dt_Recurring.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt_Recurring.Rows[i]["PAYITEM_ID"]) == Convert.ToInt32(rcmb_selectpayitemhead.SelectedItem.Value))
                {
                    dt_Recurring.Rows[i].Delete();
                }
            }
            chck_Payitems.DataSource = dt_Recurring;
            chck_Payitems.DataValueField = "PAYITEM_ID";
            chck_Payitems.DataTextField = "PAYITEM_PAYITEMNAME";
            chck_Payitems.DataBind();
            chck_Payitems.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "bonus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            rtxt_restrictionamount.Text = "";
            rtxt_minimumbonus.Text = "";
            rtxt_maximumbonus.Text = "";
            rcmb_businessunit.SelectedIndex = -1;
            rcmb_selectpayitemhead.SelectedIndex = -1;
            for (int i = 0; i < chck_Payitems.Items.Count; i++)
            {
                chck_Payitems.Items[i].Selected = false;
            }
            RadMultiPage1.SelectedIndex = 0;
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "bonus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_add(object sender, EventArgs e)
    {
        try
        {
            RadMultiPage1.SelectedIndex = 1;
            rcmb_businessunit.SelectedIndex = -1;
            rcmb_selectpayitemhead.SelectedIndex = -1;
            rcmb_businessunit.Enabled = true;
            btn_update.Visible = false;
            btnSave.Visible = true;
            rtxt_restrictionamount.Text = "";
            rtxt_minimumbonus.Text = "";
            rtxt_maximumbonus.Text = "";
            chck_Payitems.Items.Clear();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "bonus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            _obj_smhr_bonusmaster.OPERATION = operation.Select;
            _obj_smhr_bonusmaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_getbonusmaster1 = new DataTable();
            dt_getbonusmaster1 = BLL.Get_SMHR_BONUSMASTER1(_obj_smhr_bonusmaster);
            RadGrid1.DataSource = dt_getbonusmaster1;
            RadGrid1.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "bonus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lbtn_Edit_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            RadMultiPage1.SelectedIndex = 1;
            //code for security
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_update.Visible = false;

            }

            else
            {
                btn_update.Visible = true;
            }

            btnSave.Visible = false;
            string BONUS_ID = e.CommandArgument.ToString();
            ViewState["BONUS_ID"] = BONUS_ID;
            _obj_smhr_bonusmaster.BONUS_ID = Convert.ToInt32(BONUS_ID);
            _obj_smhr_bonusmaster.OPERATION = operation.Edit;
            DataTable dt_getdata = new DataTable();
            dt_getdata = BLL.Get_SMHR_BONUSMASTER1(_obj_smhr_bonusmaster);
            rcmb_businessunit.SelectedIndex = rcmb_businessunit.FindItemIndexByValue(dt_getdata.Rows[0]["BUSINESSUNIT"].ToString());
            rcmb_businessunit.Enabled = false;
            rtxt_restrictionamount.Text = dt_getdata.Rows[0]["RESTRICTION_AMOUNT"].ToString();
            rtxt_minimumbonus.Text = dt_getdata.Rows[0]["MINIMUM_BONUS_PERCENTAGE"].ToString();
            rtxt_maximumbonus.Text = dt_getdata.Rows[0]["MAXIMUM_BONUS_PERCENTAGE"].ToString();
            rcmb_selectpayitemhead.SelectedIndex = rcmb_selectpayitemhead.FindItemIndexByValue(dt_getdata.Rows[0]["PAYITEM_ID"].ToString());
            DataTable dt_Recurring = new DataTable();
            SMHR_PAYITEMS _obj_Smhr_Payitems = new SMHR_PAYITEMS();
            _obj_Smhr_Payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_Smhr_Payitems.OPERATION = operation.Select1;
            dt_Recurring = BLL.fetch_PayItems(_obj_Smhr_Payitems);
            for (int i = 0; i < dt_Recurring.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt_Recurring.Rows[i]["PAYITEM_ID"]) == Convert.ToInt32(rcmb_selectpayitemhead.SelectedItem.Value))
                {
                    dt_Recurring.Rows[i].Delete();
                }
            }
            chck_Payitems.DataSource = dt_Recurring;
            chck_Payitems.DataValueField = "PAYITEM_ID";
            chck_Payitems.DataTextField = "PAYITEM_PAYITEMNAME";
            chck_Payitems.DataBind();
            chck_Payitems.Visible = true;
            _obj_smhr_bonusmaster.OPERATION = operation.Check;
            DataTable dt_amt = new DataTable();
            dt_amt = BLL.Get_SMHR_BONUSMASTER1(_obj_smhr_bonusmaster);
            for (int i = 0; i < chck_Payitems.Items.Count; i++)
            {
                for (int j = 0; j < dt_amt.Rows.Count; j++)
                {
                    if (dt_amt.Rows[j]["BONUS_PAYITEM_CHECKED"].ToString() == "True")
                    {
                        chck_Payitems.Items[j].Selected = true;
                    }
                    else
                    {
                        chck_Payitems.Items[j].Selected = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "bonus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            chkstatus = 0;
            for (int k = 0; k < chck_Payitems.Items.Count; k++)
            {
                if (chck_Payitems.Items[k].Selected == false)
                {
                    chkstatus++;
                }
            }
            if (chkstatus == chck_Payitems.Items.Count)
            {
                BLL.ShowMessage(this, "Please Select Payitem");
                return;
            }
            _obj_smhr_bonusmaster.OPERATION = operation.Select1;
            DataTable DT_ID = new DataTable();
            DT_ID = BLL.Get_SMHR_BONUSMASTER1(_obj_smhr_bonusmaster);
            _obj_smhr_bonusmaster.BONUS_ID = Convert.ToInt32(ViewState["BONUS_ID"]);
            _obj_smhr_bonusmaster.OPERATION = operation.Update;
            _obj_smhr_bonusmaster.BUSINESSUNIT = Convert.ToInt32(rcmb_businessunit.SelectedValue.ToString());
            _obj_smhr_bonusmaster.RESTRICTION_AMOUNT = Convert.ToDecimal(rtxt_restrictionamount.Text);
            _obj_smhr_bonusmaster.MINIMUM_BONUS_PERCENTAGE = Convert.ToDecimal(rtxt_minimumbonus.Text);
            _obj_smhr_bonusmaster.MAXIMUM_BONUS_PERCENTAGE = Convert.ToDecimal(rtxt_maximumbonus.Text);
            _obj_smhr_bonusmaster.PAYITEM_HEAD = Convert.ToInt32(rcmb_selectpayitemhead.SelectedItem.Value);
            _obj_smhr_bonusmaster.MODIFIED_BY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_bonusmaster.MODIFIED_DATE = DateTime.Now;
            if (Convert.ToDecimal(rtxt_minimumbonus.Text) <= Convert.ToDecimal(rtxt_maximumbonus.Text))
            {
                if (BLL.insert(_obj_smhr_bonusmaster))
                {
                    _obj_smhr_bonusmaster.OPERATION = operation.Select1;
                    DataTable DT_ID1 = new DataTable();
                    DT_ID = BLL.Get_SMHR_BONUSMASTER1(_obj_smhr_bonusmaster);
                    int count = chck_Payitems.Items.Count;
                    for (int i = 0; i < count; i++)
                    {
                        _obj_smhr_bonusmaster.OPERATION = operation.Update1;
                        _obj_smhr_bonusmaster.BONUS_PAYITEM_BONUS_ID = _obj_smhr_bonusmaster.BONUS_ID;
                        _obj_smhr_bonusmaster.BONUS_PAYITEM_PAYITEMID = Convert.ToInt32(chck_Payitems.Items[i].Value);
                        _obj_smhr_bonusmaster.BONUS_PAYITEM_CHECKED = Convert.ToBoolean(chck_Payitems.Items[i].Selected);
                        if (BLL.insert(_obj_smhr_bonusmaster))
                        {
                            //BLL.ShowMessage(this, "Information Saved successfully");
                        }
                    }
                    BLL.ShowMessage(this, "Information Updated successfully");
                    RadMultiPage1.SelectedIndex = 0;
                    LoadGrid();
                }
                else
                {
                    BLL.ShowMessage(this, "Information Not Updated");
                }
            }

            else
            {
                BLL.ShowMessage(this, "Minimum Bonus Should be less than maximum bonus");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "bonus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


}