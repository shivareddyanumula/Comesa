using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;

public partial class Pension_TaxationMaster : System.Web.UI.Page
{
    SMHR_TAXATIONMASTER _obj_smhr_TaxationMaster;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("TaxationMaster");
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
                    return;
                }


                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    RG_TaxationSlab.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    //btn_Update.Visible = false;
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
                    return;
                }
                BindFinancialPeriod();
                btn_Save.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TaxationMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private DataTable GetEmptyDT()
    {
        DataTable dt = CreateGridDataTable();
        try
        {
            dt.Rows.Add(1, "First", "", "");
            dt.Rows.Add(2, "Second", "", "");
            dt.Rows.Add(3, "Third", "", "");
            dt.Rows.Add(4, "Fourth", "", "");
            dt.Rows.Add(5, "Remaining Amount", "", "");
            //dt.Rows.Add(5, "Fifth", "", "");
            //dt.Rows.Add(6, "Remaining Amount", "", "");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TaxationMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
    }
    private DataTable CreateGridDataTable()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add("TAXATIONMASTER_SLAB_ID", typeof(int));
            dt.Columns.Add("TAXATIONMASTER_SLAB_NAME", typeof(string));
            dt.Columns.Add("TAXATIONMASTER_SLAB_AMOUNT", typeof(string));
            dt.Columns.Add("TAXATIONMASTER_SLAB_PER", typeof(string));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TaxationMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
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
            //hdnStartDate.Value = dt_Details.Rows[0]["PERIOD_STARTDATE"].ToString();
            //hdnEndDate.Value = dt_Details.Rows[0]["PERIOD_ENDDATE"].ToString();
            rcb_FinancialPeriod.DataSource = dt_Details;
            rcb_FinancialPeriod.DataValueField = "PERIOD_ID";
            rcb_FinancialPeriod.DataTextField = "PERIOD_NAME";
            rcb_FinancialPeriod.DataBind();
            rcb_FinancialPeriod.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TaxationMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcb_FinancialPeriod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcb_FinancialPeriod.SelectedIndex > 0)
            {
                btn_Save.Visible = true;
                _obj_smhr_TaxationMaster = new SMHR_TAXATIONMASTER();
                _obj_smhr_TaxationMaster.OPERATION = operation.Get;
                _obj_smhr_TaxationMaster.TAXATIONMASTER_FINPERIOD_ID = Convert.ToInt32(rcb_FinancialPeriod.SelectedValue);
                _obj_smhr_TaxationMaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_TaxationMaster.TAXATIONMASTER_TYPE_ID = Convert.ToInt32(rcb_Taxation.SelectedValue);
                DataTable dt_Details = BLL.get_Taxation(_obj_smhr_TaxationMaster);
                if (dt_Details.Rows.Count > 0)
                {
                    RG_TaxationSlab.Visible = true;
                    RG_TaxationSlab.DataSource = dt_Details;
                    RG_TaxationSlab.DataBind();
                    SMHR_PERIOD osmhr_period = new SMHR_PERIOD();
                    osmhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    osmhr_period.PERIOD_ID = Convert.ToInt32(rcb_FinancialPeriod.SelectedValue);
                    DataTable dtCurrentFinPeriod = BLL.IscurrentFinPeriod(osmhr_period);
                    if (string.Compare(dtCurrentFinPeriod.Rows[0]["ISEXISTS"].ToString(), "0", true) == 0)
                    {
                        RG_TaxationSlab.Enabled = false;
                        btn_Save.Visible = false;
                    }
                    else
                    {
                        RG_TaxationSlab.Enabled = Convert.ToBoolean(dt_Details.Rows[0]["ISEnable"]); ;
                        btn_Save.Visible = Convert.ToBoolean(dt_Details.Rows[0]["ISEnable"]); ;
                    }
                }
                else
                {
                    RG_TaxationSlab.Visible = true;
                    RG_TaxationSlab.DataSource = GetEmptyDT();
                    RG_TaxationSlab.DataBind();
                    RG_TaxationSlab.Enabled = true;
                    btn_Save.Visible = true;
                }
            }
            else
            {

                RG_TaxationSlab.Visible = false;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TaxationMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {

            _obj_smhr_TaxationMaster = new SMHR_TAXATIONMASTER();
            DataTable dt = CreateGridDataTable();
            RadNumericTextBox rnAmnt, rnPer;
            foreach (GridDataItem g in RG_TaxationSlab.Items)
            {
                rnAmnt = rnPer = new RadNumericTextBox();
                rnAmnt = g.FindControl("txt_SlabAmount") as RadNumericTextBox;
                rnPer = g.FindControl("txt_Percentage") as RadNumericTextBox;
                dt.Rows.Add(Convert.ToInt32(g.Cells[2].Text), g.Cells[3].Text, rnAmnt.Text, rnPer.Text);
            }
            _obj_smhr_TaxationMaster.TAXATIONMASTER_FINPERIOD_ID = Convert.ToInt32(rcb_FinancialPeriod.SelectedItem.Value);
            _obj_smhr_TaxationMaster.TAXATIONMASTER_TYPE_ID = Convert.ToInt32(rcb_Taxation.SelectedItem.Value);
            _obj_smhr_TaxationMaster.TAXATIONMASTER_TYPE_NAME = rcb_Taxation.SelectedItem.Text;
            _obj_smhr_TaxationMaster.TAXATIONDATA = dt;
            _obj_smhr_TaxationMaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_TaxationMaster.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_TaxationMaster.CREATEDDATE = DateTime.Now;
            _obj_smhr_TaxationMaster.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_TaxationMaster.LASTMDFDATE = DateTime.Now;
            _obj_smhr_TaxationMaster.OPERATION = operation.Insert;
            if (BLL.set_Taxation(_obj_smhr_TaxationMaster))
                BLL.ShowMessage(this, "Information Saved Successfully");
            else
                BLL.ShowMessage(this, "Information Not Saved");

            rcb_FinancialPeriod.ClearSelection();
            rcb_Taxation.ClearSelection();
            RG_TaxationSlab.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TaxationMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcb_FinancialPeriod.ClearSelection();
            rcb_Taxation.ClearSelection();
            RG_TaxationSlab.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TaxationMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcb_Taxation_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcb_FinancialPeriod.SelectedIndex = 0;
            btn_Save.Visible = false;
            RG_TaxationSlab.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TaxationMaster", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}