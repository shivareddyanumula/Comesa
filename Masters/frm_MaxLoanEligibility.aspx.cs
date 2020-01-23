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

public partial class Masters_frm_MaxLoanEligibility : System.Web.UI.Page
{
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Loan Max Eligible");//COUNTRY");
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
                    Rg_MedicalBenifit.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                BindLoanTypes();
                Page.Validate();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MaxLoanEligibility", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void BindLoanTypes()
    {
        try
        {
            SMHR_LOANELIGIBLEAMOUNT _obj_Smhr_loan = new SMHR_LOANELIGIBLEAMOUNT();
            _obj_Smhr_loan.OPERATION = operation.Check;
            _obj_Smhr_loan.OrgID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_LoanMaxEligibleAmount(_obj_Smhr_loan);
            rad_TypeOfLoan.DataSource = dt;
            rad_TypeOfLoan.DataValueField = "PAYITEM_ID";
            rad_TypeOfLoan.DataTextField = "PAYITEM_PAYITEMNAME";
            rad_TypeOfLoan.DataBind();
            rad_TypeOfLoan.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MaxLoanEligibility", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MaxLoanEligibility", ex.StackTrace, DateTime.Now);
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
            rad_TypeOfLoan.Items.Clear();
            rad_TypeOfLoan.ClearSelection();
            rad_TypeOfLoan.Text = string.Empty;
            BindLoanTypes();
            RadGrid1.DataSource = null;
            RadGrid1.DataBind();
            RadGrid1.Visible = false;

            rad_TypeOfLoan.Enabled = true;
            btn_Save.Visible = true;
            trExpend.Visible = true;
            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MaxLoanEligibility", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void clearControls()
    {

    }

    protected void Rg_MedicalBenifit_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MaxLoanEligibility", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void LoadGrid()
    {
        try
        {
            SMHR_LOANELIGIBLEAMOUNT smhr_LoanAmount = new SMHR_LOANELIGIBLEAMOUNT();
            smhr_LoanAmount.OPERATION = operation.Select;
            smhr_LoanAmount.OrgID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_LoanMaxEligibleAmount(smhr_LoanAmount);
            Rg_MedicalBenifit.DataSource = DT;

            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MaxLoanEligibility", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void radFinPeriod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (radFinPeriod.SelectedIndex > 0 && rad_TypeOfLoan.SelectedIndex > 0)
            {
                BindLoanGrid();
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MaxLoanEligibility", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void BindLoanGrid()
    {
        try
        {
            RadGrid1.Visible = true;
            SMHR_LOANELIGIBLEAMOUNT smhr_LoanAmount = new SMHR_LOANELIGIBLEAMOUNT();
            smhr_LoanAmount.OPERATION = operation.Get;
            smhr_LoanAmount.OrgID = Convert.ToInt32(Session["ORG_ID"]);
            smhr_LoanAmount.LoanID = Convert.ToInt32(rad_TypeOfLoan.SelectedValue);
            smhr_LoanAmount.FinancialPeriodID = Convert.ToInt32(radFinPeriod.SelectedValue);
            DataTable dt = BLL.get_LoanMaxEligibleAmount(smhr_LoanAmount);
            SMHR_PERIOD osmhr_period = new SMHR_PERIOD();
            osmhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            osmhr_period.PERIOD_ID = Convert.ToInt32(radFinPeriod.SelectedValue);
            DataTable dtCurrentFinPeriod = BLL.IscurrentFinPeriod(osmhr_period);

            if (string.Compare(dtCurrentFinPeriod.Rows[0]["ISEXISTS"].ToString(), "0", true) == 0)
            {
                RadGrid1.Enabled = false;
                btn_Save.Visible = false;
            }
            else
            {
                RadGrid1.Enabled = true;
                btn_Save.Visible = true;
            }
            RadGrid1.DataSource = dt;
            RadGrid1.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MaxLoanEligibility", ex.StackTrace, DateTime.Now);
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
            SMHR_LOANELIGIBLEAMOUNT smhr_LoanAmount = new SMHR_LOANELIGIBLEAMOUNT();
            smhr_LoanAmount.OrgID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtGadeWiseAMount = GetGadeWiseAMount();
            smhr_LoanAmount.GradeWiseAmount = dtGadeWiseAMount;
            smhr_LoanAmount.FinancialPeriodID = Convert.ToInt32(radFinPeriod.SelectedValue);
            smhr_LoanAmount.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            smhr_LoanAmount.CREATEDDATE = DateTime.Now;
            smhr_LoanAmount.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            smhr_LoanAmount.LASTMDFDATE = DateTime.Now;
            switch (((Button)sender).ID.ToUpper())
            {

                case "BTN_SAVE":
                    smhr_LoanAmount.LoanID = Convert.ToInt32(rad_TypeOfLoan.SelectedValue);
                    smhr_LoanAmount.OPERATION = operation.Insert;
                    if (BLL.set_LoanMaxEligibleAmount(smhr_LoanAmount))
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MaxLoanEligibility", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_TypeOfLoan_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rad_TypeOfLoan.SelectedIndex > 0)
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MaxLoanEligibility", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MaxLoanEligibility", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_CY_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MaxLoanEligibility", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            BindFinancialPeriod();
            //BindLoanTypes();
            rad_TypeOfLoan.Enabled = false;
            RadGrid1.Visible = true;
            SMHR_LOANELIGIBLEAMOUNT smhr_LoanAmount = new SMHR_LOANELIGIBLEAMOUNT();
            smhr_LoanAmount.OPERATION = operation.Get;
            smhr_LoanAmount.OrgID = Convert.ToInt32(Session["ORG_ID"]);
            smhr_LoanAmount.LoanID = Convert.ToInt32(e.CommandArgument);
            DataTable dt = BLL.get_LoanMaxEligibleAmount(smhr_LoanAmount);
            RadGrid1.DataSource = dt;
            RadGrid1.DataBind();
            if (dt.Rows.Count > 0)
            {
                SMHR_PAYITEMS _obj_Smhr_BusinessUnit = new SMHR_PAYITEMS();
                _obj_Smhr_BusinessUnit.OPERATION = operation.Check2;
                _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt1 = BLL.get_PayItems(_obj_Smhr_BusinessUnit);
                rad_TypeOfLoan.DataSource = dt1;
                rad_TypeOfLoan.DataValueField = "PAYITEM_ID";
                rad_TypeOfLoan.DataTextField = "PAYITEM_PAYITEMNAME";
                rad_TypeOfLoan.DataBind();
                rad_TypeOfLoan.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
                rad_TypeOfLoan.SelectedIndex = rad_TypeOfLoan.FindItemIndexByValue(smhr_LoanAmount.LoanID.ToString());
                radFinPeriod.SelectedIndex = radFinPeriod.FindItemIndexByValue(dt.Rows[0]["LOANELIGIBLEAMOUNT_FIN_PERIOD_ID"].ToString());
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
            lbl_ExpenditureID.Text = smhr_LoanAmount.LoanID.ToString();
            // rad_ExpenditureName.Text = Convert.ToString(dt.Rows[0]["EXPENDITURE_NAME"]);
            //  rad_ExpenditureName.Enabled = false;
            // rtxt_ExpenditureDesc.Text = Convert.ToString(dt.Rows[0]["EXPENDITURE_DESC"]);
            btn_Save.Visible = true;
            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MaxLoanEligibility", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}