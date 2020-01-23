using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Telerik.Web.UI;
using Telerik.Web.UI.GridExcelBuilder;
using SMHR;

public partial class Payroll_frm_Esiexport : System.Web.UI.Page
{
    #region References
    /// <summary>
    /// This Region will consists of references that were used in through out the form
    /// </summary>
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_ESIIMPORT _obj_SMHR_ESIIMPORT = new SMHR_ESIIMPORT();
    DataTable dt_Information = new DataTable();
    DataTable dt_null;
    #endregion

    #region Page Load
    /// <summary>
    /// This region will consists of methods which will load the basic information related to that screen
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                Session.Remove("WRITEFACILITY");
                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("ESI Export");//ESIIMPORT");
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
                    rg_Esiparent.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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

                LoadMainGrid();
                rg_Esiparent.DataBind();
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Esiexport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
    #endregion

    #region Loading Methods
    /// <summary>
    /// This region will load information about grid, combo boxes and etc.
    /// </summary>  

    private void LoadMainGrid()
    {
        try
        {
            _obj_SMHR_ESIIMPORT.Mode = 1;
            _obj_SMHR_ESIIMPORT.ESIIMPORT_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Information = BLL.get_ESIimport(_obj_SMHR_ESIIMPORT);
            rg_Esiparent.DataSource = dt_Information;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Esiexport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            // Loading Business units

            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            rcmb_Perioddtls.Items.Clear();
            rcmb_Busniessunit.Items.Clear();
            rcmb_Financialperiod.Items.Clear();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            dt_Information = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            if (dt_Information.Rows.Count != 0)
            {
                rcmb_Busniessunit.DataSource = dt_Information;
                rcmb_Busniessunit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_Busniessunit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_Busniessunit.DataBind();
                rcmb_Busniessunit.Items.Insert(0, new RadComboBoxItem("Select"));
                rcmb_Busniessunit.SelectedIndex = 0;
            }
            else
            {
                rcmb_Busniessunit.DataSource = dt_null;
                rcmb_Busniessunit.DataBind();
                rcmb_Busniessunit.Items.Insert(0, new RadComboBoxItem("Select"));
            }

            // Loading Periods

            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_SMHR_LoginInfo.LOGIN_ID = 53;
            dt_Information = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            if (dt_Information.Rows.Count != 0)
            {
                rcmb_Financialperiod.DataSource = dt_Information;
                rcmb_Financialperiod.DataValueField = "PERIOD_ID";
                rcmb_Financialperiod.DataTextField = "PERIOD_NAME";
                rcmb_Financialperiod.DataBind();
                rcmb_Financialperiod.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                rcmb_Financialperiod.DataSource = dt_null;
                rcmb_Financialperiod.DataBind();
                rcmb_Financialperiod.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Esiexport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearControls()
    {
        rcmb_Busniessunit.Items.Clear();
        rcmb_Financialperiod.Items.Clear();
        rcmb_Perioddtls.Items.Clear();
        rg_Child.Visible = false;
    }

    private void LoadchildGrid()
    {
        try
        {
            SMHR_ESIMASTER _obj_Smhr_ESIMASTER = new SMHR_ESIMASTER();
            _obj_Smhr_ESIMASTER.Mode = 7;
            _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_BUID = Convert.ToInt32(rcmb_Busniessunit.SelectedItem.Value);
            _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_CREATEDBY = Convert.ToInt32(rcmb_Perioddtls.SelectedValue);
            dt_Information = BLL.get_ESIMASTER(_obj_Smhr_ESIMASTER);
            if (dt_Information.Rows.Count != 0)
            {
                btn_Save.Visible = true;
                btn_Finalise.Visible = true;
                rg_Child.DataSource = dt_Information;
                rg_Child.DataBind();
            }
            else
            {
                btn_Save.Visible = false;
                btn_Finalise.Visible = false;
                rg_Child.DataSource = dt_Information;
                rg_Child.DataBind();
            }
            // checking whether particular period is finalised or not.
            _obj_Smhr_ESIMASTER.Mode = 10;
            _obj_Smhr_ESIMASTER.BUID = Convert.ToInt32(rcmb_Busniessunit.SelectedValue);
            _obj_Smhr_ESIMASTER.SMHR_ESI_MASTER_MODIFIEDBY = Convert.ToInt32(rcmb_Perioddtls.SelectedValue);
            dt_Information = BLL.get_ESIMASTER(_obj_Smhr_ESIMASTER);
            if (dt_Information.Rows.Count > 0)
            {
                if (dt_Information.Rows[0][0].ToString() == "1")
                {
                    BLL.ShowMessage(this, "the Selected Period is Finalised");
                    btn_Finalise.Visible = false;
                    btn_Save.Visible = false;
                    _obj_SMHR_ESIIMPORT.Mode = 2;
                    _obj_SMHR_ESIIMPORT.ESIIMPORT_PERIDEMLEMENTID = Convert.ToInt32(rcmb_Perioddtls.SelectedValue);
                    dt_Information = BLL.get_ESIimport(_obj_SMHR_ESIIMPORT);
                    rg_Child.DataSource = dt_Information;
                    rg_Child.DataBind();

                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Esiexport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Redirecting In Multipage
    /// <summary>
    /// This region will consists of method that will load the relevant information when multiview pages are viewed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rcmb_Busniessunit.Enabled = true;
            rcmb_Financialperiod.Enabled = true;
            rcmb_Perioddtls.Enabled = true;
            btn_Save.Visible = true;
            btn_Finalise.Visible = true;
            LoadCombos();
            rg_Child.Visible = false;
            rg_Child.DataSource = dt_null;
            rg_Child.DataBind();
            rmp_Esiexport.SelectedIndex = 1;

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Esiexport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Download_Command(object sender, CommandEventArgs e)
    {
        try
        {
            LoadCombos();
            _obj_SMHR_ESIIMPORT.Mode = 2;
            _obj_SMHR_ESIIMPORT.ESIIMPORT_PERIDEMLEMENTID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            dt_Information = BLL.get_ESIimport(_obj_SMHR_ESIIMPORT);
            if (dt_Information.Rows.Count != 0)
            {
                rcmb_Busniessunit.SelectedIndex = rcmb_Busniessunit.Items.FindItemIndexByValue(Convert.ToString(dt_Information.Rows[0]["ESIIMPORT_BUID"]));
                rcmb_Financialperiod.SelectedIndex = rcmb_Financialperiod.Items.FindItemIndexByValue(Convert.ToString(dt_Information.Rows[0]["ESIIMPORT_FINANCIAL_PERIOD"]));

                // loading the period elements under that period

                SMHR_PAYROLL _obj_smhr_payroll = new SMHR_PAYROLL();
                _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_Financialperiod.SelectedValue);
                _obj_smhr_payroll.MODE = 11;
                DataTable dt_Details = new DataTable();
                dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_Perioddtls.DataSource = dt_Details;
                    rcmb_Perioddtls.DataValueField = "PRDDTL_ID";
                    rcmb_Perioddtls.DataTextField = "PRDDTL_NAME";
                    rcmb_Perioddtls.DataBind();
                    rcmb_Perioddtls.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                rcmb_Perioddtls.SelectedIndex = rcmb_Perioddtls.Items.FindItemIndexByValue(Convert.ToString(dt_Information.Rows[0]["ESIIMPORT_PERIDEMLEMENTID"]));
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    BLL.ShowMessage(this, "this User Type is Not Allowed to View and Download the Esi Information");
                    return;
                }

                Session["ESIInfo"] = dt_Information;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowESIInfo('" + Convert.ToString(rcmb_Busniessunit.SelectedItem.Text) + "','" + Convert.ToString(rcmb_Financialperiod.SelectedItem.Value) + "','" + Convert.ToString(rcmb_Perioddtls.SelectedItem.Text) + "');", true);
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Esiexport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Selection Changed Methods

    protected void rg_Esiparent_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadMainGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Esiexport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rg_Child_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (rcmb_Perioddtls.SelectedIndex > 0)
            {
                _obj_SMHR_ESIIMPORT.Mode = 2;
                _obj_SMHR_ESIIMPORT.ESIIMPORT_PERIDEMLEMENTID = Convert.ToInt32(rcmb_Perioddtls.SelectedValue);
                dt_Information = BLL.get_ESIimport(_obj_SMHR_ESIIMPORT);
                rg_Child.DataSource = dt_Information;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Esiexport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Busniessunit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_Financialperiod.ClearSelection();
            rcmb_Perioddtls.Items.Clear();
            rg_Child.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Esiexport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Financialperiod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            // checking whether selection is made or not for business unit combo box
            if (rcmb_Busniessunit.SelectedIndex > 0)
            {
                // checking for financial period
                if (rcmb_Financialperiod.SelectedIndex > 0)
                {

                    SMHR_PAYROLL _obj_smhr_payroll = new SMHR_PAYROLL();
                    _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_Financialperiod.SelectedValue);
                    _obj_smhr_payroll.MODE = 11;
                    dt_Information = BLL.get_payrolltrans(_obj_smhr_payroll);
                    if (dt_Information.Rows.Count != 0)
                    {
                        rcmb_Perioddtls.DataSource = dt_Information;
                        rcmb_Perioddtls.DataValueField = "PRDDTL_ID";
                        rcmb_Perioddtls.DataTextField = "PRDDTL_NAME";
                        rcmb_Perioddtls.DataBind();
                        rcmb_Perioddtls.Items.Insert(0, new RadComboBoxItem("Select"));
                    }
                    else
                    {
                        rcmb_Perioddtls.DataSource = dt_null;
                        rcmb_Perioddtls.DataBind();
                        rcmb_Perioddtls.Items.Insert(0, new RadComboBoxItem("Select"));
                    }

                }
                else
                {
                    BLL.ShowMessage(this, "Select Financial Period");
                    rcmb_Perioddtls.Items.Clear();
                }

            }
            else
            {
                BLL.ShowMessage(this, "Select Businessunit");
                rcmb_Financialperiod.ClearSelection();
                rcmb_Perioddtls.Items.Clear();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Esiexport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Perioddtls_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Perioddtls.SelectedIndex > 0)
            {
                LoadchildGrid();
                for (int i = 0; i < rg_Child.Items.Count; i++)
                {
                    Label LBLAMOUNT;
                    LBLAMOUNT = rg_Child.Items[i].FindControl("lbl_Total") as Label;
                    Label LBLREASONCODE;
                    LBLREASONCODE = rg_Child.Items[i].FindControl("lbl_Reasoncode") as Label;
                    if (LBLAMOUNT.Text == "0")
                    {
                        LBLREASONCODE.Text = "1";
                    }
                    else
                    {
                        LBLREASONCODE.Text = "0";
                    }

                }
                rg_Child.Visible = true;
                if (rg_Child.Items.Count <= 0)
                    BLL.ShowMessage(this, "Payroll is not Executed For the Selected Period Element or ESI Master is not set for any Employee");
            }
            else
            {
                BLL.ShowMessage(this, "Select Period Element");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Esiexport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Button Clicks
    /// <summary>
    /// This region will consists of all method related to button clicks
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":
                    _obj_SMHR_ESIIMPORT.SMHR_ESIIMPORT_ISFINALISED = false;
                    break;

                case "BTN_FINALISE":
                    _obj_SMHR_ESIIMPORT.SMHR_ESIIMPORT_ISFINALISED = true;
                    break;
                default:
                    break;
            }

            bool status = false;
            for (int i = 0; i < rg_Child.Items.Count; i++)
            {
                Label LBLEMPLOYEE;
                LBLEMPLOYEE = rg_Child.Items[i].FindControl("lbl_Empname") as Label;
                Label LBLIPNO;
                LBLIPNO = rg_Child.Items[i].FindControl("lbl_Ipnumber") as Label;
                Label LBLIPNAME;
                LBLIPNAME = rg_Child.Items[i].FindControl("lbl_Ipname") as Label;
                Label LBLPRESENTDAYS;
                LBLPRESENTDAYS = rg_Child.Items[i].FindControl("lbl_Presentdays") as Label;
                Label LBLTOTALAMOUNT;
                LBLTOTALAMOUNT = rg_Child.Items[i].FindControl("lbl_Total") as Label;
                Label LBLREASONCODE;
                LBLREASONCODE = rg_Child.Items[i].FindControl("lbl_Reasoncode") as Label;
                _obj_SMHR_ESIIMPORT.Mode = 3;
                _obj_SMHR_ESIIMPORT.ESIIMPORT_BUID = Convert.ToInt32(rcmb_Busniessunit.SelectedItem.Value);
                _obj_SMHR_ESIIMPORT.ESIIMPORT_ORGID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_ESIIMPORT.ESIIMPORT_FINANCIAL_PERIOD = Convert.ToInt32(rcmb_Financialperiod.SelectedItem.Value);
                _obj_SMHR_ESIIMPORT.ESIIMPORT_PERIDEMLEMENTID = Convert.ToInt32(rcmb_Perioddtls.SelectedItem.Value);
                _obj_SMHR_ESIIMPORT.ESIIMPORT_EMPNAME = Convert.ToString(LBLEMPLOYEE.Text);
                _obj_SMHR_ESIIMPORT.ESIIMPORT_IPNO = Convert.ToString(LBLIPNO.Text);
                _obj_SMHR_ESIIMPORT.ESIIMPORT_IPNAME = Convert.ToString(LBLIPNAME.Text);
                _obj_SMHR_ESIIMPORT.ESIIMPORT_PRESENTDAYS = Convert.ToInt32(LBLPRESENTDAYS.Text);
                _obj_SMHR_ESIIMPORT.ESIIMPORT_TOTALAMOUNT = Convert.ToString(LBLTOTALAMOUNT.Text);
                _obj_SMHR_ESIIMPORT.ESIIMPORT_REASONCODE = Convert.ToInt32(LBLREASONCODE.Text);
                _obj_SMHR_ESIIMPORT.SMHR_ESIIMPORT_EMPID = Convert.ToInt32((rg_Child.Items[i].FindControl("lbl_Empid") as Label).Text);
                status = BLL.set_ESIimport(_obj_SMHR_ESIIMPORT);
            }
            if (status == true)
            {
                BLL.ShowMessage(this, "Record Inserted Successfully");
                rcmb_Perioddtls.Items.Clear();
                rcmb_Busniessunit.Items.Clear();
                rcmb_Financialperiod.Items.Clear();
                rmp_Esiexport.SelectedIndex = 0;
                LoadMainGrid();
                rg_Esiparent.DataBind();
            }
            else
            {
                if (rg_Child.Items.Count > 0)
                    BLL.ShowMessage(this, "Error is Occured During the Process!");
                else
                    BLL.ShowMessage(this, "No Employee has Found!");
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Esiexport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Finalise_Click(object sender, EventArgs e)
    {
        try
        {
            btn_Save_Click(sender, null);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Esiexport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            rmp_Esiexport.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Esiexport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

}
