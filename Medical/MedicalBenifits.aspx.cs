using SMHR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Medical_MedicalBenifits : System.Web.UI.Page
{
    string strfilename2;
    DataSet ds = new DataSet();
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    SMHR_MEDICALBENFIT smhr_MedicalBenfit;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Medical Benifits");//COUNTRY");
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
                }



                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    Rg_MedicalBenifit.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                //BindFinancialPeriod();
                Page.Validate();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenifits", ex.StackTrace, DateTime.Now);
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
            radFinPeriod.DataSource = dt_Details;
            radFinPeriod.DataValueField = "PERIOD_ID";
            radFinPeriod.DataTextField = "PERIOD_NAME";
            radFinPeriod.DataBind();
            radFinPeriod.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenifits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            int finPrdID = Convert.ToInt32(e.CommandArgument);
            lbl_ExpenditureID.Text = finPrdID.ToString();
            int count = 0;
            clearControls();
            BindFinancialPeriod();
            BindExpenditureNames();
            rad_ExpenditureName.Enabled = false;
            RadGrid1.Visible = true;
            smhr_MedicalBenfit = new SMHR_MEDICALBENFIT();
            smhr_MedicalBenfit.OPERATION = operation.Get;
            smhr_MedicalBenfit.OrgID = Convert.ToInt32(Session["ORG_ID"]);
            //smhr_MedicalBenfit.ExpendID = lbl_ExpenditureID.Text;
            smhr_MedicalBenfit.FinancialPeriodID = finPrdID;
            DataTable dt = BLL.get_MedicalBenfit(smhr_MedicalBenfit);
            RadGrid1.DataSource = dt;
            RadGrid1.DataBind();
            if (dt.Rows.Count > 0)
            {
                SMHR_EXPENDITURE _obj_Smhr_Expenditure = new SMHR_EXPENDITURE();
                _obj_Smhr_Expenditure.OPERATION = operation.Select;
                _obj_Smhr_Expenditure.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                /*rad_ExpenditureName.DataSource = BLL.get_Expenditure(_obj_Smhr_Expenditure);
                rad_ExpenditureName.DataValueField = "EXPENDITURE_ID";
                rad_ExpenditureName.DataTextField = "EXPENDITURE_NAME";
                rad_ExpenditureName.DataBind();
                rad_ExpenditureName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                rad_ExpenditureName.SelectedIndex = rad_ExpenditureName.FindItemIndexByValue(smhr_MedicalBenfit.ExpendID.ToString());*/
                radFinPeriod.SelectedIndex = radFinPeriod.FindItemIndexByValue(dt.Rows[0]["MEDICALBENFIT_FIN_PERIOD_ID"].ToString());
            }
            SMHR_PERIOD osmhr_period = new SMHR_PERIOD();
            osmhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            osmhr_period.PERIOD_ID = Convert.ToInt32(radFinPeriod.SelectedValue);
            DataTable dtCurrentFinPeriod = BLL.IscurrentFinPeriod(osmhr_period);

            if (string.Compare(dtCurrentFinPeriod.Rows[0]["ISEXISTS"].ToString(), "0", true) == 0)
                RadGrid1.Enabled = false;
            else
                RadGrid1.Enabled = true;
            // trExpend.Visible = false;

            // rad_ExpenditureName.Text = Convert.ToString(dt.Rows[0]["EXPENDITURE_NAME"]);
            //  rad_ExpenditureName.Enabled = false;
            // rtxt_ExpenditureDesc.Text = Convert.ToString(dt.Rows[0]["EXPENDITURE_DESC"]);
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;
            }
            else
            {
                btn_Update.Visible = true;
            }
            Rm_CY_page.SelectedIndex = 1;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dt.Rows[i]["MEDICAL_ADDED"]) == false)
                    count++;
            }
            if (count > 0)
                RadGrid1.MasterTableView.Columns[3].Visible = false;
            else
                RadGrid1.MasterTableView.Columns[3].Visible = true;
            radFinPeriod.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenifits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            radFinPeriod.Items.Clear();
            radFinPeriod.ClearSelection();
            radFinPeriod.Text = string.Empty;
            //BindExpenditureNames();
            BindFinancialPeriod();
            RadGrid1.DataSource = null;
            RadGrid1.DataBind();
            RadGrid1.Visible = false;
            rad_ExpenditureName.Enabled = true;
            radFinPeriod.Enabled = true;
            btn_Save.Visible = true;
            //trExpend.Visible = true;
            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenifits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void BindExpenditureNames()
    {
        try
        {
            SMHR_EXPENDITURE _obj_Smhr_Expenditure = new SMHR_EXPENDITURE();
            _obj_Smhr_Expenditure.OPERATION = operation.Select2;
            _obj_Smhr_Expenditure.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_Expenditure(_obj_Smhr_Expenditure);
            rad_ExpenditureName.DataSource = dt;
            rad_ExpenditureName.DataValueField = "EXPENDITURE_ID";
            rad_ExpenditureName.DataTextField = "EXPENDITURE_NAME";
            rad_ExpenditureName.DataBind();
            rad_ExpenditureName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenifits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            smhr_MedicalBenfit = new SMHR_MEDICALBENFIT();
            smhr_MedicalBenfit.OPERATION = operation.Select;
            smhr_MedicalBenfit.OrgID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_MedicalBenfit(smhr_MedicalBenfit);
            Rg_MedicalBenifit.DataSource = DT;

            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenifits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (radFinPeriod.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Financial Period");
                return;
            }
            smhr_MedicalBenfit = new SMHR_MEDICALBENFIT();
            smhr_MedicalBenfit.OrgID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtGadeWiseAMount = GetGadeWiseAMount();
            smhr_MedicalBenfit.GradeWiseAmount = dtGadeWiseAMount;
            smhr_MedicalBenfit.FinancialPeriodID = Convert.ToInt32(radFinPeriod.SelectedValue);
            smhr_MedicalBenfit.MEDICALBENFIT_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            smhr_MedicalBenfit.MEDICALBENFIT_CREATEDDATE = DateTime.Now;
            smhr_MedicalBenfit.MEDICALBENFIT_MDFBY = Convert.ToInt32(Session["USER_ID"]);
            smhr_MedicalBenfit.MEDICALBENFIT_MDFDATE = DateTime.Now;
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    //smhr_MedicalBenfit.ExpendID = Convert.ToInt32(lbl_ExpenditureID.Text);
                    smhr_MedicalBenfit.OPERATION = operation.Insert;
                    if (BLL.set_MedicalBenfit(smhr_MedicalBenfit))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");



                    break;
                case "BTN_SAVE":
                    //smhr_MedicalBenfit.ExpendID = Convert.ToInt32(rad_ExpenditureName.SelectedValue);
                    smhr_MedicalBenfit.OPERATION = operation.Insert;
                    if (BLL.set_MedicalBenfit(smhr_MedicalBenfit))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_CY_page.SelectedIndex = 0;
            LoadGrid();
            Rg_MedicalBenifit.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenifits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private DataTable GetGadeWiseAMount()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add("EMPLOYEEGRADE_ID", typeof(string));
            dt.Columns.Add("MEDICALBENFIT_MAXAMOUNT", typeof(string));
            Label lID; RadNumericTextBox tAmount;
            foreach (GridDataItem d in RadGrid1.Items)
            {
                lID = new Label();
                tAmount = new RadNumericTextBox();
                lID = d.FindControl("lbl_EMPLOYEEGRADE_ID") as Label;
                tAmount = d.FindControl("txt_MEDICALBENFIT_MAXAMOUNT") as RadNumericTextBox;

                dt.Rows.Add(lID.Text, tAmount.Text);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenifits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
    }

    protected void clearControls()
    {
        try
        {
            lbl_ExpenditureID.Text = string.Empty;
            rad_ExpenditureName.Text = string.Empty;
            radFinPeriod.Text = string.Empty;
            // rtxt_ExpenditureDesc.Text = string.Empty;
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_CY_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenifits", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenifits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_MedicalBenifit_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenifits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void radFinPeriod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (radFinPeriod.SelectedIndex > 0)
            {
                BindMedicalGrid();
                //lnk_Edit_Command(o, e);
            }
            else
            {
                RadGrid1.Visible = false;
                RadGrid1.DataSource = null;
                RadGrid1.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenifits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void BindMedicalGrid()
    {
        try
        {
            int count = 0;
            RadGrid1.Visible = true;
            smhr_MedicalBenfit = new SMHR_MEDICALBENFIT();
            smhr_MedicalBenfit.OPERATION = operation.Get;
            smhr_MedicalBenfit.OrgID = Convert.ToInt32(Session["ORG_ID"]);
            //smhr_MedicalBenfit.ExpendID = Convert.ToInt32(rad_ExpenditureName.SelectedValue);
            smhr_MedicalBenfit.FinancialPeriodID = Convert.ToInt32(radFinPeriod.SelectedValue);
            DataTable dt = BLL.get_MedicalBenfit(smhr_MedicalBenfit);
            SMHR_PERIOD osmhr_period = new SMHR_PERIOD();
            osmhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            osmhr_period.PERIOD_ID = Convert.ToInt32(radFinPeriod.SelectedValue);
            DataTable dtCurrentFinPeriod = BLL.IscurrentFinPeriod(osmhr_period);

            if (string.Compare(dtCurrentFinPeriod.Rows[0]["ISEXISTS"].ToString(), "0", true) == 0)
            {
                RadGrid1.Enabled = false;
                RadGrid1.MasterTableView.Columns[3].Visible = false;
            }
            else
            {
                RadGrid1.Enabled = true;
                RadGrid1.MasterTableView.Columns[3].Visible = true;
            }
            RadGrid1.DataSource = dt;
            RadGrid1.DataBind();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dt.Rows[i]["medical_added"]) == false)
                {
                    RadGrid1.MasterTableView.Columns[3].Visible = false;
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenifits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_ExpenditureName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rad_ExpenditureName.SelectedIndex > 0)
            {
                BindFinancialPeriod();
            }
            else
            {
                radFinPeriod.Items.Clear();
                radFinPeriod.ClearSelection();
            }
            RadGrid1.Visible = false;
            RadGrid1.DataSource = null;
            RadGrid1.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenifits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    //{
    //    TextBox txt = new TextBox();
    //    txt =(TextBox) e.Item.FindControl("txt_MEDICALBENFIT_MAXAMOUNT");
    //    if (txt != null)
    //    {
    //        if (string.Compare(txt.Text, "0.00", true) == 0 && hdnIsfuture.Value == "0")
    //        {
    //            txt.Enabled = true;
    //        }
    //        else
    //        {
    //            txt.Enabled = false;
    //        }
    //    }
    //}
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkAll = (CheckBox)sender;
            RadNumericTextBox txt_MEDICALBENFIT_MAXAMOUNT;
            RadNumericTextBox amount;
            amount = RadGrid1.Items[0].FindControl("txt_MEDICALBENFIT_MAXAMOUNT") as RadNumericTextBox;

            if (chkAll.Checked)
            {
                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    txt_MEDICALBENFIT_MAXAMOUNT = RadGrid1.Items[i].FindControl("txt_MEDICALBENFIT_MAXAMOUNT") as RadNumericTextBox;
                    txt_MEDICALBENFIT_MAXAMOUNT.Text = amount.Text;
                }
            }
            else
            {
                for (int i = 0; i < RadGrid1.Items.Count; i++)
                {
                    txt_MEDICALBENFIT_MAXAMOUNT = RadGrid1.Items[i].FindControl("txt_MEDICALBENFIT_MAXAMOUNT") as RadNumericTextBox;

                    if (i != 0)
                        txt_MEDICALBENFIT_MAXAMOUNT.Text = "0";
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenifits", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}