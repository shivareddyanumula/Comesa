using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;


public partial class Reportss_PensionStatement : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT obj_smhr_Businessunit;
    SMHR_LOGININFO obj_smhr_Logininfo;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    SMHR_EMPLOYEE obj_smhr_Employee;
    SMHR_SALARYSTRUCT _obj_smhr_salaryStruct;
    
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Pension statement");
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
                LoadBusinessUnit();
                LoadSalaryStructure();
                LoadEmployee();
                LoadDates();
                LoadFromDates();
                LoadToDates();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionStatement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadBusinessUnit()
    {
        try
        {
            obj_smhr_Businessunit = new SMHR_BUSINESSUNIT();
            obj_smhr_Logininfo = new SMHR_LOGININFO();
            obj_smhr_Logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            obj_smhr_Logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(obj_smhr_Logininfo);
            if (dt_BUDetails.Rows.Count > 0)
            {
                rcmb_BusinessUnit.DataSource = dt_BUDetails;
                rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BusinessUnit.DataBind();
            }
            //rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
            rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem(Convert.ToString(Session["ORG_NAME"]), "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionStatement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadSalaryStructure()
    {
        try
        {
            rcmb_SalStruct.Items.Clear();
            _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
            _obj_smhr_salaryStruct.ISDELETED = false;
            _obj_smhr_salaryStruct.OPERATION = operation.Select;
            _obj_smhr_salaryStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
            if (dt_Details.Rows.Count > 0)
            {
                rcmb_SalStruct.DataSource = dt_Details;
                rcmb_SalStruct.DataTextField = "SALARYSTRUCT_CODE";
                rcmb_SalStruct.DataValueField = "SALARYSTRUCT_ID";
                rcmb_SalStruct.DataBind();
            }
            rcmb_SalStruct.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("ALL", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionStatement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        
    }
    protected void rcmb_SalStruct_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            LoadEmployee();
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionStatement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            LoadEmployee();
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionStatement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void LoadEmployee()
    {
        try
        {
           
               
                    SMHR_PENSION_CONTRIBUTION objPensionContribution = new SMHR_PENSION_CONTRIBUTION();
                    objPensionContribution.OPERATION = operation.Employee;
                    objPensionContribution.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    objPensionContribution.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                    objPensionContribution.PENSION_SALALRYSTRUCT_ID = Convert.ToInt32(rcmb_SalStruct.SelectedValue);
                    //_obj_Smhr_BusinessUnit.lOANREQUEST_EMPLOYEEID = Convert.ToInt32(Session["USER_ID"]);
                    rcmb_EmployeeName.Items.Clear();
                    DataTable dtEMP = BLL.get_PensionContribution(objPensionContribution);
                    rcmb_EmployeeName.DataSource = dtEMP;
                    rcmb_EmployeeName.DataTextField = "employeename";
                    rcmb_EmployeeName.DataValueField = "emp_id";
                    rcmb_EmployeeName.DataBind();
                    if (dtEMP.Rows.Count > 0)
                        rcmb_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("ALL", "-1"));
                    else
                        rcmb_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    //rcmb_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    //rcmb_EmployeeName.Enabled = false;
        
               
           
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionStatement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
            
       
     private void LoadDates()
    {
        try
        {
            SMHR_PENSION_CONTRIBUTION objPensionContribution = new SMHR_PENSION_CONTRIBUTION();
            objPensionContribution.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            objPensionContribution.OPERATION = operation.Select;
            DataTable dtdates = BLL.get_PensionContribution(objPensionContribution);
            ViewState["Dates"] = dtdates;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionStatement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    private void LoadFromDates()
    {
        try
        {
            rcmb_fromdate.Items.Clear();
            rcmb_fromdate.DataSource = ViewState["Dates"];
            rcmb_fromdate.DataTextField = "PRDDTL_NAME";
            rcmb_fromdate.DataValueField = "PRDDTL_ID";
            rcmb_fromdate.DataBind();
            rcmb_fromdate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionStatement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadToDates()
    {
        try
        {
            rcmb_todate.Items.Clear();
            rcmb_todate.DataSource = ViewState["Dates"];
            rcmb_todate.DataTextField = "PRDDTL_NAME";
            rcmb_todate.DataValueField = "PRDDTL_ID";
            rcmb_todate.DataBind();
            rcmb_todate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionStatement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
     protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_todate.SelectedIndex > rcmb_fromdate.SelectedIndex)
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToInt32(Session["ORG_ID"]) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_EmployeeName.SelectedValue) + "','" + Convert.ToString(rcmb_fromdate.SelectedValue) + "','" + Convert.ToString(rcmb_todate.SelectedValue) + "','" + Convert.ToString(rcmb_SalStruct.SelectedValue) + "');", true);
            else
                BLL.ShowMessage(this, "To Date Must be Greater than From Date");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionStatement", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
     protected void btn_Cancel_Click(object sender, EventArgs e)
     {
         try
         {
             rcmb_fromdate.SelectedIndex = 0;
             rcmb_todate.SelectedIndex = 0;
             rcmb_BusinessUnit.SelectedIndex = 0;
             rcmb_SalStruct.SelectedIndex = 0;
             rcmb_EmployeeName.SelectedIndex = 0;
             //rcmb_EmployeeName.Items.Clear();
             //rcmb_EmployeeName.Text = string.Empty;
         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionStatement", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }



     }
        
    
}