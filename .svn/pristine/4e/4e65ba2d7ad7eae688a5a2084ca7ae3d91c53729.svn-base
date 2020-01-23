using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Pension_frm_AmtTransfertoPensionAct : System.Web.UI.Page
{
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Provident Fund Transfer");
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
                    return;
                }
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    RG_Transfer.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btnSubmit.Visible = false;
                    btnUpdate.Visible = false;
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
                    return;
                }

                LoadGrid();
                RG_Transfer.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AmtTransfertoPensionAct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            SMHR_PENSIONTRANSFERFUNDS objTransferFunds = new SMHR_PENSIONTRANSFERFUNDS();
            objTransferFunds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            objTransferFunds.OPERATION = operation.Select;
            DataTable dtTransferFunds = BLL.get_PensionTransferFunds(objTransferFunds);
            RG_Transfer.DataSource = dtTransferFunds;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AmtTransfertoPensionAct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            //To fetch BusinessUnits
            DataSet ds = BLL.GetEmployeeFilterDetails(Convert.ToInt32(Session["ORG_ID"]), null, null, null);
            rcmb_BusinessUnit.DataSource = ds.Tables[0];
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataBind();
            //rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            //rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("ALL", "0"));
            rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem(Convert.ToString(Session["ORG_NAME"]),"0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AmtTransfertoPensionAct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployees()
    {
        try
        {
            rcmb_Employee.Items.Clear();
            rcmb_Employee.Text = string.Empty;
            rtxt_TransferAmt.Text = string.Empty;
            rtxt_TransferAmt.Enabled = true;
            btnSubmit.Enabled = true;
            SMHR_EMPLOYEE objEmployee = new SMHR_EMPLOYEE();
            objEmployee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            objEmployee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            if (rcmb_Directorate.SelectedIndex > 0)
            {
                objEmployee.EMP_DIRECTORATE_ID = Convert.ToInt32(rcmb_Directorate.SelectedValue);
            }
            if (rcmb_Department.SelectedIndex > 0)
            {
                objEmployee.EMP_DEPARTMENT_ID = Convert.ToInt32(rcmb_Department.SelectedValue);
            }
            objEmployee.OPERATION = operation.Employee;
            DataTable dtEmployees = BLL.get_Employeedetail(objEmployee);
            rcmb_Employee.DataSource = dtEmployees;
            rcmb_Employee.DataTextField = "EMPLOYEENAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AmtTransfertoPensionAct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BusinessUnit.SelectedIndex > 0)
            {
                //To fetch directorates
                DataSet ds = BLL.GetEmployeeFilterDetails(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BusinessUnit.SelectedValue), null, null);
                BindDirectorate(ds.Tables[1]);
                LoadEmployees();
                rcmb_Department.Items.Clear();
                rcmb_Department.Text = string.Empty;

            }
            else
            {
                rcmb_Directorate.Items.Clear();
                rcmb_Directorate.Text = string.Empty;
                rcmb_Department.Items.Clear();
                rcmb_Department.Text = string.Empty;
                rcmb_Employee.Items.Clear();
                rcmb_Employee.Text = string.Empty;
                LoadEmployees();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AmtTransfertoPensionAct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Directorate_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Directorate.SelectedIndex > 0)
            {
                DataSet ds = BLL.GetEmployeeFilterDetails(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BusinessUnit.SelectedValue), Convert.ToInt32(rcmb_Directorate.SelectedValue), null);
                BindDepartment(ds.Tables[2]);

                //To populate employee details
                //BindEmployee(ds.Tables[3]);
                LoadEmployees();
            }
            else
            {
                //DataSet ds = BLL.GetEmployeeFilterDetails(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BusinessUnit.SelectedValue), null, null);
                //BindEmployee(ds.Tables[3]);
                LoadEmployees();
                rcmb_Department.Items.Clear();
                rcmb_Department.ClearSelection();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AmtTransfertoPensionAct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Department_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Department.SelectedIndex > 0)
            {

                //To populate employee details
                //DataSet ds = BLL.GetEmployeeFilterDetails(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BusinessUnit.SelectedValue), Convert.ToInt32(rcmb_Directorate.SelectedValue), Convert.ToInt32(rcmb_Department.SelectedValue));
                //BindEmployee(ds.Tables[3]);
                LoadEmployees();
            }
            else
            {
                //DataSet ds = BLL.GetEmployeeFilterDetails(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BusinessUnit.SelectedValue), Convert.ToInt32(rcmb_Directorate.SelectedValue), null);
                //BindEmployee(ds.Tables[3]);
                LoadEmployees();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AmtTransfertoPensionAct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
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
            rcmb_Directorate.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AmtTransfertoPensionAct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
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
            rcmb_Department.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AmtTransfertoPensionAct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_PENSIONTRANSFERFUNDS objFunds = new SMHR_PENSIONTRANSFERFUNDS();
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTNUPDATE":
                    if (rtxt_TransferAmt.Text == string.Empty)
                    {
                        BLL.ShowMessage(this, "Please enter Amount to Transfer");
                        return;
                    }
                    objFunds.FUNDS_AMOUNT = Convert.ToDecimal(rtxt_TransferAmt.Value);
                    objFunds.FUNDS_EMPID = Convert.ToInt32(ViewState["EMP_ID"]);
                    objFunds.OPERATION = operation.Update;
                    if (BLL.set_PensionTransferFunds(objFunds))
                    {
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    }
                    else
                    {
                        BLL.ShowMessage(this, "An error occured while processing");
                    }
                    break;
                case "BTNSUBMIT":

                    objFunds.FUNDS_ORGID = Convert.ToInt32(Session["ORG_ID"]);
                    objFunds.FUNDS_BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                    objFunds.FUNDS_EMPID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                    objFunds.FUNDS_AMOUNT = Convert.ToDecimal(rtxt_TransferAmt.Value);
                    objFunds.OPERATION = operation.Insert;
                    if (BLL.set_PensionTransferFunds(objFunds))
                    {
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    }
                    else
                    {
                        BLL.ShowMessage(this, "An error occured while processing");
                    }
                    break;
            }
                    ClearControls();
                    LoadGrid();
                    RG_Transfer.DataBind();
                    Rm_CY_page.SelectedIndex = 0;
            
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AmtTransfertoPensionAct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AmtTransfertoPensionAct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearControls()
    {
        try
        {
            //rcmb_BusinessUnit.Items.Clear();
            //rcmb_BusinessUnit.Text = string.Empty;
            rcmb_BusinessUnit.ClearSelection();
            rcmb_Directorate.Items.Clear();
            rcmb_Directorate.Text = string.Empty;
            rcmb_Department.Items.Clear();
            rcmb_Department.Text = string.Empty;
            rcmb_Employee.Items.Clear();
            rcmb_Employee.Text = string.Empty;
            rtxt_TransferAmt.Text = string.Empty;
            Rm_CY_page.SelectedIndex = 0;
            rtxt_TransferAmt.Enabled = true;
            btnSubmit.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AmtTransfertoPensionAct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_Transfer_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            SMHR_PENSIONTRANSFERFUNDS objTransferFunds = new SMHR_PENSIONTRANSFERFUNDS();
            objTransferFunds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            objTransferFunds.OPERATION = operation.Select;
            DataTable dtTransferFunds = BLL.get_PensionTransferFunds(objTransferFunds);
            RG_Transfer.DataSource = dtTransferFunds;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AmtTransfertoPensionAct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnkTransferEdit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();
            btnSubmit.Visible = false;
            rcmb_BusinessUnit.Text = string.Empty;
            SMHR_PENSIONTRANSFERFUNDS objTransferFunds = new SMHR_PENSIONTRANSFERFUNDS();
            objTransferFunds.FUNDS_ID = Convert.ToInt32(e.CommandArgument);
            ViewState["EMP_ID"]=Convert.ToInt32(e.CommandArgument);
            objTransferFunds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            objTransferFunds.OPERATION = operation.Edit;
            DataTable dtTransferFunds = BLL.get_PensionTransferFunds(objTransferFunds);
            if (dtTransferFunds.Rows.Count > 0)
            {
                EnableDisableControls(false);

                rcmb_BusinessUnit.DataSource = dtTransferFunds;
                rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BusinessUnit.DataValueField = "FUNDS_BUID";
                rcmb_BusinessUnit.DataBind();

                rcmb_Directorate.DataSource = dtTransferFunds;
                rcmb_Directorate.DataTextField = "DIRECTORATE_CODE";
                rcmb_Directorate.DataValueField = "";
                rcmb_Directorate.DataBind();

                rcmb_Department.DataSource = dtTransferFunds;
                rcmb_Department.DataTextField = "DEPARTMENT_NAME";
                rcmb_Department.DataValueField = "";
                rcmb_Department.DataBind();

                rcmb_Employee.DataSource = dtTransferFunds;
                rcmb_Employee.DataTextField = "EMP_NAME";
                rcmb_Employee.DataValueField = "FUNDS_EMPID";
                rcmb_Employee.DataBind();

                if (!string.IsNullOrEmpty(Convert.ToString(dtTransferFunds.Rows[0]["BUSINESSUNIT_CODE"])))
                {
                    rcmb_BusinessUnit.Text = Convert.ToString(dtTransferFunds.Rows[0]["BUSINESSUNIT_CODE"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dtTransferFunds.Rows[0]["DIRECTORATE_CODE"])))
                {
                    rcmb_Directorate.Text = Convert.ToString(dtTransferFunds.Rows[0]["DIRECTORATE_CODE"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dtTransferFunds.Rows[0]["DEPARTMENT_NAME"])))
                {
                    rcmb_Department.Text = Convert.ToString(dtTransferFunds.Rows[0]["DEPARTMENT_NAME"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dtTransferFunds.Rows[0]["EMP_NAME"])))
                {
                    rcmb_Employee.Text = Convert.ToString(dtTransferFunds.Rows[0]["EMP_NAME"]);
                }
                rtxt_TransferAmt.Text = Convert.ToString(dtTransferFunds.Rows[0]["FUNDS_AMOUNT"]);
                if (Convert.ToString(dtTransferFunds.Rows[0]["EMP_RELDATE"])=="")
                {
                    rtxt_TransferAmt.Enabled = true;
                    btnUpdate.Visible = true;
                }
                else
                {
                    rtxt_TransferAmt.Enabled = false;
                    btnUpdate.Visible = false;
                }
                Rm_CY_page.SelectedIndex = 1;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AmtTransfertoPensionAct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void EnableDisableControls(bool p)
    {
        try
        {
            rcmb_BusinessUnit.Enabled = p;
            rcmb_Directorate.Enabled = p;
            rcmb_Department.Enabled = p;
            rcmb_Employee.Enabled = p;
            rtxt_TransferAmt.Enabled = p;
            btnSubmit.Enabled = p;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AmtTransfertoPensionAct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            EnableDisableControls(true);
            btnUpdate.Visible = false;
            btnSubmit.Visible = true;
            LoadCombos();
            LoadEmployees();
            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AmtTransfertoPensionAct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Employee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Employee.SelectedIndex > 0)
            {
                SMHR_PENSIONTRANSFERFUNDS objTransferFunds = new SMHR_PENSIONTRANSFERFUNDS();
                //objTransferFunds.FUNDS_ID = Convert.ToInt32(e.CommandArgument);
                objTransferFunds.FUNDS_EMPID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                objTransferFunds.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                objTransferFunds.OPERATION = operation.Check;
                DataTable dtTransferFunds = BLL.get_PensionTransferFunds(objTransferFunds);
                if (dtTransferFunds.Rows.Count > 0)
                {
                    rtxt_TransferAmt.Text = Convert.ToString(dtTransferFunds.Rows[0]["FUNDS_AMOUNT"]);
                    rtxt_TransferAmt.Enabled = false;
                    btnSubmit.Enabled = false;
                }
                else
                {
                    rtxt_TransferAmt.Text = string.Empty;
                    rtxt_TransferAmt.Enabled = true;
                    btnSubmit.Enabled = true;
                }
            }
            else
            {
                rtxt_TransferAmt.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AmtTransfertoPensionAct", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}