using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SMHR;
using System.Data;
using Telerik.Web.UI;

public partial class Payroll_frm_Voluntary_Deduction_Detail : System.Web.UI.Page
{
    SMHR_VOLUNTARY_DEDUCTION_ARREARS _obj_smhr_voluntary_deduction_arrears = new SMHR_VOLUNTARY_DEDUCTION_ARREARS();
    SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
    SMHR_DIRECTORATE _obj_smhr_directorate = new SMHR_DIRECTORATE();
    SMHR_DEPARTMENT _obj_smhr_department = new SMHR_DEPARTMENT();
    SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
    SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();

    static int chkCount = 0;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("COUNTRY");
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
                    rgVolDedArrears.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btnSubmit.Visible = false;
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
                rcbBU.Focus();

                LoadFinancialPeriod();
                LoadBusinessUnit();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployees()
    {
        try
        {
            rcbEmp.Items.Clear();

            _obj_smhr_employee.EMP_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rcbBU.SelectedValue);
            if (rcbDir.SelectedIndex > 0)
                _obj_smhr_employee.EMP_DIRECTORATE_ID = Convert.ToInt32(rcbDir.SelectedValue);
            else
                _obj_smhr_employee.EMP_DIRECTORATE_ID = 0;
            if (rcbDept.SelectedIndex > 0)
                _obj_smhr_employee.EMP_DEPARTMENT_ID = Convert.ToInt32(rcbDept.SelectedValue);
            else
                _obj_smhr_employee.EMP_DEPARTMENT_ID = 0;

            DataTable dtEmp = BLL.Get_Applicant_NamesbyControls(_obj_smhr_employee);

            if (dtEmp.Rows.Count > 0)
            {
                rcbEmp.DataSource = dtEmp;
                rcbEmp.DataTextField = "APPLICANT_FULLNAME";
                rcbEmp.DataValueField = "EMP_ID";
                rcbEmp.DataBind();
            }
            rcbEmp.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    private void LoadBusinessUnit()
    {
        try
        {
            rcbBU.Items.Clear();

            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);

            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_smhr_logininfo);

            if (dt_BUDetails.Rows.Count > 0)
            {
                rcbBU.DataSource = dt_BUDetails;
                rcbBU.DataTextField = "BUSINESSUNIT_CODE";
                rcbBU.DataValueField = "BUSINESSUNIT_ID";
                rcbBU.DataBind();
            }
            rcbEmp.Items.Insert(0, new RadComboBoxItem("Select"));
            rcbBU.Items.Insert(0, new RadComboBoxItem("Select"));
            rcbDir.Items.Insert(0, new RadComboBoxItem("Select"));
            rcbDept.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadVolDedArrGrid()
    {
        try
        {
            _obj_smhr_voluntary_deduction_arrears.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_EMP_ID = Convert.ToInt32(rcbEmp.SelectedValue);
            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_BU_ID = Convert.ToInt32(rcbBU.SelectedValue);
            if (rcbDir.SelectedIndex > 0)
                _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_DIR_ID = Convert.ToInt32(rcbDir.SelectedValue);
            else
                _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_DIR_ID = 0;
            if (rcbDept.SelectedIndex > 0)
                _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_DEP_ID = Convert.ToInt32(rcbDept.SelectedValue);
            else
                _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_DEP_ID = 0;
            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_PERIOD_ID = Convert.ToInt32(rcbFinPrd.SelectedValue);
            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_PRDDTL_ID = Convert.ToInt32(rcbPrdDtl.SelectedValue);

            DataTable dtGrid = BLL.LOAD_VOL_DED_ARREARS_GRID(_obj_smhr_voluntary_deduction_arrears);
            //DataTable chkEmpSalDtlsData = BLL.CheckEmpSalDtlsData(_obj_smhr_voluntary_deduction_arrears);

            if (dtGrid.Rows.Count == 0)
                btnSubmit.Visible = false;
            else
                btnSubmit.Visible = true;

            rgVolDedArrears.DataSource = dtGrid;
            rgVolDedArrears.DataBind();

            if (dtGrid.Rows.Count == 0)
                btnSubmit.Visible = false;
            else
                btnSubmit.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadFinancialPeriod()
    {
        try
        {
            rcbFinPrd.Items.Clear();

            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dt_FinPrd = BLL.GET_FIN_PERIOD(_obj_smhr_period);

            if (dt_FinPrd.Rows.Count > 0)
            {
                rcbFinPrd.DataSource = dt_FinPrd;
                rcbFinPrd.DataTextField = "PERIOD_NAME";
                rcbFinPrd.DataValueField = "PERIOD_ID";
                rcbFinPrd.DataBind();
            }
            rcbFinPrd.Items.Insert(0, new RadComboBoxItem("Select"));
            rcbPrdDtl.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadPeriodDetailbyFinPrdID(int fpID)
    {
        try
        {
            rcbPrdDtl.Items.Clear();

            DataTable dtPrdDtl = BLL.GetPeriodDetailsbyFinPeriod(fpID);

            if (dtPrdDtl.Rows.Count > 0)
            {
                rcbPrdDtl.DataSource = dtPrdDtl;
                rcbPrdDtl.DataTextField = "PRDDTL_NAME";
                rcbPrdDtl.DataValueField = "PRDDTL_ID";
                rcbPrdDtl.DataBind();
            }
            rcbPrdDtl.Items.Insert(0, new RadComboBoxItem("Select"));
            rcbPrdDtl.Focus();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadDirectorate()
    {
        try
        {
            rcbDir.Items.Clear();

            _obj_smhr_directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_directorate.BUSINESSUNIT_ID = Convert.ToInt32(rcbBU.SelectedValue);

            DataTable dt_DirDetails = BLL.get_Directorate(_obj_smhr_directorate);

            if (dt_DirDetails.Rows.Count > 0)
            {
                rcbDir.DataSource = dt_DirDetails;

                rcbDir.DataTextField = "DIRECTORATE_CODE";
                rcbDir.DataValueField = "DIRECTORATE_ID";

                rcbDir.DataBind();
            }
            rcbDir.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadDepartment()
    {
        try
        {
            rcbDept.Items.Clear();

            _obj_smhr_department.MODE = 7;
            _obj_smhr_department.DIRECTORATE_ID = Convert.ToInt32(rcbDir.SelectedValue);
            _obj_smhr_department.BUID = Convert.ToInt32(rcbBU.SelectedValue);

            DataTable dt_Dir = BLL.get_Department(_obj_smhr_department);

            if (dt_Dir.Rows.Count > 0)
            {
                rcbDept.DataSource = dt_Dir;
                rcbDept.DataTextField = "DEPARTMENT_NAME";
                rcbDept.DataValueField = "DEPARTMENT_ID";
                rcbDept.DataBind();
            }
            rcbDept.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void EnableControls(bool isEnabled)
    {
        try
        {
            rcbBU.Enabled = isEnabled;
            rcbDir.Enabled = isEnabled;
            rcbDept.Enabled = isEnabled;
            rcbEmp.Enabled = isEnabled;
            rcbFinPrd.Enabled = isEnabled;
            rcbPrdDtl.Enabled = isEnabled;

            if (isEnabled == false)
                ViewState["value"] = 1;
            else
                ViewState["value"] = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rgVolDedArrears_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            _obj_smhr_voluntary_deduction_arrears.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_BU_ID = Convert.ToInt32(rcbBU.SelectedValue);
            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_PERIOD_ID = Convert.ToInt32(rcbFinPrd.SelectedValue);
            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_PRDDTL_ID = Convert.ToInt32(rcbPrdDtl.SelectedValue);

            DataTable dtVolDedArrGrid = BLL.LOAD_VOL_DED_ARREARS_GRID(_obj_smhr_voluntary_deduction_arrears);

            rgVolDedArrears.DataSource = dtVolDedArrGrid;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcbBU_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcbBU.SelectedIndex > 0)
            {
                LoadDirectorate();
                LoadEmployees();

                rcbDir.Focus();
            }
            else
            {
                rcbDir.Items.Clear();
                rcbDept.Items.Clear();
                rcbEmp.Items.Clear();

                rcbDir.Items.Insert(0, new RadComboBoxItem("Select"));
                rcbDept.Items.Insert(0, new RadComboBoxItem("Select"));
                rcbEmp.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcbDir_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcbDir.SelectedIndex > 0)
            {
                LoadDepartment();
                LoadEmployees();

                rcbDept.Focus();
            }
            else
            {
                rcbDept.Items.Clear();
                rcbEmp.Items.Clear();

                rcbDept.Items.Insert(0, new RadComboBoxItem("Select"));
                rcbEmp.Items.Insert(0, new RadComboBoxItem("Select"));

                LoadEmployees();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcbDept_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcbDept.SelectedIndex > 0)
            {
                LoadEmployees();
                rcbEmp.Focus();
            }
            else
            {
                rcbEmp.Items.Clear();
                rcbEmp.Items.Insert(0, new RadComboBoxItem("Select"));

                LoadEmployees();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcbFinPrd_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcbFinPrd.SelectedIndex > 0)
            {
                rcbPrdDtl.Items.Clear();

                int finPrd = Convert.ToInt32(rcbFinPrd.SelectedItem.Value);
                LoadPeriodDetailbyFinPrdID(finPrd);

                rcbPrdDtl.Focus();
            }
            else
            {
                rcbPrdDtl.Items.Clear();
                rcbPrdDtl.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcbPrdDtl_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rgVolDedArrears.Visible = false;
            btnSubmit.Visible = false;

            if (rcbPrdDtl.SelectedIndex > 0)
            {
                _obj_smhr_voluntary_deduction_arrears.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_EMP_ID = Convert.ToInt32(rcbEmp.SelectedValue);
                _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_BU_ID = Convert.ToInt32(rcbBU.SelectedValue);
                _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_PERIOD_ID = Convert.ToInt32(rcbFinPrd.SelectedValue);
                _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_PRDDTL_ID = Convert.ToInt32(rcbPrdDtl.SelectedValue);

                DataTable chkEmpSalDtlsData = BLL.CheckEmpSalDtlsData(_obj_smhr_voluntary_deduction_arrears);

                if (chkEmpSalDtlsData.Rows.Count > 0)
                {
                    BLL.ShowMessage(this, "Payroll is already generated for the Particular Period...");
                    return;
                }
                else
                    btnGenerate.Focus();
            }
            else
            {
                btnGenerate.Focus();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rgVolDedArrears_ItemDataBound(object sender, GridItemEventArgs e)
    {
        try
        {
            Label lbl_PayItemID;
            Label lbl_EligibleAmnt;
            Label lbl_ArrearsAmnt;
            CheckBox chk_Choose;
            RadNumericTextBox rntbMoney;
            RequiredFieldValidator rfv_Money;

            for (int i = 0; i < rgVolDedArrears.Items.Count; i++)
            {
                lbl_PayItemID = rgVolDedArrears.Items[i].FindControl("lbl_PayItemID") as Label;
                lbl_EligibleAmnt = rgVolDedArrears.Items[i].FindControl("lbl_EligibleAmnt") as Label;
                lbl_ArrearsAmnt = rgVolDedArrears.Items[i].FindControl("lbl_ArrearsAmnt") as Label;
                chk_Choose = rgVolDedArrears.Items[i].FindControl("chk_Choose") as CheckBox;
                rntbMoney = rgVolDedArrears.Items[i].FindControl("rntbMoney") as RadNumericTextBox;
                rfv_Money = rgVolDedArrears.Items[i].FindControl("rfv_Money") as RequiredFieldValidator;

                if (Convert.ToString(lbl_ArrearsAmnt.Text) != string.Empty)
                {
                    chk_Choose.Checked = true;
                    rntbMoney.Text = lbl_ArrearsAmnt.Text;
                }
                else
                {
                    chk_Choose.Checked = false;
                    rntbMoney.Text = string.Empty;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_voluntary_deduction_arrears.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_EMP_ID = Convert.ToInt32(rcbEmp.SelectedValue);
            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_BU_ID = Convert.ToInt32(rcbBU.SelectedValue);
            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_PERIOD_ID = Convert.ToInt32(rcbFinPrd.SelectedValue);
            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_PRDDTL_ID = Convert.ToInt32(rcbPrdDtl.SelectedValue);

            DataTable chkEmpSalDtlsData = BLL.CheckEmpSalDtlsData(_obj_smhr_voluntary_deduction_arrears);

            if (chkEmpSalDtlsData.Rows.Count > 0)
            {
                BLL.ShowMessage(this, "Payroll is already generated for the Particular Period...");

                LoadVolDedArrGrid();
                rgVolDedArrears.Visible = true;
                rgVolDedArrears.Enabled = false;
                btnSubmit.Visible = false;
            }
            else
            {
                rgVolDedArrears.Visible = true;
                btnSubmit.Visible = true;
                rgVolDedArrears.Enabled = true;

                LoadVolDedArrGrid();
            }
            EnableControls(false);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {

            rgVolDedArrears.Visible = false;
            btnSubmit.Visible = false;

            if (Convert.ToInt32(ViewState["value"]) == 1)
                EnableControls(true);
            else
            {
                rcbBU.SelectedIndex = 0;
                rcbDir.SelectedIndex = 0;
                rcbDept.SelectedIndex = 0;
                rcbFinPrd.SelectedIndex = 0;
                rcbPrdDtl.SelectedIndex = 0;
                rcbEmp.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int value = 0;

            Label lbl_PayItemID;
            Label lbl_EligibleAmnt;
            Label lbl_ArrearsAmnt;
            CheckBox chk_Choose;
            RadNumericTextBox rntbMoney;
            RequiredFieldValidator rfv_Money;

            for (int i = 0; i < rgVolDedArrears.Items.Count; i++)
            {
                lbl_PayItemID = rgVolDedArrears.Items[i].FindControl("lbl_PayItemID") as Label;
                lbl_EligibleAmnt = rgVolDedArrears.Items[i].FindControl("lbl_EligibleAmnt") as Label;
                lbl_ArrearsAmnt = rgVolDedArrears.Items[i].FindControl("lbl_ArrearsAmnt") as Label;
                chk_Choose = rgVolDedArrears.Items[i].FindControl("chk_Choose") as CheckBox;
                rntbMoney = rgVolDedArrears.Items[i].FindControl("rntbMoney") as RadNumericTextBox;
                rfv_Money = rgVolDedArrears.Items[i].FindControl("rfv_Money") as RequiredFieldValidator;

                if (chk_Choose.Checked)
                {
                    rfv_Money.Enabled = true;

                    if (rntbMoney.Text != string.Empty)
                    {
                        if (Convert.ToDecimal(rntbMoney.Text) > Convert.ToDecimal(lbl_EligibleAmnt.Text))
                        {
                            BLL.ShowMessage(this, "Please Enter less or equal Amount as shown in Balance Amount");
                            rntbMoney.Text = string.Empty;
                            rntbMoney.Focus();
                            return;
                        }

                        _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_EMP_ID = Convert.ToInt32(rcbEmp.SelectedValue);
                        _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_BU_ID = Convert.ToInt32(rcbBU.SelectedValue);
                        if (rcbDir.SelectedIndex > 0)
                            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_DIR_ID = Convert.ToInt32(rcbDir.SelectedValue);
                        if (rcbDept.SelectedIndex > 0)
                            _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_DEP_ID = Convert.ToInt32(rcbDept.SelectedValue);
                        _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_PERIOD_ID = Convert.ToInt32(rcbFinPrd.SelectedValue);
                        _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_PRDDTL_ID = Convert.ToInt32(rcbPrdDtl.SelectedValue);
                        _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_PAYITEM_ID = Convert.ToInt32(lbl_PayItemID.Text);
                        _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_AMOUNT = Convert.ToDecimal(rntbMoney.Text);
                        _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_STATUS = 0;
                        _obj_smhr_voluntary_deduction_arrears.VOLUNTARY_DEDUCTION_ARREARS_PAYTRANID = 0;
                        _obj_smhr_voluntary_deduction_arrears.CREATEDBY = Convert.ToInt32(Session["EMP_ID"]);
                        _obj_smhr_voluntary_deduction_arrears.CREATEDDATE = DateTime.Now;
                        _obj_smhr_voluntary_deduction_arrears.LASTMDFBY = Convert.ToInt32(Session["EMP_ID"]);
                        _obj_smhr_voluntary_deduction_arrears.LASTMDFDATE = DateTime.Now;

                        DataTable dtChkExists = BLL.CheckExistsVolDedArrearsData(_obj_smhr_voluntary_deduction_arrears);

                        if (Convert.ToInt32(dtChkExists.Rows[0]["COUNT"]) == 0)
                            _obj_smhr_voluntary_deduction_arrears.OPERATION = operation.Insert;
                        else
                        {
                            _obj_smhr_voluntary_deduction_arrears.OPERATION = operation.Update;
                            value++;
                        }

                        bool setVolDedArrs = BLL.set_SMHR_VOLUNTARY_DEDUCTION_ARREARS(_obj_smhr_voluntary_deduction_arrears);

                        if (setVolDedArrs == true)
                        {
                            chkCount++;
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Please Enter Amount");
                        rntbMoney.Focus();
                        return;
                    }
                }
                else
                {
                    rfv_Money.Enabled = false;
                }
            }
            if (chkCount > 0)
            {
                if (value == 0)
                    BLL.ShowMessage(this, "Selected Records Saved Successfully");
                else
                    BLL.ShowMessage(this, "Selected Records Updated Successfully");

                LoadVolDedArrGrid();
            }
            else
            {
                BLL.ShowMessage(this, "Please Choose Atleast One Record for Submitting Amount..");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            rgVolDedArrears.Visible = false;
            btnSubmit.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction_Detail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}