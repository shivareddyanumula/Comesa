using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class Reportss_PaySlip : System.Web.UI.Page
{
    SMHR_ORGANISATION obj_smhr_Organisation;
    SMHR_BUSINESSUNIT obj_smhr_Businessunit;
    SMHR_EMPLOYEE obj_smhr_Employee;
    SMHR_PERIOD obj_smhr_Period;
    SMHR_LOGININFO obj_smhr_logininfo;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Salary Slip");
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
                    // Rg_Countries.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Submit.Visible = false;
                    // btn_Update.Visible = false;
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

                LoadPeriod();
                //LoadCombos();
                LoadOrganisation();
                //LoadBusinessUnit();
                rcmb_Organisation.Enabled = false;
                //trDept.Visible = false;
                trEmployee.Visible = false;

                if (Convert.ToString(Session["SELFSERVICE"]) != "")
                {
                    if (Convert.ToString(Session["SELFSERVICE"]).ToUpper() == "TRUE")
                    {
                        //trBusinessUnit.Visible = false;
                        trRblist.Visible = false;
                        //trDept.Visible = false;
                        trEmployee.Visible = false;
                    }
                    else
                    {
                        //trBusinessUnit.Visible = true;
                        trRblist.Visible = true;
                    }
                }
                else
                {
                    //trBusinessUnit.Visible = false;
                    LoadBusinessUnit();
                    trRblist.Visible = false;
                    //trDept.Visible = false;
                    trEmployee.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SalarySlip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadOrganisation()
    {
        try
        {
            //obj_smhr_Organisation = new SMHR_ORGANISATION();
            //obj_smhr_Organisation.MODE = 1;
            //DataTable dt_OrganisationDetails = BLL.get_Organisation(obj_smhr_Organisation);
            //rcmb_Organisation.DataSource = dt_OrganisationDetails;
            //rcmb_Organisation.DataValueField = "ORGANISATION_ID";
            //rcmb_Organisation.DataTextField = "ORGANISATION_DESC";
            //rcmb_Organisation.DataBind();
            //rcmb_Organisation.Items.Insert(0, new RadComboBoxItem("Select"));

            SMHR_LOGININFO _obj_LoginInfo = new SMHR_LOGININFO();
            _obj_LoginInfo.OPERATION = operation.Login1;
            _obj_LoginInfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_logindetails = BLL.get_Logindetails(_obj_LoginInfo);
            rcmb_Organisation.DataSource = dt_logindetails;
            rcmb_Organisation.DataTextField = "organisation_name";
            rcmb_Organisation.DataValueField = "organisation_id";
            rcmb_Organisation.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SalarySlip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    private void LoadBusinessUnit()
    {
        try
        {
            obj_smhr_Businessunit = new SMHR_BUSINESSUNIT();
            obj_smhr_Period = new SMHR_PERIOD();
            obj_smhr_logininfo = new SMHR_LOGININFO();

            obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
            {
                obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                DataTable dt_BUDetails = BLL.get_Business_Units(obj_smhr_logininfo);
                rcmb_BusinessUnit.DataSource = dt_BUDetails;
                rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BusinessUnit.DataBind();
                rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
                //rcmb_BusinessUnit.Items.Insert(-1, new RadComboBoxItem(Convert.ToString(Session["ORG_NAME"])));
            }
            else
            {
                //_obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                //_obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                //_obj_smhr_emp_payitems.ORGANISATION_ID=Convert.ToInt32(Session["ORG_ID"]);
                //_obj_smhr_emp_payitems.OPERATION=operation.Self;
                //DataTable dt_BU = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                //rcmb_BusinessUnit.DataSource = dt_BU;
                //rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                //rcmb_BusinessUnit.DataValueField = "EMP_BUSINESSUNIT_ID";
                //rcmb_BusinessUnit.DataBind();
                //rcmb_BusinessUnit.Items.Insert(0,new Telerik.Web.UI.RadComboBoxItem("Select","-1"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SalarySlip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //private void LoadDepartment()
    //{
    //    SMHR_DEPARTMENT _obj_smhr_department = new SMHR_DEPARTMENT();
    //    // _obj_smhr_department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    _obj_smhr_department.MODE = 7;
    //    _obj_smhr_department.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
    //    DataTable dt_dept = BLL.get_Department(_obj_smhr_department);
    //    rcmb_Department.DataSource = dt_dept;
    //    rcmb_Department.DataValueField = "DEPARTMENT_ID";
    //    rcmb_Department.DataTextField = "DEPARTMENT_NAME";
    //    rcmb_Department.DataBind();
    //    rcmb_Department.Items.Insert(0, new RadComboBoxItem("Select"));
    //}

    private void LoadEmployee()
    {
        try
        {
            if (rcmb_PeriodElements.SelectedIndex > 0)
            {
                if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
                {
                    if (Convert.ToInt32(rcmb_BusinessUnit.SelectedValue) > 0)
                    {
                        obj_smhr_logininfo = new SMHR_LOGININFO();
                        obj_smhr_logininfo.OPERATION = operation.getEmp;
                        obj_smhr_logininfo.LOGIN_PRDDTL = Convert.ToInt32(rcmb_PeriodElements.SelectedItem.Value);
                        obj_smhr_logininfo.LOGIN_PERIOD = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
                        string str_BusinessUnit_ID = Convert.ToString(rcmb_BusinessUnit.SelectedValue).ToUpper();
                        obj_smhr_logininfo.BUID = Convert.ToInt32(str_BusinessUnit_ID);
                        obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dt_getEMP = BLL.get_Sup_BusinessUnit(obj_smhr_logininfo);
                        rcmb_Employee.Items.Clear();
                        rcmb_Employee.DataSource = dt_getEMP;
                        rcmb_Employee.DataTextField = "EMP_NAME";
                        rcmb_Employee.DataValueField = "EMP_ID";
                        rcmb_Employee.DataBind();
                        rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                    }
                    else
                    {
                        obj_smhr_Employee = new SMHR_EMPLOYEE();
                        //obj_smhr_Employee.OPERATION = operation.SELECTEMPLOYEE;
                        //obj_smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        //DataTable dt_orgEMP = BLL.get_Employee(obj_smhr_Employee);
                        obj_smhr_logininfo = new SMHR_LOGININFO();
                        obj_smhr_logininfo.OPERATION = operation.SELECTEMPLOYEE;
                        obj_smhr_logininfo.LOGIN_PRDDTL = Convert.ToInt32(rcmb_PeriodElements.SelectedItem.Value);
                        obj_smhr_logininfo.LOGIN_PERIOD = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
                        obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dt_orgEMP = BLL.get_Sup_BusinessUnit(obj_smhr_logininfo);
                        rcmb_Employee.Items.Clear();
                        rcmb_Employee.DataSource = dt_orgEMP;
                        rcmb_Employee.DataTextField = "EMP_NAME";
                        rcmb_Employee.DataValueField = "EMP_ID";
                        rcmb_Employee.DataBind();
                        rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                    }
                }
                else
                {
                    _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                    _obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_emp_payitems.OPERATION = operation.Self;
                    DataTable dt_EMP = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                    rcmb_Employee.DataSource = dt_EMP;
                    rcmb_Employee.DataTextField = "Empname";
                    rcmb_Employee.DataValueField = "EMP_ID";
                    rcmb_Employee.DataBind();
                    rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please Select Pay Period");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SalarySlip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadPeriod()
    {
        try
        {
            obj_smhr_Period = new SMHR_PERIOD();
            obj_smhr_Period.OPERATION = operation.Select;
            obj_smhr_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt_Details = BLL.get_PeriodHeaderDetails_Calendar(obj_smhr_Period);
            DataTable dt_Details = BLL.get_PeriodHeaderDetails(obj_smhr_Period);
            rcmb_Period.DataSource = dt_Details;
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SalarySlip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //private void LoadPeriodElements()
    //{
    //    SMHR_PERIODDTL _obj_smhr_perioddtl = new SMHR_PERIODDTL();
    //    _obj_smhr_perioddtl.OPERATION = operation.Select;
    //    DataTable dt_Details = BLL.get_PeriodDetails(_obj_smhr_perioddtl);
    //    if (dt_Details.Rows.Count != 0)
    //    {
    //        rcmb_PeriodElements.DataSource = dt_Details;
    //        rcmb_PeriodElements.DataValueField = "PRDDTL_ID";
    //        rcmb_PeriodElements.DataTextField = "PRDDTL_NAME";
    //        rcmb_PeriodElements.DataBind();
    //        rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select"));
    //    }
    //}



    protected void rcmb_Organisation_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadBusinessUnit();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SalarySlip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadEmployee();
            //LoadDepartment();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SalarySlip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            string Localisation = string.Empty;
            if (Convert.ToInt32(rcmb_BusinessUnit.SelectedValue) > 0)
            {
                SMHR_BUSINESSUNIT _obj_smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
                _obj_smhr_BusinessUnit.OPERATION = operation.Get_BULocalization;
                _obj_smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                _obj_smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_BULocalization = BLL.get_BusinessUnit(_obj_smhr_BusinessUnit);
                if (dt_BULocalization.Rows.Count != 0)
                    Localisation = Convert.ToString(dt_BULocalization.Rows[0]["HR_MASTER_CODE"]).ToUpper();
            }
            if (Convert.ToString(Session["SELFSERVICE"]).ToUpper() == "TRUE")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_Period.SelectedItem.Value) + "','" + Convert.ToString(rcmb_PeriodElements.SelectedItem.Value) + "','" + Convert.ToString(rcmb_Employee.SelectedItem.Value) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "', '" + Localisation + "');", true);
            }
            else if (Convert.ToString(Session["SELFSERVICE"]).ToUpper() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_Period.SelectedItem.Value) + "','" + Convert.ToString(rcmb_PeriodElements.SelectedItem.Value) + "','" + Convert.ToString(rcmb_Employee.SelectedItem.Value) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "', '" + Localisation + "');", true);
            }
            else
            {
                if (rbList.Items[1].Selected)
                {
                    if ((rcmb_Employee.SelectedIndex > 0))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_Period.SelectedItem.Value) + "','" + Convert.ToString(rcmb_PeriodElements.SelectedItem.Value) + "','" + Convert.ToString(rcmb_Employee.SelectedItem.Value) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "', '" + Localisation + "');", true);
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Please Select An Employee to generate the payslip");
                    }
                }
                else if (rbList.Items[0].Selected)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_Period.SelectedItem.Value) + "','" + Convert.ToString(rcmb_PeriodElements.SelectedItem.Value) + "','" + Convert.ToString(-1) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "', '" + Localisation + "');", true);
                }
                else
                {
                    BLL.ShowMessage(this, "Please Choose whether to select all employees or not");
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SalarySlip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            //rcmb_Period.SelectedIndex = 0;
            //rcmb_BusinessUnit.SelectedIndex = 0;
            //rcmb_Employee.Items.Clear();
            //rcmb_PeriodElements.SelectedIndex = 0;

            LoadPeriod();
            rcmb_PeriodElements.Items.Clear();
            rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem(""));
            if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
            {
                LoadBusinessUnit();
            }
            else
            {
                rcmb_BusinessUnit.Items.Clear();
                rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem(""));
            }
            trEmployee.Visible = false;
            rbList.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SalarySlip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    //protected void rcmb_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    if (rcmb_Period.SelectedIndex != 0)
    //    {
    //        SMHR_PERIODDTL _obj_smhr_perioddtl = new SMHR_PERIODDTL();
    //        _obj_smhr_perioddtl.OPERATION = operation.Select;
    //        _obj_smhr_perioddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
    //        //DataTable dt_Details = BLL.get_PeriodDetails_Calendar(_obj_smhr_perioddtl);
    //        DataTable dt_Details = BLL.get_PeriodDetails(_obj_smhr_perioddtl);
    //        if (dt_Details.Rows.Count != 0)
    //        {
    //            rcmb_PeriodElements.DataSource = dt_Details;
    //            rcmb_PeriodElements.DataValueField = "PRDDTL_ID";
    //            rcmb_PeriodElements.DataTextField = "PRDDTL_NAME";
    //            rcmb_PeriodElements.DataBind();
    //            rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select"));
    //        }
    //    }
    //    else
    //    {
    //        rcmb_PeriodElements.Items.Clear();
    //    }
    //}

    protected void rcmb_payperiod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_PeriodElements.SelectedIndex > 0)
            {
                string strSession = Convert.ToString(Session["SELFSERVICE"]);
                if (Convert.ToString(Session["SELFSERVICE"]) == "")
                {
                    rcmb_BusinessUnit.Items.Clear();
                    if (rcmb_PeriodElements.SelectedIndex != 0)
                    {
                        string periodid = rcmb_PeriodElements.SelectedItem.Value;
                        string Emp_id = Convert.ToString(Session["EMP_ID"]);
                        DataTable dtemp = BLL.get_payslip("BU_emp", periodid, string.Empty, string.Empty, strSession, Emp_id, Convert.ToInt32(Session["USER_ID"]));
                        rcmb_BusinessUnit.DataSource = dtemp;
                        rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                        rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                        rcmb_BusinessUnit.DataBind();
                        //rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                        if (dtemp.Rows.Count == 1)
                            rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dtemp.Rows[0]["BUSINESSUNIT_ID"]));

                        rcmb_Employee.Items.Clear();
                        rcmb_Employee.DataSource = dtemp;
                        rcmb_Employee.DataValueField = "EMP_ID";
                        rcmb_Employee.DataTextField = "EMPNAME";
                        rcmb_Employee.DataBind();
                        rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                        rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(dtemp.Rows[0]["EMP_ID"]));

                    }

                }
                else
                {

                    if (rcmb_PeriodElements.SelectedItem.Value != "0")
                    {
                        if (Convert.ToString(Session["SELFSERVICE"]).ToUpper() == "TRUE")
                        {
                            //trBusinessUnit.Visible = false;
                            getEmployee();
                            //To get d BU for d selected period element
                            rcmb_BusinessUnit.Items.Clear();
                            string periodid = rcmb_PeriodElements.SelectedItem.Value;
                            string Emp_id = Convert.ToString(Session["EMP_ID"]);
                            DataTable dtemp = BLL.get_payslip("BU_emp", periodid, string.Empty, string.Empty, strSession, Emp_id, Convert.ToInt32(Session["USER_ID"]));
                            rcmb_BusinessUnit.DataSource = dtemp;
                            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                            rcmb_BusinessUnit.DataBind();
                            //rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                            if (dtemp.Rows.Count == 1)
                                rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dtemp.Rows[0]["BUSINESSUNIT_ID"]));

                            rcmb_Employee.Items.Clear();
                            rcmb_Employee.DataSource = dtemp;
                            rcmb_Employee.DataValueField = "EMP_ID";
                            rcmb_Employee.DataTextField = "EMPNAME";
                            rcmb_Employee.DataBind();
                            rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                            rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(dtemp.Rows[0]["EMP_ID"]));
                        }
                        else
                        {
                            string periodid = rcmb_PeriodElements.SelectedItem.Value;
                            DataTable dtemp = BLL.get_payslip("BU", periodid, string.Empty, string.Empty, strSession, "NULL", Convert.ToInt32(Session["USER_ID"]));
                            rcmb_BusinessUnit.DataSource = dtemp;
                            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                            rcmb_BusinessUnit.DataBind();
                        }
                    }
                }
            }
            else
            {
                rcmb_BusinessUnit.Items.Clear();
                rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem(""));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SalarySlip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void getEmployee()
    {
        try
        {
            obj_smhr_Employee = new SMHR_EMPLOYEE();
            obj_smhr_Employee.OPERATION = operation.Select;
            obj_smhr_Employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            obj_smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_Employee(obj_smhr_Employee);
            //if (Convert.ToString(dt_Details.Rows[0]["EMP_PICTURE"]) != string.Empty)
            if (dt_Details.Rows.Count > 0)
            {
                Session["dept"] = Convert.ToString(dt_Details.Rows[0]["EMP_DEPARTMENT_ID"]);
                Session["buid"] = Convert.ToString(dt_Details.Rows[0]["EMP_BUSINESSUNIT_ID"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SalarySlip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rbList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rbList.Items[0].Selected)
            {
                //trDept.Visible = false;
                trEmployee.Visible = false;
            }
            else if (rbList.Items[1].Selected)
            {
                //trDept.Visible = true;
                trEmployee.Visible = true;
                LoadEmployee();
            }
            //loadDepartment();
            //rcmb_Employee.Items.Clear();
            //rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SalarySlip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //private void loadDepartment()
    //{
    //    SMHR_DEPARTMENT _obj_smhr_department = new SMHR_DEPARTMENT();

    //    _obj_smhr_department.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
    //    _obj_smhr_department.MODE = 7;
    //    DataTable dt_dept = BLL.get_Department(_obj_smhr_department);
    //    ddl_Department.DataSource = dt_dept;
    //    ddl_Department.DataValueField = "DEPARTMENT_ID";
    //    ddl_Department.DataTextField = "DEPARTMENT_NAME";
    //    ddl_Department.DataBind();
    //    ddl_Department.Items.Insert(0, new RadComboBoxItem("Select"));
    //}

    //protected void ddl_Department_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    if (Convert.ToString(Session["SELFSERVICE"]) == "")
    //    {
    //        LoadEmployees();
    //        rcmb_Employee.Enabled = true;

    //    }
    //    else
    //    {
    //        LoadEmployees();

    //        rcmb_Employee.Enabled = true;
    //        rcmb_Employee.SelectedIndex = rcmb_Employee.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));

    //    }
    //}

    private void LoadEmployees()
    {

        try
        {
            if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
            {

                //SMHR_LOGININFO obj_smhr_logininfo = new SMHR_LOGININFO();
                //obj_smhr_logininfo.OPERATION = operation.Check;
                //string str_BusinessUnit_ID = Convert.ToString(rcmb_BusinessUnit.SelectedValue).ToUpper();


                //obj_smhr_logininfo.OPERATION = operation.Check;
                //obj_smhr_logininfo.BUID = Convert.ToInt32(str_BusinessUnit_ID);
                //DataTable dt_getEMP = BLL.get_Sup_BusinessUnit(obj_smhr_logininfo);
                obj_smhr_Employee = new SMHR_EMPLOYEE();
                obj_smhr_Employee.OPERATION = operation.getdeptwise;
                obj_smhr_Employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                obj_smhr_Employee.EMP_DEPARTMENT_ID = 0;
                DataTable dt_getEMP = BLL.get_Employee(obj_smhr_Employee);
                rcmb_Employee.Items.Clear();
                rcmb_Employee.DataSource = dt_getEMP;
                rcmb_Employee.DataTextField = "EMP_NAME";
                rcmb_Employee.DataValueField = "EMP_ID";
                rcmb_Employee.DataBind();
                rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));



            }
            else
            {
                SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                _obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_emp_payitems.OPERATION = operation.Self;
                DataTable dt_EMP = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                rcmb_Employee.DataSource = dt_EMP;
                rcmb_Employee.DataTextField = "Empname";
                rcmb_Employee.DataValueField = "EMP_ID";
                rcmb_Employee.DataBind();
                rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SalarySlip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_employee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }

    private void LoadCombos()
    {
        try
        {
            //if (Convert.ToString(Session["EMP_ID"]) == "0")
            string strSession = Convert.ToString(Session["SELFSERVICE"]);
            if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
            {

                string period = Convert.ToString(rcmb_Period.SelectedItem.Value);
                DataTable dt_Details = BLL.get_payslip("PERIOD", period, string.Empty, string.Empty, strSession, "NULL", Convert.ToInt32(Session["USER_ID"]));
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_PeriodElements.DataSource = dt_Details;
                    rcmb_PeriodElements.DataValueField = "PERIOD_ID";
                    rcmb_PeriodElements.DataTextField = "PAYPERIOD";
                    rcmb_PeriodElements.DataBind();
                    rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select", "0"));



                }
                else
                {
                    BLL.ShowMessage(this, "No Approved Payroll");
                    rcmb_PeriodElements.Items.Clear();
                    rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select"));
                    //rcmb_BusinessUnit.Items.Clear();
                    //rcmb_BusinessUnit.Items.Insert(0,new RadComboBoxItem("Select"));
                }
            }
            else
            {
                string period = Convert.ToString(rcmb_Period.SelectedItem.Value);
                string Emp_id = Convert.ToString(Session["EMP_ID"]);
                DataTable dt_Details = BLL.get_payslip("PERIOD1", period, string.Empty, string.Empty, strSession, Emp_id, Convert.ToInt32(Session["USER_ID"]));
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_PeriodElements.DataSource = dt_Details;
                    rcmb_PeriodElements.DataValueField = "PERIOD_ID";
                    rcmb_PeriodElements.DataTextField = "PAYPERIOD";
                    rcmb_PeriodElements.DataBind();
                    rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select", "0"));


                }
                else
                {
                    rcmb_PeriodElements.Items.Clear();
                    rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select", "0"));

                    BLL.ShowMessage(this, "There are no Payslips to Display");
                }
                rcmb_BusinessUnit.Items.Clear();
                rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem(""));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SalarySlip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Period.SelectedIndex > 0)
            {
                if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
                {
                    LoadCombos();
                }
                else
                {
                    LoadCombos();
                    rcmb_BusinessUnit.Items.Clear();
                    rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem(""));
                }
            }
            else
            {
                if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
                {
                    rcmb_PeriodElements.Items.Clear();
                    rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem(""));
                }
                else
                {
                    rcmb_BusinessUnit.Items.Clear();
                    rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem(""));
                    rcmb_PeriodElements.Items.Clear();
                    rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem(""));
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SalarySlip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
