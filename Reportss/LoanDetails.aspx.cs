using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Reportss_LoanDetails : System.Web.UI.Page
{
    //SMHR_BUSINESSUNIT obj_smhr_Businessunit;
    //SMHR_PERIOD obj_smhr_Period;
    SMHR_LOGININFO obj_smhr_Logininfo;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string loanType = string.Empty;
                loanType = Convert.ToString(Request.QueryString["LoanType"]);
                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString(lbl_header.Text);
                if (loanType != null)
                {
                    switch (loanType)
                    {
                        case "SpecialLoan":
                            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Special Loans");
                            break;
                        case "CombinedLoan":
                            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Combined Loan");
                            break;
                        case "CarAdvanceAndMortgage":
                            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Car Advance & Mortgage Loan A/C Statement");
                            break;
                       
                    }
                }
                else
                {
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("All Loans");
                }
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

                    btn_Generate.Visible = false;
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
                LoadOrganisation();
                LoadBusinessUnit();
                LoadLoanType();

                //To change heading based on querystring
                trLoanNo.Visible = false;
                
                if (Request.QueryString.HasKeys())
                {
                    loanType = Convert.ToString(Request.QueryString["LoanType"]);
                }

                if (loanType == "SpecialLoan")
                {
                    lbl_header.Text = "Special Loans";
                }
                else if (loanType == "CombinedLoan")
                {
                    lbl_header.Text = "Combined Loan";
                }
                else if (loanType == "CarAdvanceAndMortgage")
                {
                    lbl_header.Text = "Car Advance & Mortgage Loan A/C Statement";// "Car Advance And Mortgage Loan Account Statement";
                    //LoadLoanNumber();
                    trLoanNo.Visible = true;
                }
                else
                {
                    lbl_header.Text = "All Loans";
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadLoanNumber()
    {
        try
        {

            SMHR_PAYITEMS _obj_Smhr_PayItems = new SMHR_PAYITEMS();
            //_obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_PayItems.PAYITEM_ITEMTYPE_ID = Convert.ToInt32(rcmb_LoanType.SelectedValue);  //Loan type ID
            _obj_Smhr_PayItems.LASTMDFBY = Convert.ToInt32(rcmb_Employee.SelectedValue);
            _obj_Smhr_PayItems.OPERATION = operation.load;
            rcmb_LoanNo.Items.Clear();
            rcmb_LoanNo.DataSource = BLL.get_PayItems(_obj_Smhr_PayItems);
            rcmb_LoanNo.DataTextField = "LOANTRANS_LOANNO";
            rcmb_LoanNo.DataValueField = "LOANTRANS_LOANNO";
            rcmb_LoanNo.DataBind();
            rcmb_LoanNo.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadBusinessUnit()
    {
        try
        {
            //obj_smhr_Businessunit = new SMHR_BUSINESSUNIT();
            //obj_smhr_Period = new SMHR_PERIOD();
            obj_smhr_Logininfo = new SMHR_LOGININFO();

            if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
            {
                obj_smhr_Logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                obj_smhr_Logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_BUDetails = BLL.get_Business_Units(obj_smhr_Logininfo);
                rcmb_BusinessUnit.DataSource = dt_BUDetails;
                rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BusinessUnit.DataBind();
                rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                _obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_emp_payitems.OPERATION = operation.Self;
                DataTable dt_BU = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                rcmb_BusinessUnit.DataSource = dt_BU;
                rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BusinessUnit.DataValueField = "EMP_BUSINESSUNIT_ID";
                rcmb_BusinessUnit.DataBind();
                rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadOrganisation()
    {
        try
        {
            SMHR_LOGININFO _obj_LoginInfo = new SMHR_LOGININFO();
            _obj_LoginInfo.OPERATION = operation.Login1;
            _obj_LoginInfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_logindetails = BLL.get_Logindetails(_obj_LoginInfo);
            rcmb_Organisation.DataSource = dt_logindetails;
            rcmb_Organisation.DataTextField = "organisation_name";
            rcmb_Organisation.DataValueField = "organisation_id";
            rcmb_Organisation.DataBind();
            if (dt_logindetails.Rows.Count > 1)
            {
                rcmb_Organisation.Enabled = true;
            }
            else
            {
                rcmb_Organisation.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadLoanType()
    {
        try
        {
            SMHR_PAYITEMS _obj_Smhr_BusinessUnit = new SMHR_PAYITEMS();

            string loanType = string.Empty;
            if (Request.QueryString.HasKeys())
            {
                loanType = Convert.ToString(Request.QueryString["LoanType"]);
            }

            if (loanType == "SpecialLoan")
            {
                _obj_Smhr_BusinessUnit.OPERATION = operation.Get;
                _obj_Smhr_BusinessUnit.MODE = 1;    //Special Loan
            }
            else if (loanType == "CombinedLoan")
            {
                _obj_Smhr_BusinessUnit.OPERATION = operation.Get;
                _obj_Smhr_BusinessUnit.MODE = 2;    //Combined Loan
            }
            else if (loanType == "CarAdvanceAndMortgage")
            {
                _obj_Smhr_BusinessUnit.OPERATION = operation.Get;
                _obj_Smhr_BusinessUnit.MODE = 3;    //"CarAdvance And Mortgage Loan Account Statement"
            }
            else
            {
                //_obj_Smhr_BusinessUnit.OPERATION = operation.Check1;
                _obj_Smhr_BusinessUnit.OPERATION = operation.Get;
                _obj_Smhr_BusinessUnit.MODE = 4;    //All Loans
            }

            //SMHR_PAYITEMS _obj_Smhr_BusinessUnit = new SMHR_PAYITEMS();
            //_obj_Smhr_BusinessUnit.OPERATION = operation.Check1;
            _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_LoanType.Items.Clear();
            rcmb_LoanType.DataSource = BLL.get_PayItems(_obj_Smhr_BusinessUnit);
            rcmb_LoanType.DataTextField = "PAYITEM_PAYITEMNAME";
            rcmb_LoanType.DataValueField = "PAYITEM_ID";
            rcmb_LoanType.DataBind();
            if (loanType == "CombinedLoan")
            {
                rcmb_LoanType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("All", "-1"));
            }
            else
            {
                rcmb_LoanType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void BindDirectorate(DataTable dt)
    {
        try
        {
            rcmb_Directorate.DataSource = dt;
            rcmb_Directorate.DataTextField = "DIRECTORATE_CODE";
            rcmb_Directorate.DataValueField = "DIRECTORATE_ID";
            rcmb_Directorate.DataBind();
            rcmb_Directorate.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void BindDepartment(DataTable dt)
    {
        try
        {
            rcmb_Department.DataSource = dt;
            rcmb_Department.DataTextField = "DEPARTMENT_NAME";
            rcmb_Department.DataValueField = "DEPARTMENT_ID";
            rcmb_Department.DataBind();
            rcmb_Department.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void BindEmployee(DataTable dt)
    {
        try
        {
            rcmb_Employee.DataSource = dt;
            rcmb_Employee.DataTextField = "EMPNAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            if (string.Compare(Convert.ToString(Request.QueryString["LoanType"]), "CarAdvanceAndMortgage", true) == 0)
            {
                rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
            else
            {
                rcmb_Employee.Items.Insert(0, new RadComboBoxItem("All", "-1"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BusinessUnit.SelectedIndex > 0)
            {
                //DataSet ds = BLL.GetEmployeeFilterDetails(organisationID, Convert.ToInt32(RadBusinessUnit.SelectedValue), null, null);
                DataSet ds = BLL.GetEmployeeFilterDetails(Convert.ToInt32(rcmb_Organisation.SelectedValue), Convert.ToInt32(rcmb_BusinessUnit.SelectedValue), null, null);
                BindDirectorate(ds.Tables[1]);
                //BindDepartment(ds.Tables[2]);

                //To populate employee details
                BindEmployee(ds.Tables[3]);
                rcmb_LoanType.ClearSelection();
            }
            else
            {
                rcmb_Directorate.Items.Clear();
                rcmb_Directorate.Text = string.Empty;
                rcmb_Employee.Items.Clear();
                rcmb_Employee.Text = string.Empty;
                rcmb_Department.Items.Clear();
                rcmb_Department.Text = string.Empty;
                rcmb_LoanType.ClearSelection();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcmb_Directorate_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Directorate.SelectedIndex > 0)
            {
                DataSet ds = BLL.GetEmployeeFilterDetails(Convert.ToInt32(rcmb_Organisation.SelectedValue), Convert.ToInt32(rcmb_BusinessUnit.SelectedValue), Convert.ToInt32(rcmb_Directorate.SelectedValue), null);
                BindDepartment(ds.Tables[2]);

                //To populate employee details
                BindEmployee(ds.Tables[3]);
            }
            else
            {
                rcmb_Department.Items.Clear();
                rcmb_Department.Text = string.Empty;
                DataSet ds = BLL.GetEmployeeFilterDetails(Convert.ToInt32(rcmb_Organisation.SelectedValue), Convert.ToInt32(rcmb_BusinessUnit.SelectedValue), null, null);
                BindEmployee(ds.Tables[3]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcmb_Department_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Department.SelectedIndex > 0)
            {
                //if (!HideEmployee)
                //{
                //To populate employee details
                DataSet ds = BLL.GetEmployeeFilterDetails(Convert.ToInt32(rcmb_Organisation.SelectedValue), Convert.ToInt32(rcmb_BusinessUnit.SelectedValue), Convert.ToInt32(rcmb_Directorate.SelectedValue), Convert.ToInt32(rcmb_Department.SelectedValue));
                BindEmployee(ds.Tables[3]);
                //}
            }
            else
            {
                DataSet ds = BLL.GetEmployeeFilterDetails(Convert.ToInt32(rcmb_Organisation.SelectedValue), Convert.ToInt32(rcmb_BusinessUnit.SelectedValue), Convert.ToInt32(rcmb_Directorate.SelectedValue), null);
                BindEmployee(ds.Tables[3]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            string loanType = string.Empty;
            string rpt = string.Empty;
            if (Request.QueryString.HasKeys())
            {
                loanType = Convert.ToString(Request.QueryString["LoanType"]);
            }

            if (loanType == "SpecialLoan")
            {
                rpt = "Special Loans";
            }
            else if (loanType == "CombinedLoan")
            {
                rpt = "Combined Loan";
            }
            else if (loanType == "CarAdvanceAndMortgage")
            {
                rpt = "Car Advance And Mortgage Loan Account Statement";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPopup('" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_Directorate.SelectedValue) + "','" + Convert.ToString(rcmb_Department.SelectedValue) + "','" + Convert.ToString(rcmb_Employee.SelectedValue) + "','" + Convert.ToString(rcmb_LoanType.SelectedValue) + "','" + Convert.ToString(rpt) + "','" + Convert.ToString(rcmb_LoanNo.SelectedValue) + "');", true);
                return;
            }
            else
            {
                rpt = "All Loans";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_Directorate.SelectedValue) + "','" + Convert.ToString(rcmb_Department.SelectedValue) + "','" + Convert.ToString(rcmb_Employee.SelectedValue) + "','" + Convert.ToString(rcmb_LoanType.SelectedValue) + "','" + Convert.ToString(rpt) + "');", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_Employee.SelectedValue) + "','" + Convert.ToString(rcmb_LoanType.SelectedValue) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_BusinessUnit.ClearSelection();
            rcmb_Directorate.Items.Clear();
            rcmb_Directorate.Text = string.Empty;
            rcmb_Department.Items.Clear();
            rcmb_Department.Text = string.Empty;
            rcmb_Employee.Items.Clear();
            rcmb_Employee.Text = string.Empty;
            rcmb_LoanType.ClearSelection();
            rcmb_LoanNo.Items.Clear();
            rcmb_LoanNo.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_LoanType_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_LoanType.SelectedIndex > 0 && rcmb_Employee.SelectedIndex > 0)
            {
                string loanType = string.Empty;
                if (Request.QueryString.HasKeys())
                {
                    loanType = Convert.ToString(Request.QueryString["LoanType"]);
                    if (loanType == "CarAdvanceAndMortgage")
                    {
                        LoadLoanNumber();
                    }
                }
            }
            else
            {
                rcmb_LoanNo.Items.Clear();
                rcmb_LoanNo.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_Employee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_LoanType.SelectedIndex > 0)
            {
                string loanType = string.Empty;
                if (Request.QueryString.HasKeys())
                {
                    loanType = Convert.ToString(Request.QueryString["LoanType"]);
                    if (loanType == "CarAdvanceAndMortgage")
                    {
                        LoadLoanNumber();
                    }
                }
            }
            else
            {
                rcmb_LoanNo.Items.Clear();
                rcmb_LoanNo.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}