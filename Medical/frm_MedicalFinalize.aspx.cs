﻿using SMHR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Approval_frm_MedicalFinalize : System.Web.UI.Page
{
    string strfilename2;
    DataSet ds = new DataSet();
    SMHR_MedicalClaim _obj_Smhr_MedicalClaim;
    SMHR_LOGININFO _obj_smhr_logininfo;
    SMHR_LOGINTYPE _obj_Smhr_LoginInfo;
    SMHR_CURRENCY _obj_smhr_Currency;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (RWM_POSTREPLY1.Windows.Count > 0)
            {
                RWM_POSTREPLY1.Windows.RemoveAt(0);
            }
            if (!IsPostBack)
            {
                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Medical Benifits Claim Approve");
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
                    Rg_MedicalClaim.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Update.Visible = false;
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
                //rdpInvoiceDate.MaxDate = DateTime.Now;
                Page.Validate();
                // BindExpen

                BindServiceProviders();

                LoadGrid();
                Rg_MedicalClaim.DataBind();

                if (Convert.ToString(Request.QueryString["medSts"]) == "2")     //to get only 'Confirmed' Status of records to be displayed in the grid
                {
                    string exprsn = "(it[\"MED_STATUS\"].ToString().ToUpper().Contains(\"1\".ToUpper()))";

                    Rg_MedicalClaim.MasterTableView.FilterExpression = exprsn;
                    Rg_MedicalClaim.Rebind();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_MedicalClaim_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            chk_Rule.Enabled = false;
            btn_Edit.Visible = true;
            rdpInvoiceDate.Enabled = false;
            FBrowse.Enabled = false;
            //btn_Save.Visible = false;
            rcmb_Currency.Enabled = false;
            radAmount.Enabled = false;
            //getting previous month for particular date i.e:25th of previous month
            var previousDate = DateTime.Now.AddMonths(-1);

            var mindate = new DateTime(previousDate.Year, previousDate.Month, 1);

            rdpInvoiceDate.MinDate = mindate;

            //getting current month for particular date i.e:24th of current month
            var maxdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            rdpInvoiceDate.MaxDate = maxdate;

            ViewState["str"] = "edit";
            clearControls();
            rcbFinPeriod.Enabled = false;
            LoadFinancialPeriod();
            LoadToCurrency();   //loading currency
            _obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();
            _obj_Smhr_MedicalClaim.OPERATION = operation.Get;
            _obj_Smhr_MedicalClaim.ClaimID = Convert.ToInt32(e.CommandArgument);
            lbl_MedicalClaimID.Text = _obj_Smhr_MedicalClaim.ClaimID.ToString();
            _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
            if (dt.Rows.Count <= 0)
            {
                BLL.ShowMessage(this, "No data exist.");
                return;
            }
            rnt_CurrencyAmt.Text = Convert.ToString(dt.Rows[0]["MED_CURR_AMT"]);   //currency amt
            rnt_maxcurramt.Text = Convert.ToString(dt.Rows[0]["MED_CONVERSION_AMT"]);
            rcmb_Currency.SelectedIndex = rcmb_Currency.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["MED_CURR_ID"]));   //currency
            if (dt.Rows[0]["MED_ISRULEID"] != System.DBNull.Value)
            {
                chk_Rule.Checked = Convert.ToBoolean(dt.Rows[0]["MED_ISRULEID"]);
            }
            BindExpenditureNames();
            RadClaimType.SelectedIndex = RadClaimType.FindItemIndexByValue(dt.Rows[0]["SELF_FAMILY"].ToString());
            radExpenditureName.SelectedIndex = radExpenditureName.FindItemIndexByValue(dt.Rows[0]["EXPENDITUREID"].ToString());
            rcbFinPeriod.SelectedIndex = rcbFinPeriod.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["FIN_PRD_ID"]));
            BindServiceProviders(); //To populate ServiceProviders
            ViewState["invDoc"] = Convert.ToString(dt.Rows[0]["INVOICEDOCUMENT"]);
            if (Convert.ToInt32(dt.Rows[0]["SERVICEPROVIDERID"]) == -1)
            {
                trMedicalSvcPrvdr.Visible = true;
                radMedicalServiceProvider.Text = dt.Rows[0]["SERVICEPROVIDERNAME"].ToString();
                RadServiceProviderName.SelectedIndex = RadServiceProviderName.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SERVICEPROVIDERID"]));
            }
            else
            {
                trMedicalSvcPrvdr.Visible = false;
                RadServiceProviderName.SelectedIndex = RadServiceProviderName.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SERVICEPROVIDERID"]));
            }
            //radMedicalServiceProvider.Text = dt.Rows[0]["SERVICEPROVIDERNAME"].ToString();

            radInvoiceID.Text = dt.Rows[0]["INVOICEID"].ToString();
            radInvoiceID.Enabled = false;
            //ControlsEnableorDisable(false);
            AssignvaluesToUserControl(dt);
            rcmb_Employee.Enabled = false;
            RadClaimType.Enabled = false;
            radBenficaryName.Enabled = false;

            radGradeName.DataSource = dt;
            radGradeName.DataValueField = "EMPLOYEEGRADE_ID";
            radGradeName.DataTextField = "EMPLOYEEGRADE_CODE";
            radGradeName.DataBind();
            radExpenditureName_SelectedIndexChanged(null, null);
            rntbRule80.Text = Convert.ToString(dt.Rows[0]["MED_FINAL_AMNT"]);
            radAmount.Text = Convert.ToString(dt.Rows[0]["AMOUNT"]);
            hf_Claimamount.Value = Convert.ToString(dt.Rows[0]["AMOUNT"]);
            ViewState["radAmount"] = radAmount.Text;
            ViewState["curramt"] = rnt_CurrencyAmt.Text;
            if (!string.IsNullOrEmpty(dt.Rows[0]["DATE"].ToString()))
            {
                var minDate = (new DateTime((DateTime.Now.AddMonths(-1)).Year, (DateTime.Now.AddMonths(-1)).Month, 1));
                var maxDate = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));

                // if (Convert.ToDateTime(dt.Rows[0]["DATE"]) > minDate && Convert.ToDateTime(dt.Rows[0]["DATE"]) > maxDate || Convert.ToDateTime(dt.Rows[0]["DATE"]) < minDate && Convert.ToDateTime(dt.Rows[0]["DATE"]) < maxDate)
                if (Convert.ToDateTime(dt.Rows[0]["DATE"]) > minDate && Convert.ToDateTime(dt.Rows[0]["DATE"]) > maxDate)

                    // rdpInvoiceDate.SelectedDate = null;
                    // if (Convert.ToDateTime(dt.Rows[0]["DATE"]) >= minDate && Convert.ToDateTime(dt.Rows[0]["DATE"]) >= maxDate)
                    //  if (Convert.ToDateTime(dt.Rows[0]["DATE"]) <= minDate && Convert.ToDateTime(dt.Rows[0]["DATE"]) <= maxDate)
                    rdpInvoiceDate1.SelectedDate = null;
                else
                {
                    rdpInvoiceDate1.SelectedDate = Convert.ToDateTime(dt.Rows[0]["DATE"]); //latTextBox1.Text.Length == 0 ? 0 : latTextBox1.Text
                    rdpInvoiceDate.Visible = false;
                    rdpInvoiceDate1.Visible = true;
                }

            }
            if (string.Compare(dt.Rows[0]["SELF_FAMILY"].ToString(), "Family", true) == 0)
            {
                SMHR_EMPLOYEE obj_smhr_employee = new SMHR_EMPLOYEE();
                obj_smhr_employee.OPERATION = operation.Get;
                obj_smhr_employee.EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                //DataTable dtBenificiary = BLL.get_EmployeeFamily(obj_smhr_employee);

                _obj_Smhr_MedicalClaim.OPERATION = operation.Empty;
                _obj_Smhr_MedicalClaim.EmpID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                DataTable dtBenificiary = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);

                radBenficaryName.DataSource = dtBenificiary;
                radBenficaryName.DataTextField = "EMPFMDTL_NAME";
                radBenficaryName.DataValueField = "EMPFMDTL_ID";       //EMPFMDTL_PRIORITY // "EMPFMDTL_SERIAL";
                radBenficaryName.DataBind();
                radBenficaryName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                radBenficaryName.SelectedIndex = radBenficaryName.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BENFICIARYSERIALID"]));

                trBenficaryName.Visible = true;
                trRelation.Visible = true;
                //radBenficaryName.DataSource = dt;
                //radBenficaryName.DataValueField = "BENFICIARYSERIALID";
                //radBenficaryName.DataTextField = "BENFICIARYNAME";
                //radBenficaryName.DataBind();

                radRelation.DataSource = dt;
                radRelation.DataValueField = "RELATIONID";
                radRelation.DataTextField = "HR_MASTER_CODE";
                radRelation.DataBind();
            }
            else
            {
                trBenficaryName.Visible = false;
                trRelation.Visible = false;
            }

            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                btn_Update.Visible = false;
            else
                btn_Update.Visible = true;

            if (Convert.ToString(dt.Rows[0]["IS_FINALIZED"]) == "2")
                btn_Update.Visible = btnFinalize.Visible = btnApprove.Visible = false;
            else
                btn_Update.Visible = btnFinalize.Visible = true;

            Rm_CY_page.SelectedIndex = 1;
            rtbOtherExpndName.Text = Convert.ToString(dt.Rows[0]["OTHER_EXPND_NAME"]);

            RadServiceProviderName.Enabled = false;
            radMedicalServiceProvider.Enabled = false;
            radExpenditureName.Enabled = false;
            rtbOtherExpndName.Enabled = false;

            btn_Update.Visible = false; //as suggested by Durga & Srikanth as per the functionality

            if (RadServiceProviderName.SelectedValue == "-1")
                RadServiceProviderName_SelectedIndexChanged(null, null);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void AssignvaluesToUserControl(DataTable dt)
    {
        //RadComboBox RadBusinessUnit = (RadComboBox)BU1.FindControl("RadBusinessUnit");
        rcmb_BusinesUnit.DataSource = dt;
        rcmb_BusinesUnit.DataTextField = "BUSINESSUNIT_CODE";
        rcmb_BusinesUnit.DataValueField = "BUSINESSUNIT_ID";
        rcmb_BusinesUnit.DataBind();

        //RadComboBox RadDirectorate = (RadComboBox)BU1.FindControl("RadDirectorate");
        rcmb_Directorate.DataSource = dt;
        rcmb_Directorate.DataTextField = "DIRECTORATE_CODE";
        rcmb_Directorate.DataValueField = "DIRECTORATE_ID";
        rcmb_Directorate.DataBind();

        //RadComboBox RadDepartment = (RadComboBox)BU1.FindControl("RadDepartment");
        rcmb_Department.DataSource = dt;
        rcmb_Department.DataTextField = "DEPARTMENT_NAME";
        rcmb_Department.DataValueField = "DEPARTMENT_ID";
        rcmb_Department.DataBind();

        //RadComboBox RadEmployee = (RadComboBox)BU1.FindControl("RadEmployee");
        rcmb_Employee.DataSource = dt;
        rcmb_Employee.DataTextField = "EMPLOYEENAME";
        rcmb_Employee.DataValueField = "EMPID";
        rcmb_Employee.DataBind();
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ViewState["str"] = "add";
            radInvoiceID.Enabled = true;
            clearControls();
            BindExpenditureNames();
            BindEmployees();
            //getting previous month for particular date i.e:25th of previous month
            var previousDate = DateTime.Now.AddMonths(-1);

            var mindate = new DateTime(previousDate.Year, previousDate.Month, 26);

            rdpInvoiceDate.MinDate = mindate;

            //getting current month for particular date i.e:24th of current month
            var maxdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);

            rdpInvoiceDate.MaxDate = maxdate;
            BindServiceProviders();
            //ControlsEnableorDisable(true);
            RadClaimType.Enabled = true;
            radBenficaryName.Enabled = true;
            trBenficaryName.Visible = false;
            trRelation.Visible = false;
            btn_Save.Visible = true;
            rcbFinPeriod.Enabled = true;
            Rm_CY_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void BindExpenditureNames()
    {
        try
        {
            radExpenditureName.Items.Clear();
            SMHR_EXPENDITURE _obj_Smhr_MedicalClaim = new SMHR_EXPENDITURE();
            _obj_Smhr_MedicalClaim.OPERATION = operation.Select;
            _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_Expenditure(_obj_Smhr_MedicalClaim);
            radExpenditureName.DataSource = dt;
            radExpenditureName.DataValueField = "EXPENDITURE_ID";
            radExpenditureName.DataTextField = "EXPENDITURE_NAME";
            radExpenditureName.DataBind();
            radExpenditureName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Others", "-1"));
            radExpenditureName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaim", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void BindEmployees()
    {
        try
        {
            DataTable dtEMPData = BLL.get_EmployeeBySearchString(Convert.ToInt32(Session["ORG_ID"]), string.Empty);
            rcmb_Employee.Items.Clear();
            rcmb_Employee.Text = string.Empty;
            rcmb_Employee.AppendDataBoundItems = true;
            rcmb_Employee.Enabled = true;
            if (dtEMPData.Rows.Count > 0)
            {
                rcmb_Employee.DataSource = dtEMPData;
                rcmb_Employee.DataTextField = "EMPNAME";
                rcmb_Employee.DataValueField = "EMP_ID";
                rcmb_Employee.DataBind();
            }
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", ""));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void LoadGrid()
    {
        try
        {
            /* _obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();
             _obj_Smhr_MedicalClaim.OPERATION = operation.Select;
             _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
             _obj_Smhr_MedicalClaim.MODE = 0;
             DataTable DT = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
             Rg_MedicalClaim.DataSource = DT;

             clearControls();*/

            _obj_Smhr_LoginInfo = new SMHR_LOGINTYPE();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);   //getting organisation from session under login.aspx
            _obj_Smhr_LoginInfo.LOGTYP_ID = Convert.ToInt32(Session["EMP_TYPE"]);       //getting login type id  from session under login.aspx
            _obj_Smhr_LoginInfo.LOGTYP_UNIQUEID = Convert.ToInt32(Session["USER_GROUP"]);  //getting login type code from session under login.aspx
            if (_obj_Smhr_LoginInfo.LOGTYP_UNIQUEID == 1 || _obj_Smhr_LoginInfo.LOGTYP_UNIQUEID == 2 || _obj_Smhr_LoginInfo.LOGTYP_UNIQUEID == 6 || _obj_Smhr_LoginInfo.LOGTYP_UNIQUEID == 8)  //1:admin,2:manager(approver),6:payroll(approver),8:(senior hr executive) from SMHR_LOGINTYPE table (LOGTYP_UNIQUEID)
            {
                _obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();
                _obj_Smhr_MedicalClaim.OPERATION = operation.LOADFINALIZE;
                _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_MedicalClaim.MODE = 0;
                DataTable DT = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
                Rg_MedicalClaim.DataSource = DT;
                clearControls();
            }
            else
            {
                BLL.ShowMessage(this, "You Cannot Acess..!");
                Rg_MedicalClaim.Visible = false;
                lbl_MedicalBenfitClaimHeader.Visible = false;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Employee_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Employee.SelectedIndex > 0)
            {
                SMHR_EMPLOYEE objEmployee = new SMHR_EMPLOYEE();
                objEmployee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                objEmployee.EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                DataTable dtEmp = BLL.get_EmployeeDtls(objEmployee);
                if (dtEmp.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(dtEmp.Rows[0]["BUSINESSUNIT_CODE"])))
                        rcmb_BusinesUnit.Text = Convert.ToString(dtEmp.Rows[0]["BUSINESSUNIT_CODE"]);
                    else
                        rcmb_BusinesUnit.Text = string.Empty;
                    if (!string.IsNullOrEmpty(Convert.ToString(dtEmp.Rows[0]["DIRECTORATE_CODE"])))
                        rcmb_Directorate.Text = Convert.ToString(dtEmp.Rows[0]["DIRECTORATE_CODE"]);
                    else
                        rcmb_Directorate.Text = string.Empty;
                    if (!string.IsNullOrEmpty(Convert.ToString(dtEmp.Rows[0]["DEPARTMENT_NAME"])))
                        rcmb_Department.Text = Convert.ToString(dtEmp.Rows[0]["DEPARTMENT_NAME"]);
                    else
                        rcmb_Department.Text = string.Empty;
                }
                else
                {
                    rcmb_BusinesUnit.Text = string.Empty;
                    rcmb_Directorate.Text = string.Empty;
                    rcmb_Department.Text = string.Empty;
                }

                //to fill scales
                SMHR_EMPLOYEE obj_smhr_employee = new SMHR_EMPLOYEE();
                obj_smhr_employee.OPERATION = operation.GETGRADE;
                obj_smhr_employee.EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                DataTable dt = BLL.get_Employee(obj_smhr_employee);
                radGradeName.DataSource = dt;
                radGradeName.DataValueField = "EMPLOYEEGRADE_ID";
                radGradeName.DataTextField = "EMPLOYEEGRADE_CODE";
                radGradeName.DataBind();
                LoadFinancialPeriod();
                LoadToCurrency();
                //rcbFinPeriod.SelectedIndex = rcbFinPeriod.Items.FindItemIndexByValue(Convert.ToString(dtEmp.Rows[0]["EMP_PERIOD_ID"]));

                //_obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();
                //_obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_MedicalClaim.EmpID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                //DataTable dtEMPData = BLL.get_EmployeeBySearchString(Convert.ToInt32(Session["ORG_ID"]), string.Empty);

            }
            else
            {
                radGradeName.Items.Clear();
                radGradeName.Text = string.Empty;
                rcmb_BusinesUnit.Items.Clear();
                rcmb_BusinesUnit.Text = string.Empty;
                rcmb_Directorate.Items.Clear();
                rcmb_Directorate.Text = string.Empty;
                rcmb_Department.Items.Clear();
                rcmb_Department.Text = string.Empty;
                rcmb_Currency.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcbFinPeriod_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            radExpenditureName.SelectedIndex = 0;
            lblMaxEligibleAmount.Text = lblAvailableAmount.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RadClaimType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //if (BU1.EmployeeID != null && BU1.EmployeeID > 0)
            if (rcmb_Employee.SelectedValue != "")  // && rcmb_Employee.SelectedIndex > 0)
            {
                if (RadClaimType.SelectedIndex > 0)
                {
                    if (string.Compare(RadClaimType.SelectedItem.Text, "Family", true) == 0)
                    {
                        radBenficaryName.Items.Clear();
                        radBenficaryName.ClearSelection();
                        radBenficaryName.Text = string.Empty;
                        radRelation.Items.Clear();
                        radRelation.ClearSelection();
                        radRelation.Text = string.Empty;
                        trBenficaryName.Visible = true;
                        trRelation.Visible = true;
                        //int empID = BU1.EmployeeID;
                        //string employeename = BU1.Employee;
                        SMHR_EMPLOYEE obj_smhr_employee = new SMHR_EMPLOYEE();
                        obj_smhr_employee.OPERATION = operation.Get;
                        obj_smhr_employee.EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                        //DataTable dt = BLL.get_EmployeeFamily(obj_smhr_employee);
                        //Session["BenficaryDetails"] = dt;

                        _obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();

                        _obj_Smhr_MedicalClaim.OPERATION = operation.Empty;
                        _obj_Smhr_MedicalClaim.EmpID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                        DataTable dt = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);

                        radBenficaryName.DataSource = dt;
                        radBenficaryName.DataTextField = "EMPFMDTL_NAME";
                        radBenficaryName.DataValueField = "EMPFMDTL_ID";  // "EMPFMDTL_SERIAL";EMPFMDTL_PRIORITY
                        radBenficaryName.DataBind();
                        radBenficaryName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                    }
                    else
                    {
                        trBenficaryName.Visible = false;
                        trRelation.Visible = false;
                        return;
                    }
                }
                else
                {
                    trBenficaryName.Visible = false;
                    trRelation.Visible = false;
                    return;
                }
            }
            else
            {
                RadClaimType.SelectedIndex = 0;
                BLL.ShowMessage(this, "Please select employee");
                trBenficaryName.Visible = false;
                trRelation.Visible = false;
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RadServiceProviderName_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (RadServiceProviderName.SelectedIndex > 0)
            {
                if (string.Compare(RadServiceProviderName.SelectedValue, "-1", true) == 0)    //To pass Service Provider Name
                {
                    trMedicalSvcPrvdr.Visible = true;
                }
                else
                {
                    trMedicalSvcPrvdr.Visible = false;
                }
            }
            else
            {
                trMedicalSvcPrvdr.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void radBenficaryName_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            radExpenditureName.SelectedIndex = 0;
            lblMaxEligibleAmount.Text = lblAvailableAmount.Text = radAmount.Text = rntbRule80.Text = string.Empty;
            trOtherExpndName.Visible = false;
            if (radBenficaryName.SelectedIndex > 0)
            {
                SMHR_EMPLOYEE obj_smhr_employee = new SMHR_EMPLOYEE();
                obj_smhr_employee.OPERATION = operation.Select2;
                //obj_smhr_employee.EMPFMDTL_EMP_ID = BU1.EmployeeID;
                obj_smhr_employee.EMPFMDTL_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                obj_smhr_employee.EMPFMDTL_ID = Convert.ToInt32(radBenficaryName.SelectedValue);
                DataTable dt = BLL.get_EmployeeFamily(obj_smhr_employee);
                //FamilyAge
                radRelation.DataSource = dt;
                radRelation.DataTextField = "HR_MASTER_CODE";
                radRelation.DataValueField = "HR_MASTER_ID";
                radRelation.DataBind();

                /*if (string.Compare(dt.Rows[0]["HR_MASTER_CODE"].ToString().ToLower(), "son", true) == 0 || string.Compare(dt.Rows[0]["HR_MASTER_CODE"].ToString().ToLower(), "daughter", true) == 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["FamilyAge"]) > 25)
                    {
                        BLL.ShowMessage(this, "Age limit for son/daughter is 25");
                        return;
                    }
                }*/
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void radExpenditureName_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            lblMaxEligibleAmount.Text = lblAvailableAmount.Text = radAmount.Text = rntbRule80.Text = string.Empty;

            //if (radExpenditureName.SelectedIndex > 0 && BU1.EmployeeID != null && BU1.EmployeeID > 0)
            //if (radExpenditureName.SelectedIndex > 0 && !string.IsNullOrEmpty(rcmb_Employee.SelectedValue))
            if (rcbFinPeriod.SelectedIndex > 0 && !string.IsNullOrEmpty(rcmb_Employee.SelectedValue))
            {
                if (radExpenditureName.SelectedValue == "-1")
                {
                    trOtherExpndName.Visible = true;
                    rtbOtherExpndName.Text = string.Empty;
                }
                else
                {
                    trOtherExpndName.Visible = false;
                    rtbOtherExpndName.Text = string.Empty;
                }
                _obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();
                _obj_Smhr_MedicalClaim.EmpID = Convert.ToInt32(rcmb_Employee.SelectedValue);  //BU1.EmployeeID;
                _obj_Smhr_MedicalClaim.ExpenditureID = Convert.ToInt32(radExpenditureName.SelectedValue);
                _obj_Smhr_MedicalClaim.MODE = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                _obj_Smhr_MedicalClaim.OPERATION = operation.check;
                _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_MedicalClaim.ClaimID = Convert.ToInt32(radGradeName.SelectedValue);
                _obj_Smhr_MedicalClaim.FIN_PRD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                DataTable dt = new DataTable();
                dt = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
                _obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();
                _obj_Smhr_MedicalClaim.EmpID = Convert.ToInt32(rcmb_Employee.SelectedValue);  //BU1.EmployeeID;
                _obj_Smhr_MedicalClaim.ExpenditureID = Convert.ToInt32(radExpenditureName.SelectedValue);
                _obj_Smhr_MedicalClaim.MODE = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                _obj_Smhr_MedicalClaim.OPERATION = operation.Validate;
                _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_MedicalClaim.ClaimID = Convert.ToInt32(radGradeName.SelectedValue);
                DataTable dtBalance1 = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
                if (Convert.ToInt32(dt.Rows[0]["MEDICALBENFIT_MAXAMOUNT"]) == 0)
                {
                    lblAvailableAmount.Text = lblMaxEligibleAmount.Text = Convert.ToString(Math.Round((Convert.ToDouble(dtBalance1.Rows[0]["MEDICALBENFIT_MAXAMOUNT"]))));
                }
                else
                {
                    ////////////////////
                    _obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();
                    _obj_Smhr_MedicalClaim.EmpID = Convert.ToInt32(rcmb_Employee.SelectedValue);  //BU1.EmployeeID;
                    _obj_Smhr_MedicalClaim.ExpenditureID = Convert.ToInt32(radExpenditureName.SelectedValue);
                    _obj_Smhr_MedicalClaim.MODE = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                    _obj_Smhr_MedicalClaim.OPERATION = operation.Validate;
                    _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_MedicalClaim.ClaimID = Convert.ToInt32(radGradeName.SelectedValue);
                    DataTable dtBalance = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
                    if (dtBalance.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dtBalance.Rows[0]["MEDICALBENFIT_MAXAMOUNT"].ToString()) && dtBalance.Rows[0]["MEDICALBENFIT_MAXAMOUNT"].ToString() != "0.00")
                        {
                            lblMaxEligibleAmount.Text = Convert.ToString(Math.Round((Convert.ToDouble(dtBalance.Rows[0]["MEDICALBENFIT_MAXAMOUNT"]))));

                            if (!string.IsNullOrEmpty(dtBalance.Rows[0]["CLAIMEDAMOUNT"].ToString()) && rntbRule80.Text != string.Empty)
                                lblAvailableAmount.Text = Convert.ToString(Math.Round((Convert.ToDouble(dtBalance.Rows[0]["MEDICALBENFIT_MAXAMOUNT"]) - Convert.ToDouble(rntbRule80.Text)), 2));
                            //lblAvailableAmount.Text = (Convert.ToDouble(dtBalance.Rows[0]["MEDICALBENFIT_MAXAMOUNT"]) - Convert.ToDouble(dtBalance.Rows[0]["CLAIMEDAMOUNT"])).ToString();
                            else if (!string.IsNullOrEmpty(dtBalance.Rows[0]["FINAL_CLAIMED"].ToString()))//
                                lblAvailableAmount.Text = Convert.ToString(Math.Round((Convert.ToDouble(dtBalance.Rows[0]["MEDICALBENFIT_MAXAMOUNT"]) - Convert.ToDouble(dtBalance.Rows[0]["FINAL_CLAIMED"])), 2));
                            else
                                lblAvailableAmount.Text = lblMaxEligibleAmount.Text;
                        }

                        else
                        {
                            if (Convert.ToString(dtBalance.Rows[0]["MEDICALBENFIT_MAXAMOUNT"]) == "0.00")
                                BLL.ShowMessage(this, "The value for selected Financial period is zero");
                            else
                                BLL.ShowMessage(this, "No values are defined for selected Financial period in Medical Benefits screen");
                            lblAvailableAmount.Text = lblMaxEligibleAmount.Text = rntbRule80.Text = string.Empty;
                            radExpenditureName.ClearSelection();
                            radExpenditureName.Text = string.Empty;
                            //BLL.ShowMessage(this, "Selected Expenditure Name doesnot contain Amount");
                            return;
                        }

                    }

                    else
                    {
                        lblAvailableAmount.Text = lblMaxEligibleAmount.Text = string.Empty;

                        radExpenditureName.ClearSelection();
                        radExpenditureName.Text = string.Empty;
                        //BLL.ShowMessage(this, "Selected Expenditure Name doesnot contain Amount");
                        BLL.ShowMessage(this, "No values are defined for selected Financial period in Medical Benefits screen");
                        return;

                    }
                }
            }

            //else if (BU1.EmployeeID == null || BU1.EmployeeID ==0)
            else if (rcmb_Employee.SelectedValue == "")    //|| rcmb_Employee.SelectedIndex == 0)
            {
                lblAvailableAmount.Text = lblMaxEligibleAmount.Text = string.Empty;
                radExpenditureName.ClearSelection();
                radExpenditureName.Text = string.Empty;
                BLL.ShowMessage(this, "Please select employee");
                return;
            }
            /*else if (rcbFinPeriod.SelectedIndex == 0)
            {
                lblAvailableAmount.Text = lblMaxEligibleAmount.Text = string.Empty;
                radExpenditureName.ClearSelection();
                radExpenditureName.Text = string.Empty;
                BLL.ShowMessage(this, "Please select employee to get Financial Period");
                return;
            }*/

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaim", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void radAmount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            double value = 0.0;
            SMHR_MedicalClaim _obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();
            //for  amount after convertion in claim amount validation

            if ((Convert.ToDouble(radAmount.Text)) > (Convert.ToDouble(rnt_maxcurramt.Text)))
            {
                BLL.ShowMessage(this, "Claim Amount is exceeded than Amount after Convertion..!");
                radAmount.Text = string.Empty;
                return;
            }


            // double value = 0.0;
            //for display one currency amount to another currency amount
            rnt_CurrencyAmt.Text = string.Empty;  //checking for  textbox empty
            chk_Rule.Checked = false;
            if (rcmb_Currency.SelectedIndex > 0)
            {

                _obj_Smhr_MedicalClaim.OPERATION = operation.CurrencyRate; ;
                _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_MedicalClaim.MED_CURR_ID = Convert.ToInt32(rcmb_Currency.SelectedValue);

                DataTable DT = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
                if (DT.Rows.Count > 0)
                {
                    if (radAmount.Text != string.Empty)
                    {


                        value = Convert.ToDouble(DT.Rows[0]["CURRENCY_CONVERSION_RATE"]);  // //getting convertion rate from table
                        rnt_CurrencyAmt.Text = Convert.ToString(Convert.ToDouble(radAmount.Text) / value);

                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Selected Currency Type Has No Conversion Rate...!");
                    rnt_CurrencyAmt.Text = string.Empty;
                    radAmount.Text = string.Empty;
                }
            }

            else
            {
                BLL.ShowMessage(this, "Please Select Currency Type...!");
                rnt_CurrencyAmt.Text = string.Empty;
                radAmount.Text = string.Empty;
            }

            if (chk_Rule.Checked == false)  //if 80% checkbox is unchecked
            {



                if (rcbFinPeriod.SelectedIndex > 0 && !string.IsNullOrEmpty(rcmb_Employee.SelectedValue))
                {

                    _obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();
                    _obj_Smhr_MedicalClaim.EmpID = Convert.ToInt32(rcmb_Employee.SelectedValue);  //BU1.EmployeeID;
                    _obj_Smhr_MedicalClaim.ExpenditureID = Convert.ToInt32(radExpenditureName.SelectedValue);
                    _obj_Smhr_MedicalClaim.MODE = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                    _obj_Smhr_MedicalClaim.OPERATION = operation.Validate;
                    _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_MedicalClaim.ClaimID = Convert.ToInt32(radGradeName.SelectedValue);
                    DataTable dtBalance = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
                    if (dtBalance.Rows.Count > 0)
                    {

                        if (chk_Rule.Checked == true)
                        {
                            if (!string.IsNullOrEmpty(dtBalance.Rows[0]["FINAL_CLAIMED"].ToString()))
                                // rntbRule80.Text = Convert.ToString(Math.Round((Convert.ToDouble(dtBalance.Rows[0]["MEDICALBENFIT_MAXAMOUNT"]) - Convert.ToDouble(dtBalance.Rows[0]["FINAL_CLAIMED"])), 2));
                                rntbRule80.Text = Convert.ToString(Convert.ToDouble(rnt_CurrencyAmt.Value));
                            else
                                rntbRule80.Text = lblMaxEligibleAmount.Text;
                        }

                    }
                }
            }
            if (chk_Rule.Checked == true)   //if checkbox is checked
            {
                //for  amount after convertion in claim amount validation
                if (radAmount.Text != string.Empty && rnt_maxcurramt.Text != string.Empty)
                {
                    if ((Convert.ToDouble(radAmount.Text)) > (Convert.ToDouble(rnt_maxcurramt.Text)))
                    {
                        BLL.ShowMessage(this, "Claim Amount is exceeded than Amount after Convertion..!");
                        radAmount.Text = string.Empty;
                        chk_Rule.Checked = false;
                        rntbRule80.Text = string.Empty;
                        return;
                    }
                }



                //for display one currency amount to another currency amount
                rnt_CurrencyAmt.Text = string.Empty;  //checking for  textbox empty
                if (rcmb_Currency.SelectedIndex > 0)
                {

                    _obj_Smhr_MedicalClaim.OPERATION = operation.CurrencyRate; ;
                    _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_MedicalClaim.MED_CURR_ID = Convert.ToInt32(rcmb_Currency.SelectedValue);

                    DataTable DT = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
                    if (DT.Rows.Count > 0)
                    {
                        if (radAmount.Text != string.Empty)
                        {


                            value = Convert.ToDouble(DT.Rows[0]["CURRENCY_CONVERSION_RATE"]);  // //getting convertion rate from table
                            rnt_CurrencyAmt.Text = Convert.ToString(Convert.ToDouble(radAmount.Text) / value);

                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Selected Currency Type Has No Conversion Rate...!");
                        rnt_CurrencyAmt.Text = string.Empty;
                        radAmount.Text = string.Empty;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Please Select Currency Type...!");
                    rnt_CurrencyAmt.Text = string.Empty;
                    radAmount.Text = string.Empty;
                }
                //for display one currency amount to another currency amount

                if (rnt_CurrencyAmt.Text != string.Empty && rnt_maxcurramt.Text != string.Empty)
                {
                    if ((Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.8) > Convert.ToDouble(rnt_maxcurramt.Text))
                    //if ((Convert.ToDouble(radAmount.Text)) > Convert.ToDouble(MaxAmount.Text))
                    {
                        if (Convert.ToString(ViewState["str"]) == "add")
                        {
                            BLL.ShowMessage(this, "Entered amount is exceeding Max amount");
                            rnt_CurrencyAmt.Text = rntbRule80.Text = string.Empty;
                            rnt_CurrencyAmt.Focus();
                            return;
                        }
                        if (Convert.ToString(ViewState["str"]) == "edit" && ViewState["curramt"] != null)
                        {
                            double amount = Convert.ToDouble(rnt_maxcurramt.Text) + (Convert.ToDouble(ViewState["curramt"]) * 0.8);
                            amount = (amount * 1.25);

                            if ((Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.8) > (Convert.ToDouble(rnt_maxcurramt.Text) + (Convert.ToDouble(ViewState["curramt"]) * 0.8)))
                            {
                                BLL.ShowMessage(this, "You can enter amount upto " + Convert.ToString(amount) + " only which consists of old rule amount: " + Convert.ToString(Convert.ToDouble(ViewState["curramt"]) * 0.8) + " and available amount: " + rnt_maxcurramt.Text);
                                rnt_CurrencyAmt.Text = Convert.ToString(ViewState["curramt"]);
                                rntbRule80.Text = Convert.ToString(Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.8);
                                rnt_CurrencyAmt.Focus();
                                return;
                            }
                        }
                    }

                    if (rnt_maxcurramt.Text != string.Empty && lblMaxEligibleAmount.Text != string.Empty)
                        rntbRule80.Text = Convert.ToString(Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.8);
                    else
                        rntbRule80.Text = string.Empty;
                }
                if (rnt_CurrencyAmt.Text != string.Empty)
                {
                    if (rnt_CurrencyAmt.Text == "0")
                    {
                        BLL.ShowMessage(this, "You are not supposed to claim any amounts as available balance amount is 0..");
                        rnt_CurrencyAmt.Text = string.Empty;
                        rnt_CurrencyAmt.Focus();
                        chk_Rule.Checked = false;
                        return;
                    }
                    if (lblAvailableAmount.Text == "0")
                    {
                        BLL.ShowMessage(this, "You are not supposed to claim any amounts as available balance amount is 0..");
                        lblAvailableAmount.Text = string.Empty;
                        lblAvailableAmount.Focus();
                        chk_Rule.Checked = false;
                        return;
                    }
                }
            }


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {


            _obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();
            bool result = true;
            ValidateInputs(out result);

            if (rcbFinPeriod.SelectedValue == string.Empty || rcbFinPeriod.SelectedValue == null)
            {
                BLL.ShowMessage(this, "Please Select Financial Period");
                rcbFinPeriod.Focus();
                return;
            }
            if (rcmb_Currency.SelectedValue == string.Empty || rcmb_Currency.SelectedValue == null)
            {
                BLL.ShowMessage(this, "Please Select Currency Type..!");
                rcmb_Currency.Focus();
                return;
            }
            if (trOtherExpndName.Visible == true && rtbOtherExpndName.Text == string.Empty)
            {
                BLL.ShowMessage(this, "Please Enter other expenditure name");
                rtbOtherExpndName.Focus();
                return;
            }
            if (rnt_CurrencyAmt.Text == string.Empty)
            {
                BLL.ShowMessage(this, "Please Enter currency amount in usd$..!");
                rnt_CurrencyAmt.Focus();
                return;
            }
            if (rnt_maxcurramt.Text == string.Empty)
            {
                BLL.ShowMessage(this, "Please Enter Amount After Convertion..!");
                rnt_maxcurramt.Focus();
                return;
            }
            if(chk_Rule.Checked==false)
            {
                BLL.ShowMessage(this, "Please Select Final Amount as per Rule");
                return;
            }
            if (result)
            {
                if (string.Compare(RadClaimType.SelectedItem.Text, "Family", true) == 0 && (string.Compare(radRelation.SelectedItem.Text.ToLower(), "son", true) == 0 || string.Compare(radRelation.SelectedItem.Text.ToLower(), "daughter", true) == 0))
                {
                    SMHR_EMPLOYEE obj_smhr_employee = new SMHR_EMPLOYEE();
                    obj_smhr_employee.OPERATION = operation.Select2;
                    //obj_smhr_employee.EMPFMDTL_EMP_ID = BU1.EmployeeID;
                    obj_smhr_employee.EMPFMDTL_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                    obj_smhr_employee.EMPFMDTL_ID = Convert.ToInt32(radBenficaryName.SelectedValue);
                    DataTable dt = BLL.get_EmployeeFamily(obj_smhr_employee);
                    /*if (Convert.ToInt32(dt.Rows[0]["FamilyAge"]) > 26)
                    {
                        BLL.ShowMessage(this, "Age limit for son/daughter is 25");
                        return;
                    }*/
                }

                //_obj_Smhr_MedicalClaim.EmpID = BU1.EmployeeID;
                _obj_Smhr_MedicalClaim.EmpID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                _obj_Smhr_MedicalClaim.CliamType = RadClaimType.SelectedItem.Text;
                if (string.Compare(_obj_Smhr_MedicalClaim.CliamType, "Family", true) == 0)
                {
                    _obj_Smhr_MedicalClaim.BenficiarySerialId = Convert.ToInt32(radBenficaryName.SelectedValue);
                    _obj_Smhr_MedicalClaim.BenficiaryName = radBenficaryName.SelectedItem.Text;
                    _obj_Smhr_MedicalClaim.RelationID = Convert.ToInt32(radRelation.SelectedValue);
                }
                if (string.Compare(RadServiceProviderName.SelectedValue, "0", true) == 0)    //To pass Service Provider Name
                {
                    _obj_Smhr_MedicalClaim.ServiceProviderName = BLL.ReplaceQuote(radMedicalServiceProvider.Text);
                }
                _obj_Smhr_MedicalClaim.SERVICEPROVIDERID = Convert.ToInt32(RadServiceProviderName.SelectedValue);

                //_obj_Smhr_MedicalClaim.ServiceProviderName = BLL.ReplaceQuote(radMedicalServiceProvider.Text);
                _obj_Smhr_MedicalClaim.ExpenditureID = Convert.ToInt32(radExpenditureName.SelectedValue);

                //DataTable dtBalance = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
                //double balance=Convert.ToDouble(dtBalance.Rows[0]["Balance"]);
                //if (balance >= Convert.ToDouble(radAmount.Text))
                //{
                //    _obj_Smhr_MedicalClaim.Amount = Convert.ToDouble(radAmount.Text);
                //}
                //else
                //{
                //    BLL.ShowMessage(this, "your balance amount for this expenditure is : "+balance.ToString());
                //    return;
                //}

                _obj_Smhr_MedicalClaim.EmpID = Convert.ToInt32(rcmb_Employee.SelectedValue); //BU1.EmployeeID;
                _obj_Smhr_MedicalClaim.ExpenditureID = Convert.ToInt32(radExpenditureName.SelectedValue);
                _obj_Smhr_MedicalClaim.OPERATION = operation.Validate;
                _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_MedicalClaim.ClaimID = Convert.ToInt32(radGradeName.SelectedValue);
                //DataTable dtBalance = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
                //if (dtBalance.Rows.Count == 0)
                //{
                //    BLL.ShowMessage(this, "Selected Expenditure Name doesn't contain Amount");
                //    return;
                //}
                _obj_Smhr_MedicalClaim.FIN_PRD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                _obj_Smhr_MedicalClaim.InvoiceID = radInvoiceID.Text;
                _obj_Smhr_MedicalClaim.InvoiceDate = (DateTime)rdpInvoiceDate1.SelectedDate;
                _obj_Smhr_MedicalClaim.Amount = Convert.ToDouble(radAmount.Text);
                _obj_Smhr_MedicalClaim.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Smhr_MedicalClaim.MED_APPROVEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Smhr_MedicalClaim.InvoiceDocument = FBrowse.FileName;
                if (rntbRule80.Text != string.Empty)
                    _obj_Smhr_MedicalClaim.MED_FINAL_AMNT = Convert.ToDouble(rntbRule80.Text);
                else
                    _obj_Smhr_MedicalClaim.MED_FINAL_AMNT = (Convert.ToDouble(radAmount.Text) * 0.8);
                _obj_Smhr_MedicalClaim.OTHER_EXPND_NAME = rtbOtherExpndName.Text;


                if (rcmb_Currency.SelectedValue != string.Empty)
                    _obj_Smhr_MedicalClaim.MED_CURR_ID = Convert.ToInt32(rcmb_Currency.SelectedValue);
                else
                    _obj_Smhr_MedicalClaim.MED_CURR_ID = 0;
                if (rnt_CurrencyAmt.Text != string.Empty)
                    _obj_Smhr_MedicalClaim.MED_CURR_AMT = Convert.ToDecimal(rnt_CurrencyAmt.Text);
                else
                    _obj_Smhr_MedicalClaim.MED_CURR_AMT = 0;

                if (rnt_maxcurramt.Text != string.Empty)
                    _obj_Smhr_MedicalClaim.MED_CONVERSION_AMT = Convert.ToDecimal(rnt_maxcurramt.Text);
                else
                    _obj_Smhr_MedicalClaim.MED_CONVERSION_AMT = 0;
                _obj_Smhr_MedicalClaim.MED_ISRULEID = chk_Rule.Checked;

                if (FBrowse.HasFile)
                {
                    string pdfName = _obj_Smhr_MedicalClaim.EmpID + "_" + Guid.NewGuid().ToString() + "_" + FBrowse.FileName;
                    string strPath = "~/MedicalInvoice/" + pdfName;
                    FBrowse.PostedFile.SaveAs(Server.MapPath("~/MedicalInvoice/") + pdfName);
                    _obj_Smhr_MedicalClaim.InvoiceDocument = strPath;
                }
                switch (((Button)sender).ID.ToUpper())
                {
                    case "BTN_UPDATE":

                        if ((string.IsNullOrEmpty(Convert.ToString(ViewState["invDoc"]))) && FBrowse.HasFile == false)
                        {
                            BLL.ShowMessage(this, "Please upload invoice");
                            FBrowse.Focus();
                            return;
                        }

                        _obj_Smhr_MedicalClaim.ClaimID = Convert.ToInt32(lbl_MedicalClaimID.Text);
                        _obj_Smhr_MedicalClaim.OPERATION = operation.Update;
                        if (BLL.set_MedicalClaim(_obj_Smhr_MedicalClaim))
                            BLL.ShowMessage(this, "Information Updated Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Updated");

                        break;
                    case "BTN_SAVE":
                        _obj_Smhr_MedicalClaim.OPERATION = operation.CHECKDUPLICATE;
                        //_obj_Smhr_MedicalClaim.EDU_STATUS = 0;

                        DataTable dtCheckDup = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);

                        if (Convert.ToString(dtCheckDup.Rows[0]["COUNT"]) != string.Empty)
                        {
                            if (Convert.ToInt32(dtCheckDup.Rows[0]["COUNT"]) > 0)
                            {
                                Response.Redirect("~/Medical/frm_MedicalFinalize.aspx", false);
                                return;
                            }
                        }


                        if (!FBrowse.HasFile)
                        {
                            BLL.ShowMessage(this, "Please upload invoice");
                            FBrowse.Focus();
                            return;
                        }

                        //if (FBrowse.HasFile)
                        //{
                        //    string pdfName = _obj_Smhr_MedicalClaim.EmpID + "_" + Guid.NewGuid().ToString() + "_" + FBrowse.FileName;
                        //    string strPath = "~/MedicalInvoice/" + pdfName;
                        //    FBrowse.PostedFile.SaveAs(Server.MapPath("~/MedicalInvoice/") + pdfName);
                        //    _obj_Smhr_MedicalClaim.InvoiceDocument = strPath;
                        //}
                        //else
                        //{
                        //    BLL.ShowMessage(this, "please select invoice document");
                        //    return;
                        //}
                        _obj_Smhr_MedicalClaim.OPERATION = operation.Insert;
                        if (BLL.set_MedicalClaim(_obj_Smhr_MedicalClaim))
                            BLL.ShowMessage(this, "Information Saved Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Saved");
                        break;

                    case "BTNFINALIZE":
                        _obj_Smhr_MedicalClaim.OPERATION = operation.Check_Emp;
                         _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Smhr_MedicalClaim.Amount = Convert.ToDouble(radAmount.Text);
                        _obj_Smhr_MedicalClaim.MED_FINAL_AMNT = Convert.ToDouble(rntbRule80.Text);
                        _obj_Smhr_MedicalClaim.ClaimID = Convert.ToInt32(lbl_MedicalClaimID.Text);
                         DataTable dtBalance1 = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
                         if (dtBalance1.Rows.Count > 0)
                         {
                             if(Convert.ToInt32(dtBalance1.Rows[0]["IS_FINALIZED"])==0)
                             {
                                 BLL.ShowMessage(this, "You Cant Approve before Confirm..!");
                                 return;
                             }
                         }

                        _obj_Smhr_MedicalClaim.ClaimID = Convert.ToInt32(lbl_MedicalClaimID.Text);
                        _obj_Smhr_MedicalClaim.OPERATION = operation.MEDFINALIZE;
                        _obj_Smhr_MedicalClaim.MED_CURR_ID = Convert.ToInt32(rcmb_Currency.SelectedValue);
                        _obj_Smhr_MedicalClaim.MED_CURR_AMT = Convert.ToDecimal(rnt_CurrencyAmt.Text);
                        _obj_Smhr_MedicalClaim.MED_CONVERSION_AMT = Convert.ToDecimal(rnt_maxcurramt.Text);
                        // _obj_Smhr_MedicalClaim.IS_FINALIZED = 2;

                        if (BLL.set_MedicalClaim(_obj_Smhr_MedicalClaim))
                            BLL.ShowMessage(this, "Information Approved Successfully");
                        else
                            BLL.ShowMessage(this, "Information Not Approved");
                        break;
                    default:
                        break;
                }
                Rm_CY_page.SelectedIndex = 0;
                LoadGrid();
                Rg_MedicalClaim.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void ValidateInputs(out bool result)
    {
        result = true;
        try
        {

            //RadComboBox RadBusinessUnit = (RadComboBox)BU1.FindControl("RadBusinessUnit");
            if (!string.IsNullOrEmpty(rcmb_Employee.SelectedItem.Text))
            {
                if (!string.IsNullOrEmpty(RadClaimType.SelectedItem.Text) && string.Compare(RadClaimType.SelectedItem.Text, "Select", true) != 0)
                {
                    if (string.Compare(RadClaimType.SelectedItem.Text, "Family", true) == 0)
                    {
                        if (radBenficaryName.SelectedItem != null && !string.IsNullOrEmpty(radBenficaryName.SelectedItem.Text) && string.Compare(radBenficaryName.SelectedItem.Text, "Select", true) != 0)
                        {
                            if (radRelation.SelectedItem != null && !string.IsNullOrEmpty(radRelation.SelectedItem.Text) && string.Compare(radRelation.SelectedItem.Text, "Select", true) != 0)
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                                BLL.ShowMessage(this, "Please select relation");
                                return;
                            }
                        }
                        else
                        {
                            result = false;
                            BLL.ShowMessage(this, "Please select benficiary name");
                            return;
                        }
                    }

                    //if (!string.IsNullOrEmpty(radMedicalServiceProvider.Text))
                    if (RadServiceProviderName.SelectedIndex > 0)
                    {
                        if (!string.IsNullOrEmpty(radExpenditureName.SelectedItem.Text) && string.Compare(radExpenditureName.SelectedItem.Text, "Select", true) != 0)
                        {
                            if (!string.IsNullOrEmpty(radAmount.Text))
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                                BLL.ShowMessage(this, "Please enter amount");
                                return;
                            }
                        }
                        else
                        {
                            result = false;
                            BLL.ShowMessage(this, "Please select expenditure name");
                            return;
                        }
                    }
                    else
                    {
                        result = false;
                        BLL.ShowMessage(this, "Please enter service provider name");
                        return;
                    }
                    if (radInvoiceID.Text != string.Empty)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                        BLL.ShowMessage(this, "Please Enter Invoice Id ");
                        return;
                    }
                    if (rdpInvoiceDate1.SelectedDate != null)
                    {
                        //if (FBrowse.HasFile)
                        //{
                        result = true;
                        //}
                        //else
                        //{
                        //    result = false;
                        //    BLL.ShowMessage(this, "Please select a file to upload");
                        //    return;
                        //}
                    }
                    else
                    {
                        result = false;
                        BLL.ShowMessage(this, "Please Enter Claim Date/Invoice Date");
                        return;
                    }
                }
                else
                {
                    result = false;
                    BLL.ShowMessage(this, "Please select claim type");
                    return;
                }
            }
            else
            {
                result = false;
                BLL.ShowMessage(this, "Please select Employee");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void clearControls()
    {
        try
        {
            //  lbl_MedicalClaimID.Text = string.Empty;
            radGradeName.Items.Clear();
            radAmount.Text = string.Empty;
            radMedicalServiceProvider.Text = string.Empty;
            RadClaimType.SelectedIndex = 0;
            //BU1.ClearControls();
            lblMaxEligibleAmount.Text = string.Empty;
            lblAvailableAmount.Text = string.Empty;
            rdpInvoiceDate.SelectedDate = null;
            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_CY_page.SelectedIndex = 0;
            rcbFinPeriod.SelectedIndex = 0;
            rntbRule80.Text = string.Empty;
            rcmb_BusinesUnit.Items.Clear();
            rcmb_BusinesUnit.Text = string.Empty;
            rcmb_Directorate.Items.Clear();
            rcmb_Directorate.Text = string.Empty;
            rcmb_Department.Items.Clear();
            rcmb_Department.Text = string.Empty;
            rcmb_Employee.Items.Clear();
            rcmb_Employee.Text = string.Empty;
            RadServiceProviderName.Items.Clear();
            RadServiceProviderName.Text = string.Empty;
            radInvoiceID.Text = string.Empty;
            RadServiceProviderName.Enabled = true;
            radMedicalServiceProvider.Enabled = true;
            radExpenditureName.Enabled = true;
            rtbOtherExpndName.Enabled = true;
            rtbOtherExpndName.Text = string.Empty;
            btnFinalize.Visible = false;
            btnApprove.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadFinancialPeriod()
    {
        try
        {
            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();

            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dtFinPrd = BLL.GET_FIN_PERIOD(_obj_smhr_period);

            rcbFinPeriod.DataSource = dtFinPrd;
            rcbFinPeriod.DataTextField = "PERIOD_NAME";
            rcbFinPeriod.DataValueField = "PERIOD_ID";
            rcbFinPeriod.DataBind();
            rcbFinPeriod.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void BindServiceProviders()
    {
        try
        {
            SMHR_SERVICEPROVIDER _obj_Smhr_ServiceProvider = new SMHR_SERVICEPROVIDER();
            _obj_Smhr_ServiceProvider.OPERATION = operation.Select2;
            _obj_Smhr_ServiceProvider.SERVICEPROVIDER_TYPE = "medical";
            _obj_Smhr_ServiceProvider.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_ServiceProvider(_obj_Smhr_ServiceProvider);
            RadServiceProviderName.DataSource = DT;
            RadServiceProviderName.DataValueField = "SERVICEPROVIDER_ID";
            RadServiceProviderName.DataTextField = "SERVICEPROVIDER_NAME";
            RadServiceProviderName.DataBind();
            RadServiceProviderName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            RadServiceProviderName.Items.Add(new RadComboBoxItem("Others", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadToCurrency()
    {
        try
        {

            rcmb_Currency.Items.Clear();
            rnt_CurrencyAmt.Text = string.Empty;
            radAmount.Text = string.Empty;
            _obj_smhr_Currency = new SMHR_CURRENCY();
            _obj_smhr_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_Currency(_obj_smhr_Currency);
            rcmb_Currency.DataSource = dt_Details;
            rcmb_Currency.DataTextField = "CURR_CODE";
            rcmb_Currency.DataValueField = "CURR_ID";
            rcmb_Currency.DataBind();
            rcmb_Currency.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Currency_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            //available balance currency conversion

            //lblMaxEligibleAmount.Text = lblAvailableAmount.Text = radAmount.Text = rntbRule80.Text = rnt_CurrencyAmt.Text= string.Empty;

            //if (radExpenditureName.SelectedIndex > 0 && BU1.EmployeeID != null && BU1.EmployeeID > 0)
            //if (radExpenditureName.SelectedIndex > 0 && !string.IsNullOrEmpty(rcmb_Employee.SelectedValue))
            /* if (rcbFinPeriod.SelectedIndex > 0 && !string.IsNullOrEmpty(rcmb_Employee.SelectedValue))
             {
                 if (radExpenditureName.SelectedValue == "-1")
                 {
                     trOtherExpndName.Visible = true;
                     rtbOtherExpndName.Text = string.Empty;
                 }
                 else
                 {
                     trOtherExpndName.Visible = false;
                     rtbOtherExpndName.Text = string.Empty;
                 }
             }*/


            lblMaxEligibleAmount.Text = lblAvailableAmount.Text = radAmount.Text = rntbRule80.Text = string.Empty;

            //if (radExpenditureName.SelectedIndex > 0 && BU1.EmployeeID != null && BU1.EmployeeID > 0)
            //if (radExpenditureName.SelectedIndex > 0 && !string.IsNullOrEmpty(rcmb_Employee.SelectedValue))
            if (rcbFinPeriod.SelectedIndex > 0 && !string.IsNullOrEmpty(rcmb_Employee.SelectedValue) && radGradeName.SelectedValue!="")
            {
                /*if (radExpenditureName.SelectedValue == "-1")
                {
                    trOtherExpndName.Visible = true;
                    rtbOtherExpndName.Text = string.Empty;
                }
                else
                {
                    trOtherExpndName.Visible = false;
                    rtbOtherExpndName.Text = string.Empty;
                }*/
                _obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();
                _obj_Smhr_MedicalClaim.EmpID = Convert.ToInt32(rcmb_Employee.SelectedValue);  //BU1.EmployeeID;
                _obj_Smhr_MedicalClaim.ExpenditureID = Convert.ToInt32(radExpenditureName.SelectedValue);
                _obj_Smhr_MedicalClaim.MODE = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                _obj_Smhr_MedicalClaim.OPERATION = operation.check;
                _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_MedicalClaim.ClaimID = Convert.ToInt32(radGradeName.SelectedValue);
                _obj_Smhr_MedicalClaim.FIN_PRD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                DataTable dt = new DataTable();
                dt = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
                _obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();
                _obj_Smhr_MedicalClaim.EmpID = Convert.ToInt32(rcmb_Employee.SelectedValue);  //BU1.EmployeeID;
                _obj_Smhr_MedicalClaim.ExpenditureID = Convert.ToInt32(radExpenditureName.SelectedValue);
                _obj_Smhr_MedicalClaim.MODE = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                _obj_Smhr_MedicalClaim.OPERATION = operation.Validate;
                _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_MedicalClaim.ClaimID = Convert.ToInt32(radGradeName.SelectedValue);
                DataTable dtBalance1 = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
                if (Convert.ToInt32(dt.Rows[0]["MEDICALBENFIT_MAXAMOUNT"]) == 0)
                {
                    lblAvailableAmount.Text = lblMaxEligibleAmount.Text = Convert.ToString(Math.Round((Convert.ToDouble(dtBalance1.Rows[0]["MEDICALBENFIT_MAXAMOUNT"]))));
                }
                else
                {

                    ////////////////
                    _obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();
                    _obj_Smhr_MedicalClaim.EmpID = Convert.ToInt32(rcmb_Employee.SelectedValue);  //BU1.EmployeeID;
                    _obj_Smhr_MedicalClaim.ExpenditureID = Convert.ToInt32(radExpenditureName.SelectedValue);
                    _obj_Smhr_MedicalClaim.MODE = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                    _obj_Smhr_MedicalClaim.OPERATION = operation.Validate;
                    _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_MedicalClaim.ClaimID = Convert.ToInt32(radGradeName.SelectedValue);
                    DataTable dtBalance = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
                    if (dtBalance.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dtBalance.Rows[0]["MEDICALBENFIT_MAXAMOUNT"].ToString()) && dtBalance.Rows[0]["MEDICALBENFIT_MAXAMOUNT"].ToString() != "0.00")
                        {
                            lblMaxEligibleAmount.Text = dtBalance.Rows[0]["MEDICALBENFIT_MAXAMOUNT"].ToString();

                            Session["ABC"] = lblMaxEligibleAmount.Text;
                            if (!string.IsNullOrEmpty(dtBalance.Rows[0]["FINAL_CLAIMED"].ToString()))//
                                lblAvailableAmount.Text = Convert.ToString(Math.Round((Convert.ToDouble(dtBalance.Rows[0]["MEDICALBENFIT_MAXAMOUNT"]) - Convert.ToDouble(dtBalance.Rows[0]["FINAL_CLAIMED"])), 2));
                            else
                                lblAvailableAmount.Text = lblMaxEligibleAmount.Text;

                        }


                        else
                        {
                            if (Convert.ToString(dtBalance.Rows[0]["MEDICALBENFIT_MAXAMOUNT"]) == "0.00")
                                BLL.ShowMessage(this, "The value for selected Financial period is zero");
                            else
                                BLL.ShowMessage(this, "No values are defined for selected Financial period in Medical Benefits screen");
                            lblAvailableAmount.Text = lblMaxEligibleAmount.Text = rntbRule80.Text = string.Empty;
                            radExpenditureName.ClearSelection();
                            radExpenditureName.Text = string.Empty;
                            //BLL.ShowMessage(this, "Selected Expenditure Name doesnot contain Amount");
                            return;
                        }
                    }

                    else
                    {
                        lblAvailableAmount.Text = lblMaxEligibleAmount.Text = string.Empty;

                        radExpenditureName.ClearSelection();
                        radExpenditureName.Text = string.Empty;
                        //BLL.ShowMessage(this, "Selected Expenditure Name doesnot contain Amount");
                        BLL.ShowMessage(this, "No values are defined for selected Financial period in Medical Benefits screen");
                        return;
                    }
                    //}
                    //else if (BU1.EmployeeID == null || BU1.EmployeeID ==0)
                    if (rcmb_Employee.SelectedValue == "")    //|| rcmb_Employee.SelectedIndex == 0)
                    {
                        lblAvailableAmount.Text = lblMaxEligibleAmount.Text = string.Empty;
                        radExpenditureName.ClearSelection();
                        radExpenditureName.Text = string.Empty;
                        BLL.ShowMessage(this, "Please select employee");
                        return;
                    }
                }
                double value = 0.0;
                _obj_Smhr_MedicalClaim.OPERATION = operation.CurrencyRate; ;
                _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_MedicalClaim.MED_CURR_ID = Convert.ToInt32(rcmb_Currency.SelectedValue);
                if (rcmb_Currency.SelectedIndex > 0)
                {
                    DataTable DT = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
                    if (DT.Rows.Count > 0)
                    {
                        if (lblAvailableAmount.Text != string.Empty)
                        {


                            value = Convert.ToDouble(DT.Rows[0]["CURRENCY_CONVERSION_RATE"]);  // //getting convertion rate from table
                            rnt_maxcurramt.Text = Convert.ToString(Convert.ToDouble(lblAvailableAmount.Text) * value);

                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Selected Currency Type Has No Conversion Rate...!");
                        rnt_maxcurramt.Text = string.Empty;
                        radAmount.Text = string.Empty;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Please Select Currency Type...!");
                    rnt_maxcurramt.Text = string.Empty;
                    radAmount.Text = string.Empty;
                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaim", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void chk_Rule_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chk_Rule.Checked == true)   //if checkbx is checked
            {
                //for  amount after convertion in claim amount validation
                if (radAmount.Text != string.Empty && rnt_maxcurramt.Text != string.Empty)
                {
                    if ((Convert.ToDouble(radAmount.Text)) > (Convert.ToDouble(rnt_maxcurramt.Text)))
                    {
                        BLL.ShowMessage(this, "Claim Amount is exceeded than Amount after Convertion..!");
                        radAmount.Text = string.Empty;
                        chk_Rule.Checked = false;
                        rntbRule80.Text = string.Empty;
                        return;
                    }
                }


                double value = 0.0;
                //for display one currency amount to another currency amount
                rnt_CurrencyAmt.Text = string.Empty;  //checking for  textbox empty
                if (rcmb_Currency.SelectedIndex > 0)
                {
                    SMHR_MedicalClaim _obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();

                    _obj_Smhr_MedicalClaim.OPERATION = operation.CurrencyRate; ;
                    _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_MedicalClaim.MED_CURR_ID = Convert.ToInt32(rcmb_Currency.SelectedValue);

                    DataTable DT = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
                    if (DT.Rows.Count > 0)
                    {
                        if (radAmount.Text != string.Empty)
                        {


                            value = Convert.ToDouble(DT.Rows[0]["CURRENCY_CONVERSION_RATE"]);  // //getting convertion rate from table
                            rnt_CurrencyAmt.Text = Convert.ToString(Convert.ToDouble(radAmount.Text) / value);

                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Selected Currency Type Has No Conversion Rate...!");
                        rnt_CurrencyAmt.Text = string.Empty;
                        radAmount.Text = string.Empty;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Please Select Currency Type...!");
                    rnt_CurrencyAmt.Text = string.Empty;
                    radAmount.Text = string.Empty;
                }





                //for display one currency amount to another currency amount

                if (rnt_CurrencyAmt.Text != string.Empty && rnt_maxcurramt.Text != string.Empty)
                {
                    if ((Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.8) > Convert.ToDouble(rnt_maxcurramt.Text))
                    //if ((Convert.ToDouble(radAmount.Text)) > Convert.ToDouble(MaxAmount.Text))
                    {
                        if (Convert.ToString(ViewState["str"]) == "add")
                        {
                            BLL.ShowMessage(this, "Entered amount is exceeding Max amount");
                            rnt_CurrencyAmt.Text = rntbRule80.Text = string.Empty;
                            rnt_CurrencyAmt.Focus();
                            return;
                        }
                        if (Convert.ToString(ViewState["str"]) == "edit" && ViewState["curramt"] != null)
                        {
                            double amount = Convert.ToDouble(rnt_maxcurramt.Text) + (Convert.ToDouble(ViewState["curramt"]) * 0.8);
                            amount = (amount * 1.25);

                            if ((Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.8) > (Convert.ToDouble(rnt_maxcurramt.Text) + (Convert.ToDouble(ViewState["curramt"]) * 0.8)))
                            {
                                BLL.ShowMessage(this, "You can enter amount upto " + Convert.ToString(amount) + " only which consists of old rule amount: " + Convert.ToString(Convert.ToDouble(ViewState["curramt"]) * 0.8) + " and available amount: " + rnt_maxcurramt.Text);
                                rnt_CurrencyAmt.Text = Convert.ToString(ViewState["curramt"]);
                                rntbRule80.Text = Convert.ToString(Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.8);
                                rnt_CurrencyAmt.Focus();
                                return;
                            }
                        }
                    }

                    if (rnt_maxcurramt.Text != string.Empty && lblMaxEligibleAmount.Text != string.Empty)
                        rntbRule80.Text = Convert.ToString(Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.8);
                    else
                        rntbRule80.Text = string.Empty;
                }
            }
            else    //if checkbox is umchecked
            {
                if (rcbFinPeriod.SelectedIndex > 0 && !string.IsNullOrEmpty(rcmb_Employee.SelectedValue))
                {

                    _obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();
                    _obj_Smhr_MedicalClaim.EmpID = Convert.ToInt32(rcmb_Employee.SelectedValue);  //BU1.EmployeeID;
                    _obj_Smhr_MedicalClaim.ExpenditureID = Convert.ToInt32(radExpenditureName.SelectedValue);
                    _obj_Smhr_MedicalClaim.MODE = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                    _obj_Smhr_MedicalClaim.OPERATION = operation.Validate;
                    _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_MedicalClaim.ClaimID = Convert.ToInt32(radGradeName.SelectedValue);
                    DataTable dtBalance = BLL.get_MedicalClaim(_obj_Smhr_MedicalClaim);
                    if (dtBalance.Rows.Count > 0)
                    {


                        if (!string.IsNullOrEmpty(dtBalance.Rows[0]["FINAL_CLAIMED"].ToString()))
                            //rntbRule80.Text = Convert.ToString(Math.Round((Convert.ToDouble(dtBalance.Rows[0]["MEDICALBENFIT_MAXAMOUNT"]) - Convert.ToDouble(dtBalance.Rows[0]["FINAL_CLAIMED"])), 2));
                            rntbRule80.Text = Convert.ToString(Convert.ToDouble(rnt_CurrencyAmt.Value));
                        else
                            rntbRule80.Text = lblMaxEligibleAmount.Text;


                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalFinalize", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Edit_Click(object sender, EventArgs e)
    {
        radAmount.Enabled = true;
        chk_Rule.Checked = false;
        chk_Rule.Enabled = true;
    }
}