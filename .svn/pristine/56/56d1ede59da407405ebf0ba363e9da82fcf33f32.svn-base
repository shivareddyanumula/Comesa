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
using SMHR;
using Telerik.Web.UI;
using System.Collections.Generic;

public partial class Pension_frm_AddQuarters : System.Web.UI.Page
{
    string strfilename2;
    DataSet ds = new DataSet();


    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    SMHR_PENSION_QUARTERS _obj_Smhr_PensionQrtrs;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            if (RWM_POSTREPLY1.Windows.Count > 0)
            {
                RWM_POSTREPLY1.Windows.RemoveAt(0);
            }
            if (!IsPostBack)
            {



                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Quarters");//COUNTRY");
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
                    Rg_InteretsQuarters.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                Page.Validate();
                // BindExpen
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddQuarters", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();

            _obj_Smhr_PensionQrtrs = new SMHR_PENSION_QUARTERS();
            _obj_Smhr_PensionQrtrs.OPERATION = operation.Get;
            _obj_Smhr_PensionQrtrs.QRTR_ID = Convert.ToInt32(e.CommandArgument);
            lblID.Text = _obj_Smhr_PensionQrtrs.QRTR_ID.ToString();
            _obj_Smhr_PensionQrtrs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_PensionQuarters(_obj_Smhr_PensionQrtrs);
            BindFinancialPeriod();
            radFinPeriod.SelectedIndex = radFinPeriod.FindItemIndexByValue(dt.Rows[0]["QRTR_PERIODID"].ToString());
            radQuarters.SelectedIndex = radQuarters.FindItemIndexByValue(dt.Rows[0]["QRTR_NOOFQRTRS"].ToString());
            radFinPeriod.Enabled = radQuarters.Enabled = false;
            DataTable dtGridData = GetDataTable();
            for (int i = 1; i <= Convert.ToInt32(dt.Rows[0]["QRTR_NOOFQRTRS"]); i++)
            {
                switch (i.ToString())
                {
                    case "1":
                        dtGridData.Rows.Add(i, "Quarter " + i.ToString(), Convert.ToDateTime(dt.Rows[0]["PERIOD_STARTDATE"]), Convert.ToDateTime(dt.Rows[0]["PERIOD_ENDDATE"]), Convert.ToDateTime(dt.Rows[0]["QRTR_QRTR1SDATE"]), Convert.ToDateTime(dt.Rows[0]["QRTR_QRTR1EDATE"]));
                        break;
                    case "2":
                        dtGridData.Rows.Add(i, "Quarter " + i.ToString(), Convert.ToDateTime(dt.Rows[0]["PERIOD_STARTDATE"]), Convert.ToDateTime(dt.Rows[0]["PERIOD_ENDDATE"]), Convert.ToDateTime(dt.Rows[0]["QRTR_QRTR2SDATE"]), Convert.ToDateTime(dt.Rows[0]["QRTR_QRTR2EDATE"]));
                        break;
                    case "3":
                        dtGridData.Rows.Add(i, "Quarter " + i.ToString(), Convert.ToDateTime(dt.Rows[0]["PERIOD_STARTDATE"]), Convert.ToDateTime(dt.Rows[0]["PERIOD_ENDDATE"]), Convert.ToDateTime(dt.Rows[0]["QRTR_QRTR3SDATE"]), Convert.ToDateTime(dt.Rows[0]["QRTR_QRTR3EDATE"]));
                        break;
                    case "4":
                        dtGridData.Rows.Add(i, "Quarter " + i.ToString(), Convert.ToDateTime(dt.Rows[0]["PERIOD_STARTDATE"]), Convert.ToDateTime(dt.Rows[0]["PERIOD_ENDDATE"]), Convert.ToDateTime(dt.Rows[0]["QRTR_QRTR4SDATE"]), Convert.ToDateTime(dt.Rows[0]["QRTR_QRTR4EDATE"]));
                        break;

                }
            }
            Rg_Quarters.DataSource = dtGridData;
            Rg_Quarters.DataBind();
            Rg_Quarters.Visible = true;
            SMHR_PERIOD osmhr_period = new SMHR_PERIOD();
            osmhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            osmhr_period.PERIOD_ID = Convert.ToInt32(radFinPeriod.SelectedValue);
            DataTable dtCurrentFinPeriod = BLL.IscurrentFinPeriod(osmhr_period);
            if (string.Compare(dtCurrentFinPeriod.Rows[0]["ISEXISTS"].ToString(), "0", true) == 0)
            {
                Rg_Quarters.Enabled = false;
                btn_Update.Visible = false;

            }
            else
            {
                Rg_Quarters.Enabled = Convert.ToBoolean(dt.Rows[0]["ISEnable"]);
                btn_Update.Visible = Convert.ToBoolean(dt.Rows[0]["ISEnable"]);
            }

            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddQuarters", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }




    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            radFinPeriod.Enabled = radQuarters.Enabled = true;
            radQuarters.ClearSelection();
            btn_Save.Visible = false;
            Rg_Quarters.Visible = false;
            clearControls();
            BindFinancialPeriod();
            SMHR_PENSION_QUARTERS _obj_Smhr_PensionQrtrs = new SMHR_PENSION_QUARTERS();
            _obj_Smhr_PensionQrtrs.OPERATION = operation.Select;
            _obj_Smhr_PensionQrtrs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_PensionQuarters(_obj_Smhr_PensionQrtrs);
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow dr in DT.Rows)
                {
                    radFinPeriod.Items.Remove(radFinPeriod.FindItemIndexByValue(dr["QRTR_PERIODID"].ToString()));
                }
            }
            //ControlsEnableorDisable(true);
            btn_Save.Visible = true;
            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddQuarters", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    public void LoadGrid()
    {
        try
        {
            SMHR_PENSION_QUARTERS _obj_Smhr_PensionQrtrs = new SMHR_PENSION_QUARTERS();
            _obj_Smhr_PensionQrtrs.OPERATION = operation.Select;
            _obj_Smhr_PensionQrtrs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_PensionQuarters(_obj_Smhr_PensionQrtrs);
            Rg_InteretsQuarters.DataSource = DT;

            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddQuarters", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {

            _obj_Smhr_PensionQrtrs = new SMHR_PENSION_QUARTERS();
            _obj_Smhr_PensionQrtrs.QRTR_PERIODID = Convert.ToInt32(radFinPeriod.SelectedItem.Value);
            _obj_Smhr_PensionQrtrs.QRTR_NOOFQRTRS = Convert.ToInt32(radQuarters.SelectedItem.Value);
            RadDatePicker rd1, rd2;
            foreach (GridDataItem g in Rg_Quarters.Items)
            {
                rd1 = rd2 = new RadDatePicker();
                rd1 = g.FindControl("rdpStartDate") as RadDatePicker;
                rd2 = g.FindControl("rdpEndDate") as RadDatePicker;
                switch (g.Cells[2].Text)
                {
                    case "1":
                        _obj_Smhr_PensionQrtrs.QRTR_QRTR1SDATE = (DateTime)rd1.SelectedDate;
                        _obj_Smhr_PensionQrtrs.QRTR_QRTR1EDATE = (DateTime)rd2.SelectedDate;
                        if (_obj_Smhr_PensionQrtrs.QRTR_QRTR1EDATE < _obj_Smhr_PensionQrtrs.QRTR_QRTR1SDATE)
                        {
                            BLL.ShowMessage(this, "Quarter1 End Date Should be Greater than Quarter1 Start Date");
                            return;
                        }
                        break;
                    case "2":

                        _obj_Smhr_PensionQrtrs.QRTR_QRTR2SDATE = (DateTime)rd1.SelectedDate;
                        _obj_Smhr_PensionQrtrs.QRTR_QRTR2EDATE = (DateTime)rd2.SelectedDate;
                        if (_obj_Smhr_PensionQrtrs.QRTR_QRTR2EDATE < _obj_Smhr_PensionQrtrs.QRTR_QRTR2SDATE)
                        {
                            BLL.ShowMessage(this, "Quarter2 End Date Should be Greater than Quarter2 Start Date");
                            return;
                        }
                        if (_obj_Smhr_PensionQrtrs.QRTR_QRTR2SDATE < _obj_Smhr_PensionQrtrs.QRTR_QRTR1EDATE)
                        {
                            BLL.ShowMessage(this, "Quarter2 Start Date Should be Greater than Quarter1 end Date");
                            return;
                        }
                        break;
                    case "3":
                        _obj_Smhr_PensionQrtrs.QRTR_QRTR3SDATE = (DateTime)rd1.SelectedDate;
                        _obj_Smhr_PensionQrtrs.QRTR_QRTR3EDATE = (DateTime)rd2.SelectedDate;
                        if (_obj_Smhr_PensionQrtrs.QRTR_QRTR3EDATE < _obj_Smhr_PensionQrtrs.QRTR_QRTR3SDATE)
                        {
                            BLL.ShowMessage(this, "Quarter3 End Date Should be Greater than Quarter3 Start Date");
                            return;
                        }
                        if (_obj_Smhr_PensionQrtrs.QRTR_QRTR3SDATE < _obj_Smhr_PensionQrtrs.QRTR_QRTR2EDATE)
                        {
                            BLL.ShowMessage(this, "Quarter3 Start Date Should be Greater than Quarter2 end Date");
                            return;
                        }
                        break;
                    case "4":
                        _obj_Smhr_PensionQrtrs.QRTR_QRTR4SDATE = (DateTime)rd1.SelectedDate;
                        _obj_Smhr_PensionQrtrs.QRTR_QRTR4EDATE = (DateTime)rd2.SelectedDate;
                        if (_obj_Smhr_PensionQrtrs.QRTR_QRTR4EDATE < _obj_Smhr_PensionQrtrs.QRTR_QRTR4SDATE)
                        {
                            BLL.ShowMessage(this, "Quarter4 End Date Should be Greater than Quarter4 Start Date");
                            return;
                        }
                        if (_obj_Smhr_PensionQrtrs.QRTR_QRTR4SDATE < _obj_Smhr_PensionQrtrs.QRTR_QRTR3EDATE)
                        {
                            BLL.ShowMessage(this, "Quarter4 Start Date Should be Greater than Quarter3 end Date");
                            return;
                        }
                        break;

                }
            }
            switch (radQuarters.SelectedItem.Value)
            {
                case "1":
                    if (Convert.ToDateTime(hdnEndDate.Value) != _obj_Smhr_PensionQrtrs.QRTR_QRTR1EDATE)
                    {
                        BLL.ShowMessage(this, "Quarter1 End Date Should be equal to  Financial period end Date");
                        return;
                    }
                    break;
                case "2":
                    if (Convert.ToDateTime(hdnEndDate.Value) != _obj_Smhr_PensionQrtrs.QRTR_QRTR2EDATE)
                    {
                        BLL.ShowMessage(this, "Quarter2 End Date Should be equal to  Financial period end Date");
                        return;
                    }
                    break;
                case "3":
                    if (Convert.ToDateTime(hdnEndDate.Value) != _obj_Smhr_PensionQrtrs.QRTR_QRTR3EDATE)
                    {
                        BLL.ShowMessage(this, "Quarter3 End Date Should be equal to  Financial period end Date");
                        return;
                    }
                    break;
                case "4":
                    if (Convert.ToDateTime(hdnEndDate.Value) != _obj_Smhr_PensionQrtrs.QRTR_QRTR4EDATE)
                    {
                        BLL.ShowMessage(this, "Quarter4 End Date Should be equal to  Financial period end Date");
                        return;
                    }
                    break;
            }


            _obj_Smhr_PensionQrtrs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_PensionQrtrs.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_PensionQrtrs.CREATEDDATE = DateTime.Now;
            _obj_Smhr_PensionQrtrs.LASTMDFDATE = DateTime.Now;
            _obj_Smhr_PensionQrtrs.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);


            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Smhr_PensionQrtrs.QRTR_ID = Convert.ToInt32(lblID.Text);
                    _obj_Smhr_PensionQrtrs.OPERATION = operation.Update;
                    if (BLL.set_PensionQuarters(_obj_Smhr_PensionQrtrs))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    break;
                case "BTN_SAVE":

                    _obj_Smhr_PensionQrtrs.OPERATION = operation.Insert;
                    if (BLL.set_PensionQuarters(_obj_Smhr_PensionQrtrs))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_CY_page.SelectedIndex = 0;
            LoadGrid();
            Rg_InteretsQuarters.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddQuarters", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    protected void radQuarters_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (Convert.ToInt32(radQuarters.SelectedItem.Value) > 0)
            {
                if (string.Compare(radFinPeriod.SelectedItem.Text, "Select", true) != 0)
                {
                    DataTable dt = GetDataTable();
                    int noOfQuarters = Convert.ToInt32(radQuarters.SelectedItem.Value);
                    for (int i = 1; i <= noOfQuarters; i++)
                    {
                        dt.Rows.Add(i, "Quarter " + i.ToString(), Convert.ToDateTime(hdnStartDate.Value), Convert.ToDateTime(hdnEndDate.Value), null, null);
                    }
                    btn_Save.Visible = true;
                    Rg_Quarters.Visible = true;
                    Rg_Quarters.Enabled = true;
                    Rg_Quarters.DataSource = dt;
                    Rg_Quarters.DataBind();
                }
                else
                {
                    btn_Save.Visible = false;
                    Rg_Quarters.Visible = false;
                    radQuarters.ClearSelection();
                    BLL.ShowMessage(this, "Please select Financial Period");
                    return;
                }
            }
            else
            {
                btn_Save.Visible = false;
                Rg_Quarters.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddQuarters", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private DataTable GetDataTable()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add("QUARTER_ID", typeof(int));
            dt.Columns.Add("QUARTER_NAME", typeof(string));
            dt.Columns.Add("QUARTER_SDATE", typeof(DateTime));
            dt.Columns.Add("QUARTER_EDATE", typeof(DateTime));
            dt.Columns.Add("QUARTER_SSDATE", typeof(DateTime));
            dt.Columns.Add("QUARTER_SEDATE", typeof(DateTime));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddQuarters", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
    }
    protected void radFinPeriod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            Rg_Quarters.Visible = false;
            btn_Save.Visible = false;
            if (string.Compare(radFinPeriod.SelectedItem.Text, "Select", true) != 0)
            {
                SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
                DataTable dt_Details = new DataTable();
                _obj_smhr_period.OPERATION = operation.Select;
                _obj_smhr_period.PERIOD_ID = Convert.ToInt32(radFinPeriod.SelectedItem.Value);
                _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
                hdnStartDate.Value = dt_Details.Rows[0]["PERIOD_STARTDATE"].ToString();
                hdnEndDate.Value = dt_Details.Rows[0]["PERIOD_ENDDATE"].ToString();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddQuarters", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void BindFinancialPeriod()
    {
        try
        {

            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
            DataTable dt_Details = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);

            radFinPeriod.DataSource = dt_Details;//.Select("PERIOD_ID not in ('198')");
            radFinPeriod.DataValueField = "PERIOD_ID";
            radFinPeriod.DataTextField = "PERIOD_NAME";
            radFinPeriod.DataBind();
            radFinPeriod.Items.Insert(0, new RadComboBoxItem("Select", "-1"));


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddQuarters", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void clearControls()
    {
        try
        {
            //  lbl_MedicalClaimID.Text = string.Empty;

            //radPensionIDNo.Text = string.Empty;

            // BU1.ClearControls();

            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_CY_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddQuarters", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddQuarters", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_InteretsQuarters_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AddQuarters", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}

