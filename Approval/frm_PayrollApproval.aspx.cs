﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;

public partial class Approval_frm_PayrollApproval : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_PERIOD _obj_smhr_period;
    SMHR_PAYROLL _obj_smhr_payroll;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;

    static DataTable dt_Details;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                LoadCombos();
                RG_PayTran.Visible = false;
                chk_CheckAll.Visible = false;
                chk_CheckAll.Checked = false;


            }
            Session.Remove("WRITEFACILITY");

            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("PAYROLL APPROVAL");
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
                RG_PayTran.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Approve.Visible = false;
                btn_Reject.Visible = false;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    private void LoadCombos()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_period = new SMHR_PERIOD();
            dt_Details = new DataTable();

            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            if (dt_Details.Rows.Count != 0)
            {
                rcb_Period.DataSource = dt_Details;
                rcb_Period.DataValueField = "PERIOD_ID";
                rcb_Period.DataTextField = "PERIOD_NAME";
                rcb_Period.DataBind();
                rcb_Period.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            rcmb_businessunit.Items.Clear();
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }

    protected void rcb_Period_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcb_Period.SelectedIndex != 0)
            {
                _obj_smhr_payroll = new SMHR_PAYROLL();
                _obj_smhr_payroll.MODE = 29;
                _obj_smhr_payroll.PERODID = Convert.ToInt32(rcb_Period.SelectedValue);
                dt_Details = BLL.get_Payroll(_obj_smhr_payroll);
                rcb_PeriodElements.DataSource = dt_Details;
                rcb_PeriodElements.DataValueField = "EMPSALDTLS_PRDDTL_ID";
                rcb_PeriodElements.DataTextField = "PRDDTL_NAME";
                rcb_PeriodElements.DataBind();
                rcb_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select"));
                RG_PayTran.Visible = false;
                chk_CheckAll.Visible = false;
                chk_CheckAll.Checked = false;
                lnk.Visible = false;
                btn_Approve.Enabled = false;
                btn_Reject.Enabled = false;
                rcb_Paytran.Items.Clear();
                rcb_Paytran.Text = String.Empty;
                rcmb_businessunit.Items.Clear();
                rcmb_businessunit.Text = String.Empty;
                if ((rcb_PeriodElements.SelectedIndex > 0) && (rcmb_businessunit.SelectedIndex > 0))
                {
                    lnk.Visible = true;
                }
            }
            else
            {
                rcb_PeriodElements.Items.Clear();
                rcb_PeriodElements.Text = String.Empty;
                rcb_Paytran.Items.Clear();
                rcb_Paytran.Text = string.Empty;
                rcmb_businessunit.Items.Clear();
                rcmb_businessunit.Text = string.Empty;
                RG_PayTran.Visible = false;
                chk_CheckAll.Visible = false;
                chk_CheckAll.Checked = false;
                lnk.Visible = false;
                btn_Approve.Enabled = false;
                btn_Reject.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcb_Paytran_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcb_Paytran.SelectedIndex != 0)
            {
                LoadGrid();
                RG_PayTran.Visible = true;
                chk_CheckAll.Visible = true;
                chk_CheckAll.Checked = false;

                if ((rcb_Period.SelectedIndex > 0) && (rcb_PeriodElements.SelectedIndex > 0))
                {
                    lnk.Visible = true;
                }

            }
            else
            {
                lnk.Visible = false;
                RG_PayTran.Visible = false;
                chk_CheckAll.Visible = false;
                chk_CheckAll.Checked = false;
                btn_Approve.Enabled = false;
                btn_Reject.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcb_PeriodElements_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //if (rcb_PeriodElements.SelectedIndex != 0)
            //{
            //    _obj_smhr_payroll = new SMHR_PAYROLL();
            //    _obj_smhr_payroll.OPERATION = operation.Empty;
            //    _obj_smhr_payroll.MODE = 3;
            //    _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcb_PeriodElements.SelectedItem.Value);
            //    dt_Details = new DataTable();
            //    dt_Details = BLL.get_Payroll(_obj_smhr_payroll);
            //    if (dt_Details.Rows.Count != 0)
            //    {
            //        rcb_Paytran.DataSource = dt_Details;
            //        rcb_Paytran.DataTextField = "TEMP_PAYTRAN_NAME";
            //        rcb_Paytran.DataValueField = "TEMP_PAYTRAN_ID";
            //        rcb_Paytran.DataBind();
            //        rcb_Paytran.Items.Insert(0, new RadComboBoxItem("Select"));
            //    }
            //}
            //else
            //{
            //    rcb_Paytran.Items.Clear();
            //    chk_CheckAll.Visible = false;
            //    chk_CheckAll.Checked = false;
            //}

            //To load Business unit
            if (rcb_PeriodElements.SelectedIndex != 0)
            {
                _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
                _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
                if (dt_BUDetails.Rows.Count != 0)
                {
                    rcmb_businessunit.DataSource = dt_BUDetails;
                    rcmb_businessunit.DataValueField = "BUSINESSUNIT_ID";
                    rcmb_businessunit.DataTextField = "BUSINESSUNIT_CODE";
                    rcmb_businessunit.DataBind();
                    rcmb_businessunit.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                rcb_Paytran.Items.Clear();
                rcb_Paytran.Text = string.Empty;
                RG_PayTran.Visible = false;
                chk_CheckAll.Visible = false;
                chk_CheckAll.Checked = false;
                btn_Approve.Enabled = false;
                btn_Reject.Enabled = false;
                if ((rcb_Period.SelectedIndex > 0) && (rcmb_businessunit.SelectedIndex > 0))
                    lnk.Visible = true;
                else
                    lnk.Visible = false;
            }
            else
            {
                rcb_Paytran.Items.Clear();
                rcb_Paytran.Text = string.Empty;
                rcmb_businessunit.Items.Clear();
                rcmb_businessunit.Text = string.Empty;
                chk_CheckAll.Visible = false;
                chk_CheckAll.Checked = false;
                lnk.Visible = false;
                RG_PayTran.Visible = false;
                btn_Approve.Enabled = false;
                btn_Reject.Enabled = false;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }

    protected void btn_Approve_Click(object sender, EventArgs e)
    {
        try
        {
            bool status1 = true;
            //status1 = chkAuthority();
            if (status1 == true)
            {
                CheckBox chkBox = new CheckBox();
                string str = "";
                Label lblID = new Label();
                for (int index = 0; index <= RG_PayTran.Items.Count - 1; index++)
                {
                    chkBox = RG_PayTran.Items[index].FindControl("chk_Choose") as CheckBox;
                    lblID = RG_PayTran.Items[index].FindControl("lblID") as Label;
                    if (chkBox.Checked)
                    {
                        if (str == "")
                        {
                            str = "''" + lblID.Text + "''";
                        }
                        else
                        {
                            str = str + ",''" + lblID.Text + "''";
                        }
                    }
                }
                if (str != null && str != "")
                {
                    bool status = false;
                    _obj_smhr_payroll = new SMHR_PAYROLL();
                    _obj_smhr_payroll.TRANID = Convert.ToInt32(rcb_Paytran.SelectedItem.Value);
                    _obj_smhr_payroll.STATUS = 1;
                    _obj_smhr_payroll.EMP_ID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_payroll.EMPDATA = Convert.ToString(str);
                    _obj_smhr_payroll.PERODID = Convert.ToInt32(rcb_PeriodElements.SelectedValue);
                    status = BLL.set_Payroll(_obj_smhr_payroll);
                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Payroll Approval Process successfully done");
                        LoadGrid();
                        chk_CheckAll.Checked = false;
                        return;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Please select the Employees to Approve");
                    return;
                }
            }
            else
            {
                BLL.ShowMessage(this, "You are not authorized for approval");
                btn_Approve.Enabled = false;
                btn_Reject.Enabled = false;
                RG_PayTran.Visible = false;
                chk_CheckAll.Visible = false;
                chk_CheckAll.Checked = false;
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadGrid()
    {
        try
        {
            _obj_smhr_payroll = new SMHR_PAYROLL();
            _obj_smhr_payroll.OPERATION = operation.Check;
            _obj_smhr_payroll.MODE = 2;
            _obj_smhr_payroll.TRANID = Convert.ToInt32(rcb_Paytran.SelectedItem.Value);
            dt_Details = new DataTable();
            dt_Details = BLL.get_Payroll(_obj_smhr_payroll);
            RG_PayTran.DataSource = dt_Details;
            RG_PayTran.DataBind();
            int i = 0;
            int j = 0;
            Label lbl_Amt = new Label();
            for (i = 0; i < RG_PayTran.Items.Count; i++)
            {
                lbl_Amt = RG_PayTran.Items[i].FindControl("lblAmount") as Label;
                if (lbl_Amt.Text.StartsWith("-"))
                {
                    lbl_Amt.BackColor = System.Drawing.Color.Red;
                    lbl_Amt.ToolTip = "Negative Balance for this Employee";
                    j = j + 1;
                }
            }
            if (j > 0)
            {
                btn_Approve.Enabled = true;
                btn_Reject.Enabled = true;
                BLL.ShowMessage(this, "There are employee(s) with negative balance");
            }
            else
            {
                //code for security
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Approve.Enabled = false;
                    btn_Reject.Enabled = false;

                }

                else
                {
                    btn_Approve.Enabled = true;
                    btn_Reject.Enabled = true;
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private bool chkAuthority()
    {
        try
        {
            _obj_smhr_payroll = new SMHR_PAYROLL();
            _obj_smhr_payroll.TRANID = Convert.ToInt32(rcb_Paytran.SelectedItem.Value);
            _obj_smhr_payroll.MODE = 9;
            DataTable dt = BLL.get_PayApproval(_obj_smhr_payroll);
            if (dt.Rows.Count != 0)
            {
                if (Convert.ToString(dt.Rows[0]["TEMP_PAYTRAN_APPROVERS"]).IndexOf(Convert.ToString(Session["USER_ID"])) == -1)
                {

                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return false;
        }
    }

    protected void btn_Reject_Click1(object sender, EventArgs e)
    {
        try
        {
            bool status1 = false;
            // changed by sridevi on (24/02/2011)
            //status1 = chkAuthority();

            status1 = true;
            if (status1 == true)
            {
                int i = 0;
                CheckBox chkBox = new CheckBox();
                string str = null;
                Label lblID = new Label();
                for (int index = 0; index <= RG_PayTran.Items.Count - 1; index++)
                {
                    chkBox = RG_PayTran.Items[index].FindControl("chk_Choose") as CheckBox;
                    lblID = RG_PayTran.Items[index].FindControl("lblID") as Label;
                    if (chkBox.Checked)
                    {
                        if (str == null)
                        {
                            str = "''" + lblID.Text + "''";
                        }
                        else
                        {
                            str = str + ",''" + lblID.Text + "''";
                        }
                    }
                }
                if (str != null && str != "")
                {
                    bool status = false;
                    _obj_smhr_payroll = new SMHR_PAYROLL();
                    _obj_smhr_payroll.TRANID = Convert.ToInt32(rcb_Paytran.SelectedItem.Value);
                    _obj_smhr_payroll.EMPDATA = Convert.ToString(str);
                    _obj_smhr_payroll.MODE = 1;
                    _obj_smhr_payroll.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_payroll.LASTMDFDATE = DateTime.Now;
                    _obj_smhr_payroll.PERODID = Convert.ToInt32(rcb_PeriodElements.SelectedValue);
                    status = BLL.set_PayrollReject(_obj_smhr_payroll);
                    if (status == true)
                    {
                        if (RG_PayTran.Items.Count != 0)
                        {
                            BLL.ShowMessage(this, "Payroll rejection Process Successfully done for the selected employee(s)");
                            LoadGrid();
                            return;
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Payroll rejection Process successfully done");
                            btn_Approve.Visible = false;
                            btn_Reject.Visible = false;
                            chk_CheckAll.Visible = false;
                            chk_CheckAll.Checked = false;
                            LoadGrid();
                            rcb_Paytran.Items.Clear();
                            rcb_PeriodElements.Items.Clear();
                            rcb_Period.SelectedIndex = -1;
                            return;
                        }
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Please Select the Employees for Rejection");
                    return;
                }
            }
            else
            {
                BLL.ShowMessage(this, "You are not authorized for rejection");
                btn_Approve.Enabled = false;
                btn_Reject.Enabled = false;
                RG_PayTran.Visible = false;
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void chk_CheckAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chk_CheckAll.Checked)
            {
                CheckBox chkBox = new CheckBox();
                for (int index = 0; index <= RG_PayTran.Items.Count - 1; index++)
                {
                    chkBox = RG_PayTran.Items[index].FindControl("chk_Choose") as CheckBox;
                    chkBox.Checked = true;
                }
            }
            else
            {
                CheckBox chkBox = new CheckBox();
                for (int index = 0; index <= RG_PayTran.Items.Count - 1; index++)
                {
                    chkBox = RG_PayTran.Items[index].FindControl("chk_Choose") as CheckBox;
                    chkBox.Checked = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["DASHBOARD"] != null)
            {
                Response.Redirect("~/Security/frm_Dashboradmngr.aspx", false);
            }
            else
            {
                Response.Redirect("~/Masters/Default.aspx", false);
            }
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_businessunit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_businessunit.SelectedIndex != 0)
            {
                rcb_Paytran.Items.Clear();
                _obj_smhr_payroll = new SMHR_PAYROLL();
                _obj_smhr_payroll.OPERATION = operation.Empty;
                _obj_smhr_payroll.MODE = 3;
                _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcb_PeriodElements.SelectedItem.Value);
                _obj_smhr_payroll.BUID = Convert.ToInt32(rcmb_businessunit.SelectedItem.Value);
                dt_Details = new DataTable();
                dt_Details = BLL.get_Payroll(_obj_smhr_payroll);
                if (dt_Details.Rows.Count != 0)
                {
                    rcb_Paytran.DataSource = dt_Details;
                    rcb_Paytran.DataTextField = "TEMP_PAYTRAN_NAME";
                    rcb_Paytran.DataValueField = "TEMP_PAYTRAN_ID";
                    rcb_Paytran.DataBind();
                    rcb_Paytran.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                else
                {
                    rcb_Paytran.Items.Insert(0, new RadComboBoxItem("Select"));
                }
            
                RG_PayTran.Visible = false;
                chk_CheckAll.Visible = false;
                chk_CheckAll.Checked = false;
                lnk.Visible = false;
                btn_Approve.Enabled = false;
                btn_Reject.Enabled = false;
                //if ((rcb_Period.SelectedIndex > 0) && (rcb_PeriodElements.SelectedIndex > 0))
                //{
                //    lnk.Visible = true;
                //}
            }
            else
            {
                rcb_Paytran.Items.Clear();
                rcb_Paytran.Text = String.Empty;
                RG_PayTran.Visible = false;
                chk_CheckAll.Visible = false;
                chk_CheckAll.Checked = false;
                lnk.Visible = false;
                RG_PayTran.Visible = false;
                btn_Approve.Enabled = false;
                btn_Reject.Enabled = false;
                //lnk.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt_Local = BLL.ExecuteQuery("SELECT BUSINESSUNIT_LOCALISATION,HR_MASTER_CODE FROM SMHR_BUSINESSUNIT " +
                                             "  JOIN SMHR_HR_MASTER ON " +
                                             "  BUSINESSUNIT_LOCALISATION = HR_MASTER_ID WHERE BUSINESSUNIT_ID = '" + Convert.ToInt32(rcmb_businessunit.SelectedValue) + "'");

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcb_Period.SelectedValue)
                + "','" + Convert.ToString(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_businessunit.SelectedValue)
                + "','" + Convert.ToInt32(rcb_PeriodElements.SelectedValue) + "','" + Convert.ToString(rcb_Paytran.SelectedValue)
                + "','" + Convert.ToString(dt_Local.Rows[0]["HR_MASTER_CODE"]) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}