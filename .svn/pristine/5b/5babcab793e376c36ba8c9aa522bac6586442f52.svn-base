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
using System.Text;
using Telerik.Web.UI;
using System.IO;


public partial class Payroll_frm_YTDOpeningBalances : System.Web.UI.Page
{

    SMHR_BUSINESSUNIT _obj_smhr_Businessunit;
    SMHR_PERIOD _obj_smhr_Period;
    SMHR_PERIODDTL _obj_Smhr_Prddtl;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_PAYITEMS _obj_smhr_Payitem;
    SMHR_YTDOPENINGBALANCE _obj_Smhr_YTDOpeningBalance;

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    // ----------------------------------------------------------------------------------------
    // Author:                        Dhanush InfoTech Pvt. Ltd, India
    // Company:                       Dhanush InfoTech Pvt Ltd, India
    // Assembly version:              
    // Date:                          18/08/2010
    // Time:                          15:22
    // Project Item Name:             frm_YTDOpeningBalances.aspx
    // Project Item Filename:         frm_YTDOpeningBalances.aspx.cs
    // Class FullName:                Payroll_frm_YTDOpeningBalances
    // Class Name:                    Payroll_frm_YTDOpeningBalances
    // Procedure Name:                Page_Load
    // Purpose:                       Page Load
    // ----------------------------------------------------------------------------------------
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {



                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("YTD OPENING BALANCES");
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

                    Btn_Save.Visible = false;
                    Btn_Finalize.Visible = false;

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
                Page.Validate();
                LoadCombos();
                Rg_YTDOB.Visible = true;


            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_YTDOpeningBalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    // ----------------------------------------------------------------------------------------
    // Author:                        Dhanush InfoTech Pvt. Ltd, India
    // Company:                       Dhanush InfoTech Pvt Ltd, India
    // Assembly version:              
    // Date:                          18/08/2010
    // Time:                          15:23
    // Project Item Name:             frm_YTDOpeningBalances.aspx
    // Project Item Filename:         frm_YTDOpeningBalances.aspx.cs
    // Class FullName:                Payroll_frm_YTDOpeningBalances
    // Class Name:                    Payroll_frm_YTDOpeningBalances
    // Procedure Name:                Rg_YTD_OpeningBalance_NeedDataSource
    // Purpose:                       For Telerik Grid Datasource Binding
    // ----------------------------------------------------------------------------------------
    protected void Rg_YTD_OpeningBalance_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        //LoadGrid();
    }

