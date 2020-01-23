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

public partial class Payroll_frm_Retropay : System.Web.UI.Page
{
    SMHR_PERIOD _obj_smhr_period;
    SMHR_EMPLOYEE _obj_smhr_employee;
    SMHR_PAYROLL _obj_smhr_payroll;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                clearFields();
                LoadCombos();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Retropay", ex.StackTrace, DateTime.Now);
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
            _obj_smhr_period = new SMHR_PERIOD();
            _obj_smhr_period.OPERATION = operation.Select;
            DataTable dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            ddl_Period.DataSource = dt_Details;
            ddl_Period.DataValueField = "PERIOD_ID";
            ddl_Period.DataTextField = "PERIOD_NAME";
            ddl_Period.DataBind();
            ddl_Period.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Retropay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ddl_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            _obj_smhr_payroll = new SMHR_PAYROLL();
            _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(ddl_Period.SelectedValue);
            _obj_smhr_payroll.MODE = 11;
            DataTable dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
            if (dt_Details.Rows.Count != 0)
            {
                ddl_PeriodElements.DataSource = dt_Details;
                ddl_PeriodElements.DataValueField = "PRDDTL_ID";
                ddl_PeriodElements.DataTextField = "PRDDTL_NAME";
                ddl_PeriodElements.DataBind();
                ddl_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Retropay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void ddl_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Empty;
            _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            _obj_smhr_employee.EMPSALDTLS_PRDDTL_ID = Convert.ToInt32(ddl_PeriodElements.SelectedValue);
            DataTable dt_Details = BLL.get_PayBusinessUnit(_obj_smhr_employee);
            if (dt_Details.Rows.Count != 0)
            {
                chkSalary_List.DataSource = dt_Details;
                chkSalary_List.DataValueField = "EMP_SALALRYSTRUCT_ID";
                chkSalary_List.DataTextField = "SALARYSTRUCT_CODE";
                chkSalary_List.DataBind();
                lbl_SalaryStruct.Visible = true;
                chkSalary_List.Visible = true;
            }
            else
            {
                lbl_SalaryStruct.Visible = false;
                chkSalary_List.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Retropay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Paytran_Click(object sender, EventArgs e)
    {
        try
        {
            StringBuilder strPayroll = new StringBuilder();
            string str;
            for (int index = 0; index <= chkSalary_List.Items.Count - 1; index++)
            {
                if (chkSalary_List.Items[index].Selected)
                {
                    if (Convert.ToString(strPayroll) != string.Empty)
                    {
                        str = ",''" + chkSalary_List.Items[index].Value + "''";
                        strPayroll.Append(str);
                    }
                    else
                    {
                        str = "''" + chkSalary_List.Items[index].Value + "''";
                        strPayroll.Append(str);
                    }
                }
            }

            if (Convert.ToString(strPayroll) == string.Empty)
            {
                BLL.ShowMessage(this, "Please Choose Salary Structure");
                return;
            }

            _obj_smhr_payroll = new SMHR_PAYROLL();
            _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(ddl_PeriodElements.SelectedValue);
            _obj_smhr_payroll.MODE = 6;
            _obj_smhr_payroll.EMP_SALSTRUCT = Convert.ToString(strPayroll);
            DataTable dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
            if (dt_Details.Rows.Count != 0)
            {
                BLL.ShowMessage(this, "Payroll Already done for this Period");
                return;
            }
            else
            {
                _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(ddl_PeriodElements.SelectedValue);
                _obj_smhr_payroll.MODE = 7;
                _obj_smhr_payroll.EMP_SALSTRUCT = Convert.ToString(strPayroll);
                dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
                if (dt_Details.Rows.Count != 0)
                {
                    BLL.ShowMessage(this, "Payroll Already done for this Period");
                    return;
                }
            }



            bool status = false;
            int procstatus = 0;
            try
            {
                StringBuilder strPay = new StringBuilder();
                string str1 = null;
                _obj_smhr_payroll.MODE = 8;
                DataTable dt = BLL.get_payrolltrans(_obj_smhr_payroll);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(strPay)) && string.IsNullOrEmpty(str1))
                        {
                            str1 = Convert.ToString(dt.Rows[0][3]);
                            strPay.Append(str1);
                        }
                        else
                        {
                            str1 = "," + Convert.ToString(dt.Rows[0][3]);
                            strPay.Append(str1);
                        }
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Approval Process Not set Properly.");
                    return;
                }
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.EMPSALDTLS_PERIOD_ID = Convert.ToInt32(ddl_Period.SelectedValue);
                _obj_smhr_employee.EMPSALDTLS_PRDDTL_ID = Convert.ToInt32(ddl_PeriodElements.SelectedValue);
                _obj_smhr_employee.EMPSALDTLS_STR = Convert.ToString(strPay);
                if (Convert.ToString(strPayroll) != string.Empty)
                {
                    _obj_smhr_employee.EMPSALDTLS_STRUCT = Convert.ToString(strPayroll);
                }
                else
                {
                    _obj_smhr_employee.EMPSALDTLS_STRUCT = string.Empty;
                }
                _obj_smhr_employee.EMPSALDTLS_ID = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_employee.EMPSALDTLS_DATE = DateTime.Now;
                status = BLL.set_payrolltrans(_obj_smhr_employee, "KENYA");
                if (status == true)
                {
                    procstatus = 2;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "NO EMPLOYEES TO RUN PAYROLL")
                {
                    procstatus = 1;
                }
                //status = false;
            }
            if (procstatus == 2)
            {
                BLL.ShowMessage(this, "Payroll Process sent for Approval");
                clearFields();
                return;
            }
            else
            {
                if (procstatus == 1)
                {
                    BLL.ShowMessage(this, "No employees to process");
                    return;
                }
                else
                {
                    BLL.ShowMessage(this, "Error occured while performing the process");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Retropay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearFields()
    {
        ddl_Period.SelectedIndex = -1;
        ddl_PeriodElements.Items.Clear();
        ddl_BusinessUnit.SelectedIndex = -1;
        chkSalary_List.Items.Clear();
        lbl_SalaryStruct.Visible = false;
    }

    protected void ddl_PeriodElements_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            _obj_smhr_payroll = new SMHR_PAYROLL();
            _obj_smhr_payroll.MODE = 19;
            _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(ddl_PeriodElements.SelectedValue);
            DataTable dt_Details = BLL.get_Payroll(_obj_smhr_payroll);
            ddl_BusinessUnit.DataSource = dt_Details;
            ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            ddl_BusinessUnit.DataBind();
            ddl_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
            lbl_SalaryStruct.Visible = false;
            chkSalary_List.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Retropay", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
