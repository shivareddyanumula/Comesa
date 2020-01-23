using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class Payroll_frm_Voluntary_Deduction : System.Web.UI.Page
{
    SMHR_VOLUNTARY_DEDUCTION_DETAIL _obj_smhr_voluntary_deduction_detail = new SMHR_VOLUNTARY_DEDUCTION_DETAIL();
    SMHR_VOLUNTARY_DEDUCTION _obj_smhr_voluntary_deduction = new SMHR_VOLUNTARY_DEDUCTION();
    SMHR_BUSINESSUNIT _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
    SMHR_DIRECTORATE _obj_smhr_directorate = new SMHR_DIRECTORATE();
    SMHR_DEPARTMENT _obj_smhr_department = new SMHR_DEPARTMENT();
    SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
    SMHR_PAYITEMS _obj_smhr_payitems = new SMHR_PAYITEMS();
    SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
    SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();

    static int orgID = 0;
    static int count = 0;
    static int dedClickCount = 0;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("VOLUNTARY DEDUCTION");
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
                    rgVolDeduction.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                orgID = Convert.ToInt32(Session["ORG_ID"]);
                LoadBusinessUnit();
                rcbBU.Focus();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadBusinessUnit()
    {
        try
        {
            rcbBU.Items.Clear();

            _obj_smhr_logininfo.ORGANISATION_ID = orgID;
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);

            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_smhr_logininfo);

            if (dt_BUDetails.Rows.Count > 0)
            {
                rcbBU.DataSource = dt_BUDetails;

                rcbBU.DataTextField = "BUSINESSUNIT_CODE";
                rcbBU.DataValueField = "BUSINESSUNIT_ID";

                rcbBU.DataBind();
            }
            rcbBU.Items.Insert(0, new RadComboBoxItem("Select"));
            rcbDir.Items.Insert(0, new RadComboBoxItem("Select"));
            rcbDept.Items.Insert(0, new RadComboBoxItem("Select"));
            rcbEmp.Items.Insert(0, new RadComboBoxItem("Select"));
            rcbPayItem.Items.Insert(0, new RadComboBoxItem("Select"));
            rcbFinPrd.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadDirectorate()
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadDepartment()
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadEmployee()
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

            //DataTable dt_AllEmp = BLL.LOAD_ALLEMP_BY_CONTROLS(_obj_smhr_employee);
            DataTable dt_AllEmp = BLL.Get_Applicant_NamesbyControls(_obj_smhr_employee);

            if (dt_AllEmp.Rows.Count > 0)
            {
                rcbEmp.DataSource = dt_AllEmp;
                rcbEmp.DataTextField = "APPLICANT_FULLNAME";
                rcbEmp.DataValueField = "EMP_ID";
                rcbEmp.DataBind();
            }
            rcbEmp.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadPayItems()
    {
        try
        {
            rcbPayItem.Items.Clear();

            int orgID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dt_PayItems = BLL.get_PayItems_byOrgID(orgID);

            if (dt_PayItems.Rows.Count > 0)
            {
                rcbPayItem.DataSource = dt_PayItems;
                rcbPayItem.DataTextField = "PAYITEM_PAYITEMNAME";
                rcbPayItem.DataValueField = "PAYITEM_ID";
                rcbPayItem.DataBind();
            }
            rcbPayItem.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadFinancialPeriod()
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
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadVolDedGrid()
    {
        try
        {
            _obj_smhr_voluntary_deduction.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_BU_ID = Convert.ToInt32(rcbBU.SelectedValue);
            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_PERIOD_ID = Convert.ToInt32(rcbFinPrd.SelectedValue);
            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_EMP_ID = Convert.ToInt32(rcbEmp.SelectedValue);
            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_PAYITEM_ID = Convert.ToInt32(rcbPayItem.SelectedValue);
            if (rcbDir.SelectedIndex > 0)
                _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_DIR_ID = Convert.ToInt32(rcbDir.SelectedValue);
            if (rcbDept.SelectedIndex > 0)
                _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_DEP_ID = Convert.ToInt32(rcbDept.SelectedValue);
            //DataTable dt_LoadVolDedGrid = BLL.Load_Vol_Ded_Grid_New(_obj_smhr_voluntary_deduction);
            //DataTable dt_LoadVolDedGrid = BLL.LOAD_SMHR_VOLUNTARY_DEDUCTION(_obj_smhr_voluntary_deduction);
            //DataTable dt_LoadVolDedGrid = BLL.LOAD_FINAL_VOL_DED_GRID(_obj_smhr_voluntary_deduction);
            //DataTable dtGetDisposedAmnt = BLL.GetToBeDisposedAmnt(_obj_smhr_voluntary_deduction);
            DataTable dt_LoadVolDedGrid = BLL.LoadVolDedGrid(_obj_smhr_voluntary_deduction);

            if (dt_LoadVolDedGrid.Rows.Count == 0)
                btnSubmit.Visible = false;
            else
                btnSubmit.Visible = true;

            rgVolDeduction.DataSource = dt_LoadVolDedGrid;
            rgVolDeduction.DataBind();

            LoadCalMode();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadCalMode()
    {
        try
        {
            double totAmnt = 0;

            _obj_smhr_voluntary_deduction.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_BU_ID = Convert.ToInt32(rcbBU.SelectedValue);
            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_PERIOD_ID = Convert.ToInt32(rcbFinPrd.SelectedValue);
            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_PAYITEM_ID = Convert.ToInt32(rcbPayItem.SelectedValue);
            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_EMP_ID = Convert.ToInt32(rcbEmp.SelectedValue);

            DataTable dtCalMode = BLL.GetCalModeType(_obj_smhr_voluntary_deduction);
            DataTable dtChkEmpSalDetils = BLL.Load_Vol_Ded_Grid_New(_obj_smhr_voluntary_deduction);
            //DataTable dtChkEmpSalDetils = BLL.ChekEmpSalData(_obj_smhr_voluntary_deduction);

            if (dtCalMode.Rows.Count > 0)
            {
                rcbCalMode.Enabled = false;

                if (Convert.ToString(dtCalMode.Rows[0]["VOLUNTARY_DEDUCTION_CALCULATION_MODE"]) == "Direct")
                    rcbCalMode.SelectedValue = "2";
                else
                    rcbCalMode.SelectedValue = "1";
            }
            else
            {
                rcbCalMode.SelectedValue = "0";
                rcbCalMode.Enabled = true;
            }

            if (Convert.ToInt32(dtChkEmpSalDetils.Rows.Count) > 0)
            {
                for (int i = 0; i < dtChkEmpSalDetils.Rows.Count; i++)
                {
                    totAmnt = totAmnt + Convert.ToDouble(dtChkEmpSalDetils.Rows[i]["EMPSALDTLS_AMOUNT"]);
                }
            }

            ViewState["totAmnt"] = totAmnt;

            /*if (totAmnt > 0)
                btnDeduction.Visible = true;
            else
                btnDeduction.Visible = false;*/
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
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
            rcbPayItem.Enabled = isEnabled;

            if (isEnabled == false)
                ViewState["value"] = 1;
            else
                ViewState["value"] = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
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
                LoadFinancialPeriod();
                LoadPayItems();
                LoadEmployee();

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
                rcbPayItem.Items.Insert(0, new RadComboBoxItem("Select"));
                rcbFinPrd.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
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
                LoadEmployee();

                rcbDept.Focus();
            }
            else
            {
                rcbDept.Items.Clear();
                rcbEmp.Items.Clear();

                rcbDept.Items.Insert(0, new RadComboBoxItem("Select"));
                rcbEmp.Items.Insert(0, new RadComboBoxItem("Select"));

                LoadEmployee();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcbDept_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcbDept.SelectedIndex > 0)
            {
                LoadEmployee();
                rcbEmp.Focus();
            }
            else
            {
                rcbEmp.Items.Clear();
                rcbEmp.Items.Insert(0, new RadComboBoxItem("Select"));

                LoadEmployee();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    /*protected void rcbEmp_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcbEmp.SelectedIndex > 0)
            {
                //LoadEmployee();
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rcbPayItem_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //Load based upon org ID    SMHR_PERIOD
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rcbFinPrd_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //Load based upon org ID    SMHR_PAYITEMS
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }*/

    protected void btnDeduction_Click(object sender, EventArgs e)
    {
        try
        {
            //double dedAmount = 0;

            //btnDeduction.Visible = false;
            //btnBack.Visible = true;
            //pnlDeductions.Visible = true;

            btnSubmit.Visible = false;
            btnGenerate.Visible = false;
            btnClear.Visible = false;

            //dedAmount = Convert.ToDouble(ViewState["totAmnt"]) - Convert.ToDouble(ViewState["AMOUNT"]);
            //rntbAvailAmnt.Text = dedAmount.ToString();
            //rntbDeductedAmnt.Text = string.Empty;
            //rntbDeductedAmnt.Focus();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            //btnDeduction.Visible = true;
            //btnBack.Visible = false;
            //pnlDeductions.Visible = false;

            btnSubmit.Visible = true;
            btnGenerate.Visible = true;
            btnClear.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rgVolDeduction_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            _obj_smhr_voluntary_deduction.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_BU_ID = Convert.ToInt32(rcbBU.SelectedValue);
            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_PERIOD_ID = Convert.ToInt32(rcbFinPrd.SelectedValue);
            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_EMP_ID = Convert.ToInt32(rcbEmp.SelectedValue);
            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_PAYITEM_ID = Convert.ToInt32(rcbPayItem.SelectedValue);

            //DataTable dt_LoadVolDedGrid = BLL.Load_Vol_Ded_Grid_New(_obj_smhr_voluntary_deduction);
            //DataTable dt_LoadVolDedGrid = BLL.LOAD_SMHR_VOLUNTARY_DEDUCTION(_obj_smhr_voluntary_deduction);
            //DataTable dt_LoadVolDedGrid = BLL.LOAD_FINAL_VOL_DED_GRID(_obj_smhr_voluntary_deduction);

            DataTable dt_LoadVolDedGrid = BLL.LoadVolDedGrid(_obj_smhr_voluntary_deduction);

            rgVolDeduction.DataSource = dt_LoadVolDedGrid;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rgVolDeduction_ItemDataBound(object sender, GridItemEventArgs e)
    {
        try
        {
            CheckBox chk_Choose;
            Label lbl_PrdDtlID;
            RadNumericTextBox rntbMoney;

            _obj_smhr_voluntary_deduction.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_BU_ID = Convert.ToInt32(rcbBU.SelectedValue);
            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_PERIOD_ID = Convert.ToInt32(rcbFinPrd.SelectedValue);
            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_PAYITEM_ID = Convert.ToInt32(rcbPayItem.SelectedValue);
            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_EMP_ID = Convert.ToInt32(rcbEmp.SelectedValue);

            DataTable dt_LoadVolDedGrid = BLL.LoadVolDedGrid(_obj_smhr_voluntary_deduction);
            //DataTable dt_LoadVolDedGrid = BLL.LOAD_FINAL_VOL_DED_GRID(_obj_smhr_voluntary_deduction);
            DataTable dt_prdDtl = BLL.ChekEmpSalData(_obj_smhr_voluntary_deduction);

            for (int index = 0; index < rgVolDeduction.Items.Count; index++)
            {
                chk_Choose = rgVolDeduction.Items[index].FindControl("chk_Choose") as CheckBox;
                rntbMoney = rgVolDeduction.Items[index].FindControl("rntbMoney") as RadNumericTextBox;
                lbl_PrdDtlID = rgVolDeduction.Items[index].FindControl("lbl_PrdDtlID") as Label;

                rntbMoney.Text = dt_LoadVolDedGrid.Rows[index]["VOLUNTARY_DEDUCTION_DETAIL_AMOUNT"].ToString();
                if (rntbMoney.Text != string.Empty)
                    chk_Choose.Checked = true;
                /*if (lbl_PrdDtlMoney.Text != string.Empty)
                {
                    chk_Choose.Checked = true;
                    rgVolDeduction.Items[index].Enabled = false;
                    rntbMoney.Text = dt_LoadVolDedGrid.Rows[index]["VOLUNTARY_DEDUCTION_DETAIL_AMOUNT"].ToString();
                }
                else
                {
                    chk_Choose.Checked = false;
                    rgVolDeduction.Items[index].Enabled = true;
                    rntbMoney.Text = string.Empty;
                }*/

                for (int i = 0; i < dt_prdDtl.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt_prdDtl.Rows[i]["EMPSALDTLS_PRDDTL_ID"]) == Convert.ToInt32(lbl_PrdDtlID.Text))
                    {
                        rgVolDeduction.Items[index].Enabled = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        #region Commented
        /*DataTable dtChkEmpSalDetils = BLL.Load_Vol_Ded_Grid_New(_obj_smhr_voluntary_deduction);
        DataTable dtGetVolDedAmnt = BLL.GetVolDedAmount(_obj_smhr_voluntary_deduction);

        for (int index = 0; index < rgVolDeduction.Items.Count; index++)
        {
            chk_Choose = rgVolDeduction.Items[index].FindControl("chk_Choose") as CheckBox;
            lbl_PrdDtlID = rgVolDeduction.Items[index].FindControl("lbl_PrdDtlID") as Label;
            rntbMoney = rgVolDeduction.Items[index].FindControl("rntbMoney") as RadNumericTextBox;

            if ((dtChkEmpSalDetils.Rows.Count >= rgVolDeduction.Items.Count) || (dtGetVolDedAmnt.Rows.Count >= rgVolDeduction.Items.Count))
            {
                if (dtGetVolDedAmnt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtGetVolDedAmnt.Rows[index]["VOLUNTARY_DEDUCTION_DETAIL_PRDDTL_ID"]) == Convert.ToInt32(lbl_PrdDtlID.Text))
                    {
                        chk_Choose.Checked = true;
                        rgVolDeduction.Items[index].Enabled = false;
                        rntbMoney.Text = dtGetVolDedAmnt.Rows[index]["VOLUNTARY_DEDUCTION_DETAIL_AMOUNT"].ToString();
                    }
                    else if (dtChkEmpSalDetils.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtChkEmpSalDetils.Rows[index]["EMPSALDTLS_PRDDTL_ID"]) == Convert.ToInt32(lbl_PrdDtlID.Text))
                        {
                            chk_Choose.Checked = true;
                            rgVolDeduction.Items[index].Enabled = false;
                            rntbMoney.Text = dtChkEmpSalDetils.Rows[index]["EMPSALDTLS_AMOUNT"].ToString();
                        }
                    }
                    else
                    {
                        chk_Choose.Checked = false;
                        rgVolDeduction.Items[index].Enabled = true;
                        rntbMoney.Text = string.Empty;
                    }
                }
                else if (dtChkEmpSalDetils.Rows.Count > 0)
                {
                    if (dtGetVolDedAmnt.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtGetVolDedAmnt.Rows[index]["VOLUNTARY_DEDUCTION_DETAIL_PRDDTL_ID"]) == Convert.ToInt32(lbl_PrdDtlID.Text))
                        {
                            chk_Choose.Checked = true;
                            rgVolDeduction.Items[index].Enabled = false;
                            rntbMoney.Text = dtGetVolDedAmnt.Rows[index]["VOLUNTARY_DEDUCTION_DETAIL_AMOUNT"].ToString();
                        }
                    }
                    else if (Convert.ToInt32(dtChkEmpSalDetils.Rows[index]["EMPSALDTLS_PRDDTL_ID"]) == Convert.ToInt32(lbl_PrdDtlID.Text))
                    {
                        chk_Choose.Checked = true;
                        rgVolDeduction.Items[index].Enabled = false;
                        rntbMoney.Text = dtChkEmpSalDetils.Rows[index]["EMPSALDTLS_AMOUNT"].ToString();
                    }
                    else
                    {
                        chk_Choose.Checked = false;
                        rgVolDeduction.Items[index].Enabled = true;
                        rntbMoney.Text = string.Empty;
                    }
                }
                else
                {
                    chk_Choose.Checked = false;
                    rgVolDeduction.Items[index].Enabled = true;
                    rntbMoney.Text = string.Empty;
                }
            }
            else
            {
                chk_Choose.Checked = false;
                rgVolDeduction.Items[index].Enabled = true;
                rntbMoney.Text = string.Empty;
            }
        }*/
        #endregion
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            rgVolDeduction.Visible = true;
            btnSubmit.Visible = true;

            LoadVolDedGrid();
            LoadCalMode();
            EnableControls(false);
            pnlCalMode.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string calMode = string.Empty;

            if (rcbCalMode.SelectedIndex == 0)
            {
                BLL.ShowMessage(this, "Please Select Calculation Mode");
                rcbCalMode.Focus();
                return;
            }
            else
            {
                calMode = rcbCalMode.SelectedItem.Text;
            }

            Label lbl_PrdDtlID;
            CheckBox chk_Choose;
            RadNumericTextBox rntbMoney;
            RequiredFieldValidator rfv_Money;

            for (int i = 0; i < rgVolDeduction.Items.Count; i++)
            {
                lbl_PrdDtlID = rgVolDeduction.Items[i].FindControl("lbl_PrdDtlID") as Label;
                chk_Choose = rgVolDeduction.Items[i].FindControl("chk_Choose") as CheckBox;
                rntbMoney = rgVolDeduction.Items[i].FindControl("rntbMoney") as RadNumericTextBox;
                rfv_Money = rgVolDeduction.Items[i].FindControl("rfv_Money") as RequiredFieldValidator;

                if (chk_Choose.Checked)
                {
                    count++;
                    rfv_Money.Enabled = true;

                    if (rntbMoney.Text != string.Empty)
                    {
                        _obj_smhr_voluntary_deduction.OPERATION = operation.Insert;
                        _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_BU_ID = Convert.ToInt32(rcbBU.SelectedValue);
                        if (rcbDept.SelectedIndex > 0)
                            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_DEP_ID = Convert.ToInt32(rcbDept.SelectedValue);
                        if (rcbDir.SelectedIndex > 0)
                            _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_DIR_ID = Convert.ToInt32(rcbDir.SelectedValue);
                        _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_EMP_ID = Convert.ToInt32(rcbEmp.SelectedValue);
                        _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_PAYITEM_ID = Convert.ToInt32(rcbPayItem.SelectedValue);
                        _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_PERIOD_ID = Convert.ToInt32(rcbFinPrd.SelectedValue);
                        //_obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_AMOUNT_DISPOSED = 0;
                        //_obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_AMOUNT_TOBEDISPOSED = 0;
                        _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_CALCUALTION_MODE = calMode;
                        _obj_smhr_voluntary_deduction.CREATEDBY = Convert.ToInt32(Session["EMP_ID"]);
                        _obj_smhr_voluntary_deduction.CREATEDDATE = DateTime.Now;

                        DataTable chkEmpExists = BLL.CheckEmpVolDedDataExists(_obj_smhr_voluntary_deduction);
                        if (Convert.ToInt32(chkEmpExists.Rows[0]["COUNT"]) == 0)
                        {
                            dedClickCount = 0;

                            bool volDedStatus = BLL.set_SMHR_VOLUNTARY_DEDUCTION(_obj_smhr_voluntary_deduction);
                        }

                        DataTable dtVolDedID = BLL.GetVolDedIDbyEmployee(_obj_smhr_voluntary_deduction);
                        if (Convert.ToInt32(dtVolDedID.Rows[0]["VOLUNTARY_DEDUCTION_ID"]) != 0)
                        {
                            _obj_smhr_voluntary_deduction_detail.VOLUNTARY_DEDUCTION_DETAIL_VOLDED_ID = Convert.ToInt32(dtVolDedID.Rows[0]["VOLUNTARY_DEDUCTION_ID"]);
                            _obj_smhr_voluntary_deduction_detail.VOLUNTARY_DEDUCTION_DETAIL_PRDDTL_ID = Convert.ToInt32(lbl_PrdDtlID.Text);
                            if (calMode == "%Age")
                            {
                                if (Convert.ToDecimal(rntbMoney.Text) > 100)
                                {
                                    BLL.ShowMessage(this, "Please Enter Equal or less than 100..");
                                    rntbMoney.Focus();
                                    return;
                                }
                                else
                                {
                                    _obj_smhr_voluntary_deduction_detail.VOLUNTARY_DEDUCTION_DETAIL_AMOUNT = Convert.ToDecimal(rntbMoney.Text);
                                }
                            }
                            else
                                _obj_smhr_voluntary_deduction_detail.VOLUNTARY_DEDUCTION_DETAIL_AMOUNT = Convert.ToDecimal(rntbMoney.Text);
                            _obj_smhr_voluntary_deduction_detail.VOLUNTARY_DEDUCTION_DETAIL_STATUS = true;
                            _obj_smhr_voluntary_deduction_detail.CREATEDBY = Convert.ToInt32(Session["EMP_ID"]);
                            _obj_smhr_voluntary_deduction_detail.CREATEDDATE = DateTime.Now;

                            DataTable chkVolDedDetailData = BLL.Check_SMHR_VOLUNTARY_DEDUCTION_DETAIL(_obj_smhr_voluntary_deduction_detail);

                            if (Convert.ToInt32(chkVolDedDetailData.Rows[0]["COUNT"]) == 0)
                            {
                                _obj_smhr_voluntary_deduction_detail.OPERATION = operation.Insert;

                                bool volDedDtlStatusInst = BLL.set_SMHR_VOLUNTARY_DEDUCTION_DETAIL(_obj_smhr_voluntary_deduction_detail);
                                if (volDedDtlStatusInst == true)
                                    count++;
                            }
                            else
                            {
                                _obj_smhr_voluntary_deduction_detail.OPERATION = operation.Update;

                                bool volDedDtlStatusInst = BLL.set_SMHR_VOLUNTARY_DEDUCTION_DETAIL(_obj_smhr_voluntary_deduction_detail);
                                if (volDedDtlStatusInst == true)
                                    count++;
                            }
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Please Enter Amount for Deduction..");
                        rntbMoney.Focus();
                        return;
                    }
                }
                else
                {
                    rfv_Money.Enabled = false;
                }
            }
            if (count > 0)
            {
                if (dedClickCount == 0)
                    BLL.ShowMessage(this, "Selected Records Saved Successfully");

                LoadVolDedGrid();
            }
            else
            {
                BLL.ShowMessage(this, "Please Enter Atleast One Record for Deduction..");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            btnSubmit.Visible = false;
            rgVolDeduction.Visible = false;
            //btnBack.Visible = false;
            //btnDeduction.Visible = false;
            //pnlDeductions.Visible = false;
            pnlCalMode.Visible = false;

            if (Convert.ToInt32(ViewState["value"]) == 1)
                EnableControls(true);
            else
            {
                rcbDir.Items.Clear();
                rcbDept.Items.Clear();
                rcbEmp.Items.Clear();
                rcbPayItem.Items.Clear();
                rcbFinPrd.Items.Clear();

                rcbBU.SelectedIndex = 0;

                rcbDir.Items.Insert(0, new RadComboBoxItem("Select"));
                rcbDept.Items.Insert(0, new RadComboBoxItem("Select"));
                rcbEmp.Items.Insert(0, new RadComboBoxItem("Select"));
                rcbPayItem.Items.Insert(0, new RadComboBoxItem("Select"));
                rcbFinPrd.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Voluntary_Deduction", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    /*protected void btnDeduct_Click(object sender, EventArgs e)
    {
        try
        {
            if (rntbDeductedAmnt.Text != string.Empty)
            {
                if (Convert.ToDouble(rntbAvailAmnt.Text) < Convert.ToDouble(rntbDeductedAmnt.Text))
                {
                    BLL.ShowMessage(this, "Please Enter less or equal Amount as shown in Available Amount");
                    rntbDeductedAmnt.Focus();
                    return;
                }
                else
                {
                    //_obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_AMOUNT_TOBEDISPOSED = Convert.ToDecimal(rntbDeductedAmnt.Text);
                    _obj_smhr_voluntary_deduction.LASTMDFBY = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_smhr_voluntary_deduction.LASTMDFDATE = DateTime.Now;
                    _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_EMP_ID = Convert.ToInt32(rcbEmp.SelectedValue);
                    _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_BU_ID = Convert.ToInt32(rcbBU.SelectedValue);
                    _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_PERIOD_ID = Convert.ToInt32(rcbFinPrd.SelectedValue);
                    _obj_smhr_voluntary_deduction.VOLUNTARY_DEDUCTION_PAYITEM_ID = Convert.ToInt32(rcbPayItem.SelectedValue);

                    DataTable dtChkVolDedExists1 = BLL.CheckEmpVolDedDataExists(_obj_smhr_voluntary_deduction);
                    if (Convert.ToInt32(dtChkVolDedExists1.Rows[0]["Count"]) == 0)
                    {
                        dedClickCount = 1;
                        btnSubmit_Click(sender, e);
                    }
                    //else
                    //{
                    //    return;
                    //}
                    DataTable dtChkVolDedExists2 = BLL.CheckEmpVolDedDataExists(_obj_smhr_voluntary_deduction);
                    if (Convert.ToInt32(dtChkVolDedExists2.Rows[0]["Count"]) > 0)
                    {
                        _obj_smhr_voluntary_deduction.OPERATION = operation.Update;
                        bool updateAmnt = BLL.set_SMHR_VOLUNTARY_DEDUCTION(_obj_smhr_voluntary_deduction);

                        if (updateAmnt == true)
                        {
                            BLL.ShowMessage(this, "Entered Amount has been deducted from ur Savings..");
                            
                            LoadVolDedGrid();
                            LoadCalMode();
                            btnDeduction.Visible = false;
                            rntbAvailAmnt.Text = Convert.ToString(Convert.ToDouble(rntbAvailAmnt.Text) - Convert.ToDouble(rntbDeductedAmnt.Text));
                            rntbDeductedAmnt.Text = string.Empty;
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Entered Amount has not been deducted from ur Savings..");
                            return;
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "There are no records to Update..Need to enter Data !");
                        rntbDeductedAmnt.Text = string.Empty;
                        rntbDeductedAmnt.Focus();
                        return;
                    }
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please Enter Amount for Deduction from Savings..");
                rntbDeductedAmnt.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnCancelDeduct_Click(object sender, EventArgs e)
    {
        rntbDeductedAmnt.Text = string.Empty;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }*/
}