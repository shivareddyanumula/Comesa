
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

public partial class frm_bonustransaction : System.Web.UI.Page
{
    smhr_Bonus_trans _OBJ_BONUS_TRANS = new smhr_Bonus_trans();
    SMHR_PERIOD _obj_smhr_period;
    SMHR_EMPLOYEE _obj_smhr_employee;
    SMHR_PAYROLL _obj_smhr_payroll;
    static DataTable dt_Details;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_BONUSMASTER1 _obj_smhr_bonusmaster = new SMHR_BONUSMASTER1();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {

              //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("BONUS APPROVAL");
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
                    rg_bonusapprove.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_approve.Visible = false;
                    btn_reject.Visible = false;

                    //  btn_Update.Visible = false;
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
                LoadCombos();
            }
        }
        catch (Exception ex)
        {
            // BLL.ShowMessage(this, ex.ToString());
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransactionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
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
            rtxt_businessunit.DataSource = dt_BUDetails;
            rtxt_businessunit.DataValueField = "BUSINESSUNIT_ID";
            rtxt_businessunit.DataTextField = "BUSINESSUNIT_CODE";
            rtxt_businessunit.DataBind();
            rtxt_businessunit.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            // BLL.ShowMessage(this, ex.ToString());
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransactionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void ddl_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rtxt_period.SelectedIndex > 0)
            {

                _obj_smhr_payroll = new SMHR_PAYROLL();
                _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rtxt_period.SelectedValue);
                _obj_smhr_payroll.MODE = 11;
                dt_Details = new DataTable();
                dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
                rcmb_periodelements.DataSource = dt_Details;
                rcmb_periodelements.DataValueField = "PRDDTL_ID";
                rcmb_periodelements.DataTextField = "PRDDTL_NAME";
                rcmb_periodelements.DataBind();
                rcmb_periodelements.Items.Insert(0, new RadComboBoxItem("Select"));


            }


            else
            {

                rcmb_periodelements.Items.Clear();
                rg_bonusapprove.Visible = false;
                btncancelappr.Visible = false;
                lbl_header2.Visible = false;
            }

        }


        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransactionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_periodelements_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_periodelements.SelectedIndex > 0)
            {
                rg_bonusapprove.Visible = true;
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.Empty;
                _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rtxt_businessunit.SelectedValue);
                DataTable dt_Details = BLL.get_PayBusinessUnit(_obj_smhr_employee);
                if (Convert.ToString(Session["EMPTYPE"]) != "USERS")
                {
                    tbl_Approve.Visible = true;
                    _OBJ_BONUS_TRANS.BONUS_PERIOD_ID = Convert.ToInt32(rtxt_period.SelectedItem.Value);
                    _OBJ_BONUS_TRANS.BONUS_PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
                    _OBJ_BONUS_TRANS.BONUS_BU_ID = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
                    _OBJ_BONUS_TRANS.OPERATION = operation.Empty1;
                    DataTable dt_details_sub = BLL.Get_SMHR_BONUS_TRANS1(_OBJ_BONUS_TRANS);
                    ViewState["BONUS_TRANS"] = dt_details_sub;
                    if (dt_details_sub.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                        {

                            btn_approve.Visible = false;
                            btn_reject.Visible = false;
                        }

                        else
                        {
                            btn_approve.Visible = true;
                            btn_reject.Visible = true;


                        }
                    }
                    else
                    {

                        btn_approve.Visible = false;
                        btn_reject.Visible = false;
                        //btncancelappr.Visible = false;

                    }
                    rg_bonusapprove.DataSource = dt_details_sub;
                    rg_bonusapprove.DataBind();
                }
                else
                {
                    _obj_smhr_bonusmaster.BUSINESSUNIT = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
                    _obj_smhr_bonusmaster.PERIOD = Convert.ToInt32(rtxt_period.SelectedItem.Value);
                    _obj_smhr_bonusmaster.PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
                    LoadGrid();
                }
            }
            else
            {

                rg_bonusapprove.Visible = false;

                lbl_header2.Visible = false;

            }
        }


        catch (Exception ex)
        {
            //BLL.ShowMessage(this, ex.ToString());
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransactionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }

    protected void ddl_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rtxt_businessunit.SelectedIndex > 0)
            {
                _obj_smhr_period = new SMHR_PERIOD();
                dt_Details = new DataTable();
                _obj_smhr_period.OPERATION = operation.Select;
                _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
                _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_SMHR_LoginInfo.LOGIN_ID = 53;
                dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
                rtxt_period.DataSource = dt_Details;
                rtxt_period.DataValueField = "PERIOD_ID";
                rtxt_period.DataTextField = "PERIOD_NAME";
                rtxt_period.DataBind();
                rtxt_period.Items.Insert(0, new RadComboBoxItem("Select"));
                _OBJ_BONUS_TRANS.OPERATION = operation.Login;
                _OBJ_BONUS_TRANS.APPRCYCLE_ID = Convert.ToInt32(Session["EMP_TYPE"]);
                DataTable dt_login = BLL.Get_SMHR_BONUS_TRANS1(_OBJ_BONUS_TRANS);
                if (dt_login.Rows.Count > 0)
                {
                    Session["EMPTYPE"] = Convert.ToString(dt_login.Rows[0]["LOGTYP_CODE"]);
                }
            }
            else
            {
                rtxt_period.Items.Clear();
                rcmb_periodelements.Items.Clear();
                rg_bonusapprove.Visible = false;
                btncancelappr.Visible = false;
                lbl_header2.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransactionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void LoadGrid()
    {
        try
        {
            _OBJ_BONUS_TRANS = new smhr_Bonus_trans();//to check if records are exists or not
            _OBJ_BONUS_TRANS.OPERATION = operation.Check;
            _OBJ_BONUS_TRANS.BONUS_PERIOD_ID = Convert.ToInt32(rtxt_period.SelectedItem.Value);
            _OBJ_BONUS_TRANS.BONUS_PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
            _OBJ_BONUS_TRANS.BONUS_BU_ID = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
            DataTable dt_chk = BLL.Get_SMHR_BONUS_TRANS1(_OBJ_BONUS_TRANS);
            if (Convert.ToInt32(dt_chk.Rows[0][0]) > 0)
            {
                SMHR_BONUSMASTER1 _obj_bm = new SMHR_BONUSMASTER1();
                _obj_bm.OPERATION = operation.Select;
                _obj_bm.BUSINESSUNIT = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
                _OBJ_BONUS_TRANS.BUSINESSUNIT = Convert.ToString(rtxt_businessunit.SelectedItem.Text);
                _OBJ_BONUS_TRANS.OPERATION = operation.Delete;//to get the unchecked members...only
                DataTable dt_data = BLL.Get_SMHR_BONUS_TRANS1(_OBJ_BONUS_TRANS);
                ViewState["MINMAX"] = dt_data;
                if (dt_data.Rows.Count > 0)
                {
                }
                else
                {
                }
            }
            else
            {
                _obj_smhr_bonusmaster = new SMHR_BONUSMASTER1();
                _obj_smhr_bonusmaster.OPERATION = operation.Select;
                _obj_smhr_bonusmaster.BUSINESSUNIT = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
                _obj_smhr_bonusmaster.PERIOD = Convert.ToInt32(rtxt_period.SelectedItem.Value);
                _obj_smhr_bonusmaster.PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
                DataTable DT = BLL.Get_SMHR_BONUSMASTER(_obj_smhr_bonusmaster);
                ViewState["MINMAX"] = DT;
                if (DT.Rows.Count > 0)
                {
                }
                else
                {
                }
            }
        }
        catch (Exception ex)
        {
            //throw ex;
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransactionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rtxt_bonuspercentage12_TextChanged(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_bonusmaster = new SMHR_BONUSMASTER1();
            _obj_smhr_bonusmaster.OPERATION = operation.Select;
            _obj_smhr_bonusmaster.BUSINESSUNIT = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
            _obj_smhr_bonusmaster.PERIOD = Convert.ToInt32(rtxt_period.SelectedItem.Value);
            _obj_smhr_bonusmaster.PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
            DataTable DT = BLL.Get_SMHR_BONUSMASTER(_obj_smhr_bonusmaster);
            ViewState["MINMAX"] = DT;
            DataTable Dt_balance = new DataTable();
            Dt_balance = ViewState["MINMAX"] as DataTable;
            Telerik.Web.UI.RadNumericTextBox rtxt_bonuspercentage = sender as Telerik.Web.UI.RadNumericTextBox;
            if (rtxt_bonuspercentage.Text != string.Empty)
            {
                if ((Convert.ToDouble(rtxt_bonuspercentage.Text) < Convert.ToDouble(Dt_balance.Rows[0]["MINIMUM_BONUS_PERCENTAGE"])) || (Convert.ToDouble(rtxt_bonuspercentage.Text) > Convert.ToDouble(Dt_balance.Rows[0]["MAXIMUM_BONUS_PERCENTAGE"])))
                {

                    BLL.ShowMessage(this, "Bonus Should Be In The Range Of " + Dt_balance.Rows[0]["MINIMUM_BONUS_PERCENTAGE"] + " to " + Dt_balance.Rows[0]["MAXIMUM_BONUS_PERCENTAGE"] + "");
                    rtxt_bonuspercentage.Text = "";
                    rtxt_bonuspercentage.Focus();
                    return;
                }
                else
                {
                    GridItem gvRow = rtxt_bonuspercentage.Parent.Parent as GridItem;
                    CheckBox chk = (CheckBox)gvRow.FindControl("chckbtn_Select");
                    RadNumericTextBox rnt = (RadNumericTextBox)gvRow.FindControl("rtxt_bonus");
                    RadNumericTextBox rnt_totalvalue = (RadNumericTextBox)gvRow.FindControl("rtxt_bonusvalue");
                    RadNumericTextBox rnt_exgratia = (RadNumericTextBox)gvRow.FindControl("rtxt_exgratia");
                    RadNumericTextBox rnt1 = (RadNumericTextBox)gvRow.FindControl("rtxt_bonuspercentage");
                    DataTable dt_BONUS_TRANS = (DataTable)ViewState["BONUS_TRANS"];
                    rnt_totalvalue.Value = Math.Round(((Convert.ToDouble(dt_BONUS_TRANS.Rows[gvRow.ItemIndex]["BONUS"]) * Convert.ToDouble(rnt1.Value) / 100) * Convert.ToDouble(dt_BONUS_TRANS.Rows[gvRow.ItemIndex]["ATTENDANCE"])) / 30, 2);
                    if (rnt_totalvalue.Value >= 3500)
                    {
                        rnt.Value = 3500;
                        rnt_exgratia.Value = rnt_totalvalue.Value - 3500;
                    }
                    else
                    {
                        rnt.Value = rnt_totalvalue.Value;
                        rnt_exgratia.Value = 0;
                    }
                }
            }
            else
            {
                BLL.ShowMessage(this, "Enter Some Bonus Value");
                rtxt_bonuspercentage.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransactionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnapprove_Click(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            _OBJ_BONUS_TRANS = new smhr_Bonus_trans();
            _OBJ_BONUS_TRANS.BONUS_PERIOD_ID = Convert.ToInt32(rtxt_period.SelectedItem.Value);
            _OBJ_BONUS_TRANS.BONUS_PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
            _OBJ_BONUS_TRANS.BONUS_BU_ID = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
            _OBJ_BONUS_TRANS.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _OBJ_BONUS_TRANS.MODIFIED_BY = Convert.ToInt32(Session["USER_ID"]);
            _OBJ_BONUS_TRANS.MODIFIED_DATE = DateTime.Now;
            for (int k = 0; k < rg_bonusapprove.Items.Count; k++)
            {
                CheckBox chk = rg_bonusapprove.Items[k].FindControl("chckbtn_Select") as CheckBox;
                Label lbl_bonus_id = rg_bonusapprove.Items[k].FindControl("lbl_bonus_id") as Label;
                RadNumericTextBox rnt = new Telerik.Web.UI.RadNumericTextBox();
                RadNumericTextBox rnt_bonus_value = new Telerik.Web.UI.RadNumericTextBox();
                RadNumericTextBox rnt_bonus_totalvalue = new Telerik.Web.UI.RadNumericTextBox();
                RadNumericTextBox rnt_bonus_exgratia = new Telerik.Web.UI.RadNumericTextBox();
                rnt = rg_bonusapprove.Items[k].FindControl("rtxt_bonuspercentage") as RadNumericTextBox;
                rnt_bonus_value = rg_bonusapprove.Items[k].FindControl("rtxt_bonusvalue") as RadNumericTextBox;
                rnt_bonus_totalvalue = rg_bonusapprove.Items[k].FindControl("rtxt_bonus") as RadNumericTextBox;
                rnt_bonus_exgratia = rg_bonusapprove.Items[k].FindControl("rtxt_exgratia") as RadNumericTextBox;
                _OBJ_BONUS_TRANS.Bonus_trans_ID = Convert.ToInt32(lbl_bonus_id.Text);
                if (rnt.Text != string.Empty)
                {
                    _OBJ_BONUS_TRANS.Bonus_Percentage = Convert.ToDecimal(rnt.Text);
                }
                else
                {
                    DataTable Dt_balance = new DataTable();
                    Dt_balance = ViewState["MINMAX"] as DataTable;
                    _OBJ_BONUS_TRANS.Bonus_Percentage = Convert.ToDecimal(Dt_balance.Rows[0]["MINIMUM_BONUS_PERCENTAGE"]);
                }
                if (rnt_bonus_value.Text != string.Empty)
                {
                    _OBJ_BONUS_TRANS.BONUS_BONUSVALUE = Convert.ToDecimal(rnt_bonus_value.Text);
                    _OBJ_BONUS_TRANS.BONUS_TOTALVALUE = Convert.ToDecimal(rnt_bonus_totalvalue.Text);
                    _OBJ_BONUS_TRANS.BONUS_EXGRATIA = Convert.ToDecimal(rnt_bonus_exgratia.Text);
                }
                else
                {
                    //_OBJ_BONUS_TRANS.BONUS_BONUSVALUE = 0;
                    return;
                }

                _OBJ_BONUS_TRANS.Bonus_Trans_checked = Convert.ToBoolean(chk.Checked);
                if (chk.Checked)
                {
                    _OBJ_BONUS_TRANS.OPERATION = operation.Approve;
                    _OBJ_BONUS_TRANS.BONUS_COMMIT = 1;
                    _OBJ_BONUS_TRANS.BONUS_FINALCOMMIT = 1;
                    count++;
                }
                else
                {
                    _OBJ_BONUS_TRANS.OPERATION = operation.Approve;
                    _OBJ_BONUS_TRANS.BONUS_COMMIT = 1;
                    _OBJ_BONUS_TRANS.BONUS_FINALCOMMIT = 0;
                }
                BLL.bonus_trans_insrt(_OBJ_BONUS_TRANS);
            }

            SMHR_BONUSMASTER1 _obj_bm = new SMHR_BONUSMASTER1();
            _OBJ_BONUS_TRANS.BONUS_PERIOD_ID = Convert.ToInt32(rtxt_period.SelectedItem.Value);
            _OBJ_BONUS_TRANS.BONUS_PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
            _OBJ_BONUS_TRANS.BONUS_BU_ID = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
            _OBJ_BONUS_TRANS.OPERATION = operation.Empty1;
            DataTable dt_details_sub = BLL.Get_SMHR_BONUS_TRANS1(_OBJ_BONUS_TRANS);
            ViewState["BONUS_TRANS"] = dt_details_sub;
            if (dt_details_sub.Rows.Count > 0)
            {
                btn_approve.Visible = true;
                btn_reject.Visible = true;
            }
            else
            {
                btn_approve.Visible = false;
                btn_reject.Visible = false;
            }
            rg_bonusapprove.DataSource = dt_details_sub;
            rg_bonusapprove.DataBind();
            _obj_smhr_bonusmaster.OPERATION = operation.Select;
            _obj_smhr_bonusmaster.BUSINESSUNIT = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
            _obj_smhr_bonusmaster.PERIOD = Convert.ToInt32(rtxt_period.SelectedItem.Value);
            _obj_smhr_bonusmaster.PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
            if (count != 0)
            {
                BLL.ShowMessage(this, "Approved Successfully");
            }
            else
            {
                BLL.ShowMessage(this, "Select Employee To Approve");
            }
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransactionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnreject_Click(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            for (int k = 0; k < rg_bonusapprove.Items.Count; k++)
            {
                CheckBox chk = rg_bonusapprove.Items[k].FindControl("chckbtn_Select") as CheckBox;
                Label lbl_bonus_id = rg_bonusapprove.Items[k].FindControl("lbl_bonus_id") as Label;
                //smhr_Bonus_trans _OBJ_BONUS_TRANS = new smhr_Bonus_trans();
                _OBJ_BONUS_TRANS.OPERATION = operation.Delete1;//delete all records in the grid
                _OBJ_BONUS_TRANS.Bonus_trans_ID = Convert.ToInt32(lbl_bonus_id.Text);
                _OBJ_BONUS_TRANS.BONUS_PERIOD_ID = Convert.ToInt32(rtxt_period.SelectedItem.Value);
                _OBJ_BONUS_TRANS.BONUS_PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
                _OBJ_BONUS_TRANS.BONUS_BU_ID = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
                if (chk.Checked)
                {
                    BLL.bonus_trans_insrt(_OBJ_BONUS_TRANS);
                    count++;
                }
            }
            if (count != 0)
            {
                BLL.ShowMessage(this, "Rejected Successfully");
            }
            else
            {
                BLL.ShowMessage(this, "Select Employee To Reject");
            }

            _OBJ_BONUS_TRANS.OPERATION = operation.Empty1;
            DataTable dt_details_sub = BLL.Get_SMHR_BONUS_TRANS1(_OBJ_BONUS_TRANS);
            ViewState["BONUS_TRANS"] = dt_details_sub;
            if (dt_details_sub.Rows.Count > 0)
            {
                btn_approve.Visible = true;
                btn_reject.Visible = true;
            }
            else
            {
                btn_approve.Visible = false;
                btn_reject.Visible = false;
            }
            rg_bonusapprove.DataSource = dt_details_sub;
            rg_bonusapprove.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransactionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btncancelappr_Click(object sender, EventArgs e)
    {
        try
        {
            for (int k = 0; k < rg_bonusapprove.Items.Count; k++)
            {
                CheckBox chk = rg_bonusapprove.Items[k].FindControl("chckbtn_Select") as CheckBox;
                Label lbl_bonus_id = rg_bonusapprove.Items[k].FindControl("lbl_bonus_id") as Label;
                chk.Checked = false;
            }
            rmp_bonus.SelectedIndex = 0;


            tbl_Approve.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransactionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_pastdetails_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "Bonus_History()", true);
        }
        catch (Exception ex)
        {
            // BLL.ShowMessage(this, ex.ToString());
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransactionApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

}