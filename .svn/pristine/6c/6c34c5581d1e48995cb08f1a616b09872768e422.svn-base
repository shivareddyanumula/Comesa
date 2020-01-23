
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


                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE BONUS TRANSACTION");
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
                    btn_save.Visible = false;
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
                LoadCombos();
                if (Convert.ToString(Session["USER_NAME"]) == "fjfjhdj")
                {
                    rtxt_payitemhead.Visible = false;
                    rtxt_payitemperiod.Visible = false;
                    lbl_payitemhead.Visible = false;
                    lbl_payitemperiod.Visible = false;
                    lbl_colon3.Visible = false;
                    lbl_colon4.Visible = false;
                }
                else
                {
                    rtxt_payitemhead.Visible = true;
                    rtxt_payitemperiod.Visible = true;
                    lbl_payitemhead.Visible = true;
                    lbl_payitemperiod.Visible = true;
                    lbl_colon3.Visible = true;
                    lbl_colon4.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
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
            rg_employees.Visible = false;
            btn_save.Visible = false;
            rtxt_payitemhead.Text = "";
            rtxt_payitemperiod.Text = "";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
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
                //SMHR_PERIODDTL _obj_smhr_perioddtl1 = new SMHR_PERIODDTL();
                //_obj_smhr_perioddtl1.OPERATION = operation.Select;
                //_obj_smhr_perioddtl1.PRDDTL_PERIOD_ID = Convert.ToInt32(rtxt_period.SelectedItem.Value);
                //DataTable dt_Details = BLL.get_PeriodDetails(_obj_smhr_perioddtl1);
                //if (dt_Details.Rows.Count != 0)
                //{
                //    rcmb_periodelements.DataSource = dt_Details;
                //    rcmb_periodelements.DataValueField = "PRDDTL_ID";
                //    rcmb_periodelements.DataTextField = "PRDDTL_NAME";
                //    rcmb_periodelements.DataBind();
                //    rcmb_periodelements.Items.Insert(0, new RadComboBoxItem("Select"));
                //}
                rg_employees.Visible = false;
                btn_save.Visible = false;
                rtxt_payitemhead.Text = "";
                rtxt_payitemperiod.Text = "";
            }
            else
            {
                rcmb_periodelements.Items.Clear();
                rg_employees.Visible = false;
                rtxt_payitemhead.Text = "";
                rtxt_payitemperiod.Text = "";
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_periodelements_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //TO LOAD PAYITEM
            if (rcmb_periodelements.SelectedIndex > 0)
            {
                _obj_smhr_bonusmaster.OPERATION = operation.Get;
                _obj_smhr_bonusmaster.BUSINESSUNIT = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
                DataTable dt_payitem = BLL.Get_SMHR_BONUSMASTER1(_obj_smhr_bonusmaster);
                if (dt_payitem.Rows.Count > 0)
                {
                    rtxt_payitemhead.Text = Convert.ToString(dt_payitem.Rows[0]["PAYITEM_PAYITEMNAME"]);
                    rtxt_payitemperiod.Text = Convert.ToString(dt_payitem.Rows[0]["PAYITEM_PERIOD"]);
                    Session["PAYITEM_HEAD"] = Convert.ToInt32(dt_payitem.Rows[0]["PAYITEM_ID"]);
                    rg_employees.Visible = true;
                }
                else
                {
                    rtxt_payitemhead.Text = string.Empty;
                    rtxt_payitemperiod.Text = string.Empty;
                    rg_employees.Visible = false;

                }
                rtxt_payitemhead.Enabled = false;
                rtxt_payitemperiod.Enabled = false;

                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.Empty;
                _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rtxt_businessunit.SelectedValue);
                DataTable dt_Details = BLL.get_PayBusinessUnit(_obj_smhr_employee);
                if (Convert.ToString(Session["USER_NAME"]) == "fjfjhdj")
                {
                    rmp_bonus.SelectedIndex = 2;
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
                            btn_reject.Visible = false;
                            btn_approve.Visible = false;

                        }

                        else
                        {
                            btn_reject.Visible = true;
                            btn_approve.Visible = true;
                        }


                    }
                    else
                    {
                        btn_approve.Visible = false;
                        btn_reject.Visible = false;
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
                rg_employees.Visible = false;
                rtxt_payitemhead.Text = "";
                rtxt_payitemperiod.Text = "";
                btn_save.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
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
                rg_employees.Visible = false;
                btn_save.Visible = false;
                rtxt_payitemhead.Text = "";
                rtxt_payitemperiod.Text = "";
                rcmb_periodelements.Items.Clear();
                if (dt_login.Rows.Count > 0)
                {
                    Session["USER_NAME"] = Convert.ToString(dt_login.Rows[0]["LOGTYP_CODE"]);
                }
            }
            else
            {
                rtxt_period.Items.Clear();
                rg_employees.Visible = false;
                btn_save.Visible = false;
                rtxt_payitemhead.Text = "";
                rtxt_payitemperiod.Text = "";
                rcmb_periodelements.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
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
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_save.Visible = false;

                    }

                    else
                    {
                        btn_save.Visible = true;
                    }

                }
                else
                {
                    btn_save.Visible = false;
                }
                rg_employees.DataSource = dt_data;
                rg_employees.DataBind();
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
                    if (Convert.ToInt32(DT.Rows[0][0]) == 0)
                    {
                        BLL.ShowMessage(this, "Please Define Masters of Bonus For this Businessunit.");
                        return;
                    }
                    btn_save.Visible = true;
                }
                else
                {
                    btn_save.Visible = false;
                }

                rg_employees.DataSource = DT;
                rg_employees.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            submit(_OBJ_BONUS_TRANS);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    public void submit(smhr_Bonus_trans _OBJ_BONUS_TRANS)
    {
        try
        {
            int count = 0;
            _OBJ_BONUS_TRANS.BONUS_PERIOD_ID = Convert.ToInt32(rtxt_period.SelectedItem.Value);
            _OBJ_BONUS_TRANS.BONUS_PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
            _OBJ_BONUS_TRANS.BONUS_BU_ID = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
            Session["BUSINESSUNIT"] = _OBJ_BONUS_TRANS.BONUS_BU_ID;
            _OBJ_BONUS_TRANS.MODIFIED_BY = Convert.ToInt32(Session["USER_ID"]);
            _OBJ_BONUS_TRANS.MODIFIED_DATE = DateTime.Now;
            for (int k = 0; k < rg_bonuscalculation.Items.Count; k++)
            {
                CheckBox chk = rg_bonuscalculation.Items[k].FindControl("chckbtn_Select") as CheckBox;
                Label lbl_bonus_id = rg_bonuscalculation.Items[k].FindControl("lbl_bonus_id") as Label;
                RadNumericTextBox rnt = new Telerik.Web.UI.RadNumericTextBox();
                RadNumericTextBox rnt_bonus_value = new Telerik.Web.UI.RadNumericTextBox();
                RadNumericTextBox rnt_bonus_totalvalue = new Telerik.Web.UI.RadNumericTextBox();
                RadNumericTextBox rnt_bonus_exgratia = new Telerik.Web.UI.RadNumericTextBox();
                rnt = rg_bonuscalculation.Items[k].FindControl("rtxt_bonuspercentage") as RadNumericTextBox;
                rnt_bonus_value = rg_bonuscalculation.Items[k].FindControl("rtxt_bonusvalue") as RadNumericTextBox;
                rnt_bonus_totalvalue = rg_bonuscalculation.Items[k].FindControl("rtxt_bonus") as RadNumericTextBox;
                rnt_bonus_exgratia = rg_bonuscalculation.Items[k].FindControl("rtxt_exgratia") as RadNumericTextBox;
                _OBJ_BONUS_TRANS.Bonus_trans_ID = Convert.ToInt32(lbl_bonus_id.Text);
                if (rnt.Text != string.Empty)
                {
                    _OBJ_BONUS_TRANS.Bonus_Percentage = Convert.ToDecimal(rnt.Text);

                }
                else
                {
                    //DataTable Dt_balance = new DataTable();
                    //Dt_balance = ViewState["MINMAX"] as DataTable;
                    //_OBJ_BONUS_TRANS.Bonus_Percentage = Convert.ToDecimal(Dt_balance.Rows[0]["MINIMUM_BONUS_PERCENTAGE"]);
                    return;
                }
                if (rnt_bonus_value.Text != string.Empty)
                {
                    _OBJ_BONUS_TRANS.BONUS_BONUSVALUE = Convert.ToDecimal(rnt_bonus_value.Text);
                    _OBJ_BONUS_TRANS.BONUS_TOTALVALUE = Convert.ToDecimal(rnt_bonus_totalvalue.Text);
                    _OBJ_BONUS_TRANS.BONUS_EXGRATIA = Convert.ToDecimal(rnt_bonus_exgratia.Text);
                }
                else
                {
                    _OBJ_BONUS_TRANS.BONUS_BONUSVALUE = 0;
                }

                _OBJ_BONUS_TRANS.Bonus_Trans_checked = Convert.ToBoolean(chk.Checked);
                if (chk.Checked)
                {
                    _OBJ_BONUS_TRANS.OPERATION = operation.Approve;
                    _OBJ_BONUS_TRANS.BONUS_COMMIT = 1;
                    count++;

                }
                else
                {
                    _OBJ_BONUS_TRANS.OPERATION = operation.Delete1;

                }
                BLL.bonus_trans_insrt(_OBJ_BONUS_TRANS);
            }
            SMHR_BONUSMASTER1 _obj_bm1 = new SMHR_BONUSMASTER1();
            _OBJ_BONUS_TRANS.BONUS_BU_ID = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
            _OBJ_BONUS_TRANS.BONUS_PERIOD_ID = Convert.ToInt32(rtxt_period.SelectedItem.Value);
            _OBJ_BONUS_TRANS.BONUS_PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
            _OBJ_BONUS_TRANS.OPERATION = operation.Empty;
            DataTable dt_details_sub1 = BLL.Get_SMHR_BONUS_TRANS1(_OBJ_BONUS_TRANS);
            ViewState["BONUS_TRANS"] = dt_details_sub1;

            if (count != 0)
            {
                if (dt_details_sub1.Rows.Count > 0)
                {
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_submit.Visible = false;

                    }

                    else
                    {
                        btn_submit.Visible = true;
                    }

                }

                else
                {
                    btn_submit.Visible = false;
                }
                rg_bonuscalculation.DataSource = dt_details_sub1;
                rg_bonuscalculation.DataBind();
                _obj_smhr_bonusmaster.OPERATION = operation.Select;
                _obj_smhr_bonusmaster.BUSINESSUNIT = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
                _obj_smhr_bonusmaster.PERIOD = Convert.ToInt32(rtxt_period.SelectedItem.Value);
                _obj_smhr_bonusmaster.PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
                SMHR_BONUSMASTER1 _obj_bm = new SMHR_BONUSMASTER1();
                _obj_bm.BUSINESSUNIT = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
                _obj_bm.OPERATION = operation.Select;
                _OBJ_BONUS_TRANS.BONUS_BU_ID = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
                _OBJ_BONUS_TRANS.BONUS_PERIOD_ID = Convert.ToInt32(rtxt_period.SelectedItem.Value);
                _OBJ_BONUS_TRANS.BONUS_PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
                _OBJ_BONUS_TRANS.OPERATION = operation.Empty1;
                DataTable dt_details_sub = BLL.Get_SMHR_BONUS_TRANS1(_OBJ_BONUS_TRANS);
                ViewState["BONUS_TRANS"] = dt_details_sub;
                if (dt_details_sub.Rows.Count > 0)
                {
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_reject.Visible = false;
                        btn_approve.Visible = false;

                    }

                    else
                    {
                        btn_reject.Visible = true;
                        btn_approve.Visible = true;
                    }


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
                BLL.ShowMessage(this, "Submitted Successfully");
                LoadGrid();
                rmp_bonus.SelectedIndex = 0;
                return;
            }
            else
            {
                BLL.ShowMessage(this, "Select Employee To Submit");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        try
        {
            for (int k = 0; k < rg_bonuscalculation.Items.Count; k++)
            {
                Label lbl_bonus_id = rg_bonuscalculation.Items[k].FindControl("lbl_bonus_id") as Label;
                smhr_Bonus_trans _OBJ_BONUS_TRANS = new smhr_Bonus_trans();
                _OBJ_BONUS_TRANS.OPERATION = operation.Delete1;//delete all records in the grid
                _OBJ_BONUS_TRANS.Bonus_trans_ID = Convert.ToInt32(lbl_bonus_id.Text);
                _OBJ_BONUS_TRANS.BONUS_PERIOD_ID = Convert.ToInt32(rtxt_period.SelectedItem.Value);
                _OBJ_BONUS_TRANS.BONUS_PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
                _OBJ_BONUS_TRANS.BONUS_BU_ID = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
                BLL.bonus_trans_insrt(_OBJ_BONUS_TRANS);
            }
            LoadGrid();
            BLL.ShowMessage(this, "Cancelled Successfully");
            rmp_bonus.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            smhr_Bonus_trans _OBJ_BONUS_TRANS = new smhr_Bonus_trans();
            _OBJ_BONUS_TRANS.OPERATION = operation.Insert;
            _OBJ_BONUS_TRANS.BONUS_PERIOD_ID = Convert.ToInt32(rtxt_period.SelectedItem.Value);
            _OBJ_BONUS_TRANS.BONUS_PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
            _OBJ_BONUS_TRANS.BONUS_BU_ID = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
            _OBJ_BONUS_TRANS.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _OBJ_BONUS_TRANS.BONUS_PAYITEM_HEAD = Convert.ToInt32(Session["PAYITEM_HEAD"]);
            _OBJ_BONUS_TRANS.CREATED_BY = Convert.ToInt32(Session["USER_ID"]);
            //_OBJ_BONUS_TRANS.CREATED_DATE = DateTime.Now;
            _OBJ_BONUS_TRANS.MODIFIED_BY = Convert.ToInt32(Session["USER_ID"]);
            //_OBJ_BONUS_TRANS.MODIFIED_DATE = DateTime.Now;

            for (int k = 0; k < rg_employees.Items.Count; k++)
            {
                CheckBox chk = rg_employees.Items[k].FindControl("chckbtn_Select") as CheckBox;
                Label lbl_emp_id = rg_employees.Items[k].FindControl("lbl_emp_id") as Label;
                RadNumericTextBox rnt = new Telerik.Web.UI.RadNumericTextBox();
                rnt = rg_employees.Items[k].FindControl("rtxt_bonuspercentage") as RadNumericTextBox;
                _OBJ_BONUS_TRANS.Bonus_Emp_ID = Convert.ToInt32(lbl_emp_id.Text);
                if (rnt.Text != string.Empty)
                {
                    _OBJ_BONUS_TRANS.Bonus_Percentage = Convert.ToDecimal(rnt.Text);
                }
                else
                {
                    //DataTable Dt_balance1 = new DataTable();
                    //Dt_balance1 = ViewState["MINMAX"] as DataTable;
                    //_OBJ_BONUS_TRANS.Bonus_Percentage = Convert.ToDecimal(Dt_balance1.Rows[0]["MINIMUM_BONUS_PERCENTAGE"]);

                    return;
                }

                _OBJ_BONUS_TRANS.Bonus_Trans_checked = Convert.ToBoolean(chk.Checked);
                if (chk.Checked)
                {
                    BLL.bonus_trans_insrt(_OBJ_BONUS_TRANS);
                    count++;
                }
            }
            if (count != 0)
            {
                SMHR_BONUSMASTER1 _obj_bm = new SMHR_BONUSMASTER1();
                _OBJ_BONUS_TRANS.BONUS_BU_ID = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
                _OBJ_BONUS_TRANS.BONUS_PERIOD_ID = Convert.ToInt32(rtxt_period.SelectedItem.Value);
                _OBJ_BONUS_TRANS.BONUS_PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
                _OBJ_BONUS_TRANS.OPERATION = operation.Empty;
                DataTable dt_details_sub = BLL.Get_SMHR_BONUS_TRANS1(_OBJ_BONUS_TRANS);
                ViewState["BONUS_TRANS"] = dt_details_sub;
                if (dt_details_sub.Rows.Count > 0)
                {

                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        btn_submit.Visible = false;

                    }

                    else
                    {
                        btn_submit.Visible = true;
                    }

                }
                else
                {
                    btn_submit.Visible = false;
                }
                rg_bonuscalculation.DataSource = dt_details_sub;
                rg_bonuscalculation.DataBind();
                rmp_bonus.SelectedIndex = 1;
                _obj_smhr_bonusmaster.OPERATION = operation.Select;
                _obj_smhr_bonusmaster.BUSINESSUNIT = Convert.ToInt32(rtxt_businessunit.SelectedItem.Value);
                _obj_smhr_bonusmaster.PERIOD = Convert.ToInt32(rtxt_period.SelectedItem.Value);
                _obj_smhr_bonusmaster.PERIOD_ELEMENTS = Convert.ToInt32(rcmb_periodelements.SelectedItem.Value);
            }
            else
            {
                BLL.ShowMessage(this, "Select Employee To Calculate");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void rtxt_bonuspercentage11_TextChanged(object sender, EventArgs e)
    {
        try
        {
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
                    rnt_totalvalue.Value = Math.Round((((Convert.ToDouble(dt_BONUS_TRANS.Rows[gvRow.ItemIndex]["BONUS"]) * Convert.ToDouble(rnt1.Value) / 100) * Convert.ToDouble(dt_BONUS_TRANS.Rows[gvRow.ItemIndex]["ATTENDANCE"])) / 30), 2);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
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
                    rnt_totalvalue.Value = Math.Round((((Convert.ToDouble(dt_BONUS_TRANS.Rows[gvRow.ItemIndex]["BONUS"]) * Convert.ToDouble(rnt1.Value) / 100) * Convert.ToDouble(dt_BONUS_TRANS.Rows[gvRow.ItemIndex]["ATTENDANCE"])) / 30), 2);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rtxt_bonuspercentage13_TextChanged(object sender, EventArgs e)
    {
        try
        {
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
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
                rnt_bonus_totalvalue = rg_bonuscalculation.Items[k].FindControl("rtxt_bonus") as RadNumericTextBox;
                rnt_bonus_exgratia = rg_bonuscalculation.Items[k].FindControl("rtxt_exgratia") as RadNumericTextBox;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
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
            }
            rg_bonusapprove.DataSource = dt_details_sub;
            rg_bonusapprove.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void chk_selectall_checkedchanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < rg_employees.Items.Count; i++)
            {
                CheckBox Chk_All = (CheckBox)sender;
                if (Chk_All.Checked)
                {
                    for (int index = 0; index < rg_employees.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)rg_employees.Items[index].FindControl("chckbtn_Select");
                        c.Checked = true; ;
                    }
                }
                else
                {
                    for (int index = 0; index < rg_employees.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)rg_employees.Items[index].FindControl("chckbtn_Select");
                        c.Checked = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
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
            rtxt_period.SelectedIndex = -1;
            rtxt_payitemhead.Visible = false;
            rtxt_payitemperiod.Visible = false;
            lbl_payitemhead.Visible = false;
            lbl_payitemperiod.Visible = false;
            lbl_colon3.Visible = false;
            lbl_colon4.Visible = false;
            DataTable dt = new DataTable();
            rtxt_businessunit.DataSource = dt;
            rtxt_businessunit.DataBind();
            rcmb_periodelements.DataSource = dt;
            rcmb_periodelements.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_bonustransaction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

}