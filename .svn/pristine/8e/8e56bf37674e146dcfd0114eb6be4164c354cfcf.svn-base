using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class Masters_frmFoodAllowance : System.Web.UI.Page
{
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    SMHR_PAYROLL _obj_smhr_payroll;
    SMHR_LOGININFO _obj_smhr_logininfo;
    SMHR_PERIOD _obj_smhr_period;
    SMHR_FOODALLOWANCE _obj_FoodAllowance;
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
                    rgFoodAllowance.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btnSave.Visible = false;
                    //btn_Update.Visible = false;
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
                loadBusinessUnit();
                //loadPeriod();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmFoodAllowance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadBusinessUnit()
    {
        try
        {
            _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
            rcmbBusinessUnit.Items.Clear();
            rcmbBusinessUnit.DataSource = BLL.get_Business_Units(_obj_smhr_logininfo);
            rcmbBusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmbBusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmbBusinessUnit.DataBind();
            rcmbBusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmFoodAllowance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //public void loadPeriod()
    //{
    //    _obj_smhr_period = new SMHR_PERIOD();
    //    DataTable dt_Details = new DataTable();
    //    _obj_smhr_period.OPERATION = operation.Select;
    //    _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
    //    rcmbPeriod.DataSource = dt_Details;
    //    rcmbPeriod.DataValueField = "PERIOD_ID";
    //    rcmbPeriod.DataTextField = "PERIOD_NAME";
    //    rcmbPeriod.DataBind();
    //    rcmbPeriod.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
    //}

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcmbBusinessUnit.SelectedIndex > 0)
            {
                int countSaved = 0;
                int countChk = 0;
                Label lbl = new Label();
                RadNumericTextBox txt = new RadNumericTextBox();
                CheckBox chkCheck = new CheckBox();
                for (int iGridCount = 0; iGridCount < rgFoodAllowance.Items.Count; iGridCount++)
                {
                    lbl = rgFoodAllowance.Items[iGridCount].FindControl("lblEmpId") as Label;
                    txt = rgFoodAllowance.Items[iGridCount].FindControl("rntb") as RadNumericTextBox;
                    chkCheck = rgFoodAllowance.Items[iGridCount].FindControl("chkCheck") as CheckBox;
                    if (chkCheck.Checked)
                    {
                        countChk += 1;
                    }
                    if ((Convert.ToString(txt.Text) != ""))
                    {
                        if (chkCheck.Checked == false)
                        {
                            BLL.ShowMessage(this, "Please Select Employee(s)");
                            return;
                        }
                        _obj_FoodAllowance = new SMHR_FOODALLOWANCE();
                        _obj_FoodAllowance.FOODALLOWANCE_BU_ID = Convert.ToInt32(rcmbBusinessUnit.SelectedValue);
                        _obj_FoodAllowance.FOODALLOWANCE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_FoodAllowance.CREATEDDATE = DateTime.Now;
                        _obj_FoodAllowance.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_FoodAllowance.LASTMDFDATE = DateTime.Now;
                        _obj_FoodAllowance.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_FoodAllowance.FOODALLOWANCE_EMP_ID = Convert.ToInt32(lbl.Text);
                        _obj_FoodAllowance.FOODALLOWANCE_AMOUNT = Convert.ToDouble(txt.Text);
                        _obj_FoodAllowance.OPERATION = operation.Insert;
                        if (BLL.setFoodAllowance(_obj_FoodAllowance))
                            countSaved += 1;
                    }
                    else
                    {
                        _obj_FoodAllowance = new SMHR_FOODALLOWANCE();
                        _obj_FoodAllowance.OPERATION = operation.Delete;
                        _obj_FoodAllowance.FOODALLOWANCE_EMP_ID = Convert.ToInt32(lbl.Text);
                        _obj_FoodAllowance.FOODALLOWANCE_BU_ID = Convert.ToInt32(rcmbBusinessUnit.SelectedValue);
                        bool status = BLL.setFoodAllowance(_obj_FoodAllowance);
                    }
                }
                if (countChk > countSaved)
                {
                    BLL.ShowMessage(this, "All selected employee(s) are not provided with values");
                    return;
                }
                else
                {
                    BLL.ShowMessage(this, "Total records saved are : " + countSaved);
                }
                rgFoodAllowance.Visible = false;
                chkAll.Visible = false;
                loadBusinessUnit();
            }
            else
            {
                BLL.ShowMessage(this, "Please Select BusinessUnit");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmFoodAllowance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            rgFoodAllowance.Visible = false;
            loadBusinessUnit();
            chkAll.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmFoodAllowance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmbBusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            RadNumericTextBox txt = new RadNumericTextBox();
            CheckBox chkCheck = new CheckBox();
            if (rcmbBusinessUnit.SelectedIndex > 0)
            {
                _obj_FoodAllowance = new SMHR_FOODALLOWANCE();
                _obj_FoodAllowance.FOODALLOWANCE_BU_ID = Convert.ToInt32(rcmbBusinessUnit.SelectedValue);
                _obj_FoodAllowance.FOODALLOWANCE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_FoodAllowance.OPERATION = operation.Select;
                DataTable dt = BLL.getFoodAllowance(_obj_FoodAllowance);
                if (dt.Rows.Count > 0)
                {
                    rgFoodAllowance.Visible = true; ;
                    rgFoodAllowance.DataSource = dt;
                    rgFoodAllowance.DataBind();
                    for (int iGridCount = 0; iGridCount < rgFoodAllowance.Items.Count; iGridCount++)
                    {
                        txt = rgFoodAllowance.Items[iGridCount].FindControl("rntb") as RadNumericTextBox;
                        chkCheck = rgFoodAllowance.Items[iGridCount].FindControl("chkCheck") as CheckBox;
                        if (txt.Text != string.Empty)
                            chkCheck.Checked = true;
                    }
                }
                chkAll.Visible = true;
                chkAll.Checked = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmFoodAllowance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    //protected void rcmbPeriod_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    try
    //    {
    //        _obj_smhr_payroll = new SMHR_PAYROLL();
    //        _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmbPeriod.SelectedValue);
    //        _obj_smhr_payroll.MODE = 28;
    //        DataTable dtPeriodElement = BLL.get_payrolltrans(_obj_smhr_payroll);
    //        if (dtPeriodElement.Rows.Count != 0)
    //        {
    //            rcmbPeriodElement.DataSource = dtPeriodElement;
    //            rcmbPeriodElement.DataValueField = "PRDDTL_ID";
    //            rcmbPeriodElement.DataTextField = "PRDDTL_NAME";
    //            rcmbPeriodElement.DataBind();
    //            rcmbPeriodElement.Items.Insert(0, new RadComboBoxItem("Select"));
    //        }
    //        else
    //        {

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmFoodAllowance", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}
    //protected void rcmbPeriodElement_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    try
    //    {
    //        if (rcmbPeriodElement.SelectedIndex > 0)
    //        {
    //            _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
    //            _obj_smhr_emp_payitems.OPERATION = operation.Empty;
    //            _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmbBusinessUnit.SelectedItem.Value);
    //            _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            DataTable dt = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
    //            if (dt.Rows.Count > 0)
    //            {
    //                rgFoodAllowance.DataSource = dt;
    //                rgFoodAllowance.DataBind();
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmFoodAllowance", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}
    //protected void rgFoodAllowance_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    //{
    //    loadGrid();
    //}

    //public void loadGrid()
    //{
    //    _obj_FoodAllowance = new SMHR_FOODALLOWANCE();
    //    _obj_FoodAllowance.OPERATION = operation.Select;
    //    _obj_FoodAllowance.FOODALLOWANCE_BU_ID = Convert.ToInt32(rcmbBusinessUnit.SelectedValue);
    //    _obj_FoodAllowance.FOODALLOWANCE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    DataTable dt = BLL.getFoodAllowance(_obj_FoodAllowance);
    //    rgFoodAllowance.DataSource = dt;
    //}
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk = new CheckBox();
            if (chkAll.Checked)
            {
                for (int iGridCount = 0; iGridCount < rgFoodAllowance.Items.Count; iGridCount++)
                {
                    chk = rgFoodAllowance.Items[iGridCount].FindControl("chkCheck") as CheckBox;
                    chk.Checked = true;
                }
            }
            else
            {
                for (int iGridCount = 0; iGridCount < rgFoodAllowance.Items.Count; iGridCount++)
                {
                    chkAll = rgFoodAllowance.Items[iGridCount].FindControl("chkCheck") as CheckBox;
                    chkAll.Checked = false;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmFoodAllowance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
