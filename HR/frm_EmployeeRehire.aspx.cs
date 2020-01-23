using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using System.IO;
using System.Collections;
using System.Text;

public partial class HR_frm_EmployeeRehire : System.Web.UI.Page
{
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    SMHR_EMPLOYEE _obj_Smhr_Employee;
    SMHR_APPLICANT _obj_smhr_applicant;
    SMHR_GLOBALCONFIG _obj_smhr_globalconfig;
    DataTable dt_Details;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE RE-HIRE PROCESS");
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
                    btn_Hire.Visible = false;

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
            }
            Page.Validate();
            if (ViewState["IsPostBack"] == null)
            {
                LoadRelievedEmployees();
                btn_Hire.Visible = true;
                ViewState["IsPostBack"] = 1;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeRehire", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void LoadRelievedEmployees()
    {
        try
        {
            _obj_Smhr_Employee = new SMHR_EMPLOYEE();
            _obj_Smhr_Employee.OPERATION = operation.Empty;
            _obj_Smhr_Employee.EMP_RELDATE = Convert.ToDateTime("1/1/1900");

            rcmb_RelEmpID.Items.Clear();
            _obj_Smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_Employee(_obj_Smhr_Employee);
            rcmb_RelEmpID.DataSource = dt_Details;
            rcmb_RelEmpID.DataTextField = "EMPNAME";
            rcmb_RelEmpID.DataValueField = "EMP_ID";
            rcmb_RelEmpID.DataBind();
            rcmb_RelEmpID.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeRehire", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcmb_RelEmpID_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //getEmpCode();
        //
    }

    protected void btn_Hire_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_ORGANISATION _obj_Smhr_Organisation = new SMHR_ORGANISATION();
            _obj_Smhr_Organisation.MODE = 8;
            _obj_Smhr_Organisation.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_Organisation(_obj_Smhr_Organisation);
            SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.EmployeeCount;
           _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
           DataTable dtDetails = BLL.get_Employee(_obj_smhr_employee);
           string Val = BLL.PasswordDecrypt(Convert.ToString(dt.Rows[0]["ORGANISATION_EMPLOYEES"]));
           string strVal = Convert.ToString(dtDetails.Rows[0]["EMPCOUNT"]);
           if (dtDetails.Rows.Count != 0)
           {
               if (Val != strVal)
               {
                   if (Convert.ToInt32(Val) > Convert.ToInt32(strVal))
                   {
                       RehireProcess();
                   }
                   else
                   {
                       BLL.ShowMessage(this, "You have only limited no of users License. You cannot create more employees");
                       return;
                   }

               }
               else
               {
                   BLL.ShowMessage(this, "You have only limited no of users License. You cannot create more employees");
                   return;
               }
           }
           else
           {
               RehireProcess();
           }
                               
           
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeRehire", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void RehireProcess()
    {
        try
        {
            //if (Convert.ToString(Session["EMPCODE_MANUAL"]) == "True")
            //{
            //    SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
            //    _obj_smhr_employee.OPERATION = operation.Get;
            //    _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    _obj_smhr_employee.EMP_EMPCODE = rtxt_empcode.Text;
            //    if (Convert.ToString(BLL.get_empcode(_obj_smhr_employee).Rows[0]["Count"]) != "0")
            //    {
            //        BLL.ShowMessage(this, "Employee Code Already Exists");
            //        rtxt_empcode.Text = string.Empty;
            //        rtxt_empcode.Focus();
            //        return;
            //    }
            //}
            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.OPERATION = operation.Select3;
            _obj_smhr_logininfo.LOGIN_EMP_ID = Convert.ToInt32(rcmb_RelEmpID.SelectedItem.Value);
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_emp = BLL.get_LoginInfo(_obj_smhr_logininfo);
            if (dt_emp.Rows.Count > 0)
            {
                Session["RelDate"] = Convert.ToDateTime(dt_emp.Rows[0]["EMP_RELDATE"]);
            }
            _obj_Smhr_Employee = new SMHR_EMPLOYEE();
            _obj_Smhr_Employee.OPERATION = operation.Insert;
            //if (Convert.ToString(Session["EMPCODE_MANUAL"]) == "True")
            //{
            //    _obj_Smhr_Employee.EMP_EMPCODE = rtxt_empcode.Text;
            //}
            //else
            //{
            //    lbl_EmployeeNewID.Text = getEmpCode();
            //    _obj_Smhr_Employee.EMP_EMPCODE = lbl_EmployeeNewID.Text;
            //}
            _obj_Smhr_Employee.EMPFMDTL_NAME = Convert.ToString(getCode()); //Applicant Name
            _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(rcmb_RelEmpID.SelectedItem.Value);
            _obj_Smhr_Employee.EMP_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_Employee.EMP_CREATEDDATE = DateTime.Now;
            _obj_Smhr_Employee.EMP_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Smhr_Employee.EMP_LASTMDFDATE = DateTime.Now;
            _obj_Smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Employee.EMP_EMPLOYEETYPE = Convert.ToString(rcmb_EmpType.SelectedItem.Text).Trim();
            _obj_Smhr_Employee.OPERATION = operation.Insert;
            bool status = false;
            //NOT DONE
            status = BLL.set_RehireEmployee(_obj_Smhr_Employee);
            if (status == true)
            {
                BLL.ShowMessage(this, "Employee Recreated Successfully");
                // ClearControls();
                _obj_Smhr_Employee = new SMHR_EMPLOYEE();
                _obj_Smhr_Employee.OPERATION = operation.CheckEmp;
                //if (Convert.ToString(Session["EMPCODE_MANUAL"]) == "True")
                //{
                //    _obj_Smhr_Employee.EMP_EMPCODE = rtxt_empcode.Text;
                //}
                //else
                //{
                //    _obj_Smhr_Employee.EMP_EMPCODE = lbl_EmployeeNewID.Text;
                //}
                _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(rcmb_RelEmpID.SelectedItem.Value);
                _obj_Smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_Employee(_obj_Smhr_Employee);
                //string lbl_EMP_ID = Convert.ToString(dt.Rows[0]["EMP_ID"]);
                Session["Rehire"] = true;
                Response.Redirect("~/HR/frmemployeeadd.aspx?EID=" + Convert.ToString(dt.Rows[0]["EMP_ID"]) + "&Status=R", false);
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeRehire", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void ClearControls()
    {
        try
        {
            rcmb_RelEmpID_SelectedIndexChanged(null, null);
            rcmb_RelEmpID.SelectedIndex = -1;
            rcmb_EmpType.SelectedIndex = -1;
            lbl_EmployeeNewID.Text = String.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeRehire", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private string getCode()
    {
        string Appcode = string.Empty;
        try
        {

            string code = string.Empty;
            string str = string.Empty;
            string Series = string.Empty;


            _obj_smhr_globalconfig = new SMHR_GLOBALCONFIG();
            _obj_smhr_globalconfig.OPERATION = operation.Select;
            _obj_smhr_globalconfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_ConfigDetails(_obj_smhr_globalconfig);
            if (dt_Details.Rows.Count != 0)
            {
                str = Convert.ToString(Convert.ToInt32(dt_Details.Rows[0][2]) + 1).Trim();
                if (str.Length == 1)
                {
                    Series = "000";
                }
                else if (str.Length == 2)
                {
                    Series = "00";
                }
                else if (str.Length == 3)
                {
                    Series = "00";
                }
                else if (str.Length == 4)
                {
                    Series = "0";
                }
                //_obj_smhr_globalconfig = new SMHR_GLOBALCONFIG();
                //_obj_smhr_globalconfig.OPERATION = operation.Select;
                //DataTable dt = BLL.get_ConfigDetails(_obj_smhr_globalconfig);
                Appcode = dt_Details.Rows[0]["GLOBALCONFIG_APP_CODE"].ToString().Trim() + Convert.ToString(Series) + Convert.ToString(str);

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeRehire", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }
        return Appcode;
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_RelEmpID.SelectedIndex = 0;
            rcmb_EmpType.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmployeeRehire", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
