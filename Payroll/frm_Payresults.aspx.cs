using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;

public partial class Payroll_frm_Payresults : System.Web.UI.Page
{

    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_PERIOD _obj_smhr_period;
    SMHR_PERIODDTL _obj_smhr_perioddtl;
    SMHR_PAYROLL _obj_smhr_payroll;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;

    static DataTable dt_Details;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {

                //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){ }", true);
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Payroll Results");//PAYROLLPROCESS");
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
                    Rg_PayReults.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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

                BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), Rg_PayReults, "EMPDOJ");



            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payresults", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
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

            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BUI.DataSource = dt_BUDetails;
            rcmb_BUI.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BUI.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BUI.DataBind();
            rcmb_BUI.Items.Insert(0, new RadComboBoxItem("Select"));


            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmb_PeriodMaster.DataSource = dt_Details;
            rcmb_PeriodMaster.DataValueField = "PERIOD_ID";
            rcmb_PeriodMaster.DataTextField = "PERIOD_NAME";
            rcmb_PeriodMaster.DataBind();
            rcmb_PeriodMaster.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payresults", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_PeriodMaster_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            Rg_PayReults.Visible = false;
            rcmb_PeriodStatus.SelectedIndex = 0;
            if (rcmb_PeriodMaster.SelectedIndex != 0)
            {
                _obj_smhr_perioddtl = new SMHR_PERIODDTL();
                _obj_smhr_perioddtl.OPERATION = operation.Select;
                _obj_smhr_perioddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(rcmb_PeriodMaster.SelectedItem.Value);
                dt_Details = new DataTable();
                dt_Details = BLL.get_PeriodDetails(_obj_smhr_perioddtl);
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_PeriodElement.DataSource = dt_Details;
                    rcmb_PeriodElement.DataValueField = "PRDDTL_ID";
                    rcmb_PeriodElement.DataTextField = "PRDDTL_NAME";
                    rcmb_PeriodElement.DataBind();
                    rcmb_PeriodElement.Items.Insert(0, new RadComboBoxItem("Select"));
                }
            }
            else
            {
                rcmb_PeriodElement.Items.Clear();
                rcmb_PeriodElement.Items.Insert(0, new RadComboBoxItem("", ""));
                rcb_Transaction.Items.Clear();
                rcb_Transaction.Items.Insert(0, new RadComboBoxItem("", ""));
            }
            //added for link to Payroll Reports. By Anirudh
            lnk.Visible = false;
            lnk_Approved.Visible = false;
            //if (rcmb_PeriodMaster.SelectedIndex == 0)
            //{
            //    lnk.Visible = false;
            //    lnk_Approved.Visible = false;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payresults", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_PeriodElement_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            Rg_PayReults.Visible = false;
            rcmb_PeriodStatus.SelectedIndex = 0;
            rcb_Transaction.Items.Clear();
            rcb_Transaction.Items.Insert(0, new RadComboBoxItem("", ""));
            //added for link to Payroll Reports. By Anirudh
            lnk.Visible = false;
            lnk_Approved.Visible = false;
            //if (rcmb_PeriodElement.SelectedIndex == 0)
            //{
            //    lnk.Visible = false;
            //    lnk_Approved.Visible = false;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payresults", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_PeriodStatus_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            Rg_PayReults.Visible = false;
            rcb_Transaction.Items.Clear();
            rcb_Transaction.Text = string.Empty;
            rcb_Transaction.Items.Insert(0, new RadComboBoxItem("", ""));
            lnk.Visible = false;
            lnk_Approved.Visible = false;
            //added for link to Payroll Reports. By Anirudh
            //if (rcmb_PeriodStatus.SelectedIndex > 0)
            //{
            //    if ((rcmb_PeriodStatus.SelectedItem.Text).ToUpper() == "PENDING")
            //    {
            //        if ((rcmb_BUI.SelectedIndex > 0) && (rcmb_PeriodMaster.SelectedIndex > 0) && (rcmb_PeriodElement.SelectedIndex > 0))
            //        {
            //            lnk.Visible = true;
            //            lnk_Approved.Visible = false;
            //        }
            //        else
            //        {
            //            lnk.Visible = false;
            //            lnk_Approved.Visible = false;
            //        }
            //    }
            //    else if ((rcmb_PeriodStatus.SelectedItem.Text).ToUpper() == "APPROVED")
            //    {
            //        if ((rcmb_BUI.SelectedIndex > 0) && (rcmb_PeriodMaster.SelectedIndex > 0) && (rcmb_PeriodElement.SelectedIndex > 0))
            //        {
            //            lnk.Visible = false;
            //            lnk_Approved.Visible = true;
            //        }
            //        else
            //        {
            //            lnk.Visible = false;
            //            lnk_Approved.Visible = false;
            //        }
            //    }
            //    else
            //    {
            //        lnk.Visible = false;
            //        lnk_Approved.Visible = false;
            //    }
            //}

            //if(rcmb_PeriodStatus.SelectedIndex==0)
            //{
            //    lnk.Visible=false;
            //    lnk_Approved.Visible=false;
            //}
            /////////////////////////

            if (rcmb_PeriodStatus.SelectedIndex != 0)
            {

                if ((rcmb_BUI.SelectedIndex > 0) && (rcmb_PeriodMaster.SelectedIndex > 0) && (rcmb_PeriodElement.SelectedIndex > 0))
                {

                    if (rcmb_PeriodStatus.SelectedItem.Value == Convert.ToString(1)) //Approved
                    {
                        rcb_Transaction.Items.Clear();
                        _obj_smhr_payroll = new SMHR_PAYROLL();
                        _obj_smhr_payroll.MODE = 30;
                        _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_PeriodElement.SelectedItem.Value);
                        _obj_smhr_payroll.BUID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
                        DataTable dt = BLL.get_PayDetails(_obj_smhr_payroll);
                        if (dt.Rows.Count != 0)
                        {

                            rcb_Transaction.Items.Clear();
                            rcb_Transaction.DataSource = dt;
                            rcb_Transaction.DataTextField = "PAYTRAN_NAME";
                            rcb_Transaction.DataValueField = "PAYTRAN_ID";
                            rcb_Transaction.DataBind();
                            rcb_Transaction.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

                        }
                    }
                    else if ((rcmb_PeriodStatus.SelectedItem.Value == Convert.ToString(2))) //Rejected
                    {
                        rcb_Transaction.Items.Clear();

                        _obj_smhr_payroll = new SMHR_PAYROLL();
                        _obj_smhr_payroll.MODE = 31;
                        _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_PeriodElement.SelectedItem.Value);
                        _obj_smhr_payroll.BUID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
                        DataTable dt = BLL.get_PayDetails(_obj_smhr_payroll);
                        if (dt.Rows.Count != 0)
                        {

                            rcb_Transaction.Items.Clear();
                            rcb_Transaction.DataSource = dt;
                            rcb_Transaction.DataTextField = "PAYTRAN_NAME";
                            rcb_Transaction.DataValueField = "PAYTRAN_ID";
                            rcb_Transaction.DataBind();
                            rcb_Transaction.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

                        }
                    }
                    else //Pending
                    {
                        rcb_Transaction.Items.Clear();
                        _obj_smhr_payroll = new SMHR_PAYROLL();
                        _obj_smhr_payroll.MODE = 22;
                        _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_PeriodElement.SelectedItem.Value);
                        _obj_smhr_payroll.BUID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
                        DataTable dt = BLL.get_PayDetails(_obj_smhr_payroll);
                        if (dt.Rows.Count != 0)
                        {
                            //_obj_smhr_payroll = new SMHR_PAYROLL();
                            //_obj_smhr_payroll.MODE = 22;
                            //_obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_PeriodElement.SelectedItem.Value);
                            //_obj_smhr_payroll.BUID = Convert.ToInt32(rcmb_businessunit.SelectedItem.Value);
                            //DataTable dt = BLL.get_PayDetails(_obj_smhr_payroll);
                            rcb_Transaction.Items.Clear();
                            rcb_Transaction.DataSource = dt;
                            rcb_Transaction.DataTextField = "TEMP_PAYTRAN_NAME";
                            rcb_Transaction.DataValueField = "TEMP_PAYTRAN_ID";
                            rcb_Transaction.DataBind();
                            rcb_Transaction.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                            //RG_Transaction.Visible = false;
                            //btn_Rollback.Visible = false;
                        }
                        else
                        {
                            //RG_Transaction.Visible = false;
                            //btn_Rollback.Visible = false;
                        }
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Select All Paramaters.");
                    return;
                }


            }
            else
            {
                rcb_Transaction.Items.Clear();
                rcb_Transaction.Items.Insert(0, new RadComboBoxItem("", ""));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payresults", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void rcb_Transaction_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcb_Transaction.SelectedIndex != 0)
            {

                LoadSaldtls();

                if (rcmb_PeriodStatus.SelectedIndex > 0)
                {
                    if ((rcmb_PeriodStatus.SelectedItem.Text).ToUpper() == "PENDING")
                    {


                        if ((rcmb_BUI.SelectedIndex > 0) && (rcmb_PeriodMaster.SelectedIndex > 0) && (rcmb_PeriodElement.SelectedIndex > 0))
                        {
                            lnk.Visible = true;
                            lnk_Approved.Visible = false;
                        }
                        else
                        {
                            lnk.Visible = false;
                            lnk_Approved.Visible = false;
                        }
                    }
                    else if ((rcmb_PeriodStatus.SelectedItem.Text).ToUpper() == "APPROVED")
                    {
                        if ((rcmb_BUI.SelectedIndex > 0) && (rcmb_PeriodMaster.SelectedIndex > 0) && (rcmb_PeriodElement.SelectedIndex > 0))
                        {
                            lnk.Visible = false;
                            lnk_Approved.Visible = true;
                        }
                        else
                        {
                            lnk.Visible = false;
                            lnk_Approved.Visible = false;
                        }
                    }
                    else
                    {
                        lnk.Visible = false;
                        lnk_Approved.Visible = false;
                    }
                }

                if (rcmb_PeriodStatus.SelectedIndex == 0)
                {
                    lnk.Visible = false;
                    lnk_Approved.Visible = false;
                }
            }
            else
            {
                Rg_PayReults.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payresults", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            string str = Convert.ToString(e.CommandName);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(e.CommandArgument) + "','" + Convert.ToString(rcmb_PeriodElement.SelectedItem.Value) + "','" + Convert.ToString(rcmb_PeriodStatus.SelectedItem.Text) + "','" + str + "','" + Convert.ToString(rcb_Transaction.SelectedItem.Value) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payresults", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_View_Command(object sender, CommandEventArgs e)
    {
        try
        {
            string str = Convert.ToString(e.CommandName);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowProvisional('" + Convert.ToString(e.CommandArgument) + "','" + Convert.ToString(rcmb_PeriodMaster.SelectedItem.Value) + "','" + Convert.ToString(rcmb_BUI.SelectedItem.Value) + "','" + Convert.ToString(rcmb_PeriodElement.SelectedItem.Value) + "','" + Convert.ToString(Session["ORG_ID"]) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payresults", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    private void LoadSaldtls()
    {

        try
        {
            DataTable dt = new DataTable();
            if (rcmb_PeriodStatus.SelectedIndex != 0)
            {
                _obj_smhr_payroll = new SMHR_PAYROLL();
                _obj_smhr_payroll.BUID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
                _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_PeriodElement.SelectedItem.Value);
                if (rcmb_PeriodStatus.SelectedItem.Value == Convert.ToString(1)) //Approved
                {
                    _obj_smhr_payroll.MODE = 10;
                    _obj_smhr_payroll.TRANID = Convert.ToInt32(rcb_Transaction.SelectedItem.Value);
                    dt = BLL.get_PayDetails(_obj_smhr_payroll);
                    if (dt.Rows.Count != 0)
                    {
                        Rg_PayReults.DataSource = dt;
                        Rg_PayReults.DataBind();
                    }
                    else
                    {
                        _obj_smhr_payroll = new SMHR_PAYROLL();
                        _obj_smhr_payroll.BUID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
                        _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_PeriodElement.SelectedItem.Value);
                        _obj_smhr_payroll.MODE = 25;
                        DataTable dt_1 = BLL.get_PayDetails(_obj_smhr_payroll);
                        if (dt_1.Rows.Count != 0)
                        {
                            Rg_PayReults.DataSource = dt_1;
                            Rg_PayReults.DataBind();
                        }
                        else
                        {
                            dt.Rows.Clear();
                            Rg_PayReults.DataSource = dt;
                            Rg_PayReults.DataBind();
                        }
                    }
                }
                else if ((rcmb_PeriodStatus.SelectedItem.Value == Convert.ToString(2))) //Rejected
                {
                    _obj_smhr_payroll.MODE = 12;
                    _obj_smhr_payroll.TRANID = Convert.ToInt32(rcb_Transaction.SelectedItem.Value);
                    dt = BLL.get_PayDetails(_obj_smhr_payroll);
                    if (dt.Rows.Count != 0)
                    {
                        Rg_PayReults.DataSource = dt;
                        Rg_PayReults.DataBind();
                    }
                    else
                    {
                        dt.Rows.Clear();
                        Rg_PayReults.DataSource = dt;
                        Rg_PayReults.DataBind();
                    }

                }
                else //Pending
                {
                    _obj_smhr_payroll.MODE = 13;
                    _obj_smhr_payroll.TRANID = Convert.ToInt32(rcb_Transaction.SelectedItem.Value);
                    dt = BLL.get_PayDetails(_obj_smhr_payroll);
                    if (dt.Rows.Count != 0)
                    {
                        Rg_PayReults.DataSource = dt;
                        Rg_PayReults.DataBind();
                        for (int i = 0; i < Rg_PayReults.Items.Count; i++)
                        {
                            LinkButton lnkview = new LinkButton();
                            lnkview = (LinkButton)Rg_PayReults.Items[i].FindControl("lnk_View") as LinkButton;
                            lnkview.Visible = true;

                        }


                    }
                    else
                    {
                        dt.Rows.Clear();
                        Rg_PayReults.DataSource = dt;
                        Rg_PayReults.DataBind();
                    }

                }
                Rg_PayReults.Visible = true;
            }
            else
            {
                dt.Rows.Clear();
                Rg_PayReults.DataSource = dt;
                Rg_PayReults.DataBind();
            }

            foreach (GridDataItem dataItem in Rg_PayReults.MasterTableView.Items)
            {
                if (dataItem["SALARY"].Text.StartsWith("-"))
                {
                    dataItem.BackColor = System.Drawing.Color.Red;
                    dataItem.ForeColor = System.Drawing.Color.White;
                    dataItem.ToolTip = "Note: Negative salary for this Employee";
                }
                else if (dataItem["SAL_FLAG"].Text.ToString() == "1")
                {
                    dataItem.BackColor = System.Drawing.Color.Yellow;
                    //dataItem.ForeColor = System.Drawing.Color.White;
                    dataItem.ToolTip = "Note: Salary less than 1/3 of Basic for this Employee";
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payresults", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    private void LoadSaldtlsold()
    {

        try
        {
            DataTable dt = new DataTable();
            if (rcmb_PeriodStatus.SelectedIndex != 0)
            {
                _obj_smhr_payroll = new SMHR_PAYROLL();
                _obj_smhr_payroll.BUID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
                _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_PeriodElement.SelectedItem.Value);
                if (rcmb_PeriodStatus.SelectedItem.Value == Convert.ToString(1)) //Approved
                {
                    _obj_smhr_payroll.MODE = 10;

                    dt = BLL.get_PayDetails(_obj_smhr_payroll);
                    if (dt.Rows.Count != 0)
                    {
                        Rg_PayReults.DataSource = dt;
                        Rg_PayReults.DataBind();
                    }
                    else
                    {
                        _obj_smhr_payroll = new SMHR_PAYROLL();
                        _obj_smhr_payroll.BUID = Convert.ToInt32(rcmb_BUI.SelectedItem.Value);
                        _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_PeriodElement.SelectedItem.Value);
                        _obj_smhr_payroll.MODE = 25;
                        DataTable dt_1 = BLL.get_PayDetails(_obj_smhr_payroll);
                        if (dt_1.Rows.Count != 0)
                        {
                            Rg_PayReults.DataSource = dt_1;
                            Rg_PayReults.DataBind();
                        }
                        else
                        {
                            dt.Rows.Clear();
                            Rg_PayReults.DataSource = dt;
                            Rg_PayReults.DataBind();
                        }
                    }
                }
                else if ((rcmb_PeriodStatus.SelectedItem.Value == Convert.ToString(2))) //Rejected
                {
                    _obj_smhr_payroll.MODE = 12;
                    dt = BLL.get_PayDetails(_obj_smhr_payroll);
                    if (dt.Rows.Count != 0)
                    {
                        Rg_PayReults.DataSource = dt;
                        Rg_PayReults.DataBind();
                    }
                    else
                    {
                        dt.Rows.Clear();
                        Rg_PayReults.DataSource = dt;
                        Rg_PayReults.DataBind();
                    }

                }
                else //Pending
                {
                    _obj_smhr_payroll.MODE = 13;
                    dt = BLL.get_PayDetails(_obj_smhr_payroll);
                    if (dt.Rows.Count != 0)
                    {
                        Rg_PayReults.DataSource = dt;
                        Rg_PayReults.DataBind();
                    }
                    else
                    {
                        dt.Rows.Clear();
                        Rg_PayReults.DataSource = dt;
                        Rg_PayReults.DataBind();
                    }

                }
                Rg_PayReults.Visible = true;
            }
            else
            {
                dt.Rows.Clear();
                Rg_PayReults.DataSource = dt;
                Rg_PayReults.DataBind();
            }

            foreach (GridDataItem dataItem in Rg_PayReults.MasterTableView.Items)
            {
                if (dataItem["SALARY"].Text.StartsWith("-"))
                {
                    dataItem.BackColor = System.Drawing.Color.Red;
                    dataItem.ForeColor = System.Drawing.Color.White;
                    dataItem.ToolTip = "Note: Negative salary for this Employee";
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payresults", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rg_PayReults.Visible = false;
            rcmb_PeriodStatus.SelectedIndex = 0;
            rcmb_PeriodElement.Items.Clear();
            rcmb_PeriodElement.Items.Insert(0, new RadComboBoxItem("", ""));
            //rcmb_BUI.SelectedIndex = -1;
            rcmb_BUI.ClearSelection();
            rcmb_PeriodMaster.ClearSelection();
            rcb_Transaction.Items.Clear();
            //rcmb_PeriodMaster.SelectedIndex = -1;
            //rcb_Transaction.SelectedIndex = -1;
            //rcb_Transaction.Items.Clear();
            rcb_Transaction.Items.Insert(0, new RadComboBoxItem("", ""));
            //added for link to Payroll Reports. By Anirudh
            lnk.Visible = false;
            lnk_Approved.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payresults", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void rcmb_BUI_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            Rg_PayReults.Visible = false;
            rcmb_PeriodStatus.SelectedIndex = 0;
            rcmb_PeriodElement.Items.Clear();
            //rcmb_PeriodMaster.SelectedIndex = -1;
            rcb_Transaction.Items.Clear();
            rcmb_PeriodMaster.ClearSelection();
            rcb_Transaction.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_PeriodElement.Items.Insert(0, new RadComboBoxItem("", ""));

            //added for link to Payroll Reports. By Anirudh
            lnk.Visible = false;
            lnk_Approved.Visible = false;
            //if(rcmb_BUI.SelectedIndex==0)
            //{
            //    lnk.Visible=false;
            //    lnk_Approved.Visible=false;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payresults", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //added for link to Payroll Reports. By Anirudh
    protected void lnk_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt_Local = BLL.ExecuteQuery("SELECT BUSINESSUNIT_LOCALISATION,HR_MASTER_CODE FROM SMHR_BUSINESSUNIT " +
                                                      "  JOIN SMHR_HR_MASTER ON " +
                                                      "  BUSINESSUNIT_LOCALISATION = HR_MASTER_ID WHERE BUSINESSUNIT_ID = '" + Convert.ToInt32(rcmb_BUI.SelectedValue) + "'");
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop_Pending('" + Convert.ToString(rcmb_PeriodMaster.SelectedValue)
                + "','" + Convert.ToString(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_BUI.SelectedValue)
                + "','" + Convert.ToInt32(rcmb_PeriodElement.SelectedValue) + "','" + Convert.ToInt32(rcb_Transaction.SelectedValue)
                + "','" + Convert.ToString(dt_Local.Rows[0]["HR_MASTER_CODE"]) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payresults", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void lnk_Approved_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt_Local = BLL.ExecuteQuery("SELECT BUSINESSUNIT_LOCALISATION,HR_MASTER_CODE FROM SMHR_BUSINESSUNIT " +
                                                      "  JOIN SMHR_HR_MASTER ON " +
                                                      "  BUSINESSUNIT_LOCALISATION = HR_MASTER_ID WHERE BUSINESSUNIT_ID = '" + Convert.ToInt32(rcmb_BUI.SelectedValue) + "'");

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop_Approved('" + Convert.ToString(rcmb_PeriodMaster.SelectedValue)
                + "','" + Convert.ToString(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_BUI.SelectedValue)
                + "','" + Convert.ToInt32(rcmb_PeriodElement.SelectedValue) + "','" + Convert.ToInt32(rcb_Transaction.SelectedValue)
                + "','" + Convert.ToString(dt_Local.Rows[0]["HR_MASTER_CODE"]) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payresults", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    //added for link to Payroll Reports. By Anirudh
    protected void btnShowResult_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowResult(" + rcmb_BUI.SelectedValue + "," +
                rcmb_PeriodMaster.SelectedValue + "," + rcmb_PeriodElement.SelectedValue + ");", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payresults", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}