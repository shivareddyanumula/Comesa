using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Payroll_frm_IncrementCycle : System.Web.UI.Page
{
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {


                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Increment Cycle");//COUNTRY");
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
                    Rg_IncrementCycle.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
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
                Rg_IncrementCycle.DataSource = BindIncrementCycleGrid();
                Rg_IncrementCycle.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncrementCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private DataTable BindIncrementCycleGrid()
    {
        SMHR_INCREMENTCYCLE _obj_IncrementCycle = new SMHR_INCREMENTCYCLE();
        try
        {
            _obj_IncrementCycle.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_IncrementCycle.OPERATION = operation.Select;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncrementCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return BLL.Get_FinancialPeriodDetails(_obj_IncrementCycle);
    }
    protected void Rg_IncrementCycle_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            Rg_IncrementCycle.DataSource = BindIncrementCycleGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncrementCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();

            rcmb_FinPeriod.Enabled = false;
            rcmb_Cycles.Enabled = false;
            btn_Generate.Enabled = false;
            btn_Save.Enabled = false;
            rg_FinCycles.Enabled = false;

            LoadFinancialPeriodCombos("Edit");

            LinkButton lnkEdit = sender as LinkButton;
            GridDataItem item = lnkEdit.NamingContainer as GridDataItem;

            rcmb_FinPeriod.SelectedValue = e.CommandArgument.ToString();
            if (item["INCREMENTCYCLE_MONTH"].Text != "&nbsp;")
            {
                rcmb_Cycles.SelectedValue = item["INCREMENTCYCLE_MONTH"].Text;
                //btnGenerate_Click(null, null);
                tr_GenerateCycles.Visible = true;

                SMHR_INCREMENTCYCLE _obj_IncrementCycle = new SMHR_INCREMENTCYCLE();
                _obj_IncrementCycle.INCREMENTCYCLE_PERIODID = Convert.ToInt32(rcmb_FinPeriod.SelectedValue);
                _obj_IncrementCycle.INCREMENTCYCLE_MONTH = rcmb_Cycles.SelectedValue;
                _obj_IncrementCycle.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_IncrementCycle.OPERATION = operation.IncrementCycles;
                DataTable dtFinPeriodData = BLL.Get_FinancialPeriodDetails(_obj_IncrementCycle);

                rg_FinCycles.DataSource = dtFinPeriodData;
                rg_FinCycles.DataBind();
            }

            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncrementCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();
            LoadFinancialPeriodCombos("Add");

            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncrementCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void ClearControls()
    {
        try
        {
            tr_GenerateCycles.Visible = false;
            rcmb_FinPeriod.Enabled = true;
            rcmb_FinPeriod.SelectedIndex = -1;
            rcmb_Cycles.Enabled = true;
            rcmb_Cycles.SelectedIndex = -1;

            rcmb_FinPeriod.Enabled = true;
            rcmb_Cycles.Enabled = true;
            btn_Generate.Enabled = true;
            btn_Save.Enabled = true;
            rg_FinCycles.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncrementCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_INCREMENTCYCLE _obj_IncrementCycle = new SMHR_INCREMENTCYCLE();
            _obj_IncrementCycle.INCREMENTCYCLE_PERIODID = Convert.ToInt32(rcmb_FinPeriod.SelectedValue);
            _obj_IncrementCycle.INCREMENTCYCLE_MONTH = rcmb_Cycles.SelectedValue;
            _obj_IncrementCycle.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_IncrementCycle.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_IncrementCycle.CREATEDDATE = DateTime.Now;

            RadNumericTextBox rtxt_SlabAmountGrid = new RadNumericTextBox();
            DataTable dtIncrementCycles = new DataTable();
            dtIncrementCycles.Columns.Add("PERIODID", typeof(int));
            dtIncrementCycles.Columns.Add("STARTMONTH", typeof(string));
            dtIncrementCycles.Columns.Add("ENDMONTH", typeof(string));
            dtIncrementCycles.Columns.Add("INCREMENTCYCLE_SRNO", typeof(string));
            dtIncrementCycles.Columns.Add("STARTMONTH_ID", typeof(int));
            dtIncrementCycles.Columns.Add("ENDMONTH_ID", typeof(int));

            for (int index = 0; index <= rg_FinCycles.Items.Count - 1; index++)
            {
                int PERIODID = rg_FinCycles.Items[index]["PERIODID"].Text != "&nbsp;" ? Convert.ToInt32(rg_FinCycles.Items[index]["PERIODID"].Text) : 0;
                string StartMonth = rg_FinCycles.Items[index]["StartMonth"].Text != "&nbsp;" ? rg_FinCycles.Items[index]["StartMonth"].Text : string.Empty;
                string EndMonth = rg_FinCycles.Items[index]["EndMonth"].Text != "&nbsp;" ? rg_FinCycles.Items[index]["EndMonth"].Text : string.Empty;
                string SRNO = rg_FinCycles.Items[index]["SRNO"].Text != "&nbsp;" ? rg_FinCycles.Items[index]["SRNO"].Text : string.Empty;
                int STARTMONTH_ID = rg_FinCycles.Items[index]["STARTMONTH_ID"].Text != "&nbsp;" ? Convert.ToInt32(rg_FinCycles.Items[index]["STARTMONTH_ID"].Text) : 0;
                int ENDMONTH_ID = rg_FinCycles.Items[index]["ENDMONTH_ID"].Text != "&nbsp;" ? Convert.ToInt32(rg_FinCycles.Items[index]["ENDMONTH_ID"].Text) : 0;

                dtIncrementCycles.Rows.Add(PERIODID, StartMonth, EndMonth, SRNO, STARTMONTH_ID, ENDMONTH_ID);
            }
            _obj_IncrementCycle.TBLINCREMENTCYCLES = dtIncrementCycles;
            if (BLL.Insert_IncrementCycles(_obj_IncrementCycle))
                BLL.ShowMessage(this, "Increment Cycles Saved Successfully");
            else
                BLL.ShowMessage(this, "Increment Cycles Failed");


            Rm_CY_page.SelectedIndex = 0;
            Rg_IncrementCycle.DataSource = BindIncrementCycleGrid();
            Rg_IncrementCycle.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncrementCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_CY_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncrementCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            tr_GenerateCycles.Visible = true;

            SMHR_INCREMENTCYCLE _obj_IncrementCycle = new SMHR_INCREMENTCYCLE();
            _obj_IncrementCycle.INCREMENTCYCLE_PERIODID = Convert.ToInt32(rcmb_FinPeriod.SelectedValue);
            _obj_IncrementCycle.INCREMENTCYCLE_MONTH = rcmb_Cycles.SelectedValue;
            _obj_IncrementCycle.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_IncrementCycle.OPERATION = operation.Get;
            DataTable dtFinPeriodData = BLL.Get_FinancialPeriodDetails(_obj_IncrementCycle);

            ViewState["FinCycles"] = dtFinPeriodData;
            rg_FinCycles.DataSource = dtFinPeriodData;
            rg_FinCycles.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncrementCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    private void LoadFinancialPeriodCombos(string DataFlag)
    {
        try
        {
            DataTable dtData = new DataTable();
            if (DataFlag == "Edit")
                dtData = BLL.Get_FinancialPeriodDetails(new SMHR_INCREMENTCYCLE { OPERATION = operation.FINANCIALPERIODSINCLUDED, ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]), INCREMENTCYCLE_PERIODID = 0 });
            else if (DataFlag == "Add")
                dtData = BLL.Get_FinancialPeriodDetails(new SMHR_INCREMENTCYCLE { OPERATION = operation.FINANCIALPERIODSEXCLUDED, ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]), INCREMENTCYCLE_PERIODID = 0 });

            rcmb_FinPeriod.DataSource = dtData;
            rcmb_FinPeriod.DataBind();
            rcmb_FinPeriod.Items.Insert(0, new RadComboBoxItem { Text = "Select", Value = "0" });
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncrementCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rg_FinCycles_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            DataTable dtFinCycles = (DataTable)ViewState["FinCycles"];
            rg_FinCycles.DataSource = dtFinCycles;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncrementCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_GenerateCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_CY_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncrementCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_FinPeriod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_Cycles.SelectedIndex = -1;
            rg_FinCycles.DataSource = new DataTable();
            rg_FinCycles.DataBind();
            tr_GenerateCycles.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_IncrementCycle", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}