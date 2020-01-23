using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SMHR;
using Telerik.Web.UI;


using System.Web.UI.HtmlControls;

public partial class Payroll_frm_vpms_trans : System.Web.UI.Page
{
    #region References

    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
    SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
    SMHR_VARIABLEAMT _obj_vamt = new SMHR_VARIABLEAMT();
    DataTable dt_Result = new DataTable();
    DataTable dt_Compare = new DataTable();
    SMHR_PAYROLL _obj_smhr_payroll;
    #endregion
    #region PageLoad
    /// <summary>
    /// Loading Business Units which are having Variable Pay And Financial Periods
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                RG_Vpay.Visible = false;
                _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_vamt.user_id = Convert.ToInt32(Session["USER_ID"].ToString());
                _obj_vamt.OPERATION = operation.Check;
                rcbBusinessUnit.Items.Clear();
                dt_Result = BLL.get_Employeevariableamt(_obj_vamt);
                rcbBusinessUnit.DataSource = dt_Result;
                rcbBusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                rcbBusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                rcbBusinessUnit.DataBind();
                rcbBusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

                _obj_smhr_period.OPERATION = operation.Select;//Method Related To Bonus
                _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                dt_Result = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
                rcbFinancialPeriod.DataSource = dt_Result;
                rcbFinancialPeriod.DataValueField = "PERIOD_ID";
                rcbFinancialPeriod.DataTextField = "PERIOD_NAME";
                rcbFinancialPeriod.DataBind();
                rcbFinancialPeriod.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //rcbFinancialPeriod.Visible = false;
                btnSave.Visible = false;
                btnFinalise.Visible = false;
                btn_Calculate.Visible = false;



                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Performance Bonus");//COUNTRY");
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
                    RG_Vpay.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btnSave.Visible = false;
                    //  btn_Update.Visible = false;
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
        }
        catch (Exception ex)
        {
            BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_vpms_trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        //LoadCombos();


    }
    #endregion
    #region Selected Index Changed Events
    /// <summary>
    /// All Events Which will Fire Selected Index Change Events Are Defined Here
    /// Based on the financial period user selected Loads all periods under that financial period
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcbBusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcbBusinessUnit.SelectedIndex > 0)
            {
                rcbFinancialPeriod.ClearSelection();
            }
            else
            {
                rcbFinancialPeriod.ClearSelection();
                rcbPeriodID.Items.Clear();
                rcbPeriodID.Items.Insert(0, new RadComboBoxItem("", ""));
            }
        }
        catch (Exception ex)
        {
            BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_vpms_trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcbFinancialPeriod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        // LOADS PERIOD WHICH ARE UNDER THAT FINANCIAL PERIODS
        try
        {
            if ((rcbBusinessUnit.SelectedIndex > 0) && (rcbFinancialPeriod.SelectedIndex > 0))
            {
                _obj_smhr_payroll = new SMHR_PAYROLL();
                _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcbFinancialPeriod.SelectedItem.Value);
                _obj_smhr_payroll.MODE = 11;
                dt_Result = BLL.get_payrolltrans(_obj_smhr_payroll);
                rcbPeriodID.DataSource = dt_Result;
                rcbPeriodID.DataValueField = "PRDDTL_ID";
                rcbPeriodID.DataTextField = "PRDDTL_NAME";
                rcbPeriodID.DataBind();
                rcbPeriodID.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                RG_Vpay.Visible = false;
            }
            else
            {
                BLL.ShowMessage(this, "Select Proper Financial Period For Proper Businesunit");
                rcbBusinessUnit.ClearSelection();
                rcbFinancialPeriod.ClearSelection();
                rcbPeriodID.Items.Clear();
                rcbPeriodID.Items.Insert(0, new RadComboBoxItem("", ""));
                RG_Vpay.Visible = false;
            }
        }
        catch (Exception ex)
        {
            BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_vpms_trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void chk_selectall_CheckedChanged(object sender, EventArgs e)
    {
        // FOR SELECTION OF ALL EMPLOYEE WHEN ONE IS CHECKED
        try
        {
            CheckBox all = (CheckBox)sender;
            if (all.Checked)
            {
                for (int row = 0; row < RG_Vpay.Items.Count; row++)
                {
                    CheckBox checkrow = (CheckBox)RG_Vpay.Items[row].FindControl("chckbtn_Select");
                    if (checkrow.Enabled)
                        checkrow.Checked = true;
                }
            }
            else
            {
                for (int row = 0; row < RG_Vpay.Items.Count; row++)
                {
                    CheckBox checkrow = (CheckBox)RG_Vpay.Items[row].FindControl("chckbtn_Select");
                    checkrow.Checked = false;
                }
            }
        }
        catch (Exception ex)
        {
            BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_vpms_trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcbPeriodID_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        // BASED ON THE PERIOD USER CHOOSEN WE WILL GET THE EMPLOYEES LIST WHO ARE CHECKED THAT PARTICULAR PERIOD AND PREVIOUS PERIODS WHICH THEY DIDN'T PAID
        try
        {
            if (rcbPeriodID.SelectedIndex > 0)
            {
                //RG_Vpay.Visible = true;
                if ((rcbBusinessUnit.SelectedIndex > 0) && (rcbFinancialPeriod.SelectedIndex > 0))
                {
                    rcbBusinessUnit.Enabled = false;

                    rcbFinancialPeriod.Enabled = false;
                    _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_vamt.BUID = Convert.ToInt32(rcbBusinessUnit.SelectedValue);
                    _obj_vamt.financial_period = Convert.ToInt32(rcbFinancialPeriod.SelectedValue);
                    _obj_vamt.EMPSALDTLS_PRDDTL_ID = Convert.ToInt32(rcbPeriodID.SelectedValue);//FETCHING THE EMPLOYEE SELECTED PERIODS WITH THIS PERIOD AND ALSO PREVIOUS PERIODS WHICH ARE NOT PAID
                    dt_Result = BLL.get_employee_varamt(_obj_vamt);
                    if (dt_Result.Rows.Count > 0)
                    {
                        RG_Vpay.Visible = true;
                        RG_Vpay.DataSource = dt_Result;
                        RG_Vpay.DataBind();
                        //btnSave.Visible = true;
                        //TO CHECK WHETHER PAYROLL IS APPROVED FOR SELECTED PERIOD ELEMENT OR NOT
                        _obj_vamt.OPERATION = operation.Empty1;
                        _obj_vamt.emp_period = Convert.ToInt32(rcbPeriodID.SelectedItem.Value);
                        DataTable dt_payroll = BLL.get_empdoj(_obj_vamt);
                        if (dt_payroll.Rows.Count > 0)
                        {
                            BLL.ShowMessage(this, "Payroll is Approved for this Period Element.Please Select other Element.");
                            RG_Vpay.Enabled = false;
                            btnFinalise.Visible = false;
                            btn_Calculate.Visible = false;
                            //return;
                        }
                        else
                        {
                            RG_Vpay.Enabled = true;
                            btnFinalise.Visible = true;
                            btn_Calculate.Visible = true;
                        }
                        for (int index = 0; index < RG_Vpay.Items.Count; index++)
                        {
                            RadNumericTextBox percentage = (RadNumericTextBox)RG_Vpay.Items[index].FindControl("rtxt_percentage");
                            RadNumericTextBox AMOUNT = (RadNumericTextBox)RG_Vpay.Items[index].FindControl("rtxt_amount");
                            percentage.MinValue = Convert.ToInt32(dt_Result.Rows[index]["MIN"].ToString());
                            percentage.MaxValue = Convert.ToInt32(dt_Result.Rows[index]["MAX"].ToString());
                            //if ((dt_Result.Rows[index]["VAR_EMP_ISFINALISED"].ToString() != string.Empty) && (dt_Result.Rows[index]["VAR_PERCENTAGE"].ToString() != string.Empty))
                            if ((dt_Result.Rows[index]["SMHR_EMPPERFORM_ISFINALISED"].ToString() != string.Empty))
                            {
                                if (dt_Result.Rows[index]["SMHR_EMPPERFORM_ISFINALISED"].ToString() == Convert.ToString(true))
                                {
                                    RG_Vpay.Items[index].Enabled = false;
                                    CheckBox checkrow = (CheckBox)RG_Vpay.Items[index].FindControl("chckbtn_Select");
                                    checkrow.Enabled = false;
                                    // CheckBox all = (CheckBox)RG_Vpay.Items[0].FindControl("chk_selectall");
                                    //CheckBox all = (CheckBox)RG_Vpay.HeaderContextMenu.TemplateControl.FindControl("chk_selectall");
                                    //CheckBox all = (CheckBox)RG_Vpay.Items[0].TemplateControl.FindControl("chk_selectall");
                                    //GridHeaderItem header=RG_Vpay.MasterTableView.GetItems(GridHeaderItem. 
                                    //GridHeaderItem header = RG_Vpay.MasterTableView.GetItems(GridItemType.Header);
                                    //foreach (GridHeaderItem headerItem in RG_Vpay.MasterTableView.GetItems(GridItemType.Header))
                                    //{
                                    //    CheckBox chk = (CheckBox)headerItem["Check"].Controls[0]; // Get the header checkbox
                                    //    chk.Enabled = false;
                                    //    chk.Checked = false;
                                    //}
                                    percentage.Text = dt_Result.Rows[index]["VAR_PERCENTAGE"].ToString();
                                    percentage.Enabled = false;
                                    AMOUNT.Text = dt_Result.Rows[index]["VAR_EMP_PAYABLEAMT"].ToString();
                                    AMOUNT.Enabled = false;
                                }
                                else
                                {
                                    percentage.Text = dt_Result.Rows[index]["VAR_PERCENTAGE"].ToString();
                                    percentage.Enabled = true;
                                    AMOUNT.Text = dt_Result.Rows[index]["VAR_EMP_PAYABLEAMT"].ToString();
                                    AMOUNT.Enabled = false;
                                }

                            }
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "No Employee Has Selected For this Period For Paying Variable Amout");
                        RG_Vpay.Visible = false;
                        btn_Calculate.Visible = false;
                    }

                }

                else
                {
                    BLL.ShowMessage(this, "Select Proper Businessunit or Financial Period!");
                    rcbFinancialPeriod.ClearSelection();
                    rcbPeriodID.Items.Clear();
                    RG_Vpay.DataSource = null;
                    RG_Vpay.DataBind();
                    RG_Vpay.Visible = false;
                    btn_Calculate.Visible = false;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Select A Period");
                RG_Vpay.Visible = false;
                btn_Calculate.Visible = false;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_vpms_trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void rtxt_percentage_TextChanged(object sender, EventArgs e)
    //{
    //    // FOR LOADING THE AMOUNT BASED ON THE PERCENTAGE ENTERED BY THE USER IN THE GRID
    //    try
    //    {
    //        //RadNumericTextBox Percentage = new RadNumericTextBox();
    //        RadNumericTextBox Percentage = (RadNumericTextBox)sender;//percentage entered value
    //        GridItem row = Percentage.Parent.Parent as GridItem;
    //        //RadNumericTextBox payableamt = new RadNumericTextBox();
    //        //Label lbl_amt = new Label();
    //       // payableamt = (RadNumericTextBox)row.FindControl("rtxt_variableallowance");//amount which has entered while creating the employee itself
    //        Label lbl_amt = (Label)row.FindControl("lbl_Amt");
    //        //RadNumericTextBox amount = new RadNumericTextBox();
    //        RadNumericTextBox amount = (RadNumericTextBox)row.FindControl("rtxt_amount");
    //        amount.Value = Math.Round((Convert.ToDouble(lbl_amt.Text) * (Convert.ToDouble(Percentage.Value) / 100)));
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Payroll_frm_vpms_trans", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    #endregion
    #region Button Clicks

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int recordsinserted = 0;
            bool selected = false;
            CheckBox chkrow = new CheckBox();
            if (RG_Vpay.Items.Count > 0)
            {
                for (int gridrow = 0; gridrow < RG_Vpay.Items.Count; gridrow++)
                {
                    chkrow = (CheckBox)RG_Vpay.Items[gridrow].FindControl("chckbtn_Select");
                    if (chkrow.Checked)
                    {

                        Label empid = (Label)RG_Vpay.Items[gridrow].FindControl("lbl_emp_id");
                        RadNumericTextBox amount = (RadNumericTextBox)RG_Vpay.Items[gridrow].FindControl("rtxt_amount");
                        RadNumericTextBox Percentage = (RadNumericTextBox)RG_Vpay.Items[gridrow].FindControl("rtxt_percentage");
                        Label checkedperiod = (Label)RG_Vpay.Items[gridrow].FindControl("lbl_Periodid");
                        _obj_vamt.emp_id = Convert.ToInt32(empid.Text);
                        if (Percentage.Text != string.Empty)
                        {
                            selected = true;
                            if (!(amount.Text != string.Empty))
                            {
                                BLL.ShowMessage(this, "Enter Percentage For Each Employee And Click On Calculate");
                                return;
                            }
                            _obj_vamt.emp_va = Convert.ToDouble(amount.Text);
                            Label lbl_componentid = (Label)RG_Vpay.Items[gridrow].FindControl("lbl_Componentid");
                            _obj_vamt.component_id = Convert.ToInt32(lbl_componentid.Text);
                            _obj_vamt.percentage = Convert.ToDouble(Percentage.Text);
                            _obj_vamt.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_vamt.BUID = Convert.ToInt32(rcbBusinessUnit.SelectedValue);
                            _obj_vamt.financial_period = Convert.ToInt32(rcbFinancialPeriod.SelectedValue);
                            _obj_vamt.emp_period = Convert.ToInt32(rcbPeriodID.SelectedValue);
                            _obj_vamt.emp_checkedperiod = Convert.ToInt32(checkedperiod.Text);
                            _obj_vamt.EMP_STATUS = Convert.ToInt32(false);
                            _obj_vamt.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                            _obj_vamt.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                            if (!_obj_vamt.emp_isfinalised)
                                _obj_vamt.emp_isfinalised = false;
                            else
                                _obj_vamt.emp_isfinalised = true;
                            _obj_vamt.emp_status = false;
                            bool status = BLL.set_empvariablepay(_obj_vamt);
                            if (_obj_vamt.emp_isfinalised)
                            {
                                chkrow.Enabled = false;
                                chkrow.Checked = false;
                            }
                            //RG_Vpay.Items[gridrow].RemoveChildSelectedItems();
                            // RG_Vpay.Items[gridrow].Visible = false;
                            if (!status)
                            {
                                BLL.ShowMessage(this, "Error is Occured During The Process");
                            }
                            else
                            {
                                recordsinserted += 1;
                            }
                        }
                        else
                        {
                            BLL.ShowMessage(this, "Enter Percentage For The Employee In the Row :" + gridrow);
                            amount.Text = "";
                            return;
                        }
                    }
                }
                if (!selected)
                {
                    BLL.ShowMessage(this, "Select An Employee");
                }
                else
                {
                    if (_obj_vamt.emp_isfinalised)
                        BLL.ShowMessage(this, "Total Records Finalised Are:" + recordsinserted);
                    else
                        BLL.ShowMessage(this, "Total Records Saved Are:" + recordsinserted);
                }
            }
            else
            {
                BLL.ShowMessage(this, "No Employee Found");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_vpms_trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnFinalise_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_vamt.emp_isfinalised = false;
            btnSave_Click(null, null);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_vpms_trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            RG_Vpay.Visible = false;
            rcbBusinessUnit.ClearSelection();
            rcbFinancialPeriod.ClearSelection();
            rcbPeriodID.Items.Clear();
            rcbPeriodID.Items.Insert(0, new RadComboBoxItem("", ""));
            btnFinalise.Visible = false;
            btnSave.Visible = false;
            rcbBusinessUnit.Enabled = true;
            rcbFinancialPeriod.Enabled = true;
            btn_Calculate.Visible = false;
        }
        catch (Exception ex)
        {
            BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_vpms_trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Calculate_Click(object sender, EventArgs e)
    {
        try
        {
            // calculating amounts of each employee at a time
            bool Selected = false;
            if (rcbBusinessUnit.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Business Unit");
                return;

            }
            if (rcbFinancialPeriod.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Financial Period");
                return;
            }

            if (rcbPeriodID.SelectedIndex <= 0)
            {
                BLL.ShowMessage(this, "Please Select Period Id");
                return;
            }
            for (int rows = 0; rows < RG_Vpay.Items.Count; rows++)
            {
                GridItem row = RG_Vpay.Items[rows] as GridItem;
                CheckBox chkrow = (CheckBox)RG_Vpay.Items[rows].FindControl("chckbtn_Select");
                if (chkrow.Checked)
                {
                    Selected = true;
                    RadNumericTextBox Percentage = new RadNumericTextBox();
                    Percentage = row.FindControl("rtxt_percentage") as RadNumericTextBox;
                    Label lbl_amt = (Label)row.FindControl("lbl_Amt");
                    RadNumericTextBox amount = (RadNumericTextBox)row.FindControl("rtxt_amount");
                    if (Percentage.Text != string.Empty)
                    {
                        amount.Value = Math.Round((Convert.ToDouble(lbl_amt.Text) * (Convert.ToDouble(Percentage.Text) / 100)));
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Enter the Percentage at the row no:" + (rows + 1));
                        amount.Text = "";
                        return;
                    }
                }
            }
            if (!Selected)
                BLL.ShowMessage(this, "Select Atleaset One Employee To Calcualte Performance Bonus");
        }
        catch (Exception ex)
        {
            BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_vpms_trans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

}
