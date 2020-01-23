using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;


public partial class Reportss_New_Reports_EmpLeaveStmt : System.Web.UI.Page
{
    SMHR_ORGANISATION obj_smhr_Organisation;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Leave Statement");
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
                    btn_Submit.Visible = false;
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
                LoadOrganisation();
                LoadBU();
            }

            //if (!(IsPostBack))
            //    LoadEmployee();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpLeaveStmt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void LoadEmployee()
    {
        try
        {
            _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_emp_payitems.OPERATION = operation.Select_Self;
            DataTable dt_EMP = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
            rcmb_Emp.DataSource = dt_EMP;
            rcmb_Emp.DataTextField = "Empname";
            rcmb_Emp.DataValueField = "EMP_ID";
            rcmb_Emp.DataBind();
            rcmb_Emp.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("All", "-1"));

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpLeaveStmt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
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
            rcmb_Org.DataSource = dt_logindetails;
            rcmb_Org.DataTextField = "organisation_name";
            rcmb_Org.DataValueField = "organisation_id";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpLeaveStmt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        rcmb_Org.DataBind();
    }

    private void LoadBU()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            obj_smhr_Period = new SMHR_PERIOD();

            obj_smhr_logininfo = new SMHR_LOGININFO();
            obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(obj_smhr_logininfo);
            rcmb_BU.DataSource = dt_BUDetails;
            rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BU.DataBind();

            //if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
            //    rcmb_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("All", "-1"));
            //else
            //    rcmb_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            rcmb_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpLeaveStmt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BU_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BU.SelectedValue != "")
            {
                if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
                {
                    obj_smhr_logininfo = new SMHR_LOGININFO();
                    obj_smhr_logininfo.OPERATION = operation.Check;
                    string str_BusinessUnit_ID = Convert.ToString(rcmb_BU.SelectedValue).ToUpper();
                    //obj_smhr_logininfo.BUID = Convert.ToInt32(str_BusinessUnit_ID);
                    //DataTable dt_getBUSINESS_ID = BLL.get_Sup_BusinessUnit(obj_smhr_logininfo);
                    //string str_BUSINESSUNIT_ID = Convert.ToString(dt_getBUSINESS_ID.Rows[0][0]);

                    obj_smhr_logininfo.OPERATION = operation.Check;
                    obj_smhr_logininfo.BUID = Convert.ToInt32(str_BusinessUnit_ID);
                    DataTable dt_getEMP = BLL.get_Sup_BusinessUnit(obj_smhr_logininfo);

                    rcmb_Emp.Items.Clear();
                    rcmb_Emp.DataSource = dt_getEMP;
                    rcmb_Emp.DataTextField = "EMP_NAME";
                    rcmb_Emp.DataValueField = "EMP_ID";
                    rcmb_Emp.DataBind();
                    //rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                    rcmb_Emp.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("All", "-1"));
                    if (rcmb_BU.SelectedValue != "-1")
                        rcmb_Emp.SelectedValue = "-1";
                }
                else
                {
                    _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                    _obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_emp_payitems.OPERATION = operation.Self;
                    DataTable dt_EMP = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                    rcmb_Emp.DataSource = dt_EMP;
                    rcmb_Emp.DataTextField = "Empname";
                    rcmb_Emp.DataValueField = "EMP_ID";
                    rcmb_Emp.DataBind();
                    rcmb_Emp.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                }
            }
            else
            {
                rcmb_Emp.Items.Clear();
                rcmb_Emp.Text = String.Empty;
                rdt_FromDate.SelectedDate = null;
                rdt_Enddate.SelectedDate = null;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpLeaveStmt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["SELFSERVICE"]).ToUpper() == "TRUE")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_Org.SelectedValue) + "','" + Convert.ToString(rcmb_BU.SelectedValue) + "','" + Convert.ToString(rcmb_Emp.SelectedValue) + "','" + rdt_FromDate.SelectedDate + "','" + rdt_Enddate.SelectedDate + "','" + Convert.ToString(rcbStatus.SelectedItem.Value) + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_Org.SelectedValue) + "','" + Convert.ToString(rcmb_BU.SelectedValue) + "','" + Convert.ToString(rcmb_Emp.SelectedValue) + "','" + rdt_FromDate.SelectedDate + "','" + rdt_Enddate.SelectedDate + "','" + Convert.ToString(rcbStatus.SelectedItem.Value) + "');", true);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpLeaveStmt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            LoadBU();
            rcmb_Emp.SelectedIndex = 0;
            rdt_FromDate.SelectedDate = null;
            rdt_Enddate.SelectedDate = null;
            rcbStatus.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpLeaveStmt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void rdt_FromDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            if (rdt_FromDate.SelectedDate != null)
                rdt_Enddate.MinDate = Convert.ToDateTime(rdt_FromDate.SelectedDate);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpLeaveStmt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}