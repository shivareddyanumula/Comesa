using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Pension_frm_PensionFFS : System.Web.UI.Page
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Full and Final Settlement");
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
                    RG_PensionFFS.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btnSave.Visible = false;
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
                RG_PensionFFS.DataBind();
                //To load BusinessUnits
                //LoadCombos();
                lblHeading.Text = "Part, Full and Final Settlement";
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region LoadCombos

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
            rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployees()
    {
        try
        {
            rcmb_Employee.Items.Clear();
            rcmb_Employee.Text = string.Empty;
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
            objEmployee.OPERATION = operation.Chk;
            DataTable dtEmployees = BLL.get_Employeedetail(objEmployee);
            rcmb_Employee.DataSource = dtEmployees;
            rcmb_Employee.DataTextField = "EMPLOYEENAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployeeDetails()
    {
        try
        {
            SMHR_EMPLOYEE objEmpDtls = new SMHR_EMPLOYEE();
            objEmpDtls.EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
            objEmpDtls.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            objEmpDtls.MODE = 1;
            DataTable dtEmpDtls = BLL.get_EmployeeDtls(objEmpDtls);
            if (dtEmpDtls.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtEmpDtls.Rows[0]["IsPartialPayment"]))//Is partial payment
                {
                    trPayItem.Visible = true;
                    rcmb_SettlementType.Enabled = true;
                    hdnIsPartialPaymnt.Value = Convert.ToString(dtEmpDtls.Rows[0]["IsPartialPayment"]);
                    rdtpSettlementDate.MinDate = Convert.ToDateTime(dtEmpDtls.Rows[0]["EMP_RELDATE"]);
                    rdtpSettlementDate.SelectedDate = DateTime.Today;
                    rtxt_Amount.Text = Convert.ToString(Convert.ToDouble(rtxt_TotPensionAmt.Value) - Convert.ToDouble(rtxt_AmtDisbursed.Value));
                    rtxt_Amount.Enabled = true;
                }
                else
                {
                    if (Convert.ToString(dtEmpDtls.Rows[0]["RelievingReason"]) == "Death")
                    {
                        rcmb_WithdrawlType.SelectedIndex = rcmb_WithdrawlType.FindItemIndexByValue(Convert.ToString("Family"));
                        rcmb_WithdrawlType.Enabled = false;
                        rcmb_WithdrawlType_SelectedIndexChanged(null, null);
                    }
                    rcmb_SettlementType.SelectedIndex = rcmb_SettlementType.FindItemIndexByValue(Convert.ToString(dtEmpDtls.Rows[0]["FullSettlementID"]));
                    rcmb_SettlementType.Enabled = false;
                    trPayItem.Visible = false;
                    rtxt_Amount.Text = Convert.ToString(Convert.ToDouble(rtxt_TotPensionAmt.Value) - Convert.ToDouble(rtxt_AmtDisbursed.Value));
                    rtxt_Amount.Enabled = false;
                    rdtpSettlementDate.MinDate = Convert.ToDateTime(dtEmpDtls.Rows[0]["EMP_RELDATE"]);
                    rdtpSettlementDate.SelectedDate = DateTime.Today;
                    hdnIsPartialPaymnt.Value = Convert.ToString(dtEmpDtls.Rows[0]["IsPartialPayment"]);
                }
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadPensionAmount()
    {
        try
        {
            SMHR_EMPLOYEE objEmployee = new SMHR_EMPLOYEE();
            objEmployee.EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
            objEmployee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            objEmployee.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            DataTable dtPensionAmt = BLL.get_PensionFNF(objEmployee);
            if (dtPensionAmt.Rows.Count > 0)
            {
                rtxt_TotPensionAmt.Text = Convert.ToString(dtPensionAmt.Rows[0]["FFS_AMOUNT"]);
                rtxt_AmtDisbursed.Text = Convert.ToString(dtPensionAmt.Rows[0]["WITHDRAWL"]);
                rtxt_BalAmt.Text = Convert.ToString(dtPensionAmt.Rows[0]["WITHDRAWL_BALANCE"]);
                hdnFFSID.Value = Convert.ToString(dtPensionAmt.Rows[0]["FFS_ID"]);
                //rtxt_Amount.Text = Convert.ToString(Convert.ToDouble(dtPensionAmt.Rows[0]["FFS_AMOUNT"]) - Convert.ToDouble(dtPensionAmt.Rows[0]["WITHDRAWL"]));
                //rtxt_Amount.MaxValue = Convert.ToDouble(dtPensionAmt.Rows[0]["WITHDRAWL_BALANCE"]);
            }
            else
            {
                rtxt_TotPensionAmt.Text = string.Empty;
                rtxt_AmtDisbursed.Text = string.Empty;
                rtxt_BalAmt.Text = string.Empty;
                hdnFFSID.Value = null;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadPayItems()
    {
        try
        {
            SMHR_MASTERS objMaster = new SMHR_MASTERS();
            objMaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            objMaster.MASTER_TYPE = "PENSIONWITHDRAWL";
            objMaster.MODE = 3;
            DataTable dtSettlemts = BLL.get_MasterRecords(objMaster);
            rcmb_PayItem.DataSource = dtSettlemts;
            rcmb_PayItem.DataValueField = "HR_MASTER_ID";
            rcmb_PayItem.DataTextField = "HR_MASTER_CODE";
            rcmb_PayItem.DataBind();
            rcmb_PayItem.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadSettlement()
    {
        try
        {
            SMHR_MASTERS objMaster = new SMHR_MASTERS();
            objMaster.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            objMaster.MASTER_TYPE = "SETTLEMENT";
            objMaster.MODE = 3;
            DataTable dtSettlemts = BLL.get_MasterRecords(objMaster);
            rcmb_SettlementType.DataSource = dtSettlemts;
            rcmb_SettlementType.DataValueField = "HR_MASTER_ID";
            rcmb_SettlementType.DataTextField = "HR_MASTER_CODE";
            rcmb_SettlementType.DataBind();
            rcmb_SettlementType.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadRelation()
    {
        try
        {
            rcmb_Relation.Items.Clear();
            rcmb_Relation.Text = string.Empty;
            SMHR_EMPLOYEE objRelation = new SMHR_EMPLOYEE();
            objRelation.EMPFMDTL_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
            objRelation.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            objRelation.OPERATION = operation.Check;
            DataTable dtRelations = BLL.get_EmployeeFamily(objRelation);
            if (dtRelations.Rows.Count > 0)
            {
                rcmb_Relation.DataSource = dtRelations;
                rcmb_Relation.DataTextField = "EMPFMDTL_EMPREL_NAME";
                rcmb_Relation.DataValueField = "EMPFMDTL_EMPREL_ID";
                rcmb_Relation.DataBind();
                rcmb_Relation.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
            else
            {
                rcmb_Relation.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                //rfv_rcmb_Relation.Visible = false;
            }
            
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region SelectedIndexChanged

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
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
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
                rcmb_Department.Items.Insert(0,new RadComboBoxItem ("Select","0"));

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Employee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Employee.SelectedIndex > 0)
            {
                LoadRelation(); //To populate relations of the selected employee
                LoadSettlement();   //To populate settlementType as per organisation
                LoadPayItems(); //To populate payitems as per organisation
                LoadPensionAmount();    //To populate pension amounts
                LoadEmployeeDetails();
                Rm_CY_page.SelectedIndex = 1;
            }
            else
            {
                rtxt_TotPensionAmt.Text = string.Empty;
                rtxt_AmtDisbursed.Text = string.Empty;
                rtxt_BalAmt.Text = string.Empty;
                rcmb_SettlementType.ClearSelection();
                rtxt_Amount.Value = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Relation_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Relation.SelectedIndex > 0)
            {
                SMHR_EMPLOYEE objRelation = new SMHR_EMPLOYEE();
                objRelation.EMPFMDTL_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                objRelation.EMPFMDTL_EMPREL_ID = Convert.ToInt32(rcmb_Relation.SelectedValue);
                objRelation.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                objRelation.OPERATION = operation.Chk;
                DataTable dtRelations = BLL.get_EmployeeFamily(objRelation);
                if (dtRelations.Rows.Count > 0)
                {
                    rtxt_Beneficiary.Text = Convert.ToString(dtRelations.Rows[0]["EMPFMDTL_NAME"]);
                }
                else
                {
                    rtxt_Beneficiary.Text = string.Empty;
                }
            }
            else
            {
                rtxt_Beneficiary.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //if (rcmb_Relation.SelectedIndex <= 0)
            //{
            //    BLL.ShowMessage(this, "Please Select Relation");
            //    return;
            //}
            if (rtxt_Amount.Value <= 0)
            {
                BLL.ShowMessage(this, "Insufficient Pension Balance");
                return;
            }
            SMHR_PENSION_WITHDRAWL objPensionWithdrwl = new SMHR_PENSION_WITHDRAWL();
            objPensionWithdrwl.WITHDRAWL_WITHDRAWLAMOUNT = Convert.ToDouble(rtxt_Amount.Value);
            if (trPayItem.Visible == true)
            {
                objPensionWithdrwl.WITHDRAWL_PAYITEMID = Convert.ToInt32(rcmb_PayItem.SelectedValue);
            }
            objPensionWithdrwl.WITHDRAWL_FFS_ID = Convert.ToInt32(hdnFFSID.Value);
            objPensionWithdrwl.WITHDRAWL_SETTLEMENTTYPE = Convert.ToInt32(rcmb_SettlementType.SelectedValue);
            objPensionWithdrwl.WITHDRAWL_SETTLEMENTDATE = Convert.ToDateTime(rdtpSettlementDate.SelectedDate);
            objPensionWithdrwl.WITHDRAWL_BENEFICIARY = Convert.ToString(rtxt_Beneficiary.Text);
            objPensionWithdrwl.WITHDRAWL_BALANCE = Convert.ToDouble(rtxt_TotPensionAmt.Value) - Convert.ToDouble(rtxt_AmtDisbursed.Value) - Convert.ToDouble(rtxt_Amount.Value);
            objPensionWithdrwl.WITHDRAWL_RELATIONTYPE = Convert.ToInt32(rcmb_Relation.SelectedValue);
            objPensionWithdrwl.WITHDRAWL_WITHDRAWLTYPE = Convert.ToString(rcmb_WithdrawlType.SelectedValue);
            objPensionWithdrwl.OPERATION = operation.Insert;
            if (BLL.set_PENSION_WITHDRAWL(objPensionWithdrwl))
            {
                BLL.ShowMessage(this, "Information Saved Successfully");
                clearControls();
            }
            else
            {
                BLL.ShowMessage(this, "Error occured while processing");
                clearControls();
            }

            LoadGrid();
            RG_PensionFFS.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearControls()
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
            rtxt_TotPensionAmt.Text = string.Empty;
            rtxt_AmtDisbursed.Text = string.Empty;
            rtxt_BalAmt.Text = string.Empty;
            hdnFFSID.Value = null;
            hdnIsPartialPaymnt.Value = null;
            rcmb_Relation.Items.Clear();
            rcmb_Relation.Text = string.Empty;
            rtxt_Beneficiary.Text = string.Empty;
            rcmb_SettlementType.Items.Clear();
            rcmb_SettlementType.Text = string.Empty;
            rtxt_Amount.Text = string.Empty;
            rdtpSettlementDate.SelectedDate = null;
            Rm_CY_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RG_PensionFFS_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            SMHR_PENSION_WITHDRAWL objPensionWithdrwl = new SMHR_PENSION_WITHDRAWL();
            objPensionWithdrwl.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            objPensionWithdrwl.OPERATION = operation.Select;
            DataTable dtPensioWithdrwl = BLL.get_PENSION_WITHDRAWL(objPensionWithdrwl);
            RG_PensionFFS.DataSource = dtPensioWithdrwl;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
            LoadCombos();
            EnableDisableContols(true);
            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnkWithdrawlEdit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearControls();
            EnableDisableContols(false);
            rcmb_BusinessUnit.Items.Clear();
            SMHR_PENSION_WITHDRAWL objPensionWithdrwl = new SMHR_PENSION_WITHDRAWL();
            objPensionWithdrwl.WITHDRAWL_ID = Convert.ToInt32(e.CommandArgument);
            objPensionWithdrwl.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            objPensionWithdrwl.OPERATION = operation.Edit;
            DataTable dtPensionWithdrwl = BLL.get_PENSION_WITHDRAWL(objPensionWithdrwl);
            if (dtPensionWithdrwl.Rows.Count > 0)
            {
                //To populate pension amounts
                #region LoadPensionAmounts
                SMHR_EMPLOYEE objEmployee = new SMHR_EMPLOYEE();
                objEmployee.EMP_ID = Convert.ToInt32(dtPensionWithdrwl.Rows[0]["EMP_ID"]);
                objEmployee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                objEmployee.BUID = Convert.ToInt32(dtPensionWithdrwl.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                DataTable dtPensionAmt = BLL.get_PensionFNF(objEmployee);
                if (dtPensionAmt.Rows.Count > 0)
                {
                    rtxt_TotPensionAmt.Text = Convert.ToString(dtPensionAmt.Rows[0]["FFS_AMOUNT"]);
                    rtxt_AmtDisbursed.Text = Convert.ToString(dtPensionAmt.Rows[0]["WITHDRAWL"]);
                    rtxt_BalAmt.Text = Convert.ToString(dtPensionAmt.Rows[0]["WITHDRAWL_BALANCE"]);
                    //hdnFFSID.Value = Convert.ToString(dtPensionAmt.Rows[0]["FFS_ID"]);
                    //rtxt_Amount.MaxValue = Convert.ToDouble(dtPensionAmt.Rows[0]["WITHDRAWL_BALANCE"]);
                }
                else
                {
                    rtxt_TotPensionAmt.Text = string.Empty;
                    rtxt_AmtDisbursed.Text = string.Empty;
                    rtxt_BalAmt.Text = string.Empty;
                    hdnFFSID.Value = null;
                }
                #endregion
                rtxt_BalAmt.Text = Convert.ToString(dtPensionWithdrwl.Rows[0]["WITHDRAWL_BALANCE"]);

                if (!string.IsNullOrEmpty(Convert.ToString(dtPensionWithdrwl.Rows[0]["BUSINESSUNIT_CODE"])))
                {
                    rcmb_BusinessUnit.Text = Convert.ToString(dtPensionWithdrwl.Rows[0]["BUSINESSUNIT_CODE"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dtPensionWithdrwl.Rows[0]["DIRECTORATE_CODE"])))
                {
                    rcmb_Directorate.Text = Convert.ToString(dtPensionWithdrwl.Rows[0]["DIRECTORATE_CODE"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dtPensionWithdrwl.Rows[0]["DEPARTMENT_NAME"])))
                {
                    rcmb_Department.Text = Convert.ToString(dtPensionWithdrwl.Rows[0]["DEPARTMENT_NAME"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dtPensionWithdrwl.Rows[0]["EMP_NAME"])))
                {
                    rcmb_Employee.Text = Convert.ToString(dtPensionWithdrwl.Rows[0]["EMP_NAME"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dtPensionWithdrwl.Rows[0]["WITHDRAWL_WITHDRAWLTYPE"])))
                {
                    //rcmb_WithdrawlType.Text = Convert.ToString(dtPensionWithdrwl.Rows[0]["WITHDRAWL_WITHDRAWLTYPE"]);
                    rcmb_WithdrawlType.SelectedIndex = rcmb_WithdrawlType.FindItemIndexByValue(Convert.ToString(dtPensionWithdrwl.Rows[0]["WITHDRAWL_WITHDRAWLTYPE"]));

                    if (string.Compare(Convert.ToString(dtPensionWithdrwl.Rows[0]["WITHDRAWL_WITHDRAWLTYPE"]), "Family", true) == 0)
                        trRelation.Visible = true;
                    else
                        trRelation.Visible = false;
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dtPensionWithdrwl.Rows[0]["RELATION"])))
                {
                    rcmb_Relation.Text = Convert.ToString(dtPensionWithdrwl.Rows[0]["RELATION"]);
                }
                rtxt_Beneficiary.Text = Convert.ToString(dtPensionWithdrwl.Rows[0]["WITHDRAWL_BENEFICIARY"]);

                if (!string.IsNullOrEmpty(Convert.ToString(dtPensionWithdrwl.Rows[0]["SETTLEMENT_TYPE"])))
                {
                    rcmb_SettlementType.Text = Convert.ToString(dtPensionWithdrwl.Rows[0]["SETTLEMENT_TYPE"]);
                }
                
                rtxt_Amount.Text = Convert.ToString(dtPensionWithdrwl.Rows[0]["WITHDRAWL_WITHDRAWLAMOUNT"]);
                rdtpSettlementDate.SelectedDate = Convert.ToDateTime(dtPensionWithdrwl.Rows[0]["WITHDRAWL_SETTLEMENTDATE"]);
                Rm_CY_page.SelectedIndex = 1;
            }
            else
            {
                clearControls();
                Rm_CY_page.SelectedIndex = 0;
                BLL.ShowMessage(this, "No data found");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void EnableDisableContols(bool flag)
    {
        try
        {
            rcmb_BusinessUnit.Enabled = flag;
            rcmb_Directorate.Enabled = flag;
            rcmb_Department.Enabled = flag;
            rcmb_Employee.Enabled = flag;
            rcmb_Relation.Enabled = flag;
            rtxt_Beneficiary.Enabled = flag;
            rcmb_SettlementType.Enabled = flag;
            rtxt_Amount.Enabled = flag;
            rdtpSettlementDate.Enabled = flag;

            rcmb_WithdrawlType.Enabled = flag;
            rtxt_TotPensionAmt.Enabled = flag;
            rtxt_AmtDisbursed.Enabled = flag;
            rtxt_BalAmt.Enabled = flag;
            btnSave.Visible = flag;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_WithdrawlType_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_WithdrawlType.SelectedIndex > 0)
            {
                if (string.Compare(rcmb_WithdrawlType.SelectedItem.Text, "Family", true) == 0)
                {
                    trBeneficiary.Visible = true;
                    rtxt_Beneficiary.Text = string.Empty;
                    trRelation.Visible = true;
                    LoadRelation();

                    //radBenficaryName.Items.Clear();
                    //radBenficaryName.ClearSelection();
                    //radBenficaryName.Text = string.Empty;
                    //radRelation.Items.Clear();
                    //radRelation.ClearSelection();
                    //radRelation.Text = string.Empty;
                    //trBenficaryName.Visible = true;
                    //trRelation.Visible = true;
                    //SMHR_EMPLOYEE obj_smhr_employee = new SMHR_EMPLOYEE();
                    //obj_smhr_employee.OPERATION = operation.Get;
                    //obj_smhr_employee.EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                    //DataTable dt = BLL.get_EmployeeFamily(obj_smhr_employee);
                    ////Session["BenficaryDetails"] = dt;
                    //radBenficaryName.DataSource = dt;
                    //radBenficaryName.DataTextField = "EMPFMDTL_NAME";
                    //radBenficaryName.DataValueField = "EMPFMDTL_SERIAL";
                    //radBenficaryName.DataBind();
                    //radBenficaryName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                }
                else
                {
                    trRelation.Visible = false;
                    trBeneficiary.Visible = false;
                    return;
                }
            }
            else
            {
                trRelation.Visible = false;
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PensionFFS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}