    private void LoadCombos()
    {
        try
        {
            //Business Unit
            rcmb_BusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BusinessUnit.DataSource = dt_BUDetails;
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            rcmb_Period.Items.Clear();
            _obj_smhr_Period = new SMHR_PERIOD();
            _obj_smhr_Period.OPERATION = operation.Select;
            _obj_smhr_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_PeriodHeaderDetails(_obj_smhr_Period);
            rcmb_Period.DataSource = dt;
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select"));


            //Pay Item
            rcmb_Payitem.Items.Clear();
            _obj_Smhr_YTDOpeningBalance = new SMHR_YTDOPENINGBALANCE();
            _obj_Smhr_YTDOpeningBalance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_YTDOpeningBalance.OPERATION = operation.EMPTY1;
            DataTable dtPayitem = BLL.get_YTDOpeningBalance(_obj_Smhr_YTDOpeningBalance);
            rcmb_Payitem.DataSource = dtPayitem;
            rcmb_Payitem.DataValueField = "PAYITEM_ID";
            rcmb_Payitem.DataTextField = "PAYITEM_PAYITEMNAME";
            rcmb_Payitem.DataBind();
            rcmb_Payitem.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_YTDOpeningBalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            _obj_Smhr_YTDOpeningBalance = new SMHR_YTDOPENINGBALANCE();
            _obj_Smhr_YTDOpeningBalance.OPERATION = operation.Select;
            _obj_Smhr_YTDOpeningBalance.YTD_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            _obj_Smhr_YTDOpeningBalance.YTD_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
            _obj_Smhr_YTDOpeningBalance.YTD_PAYITEM_ID = Convert.ToInt32(rcmb_Payitem.SelectedItem.Value);
            DataTable DT = BLL.get_YTDOpeningBalance(_obj_Smhr_YTDOpeningBalance);
            Rg_YTDOB.DataSource = DT;

            Rg_YTDOB.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_YTDOpeningBalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Period_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Period.SelectedIndex > 0)
            {
                rcmb_PeriodElements.Items.Clear();
                _obj_Smhr_Prddtl = new SMHR_PERIODDTL();
                _obj_Smhr_Prddtl.OPERATION = operation.Select;
                _obj_Smhr_Prddtl.ISDELETED = true;
                _obj_Smhr_Prddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedValue);
                DataTable dt_Period = BLL.get_PeriodDetails(_obj_Smhr_Prddtl);

                rcmb_PeriodElements.DataSource = dt_Period;
                rcmb_PeriodElements.DataValueField = "PRDDTL_ID";
                rcmb_PeriodElements.DataTextField = "PRDDTL_NAME";
                rcmb_PeriodElements.DataBind();
                rcmb_PeriodElements.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
            else
            {
                rcmb_PeriodElements.Items.Clear();
                rcmb_Payitem.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_YTDOpeningBalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        try
        {

            bool result = false;
            for (int i = 0; i < Rg_YTDOB.Items.Count; i++)
            {
                //employee id
                _obj_Smhr_YTDOpeningBalance = new SMHR_YTDOPENINGBALANCE();
                _obj_Smhr_YTDOpeningBalance.OPERATION = operation.Select;
                _obj_Smhr_YTDOpeningBalance.YTD_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);

                DataTable DT = BLL.get_YTDOpeningBalance(_obj_Smhr_YTDOpeningBalance);


                RadNumericTextBox rntb, rtxtoldbalance = new RadNumericTextBox();
                RadComboBox rcmb = new RadComboBox();
                rntb = Rg_YTDOB.Items[i].FindControl("rnt_NewBal") as RadNumericTextBox;
                rtxtoldbalance = Rg_YTDOB.Items[i].FindControl("txt_oldbalance") as RadNumericTextBox;

                rcmb = Rg_YTDOB.Items[i].FindControl("rcmb_Select") as RadComboBox;

                _obj_Smhr_YTDOpeningBalance = new SMHR_YTDOPENINGBALANCE();

                _obj_Smhr_YTDOpeningBalance.YTD_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
                _obj_Smhr_YTDOpeningBalance.YTD_PAYITEM_ID = Convert.ToInt32(rcmb_Payitem.SelectedItem.Value);
                _obj_Smhr_YTDOpeningBalance.YTD_OLDBALANCE = Convert.ToDecimal(rtxtoldbalance.Text);
                _obj_Smhr_YTDOpeningBalance.YTD_NEWBALANCE = Convert.ToInt32(rntb.Value);
                //_obj_Smhr_YTDOpeningBalance.YTD_OPERATION = Convert.ToString(rcmb.SelectedItem.Text );
                _obj_Smhr_YTDOpeningBalance.YTD_EMP_ID = Convert.ToInt32(Rg_YTDOB.Items[i]["EMP_ID"].Text);
                _obj_Smhr_YTDOpeningBalance.YTD_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                _obj_Smhr_YTDOpeningBalance.YTD_STATUS = 0;
                _obj_Smhr_YTDOpeningBalance.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Smhr_YTDOpeningBalance.CREATEDDATE = DateTime.Now;

                _obj_Smhr_YTDOpeningBalance.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Smhr_YTDOpeningBalance.LASTMDFDATE = DateTime.Now;
                _obj_Smhr_YTDOpeningBalance.OPERATION = operation.Insert;
                _obj_Smhr_YTDOpeningBalance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                result = BLL.set_YTDOpeningBalance(_obj_Smhr_YTDOpeningBalance);
                //obj_Smhr_YTDOpeningBalance.OPERATION = operation.Update;
                //BLL.set_YTDOpeningBalance(_obj_Smhr_YTDOpeningBalance);
            }
            if (result == true)
            {

                Rg_YTDOB.Visible = true;
                LoadGrid();
                Rg_YTDOB.DataBind();
                BLL.ShowMessage(this, "YTD Transaction completed successfully");
                //Btn_Save.Enabled = false;
                Btn_Finalize.Visible = true;
                Btn_Finalize.Enabled = true;
            }
            else
            {
                BLL.ShowMessage(this, "YTD Transaction failed");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_YTDOpeningBalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        //Rg_YTDOB.Visible = true;
        //LoadGrid();
        //Rg_YTDOB.DataBind();
    }

    protected void Btn_Finalize_Click(object sender, EventArgs e)
    {
        try
        {
            bool result = false;
            for (int i = 0; i < Rg_YTDOB.Items.Count; i++)
            {

                _obj_Smhr_YTDOpeningBalance = new SMHR_YTDOPENINGBALANCE();
                _obj_Smhr_YTDOpeningBalance.OPERATION = operation.Select;
                _obj_Smhr_YTDOpeningBalance.YTD_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                DataTable DT = BLL.get_YTDOpeningBalance(_obj_Smhr_YTDOpeningBalance);

                RadNumericTextBox rtxtoldbalance = new RadNumericTextBox();
                RadNumericTextBox rntb = new RadNumericTextBox();
                RadComboBox rcmb = new RadComboBox();
                rtxtoldbalance = Rg_YTDOB.Items[i].FindControl("txt_oldbalance") as RadNumericTextBox;
                rntb = Rg_YTDOB.Items[i].FindControl("rnt_NewBal") as RadNumericTextBox;

                rcmb = Rg_YTDOB.Items[i].FindControl("rcmb_Select") as RadComboBox;

                _obj_Smhr_YTDOpeningBalance = new SMHR_YTDOPENINGBALANCE();
                _obj_Smhr_YTDOpeningBalance.YTD_ID = Convert.ToInt32(Rg_YTDOB.Items[i]["YTD_ID"].Text);
                _obj_Smhr_YTDOpeningBalance.YTD_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
                _obj_Smhr_YTDOpeningBalance.YTD_PAYITEM_ID = Convert.ToInt32(rcmb_Payitem.SelectedItem.Value);
                _obj_Smhr_YTDOpeningBalance.YTD_OLDBALANCE = Convert.ToDecimal(rtxtoldbalance.Text);
                _obj_Smhr_YTDOpeningBalance.YTD_NEWBALANCE = Convert.ToInt32(rntb.Value);
                //_obj_Smhr_YTDOpeningBalance.YTD_OPERATION = Convert.ToString(rcmb.SelectedItem.Text);
                _obj_Smhr_YTDOpeningBalance.YTD_EMP_ID = Convert.ToInt32(Rg_YTDOB.Items[i]["EMP_ID"].Text);
                _obj_Smhr_YTDOpeningBalance.YTD_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                _obj_Smhr_YTDOpeningBalance.YTD_STATUS = 1;
                _obj_Smhr_YTDOpeningBalance.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Smhr_YTDOpeningBalance.CREATEDDATE = DateTime.Now;
                _obj_Smhr_YTDOpeningBalance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                _obj_Smhr_YTDOpeningBalance.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Smhr_YTDOpeningBalance.LASTMDFDATE = DateTime.Now;
                _obj_Smhr_YTDOpeningBalance.OPERATION = operation.Update;
                result = true;
                result = BLL.set_YTDOpeningBalance(_obj_Smhr_YTDOpeningBalance);
            }
            if (result == true)
            {
                BLL.ShowMessage(this, "YTD Transaction Finalized successfully");
                Rg_YTDOB.DataSource = null;
                Rg_YTDOB.DataBind();
                Btn_Finalize.Enabled = false;
                Btn_Save.Enabled = false;
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_YTDOpeningBalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_YTDOpeningBalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearControls()
    {
        try
        {
            rcmb_BusinessUnit.SelectedIndex = -1;
            rcmb_Payitem.SelectedIndex = -1;
            rcmb_Period.SelectedIndex = -1;
            rcmb_PeriodElements.Items.Clear();
            rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem());
            Rg_YTDOB.Visible = false;
            Btn_Save.Visible = false;
            Btn_Save.Enabled = true;
            Btn_Finalize.Enabled = true;
            Btn_Finalize.Visible = false;
            Btn_Cancel.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_YTDOpeningBalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_PeriodElements_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //if (!(rcmb_PeriodElements.SelectedIndex > 0))
            //{
            //    Rg_YTDOB.Visible = false;
            //    Btn_Save.Visible = false;
            //    Btn_Finalize.Visible = false;
            //}
            rcmb_Payitem.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_YTDOpeningBalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Payitem_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BusinessUnit.SelectedIndex > 0 && rcmb_Period.SelectedIndex > 0)
            {
                if (rcmb_Payitem.SelectedIndex != 0)
                {
                    _obj_Smhr_YTDOpeningBalance = new SMHR_YTDOPENINGBALANCE();
                    _obj_Smhr_YTDOpeningBalance.OPERATION = operation.Validate;
                    _obj_Smhr_YTDOpeningBalance.YTD_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                    _obj_Smhr_YTDOpeningBalance.YTD_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
                    _obj_Smhr_YTDOpeningBalance.YTD_PAYITEM_ID = Convert.ToInt32(rcmb_Payitem.SelectedItem.Value);

                    DataTable dt_count = BLL.get_YTDCount(_obj_Smhr_YTDOpeningBalance);
                    if (dt_count.Rows.Count != 0)
                    {
                        if (Convert.ToInt32(dt_count.Rows[0]["CNT"]) > 0)
                        {
                            _obj_Smhr_YTDOpeningBalance = new SMHR_YTDOPENINGBALANCE();
                            _obj_Smhr_YTDOpeningBalance.YTD_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                            _obj_Smhr_YTDOpeningBalance.YTD_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
                            _obj_Smhr_YTDOpeningBalance.YTD_PAYITEM_ID = Convert.ToInt32(rcmb_Payitem.SelectedItem.Value);
                            _obj_Smhr_YTDOpeningBalance.OPERATION = operation.Select;
                            DataTable DT = BLL.get_YTDOpeningBalance(_obj_Smhr_YTDOpeningBalance);
                            if (DT.Rows.Count != 0)
                            {
                                if (Convert.ToInt32((DT.Rows[0]["YTD_STATUS"])) == 1)
                                {
                                    Rg_YTDOB.Enabled = false;
                                    Rg_YTDOB.DataSource = DT;
                                    Rg_YTDOB.DataBind();
                                    Btn_Save.Visible = false;
                                    Btn_Save.Enabled = false;
                                }
                                else
                                {
                                    Rg_YTDOB.Enabled = true;
                                    Rg_YTDOB.DataSource = DT;
                                    Rg_YTDOB.DataBind();
                                    Btn_Save.Visible = true;
                                    Btn_Save.Enabled = true;
                                }
                            }
                        }
                        else
                        {
                            _obj_Smhr_YTDOpeningBalance.OPERATION = operation.Empty;
                            DataTable DT1 = BLL.get_YTDOpeningBalance(_obj_Smhr_YTDOpeningBalance);
                            Rg_YTDOB.DataSource = DT1;
                            Rg_YTDOB.DataBind();
                            Rg_YTDOB.Enabled = true;
                            Btn_Save.Visible = true;
                            Btn_Save.Enabled = true;
                        }
                    }
                    Rg_YTDOB.Visible = true;
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        Btn_Finalize.Visible = false;
                        Btn_Save.Visible = false;


                    }

                    else
                    {
                        Btn_Finalize.Visible = false;
                        //Btn_Save.Visible = true;
                        //Btn_Save.Enabled = true;
                        Btn_Finalize.Enabled = true;

                    }


                    Btn_Cancel.Visible = true;
                }
                else
                {
                    Rg_YTDOB.Visible = false;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please Select All Parameters.");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_YTDOpeningBalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_Payitem.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_YTDOpeningBalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}


