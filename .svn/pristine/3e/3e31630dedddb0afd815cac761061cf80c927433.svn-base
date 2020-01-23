using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using SMHR;
using Telerik.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

public partial class Security_PasswordReset : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    SMHR_EMPLOYEE _obj_smhr_employee;
    SMHR_LOGINTYPE _obj_Smhr_LoginInfo;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                loadBusinessUnit();

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PasswordReset", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadBusinessUnit()
    {
        try
        {


            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmbBusinessUnit.DataSource = dt_BUDetails;
            rcmbBusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmbBusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmbBusinessUnit.DataBind();
            rcmbBusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PasswordReset", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadEmployees()
    {
        try
        {
            _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            _obj_smhr_emp_payitems.OPERATION = operation.GetPass;
            _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmbBusinessUnit.SelectedValue);
            _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
            if (dt_Details.Rows.Count != 0)
            {
                rcmbEmployee.Items.Clear();
                rcmbEmployee.DataSource = dt_Details;
                rcmbEmployee.DataTextField = "Empname";
                rcmbEmployee.DataValueField = "EMP_ID";
                rcmbEmployee.DataBind();
                rcmbEmployee.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PasswordReset", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadUserGroups()
    {
        try
        {
            rcmbUserGroup.Items.Clear();
            _obj_Smhr_LoginInfo = new SMHR_LOGINTYPE();
            _obj_Smhr_LoginInfo.OPERATION = operation.Select;
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmbUserGroup.DataSource = BLL.get_LoginType(_obj_Smhr_LoginInfo);
            rcmbUserGroup.DataTextField = "LOGTYP_CODE";
            rcmbUserGroup.DataValueField = "LOGTYP_ID";
            rcmbUserGroup.DataBind();
            rcmbUserGroup.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PasswordReset", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void getDetails()
    {
        try
        {
            LoadUserGroups();
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Select1;
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(rcmbEmployee.SelectedValue);
            DataTable dt = BLL.get_EMP_NEWCONTACTS(_obj_smhr_employee);
            if (dt.Rows.Count > 0)
            {
                rcmbUserGroup.SelectedIndex = rcmbUserGroup.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LOGIN_TYPE"]));
                if (rcmbUserGroup.SelectedIndex > 0)
                {
                    rcmbUserGroup.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PasswordReset", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmbBusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmbBusinessUnit.SelectedIndex > 0)
            {
                rcmbEmployee.Text = string.Empty;
                rcmbEmployee.Items.Clear();
                //rcmbEmployee.SelectedIndex = -1;
                loadEmployees();
                rcmbUserGroup.Items.Clear();
                rcmbUserGroup.Items.Insert(0, new RadComboBoxItem("", ""));
            }
            else
            {
                rcmbEmployee.Items.Clear();
                rcmbEmployee.Items.Insert(0, new RadComboBoxItem("", ""));
                rcmbUserGroup.Items.Clear();
                rcmbUserGroup.Items.Insert(0, new RadComboBoxItem("", ""));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PasswordReset", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmbEmployee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmbEmployee.SelectedIndex > 0)
            {
                getDetails();
            }
            else
            {
                rcmbUserGroup.Items.Clear();
                rcmbUserGroup.Items.Insert(0, new RadComboBoxItem("", ""));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PasswordReset", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcmbEmployee.SelectedIndex > 0)
            {
                string strMail = string.Empty;
                _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
                _obj_SMHR_LoginInfo.LOGIN_EMP_ID = Convert.ToInt32(rcmbEmployee.SelectedValue);
                _obj_SMHR_LoginInfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_LoginInfo.OPERATION = operation.getLogin;
                DataTable dtLogin = BLL.get_LoginInfo(_obj_SMHR_LoginInfo);
                if (dtLogin.Rows.Count > 0)
                {
                    strMail = Convert.ToString(dtLogin.Rows[0]["LOGIN_EMAILID"]);
                    if (!(strMail == string.Empty))
                    {
                        _obj_smhr_employee = new SMHR_EMPLOYEE();
                        _obj_smhr_employee.OPERATION = operation.Select1;
                        _obj_smhr_employee.EMP_ID = Convert.ToInt32(rcmbEmployee.SelectedValue);
                        DataTable dt = BLL.get_EMP_NEWCONTACTS(_obj_smhr_employee);
                        if (dt.Rows.Count != 0)
                        {
                            _obj_smhr_employee.EMP_ID = Convert.ToInt32(rcmbEmployee.SelectedValue);
                            _obj_smhr_employee.USER_GROUP = Convert.ToInt32(Convert.ToString(dt.Rows[0]["LOGIN_TYPE"]));
                            _obj_smhr_employee.PASSWORD = BLL.PasswordEncrypt(BLL.ReplaceQuote("123456aA"));
                            _obj_smhr_employee.PASSCODE = BLL.PasswordEncrypt(BLL.ReplaceQuote("123456aA")); //Convert.ToString(dt.Rows[0]["LOGIN_PASS_CODE"]);
                            _obj_smhr_employee.OPERATION = operation.Update;
                            BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);
                            BLL.ShowMessage(this, "The password and passcode has been updated as : 123456aA");
                            sendMail();
                            clearControls();
                        }
                        else
                        {

                            _obj_smhr_employee.EMP_ID = Convert.ToInt32(rcmbEmployee.SelectedValue);
                            _obj_smhr_employee.USER_GROUP = Convert.ToInt32(rcmbUserGroup.SelectedItem.Value);
                            _obj_smhr_employee.PASSWORD = BLL.PasswordEncrypt(BLL.ReplaceQuote("123456aA"));
                            _obj_smhr_employee.PASSCODE = BLL.PasswordEncrypt(BLL.ReplaceQuote("123456aA"));
                            _obj_smhr_employee.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_smhr_employee.OPERATION = operation.Insert;
                            BLL.set_EMP_NEWCONTACTS(_obj_smhr_employee);
                            BLL.ShowMessage(this, "The password and passcode has been saved as : 123456aA");
                            sendMail();
                            clearControls();
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Please add mail id for the selected employee in employee screen");
                        return;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Selected Employee does not have Login Credentials.");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PasswordReset", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PasswordReset", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearControls()
    {
        rcmbBusinessUnit.SelectedIndex = 0;
        rcmbEmployee.Items.Clear();
        rcmbEmployee.Items.Insert(0, new RadComboBoxItem("", ""));
        rcmbUserGroup.Items.Clear();
        rcmbUserGroup.Items.Insert(0, new RadComboBoxItem("", ""));
    }

    public void sendMail()
    {
        try
        {
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.LOGIN_EMP_ID = Convert.ToInt32(rcmbEmployee.SelectedValue);
            _obj_SMHR_LoginInfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.OPERATION = operation.getLogin;
            DataTable dtLogin = BLL.get_LoginInfo(_obj_SMHR_LoginInfo);

            SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(rcmbEmployee.SelectedValue);
            //dt_Details = new DataTable();
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtEmployee = BLL.get_Employee(_obj_smhr_employee);

            if (dtLogin.Rows.Count > 0)
            {
                int i_LoginId = Convert.ToInt32(dtLogin.Rows[0]["LOGIN_ID"]);
                DataTable dtLoginInfo = BLL.get_LoginInfo(new SMHR_LOGININFO(Convert.ToInt32(Convert.ToString(i_LoginId))));
                if (dtLoginInfo.Rows.Count > 0)
                {
                    ViewState["email"] = Convert.ToString(dtLoginInfo.Rows[0]["LOGIN_EMAILID"]);
                    ViewState["passcode"] = Convert.ToString(dtLoginInfo.Rows[0]["LOGIN_PASS_CODE"]);
                    SMHR_LOGININFO _obj_Login = new SMHR_LOGININFO();
                    _obj_Login.OPERATION = operation.Check1;
                    _obj_Login.LOGIN_USERNAME = Convert.ToString(dtEmployee.Rows[0]["EMP_EMAILID"]); //Convert.ToString(ViewState["email"]);
                    _obj_Login.LOGIN_PASS_CODE = Convert.ToString(ConfigurationSettings.AppSettings["PassCode"]);   //Convert.ToString(ViewState["passcode"]);
                    _obj_Login.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt = BLL.get_Login_Validate(_obj_Login);
                    if (dt.Rows.Count != 0)
                    {
                        string emp_name = string.Empty;
                        if (dt.Rows[0]["EMP_NAME"] != System.DBNull.Value && Convert.ToString(dt.Rows[0]["EMP_NAME"]).Trim() != string.Empty)
                        {
                            emp_name = Convert.ToString(dt.Rows[0]["EMP_NAME"]);
                        }
                        else
                        {
                            emp_name = Convert.ToString(dtLoginInfo.Rows[0]["LOGIN_EMAILID"]);
                        }

                        string toAddress, subject, body;
                        toAddress = (Convert.ToString(Convert.ToString(dtEmployee.Rows[0]["EMP_EMAILID"])));
                        subject = "Smart HR Password";
                        body = "<html>" +
                                        "<body> " +
                                        "<p>Dear, " + Convert.ToString(emp_name) + " </p> " +
                                        "<p>Welcome to Smart HR Online !</p>" +
                                        "<p>Your password has been reset.</p>" +
                                        "<p>Your new credentials for accessing Smart HR for " + Convert.ToString(dt.Rows[0]["ORGANISATION_NAME"]) + " are <br>" +
                                        "</p> " +
                                        "<p>User name: " + Convert.ToString(ViewState["email"]) + " </p> " +
                                        "<p>Password:  " + Convert.ToString("123456aA") + " </p> " +
                                        "<p>Security Code: " + Convert.ToString("123456aA") + "</p>" +
                                        "This above password is temporary. Please change it later for security reasons.</p>" +
                                        "<p>Best Regards,<br/><br/>" +
                                        "Team Smart HR</p>" +
                                        "</body>" +
                                        " </html>";
                        BLL.SendMail(toAddress, null, subject, body);
                        BLL.ShowMessage(this, "A Mail has been sent to the user");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", "<script type='text/javascript'>Close()</" + "script>", false);
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Security Code is Invalid");
                        return;
                    }
                }
            }
        }
    
    catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PasswordReset", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
     
}
