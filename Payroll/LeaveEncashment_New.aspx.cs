using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMHR;
using Telerik.Web.UI;
using System.Text;
using System.Collections.Generic;

public partial class LeaveEncashment_New : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_PERIOD _obj_smhr_period;
    DataTable dt_Details;
    SMHR_LEAVEPROCESS obj_smhr_leave;
    SMHR_GLOBALCONFIG _obj_smhr_globalConfig;
    //SMHR_PAYROLL _obj_smhr_payroll;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            bool bln_Leaveprocess = false;
            Page.Validate();
            if (!Page.IsPostBack)
            {

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("LEAVE ENCASHMENT");
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
                    btn_Process.Visible = false;
                    lnkbtn_History.Visible = false;
                    Btn_Submit.Visible = false;
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

                DataTable dtDetails;
                _obj_smhr_globalConfig = new SMHR_GLOBALCONFIG();
                _obj_smhr_globalConfig.OPERATION = operation.Select;
                _obj_smhr_globalConfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                dtDetails = BLL.get_ConfigDetails(_obj_smhr_globalConfig);
                if (dtDetails.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtDetails.Rows[0]["GLOBALCONFIG_LEAVETRANFLAG"]) == false)
                    {
                        bln_Leaveprocess = true;
                        BLL.ShowMessage(this, "Leave Process Not Yet Started");
                        EnableDisableControls();
                    }
                }

                LoadDropdown();
                LoadPeriods();
                LoadnonRecurringPayitem();
                LoadPayItemListbox();
                rcmb_periodelement.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                // LoadPeriodElements();
                LoadFinancialPeriod();

                Rg_Details.Visible = true;
                DataTable dt_empty = new DataTable();
                Rg_Details.DataSource = dt_empty;
                Rg_Details.DataBind();
                Btn_Submit.Visible = false;
                Btn_Clear.Visible = false;

                obj_smhr_leave.MODE = 14;
                DataTable dtCheckLOB = new DataTable();
                dtCheckLOB = BLL.Get_LEAVEDETAILS(obj_smhr_leave);

                if (dtCheckLOB.Rows.Count > 0)
                {
                    if (bln_Leaveprocess == true)
                    {
                        BLL.ShowMessage(this, "Leave Opening Balances not set for the Organisation");
                        EnableDisableControls();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void EnableDisableControls()
    {
        try
        {
            rcmb_toperiod.Enabled = false;
            rcmb_FromPeriod.Enabled = false;
            rcmb_BusinessUnit.Enabled = false;
            rcmb_Payitems.Enabled = false;
            rcmb_periodelement.Enabled = false;
            rcmb_FinancialPeriod.Enabled = false;
            //rcmb_Payitems.Enabled = false;
            RL_Payitem.Enabled = false;
            btn_Process.Enabled = false;

            Rg_Details.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadDropdown()
    {
        try
        {
            rcmb_BusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BusinessUnit.DataSource = dt_BUDetails;
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadPeriodElements()
    {
        try
        {
            obj_smhr_leave = new SMHR_LEAVEPROCESS();
            obj_smhr_leave.PERIODELEMENT = Convert.ToInt32(rcmb_FinancialPeriod.SelectedValue);
            obj_smhr_leave.MODE = 9;
            rcmb_periodelement.Items.Clear();
            dt_Details = new DataTable();
            dt_Details = BLL.Get_LEAVEDETAILS(obj_smhr_leave);
            rcmb_periodelement.DataSource = dt_Details;
            rcmb_periodelement.DataValueField = "PRDDTL_ID";
            rcmb_periodelement.DataTextField = "PRDDTL_NAME";
            rcmb_periodelement.DataBind();
            //   rcmb_periodelement.SelectedIndex = 0;
            rcmb_periodelement.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadFinancialPeriod()
    {
        try
        {
            _obj_smhr_period = new SMHR_PERIOD();
            dt_Details = new DataTable();

            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);

            rcmb_FinancialPeriod.DataSource = dt_Details;
            rcmb_FinancialPeriod.DataValueField = "PERIOD_ID";
            rcmb_FinancialPeriod.DataTextField = "PERIOD_NAME";
            rcmb_FinancialPeriod.DataBind();
            rcmb_FinancialPeriod.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadPeriods()
    {
        try
        {
            _obj_smhr_period = new SMHR_PERIOD();
            dt_Details = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails_Calendar(_obj_smhr_period);
            //Session["Periods"] = dt_Details.Rows[0]["PERIOD_STARTDATE"];
            rcmb_FromPeriod.DataSource = dt_Details;
            rcmb_FromPeriod.DataValueField = "PERIOD_ID";
            rcmb_FromPeriod.DataTextField = "PERIOD_NAME";
            rcmb_FromPeriod.DataBind();
            rcmb_FromPeriod.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            _obj_smhr_period = new SMHR_PERIOD();
            dt_Details = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails_Calendar(_obj_smhr_period);
            rcmb_toperiod.DataSource = dt_Details;
            rcmb_toperiod.DataValueField = "PERIOD_ID";
            rcmb_toperiod.DataTextField = "PERIOD_NAME";
            rcmb_toperiod.DataBind();
            rcmb_toperiod.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadPayItemListbox()
    {
        try
        {
            obj_smhr_leave = new SMHR_LEAVEPROCESS();
            obj_smhr_leave.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            obj_smhr_leave.MODE = 4;
            //DataTable dt_payitems = new DataTable();
            RL_Payitem.DataSource = BLL.Get_LEAVEDETAILS(obj_smhr_leave);
            // RL_Payitem.DataSource = dt_payitems;
            RL_Payitem.DataTextField = "PAYITEM_PAYITEMNAME";
            RL_Payitem.DataValueField = "PAYITEM_ID";
            RL_Payitem.DataBind();
            //RL_Payitem.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_Details_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadEmptygrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void Loadgrid()
    {
        try
        {
            if (rcmb_BusinessUnit.SelectedIndex > 0)
            {
                if (rcmb_FinancialPeriod.SelectedIndex > 0)
                {
                    if (rcmb_FromPeriod.SelectedIndex > 0)
                    {
                        if (rcmb_toperiod.SelectedIndex > 0)
                        {
                            string payitem = string.Empty;
                            //if (rcmb_toperiod.SelectedIndex > rcmb_FromPeriod.SelectedIndex)
                            //{
                            if (RL_Payitem.CheckedItems.Count > 0)
                            {
                                for (int i = 0; i <= RL_Payitem.CheckedItems.Count - 1; i++)
                                {
                                    if (payitem == "")
                                    {
                                        payitem = RL_Payitem.CheckedItems[0].Value;
                                        //payitem = RL_Payitem.SelectedItem.Value;
                                    }
                                    else
                                    {
                                        payitem = payitem + "," + RL_Payitem.CheckedItems[i].Value;
                                    }
                                }
                            }
                            else
                            {
                                BLL.ShowMessage(this, "Select Atleast One Payitem");
                                return;
                            }

                            Rg_Details.Visible = true;
                            obj_smhr_leave = new SMHR_LEAVEPROCESS();
                            obj_smhr_leave.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                            obj_smhr_leave.FROMPERIOD = Convert.ToInt32(rcmb_FromPeriod.SelectedItem.Value);
                            obj_smhr_leave.TOPERIOD = Convert.ToInt32(rcmb_toperiod.SelectedItem.Value);
                            obj_smhr_leave.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                            obj_smhr_leave.PAYITEM = payitem;
                            obj_smhr_leave.MODE = 1;
                            DataTable Dt_Leaves = new DataTable();
                            Dt_Leaves = BLL.Get_LEAVEDETAILS(obj_smhr_leave);


                            Rg_Details.DataSource = Dt_Leaves;
                            Rg_Details.DataBind();
                            for (int index = 0; index < Rg_Details.Items.Count; index++)
                            {
                                if (Dt_Leaves.Rows[index]["LP_STATUS"] != System.DBNull.Value)
                                {
                                    if (Convert.ToInt32(Dt_Leaves.Rows[index]["LP_STATUS"]) == 1)
                                        Rg_Details.Items[index].Enabled = false;
                                }
                                else
                                {
                                    obj_smhr_leave.EMP_ID = Convert.ToInt32(Dt_Leaves.Rows[index]["EMP_ID"]);
                                    obj_smhr_leave.LEAVETYPE_ID = Convert.ToInt32(Dt_Leaves.Rows[index]["LT_LEAVETYPEID"]);
                                    obj_smhr_leave.MODE = 17;
                                    DataTable dt = BLL.Get_LEAVEDETAILS(obj_smhr_leave);
                                    if (dt.Rows.Count > 0)
                                    {
                                        if (Convert.ToInt32(dt.Rows[0]["LT_STATUS"]) == 1)
                                            Rg_Details.Items[index].Enabled = false;
                                    }
                                }
                            }
                            rcmb_toperiod.Enabled = false;
                            rcmb_FromPeriod.Enabled = false;
                            rcmb_BusinessUnit.Enabled = false;
                            rcmb_Payitems.Enabled = false;
                            rcmb_periodelement.Enabled = false;
                            rcmb_FinancialPeriod.Enabled = false;
                            btn_Process.Enabled = false;

                            RL_Payitem.Enabled = false;
                            //  LoadEmptygrid();
                            //  Rg_Details.DataBind();

                            //}
                            //else
                            //{
                            //    BLL.ShowMessage(this, "To Period Should be Greater than From Period");
                            //}
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Please Select To Period");
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Please Select From Period");
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Please Select Financial Period");
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please Select Business Unit");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadEmptygrid()
    {
        try
        {
            Rg_Details.Visible = true;
            obj_smhr_leave = new SMHR_LEAVEPROCESS();
            //obj_smhr_leave.LEAVEPROCESSTYPE = rbtn_Encash.SelectedIndex;
            obj_smhr_leave.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            obj_smhr_leave.MODE = 1;
            Rg_Details.DataSource = BLL.Get_LEAVEDETAILS(obj_smhr_leave);
            //Rg_Details.DataBind();
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                Btn_Submit.Enabled = false;
            }
            else
            {
                Btn_Submit.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    private void LoadnonRecurringPayitem()
    {
        try
        {
            obj_smhr_leave = new SMHR_LEAVEPROCESS();
            obj_smhr_leave.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            obj_smhr_leave.MODE = 6;
            DataTable dt_PayItemDetails = BLL.Get_LEAVEDETAILS(obj_smhr_leave);
            rcmb_Payitems.DataSource = dt_PayItemDetails;
            rcmb_Payitems.DataValueField = "PAYITEM_ID";
            rcmb_Payitems.DataTextField = "PAYITEM_PAYITEMNAME";
            rcmb_Payitems.DataBind();
            rcmb_Payitems.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            rcmb_Payitems.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void txtEncash_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string payitem = string.Empty;
            double totAmount = 0;
            double Curbal;
            double TotEncash;
            double TotCarryForward;
            double Total;

            RadNumericTextBox totalencash = new RadNumericTextBox();
            RadNumericTextBox txtTotalAmount = new RadNumericTextBox();
            RadNumericTextBox txtTotalCF = new RadNumericTextBox();
            RadNumericTextBox txtDefaultValue = new RadNumericTextBox();
            RadNumericTextBox totalencash_dis = new RadNumericTextBox();
            RadNumericTextBox txtTotalCF_dis = new RadNumericTextBox();
            Label currentbalance = new Label();
            Telerik.Web.UI.RadNumericTextBox rtxt_TotalEncashAmt = sender as Telerik.Web.UI.RadNumericTextBox;
            GridItem gvRow = rtxt_TotalEncashAmt.Parent.Parent as GridItem;
            Label defaultvalue = new Label();
            totalencash = Rg_Details.Items[gvRow.ItemIndex].FindControl("txtEncash") as RadNumericTextBox;
            //  defaultvalue = Rg_Details.Items[gvRow.ItemIndex].FindControl("lbldefaultvalue_id") as Label;
            txtDefaultValue = Rg_Details.Items[gvRow.ItemIndex].FindControl("txtDefaultValue") as RadNumericTextBox;
            txtTotalAmount = Rg_Details.Items[gvRow.ItemIndex].FindControl("txtTotalAmount") as RadNumericTextBox;
            txtTotalCF = Rg_Details.Items[gvRow.ItemIndex].FindControl("txtTotalCF") as RadNumericTextBox;
            totalencash_dis = Rg_Details.Items[gvRow.ItemIndex].FindControl("txtEncash_dis") as RadNumericTextBox;
            txtTotalCF_dis = Rg_Details.Items[gvRow.ItemIndex].FindControl("txtTotalCF_dis") as RadNumericTextBox;
            currentbalance = Rg_Details.Items[gvRow.ItemIndex].FindControl("lblCurrentBalance") as Label;
            if (totalencash.Value > totalencash_dis.Value)
            {
                BLL.ShowMessage(this, "Maximum Value is " + totalencash_dis.Value);
                totalencash.Value = totalencash_dis.Value;
                return;
            }
            txtTotalAmount.Value = totAmount;
            currentbalance = Rg_Details.Items[gvRow.ItemIndex].FindControl("lblCurrentBalance") as Label;
            Curbal = Convert.ToDouble(currentbalance.Text);
            TotEncash = Convert.ToDouble(totalencash.Text);
            //if (Convert.ToDouble((Curbal) - (TotEncash)) < txtTotalCF_dis.Value)
            //    txtTotalCF.Value = Convert.ToDouble((Curbal) - (TotEncash));
            //else
            //    txtTotalCF.Value = txtTotalCF_dis.Value;
            TotCarryForward = Convert.ToDouble(txtTotalCF.Text);
            Total = (TotEncash + TotCarryForward);
            if (Curbal < Total)
            {
                BLL.ShowMessage(this, "Sum of Encash and CarryForward leaves should not be greater than Current balance.");
                return;
            }
            //comented on 3.1.2013
            ////if (Total != Curbal)
            ////{
            ////    if (Total > Curbal)
            ////    {
            ////        BLL.ShowMessage(this, "Sum of Encash and CarryForward leaves should not be greater than Current balance.Update Leave Balances for him/her in Leave Opening Balance Screen.");
            ////        return;
            ////    }
            ////    else
            ////    {
            ////        BLL.ShowMessage(this, "Sum of Encash and CarryForward leaves should not be greater than Current balance.");
            ////        return;
            ////    }
            ////}

            //totalencash.Value = Convert.ToDouble((Curbal) - (TotEncash));
            //TotEncash = Convert.ToDouble((Curbal) - (totalencash.Value));

            //txtTotalCF.Value = TotEncash;
            //ViewState["totalencash"] = totalencash.Value;

            //if (Convert.ToDouble(totalencash.Value) != (Convert.ToDouble(ViewState["totalencash"])))
            //{
            //    TotEncash = Convert.ToDouble((Curbal) - (totalencash.Value));

            //}

            totAmount = Convert.ToDouble(totalencash.Value) * Convert.ToDouble(txtDefaultValue.Value);
            txtTotalAmount.Value = totAmount;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void txtTotalCF_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string payitem = string.Empty;
            double totAmount = 0;
            double Curbal;
            double TotEncash;
            double TotCarryForward;
            double Total;

            RadNumericTextBox totalencash = new RadNumericTextBox();
            RadNumericTextBox txtTotalAmount = new RadNumericTextBox();
            RadNumericTextBox txtTotalCF = new RadNumericTextBox();
            RadNumericTextBox txtDefaultValue = new RadNumericTextBox();
            RadNumericTextBox txtTotalCF_dis = new RadNumericTextBox();
            RadNumericTextBox totalencash_dis = new RadNumericTextBox();

            Telerik.Web.UI.RadNumericTextBox rtxt_TotalEncashAmt = sender as Telerik.Web.UI.RadNumericTextBox;
            GridItem gvRow = rtxt_TotalEncashAmt.Parent.Parent as GridItem;
            Label defaultvalue = new Label();
            totalencash = Rg_Details.Items[gvRow.ItemIndex].FindControl("txtEncash") as RadNumericTextBox;
            // defaultvalue = Rg_Details.Items[gvRow.ItemIndex].FindControl("lbldefaultvalue_id") as Label;
            txtDefaultValue = Rg_Details.Items[gvRow.ItemIndex].FindControl("txtDefaultValue") as RadNumericTextBox;
            txtTotalAmount = Rg_Details.Items[gvRow.ItemIndex].FindControl("txtTotalAmount") as RadNumericTextBox;
            txtTotalCF = Rg_Details.Items[gvRow.ItemIndex].FindControl("txtTotalCF") as RadNumericTextBox;
            totalencash_dis = Rg_Details.Items[gvRow.ItemIndex].FindControl("txtEncash_dis") as RadNumericTextBox;
            txtTotalCF_dis = Rg_Details.Items[gvRow.ItemIndex].FindControl("txtTotalCF_dis") as RadNumericTextBox;

            if (txtTotalCF.Value > txtTotalCF_dis.Value)
            {
                BLL.ShowMessage(this, "Maximum Value is " + txtTotalCF_dis.Value);
                txtTotalCF.Value = txtTotalCF_dis.Value;
                return;
            }

            txtTotalAmount.Value = totAmount;
            Label currentbalance = new Label();
            currentbalance = Rg_Details.Items[gvRow.ItemIndex].FindControl("lblCurrentBalance") as Label;
            Curbal = Convert.ToDouble(currentbalance.Text);
            TotEncash = Convert.ToDouble(txtTotalCF.Text);

            //if (Convert.ToDouble((Curbal) - (TotEncash)) < totalencash_dis.Value)
            //    totalencash.Value = Convert.ToDouble((Curbal) - (TotEncash));
            //else
            //    totalencash.Value = totalencash_dis.Value;

            TotEncash = Convert.ToDouble(totalencash.Text);
            TotCarryForward = Convert.ToDouble(txtTotalCF.Text);
            Total = (TotEncash + TotCarryForward);
            if (Curbal < Total)
            {
                BLL.ShowMessage(this, "Sum of Encash and CarryForward leaves should not be greater than Current balance.");
                return;
            }
            //  Total = (TotEncash + TotCarryForward);
            //comented on 3.1.2013
            ////if (Total != Curbal)
            ////{
            ////    if (Total > Curbal)
            ////    {
            ////        BLL.ShowMessage(this, "Sum of Encash and CarryForward leaves should not be greater than Current balance.Update Leave Balances for him/her in Leave Opening Balance Screen.");
            ////        return;
            ////    }
            ////    else
            ////    {
            ////        BLL.ShowMessage(this, "Sum of Encash and CarryForward leaves should not be greater than Current balance.");
            ////        return;
            ////    }
            ////}

            //TotEncash = Convert.ToDouble((Curbal) - (totalencash.Value));

            //ViewState["totalencash"] = totalencash.Value;

            //if (Convert.ToDouble(totalencash.Value) != (Convert.ToDouble(ViewState["totalencash"])))
            //{
            //    TotEncash = Convert.ToDouble((Curbal) - (totalencash.Value));

            //}
            totAmount = Convert.ToDouble(totalencash.Value) * Convert.ToDouble(txtDefaultValue.Value);
            txtTotalAmount.Value = totAmount;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SUBMIT":

                    string Temp_Query = string.Empty;
                    string Temp_Query2 = string.Empty;
                    string Temp_Query3 = string.Empty;
                    bool checkdata = false;
                    string payitem = "";

                    if (RL_Payitem.CheckedItems.Count > 0)
                    {

                        for (int countPayItem = 0; countPayItem <= RL_Payitem.CheckedItems.Count - 1; countPayItem++)
                        {
                            if (payitem == "")
                            {
                                //payitem = RL_Payitem.SelectedItem.Value;
                                payitem = RL_Payitem.CheckedItems[0].Value;
                            }
                            else
                            {
                                payitem = payitem + "," + RL_Payitem.CheckedItems[countPayItem].Value;

                            }
                        }
                    }

                    if (Rg_Details.Items.Count > 0)
                    {
                        int count = 0;
                        for (int i = 0; i < Rg_Details.Items.Count; i++)
                        {
                            CheckBox chk = Rg_Details.Items[i].FindControl("chckbtn_Select") as CheckBox;
                            if (chk.Checked)
                                count++;
                        }
                        if (count == 0)
                        {
                            BLL.ShowMessage(this, "Please Select Atleast One Employee to Submit.");
                            return;
                        }
                        for (int i = 0; i <= Rg_Details.Items.Count - 1; i++)
                        {
                            CheckBox chk = Rg_Details.Items[i].FindControl("chckbtn_Select") as CheckBox;
                            if (chk.Checked)
                            {
                                Label empid = new Label();
                                Label leavetypeid = new Label();
                                SMHR_LOGININFO obj_smhr_login = new SMHR_LOGININFO();

                                obj_smhr_leave = new SMHR_LEAVEPROCESS();
                                obj_smhr_leave.PAYITEMID = payitem;
                                empid = Rg_Details.Items[i].FindControl("lblEmp_id") as Label;
                                obj_smhr_leave.EMP_ID = Convert.ToInt32(empid.Text);
                                leavetypeid = Rg_Details.Items[i].FindControl("lblLeaveTypeId") as Label;
                                obj_smhr_leave.LEAVETYPE_ID = Convert.ToInt32(leavetypeid.Text);
                                obj_smhr_leave.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                                obj_smhr_leave.FROMPERIOD = Convert.ToInt32(rcmb_FromPeriod.SelectedItem.Value);
                                obj_smhr_leave.TOPERIOD = Convert.ToInt32(rcmb_toperiod.SelectedItem.Value);
                                obj_smhr_leave.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                                obj_smhr_leave.PERIODELEMENT = Convert.ToInt32(rcmb_periodelement.SelectedItem.Value);
                                obj_smhr_leave.LPPAYITEMHEAD = Convert.ToInt32(rcmb_Payitems.SelectedItem.Value);
                                RadNumericTextBox totalcf = new RadNumericTextBox();
                                totalcf = Rg_Details.Items[i].FindControl("txtTotalCF") as RadNumericTextBox;
                                obj_smhr_leave.LP_CF_Leaves = Convert.ToDouble(totalcf.Text);
                                RadNumericTextBox totalencash = new RadNumericTextBox();
                                totalencash = Rg_Details.Items[i].FindControl("txtEncash") as RadNumericTextBox;
                                obj_smhr_leave.LP_Enc_Leaves = Convert.ToDouble(totalencash.Text);
                                RadNumericTextBox totalamount = new RadNumericTextBox();
                                totalamount = Rg_Details.Items[i].FindControl("txtTotalAmount") as RadNumericTextBox;
                                Label curr_bal = new Label();
                                curr_bal = Rg_Details.Items[i].FindControl("lblCurrentBalance") as Label;
                                Label EMP_NAME = new Label();
                                EMP_NAME = Rg_Details.Items[i].FindControl("lblEMPLOYEENAME") as Label;
                                double Total = 0;
                                double Curbal = 0;
                                Total = Convert.ToDouble(totalencash.Text) + Convert.ToDouble(totalcf.Text);
                                Curbal = Convert.ToDouble(curr_bal.Text);
                                if (Total != Curbal && Total != 0)
                                {
                                    ////if (Total > Curbal)
                                    ////{
                                    ////    BLL.ShowMessage(this, "Sum of Encash and CarryForward leaves should not be greater than Current balance.Update Leave Balances for "+ EMP_NAME.Text+ " in Leave Opening Balance Screen.");
                                    ////    return;
                                    ////}
                                    if (Total > Curbal)
                                    {
                                        BLL.ShowMessage(this, "Sum of Encash and CarryForward leaves exceeds Current balance for " + EMP_NAME.Text);
                                        return;
                                    }
                                }
                                obj_smhr_leave.TotalAmount = Convert.ToDouble(totalamount.Text);
                                obj_smhr_leave.LP_STATUS = 0;
                                //DataTable dt_LoginDetails = BLL.get_LoginInfo(_obj_SMHR_LoginInfo);
                                //obj_smhr_login.OPERATION = operation.Check;
                                //obj_smhr_login.CREATEDBY = Convert.ToInt32(dt_LoginDetails.Rows[0]["LOGIN_ID"]);

                                obj_smhr_leave.LPCREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                                //obj_smhr_leave.LPCREATEDDATE = System.DateTime.Now;

                                obj_smhr_leave.MODE = 3;
                                checkdata = true;
                                if ((totalcf.Text != "0") && (totalencash.Text != "0"))
                                {
                                    Temp_Query = Temp_Query + BLL.set_LEAVEDETAILS_VALUES(obj_smhr_leave);
                                }
                                obj_smhr_leave.MODE = 5;
                                Temp_Query2 = Temp_Query2 + BLL.set_LEAVEDETAILS_VALUES(obj_smhr_leave);

                                ////if ((totalcf.Text == "0") && (totalencash.Text == "0"))
                                ////{
                                ////    continue;
                                ////}
                                ////else
                                ////{
                                ////    checkdata = true;

                                ////    Temp_Query = Temp_Query + BLL.set_LEAVEDETAILS_VALUES(obj_smhr_leave);
                                ////    obj_smhr_leave.MODE = 5;
                                ////    Temp_Query2 = Temp_Query2 + BLL.set_LEAVEDETAILS_VALUES(obj_smhr_leave);

                                ////    // For Populating Nonrecurring payitems
                                ////    //////////obj_smhr_leave.MODE = 6;
                                ////    //////////Temp_Query3 = Temp_Query3 + BLL.Get_LEAVEDETAILS(obj_smhr_leave);
                                ////}
                            }
                        }

                        if (checkdata == true)
                        {
                            obj_smhr_leave.MODE = 2;

                            // query to insert into Leave process table
                            obj_smhr_leave.Query = Temp_Query;
                            BLL.set_LEAVEDETAILS(obj_smhr_leave);

                            // query to update leave balnces with caryforward leaves
                            obj_smhr_leave.Query = Temp_Query2;
                            BLL.set_LEAVEDETAILS(obj_smhr_leave);
                            BLL.ShowMessage(this, "Leave Encashment Sucessfully Submited for Selected Employees.");
                        }
                        else
                        {
                            BLL.ShowMessage(this, "No Data To Submit");
                            return;
                        }
                        //      Session["Buid"] = rcmb_BusinessUnit.SelectedItem.Text;
                        Session["From_Period_id"] = rcmb_FromPeriod.SelectedItem.Value;
                        //        Session["To_Period_id"] = rcmb_toperiod.SelectedItem.Text;
                        Session["Executed_Date"] = DateTime.Now;
                        Session["Bu_Id"] = rcmb_BusinessUnit.SelectedItem.Value;
                        Session["ToPeriod_id"] = rcmb_toperiod.SelectedItem.Value;

                        //Response.Redirect("frm_FinaliseData.aspx");
                        Loadgrid();
                    }
                    else
                    {
                        BLL.ShowMessage(this, "No Items To  Submit");
                        return;
                    }

                    break;
                case "BTN_FINALISE":
                    string Temp_Query1 = string.Empty;
                    string Temp_Query12 = string.Empty;
                    string Temp_Query13 = string.Empty;
                    bool checkdata1 = false;
                    string payitem1 = "";

                    if (RL_Payitem.CheckedItems.Count > 0)
                    {

                        for (int countPayItem = 0; countPayItem <= RL_Payitem.CheckedItems.Count - 1; countPayItem++)
                        {
                            if (payitem1 == "")
                            {
                                //payitem = RL_Payitem.SelectedItem.Value;
                                payitem1 = RL_Payitem.CheckedItems[0].Value;
                            }
                            else
                            {
                                payitem1 = payitem1 + "," + RL_Payitem.CheckedItems[countPayItem].Value;

                            }
                        }
                    }

                    if (Rg_Details.Items.Count > 0)
                    {
                        int count = 0;
                        for (int i = 0; i < Rg_Details.Items.Count; i++)
                        {
                            CheckBox chk = Rg_Details.Items[i].FindControl("chckbtn_Select") as CheckBox;
                            if (chk.Checked)
                                count++;
                        }
                        if (count == 0)
                        {
                            BLL.ShowMessage(this, "Please Select Atleast One Employee to Submit.");
                            return;
                        }
                        for (int i = 0; i <= Rg_Details.Items.Count - 1; i++)
                        {
                            CheckBox chk = Rg_Details.Items[i].FindControl("chckbtn_Select") as CheckBox;
                            if (chk.Checked)
                            {
                                Label empid = new Label();
                                Label leavetypeid = new Label();
                                SMHR_LOGININFO obj_smhr_login = new SMHR_LOGININFO();

                                obj_smhr_leave = new SMHR_LEAVEPROCESS();
                                obj_smhr_leave.PAYITEMID = payitem1;
                                empid = Rg_Details.Items[i].FindControl("lblEmp_id") as Label;
                                obj_smhr_leave.EMP_ID = Convert.ToInt32(empid.Text);
                                leavetypeid = Rg_Details.Items[i].FindControl("lblLeaveTypeId") as Label;
                                obj_smhr_leave.LEAVETYPE_ID = Convert.ToInt32(leavetypeid.Text);
                                obj_smhr_leave.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                                obj_smhr_leave.FROMPERIOD = Convert.ToInt32(rcmb_FromPeriod.SelectedItem.Value);
                                obj_smhr_leave.TOPERIOD = Convert.ToInt32(rcmb_toperiod.SelectedItem.Value);
                                obj_smhr_leave.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                                obj_smhr_leave.PERIODELEMENT = Convert.ToInt32(rcmb_periodelement.SelectedItem.Value);
                                obj_smhr_leave.LPPAYITEMHEAD = Convert.ToInt32(rcmb_Payitems.SelectedItem.Value);
                                RadNumericTextBox totalcf = new RadNumericTextBox();
                                totalcf = Rg_Details.Items[i].FindControl("txtTotalCF") as RadNumericTextBox;
                                obj_smhr_leave.LP_CF_Leaves = Convert.ToDouble(totalcf.Text);
                                RadNumericTextBox totalencash = new RadNumericTextBox();
                                totalencash = Rg_Details.Items[i].FindControl("txtEncash") as RadNumericTextBox;
                                obj_smhr_leave.LP_Enc_Leaves = Convert.ToDouble(totalencash.Text);
                                RadNumericTextBox totalamount = new RadNumericTextBox();
                                totalamount = Rg_Details.Items[i].FindControl("txtTotalAmount") as RadNumericTextBox;
                                obj_smhr_leave.TotalAmount = Convert.ToDouble(totalamount.Text);
                                obj_smhr_leave.LP_STATUS = 1;
                                Label curr_bal = new Label();
                                curr_bal = Rg_Details.Items[i].FindControl("lblCurrentBalance") as Label;
                                Label EMP_NAME = new Label();
                                EMP_NAME = Rg_Details.Items[i].FindControl("lblEMPLOYEENAME") as Label;
                                double Total = 0;
                                double Curbal = 0;
                                Total = Convert.ToDouble(totalencash.Text) + Convert.ToDouble(totalcf.Text);
                                Curbal = Convert.ToDouble(curr_bal.Text);
                                if (Total != Curbal && Total != 0)
                                {
                                    ////if (Total > Curbal)
                                    ////{
                                    ////    BLL.ShowMessage(this, "Sum of Encash and CarryForward leaves should not be greater than Current balance.Update Leave Balances for " + EMP_NAME.Text + " in Leave Opening Balance Screen.");
                                    ////    return;
                                    ////}
                                    if (Total > Curbal)
                                    {
                                        BLL.ShowMessage(this, "Sum of Encash and CarryForward leaves exceeds Current balance for " + EMP_NAME.Text);
                                        return;
                                    }
                                }
                                obj_smhr_leave.LPCREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                                obj_smhr_leave.MODE = 3;
                                checkdata1 = true;
                                if ((totalcf.Text != "0") && (totalencash.Text != "0"))
                                {
                                    Temp_Query1 = Temp_Query1 + BLL.set_LEAVEDETAILS_VALUES(obj_smhr_leave);
                                }
                                obj_smhr_leave.MODE = 5;
                                Temp_Query12 = Temp_Query12 + BLL.set_LEAVEDETAILS_VALUES(obj_smhr_leave);

                                ////if ((totalcf.Text == "0") && (totalencash.Text == "0"))
                                ////{
                                ////    continue;
                                ////}
                                ////else
                                ////{
                                ////    checkdata1 = true;

                                ////    Temp_Query1 = Temp_Query1 + BLL.set_LEAVEDETAILS_VALUES(obj_smhr_leave);
                                ////    obj_smhr_leave.MODE = 5;
                                ////    Temp_Query12 = Temp_Query12 + BLL.set_LEAVEDETAILS_VALUES(obj_smhr_leave);

                                ////    // For Populating Nonrecurring payitems
                                ////    //////////obj_smhr_leave.MODE = 6;
                                ////    //////////Temp_Query3 = Temp_Query3 + BLL.Get_LEAVEDETAILS(obj_smhr_leave);
                                ////}
                            }
                        }

                        if (checkdata1 == true)
                        {
                            obj_smhr_leave.MODE = 2;

                            // query to insert into Leave process table
                            obj_smhr_leave.Query = Temp_Query1;
                            BLL.set_LEAVEDETAILS(obj_smhr_leave);

                            // query to update leave balnces with caryforward leaves
                            obj_smhr_leave.Query = Temp_Query12;
                            BLL.set_LEAVEDETAILS(obj_smhr_leave);
                            BLL.ShowMessage(this, "Leave Encashment Sucessfully Finalised for Selected Employees.");
                        }
                        else
                        {
                            BLL.ShowMessage(this, "No Data To Submit");
                            return;
                        }
                        //      Session["Buid"] = rcmb_BusinessUnit.SelectedItem.Text;
                        Session["From_Period_id"] = rcmb_FromPeriod.SelectedItem.Value;
                        //        Session["To_Period_id"] = rcmb_toperiod.SelectedItem.Text;
                        Session["Executed_Date"] = DateTime.Now;
                        Session["Bu_Id"] = rcmb_BusinessUnit.SelectedItem.Value;
                        Session["ToPeriod_id"] = rcmb_toperiod.SelectedItem.Value;

                        //Response.Redirect("frm_FinaliseData.aspx");
                        Loadgrid();
                    }
                    else
                    {
                        BLL.ShowMessage(this, "No Items To  Submit");
                        return;
                    }
                    break;
                case "BTN_CLEAR":

                    rcmb_toperiod.SelectedIndex = -1;
                    rcmb_FromPeriod.SelectedIndex = -1;
                    rcmb_BusinessUnit.SelectedIndex = -1;
                    rcmb_Payitems.SelectedIndex = -1;
                    rcmb_periodelement.SelectedIndex = -1;
                    rcmb_FinancialPeriod.SelectedIndex = -1;
                    RL_Payitem.ClearChecked();
                    btn_Process.Enabled = true;

                    LoadEmptygrid();
                    Rg_Details.DataBind();

                    rcmb_toperiod.Enabled = true; ;
                    rcmb_FromPeriod.Enabled = true;
                    rcmb_BusinessUnit.Enabled = true;
                    rcmb_FinancialPeriod.Enabled = true;
                    // rbtn_Encash.ClearSelection();
                    //RL_Payitem.ClearSelection();
                    RL_Payitem.ClearChecked();
                    RL_Payitem.Enabled = true;
                    rcmb_Payitems.Enabled = true;
                    rcmb_periodelement.Enabled = true;
                    break;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnkbtn_History_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "LeaveEncash_History()", true);
            Session["Buid"] = rcmb_BusinessUnit.SelectedItem.Text;
            Session["From_Period_id"] = rcmb_FromPeriod.SelectedItem.Text;
            Session["To_Period_id"] = rcmb_toperiod.SelectedItem.Text;
            Session["Executed_Date"] = DateTime.Now;
            Session["Bu_Id"] = rcmb_BusinessUnit.SelectedItem.Value;
            Session["ToPeriod_id"] = rcmb_toperiod.SelectedItem.Value;

            bool fromstatus = false;
            bool tostatus = false;
            DateTime FromStart = DateTime.Now;
            DateTime ToStart = DateTime.Now;

            SMHR_LEAVEPROCESS _obj_smhr_period = new SMHR_LEAVEPROCESS();
            dt_Details = new DataTable();
            _obj_smhr_period.MODE = 15;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.Get_LEAVEDETAILS(_obj_smhr_period);
            if (dt_Details.Rows.Count > 0)
            {
                int fromperiod = Convert.ToInt32(rcmb_FromPeriod.SelectedValue);
                int toperiod = Convert.ToInt32(rcmb_toperiod.SelectedValue);
                for (int i = 0; dt_Details.Rows.Count > i; i++)
                {
                    if (fromperiod == Convert.ToInt32(dt_Details.Rows[i]["PERIOD_ID"].ToString()))
                    {
                        FromStart = Convert.ToDateTime(dt_Details.Rows[i]["PERIOD_STARTDATE"]);
                        fromstatus = true;
                    }
                    if (toperiod == Convert.ToInt32(dt_Details.Rows[i]["PERIOD_ID"].ToString()))
                    {
                        ToStart = Convert.ToDateTime(dt_Details.Rows[i]["PERIOD_STARTDATE"]);
                        tostatus = true;
                    }
                    if (tostatus && fromstatus)
                    {
                        if (ToStart < FromStart)
                        {
                            BLL.ShowMessage(this, "From Period Cant be Greater than To Period");
                            return;
                        }
                    }
                }




                if (rcmb_BusinessUnit.SelectedIndex > 0)
                {
                    if (rcmb_FromPeriod.SelectedIndex > 0)
                    {
                        if (rcmb_toperiod.SelectedIndex > 0)
                        {

                            //if (rcmb_toperiod.SelectedIndex > rcmb_FromPeriod.SelectedIndex)
                            //{

                            //////string payitem = string.Empty;


                            //////       if (RL_Payitem.CheckedItems.Count > 0)
                            //////       {

                            //////           for (int countPayItem = 0; countPayItem <= RL_Payitem.CheckedItems.Count-1 ; countPayItem++)
                            //////           {
                            //////               if (payitem == "")
                            //////               {
                            //////                 //  payitem = RL_Payitem.SelectedValue.ToString();
                            //////                   payitem = RL_Payitem.CheckedItems[0].Text ;   
                            //////               }
                            //////               else
                            //////               {
                            //////                   payitem = payitem + "," + RL_Payitem.CheckedItems[countPayItem].Text ;
                            //////                   //payitem = payitem + "," + RL_Payitem.CheckedItems[0].Value;   

                            //////               }
                            //////           }
                            //////       }
                            //////             Session["payitem"] = payitem;
                        }
                        //else
                        //{
                        //    BLL.ShowMessage(this, "To Period Should be Greater than From Period");

                        //    Response.Redirect("LeaveEncashment_New.aspx");
                        //}
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Please Select To Period");
                        Response.Redirect("LeaveEncashment_New.aspx");
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Please Select From Period");
                    Response.Redirect("LeaveEncashment_New.aspx");
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please Select Business Unit");

                Response.Redirect("LeaveEncashment_New.aspx");
                return;

            }


            string payitem = string.Empty;

            if (RL_Payitem.CheckedItems.Count > 0)
            {
                for (int countPayItem = 0; countPayItem <= RL_Payitem.CheckedItems.Count - 1; countPayItem++)
                {
                    if (payitem == "")
                    {
                        //  payitem = RL_Payitem.SelectedValue.ToString();
                        payitem = RL_Payitem.CheckedItems[0].Text;
                    }
                    else
                    {
                        payitem = payitem + "," + RL_Payitem.CheckedItems[countPayItem].Text;
                        //payitem = payitem + "," + RL_Payitem.CheckedItems[0].Value;   
                    }
                }
            }
            Session["payitem"] = payitem;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void rcmb_FinancialPeriod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadPeriodElements();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Process_Click(object sender, EventArgs e)
    {
        try
        {
            obj_smhr_leave = new SMHR_LEAVEPROCESS();
            obj_smhr_leave.FROMPERIOD = Convert.ToInt32(rcmb_FromPeriod.SelectedValue);
            obj_smhr_leave.TOPERIOD = Convert.ToInt32(rcmb_toperiod.SelectedValue);
            obj_smhr_leave.MODE = 12;
            obj_smhr_leave.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            DataTable dt_Details = BLL.Get_LEAVEDETAILS(obj_smhr_leave);
            //if (dt_Details.Rows.Count != 0)
            //{
            //    BLL.ShowMessage(this, "Leave Encashment is Already Done For The Selected Period");
            //    return;
            //}

            obj_smhr_leave = new SMHR_LEAVEPROCESS();
            obj_smhr_leave.FINANCEPERIOD = Convert.ToInt32(rcmb_FinancialPeriod.SelectedValue);
            obj_smhr_leave.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //obj_smhr_leave.MODE = 16;
            //DataTable dt_details = BLL.Get_LEAVEDETAILS(obj_smhr_leave);
            //if (dt_details.Rows.Count == 0)
            //{
            //    BLL.ShowMessage(this, "Pay Roll is not Done for this Selected Period");
            //    return;
            //}
            bool fromstatus = false;
            bool tostatus = false;
            DateTime FromStart = DateTime.Now;
            DateTime ToStart = DateTime.Now;
            SMHR_LEAVEPROCESS _obj_smhr_period = new SMHR_LEAVEPROCESS();
            dt_Details = new DataTable();
            _obj_smhr_period.MODE = 15;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.Get_LEAVEDETAILS(_obj_smhr_period);
            if (dt_Details.Rows.Count > 0)
            {
                int fromperiod = Convert.ToInt32(rcmb_FromPeriod.SelectedValue);
                int toperiod = Convert.ToInt32(rcmb_toperiod.SelectedValue);
                for (int i = 0; dt_Details.Rows.Count > i; i++)
                {
                    if (fromperiod == Convert.ToInt32(dt_Details.Rows[i]["PERIOD_ID"].ToString()))
                    {
                        FromStart = Convert.ToDateTime(dt_Details.Rows[i]["PERIOD_STARTDATE"]);
                        fromstatus = true;
                    }
                    if (toperiod == Convert.ToInt32(dt_Details.Rows[i]["PERIOD_ID"].ToString()))
                    {
                        ToStart = Convert.ToDateTime(dt_Details.Rows[i]["PERIOD_STARTDATE"]);
                        tostatus = true;
                    }
                    if (tostatus && fromstatus)
                    {
                        if (ToStart < FromStart)
                        {
                            BLL.ShowMessage(this, "From Period Cant be Greater than To Period");
                            return;
                        }
                        if (FromStart == ToStart)
                        {
                            BLL.ShowMessage(this, "From Start Period and To Start Period cant be The Same");
                            return;
                        }
                    }
                    //if (tostatus && fromstatus)
                    //{
                    //    if (FromStart == ToStart)
                    //    {
                    //        BLL.ShowMessage(this, "From Period and To Period can't be Same");
                    //        return;
                    //    }
                    //}
                }
            }
            Loadgrid();

            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                Btn_Submit.Visible = false;
                Btn_Clear.Visible = false;
            }
            else
            {
                Btn_Submit.Visible = true;
                Btn_Clear.Visible = true;
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void chk_selectall_checkedchanged(object sender, EventArgs e)
    {
        try
        {
            //for (int i = 0; i < Rg_Details.Items.Count; i++)
            //{
            CheckBox Chk_All = (CheckBox)sender;
            if (Chk_All.Checked)
            {
                for (int index = 0; index < Rg_Details.Items.Count; index++)
                {
                    CheckBox c = (CheckBox)Rg_Details.Items[index].FindControl("chckbtn_Select");
                    if (Rg_Details.Items[index].Enabled)
                        c.Checked = true;
                    else
                        c.Checked = false;
                }
            }
            else
            {
                for (int index = 0; index < Rg_Details.Items.Count; index++)
                {
                    CheckBox c = (CheckBox)Rg_Details.Items[index].FindControl("chckbtn_Select");
                    c.Checked = false;
                }
            }
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveEncashment_New", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
