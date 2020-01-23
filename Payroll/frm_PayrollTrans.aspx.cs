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


public partial class Payroll_frm_PayrollTrans : System.Web.UI.Page
{
    SMHR_PERIOD _obj_smhr_period;
    SMHR_EMPLOYEE _obj_smhr_employee;
    SMHR_PAYROLL _obj_smhr_payroll;

    static DataTable dt_Details;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                clearFields();
                LoadCombos();

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("PAYROLLPROCESS");
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
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Paytran.Visible = false;

                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    // ----------------------------------------------------------------------------------------
    // Author:                        Dhanush InfoTech Pvt Ltd
    // Company:                       Dhanush InfoTech Pvt Ltd
    // Date:                          7/22/2010
    // Time:                          16:32
    // Procedure Name:                LoadCombos
    // Procedure Kind Description:    Method
    // Purpose:                       Loading Respective Dropdowns
    // ----------------------------------------------------------------------------------------
    private void LoadCombos()
    {
        try
        {
            _obj_smhr_period = new SMHR_PERIOD();
            dt_Details = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            ddl_Period.DataSource = dt_Details;
            ddl_Period.DataValueField = "PERIOD_ID";
            ddl_Period.DataTextField = "PERIOD_NAME";
            ddl_Period.DataBind();
            ddl_Period.Items.Insert(0, new RadComboBoxItem("Select"));

            SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            ddl_BusinessUnit.DataSource = dt_BUDetails;
            ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            ddl_BusinessUnit.DataBind();
            ddl_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
            lbl_SalaryStruct.Visible = false;
            chkSalary_List.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    // ----------------------------------------------------------------------------------------
    // Author:                        Dhanush InfoTech Pvt Ltd
    // Company:                       Dhanush InfoTech Pvt Ltd
    // Date:                          7/22/2010
    // Time:                          16:34
    // Procedure Name:                ddl_Period_SelectedIndexChanged
    // Procedure Kind Description:    Method
    // Purpose:                       Filling up Period Elements Drop down
    // ----------------------------------------------------------------------------------------
    protected void ddl_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if ((ddl_BusinessUnit.SelectedIndex > 0) && (ddl_Period.SelectedIndex > 0))
            {
                _obj_smhr_payroll = new SMHR_PAYROLL();
                _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(ddl_Period.SelectedValue);
                _obj_smhr_payroll.MODE = 28;
                dt_Details = new DataTable();
                dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
                if (dt_Details.Rows.Count != 0)
                {
                    ddl_PeriodElements.DataSource = dt_Details;
                    ddl_PeriodElements.DataValueField = "PRDDTL_ID";
                    ddl_PeriodElements.DataTextField = "PRDDTL_NAME";
                    ddl_PeriodElements.DataBind();
                    ddl_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select"));
                }
            }
            else
            {
                if (ddl_BusinessUnit.SelectedIndex <= 0)
                    ddl_Period.ClearSelection();

                if (ddl_Period.SelectedIndex <= 0)
                {
                    ddl_PeriodElements.Items.Clear();
                    lbl_SalaryStruct.Visible = false;
                    chkSalary_List.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
           BLL.ShowMessage(this,ex.ToString());
        }
    }

    protected void ddl_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (ddl_BusinessUnit.SelectedIndex <= 0)
            {
                ddl_Period.ClearSelection();
                ddl_PeriodElements.Items.Clear();
                lbl_SalaryStruct.Visible = false;
                chkSalary_List.Visible = false;
            }
              
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            BLL.ShowMessage(this, ex.ToString());
        }
    }

    protected void chkSalary_List_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void btn_Paytran_Click(object sender, EventArgs e)
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
        _obj_smhr_payroll.BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
        dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
        if (dt_Details.Rows.Count != 0)
        {
            //BLL.ShowMessage(this, "Payroll Already done for this Period");
            //return;
        }
        else
        {
            _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(ddl_PeriodElements.SelectedValue);
            _obj_smhr_payroll.MODE = 7;
            _obj_smhr_payroll.EMP_SALSTRUCT = Convert.ToString(strPayroll);
            _obj_smhr_payroll.BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
            if (dt_Details.Rows.Count != 0)
            {
                //BLL.ShowMessage(this, "Payroll Already done for this Period");
                //return;
            }
        }



        bool status = false;
        int procstatus = 0;
        try
        {
            StringBuilder strPay = new StringBuilder();
            string str1 = null;
            _obj_smhr_payroll.MODE = 8;
            _obj_smhr_payroll.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            
            DataTable dt = BLL.get_payrolltrans(_obj_smhr_payroll);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(strPay)) && string.IsNullOrEmpty(str1))
                    {
                        str1 = Convert.ToString(dt.Rows[i][0]);
                        strPay.Append(str1);
                    }
                    else
                    {
                        str1 = "," + Convert.ToString(dt.Rows[i][0]);
                        strPay.Append(str1);
                    }
                }
            }
            else
            {
                //BLL.ShowMessage(this, "Approval Process Not set Properly.");
                //return;
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
            _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Local = BLL.ExecuteQuery("SELECT BUSINESSUNIT_LOCALISATION,HR_MASTER_CODE FROM SMHR_BUSINESSUNIT " +
                                                  "  JOIN SMHR_HR_MASTER ON " +
                                                  "  BUSINESSUNIT_LOCALISATION = HR_MASTER_ID WHERE BUSINESSUNIT_ID = '" + Convert.ToInt32(ddl_BusinessUnit.SelectedValue) + "'");

            if (dt_Local.Rows.Count > 0)
            {
                status = BLL.set_payrolltrans(_obj_smhr_employee, Convert.ToString(dt_Local.Rows[0]["HR_MASTER_CODE"]));
            }
            else
            {
                BLL.ShowMessage(this, "Localisation is Not Defined for Selected business Unit");
                return;
            }


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
            else if (ex.Message == "NOATTENDS")
            {
                procstatus = 3;
            }
            else if (ex.Message == "NOMAPPING")
            {
                procstatus = 4;
            }
            else if (ex.Message == "ALREADYEXIST")
            {
                procstatus = 5;
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
            else if (procstatus == 3)
            {
                BLL.ShowMessage(this, "Attendance is not defined for this period.");
                return;
            }
            else if (procstatus == 4)
            {
                BLL.ShowMessage(this, "Payitems Mapping is not defined for this Organisation.");
                return;
            }
            else if (procstatus == 5)
            {
                BLL.ShowMessage(this, "Payroll Already done for this Period.");
                return;
            }
            else
            {
                BLL.ShowMessage(this, "Error occured while performing the process");
                return;
            }
        }
    }

    private void clearFields()
    {
        ddl_Period.SelectedIndex = -1;
        ddl_PeriodElements.Items.Clear();
        ddl_BusinessUnit.SelectedIndex = -1;
        chkSalary_List.Items.Clear();
        lbl_SalaryStruct.Visible = false;
        //RLB_Employees.Visible = false;
        //RLB_SelectedEmps.Visible = false;
    }

    protected void ddl_PeriodElements_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if ((ddl_BusinessUnit.SelectedIndex > 0) && (ddl_PeriodElements.SelectedIndex > 0))
            {
                dt_Details = new DataTable();
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.Empty;
                _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                _obj_smhr_employee.EMPSALDTLS_PRDDTL_ID = Convert.ToInt32(ddl_PeriodElements.SelectedValue);
                _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                dt_Details = BLL.get_PayBusinessUnit(_obj_smhr_employee);
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
            else
            {
                lbl_SalaryStruct.Visible = false;
                chkSalary_List.Visible = false;
            }
           
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollTrans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
