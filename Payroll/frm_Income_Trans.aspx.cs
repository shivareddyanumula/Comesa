using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;

public partial class Payroll_frm_Income_Trans : System.Web.UI.Page
{
    SMHR_TAX_TRANS _obj_smhr_tax_trans;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    SMHR_INCOME_TRANS _obj_smhr_income_trans;
    SMHR_PERIOD _obj_smhr_period;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE OTHER INCOME SAVINGS");

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

                    btn_Save.Visible = false;

                    // added to support Only-View functionality.

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
                RG_Employee.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Income_Trans", ex.StackTrace, DateTime.Now);
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
            //To load Business units
            SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcb_BusinessUnit.DataSource = dt_BUDetails;
            rcb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcb_BusinessUnit.DataBind();
            rcb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
            rcb_Employee.Items.Clear();

            //To load Financial Periods
            _obj_smhr_period = new SMHR_PERIOD();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmb_period.DataSource = dt_Details;
            rcmb_period.DataValueField = "PERIOD_ID";
            rcmb_period.DataTextField = "PERIOD_NAME";
            rcmb_period.DataBind();
            rcmb_period.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Income_Trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadEmployees()
    {
        try
        {
            if (rcb_BusinessUnit.SelectedIndex != 0 && rcmb_period.SelectedIndex != 0)
            {
                _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                _obj_smhr_emp_payitems.OPERATION = operation.Empty2;
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcb_BusinessUnit.SelectedValue);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_emp_payitems.PERIOD_ID = Convert.ToInt32(rcmb_period.SelectedItem.Value);
                DataTable dt_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                if (dt_Details.Rows.Count != 0)
                {
                    rcb_Employee.Items.Clear();
                    rcb_Employee.DataSource = dt_Details;
                    rcb_Employee.DataTextField = "Empname";
                    rcb_Employee.DataValueField = "EMP_ID";
                    rcb_Employee.DataBind();
                    rcb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                    RG_Employee.Visible = false;
                    btn_Cancel.Visible = false;
                    btn_Save.Visible = false;
                }
                else
                {
                    rcb_Employee.Items.Clear();
                    rcb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                    RG_Employee.Visible = false;
                    btn_Cancel.Visible = false;
                    btn_Save.Visible = false;
                }
            }
            else
            {
                rcb_Employee.Items.Clear();
                rcb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                rcmb_period.ClearSelection();
                RG_Employee.Visible = false;
                btn_Save.Visible = false;
                btn_Cancel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Income_Trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //LoadEmployees();
            if (rcb_BusinessUnit.SelectedIndex <= 0)
            {
                rcb_Employee.Items.Clear();
                rcb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                rcmb_period.ClearSelection();
                RG_Employee.Visible = false;
                btn_Save.Visible = false;
                btn_Cancel.Visible = false;
            }
            else
            {
                LoadEmployees();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Income_Trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcb_Employee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcb_Employee.SelectedIndex != 0)
            {
                LoadGrid();
                RG_Employee.DataBind();
                RG_Employee.Visible = true;
                btn_Cancel.Visible = true;
                btn_Save.Visible = true;
            }
            else
            {
                RG_Employee.Visible = false;
                btn_Cancel.Visible = false;
                btn_Save.Visible = false;
            }
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Save.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Income_Trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RG_Employee.Visible = false;
            btn_Cancel.Visible = false;
            btn_Save.Visible = false;
            rcb_Employee.Items.Clear();
            //rcb_BusinessUnit.SelectedIndex = 0;
            rcb_BusinessUnit.ClearSelection();
            rcmb_period.ClearSelection();
            rcb_Employee.Items.Insert(0, new RadComboBoxItem("", ""));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Income_Trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            Label lbl_ID = new Label();
            Label lbl_taxName = new Label();
            RadNumericTextBox rntxt_Value = new RadNumericTextBox();
            Label lbl_MaxAmt = new Label();
            //int index = 0;
            //int Counter = 0;

            //for (index = 0; index <= RG_Employee.Items.Count - 1; index++)
            //{
            //    rntxt_Value = RG_Employee.Items[index].FindControl("rntxt_Number") as RadNumericTextBox;
            //    if (rntxt_Value.Value == 0.00)
            //    {
            //        Counter = Counter + 1;
            //    }
            //}

            //if (Counter == RG_Employee.Items.Count)
            //{
            //    BLL.ShowMessage(this, "Please Enter atleast one Exemption Value");
            //    return;
            //}
            //else
            //{
            bool status = false;
            bool status1 = false;
            _obj_smhr_income_trans = new SMHR_INCOME_TRANS();
            _obj_smhr_income_trans.Mode = 4;
            _obj_smhr_income_trans.SMHR_EMPINCOME_EMPID = Convert.ToInt32(rcb_Employee.SelectedValue);
            _obj_smhr_income_trans.SMHR_EMPINCOME_PERIOD = Convert.ToInt32(rcmb_period.SelectedItem.Value);
            DataTable dt = BLL.get_Income_trans(_obj_smhr_income_trans);
            if (dt.Rows.Count != 0)
            {
                _obj_smhr_income_trans = new SMHR_INCOME_TRANS();
                _obj_smhr_income_trans.Mode = 3;
                _obj_smhr_income_trans.SMHR_EMPINCOME_EMPID = Convert.ToInt32(rcb_Employee.SelectedValue);
                _obj_smhr_income_trans.SMHR_EMPINCOME_PERIOD = Convert.ToInt32(rcmb_period.SelectedItem.Value);
                status = BLL.set_Income_Trans(_obj_smhr_income_trans);
                status1 = process();
                if (status1 == true)
                {
                    BLL.ShowMessage(this, "Income Exemptions Added Successfully");
                    RG_Employee.Visible = false;
                    btn_Cancel.Visible = false;
                    btn_Save.Visible = false;
                    rcb_Employee.Items.Clear();
                    rcb_Employee.Items.Insert(0, new RadComboBoxItem("", ""));
                    //rcb_BusinessUnit.SelectedIndex = 0;
                    rcmb_period.ClearSelection();
                    rcb_BusinessUnit.ClearSelection();
                    return;
                }

                else
                {
                    //BLL.ShowMessage(this, "An Error Occured while doing the process");
                    // BLL.ShowMessage(this, "Enter the amount for Income Elements to process");
                    return;
                }
            }
            else
            {
                status1 = process();
                if (status1 == true)
                {
                    BLL.ShowMessage(this, "Income Exemptions Added Successfully");
                    RG_Employee.Visible = false;
                    btn_Cancel.Visible = false;
                    btn_Save.Visible = false;
                    rcb_Employee.Items.Clear();
                    //rcb_BusinessUnit.SelectedIndex = 0;
                    rcmb_period.ClearSelection();
                    rcb_BusinessUnit.ClearSelection();
                    return;
                }
                else
                {
                    //BLL.ShowMessage(this, "Enter the amount for Income Elements to process");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Income_Trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

        //}
    }

    private bool process()
    {
        try
        {
            Label lbl_ID = new Label();
            Label lbl_taxName = new Label();
            RadNumericTextBox rntxt_Value = new RadNumericTextBox();
            Label lbl_MaxAmt = new Label();
            bool status1 = false;
            int index = 0;
            for (index = 0; index <= RG_Employee.Items.Count - 1; index++)
            {
                lbl_ID = RG_Employee.Items[index].FindControl("lbl_tax_id") as Label;
                rntxt_Value = RG_Employee.Items[index].FindControl("rntxt_Number") as RadNumericTextBox;
                lbl_MaxAmt = RG_Employee.Items[index].FindControl("lbl_tax_maxlimit") as Label;
                if (rntxt_Value.Value != 0.00)
                {
                    _obj_smhr_income_trans = new SMHR_INCOME_TRANS();
                    _obj_smhr_income_trans.Mode = 2;
                    _obj_smhr_income_trans.SMHR_EMPINCOME_EMPID = Convert.ToInt32(rcb_Employee.SelectedValue);
                    _obj_smhr_income_trans.SMHR_EMPINCOME_INCOMEID = Convert.ToInt32(Convert.ToString(lbl_ID.Text));
                    _obj_smhr_income_trans.SMHR_EMPINCOME_PERIOD = Convert.ToInt32(rcmb_period.SelectedItem.Value);
                    // Verifying whether the Entered Exemption value is greater than the max limit
                    // if Entered Value is greater than the max limit then take max limit value
                    // else take entered value
                    if (Convert.ToDouble(rntxt_Value.Value) > Convert.ToDouble(Convert.ToString(lbl_MaxAmt.Text)))
                    {
                        _obj_smhr_income_trans.SMHR_EMPINCOME_AMOUNT = Convert.ToDouble(rntxt_Value.Value);
                        _obj_smhr_income_trans.SMHR_EMPINCOME_AMT = Convert.ToDouble(Convert.ToString(lbl_MaxAmt.Text));
                    }
                    else
                    {
                        _obj_smhr_income_trans.SMHR_EMPINCOME_AMOUNT = Convert.ToDouble(rntxt_Value.Value);
                        _obj_smhr_income_trans.SMHR_EMPINCOME_AMT = Convert.ToDouble(rntxt_Value.Value);
                    }
                    _obj_smhr_income_trans.SMHR_EMPINCOME_CREATEDBY = Convert.ToInt32(Convert.ToString(Session["EMP_ID"]));
                    _obj_smhr_income_trans.SMHR_EMPINCOME_CREATEDDATE = DateTime.Now;
                    status1 = BLL.set_Income_Trans(_obj_smhr_income_trans);
                }
            }
            return status1;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Income_Trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return false;
        }
    }

    protected void RG_Employee_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Income_Trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            _obj_smhr_income_trans = new SMHR_INCOME_TRANS();
            _obj_smhr_income_trans.Mode = 1;
            _obj_smhr_income_trans.SMHR_EMPINCOME_EMPID = Convert.ToInt32(rcb_Employee.SelectedValue);
            _obj_smhr_income_trans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_income_trans.SMHR_EMPINCOME_PERIOD = Convert.ToInt32(rcmb_period.SelectedItem.Value);
            DataTable dt = BLL.get_Income_trans(_obj_smhr_income_trans);
            RG_Employee.DataSource = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Income_Trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_period.SelectedIndex <= 0)
            {
                //rcb_Employee.ClearSelection();
                rcb_Employee.Items.Clear();
                rcb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                btn_Save.Visible = false;
                RG_Employee.Visible = false;
            }
            else
            {
                if (rcb_BusinessUnit.SelectedIndex <= 0)
                {
                    rcmb_period.ClearSelection();
                    rcb_Employee.Items.Clear();
                    btn_Save.Visible = false;
                    RG_Employee.Visible = false;
                }
                else
                {
                    LoadEmployees();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Income_Trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
