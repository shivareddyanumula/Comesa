using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;
using System.Collections;
using System.IO;
using System.Text;
public partial class Payroll_frm_PromotionHikes : System.Web.UI.Page
{
    protected SMHR_EMPLOYEE _obj_Smhr_Employee;
    protected SMHR_EMPPROMOTIONS _obj_Smhr_Promotions;
    protected SMHR_EMPPROMOTIONS _obj_Smhr_Promotions_2;
    protected SMHR_POSITIONS _obj_Smhr_Positions;
    protected SMHR_MASTERS _obj_Smhr_Masters;
    protected SMHR_SHIFTDEFINITION _obj_Smhr_Shift;
    protected SMHR_LEAVESTRUCT _obj_Smhr_Leavestruct;
    protected SMHR_SALARYSTRUCT _obj_Smhr_SalStruct;
    protected SMHR_LOGININFO _obj_SMHR_LoginInfo;
    protected SMHR_BUSINESSUNIT _obj_smhr_BusinessUnit;
    protected SMHR_EMP_PAYITEMS _obj_smhr_payitems;
    protected SMHR_EMPLOYEE _obj_smhr_employee;
    protected SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    protected SMHR_GLOBALCONFIG _obj_smhr_globalconfig;
    protected SMHR_PERIODDTL _obj_smhr_prd;
    static double minsal = 0.0;
    static double maxsal = 0.0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {


                ////To check whether the selected business unit is allowing manual employee code or not
                //SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
                //_obj_Smhr_BusinessUnit.OPERATION = operation.Get_BU;
                //_obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dt_bu = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
                //if (dt_bu.Rows.Count > 0)
                //{
                //    if (dt_bu.Rows[0]["ORGANISATION_EMPCODE_MANUAL"] != DBNull.Value)
                //    {
                //        if (Convert.ToString(dt_bu.Rows[0]["ORGANISATION_EMPCODE_MANUAL"]) == "True")
                //        {
                //            ViewState["EMPCODE_MANUAL"] = true;
                //            rtxt_empcode_Validate.Enabled = true;
                //        }
                //        else
                //        {
                //            ViewState["EMPCODE_MANUAL"] = false;
                //            rtxt_empcode_Validate.Enabled = false;
                //        }
                //    }
                //    else
                //    {
                //        ViewState["EMPCODE_MANUAL"] = false;
                //        rtxt_empcode_Validate.Enabled = false;
                //    }


                //}

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Salary Progressions");//PROMOTIONS & HIKES");
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
                    rg_Promotion.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Submit.Visible = false;

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
                LoadGrid();
                LoadPeriod();
                // BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdtp_DateofExecution, rdtp_RMEndDate, rdtp_DOJ, rdtp_DOC);31.5.2016
                BLL.ChangeDateFormat(Convert.ToString(Session["EMP_ID"]), rdtp_DateofExecution, rdtp_DOJ);
                //BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), rg_Promotion, "DATEOFJOIN", "DATEOFCONFIRMATION", "DATEOFPROMOTION");31.5.2016
                BLL.gridDateFormat(Convert.ToString(Session["EMP_ID"]), rg_Promotion, "DATEOFJOIN", "DATEOFPROMOTION");
                Page.Validate();

                rtxt_Basic.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrades()
    {
        try
        {
            rcmb_Grade.Items.Clear();

            SMHR_EMPLOYEEGRADE _obj_Emp_Grade = new SMHR_EMPLOYEEGRADE();

            _obj_Emp_Grade.OPERATION = operation.EmployeeGrade;
            _obj_Emp_Grade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dt = BLL.GetEmployeeGrade(_obj_Emp_Grade);

            if (dt.Rows.Count > 0)
            {
                rcmb_Grade.DataSource = dt;
                rcmb_Grade.DataTextField = "EMPLOYEEGRADE_CODE";
                rcmb_Grade.DataValueField = "EMPLOYEEGRADE_ID";
                rcmb_Grade.DataBind();
            }

            rcmb_Grade.Items.Insert(0, new RadComboBoxItem("Select"));
            rcmb_Slabs.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            SMHR_EMPPROMOTIONS _obj_Smhr_Promotions = new SMHR_EMPPROMOTIONS();
            _obj_Smhr_Promotions.OPERATION = operation.Select;
            _obj_Smhr_Promotions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Promotions.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable DT = BLL.get_EmpPromotions(_obj_Smhr_Promotions);
            rg_Promotion.DataSource = DT;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Desg_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            #region oldcode
            //if (rcmb_Desg.SelectedIndex > 0 && string.Compare(lbl_Desg_ID.Text, rcmb_Desg.SelectedValue, true) != 0)
            //{
            //    SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
            //    _obj_smhr_positions.POSITIONS_ID = Convert.ToInt32(rcmb_Desg.SelectedValue);
            //    _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    _obj_smhr_positions.OPERATION = operation.GETVACANCY;
            //    DataTable dtVacancy = BLL.get_Positions(_obj_smhr_positions);
            //    if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 0)
            //    {
            //        rcmb_Desg.SelectedIndex = -1;
            //        BLL.ShowMessage(this, "Establishment not done for this position");
            //        return;
            //    }
            //    //else if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 1)
            //    //{
            //    //    rcmb_Desg.SelectedIndex = -1;
            //    //    BLL.ShowMessage(this, "Establishment not finalised for this position");
            //    //}
            //    else if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 3)
            //    {
            //        rcmb_Desg.SelectedIndex = -1;
            //        BLL.ShowMessage(this, "There is no vacancy for this position");
            //        return;
            //    }


            //    //Load Scales
            //    rcmb_Grade.Items.Clear();
            //    rcmb_Grade.Text = string.Empty;

            //    rcmb_Slabs.Items.Clear();
            //    rcmb_Slabs.Text = string.Empty;
            //    // rtxt_GrossSalary.Text = string.Empty;
            //    rtxt_Basic.Text = string.Empty;

            //    SMHR_POSITIONS _obj_smhr_position = new SMHR_POSITIONS();
            //    _obj_smhr_position.OPERATION = operation.POSITIONSGRADE;
            //    _obj_smhr_position.POSITIONS_ID = Convert.ToInt32(rcmb_Desg.SelectedValue);
            //    _obj_smhr_position.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    DataTable dtPos = BLL.get_Positions(_obj_smhr_position);
            //    if (dtPos.Rows.Count > 0)
            //    {
            //        rcmb_Grade.DataSource = dtPos;
            //        rcmb_Grade.DataTextField = "CODERANK";
            //        rcmb_Grade.DataValueField = "EMPLOYEEGRADE_ID";
            //        rcmb_Grade.DataBind();
            //        rcmb_Grade.Enabled = false;
            //        //rcmb_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            //        rcmb_Slabs.DataValueField = "EMPLOYEEGRADE_SLAB_ID";    // "EMPLOYEEGRADE_SLAB_SRNO";
            //        rcmb_Slabs.DataTextField = "EMPLOYEEGRADE_SLAB_AMOUNT";
            //        rcmb_Slabs.DataSource = LoadSalarySlabs();
            //        rcmb_Slabs.DataBind();
            //        rcmb_Slabs.Items.Insert(0, new RadComboBoxItem { Text = "Select", Value = "0" });
            //    }
            //}
            //else
            //{
            //    //Load Scales
            //    rcmb_Grade.Items.Clear();
            //    rcmb_Grade.Text = string.Empty;

            //    rcmb_Slabs.Items.Clear();
            //    rcmb_Slabs.Text = string.Empty;
            //    // rtxt_GrossSalary.Text = string.Empty;
            //    rtxt_Basic.Text = string.Empty;
            //}

            #endregion

            if (rcmb_FinancialPeriod.SelectedValue == string.Empty || rcmb_FinancialPeriod.SelectedValue == null)
            {
                BLL.ShowMessage(this, "Please select Financial Period before choose Position");
                rcmb_Desg.SelectedIndex = 0;
                return;
            }
            if (rcmb_Desg.SelectedIndex > 0)
            {
                if (string.Compare(lbl_Desg_ID.Text, rcmb_Desg.SelectedValue, true) != 0)
                {
                    SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                    _obj_smhr_positions.POSITIONS_ID = Convert.ToInt32(rcmb_Desg.SelectedValue);
                    _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_positions.POSITIN_PERIOD_ID = Convert.ToInt32(rcmb_FinancialPeriod.SelectedValue);
                    _obj_smhr_positions.OPERATION = operation.GETVACANCY;
                    DataTable dtVacancy = BLL.get_Positions(_obj_smhr_positions);
                    if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 0)
                    {
                        rcmb_Desg.SelectedIndex = -1;
                        BLL.ShowMessage(this, "Establishment not done for this position");
                        return;
                    }
                    //else if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 1)
                    //{
                    //    rcmb_Desg.SelectedIndex = -1;
                    //    BLL.ShowMessage(this, "Establishment not finalised for this position");
                    //}
                    else if (Convert.ToInt32(dtVacancy.Rows[0][0]) == 3)
                    {
                        rcmb_Desg.SelectedIndex = -1;
                        BLL.ShowMessage(this, "There is no vacancy for this position");
                        return;
                    }
                }
                //Load Scales
                //rcmb_Grade.Items.Clear();
                //rcmb_Grade.Text = string.Empty;

                //rcmb_Slabs.Items.Clear();
                //rcmb_Slabs.Text = string.Empty;
                // rtxt_GrossSalary.Text = string.Empty;
                //rtxt_Basic.Text = string.Empty;

                /*SMHR_POSITIONS _obj_smhr_position = new SMHR_POSITIONS();
                _obj_smhr_position.OPERATION = operation.POSITIONSGRADE;
                _obj_smhr_position.POSITIONS_ID = Convert.ToInt32(rcmb_Desg.SelectedValue);
                _obj_smhr_position.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtPos = BLL.get_Positions(_obj_smhr_position);
                if (dtPos.Rows.Count > 0)
                {
                    rcmb_Grade.DataSource = dtPos;
                    rcmb_Grade.DataTextField = "CODERANK";
                    rcmb_Grade.DataValueField = "EMPLOYEEGRADE_ID";
                    rcmb_Grade.DataBind();
                    rcmb_Grade.Enabled = false;
                    //rcmb_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

                    rcmb_Slabs.DataValueField = "EMPLOYEEGRADE_SLAB_ID";    // "EMPLOYEEGRADE_SLAB_SRNO";
                    rcmb_Slabs.DataTextField = "EMPLOYEEGRADE_SLAB_AMOUNT";
                    rcmb_Slabs.DataSource = LoadSalarySlabs();
                    rcmb_Slabs.DataBind();
                    rcmb_Slabs.Items.Insert(0, new RadComboBoxItem { Text = "Select", Value = "0" });
                }*/

                //To check if Salary Progression is selected
                //31.5.2016
                /*if (rcmb_IncrementType.SelectedIndex > 0 && rcmb_IncrementType.SelectedItem.Text == "Appointment")
                {
                    //To check if previous designationID is same as current DesignationID
                    if (lbl_Desg_ID.Text != string.Empty)
                    {
                        if (lbl_Desg_ID.Text == rcmb_Desg.SelectedValue)
                        {
                            BLL.ShowMessage(this, "You cannot appoint employee to the same position");
                            rcmb_IncrementType.ClearSelection();
                        }
                    }
                }*/
            }
            else
            {
                //Load Scales
                //rcmb_Grade.Items.Clear();
                //rcmb_Grade.Text = string.Empty;

                //rcmb_Slabs.Items.Clear();
                //rcmb_Slabs.Text = string.Empty;
                // rtxt_GrossSalary.Text = string.Empty;
                //rtxt_Basic.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rdp_IncrementDate.MinDate = DateTime.Now;
            //LoadEmployee();
            LoadBusinessunit();
            //Disablefields(true);
            ClearControls();
            rcmb_Employee.Items.Clear();
            rcmb_Employee.Text = string.Empty;

            btn_Submit.Visible = true;
            //RM_PROMOTIONS.SelectedIndex = 1;
            RM_PROMOTIONS.SelectedIndex = 2;
            rtxt_Basic.Enabled = false;
            //rtxt_GrossSalary.Enabled = false;
            //LoadGrades();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadBusinessunit()
    {
        try
        {
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            if (Convert.ToString(Session["ORG_ID"]) != string.Empty)
            {
                _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
                rcmb_Businessunit.Items.Clear();
                DataTable dt_businessunit = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
                rcmb_Businessunit.DataSource = dt_businessunit;
                rcmb_Businessunit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_Businessunit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_Businessunit.DataBind();
                rcmb_Businessunit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                Response.Redirect("~/Login.aspx", false);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    protected void LoadDetails()
    {
        try
        {
            _obj_Smhr_Promotions = new SMHR_EMPPROMOTIONS();
            _obj_Smhr_Promotions.OPERATION = operation.Empty;
            _obj_Smhr_Promotions.EMPPRO_EMPID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
            _obj_Smhr_Promotions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_EmpPromotions(_obj_Smhr_Promotions);
            if (dt.Rows.Count != 0)
            {
                rdtp_DOJ.SelectedDate = Convert.ToDateTime(dt.Rows[0]["Date_Of_Join"]);
                /*if (dt.Rows[0]["DOC"] != System.DBNull.Value)31.5.2016
                {
                    rdtp_DOC.SelectedDate = Convert.ToDateTime(dt.Rows[0]["DOC"]);
                }
                else
                {
                    rdtp_DOC.SelectedDate = null;
                }*/
                if (dt.Rows[0]["EMP_EMPLOYEETYPE"] != System.DBNull.Value)
                {
                    lbl_emptype_from.Text = Convert.ToString(dt.Rows[0]["EMP_EMPLOYEETYPE"]);
                }
                else
                {
                    lbl_emptype_from.Text = null;
                }
                if (dt.Rows[0]["PERIOD_NAME"] != System.DBNull.Value)
                {
                    lblFinPeriodFrom.Text = Convert.ToString(dt.Rows[0]["PERIOD_NAME"]);
                }
                else
                {
                    lblFinPeriodFrom.Text = null;
                }
                //if (lbl_emptype_from.Text == "Permanent and Pensionable")
                //{
                //    rcmb_emptype.SelectedIndex = rcmb_emptype.FindItemIndexByText(Convert.ToString(dt.Rows[0]["EMP_EMPLOYEETYPE"]));
                //    rcmb_emptype.Enabled = false;
                //    rtxt_empcode.Text = Convert.ToString(dt.Rows[0]["EMP_EMPCODE"]);
                //    rtxt_empcode.Enabled = false;
                //}
                //else
                //{
                //    rcmb_emptype.SelectedIndex = 0;
                //    rcmb_emptype.Enabled = true;
                //    rtxt_empcode.Text = string.Empty;
                //    if (Convert.ToBoolean(ViewState["EMPCODE_MANUAL"]) == true)
                //    {
                //        rtxt_empcode.Enabled = true;
                //    }
                //    else
                //    {
                //        rtxt_empcode.Enabled = false;
                //    }
                //}
                //if (dt.Rows[0]["EMP_EMPCODE"] != System.DBNull.Value)
                //{
                //    lbl_empcode_from.Text = Convert.ToString(dt.Rows[0]["EMP_EMPCODE"]);
                //}
                //else
                //{
                //    lbl_empcode_from.Text = string.Empty;
                //}
                lblJobFrom.Text = Convert.ToString(dt.Rows[0]["JOBS_CODE"]);
                lblJobID.Text = Convert.ToString(dt.Rows[0]["JOBS_ID"]);
                rcmb_Job.SelectedIndex = 0;

                lbl_Desg_from.Text = Convert.ToString(dt.Rows[0]["Designation"]);
                lbl_Desg_ID.Text = Convert.ToString(dt.Rows[0]["Desg_ID"]);
                //rcmb_Desg.SelectedIndex = rcmb_Desg.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["Desg_ID"]));

                rcmb_Desg.SelectedIndex = 0;
                if (dt.Rows[0]["Grade"] != System.DBNull.Value)
                {
                    lbl_Grade_from.Text = Convert.ToString(dt.Rows[0]["Grade"]);
                }
                else
                {
                    lbl_Grade_from.Text = null;
                }

                lbl_Grade_ID.Text = Convert.ToString(dt.Rows[0]["Grade_ID"]);
                //rcmb_Grade.SelectedIndex = rcmb_Grade.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["Grade_ID"]));

                rcmb_Grade.SelectedIndex = 0;
                //lbl_GrossSalary_from.Text = Convert.ToString(dt.Rows[0]["Gross_Salary"]);
                rcmb_Slabs.SelectedIndex = 0;
                //lbl_Scale_From.Text = Convert.ToString(dt.Rows[0]["EMPLOYEEGRADE_SLAB_AMOUNT"]);
                Double x;
                x = Convert.ToDouble(dt.Rows[0]["EMPLOYEEGRADE_SLAB_AMOUNT"]);
                lbl_Scale_From.Text = x.ToString("0.00");
                lbl_Slab_ID.Text = Convert.ToString(dt.Rows[0]["EMP_SLAB_ID"]);


                //rtxt_GrossSalary.Text = Convert.ToString(dt.Rows[0]["Gross_Salary"]);
                lbl_LeaveStruct_from.Text = Convert.ToString(dt.Rows[0]["Leave_Structure"]);
                lbl_LS_ID.Text = Convert.ToString(dt.Rows[0]["LS_ID"]);
                //rcmb_LeaveStruct.SelectedIndex = rcmb_LeaveStruct.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["LS_ID"]));

                rcmb_LeaveStruct.SelectedIndex = 0;
                lbl_SalStruct_from.Text = Convert.ToString(dt.Rows[0]["Salary_Structure"]);
                lbl_SS_ID.Text = Convert.ToString(dt.Rows[0]["SS_ID"]);
                //rcmb_SalStruct.SelectedIndex = rcmb_SalStruct.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SS_ID"]));
                rcmb_SalStruct.SelectedIndex = 0;

                lbl_Shifts_from.Text = Convert.ToString(dt.Rows[0]["Shift"]);
                lbl_Shift_ID.Text = Convert.ToString(dt.Rows[0]["SHIFT_ID"]);
                //rcmb_Shift.SelectedIndex = rcmb_Shift.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SHIFT_ID"]));
                rcmb_Shift.SelectedIndex = 0;
                lbl_Basic_from.Text = Convert.ToString(dt.Rows[0]["Basic"]);
                //rtxt_Basic.Text = Convert.ToString(dt.Rows[0]["Basic"]);                                                                           

                //_obj_Smhr_Promotions.OPERATION = operation.Empty;
                //DataTable dt1 = BLL.get_ReportingEmployee(_obj_Smhr_Promotions);
                //if (dt1.Rows.Count != 0)
                //{
                lbl_ReportingEmployee_from.Text = Convert.ToString(dt.Rows[0]["REPEMP_NAME"]);
                //lbl_PR.Text = Convert.ToString(dt.Rows[0]["REMP_ID"]);
                //rcmb_RepEmployee.SelectedIndex = rcmb_RepEmployee.FindItemIndexByValue(Convert.ToString(dt1.Rows[0]["REMP_ID"]));

                rcmb_RepEmployee.SelectedIndex = 0;
                //}
                rdtp_DateofExecution.SelectedDate = DateTime.Now;

                //31.5.2016 divya
                /*if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["EMP_INCRMENTMONTH"])))
                {
                    rcmb_IncrementMonth.SelectedIndex = rcmb_IncrementMonth.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMP_INCRMENTMONTH"]));
                }
                else
                {
                    rcmb_IncrementMonth.ClearSelection();
                }*/

                //31.5.2016
                /*if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["EMPPRO_INCREMENTTYPE_ID"])))
                {
                    rcmb_IncrementTypeFrom.SelectedIndex = rcmb_IncrementTypeFrom.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMPPRO_INCREMENTTYPE_ID"]));
                }
                else
                {
                    rcmb_IncrementTypeFrom.ClearSelection();
                }*/
                //31.5.2016
                /*if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["INCR_MONTH"])))
                {
                    lbl_IncrementMonthFrom.Text = Convert.ToString(dt.Rows[0]["INCR_MONTH"]);
                }
                else
                {
                    lbl_IncrementMonthFrom.Text = string.Empty;
                }*/
                if (dt.Rows[0]["EMP_CONTRACT_STARTDATE"] != null)
                {
                    rdp_ContractStart.SelectedDate= Convert.ToDateTime(dt.Rows[0]["EMP_CONTRACT_STARTDATE"]);
                }
                else
                    rdp_ContractStart.SelectedDate = null;
                if (dt.Rows[0]["EMP_CONTRACT_ENDDATE"] != null)
                {                    
                    rdp_ContractEnd.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EMP_CONTRACT_ENDDATE"]);
                }
                else
                    rdp_ContractEnd.SelectedDate = null;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadEmployee()
    {
        try
        {
            //Load Employee
            //_obj_Smhr_Promotions = new SMHR_EMPPROMOTIONS();
            //_obj_Smhr_Promotions.OPERATION = operation.Select;
            //_obj_Smhr_Promotions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //rcmb_Employee.Items.Clear();

            //rcmb_Employee.DataSource = BLL.get_ReportingEmployee(_obj_Smhr_Promotions);
            //rcmb_Employee.DataTextField = "EMPNAME";
            //rcmb_Employee.DataValueField = "EMP_ID";
            //rcmb_Employee.DataBind();
            //rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            rcmb_Employee.Items.Clear();
            _obj_smhr_payitems = new SMHR_EMP_PAYITEMS();
            //_obj_smhr_payitems.OPERATION = operation.Empty;
            _obj_smhr_payitems.OPERATION = operation.Empty_PH;
            _obj_smhr_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_Businessunit.SelectedItem.Value);
            _obj_smhr_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT_Details = BLL.get_EmpDetails(_obj_smhr_payitems);//NOT NEEDED AS WE ARE LOADING RELAVENT TO ORG.
            if (DT_Details.Rows.Count != 0)
            {
                rcmb_Employee.DataSource = DT_Details;
                rcmb_Employee.DataTextField = "EMPNAME";
                rcmb_Employee.DataValueField = "EMP_ID";
                rcmb_Employee.DataBind();
                rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadDropdowns()
    {
        try
        {
            //Load Designation
            //_obj_Smhr_Positions = new SMHR_POSITIONS();
            //_obj_Smhr_Positions.OPERATION = operation.Select;
            //_obj_Smhr_Positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dtPos = BLL.get_Positions(_obj_Smhr_Positions);
            //rcmb_Desg.DataSource = dtPos;
            //rcmb_Desg.DataTextField = "POSITIONS_CODE";
            //rcmb_Desg.DataValueField = "POSITIONS_ID";
            //rcmb_Desg.DataBind();
            //rcmb_Desg.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            if (rcmb_Businessunit.SelectedIndex > 0)
            {
                //To populate jobs
                rcmb_Job.Items.Clear();
                SMHR_JOBS _obj_Jobs = new SMHR_JOBS();
                _obj_Jobs.OPERATION = operation.Get;
                _obj_Jobs.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                _obj_Jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT = BLL.get_Jobs(_obj_Jobs);
                rcmb_Job.DataSource = DT;
                rcmb_Job.DataTextField = "JOBS_CODE";
                rcmb_Job.DataValueField = "JOBS_ID";
                rcmb_Job.DataBind();
                rcmb_Job.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

                rcmb_Desg.Items.Clear();
                rcmb_Desg.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

                //// added by joseph on 2009-11-21
                //rcmb_Desg.Items.Clear();
                //_obj_Smhr_Positions = new SMHR_POSITIONS();
                //_obj_Smhr_Positions.OPERATION = operation.Select;
                //_obj_Smhr_Positions.JOBLOC_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                //_obj_Smhr_Positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dtPos = BLL.get_BUPositions(_obj_Smhr_Positions);
                //rcmb_Desg.DataSource = dtPos;
                //rcmb_Desg.DataTextField = "POSITIONS_CODE";
                //rcmb_Desg.DataValueField = "POSITIONS_ID";
                //rcmb_Desg.DataBind();
                //rcmb_Desg.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //To clear scale and slabs
                //rcmb_Grade.Text = string.Empty;
                //rcmb_Slabs.Text = string.Empty;
                //rcmb_Slabs.Items.Clear();
            }
            else
            {
                rcmb_Job.Items.Clear();
                rcmb_Job.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                rcmb_Desg.Items.Clear();
                rcmb_Desg.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                //rcmb_Grade.Items.Clear();
            }

            //Load Grade
            /*if (rcmb_Desg.SelectedValue != string.Empty)
            {
                rcmb_Grade.Items.Clear();
                SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                _obj_smhr_positions.OPERATION = operation.POSITIONSGRADE;
                _obj_smhr_positions.POSITIONS_ID = Convert.ToInt32(rcmb_Desg.SelectedValue);
                _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtPos = BLL.get_Positions(_obj_smhr_positions);
                rcmb_Grade.DataSource = dtPos;
                rcmb_Grade.DataTextField = "EMPLOYEEGRADE_ID";
                rcmb_Grade.DataValueField = "CODERANK";
                rcmb_Grade.DataBind();
                //ddl_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }*/
            //_obj_Smhr_Masters = new SMHR_MASTERS();
            //_obj_Smhr_Masters.MASTER_TYPE = "GRADE";
            //_obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //rcmb_Grade.Items.Clear();
            //rcmb_Grade.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
            //rcmb_Grade.DataTextField = "HR_MASTER_CODE";
            //rcmb_Grade.DataValueField = "HR_MASTER_ID";
            //rcmb_Grade.DataBind();
            //rcmb_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            //Load Leave Structure
            _obj_Smhr_Leavestruct = new SMHR_LEAVESTRUCT();
            _obj_Smhr_Leavestruct.OPERATION = operation.Select;
            _obj_Smhr_Leavestruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_LeaveStruct.Items.Clear();
            rcmb_LeaveStruct.DataSource = BLL.get_LeaveStructHeaderDetails(_obj_Smhr_Leavestruct);
            rcmb_LeaveStruct.DataTextField = "LEAVESTRUCT_CODE";
            rcmb_LeaveStruct.DataValueField = "LEAVESTRUCT_ID";
            rcmb_LeaveStruct.DataBind();
            rcmb_LeaveStruct.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));


            //Load Salary Structure
            _obj_Smhr_SalStruct = new SMHR_SALARYSTRUCT();
            _obj_Smhr_SalStruct.OPERATION = operation.Select;

            _obj_Smhr_SalStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_SalStruct.Items.Clear();
            rcmb_SalStruct.DataSource = BLL.get_SalaryHeaderDetails(_obj_Smhr_SalStruct);
            rcmb_SalStruct.DataTextField = "SALARYSTRUCT_CODE";
            rcmb_SalStruct.DataValueField = "SALARYSTRUCT_ID";
            rcmb_SalStruct.DataBind();
            rcmb_SalStruct.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            //Load Reporting Employee
            _obj_Smhr_Promotions = new SMHR_EMPPROMOTIONS();
            _obj_Smhr_Promotions.OPERATION = operation.Select;
            _obj_Smhr_Promotions.EMPPRO_EMPID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
            _obj_Smhr_Promotions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_RepEmployee.Items.Clear();
            rcmb_RepEmployee.DataSource = BLL.get_EmpPromotions(_obj_Smhr_Promotions);
            rcmb_RepEmployee.DataTextField = "EMPNAME";
            rcmb_RepEmployee.DataValueField = "EMP_ID";
            rcmb_RepEmployee.DataBind();
            rcmb_RepEmployee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));


            //Load Shift
            _obj_Smhr_Shift = new SMHR_SHIFTDEFINITION();
            _obj_Smhr_Shift.OPERATION = operation.Select;
            _obj_Smhr_Shift.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_Shift.Items.Clear();
            rcmb_Shift.DataSource = BLL.get_ShiftDefinition(_obj_Smhr_Shift);
            rcmb_Shift.DataTextField = "SHIFT_CODE";
            rcmb_Shift.DataValueField = "SHIFT_ID";
            rcmb_Shift.DataBind();
            rcmb_Shift.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            //Load Increment Month
            //31.5.2016
            /*SMHR_EMPLOYEE objEmployee = new SMHR_EMPLOYEE();
            objEmployee.OPERATION = operation.Select_New;
            rcmb_IncrementMonth.Items.Clear();
            rcmb_IncrementMonth.DataSource = BLL.get_IncrementMonth(objEmployee);
            rcmb_IncrementMonth.DataTextField = "INCR_MONTH";
            rcmb_IncrementMonth.DataValueField = "INCR_ID";
            rcmb_IncrementMonth.DataBind();
            rcmb_IncrementMonth.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));*/

            //Load Increment Type
            //SMHR_EMPLOYEE objEmployee = new SMHR_EMPLOYEE();
            //31.5.2016
            /*objEmployee.OPERATION = operation.Get;
            objEmployee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_IncrementType = BLL.get_IncrementMonth(objEmployee);
            rcmb_IncrementTypeFrom.DataSource = dt_IncrementType;
            rcmb_IncrementTypeFrom.DataValueField = "HR_MASTER_ID";
            rcmb_IncrementTypeFrom.DataTextField = "HR_MASTER_DESC";
            rcmb_IncrementTypeFrom.DataBind();
            rcmb_IncrementTypeFrom.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));*?
            //31.5.2016
            /*if (rcmb_IncrementType.Enabled)
            {
                dt_IncrementType.DefaultView.RowFilter = " HR_MASTER_DESC  in ('Promotion', 'Revision','Appointment')";
                dt_IncrementType = dt_IncrementType.DefaultView.ToTable();
                rcmb_IncrementType.DataSource = dt_IncrementType;
                rcmb_IncrementType.DataValueField = "HR_MASTER_ID";
                rcmb_IncrementType.DataTextField = "HR_MASTER_DESC";
                rcmb_IncrementType.DataBind();
                rcmb_IncrementType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                //dt_IncrementType.DefaultView.RowFilter = " HR_MASTER_DESC  in ('Promotion', 'Revision')";
                //dt_IncrementType = dt_IncrementType.DefaultView.ToTable();
                rcmb_IncrementType.DataSource = dt_IncrementType;
                rcmb_IncrementType.DataValueField = "HR_MASTER_ID";
                rcmb_IncrementType.DataTextField = "HR_MASTER_DESC";
                rcmb_IncrementType.DataBind();
                rcmb_IncrementType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }*/


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Employee_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //_obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            //_obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            //DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            ClearControls();
            RM_PROMOTIONS.SelectedIndex = 1;
            if (rcmb_Employee.SelectedIndex > 0)
            {
                LoadPeriod();
                LoadDropdowns();
                LoadDetails();
                //rtxt_GrossSalary.Text = string.Empty;
                rtxt_Basic.Text = string.Empty;
                //rdtp_RMEndDate.SelectedDate = null;  31.5.2016
                if (rdtp_DOJ.SelectedDate != null)
                    rtxt_lS.Text = UnitOfMeasure.ConvertToDuration(DateTime.Now.Subtract(Convert.ToDateTime(rdtp_DOJ.SelectedDate)).Days);
                //rdtp_DateofExecution.MinDate = DateTime.Now;
                //rdtp_DateofExecution.MinDate = Convert.ToDateTime("01/01/2011");
                SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                _obj_smhr_logininfo.OPERATION = operation.Select3;
                _obj_smhr_logininfo.LOGIN_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_emp = BLL.get_LoginInfo(_obj_smhr_logininfo);
                if (dt_emp.Rows.Count > 0)
                {
                    rdtp_DateofExecution.MinDate = Convert.ToDateTime(dt_emp.Rows[0]["EMP_DOJ"]);
                }
            }
            else
            {
                rcmb_Employee.SelectedIndex = -1;
                rdtp_DOJ.SelectedDate = null;
                rcmb_FinancialPeriod.SelectedIndex = -1;
                lblFinPeriodFrom.Text = string.Empty;
                //rdtp_DOC.SelectedDate = null;31.5.2016
                lbl_Basic_from.Text = string.Empty;
                lbl_Desg_from.Text = string.Empty;
                lbl_Grade_from.Text = string.Empty;
                //lbl_GrossSalary_from.Text = string.Empty;
                lbl_LeaveStruct_from.Text = string.Empty;
                lbl_Shifts_from.Text = string.Empty;
                lbl_ReportingEmployee_from.Text = string.Empty;
                //lbl_empcode_from.Text = string.Empty;
                lbl_emptype_from.Text = string.Empty;
                rcmb_emptype.SelectedIndex = 0;
                rcmb_FinancialPeriod.SelectedIndex = 0;
                //rcmb_Perioddtls.SelectedIndex = 0;
                //rtxt_empcode.Text = string.Empty;
                rcmb_Desg.SelectedIndex = -1;
                rcmb_Employee.SelectedIndex = -1;
                rcmb_Grade.SelectedIndex = -1;
                rcmb_GSCurrency.SelectedIndex = -1;
                rcmb_LeaveStruct.SelectedIndex = -1;
                rcmb_RepEmployee.SelectedIndex = -1;
                rcmb_SalStruct.SelectedIndex = -1;
                // rdtp_RMEndDate.SelectedDate = null;  31.5.2016
                rcmb_Shift.SelectedIndex = -1;
                //rtxt_GrossSalary.Text = string.Empty;
                rtxt_Basic.Text = string.Empty;
                rtxt_lS.Text = string.Empty;
                rdtp_DateofExecution.SelectedDate = null;
                rdp_IncrementDate.SelectedDate = null;
                rdp_ContractStart.SelectedDate = null;
                rdp_ContractEnd.SelectedDate = null;
                lbl_SalStruct_from.Text = string.Empty;
                Disablefields(true);
                //RM_PROMOTIONS.SelectedIndex = 0;
                //rcmb_Employee.Items.Clear();
                rcmb_Desg.Items.Clear();
                rcmb_Grade.Items.Clear();
                rcmb_GSCurrency.Items.Clear();
                rcmb_LeaveStruct.Items.Clear();
                rcmb_RepEmployee.Items.Clear();
                rcmb_SalStruct.Items.Clear();
                rcmb_Shift.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    public class UnitOfMeasure
    {

        public UnitOfMeasure(string name, int value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; set; }
        public int Value { get; set; }
        public static UnitOfMeasure[] All = new UnitOfMeasure[]
        {
            new UnitOfMeasure("Year", 365),
            new UnitOfMeasure("Month", 30),
            new UnitOfMeasure("Week", 7),
            new UnitOfMeasure("Day", 1)
        };
        public static string ConvertToDuration(int days)
        {
            List<string> results = new List<string>();
            for (int i = 0; i < All.Length; i++)
            {
                int count = days / All[i].Value;
                if (count >= 1)
                {
                    results.Add((count + " " + All[i].Name) + (count == 1 ? string.Empty : "s"));
                    days -= count * All[i].Value;
                }
            }

            return string.Join(", ", results.ToArray());

        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            bool submit = true;
            string errormsg = null;
            if ((rcmb_Job.SelectedIndex <= 0))
            {
                errormsg += @"\nPlease select Promoted Job ";
                submit = false;
            }
            if ((rcmb_Desg.SelectedIndex <= 0))
            {
                errormsg += @"\nPlease select Promoted Position ";
                submit = false;
            }
            if (rcmb_LeaveStruct.SelectedIndex <= 0)
            {
                errormsg += @"\nPlease select Promoted LeaveStructure";
                submit = false;
            }
            //if (rcmb_RepEmployee.SelectedIndex <= 0)
            //{
            //    errormsg += @"\nSelect Reporting Employee ";
            //    submit = false;
            //}
            if (rcmb_Shift.SelectedIndex <= 0)
            {
                errormsg += @"\nPlease select Promoted Shift  ";
                submit = false;
            }
            if (rdtp_DateofExecution.SelectedDate == null)
            {
                errormsg += @"\nPlease select Execution Date  ";
                submit = false;
            }
            //if (rdtp_RMEndDate.SelectedDate == null)
            //{
            //    errormsg += @"\nSelect End Date , ";
            //    submit = false;
            //}
            if ((rcmb_SalStruct.SelectedIndex <= 0))
            {
                errormsg += @"\nPlease select Promoted SalaryStructure  ";
                submit = false;
            }
            if ((rcmb_FinancialPeriod.SelectedIndex <= 0))
            {
                errormsg += @"\nPlease select Financial Period";
                submit = false;
            }
            //if (rtxt_GrossSalary.Text == "")
            //{
            //    errormsg += @"\nEnter Gross Salary  ";
            //    submit = false;
            //}
            ////if (rtxt_empcode.Text == "")
            ////{
            ////    errormsg += @"\nEnter Employee Code  ";
            ////    submit = false;
            ////}
            if (rcmb_emptype.SelectedIndex <= 0)
            {
                errormsg += @"\nPlease select Employee Type  ";
                submit = false;
            }
            //if ( rcmb_Grade.SelectedItem.Text = string.Empty)
            //{
            //    errormsg += @"\nSelect Scale";
            //    submit = false;
            //}
            if (rcmb_Slabs.SelectedIndex <= 0)
            {
                errormsg += @"\nPlease select Slabs";
                submit = false;
            }

            if (rdp_ContractStart.SelectedDate != null || rdp_ContractEnd.SelectedDate != null)
            {
                if (rdp_ContractStart.SelectedDate != null && rdp_ContractEnd.SelectedDate == null)
                {
                    BLL.ShowMessage(this, "Contract end date is mandatory..!");
                    rdp_ContractEnd.Focus();
                    return;
                }
                if (rdp_ContractStart.SelectedDate == null && rdp_ContractEnd.SelectedDate != null)
                {
                    BLL.ShowMessage(this, "Contract start date is mandatory..!");
                    rdp_ContractStart.Focus();
                    return;
                }
            }
            if (rdtp_DateofExecution.SelectedDate != null && rcmb_Grade.SelectedValue != string.Empty)
            {
                _obj_Smhr_Promotions = new SMHR_EMPPROMOTIONS();
                _obj_Smhr_Promotions_2 = new SMHR_EMPPROMOTIONS();
                _obj_Smhr_Promotions.OPERATION = operation.CHECKSLABPERIODS;
                _obj_Smhr_Promotions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Promotions.EMPPRO_GRADE = Convert.ToInt32(rcmb_Grade.SelectedValue);
                _obj_Smhr_Promotions.VALIDATEPERIOD = Convert.ToDateTime(rdtp_DateofExecution.SelectedDate);

                bool status = BLL.set_EmpPromotion(_obj_Smhr_Promotions, _obj_Smhr_Promotions_2);
                if (status == false)
                {
                    BLL.ShowMessage(this, "Slabs Not Finalized For Selected Grade");
                    rdtp_DateofExecution.SelectedDate = null;
                    return;
                }
            }
            if (submit)
            {

                _obj_Smhr_Promotions = new SMHR_EMPPROMOTIONS();
                _obj_Smhr_Promotions_2 = new SMHR_EMPPROMOTIONS();
                _obj_Smhr_Promotions.EMPPRO_EMPID = Convert.ToInt32(rcmb_Employee.SelectedValue.ToString());
                // Added by Joseph
                if (rdtp_DateofExecution.SelectedDate != null)
                {
                    _obj_Smhr_Employee = new SMHR_EMPLOYEE();
                    _obj_Smhr_Employee.OPERATION = operation.Select;
                    _obj_Smhr_Employee.EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue.ToString());
                    _obj_Smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_DOJ = BLL.get_Employee(_obj_Smhr_Employee);
                    DateTime Emp_DOJ = Convert.ToDateTime(dt_DOJ.Rows[0]["EMP_DOJ"]);
                    if (Convert.ToDateTime(Emp_DOJ.ToShortDateString()) >= Convert.ToDateTime(Convert.ToDateTime(rdtp_DateofExecution.SelectedDate).ToShortDateString()))
                    {
                        rdtp_DateofExecution.SelectedDate = null;
                        BLL.ShowMessage(this, "Execution Date shoud be greater than the Joining Date of the Employee");
                        return;
                    }
                }
                //if (lbl_emptype_from.Text == "Contract" || lbl_emptype_from.Text == "Consultant")
                //{
                ////if (lbl_emptype_from.Text != Convert.ToString(rcmb_emptype.SelectedItem.Text))
                ////{
                ////    if (Convert.ToBoolean(ViewState["EMPCODE_MANUAL"]) == true)
                ////    {
                ////        _obj_Smhr_Promotions_2.EMPPRO_EMPCODEN = Convert.ToString(lbl_empcode_from.Text);
                ////        _obj_smhr_employee = new SMHR_EMPLOYEE();
                ////        _obj_smhr_employee.OPERATION = operation.Get;
                ////        _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                ////        _obj_smhr_employee.EMP_EMPCODE = Convert.ToString(rtxt_empcode.Text.Replace("'", "''")); ;
                ////        if (Convert.ToString(BLL.get_empcode(_obj_smhr_employee).Rows[0]["Count"]) != "0")
                ////        {
                ////            BLL.ShowMessage(this, "Employee Code Already Exists");
                ////            rtxt_empcode.Text = string.Empty;
                ////            rtxt_empcode.Focus();
                ////            return;
                ////        }
                ////    }
                ////    else
                ////    {
                ////        getEmpCode();
                ////        _obj_Smhr_Promotions_2.EMPPRO_EMPCODEN = Convert.ToString(lbl_Code.Text);
                ////    }
                ////}
                ////else
                ////{
                ////    _obj_Smhr_Promotions_2.EMPPRO_EMPCODEN = Convert.ToString(lbl_empcode_from.Text);
                ////}
                //////}
                //////else
                //////{
                //////    _obj_Smhr_Promotions_2.EMPPRO_EMPCODEN = Convert.ToString(lbl_empcode_from.Text);
                //////}
                ////_obj_Smhr_Promotions.EMPPRO_EMPCODE = Convert.ToString(lbl_empcode_from.Text);
                //Completed
                _obj_Smhr_Promotions.EMPPRO_DATEOFPROMOTION = rdtp_DateofExecution.SelectedDate;
                //_obj_Smhr_Promotions.EMPPRO_DESIGNATION_ID = Convert.ToInt32(rcmb_Desg.SelectedValue.ToString());
                _obj_Smhr_Promotions.EMPPRO_DESIGNATION_ID = Convert.ToInt32(lbl_Desg_ID.Text);
                // _obj_Smhr_Promotions.EMPPRO_GRADE = Convert.ToInt32(rcmb_Grade.SelectedValue.ToString());
                _obj_Smhr_Promotions.EMPPRO_LEAVESTRUCT_ID = Convert.ToInt32(lbl_LS_ID.Text);
                _obj_Smhr_Promotions.EMPPRO_SALALRYSTRUCT_ID = Convert.ToInt32(lbl_SS_ID.Text);
                _obj_Smhr_Promotions.EMPPRO_EMPLOYEETYPE = Convert.ToString(lbl_emptype_from.Text);

                //to insert increment date  1.6.2016
                if (rdp_IncrementDate.SelectedDate != null)
                {
                    _obj_Smhr_Promotions.EMPPRO_INCRMENTDATE = rdp_IncrementDate.SelectedDate;
                }
                else
                    _obj_Smhr_Promotions.EMPPRO_INCRMENTDATE = null;
                if (rdp_ContractStart.SelectedDate != null)
                {
                    _obj_Smhr_Promotions.EMPPRO_CONTRACT_STARTDATE = rdp_ContractStart.SelectedDate;
                }
                else
                    _obj_Smhr_Promotions.EMPPRO_CONTRACT_STARTDATE = null;
                if (rdp_ContractEnd.SelectedDate != null)
                {
                    _obj_Smhr_Promotions.EMPPRO_CONTRACT_ENDDATE = rdp_ContractEnd.SelectedDate;
                }
                else
                    _obj_Smhr_Promotions.EMPPRO_CONTRACT_ENDDATE = null;


                if (rcmb_FinancialPeriod.SelectedIndex > 0)
                {
                    _obj_Smhr_Promotions.EMPPRO_PERIOD = Convert.ToInt32(rcmb_FinancialPeriod.SelectedValue);
                }
                else
                    _obj_Smhr_Promotions.EMPPRO_PERIOD = 0;
                /* if (rcmb_Perioddtls.SelectedIndex > 0)
                 {
                     _obj_Smhr_Promotions.EMPPRO_PERIODDETAILS = Convert.ToInt32(rcmb_Perioddtls.SelectedValue);
                 }*/
                if (!string.IsNullOrEmpty(lbl_Grade_ID.Text))
                {
                    _obj_Smhr_Promotions.EMPPRO_GRADE = Convert.ToInt32(lbl_Grade_ID.Text);
                }
                else
                    _obj_Smhr_Promotions.EMPPRO_GRADE = 0;

                if (!string.IsNullOrEmpty(lbl_Slab_ID.Text))
                {
                    _obj_Smhr_Promotions.EMP_SLAB_ID = Convert.ToInt32(lbl_Slab_ID.Text);
                }
                else
                    _obj_Smhr_Promotions.EMP_SLAB_ID = 0;
                //_obj_Smhr_Promotions.EMPPRO_REPORTINGEMPLOYEE = Convert.ToInt32(lbl_ReportingEmployee_from.Text);
                _obj_Smhr_Promotions_2.EMPPRO_REPORTINGEMPLOYEE = Convert.ToInt32(rcmb_RepEmployee.SelectedValue.ToString());
                /*if (rdtp_RMEndDate.SelectedDate == null)   31.5.2016
                {
                    _obj_Smhr_Promotions.EMPPRO_REPORTINGEMPLOYEE_ENDDATE = null;
                }
                else
                    _obj_Smhr_Promotions.EMPPRO_REPORTINGEMPLOYEE_ENDDATE = Convert.ToDateTime(rdtp_RMEndDate.SelectedDate);*/

                //TO GET REPORTING EMPLOYEE BUSINESSUNIT
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.Select;
                _obj_smhr_employee.EMP_ID = Convert.ToInt32(rcmb_RepEmployee.SelectedValue.ToString());
                //dt_Details = new DataTable();
                _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);
                if (dt_Details.Rows.Count > 0)
                {
                    _obj_Smhr_Promotions_2.BUID = Convert.ToInt32(dt_Details.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                }

                _obj_Smhr_Promotions.EMMPRO_SHIFT_ID = Convert.ToInt32(lbl_Shift_ID.Text);
                //_obj_Smhr_Promotions.EMPPRO_GROSSSAL = Convert.ToDouble(lbl_GrossSalary_from.Text);
                if (lbl_Scale_From.Text != string.Empty)
                    _obj_Smhr_Promotions.EMPPRO_GROSSSAL = Convert.ToDouble(lbl_Scale_From.Text);      //gross
                if (lbl_Basic_from.Text != string.Empty)
                    _obj_Smhr_Promotions.EMPPRO_BASIC = Math.Round(Convert.ToDouble(lbl_Basic_from.Text), 2);
                // _obj_Smhr_Promotions_2.EMPPRO_EMPID = Convert.ToInt32(rcmb_Employee.SelectedValue.ToString());
                _obj_Smhr_Promotions_2.EMPPRO_DATEOFPROMOTION = rdtp_DateofExecution.SelectedDate;
                if (rcmb_Desg.SelectedIndex == 0)
                {
                    _obj_Smhr_Promotions_2.EMPPRO_DESIGNATION_ID = Convert.ToInt32(lbl_Desg_ID.Text);
                }
                else
                {
                    _obj_Smhr_Promotions_2.EMPPRO_DESIGNATION_ID = Convert.ToInt32(rcmb_Desg.SelectedValue.ToString());
                }

                if (rcmb_Desg.SelectedIndex == 0)
                {
                    _obj_Smhr_Promotions_2.EMPPRO_GRADE = Convert.ToInt32(lbl_Grade_ID.Text);
                }
                else
                {
                    _obj_Smhr_Promotions_2.EMPPRO_GRADE = Convert.ToInt32(rcmb_Grade.SelectedValue.ToString());
                }
                if (rcmb_Slabs.SelectedIndex == 0)
                {
                    _obj_Smhr_Promotions_2.EMP_SLAB_ID = Convert.ToInt32(lbl_Slab_ID.Text);
                }
                else
                {
                    _obj_Smhr_Promotions_2.EMP_SLAB_ID = Convert.ToInt32(rcmb_Slabs.SelectedValue.ToString());
                }
                if (rcmb_LeaveStruct.SelectedIndex == 0)
                {
                    _obj_Smhr_Promotions_2.EMPPRO_LEAVESTRUCT_ID = Convert.ToInt32(lbl_LS_ID.Text);
                }
                else
                {
                    _obj_Smhr_Promotions_2.EMPPRO_LEAVESTRUCT_ID = Convert.ToInt32(rcmb_LeaveStruct.SelectedValue.ToString());
                }
                if (rcmb_SalStruct.SelectedIndex == 0)
                {
                    _obj_Smhr_Promotions_2.EMPPRO_SALALRYSTRUCT_ID = Convert.ToInt32(lbl_SS_ID.Text);

                }
                else
                {
                    _obj_Smhr_Promotions_2.EMPPRO_SALALRYSTRUCT_ID = Convert.ToInt32(rcmb_SalStruct.SelectedValue.ToString());

                }

                _obj_Smhr_Promotions_2.EMPPRO_REPORTINGEMPLOYEE = Convert.ToInt32(rcmb_RepEmployee.SelectedValue.ToString());
                /*if (rdtp_RMEndDate.SelectedDate == null)  31.5.2016
                {
                    _obj_Smhr_Promotions_2.EMPPRO_REPORTINGEMPLOYEE_ENDDATE = null;
                }
                else
                    _obj_Smhr_Promotions_2.EMPPRO_REPORTINGEMPLOYEE_ENDDATE = Convert.ToDateTime(rdtp_RMEndDate.SelectedDate);*/

                _obj_Smhr_Promotions_2.EMPPRO_EMPLOYEETYPEN = Convert.ToString(rcmb_emptype.SelectedItem.Text);
                _obj_Smhr_Promotions_2.EMMPRO_SHIFT_ID = Convert.ToInt32(rcmb_Shift.SelectedValue.ToString());
                //_obj_Smhr_Promotions_2.EMPPRO_GROSSSAL = Convert.ToDouble(rtxt_GrossSalary.Text == null ? "null" : rtxt_GrossSalary.Text);

                string[] str = Convert.ToString(rcmb_Slabs.Text).Replace(" )", "").Replace(")", "").Split('(');
                _obj_Smhr_Promotions_2.EMPPRO_GROSSSAL = Convert.ToDouble(str[1].Trim());   //gross 

                // _obj_Smhr_Promotions_2.EMPPRO_GROSSSAL = Convert.ToDouble(rcmb_Slabs.Text);  // Convert.ToDouble(rcmb_Slabs.Text == null ? "null" : rcmb_Slabs.Text);    //gross 
                _obj_Smhr_Promotions_2.EMPPRO_BASIC = Convert.ToDouble(rtxt_Basic.Text == null ? "null" : rtxt_Basic.Text);
                //if (lbl_AnnualGross.Text != string.Empty)
                //    _obj_Smhr_Promotions_2.EMPPRO_ANNUALGROSSSAL = Convert.ToDouble(lbl_AnnualGross.Text);
                //else
                _obj_Smhr_Promotions_2.EMPPRO_ANNUALGROSSSAL = 0.00;
                if (lbl_AnnualBasic.Text != string.Empty)
                    _obj_Smhr_Promotions_2.EMPPRO_ANNUALBASIC = Convert.ToDouble(lbl_AnnualBasic.Text);
                else
                    _obj_Smhr_Promotions_2.EMPPRO_ANNUALBASIC = 0.00;
                _obj_Smhr_Promotions_2.EMPPRO_STATUS = 0;
                //_obj_Smhr_Promotions_2.EMPPRO_EMPCODEN = Convert.ToString(lbl_empcode_from.Text);
                _obj_Smhr_Promotions.OPERATION = operation.Insert;
                _obj_Smhr_Promotions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Promotions.EMPPRO_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Smhr_Promotions.EMPPRO_CREATEDDATE = DateTime.Now;
                _obj_Smhr_Promotions.EMPPRO_LSTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Smhr_Promotions.MP_LSTMDFDATE = DateTime.Now;


                //31.5.2016
                //_obj_Smhr_Promotions.EMPPRO_INCREMENTTYPE_ID = Convert.ToInt32(rcmb_IncrementType.SelectedValue);
                //31.5.2016 divya
                //_obj_Smhr_Promotions.EMP_INCRMENTMONTH = Convert.ToInt32(rcmb_IncrementMonth.SelectedValue);
                if (BLL.set_EmpPromotion(_obj_Smhr_Promotions, _obj_Smhr_Promotions_2))
                {
                    BLL.ShowMessage(this, "Employee Promotion Successfully Done");

                }
                if (Convert.ToDateTime(DateTime.Now) >= Convert.ToDateTime(Convert.ToDateTime(rdtp_DateofExecution.SelectedDate).ToShortDateString()))
                {
                    _obj_Smhr_Promotions_2.EMPPRO_STATUS = 1;
                    _obj_Smhr_Promotions.OPERATION = operation.Insert1;
                    if (BLL.set_EmpPromotion(_obj_Smhr_Promotions, _obj_Smhr_Promotions_2))
                    {
                    }
                }
                RM_PROMOTIONS.SelectedIndex = 0;
                LoadGrid();
                rg_Promotion.DataBind();
            }
            else
            {
                BLL.ShowMessage(this, errormsg);
                //int length = errormsg.Length;
                //string msg = errormsg.Substring(0, length - 1);
                //BLL.ShowMessage(this, msg);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //private void getEmpCode()
    //{
    //    string code = string.Empty;
    //    string str = string.Empty;
    //    string Series = string.Empty;
    //    string strCode = string.Empty;
    //    //_obj_smhr_employee = new SMHR_EMPLOYEE();
    //    //_obj_smhr_employee.OPERATION = operation.Update;
    //    //_obj_smhr_employee.APP_EMP_STATUS = Convert.ToString(rcmb_emptype.SelectedItem.Text);
    //    //_obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    //DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);
    //    //if (dt_Details.Rows.Count != 0)
    //    //{
    //    SMHR_EMPLOYEETYPE _obj_smhr_EmployeeType = new SMHR_EMPLOYEETYPE();
    //    _obj_smhr_EmployeeType.OPERATION = operation.Get;
    //    _obj_smhr_EmployeeType.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    _obj_smhr_EmployeeType.EMPLOYEETYPE_CODE = Convert.ToString(rcmb_emptype.SelectedItem.Text);
    //    DataTable dt = BLL.get_EmployeeType(_obj_smhr_EmployeeType);
    //    if (dt.Rows.Count != 0)
    //    {
    //        strCode = dt.Rows[0]["EMPLOYEETYPE_PREFIX"].ToString().Trim();
    //        str = dt.Rows[0]["EMPLOYEETYPE_SERIALNO"].ToString().Trim();
    //    }

    //    // str = dt_Details.Rows[0][0].ToString().Trim();
    //    //To get no of zero's for this organisation, by sravani 04.03.2011
    //    SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
    //    _obj_Smhr_BusinessUnit.OPERATION = operation.Get_BU;
    //    _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    DataTable dt_bu = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
    //    StringBuilder sb = new StringBuilder();
    //    if (dt_bu.Rows.Count > 0)
    //    {
    //        int n = Convert.ToInt32(dt_bu.Rows[0]["ORGANISATION_NOOFZEROS"]);
    //        for (int i = Convert.ToInt32(str.Length); i <= n; i++)
    //        {
    //            sb = sb.Append("0");
    //        }
    //        Series = Convert.ToString(sb);
    //    }


    //    //_obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
    //    ////_obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
    //    //_obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    //DataTable dt_BU = BLL.get_BusinessUnit(_obj_smhr_businessunit);

    //    //if (Convert.ToString(rcmb_emptype.SelectedItem.Text).Trim() == "Permanent and Pensionable")
    //    //{
    //    //    _obj_smhr_globalconfig = new SMHR_GLOBALCONFIG();
    //    //    _obj_smhr_globalconfig.OPERATION = operation.Select;
    //    //    _obj_smhr_globalconfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    //    DataTable dt = BLL.get_ConfigDetails(_obj_smhr_globalconfig);
    //    //    if (dt.Rows.Count != 0)
    //    //    {
    //    //        strCode = dt.Rows[0]["GLOBALCONFIG_EMP_CODE"].ToString().Trim();
    //    //    }
    //    //    lbl_Code.Text = Convert.ToString(strCode) + Convert.ToString(Series) + Convert.ToString(str);
    //    //}
    //    //else if(Convert.ToString(rcmb_emptype.SelectedItem.Text).Trim() == "Consultant")
    //    //{
    //    //     _obj_smhr_globalconfig = new SMHR_GLOBALCONFIG();
    //    //    _obj_smhr_globalconfig.OPERATION = operation.Select;
    //    //    _obj_smhr_globalconfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    //    DataTable dt = BLL.get_ConfigDetails(_obj_smhr_globalconfig);
    //    //    if (dt.Rows.Count != 0)
    //    //    {
    //    //        strCode = dt.Rows[0]["GLOBALCONFIG_CONSULTANT_EMPCODE"].ToString().Trim();
    //    //    }
    //    //    lbl_Code.Text = Convert.ToString(strCode) + Convert.ToString(Series) + Convert.ToString(str);
    //    //}
    //    //else
    //    //{
    //    //     _obj_smhr_globalconfig = new SMHR_GLOBALCONFIG();
    //    //    _obj_smhr_globalconfig.OPERATION = operation.Select;
    //    //    _obj_smhr_globalconfig.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    //    DataTable dt = BLL.get_ConfigDetails(_obj_smhr_globalconfig);
    //    //    if (dt.Rows.Count != 0)
    //    //    {
    //    //        strCode = dt.Rows[0]["GLOBALCONFIG_CONTRACT_EMPCODE"].ToString().Trim();
    //    //    }
    //    //    lbl_Code.Text = Convert.ToString(strCode) + Convert.ToString(Series) + Convert.ToString(str);
    //    //}
    //    lbl_Code.Text = Convert.ToString(strCode) + Convert.ToString(Series) + (Convert.ToInt32(str) + 1).ToString();
    //    //}
    //}
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            rcmb_Employee.Items.Clear();
            rcmb_Employee.Text = string.Empty;
            RM_PROMOTIONS.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void ClearControls()
    {
        try
        {
            //lbl_empcode_from.Text = string.Empty;
            //rtxt_empcode.Text = string.Empty;
            rdtp_DOJ.SelectedDate = null;
            // rdtp_DOC.SelectedDate = null;31.5.2016
            lbl_Basic_from.Text = string.Empty;
            lbl_Desg_from.Text = string.Empty;
            lbl_Desg_ID.Text = string.Empty;
            lbl_Grade_from.Text = string.Empty;
            //lbl_GrossSalary_from.Text = string.Empty;
            lbl_LeaveStruct_from.Text = string.Empty;
            lbl_Shifts_from.Text = string.Empty;
            lbl_ReportingEmployee_from.Text = string.Empty;
            lbl_emptype_from.Text = string.Empty;
            rcmb_emptype.SelectedIndex = 0;
            rcmb_Desg.SelectedIndex = -1;
            rcmb_Grade.SelectedIndex = -1;
            rcmb_Slabs.SelectedIndex = -1;
            rcmb_Slabs.Items.Clear();
            rcmb_Slabs.Text = string.Empty;
            lbl_Scale_From.Text = string.Empty;
            lbl_Slab_ID.Text = string.Empty;
            rcmb_GSCurrency.SelectedIndex = -1;
            rcmb_LeaveStruct.SelectedIndex = -1;
            rcmb_RepEmployee.SelectedIndex = -1;
            rcmb_SalStruct.SelectedIndex = -1;
            //rdtp_RMEndDate.SelectedDate = null;  31.5.2016
            rcmb_Shift.SelectedIndex = -1;
            //rtxt_GrossSalary.Text = string.Empty;
            rtxt_Basic.Text = string.Empty;
            rtxt_lS.Text = string.Empty;
            rdtp_DateofExecution.SelectedDate = null;
            lbl_SalStruct_from.Text = string.Empty;
            Disablefields(true);
            RM_PROMOTIONS.SelectedIndex = 0;
            //rcmb_Employee.SelectedIndex = -1;
            //rcmb_Employee.Items.Clear();
            //rcmb_Employee.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Desg.Items.Clear();
            rcmb_Desg.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Grade.Items.Clear();
            rcmb_Grade.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_GSCurrency.Items.Clear();
            rcmb_LeaveStruct.Items.Clear();
            rcmb_LeaveStruct.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_RepEmployee.Items.Clear();
            rcmb_RepEmployee.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_SalStruct.Items.Clear();
            rcmb_SalStruct.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Shift.Items.Clear();
            rcmb_Shift.Items.Insert(0, new RadComboBoxItem("", ""));
            rdtp_DateofExecution.MinDate = Convert.ToDateTime("01-01-1900");
            rdb_choose.SelectedIndex = -1;
            //lbl_AnnualGross.Text = string.Empty;
            lbl_AnnualBasic.Text = string.Empty;
            lblJobFrom.Text = string.Empty;
            lblJobID.Text = string.Empty;
            rcmb_Job.Items.Clear();
            rcmb_Job.Items.Insert(0, new RadComboBoxItem("", ""));
            //rcmb_FinancialPeriod.Items.Clear();
            //rcmb_FinancialPeriod.Items.Insert(0,new RadComboBoxItem("",""));
            rdp_IncrementDate.SelectedDate = null;
            rdp_ContractStart.SelectedDate = null;
            rdp_ContractEnd.SelectedDate = null;
            //31.5.2016
            // rcmb_IncrementMonth.Items.Clear();
            //31.5.2016
            // rcmb_IncrementType.Items.Clear();
            //31.5.2016
            //rcmb_IncrementTypeFrom.Items.Clear();
            //31.5.2016
            //lbl_IncrementMonthFrom.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Disablefields(false);

            LoadBusinessunit();
            LoadPeriod();
            //LoadEmployee();
            SMHR_EMPPROMOTIONS _obj_Smhr_Promotions = new SMHR_EMPPROMOTIONS();
            _obj_Smhr_Promotions.OPERATION = operation.Select;
            _obj_Smhr_Promotions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_Employee.Items.Clear();

            rcmb_Employee.DataSource = BLL.get_ReportingEmployee(_obj_Smhr_Promotions);
            rcmb_Employee.DataTextField = "EMPNAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            //LoadDropdowns();
            //SMHR_EMPPROMOTIONS _obj_Smhr_Promotions = new SMHR_EMPPROMOTIONS();
            _obj_Smhr_Promotions.EMPPRO_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _obj_Smhr_Promotions.OPERATION = operation.Select;
            DataTable dtnew = new DataTable();
            _obj_Smhr_Promotions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dtnew = BLL.get_EmpPromotions(_obj_Smhr_Promotions);
            if (dtnew.Rows.Count != 0)
            {
                //            rcmb_Employee.AllowCustomText = true;
                rcmb_Businessunit.SelectedIndex = rcmb_Businessunit.Items.FindItemIndexByValue(Convert.ToString(dtnew.Rows[0]["EMP_BUSINESSUNIT_ID"]));
                LoadDropdowns();
                rcmb_Employee.SelectedIndex = rcmb_Employee.FindItemIndexByValue(Convert.ToString(dtnew.Rows[0]["EMPPRO_EMPID"]));
                if ((Convert.ToInt32(dtnew.Rows[0]["EMP_STATUS"]) == 0) || (Convert.ToInt32(dtnew.Rows[0]["EMP_STATUS"]) == 1))
                {
                    rcmb_Employee.SelectedIndex = rcmb_Employee.FindItemIndexByValue(Convert.ToString(dtnew.Rows[0]["EMPPRO_EMPID"]));
                }
                else if ((Convert.ToInt32(dtnew.Rows[0]["EMP_STATUS"]) == 2) || (Convert.ToInt32(dtnew.Rows[0]["EMP_STATUS"]) == 3))
                {
                    _obj_Smhr_Promotions = new SMHR_EMPPROMOTIONS();
                    _obj_Smhr_Promotions.OPERATION = operation.EMPTY_R;
                    _obj_Smhr_Promotions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    rcmb_Employee.Items.Clear();

                    rcmb_Employee.DataSource = BLL.get_ReportingEmployee(_obj_Smhr_Promotions);
                    rcmb_Employee.DataTextField = "EMPNAME";
                    rcmb_Employee.DataValueField = "EMP_ID";
                    rcmb_Employee.DataBind();
                    rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                    rcmb_Employee.SelectedIndex = rcmb_Employee.FindItemIndexByValue(Convert.ToString(dtnew.Rows[0]["EMPPRO_EMPID"]));
                }
                rdtp_DateofExecution.MinDate = Convert.ToDateTime("01-01-1900");
                if (dtnew.Rows[0]["DOJ"] != DBNull.Value)
                {
                    rdtp_DOJ.SelectedDate = Convert.ToDateTime(dtnew.Rows[0]["DOJ"]);
                }
                else
                {
                    rdtp_DOJ.SelectedDate = null;
                }


                /*if (dtnew.Rows[0]["DOC"] != DBNull.Value)31.5.2016
                {
                    rdtp_DOC.SelectedDate = Convert.ToDateTime(dtnew.Rows[0]["DOC"]);
                }
                else
                {
                    rdtp_DOC.SelectedDate = null;
                }*/
                lbl_Desg_from.Text = Convert.ToString(dtnew.Rows[0]["Designation"]);

                if (dtnew.Rows[0]["PREVIOUS_GRADE"] != DBNull.Value)
                {
                    //lbl_Grade_from.Text = Convert.ToString(dtnew.Rows[0]["Grade"]);
                    lbl_Grade_from.Text = Convert.ToString(dtnew.Rows[0]["PREVIOUS_GRADE"]);
                }
                else
                {
                    lbl_Grade_from.Text = null;
                }

                //lbl_Scale_From.Text = Convert.ToString(dtnew.Rows[0]["PREVIOUS_SLAB"]);

                Double x;
                x = Convert.ToDouble(dtnew.Rows[0]["PREVIOUS_SLAB"]);
                lbl_Scale_From.Text = x.ToString("0.00");

                // String.Format("{0:0.00}", 123.4567);
                //rcmb_Grade.Text = Convert.ToString(dtnew.Rows[0]["GRADE"]);
                rcmb_Grade.ClearSelection();
                rcmb_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(Convert.ToString(dtnew.Rows[0]["GRADE"]), "0"));
                // rcmb_Grade.DataBind();
                //rcmb_Grade.SelectedIndex = 0;
                //rcmb_Slabs.Text = Convert.ToString(dtnew.Rows[0]["EMP_SLAB"]);

                Double y;
                y = Convert.ToDouble(dtnew.Rows[0]["EMP_SLAB"]);
                // lbl_Scale_From.Text = Y.ToString("0.00");

                rcmb_Slabs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem(y.ToString("0.00"), "0"));
                rcmb_Slabs.DataBind();



                //bl_Grade_ID.Text = Convert.ToString(dtnew.Rows[0]["Grade_ID"]);
                // lbl_GrossSalary_from.Text = Convert.ToString(dtnew.Rows[0]["Gross_Salary"]);
                lbl_LeaveStruct_from.Text = Convert.ToString(dtnew.Rows[0]["Leave_Structure"]);
                // lbl_LS_ID.Text = Convert.ToString(dtnew.Rows[0]["LS_ID"]);
                lbl_SalStruct_from.Text = Convert.ToString(dtnew.Rows[0]["Salary_Structure"]);
                // lbl_SS_ID.Text = Convert.ToString(dtnew.Rows[0]["SS_ID"]);
                lbl_Shifts_from.Text = Convert.ToString(dtnew.Rows[0]["Shift"]);
                //  lbl_Shift_ID.Text = Convert.ToString(dtnew.Rows[0]["SHIFT_ID"]);
                lbl_Basic_from.Text = Convert.ToString(dtnew.Rows[0]["Basic"]);
                _obj_Smhr_Promotions.OPERATION = operation.Empty;
                //DataTable dtpp = BLL.get_ReportingEmployee(_obj_Smhr_Promotions);
                //if (dtpp.Rows.Count != 0)
                //{
                lbl_ReportingEmployee_from.Text = Convert.ToString(dtnew.Rows[0]["EMPPRO_REPORTINGEMPLOYEE"]);
                // lbl_PR.Text = Convert.ToString(dtpp.Rows[0]["REMP_ID"]);
                //}
                //rdtnewp_DateofExecution.SelectedDate = DateTime.Now;
                if (dtnew.Rows[0]["EMPPRO_EMPLOYEETYPE"] != System.DBNull.Value)
                {
                    lbl_emptype_from.Text = Convert.ToString(dtnew.Rows[0]["EMPPRO_EMPLOYEETYPE"]);
                }
                else
                {
                    lbl_emptype_from.Text = string.Empty;
                }
                if (dtnew.Rows[0]["EMPPRO_EMPLOYEETYPEN"] != System.DBNull.Value)
                {
                    rcmb_emptype.SelectedIndex = rcmb_emptype.Items.FindItemIndexByText(Convert.ToString(dtnew.Rows[0]["EMPPRO_EMPLOYEETYPEN"]));
                }
                else
                {
                    rcmb_emptype.SelectedIndex = 0;
                }
                //if (dtnew.Rows[0]["EMPPRO_EMPCODE"] != System.DBNull.Value)
                //{
                //    lbl_empcode_from.Text = Convert.ToString(dtnew.Rows[0]["EMPPRO_EMPCODE"]);
                //}
                //else
                //{
                //    lbl_empcode_from.Text = string.Empty;
                //}
                //if (dtnew.Rows[0]["EMPPRO_EMPCODEN"] != System.DBNull.Value)
                //{
                //    rtxt_empcode.Text = Convert.ToString(dtnew.Rows[0]["EMPPRO_EMPCODEN"]);
                //}
                //else
                //{
                //    rtxt_empcode.Text = string.Empty;
                //}

                rtxt_Basic.Text = Convert.ToString(dtnew.Rows[0]["EMPPRO_BASICN"]);
                rcmb_Businessunit.SelectedIndex = rcmb_Businessunit.Items.FindItemIndexByValue(Convert.ToString(dtnew.Rows[0]["EMP_BUSINESSUNIT_ID"]));
                lblJobFrom.Text = Convert.ToString(dtnew.Rows[0]["JOBS_CODE"]);
                lblJobID.Text = Convert.ToString(dtnew.Rows[0]["JOBS_ID"]);
                lblFinPeriodFrom.Text = Convert.ToString(dtnew.Rows[0]["PERIOD_NAME"]);
                rcmb_Job.SelectedIndex = rcmb_Job.FindItemIndexByValue(Convert.ToString(dtnew.Rows[0]["JOBS_IDN"]));    //to select job
                rcmb_Job_SelectedIndexChanged(null, null);
                rcmb_Desg.SelectedIndex = rcmb_Desg.Items.FindItemIndexByValue(Convert.ToString(dtnew.Rows[0]["EMPPRO_DESIGNATION_IDN"]));
                //rcmb_Grade.SelectedIndex = rcmb_Grade.Items.FindItemIndexByValue(Convert.ToString(dtnew.Rows[0]["EMPPRO_GRADEN"]));
                // rtxt_GrossSalary.Text = Convert.ToString(dtnew.Rows[0]["EMPPRO_GROSSSALN"]);
                rcmb_LeaveStruct.SelectedIndex = rcmb_LeaveStruct.Items.FindItemIndexByValue(Convert.ToString(dtnew.Rows[0]["EMPPRO_LEAVESTRUCT_IDN"]));
                rcmb_Shift.SelectedIndex = rcmb_Shift.Items.FindItemIndexByValue(Convert.ToString(dtnew.Rows[0]["EMMPRO_SHIFT_IDN"]));
                rcmb_SalStruct.SelectedIndex = rcmb_SalStruct.Items.FindItemIndexByValue(Convert.ToString(dtnew.Rows[0]["EMPPRO_SALALRYSTRUCT_IDN"]));
                rcmb_RepEmployee.SelectedIndex = rcmb_RepEmployee.Items.FindItemIndexByValue(Convert.ToString(dtnew.Rows[0]["EMPPRO_REPORTINGEMPLOYEEN"]));


                /*if ((dtnew.Rows[0]["EMPPRO_REPORTINGEMPLOYEE_ENDDATEN"]) == System.DBNull.Value)   31.5.2016
                {
                    rdtp_RMEndDate.SelectedDate = null;
                }
                else
                {
                    rdtp_RMEndDate.SelectedDate = Convert.ToDateTime(dtnew.Rows[0]["EMPPRO_REPORTINGEMPLOYEE_ENDDATEN"]);
                }*/
                if (rdtp_DOJ.SelectedDate != null)
                    rtxt_lS.Text = UnitOfMeasure.ConvertToDuration(DateTime.Now.Subtract(Convert.ToDateTime(rdtp_DOJ.SelectedDate)).Days);
                rdtp_DateofExecution.SelectedDate = Convert.ToDateTime(dtnew.Rows[0]["EMPPRO_DATEOFPROMOTION"]);
                if (!string.IsNullOrEmpty(Convert.ToString(dtnew.Rows[0]["EMPPRO_INCRMENTDATE"])))
                {

                    if (Convert.ToDateTime(dtnew.Rows[0]["EMPPRO_INCRMENTDATE"]).ToString("dd-MM-yyyy") == "01-01-1900")
                    {
                        rdp_IncrementDate = null;
                    }

                    else
                        rdp_IncrementDate.SelectedDate = Convert.ToDateTime(dtnew.Rows[0]["EMPPRO_INCRMENTDATE"]);
                }

                if (!string.IsNullOrEmpty(Convert.ToString(dtnew.Rows[0]["EMPRO_CONTRACT_STARTDATE"])))
                {
                    if (Convert.ToDateTime(dtnew.Rows[0]["EMPRO_CONTRACT_STARTDATE"]).ToString("dd-MM-yyyy") == "01-01-1900")
                    {
                        rdp_ContractStart = null;
                    }
                    else
                        rdp_ContractStart.SelectedDate = Convert.ToDateTime(dtnew.Rows[0]["EMPRO_CONTRACT_STARTDATE"]);
                }
                /*else
                {
                    rdp_ContractStart.SelectedDate = null;
                }*/
                if (!string.IsNullOrEmpty(Convert.ToString(dtnew.Rows[0]["EMPRO_CONTRACT_ENDDATE"])))
                {
                    if (Convert.ToDateTime(dtnew.Rows[0]["EMPRO_CONTRACT_ENDDATE"]).ToString("dd-MM-yyyy") == "01-01-1900")
                    {
                        rdp_ContractEnd = null;
                    }
                    else
                        rdp_ContractEnd.SelectedDate = Convert.ToDateTime(dtnew.Rows[0]["EMPRO_CONTRACT_ENDDATE"]);
                }
                /*else
                {
                    rdp_ContractEnd.SelectedDate = null;
                }*/
                if (!string.IsNullOrEmpty(Convert.ToString(dtnew.Rows[0]["EMPPRO_PERIOD"])))
                {
                    rcmb_FinancialPeriod.SelectedIndex = rcmb_FinancialPeriod.Items.FindItemIndexByValue(Convert.ToString(dtnew.Rows[0]["EMPPRO_PERIOD"]));
                }
                else
                {
                    rcmb_FinancialPeriod.SelectedIndex = 0;
                }


                //To show Increment type
                //lbl_IncrementTypeFrom.Text = Convert.ToString(dtnew.Rows[0]["INCREMENTTYPE"]);
                //31.5.2016
                /*if (!string.IsNullOrEmpty(Convert.ToString(dtnew.Rows[0]["EMPPRO_INCREMENTTYPE_ID"])))
                {
                    rcmb_IncrementTypeFrom.SelectedIndex = rcmb_IncrementTypeFrom.FindItemIndexByValue(Convert.ToString(dtnew.Rows[0]["EMPPRO_INCREMENTTYPE_ID"]));
                }
                else
                {
                    rcmb_IncrementTypeFrom.ClearSelection();
                }*/

                //31.5.2016
                /*if (!string.IsNullOrEmpty(Convert.ToString(dtnew.Rows[0]["EMPPRO_INCREMENTTYPE_IDN"])))
                {
                    rcmb_IncrementType.SelectedIndex = rcmb_IncrementType.FindItemIndexByValue(Convert.ToString(dtnew.Rows[0]["EMPPRO_INCREMENTTYPE_IDN"]));
                }
                else
                {
                    rcmb_IncrementType.ClearSelection();
                }*/

                //To select Increment Month
                //31.5.2016 divya
                /* if (!string.IsNullOrEmpty(Convert.ToString(dtnew.Rows[0]["EMP_INCRMENTMONTH"])))
                 {
                     rcmb_IncrementMonth.SelectedIndex = rcmb_IncrementMonth.FindItemIndexByValue(Convert.ToString(dtnew.Rows[0]["EMP_INCRMENTMONTH"]));
                 }
                 else
                 {
                     rcmb_IncrementMonth.ClearSelection();
                 }

                 //To select Previous Increment Month
                 if (!string.IsNullOrEmpty(Convert.ToString(dtnew.Rows[0]["PREVIOUS_INCRMENTMONTH"])))
                 {
                     lbl_IncrementMonthFrom.Text = Convert.ToString(dtnew.Rows[0]["PREVIOUS_INCRMENTMONTH"]);
                 }
                 else
                 {
                     lbl_IncrementMonthFrom.Text = string.Empty;
                 }*/
            }
            RM_PROMOTIONS.SelectedIndex = 1;

            //Disablefields(false);
            //rtxt_empcode.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void Disablefields(bool b)
    {
        try
        {
            rcmb_Employee.Enabled = b;
            //rdtp_DOJ.Enabled = b;
            //rdtp_DOC.Enabled = b;
            lbl_Basic_from.Enabled = b;
            lbl_Desg_from.Enabled = b;
            lbl_Grade_from.Enabled = b;
            // lbl_GrossSalary_from.Enabled = b; ;
            lbl_LeaveStruct_from.Enabled = b; ;
            lbl_Shifts_from.Enabled = b;
            lbl_ReportingEmployee_from.Enabled = b;
            rcmb_Desg.Enabled = b;
            rcmb_Employee.Enabled = b;
            rcmb_Grade.Enabled = b;
            rcmb_GSCurrency.Enabled = b;
            rcmb_LeaveStruct.Enabled = b;
            rcmb_RepEmployee.Enabled = b;
            rcmb_SalStruct.Enabled = b;
            //rdtp_RMEndDate.Enabled = b;  31.5.2016
            rcmb_Shift.Enabled = b;
            rcmb_Slabs.Enabled = b;
            //rtxt_GrossSalary.Enabled = b;
            //rtxt_Basic.Enabled = b;
            rdtp_DateofExecution.Enabled = b;
            rcmb_Businessunit.Enabled = b;// BUSINESSUNIT
            lbl_SalStruct_from.Enabled = b;
            rcmb_emptype.Enabled = b;
            rcmb_Job.Enabled = b;
            rcmb_FinancialPeriod.Enabled = b;
            rdp_IncrementDate.Enabled = b;
            rdp_ContractStart.Enabled = b;
            rdp_ContractEnd.Enabled = b;
            //31.5.2016
            //rcmb_IncrementMonth.Enabled = b;
            //31.5.2016
            //rcmb_IncrementType.Enabled = b;
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Submit.Enabled = false;
            }
            else
            {
                btn_Submit.Enabled = b;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rg_Promotion_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void getJob(string strPosition)
    {
        try
        {
            if (strPosition != "")
            {
                SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                _obj_smhr_positions.OPERATION = operation.Empty;
                _obj_smhr_positions.POSITIONS_ID = Convert.ToInt32(strPosition);
                _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_Positions(_obj_smhr_positions);
                if (dt.Rows.Count != 0)
                {
                    //lbl_jobName.Text = Convert.ToString(dt.Rows[0]["JOBS_CODE"]);
                    if (Convert.ToString(dt.Rows[0]["JOBS_ID"]) != "")
                    {
                        SMHR_JOBS _obj_Jobs = new SMHR_JOBS();
                        _obj_Jobs.JOBS_ID = Convert.ToInt32(dt.Rows[0]["JOBS_ID"]);
                        DataTable dt1 = BLL.get_Jobs(_obj_Jobs);
                        maxsal = Convert.ToDouble(dt1.Rows[0]["JOBS_MAXSAL"]);
                        minsal = Convert.ToDouble(dt1.Rows[0]["JOBS_MINSAL"]);
                        //if (rtxt_GrossSalary.Text != "" || lbl_GrossSalary.Text != string.Empty)
                        //{
                        //    //for validating job minsal and maxsal with the gross                        
                        //    if (!((Convert.ToDouble(lbl_GrossSalary.Text) >= minsal) && (Convert.ToDouble(lbl_GrossSalary.Text) <= maxsal)))
                        //    {
                        //        BLL.ShowMessage(this, "Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
                        //        rtxt_GrossSalary.Text = "";
                        //        rtxt_Basic.Text = "";
                        //        lbl_GrossSalary.Text = string.Empty;
                        //        //return;
                        //    }

                        //}
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void getJobAnnual(string strPosition)
    {
        try
        {
            if (strPosition != "")
            {
                SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                _obj_smhr_positions.OPERATION = operation.Empty;
                _obj_smhr_positions.POSITIONS_ID = Convert.ToInt32(strPosition);
                _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_Positions(_obj_smhr_positions);
                if (dt.Rows.Count != 0)
                {
                    //lbl_jobName.Text = Convert.ToString(dt.Rows[0]["JOBS_CODE"]);
                    if (Convert.ToString(dt.Rows[0]["JOBS_ID"]) != "")
                    {
                        SMHR_JOBS _obj_Jobs = new SMHR_JOBS();
                        _obj_Jobs.JOBS_ID = Convert.ToInt32(dt.Rows[0]["JOBS_ID"]);
                        DataTable dt1 = BLL.get_Jobs(_obj_Jobs);
                        maxsal = Convert.ToDouble(dt1.Rows[0]["JOBS_MAXSAL"]);
                        minsal = Convert.ToDouble(dt1.Rows[0]["JOBS_MINSAL"]);
                        //if (rtxt_GrossSalary.Text != "" || lbl_GrossSalary.Text != string.Empty)
                        //{
                        //    //for validating job minsal and maxsal with the gross                        
                        //    if (!((Convert.ToDouble(lbl_AnnualGross.Text) >= minsal) && (Convert.ToDouble(lbl_AnnualGross.Text) <= maxsal)))
                        //    {
                        //        BLL.ShowMessage(this, "Annual Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
                        //        rtxt_GrossSalary.Text = "";
                        //        rtxt_Basic.Text = "";
                        //        lbl_AnnualGross.Text = string.Empty;
                        //        lbl_AnnualBasic.Text = string.Empty;
                        //        lbl_GrossSalary.Text = string.Empty;
                        //        //return;
                        //    }

                        //}
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Businessunit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            ClearControls();
            rcmb_Employee.Items.Clear();
            rcmb_Employee.Text = string.Empty;
            //rcmb_Employee.Items.Insert(0, new RadComboBoxItem("", ""));
            RM_PROMOTIONS.SelectedIndex = 1;
            LoadEmployee();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rdb_choose_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            rcmb_FinancialPeriod.SelectedIndex = 0;
            if (Convert.ToInt32(rdb_choose.SelectedItem.Value) == 0)
            {
                RM_PROMOTIONS.SelectedIndex = 1;
            }
            else
            {
                RM_PROMOTIONS.SelectedIndex = 3;
                rdtp_execdate_group.MinDate = DateTime.Today;   //Setting mindate to today's date
                LoadDropdowns_Group();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadDropdowns_Group()
    {
        try
        {
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            if (Convert.ToString(Session["ORG_ID"]) != string.Empty)
            {
                _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
                rcmb_BU_group.Items.Clear();
                DataTable dt_businessunit = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
                rcmb_BU_group.DataSource = dt_businessunit;
                rcmb_BU_group.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BU_group.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BU_group.DataBind();
                rcmb_BU_group.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                Response.Redirect("~/Login.aspx", false);
            }
            //Load Grade
            rcmb_grade_group.Items.Clear();
            SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();
            _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade).Tables[0];
            rcmb_grade_group.DataSource = DT;
            rcmb_grade_group.DataTextField = "EMPLOYEEGRADE_CODE";
            rcmb_grade_group.DataValueField = "EMPLOYEEGRADE_ID";
            rcmb_grade_group.DataBind();
            rcmb_grade_group.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            //_obj_Smhr_Masters = new SMHR_MASTERS();
            //_obj_Smhr_Masters.MASTER_TYPE = "GRADE";
            //_obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //rcmb_grade_group.Items.Clear();
            //rcmb_grade_group.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
            //rcmb_grade_group.DataTextField = "HR_MASTER_CODE";
            //rcmb_grade_group.DataValueField = "HR_MASTER_ID";
            //rcmb_grade_group.DataBind();
            //rcmb_grade_group.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            //Load Leave Structure
            _obj_Smhr_Leavestruct = new SMHR_LEAVESTRUCT();
            _obj_Smhr_Leavestruct.OPERATION = operation.Select;
            _obj_Smhr_Leavestruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_levestruct_group.Items.Clear();
            rcmb_levestruct_group.DataSource = BLL.get_LeaveStructHeaderDetails(_obj_Smhr_Leavestruct);
            rcmb_levestruct_group.DataTextField = "LEAVESTRUCT_CODE";
            rcmb_levestruct_group.DataValueField = "LEAVESTRUCT_ID";
            rcmb_levestruct_group.DataBind();
            rcmb_levestruct_group.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));


            //Load Salary Structure
            _obj_Smhr_SalStruct = new SMHR_SALARYSTRUCT();
            _obj_Smhr_SalStruct.OPERATION = operation.Select;

            _obj_Smhr_SalStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_salstruct_group.Items.Clear();
            rcmb_salstruct_group.DataSource = BLL.get_SalaryHeaderDetails(_obj_Smhr_SalStruct);
            rcmb_salstruct_group.DataTextField = "SALARYSTRUCT_CODE";
            rcmb_salstruct_group.DataValueField = "SALARYSTRUCT_ID";
            rcmb_salstruct_group.DataBind();
            rcmb_salstruct_group.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            //Load Reporting Employee
            _obj_Smhr_Promotions = new SMHR_EMPPROMOTIONS();
            _obj_Smhr_Promotions.OPERATION = operation.Select1;
            //_obj_Smhr_Promotions.EMPPRO_EMPID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
            _obj_Smhr_Promotions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_reportemp_group.Items.Clear();
            rcmb_reportemp_group.DataSource = BLL.get_EmpPromotions(_obj_Smhr_Promotions);
            rcmb_reportemp_group.DataTextField = "EMPNAME";
            rcmb_reportemp_group.DataValueField = "EMP_ID";
            rcmb_reportemp_group.DataBind();
            rcmb_reportemp_group.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            //Load Increment Month
            //31.5.2016 divya
            /*SMHR_EMPLOYEE objEmployee = new SMHR_EMPLOYEE();
            objEmployee.OPERATION = operation.Select_New;
            rcmb_IncrementMonth_group.Items.Clear();
            rcmb_IncrementMonth_group.DataSource = BLL.get_IncrementMonth(objEmployee);
            rcmb_IncrementMonth_group.DataTextField = "INCR_MONTH";
            rcmb_IncrementMonth_group.DataValueField = "INCR_ID";
            rcmb_IncrementMonth_group.DataBind();
            rcmb_IncrementMonth_group.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));*/

            //Load Increment Type Group
            //SMHR_EMPLOYEE objEmployee = new SMHR_EMPLOYEE();
            //31.5.2016
            /*objEmployee.OPERATION = operation.Get;
            objEmployee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_IncrementType = BLL.get_IncrementMonth(objEmployee);

            //dt_IncrementType.DefaultView.RowFilter = " HR_MASTER_DESC  in ('Promotion', 'Revision')";
            dt_IncrementType.DefaultView.RowFilter = " HR_MASTER_DESC  in ('Revision')";
            dt_IncrementType = dt_IncrementType.DefaultView.ToTable();
            rcmb_IncrementType_Group.DataSource = dt_IncrementType;
            rcmb_IncrementType_Group.DataValueField = "HR_MASTER_ID";
            rcmb_IncrementType_Group.DataTextField = "HR_MASTER_DESC";
            rcmb_IncrementType_Group.DataBind();*/
            //rcmb_IncrementType_Group.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_BU_group_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BU_group.SelectedIndex > 0 && rcmb_grade_group.SelectedIndex > 0)
            {
                LoadGrid_Group();
            }
            else
            {
                rg_employees_group.Visible = false;
                btn_submit_group.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadGrid_Group()
    {
        try
        {
            _obj_Smhr_Promotions = new SMHR_EMPPROMOTIONS();
            _obj_Smhr_Promotions.BUID = Convert.ToInt32(rcmb_BU_group.SelectedItem.Value);
            _obj_Smhr_Promotions.EMPPRO_GRADE = Convert.ToInt32(rcmb_grade_group.SelectedItem.Value);
            _obj_Smhr_Promotions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Promotions.OPERATION = operation.Select_New;
            DataTable dt_emp = BLL.get_EmpPromotions(_obj_Smhr_Promotions);
            rg_employees_group.DataSource = dt_emp;
            rg_employees_group.DataBind();
            if (dt_emp.Rows.Count > 0)
            {
                btn_submit_group.Visible = true;
                rg_employees_group.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_grade_group_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BU_group.SelectedIndex > 0 && rcmb_grade_group.SelectedIndex > 0)
            {
                LoadGrid_Group();
            }
            else
            {
                rg_employees_group.Visible = false;
                btn_submit_group.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void chk_selectall_checkedchanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < rg_employees_group.Items.Count; i++)
            {
                CheckBox Chk_All = (CheckBox)sender;
                if (Chk_All.Checked)
                {
                    for (int index = 0; index < rg_employees_group.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)rg_employees_group.Items[index].FindControl("chckbtn_Select");
                        c.Checked = true; ;
                    }
                }
                else
                {
                    for (int index = 0; index < rg_employees_group.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)rg_employees_group.Items[index].FindControl("chckbtn_Select");
                        c.Checked = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void rtxt_gross_group_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        //code for getting Basic percentage of Gross For the businessunit selected
    //        _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
    //        _obj_smhr_businessunit.OPERATION = operation.Select;
    //        _obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BU_group.SelectedValue);
    //        _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        DataTable dt_BusinessUnit = BLL.get_BusinessUnit(_obj_smhr_businessunit);
    //        Telerik.Web.UI.RadNumericTextBox rtxt_gross_group = sender as Telerik.Web.UI.RadNumericTextBox;
    //        GridItem gvRow = rtxt_gross_group.Parent.Parent as GridItem;
    //        RadNumericTextBox rnt_gross = (RadNumericTextBox)gvRow.FindControl("rtxt_gross_group");
    //        RadNumericTextBox rnt_basic = (RadNumericTextBox)gvRow.FindControl("rtxt_basic_group");
    //        RadNumericTextBox rnt_annualgross = (RadNumericTextBox)gvRow.FindControl("rtxt_annualgross");
    //        RadNumericTextBox rnt_annualbasic = (RadNumericTextBox)gvRow.FindControl("rtxt_annualbasic");
    //        Label lblempid = (Label)gvRow.FindControl("lbl_emp_id");

    //        if (rcmb_salstruct_group.SelectedIndex <= 0)
    //        {
    //            BLL.ShowMessage(this, "Please Select Salary Structure.");
    //            rnt_gross.Text = "";
    //            return;
    //        }
    //        //TO GET EMPLOYEE DETAILS
    //        _obj_smhr_employee = new SMHR_EMPLOYEE();
    //        _obj_smhr_employee.OPERATION = operation.Select;
    //        _obj_smhr_employee.EMP_ID = Convert.ToInt32(lblempid.Text);
    //        //dt_Details = new DataTable();
    //        _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);
    //        if (dt_Details.Rows.Count > 0)
    //        {
    //            //FOR PERMANENT EMPLOYEE
    //            if (Convert.ToString(dt_Details.Rows[0]["EMP_EMPLOYEETYPE"]) == "Permanent and Pensionable")
    //            {
    //                if ((dt_BusinessUnit.Rows.Count > 0) && (rcmb_BU_group.SelectedValue != string.Empty))
    //                {
    //                    if (dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"] != System.DBNull.Value)
    //                    {
    //                        float IBasicPercent = Convert.ToSingle(dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"]);

    //                        float emp_GrossSal = Convert.ToSingle(rnt_gross.Text.Replace("'", "''"));
    //                        //float emp_BasicSal = (55 * emp_GrossSal) / 100;
    //                        float emp_BasicSal = (IBasicPercent * emp_GrossSal) / 100;
    //                        rnt_basic.Text = Convert.ToString(emp_BasicSal);
    //                       // lbl_GrossSalary.Text = rnt_gross.Text;
    //                        //rnt_gross.Focus();

    //                        //TO CALCULATE ANNUAL GROSS AND ANNUAL BASIC
    //                        SMHR_ORGANISATION _obj_SMHR_ORGANISATION = new SMHR_ORGANISATION();
    //                        _obj_SMHR_ORGANISATION.MODE = 2;
    //                        _obj_SMHR_ORGANISATION.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                        DataTable dt_Organisation = BLL.get_Organisation(_obj_SMHR_ORGANISATION);
    //                        if (dt_Organisation.Rows.Count != 0)
    //                        {
    //                            if (Convert.ToString(dt_Organisation.Rows[0]["ORGANISATION_ANNUALPROCESS"]) != "")
    //                            {
    //                                if (Convert.ToString(dt_Organisation.Rows[0]["ORGANISATION_ANNUALPROCESS"]).ToUpper() == "TRUE")
    //                                {
    //                                    SMHR_SALARYSTRUCT _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
    //                                    _obj_smhr_salaryStruct.OPERATION = operation.Select;
    //                                    _obj_smhr_salaryStruct.SALARYSTRUCT_ID = Convert.ToInt32(rcmb_salstruct_group.SelectedItem.Value);
    //                                    _obj_smhr_salaryStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                                    DataTable dt_PeriodType = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
    //                                    _obj_smhr_salaryStruct.SALARYSTRUCT_TYPE = Convert.ToInt32(dt_PeriodType.Rows[0]["SALARYSTRUCT_TYPE"]);
    //                                    _obj_smhr_salaryStruct.OPERATION = operation.Validate;
    //                                    DataTable dt_PeriodTypeName = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
    //                                    if (dt_PeriodTypeName.Rows.Count != 0)
    //                                    {
    //                                        if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "MONTHLY")
    //                                        {
    //                                            //lbl_AnnualGross.Text = Convert.ToString(Convert.ToDouble(rnt_gross.Text) * 12);
    //                                            //double IAnnualGross = Convert.ToDouble(lbl_AnnualGross.Text);
    //                                            //int IBasic = (IGross * 55) / 100;
    //                                            double IAnnualBasic = (IAnnualGross * IBasicPercent) / 100;
    //                                            lbl_AnnualBasic.Text = Convert.ToString(IAnnualBasic);
    //                                        }
    //                                        else if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "FORTNIGHT")
    //                                        {
    //                                            //lbl_AnnualGross.Text = Convert.ToString(Convert.ToDouble(rnt_gross.Text) * 26);
    //                                            //double IAnnualGross = Convert.ToDouble(lbl_AnnualGross.Text);
    //                                            //int IBasic = (IGross * 55) / 100;
    //                                            double IAnnualBasic = (IAnnualGross * IBasicPercent) / 100;
    //                                            lbl_AnnualBasic.Text = Convert.ToString(IAnnualBasic);
    //                                        }
    //                                    }
    //                                    getJobAnnual(Convert.ToString(dt_Details.Rows[0]["EMP_DESIGNATION_ID"]));
    //                                    //if (lbl_AnnualGross.Text != string.Empty && lbl_AnnualBasic.Text != string.Empty)
    //                                    //{
    //                                    //    rnt_annualgross.Text = lbl_AnnualGross.Text;
    //                                    //    rnt_annualbasic.Text = lbl_AnnualBasic.Text;
    //                                    //}
    //                                    //else
    //                                    //{
    //                                    //    rnt_annualgross.Value = 0.0;
    //                                    //    rnt_annualbasic.Value = 0.0;
    //                                    //    rnt_gross.Text = "";
    //                                    //    rnt_basic.Text = "";
    //                                    //    lbl_GrossSalary.Text = string.Empty;
    //                                    //    return;
    //                                    //}
    //                                }
    //                                else
    //                                {
    //                                    //lbl_AnnualGross.Text = string.Empty;
    //                                    lbl_AnnualBasic.Text = string.Empty;
    //                                    rnt_annualgross.Value = 0.0;
    //                                    rnt_annualbasic.Value = 0.0;
    //                                    getJob(Convert.ToString(dt_Details.Rows[0]["EMP_DESIGNATION_ID"]));
    //                                    //if (lbl_GrossSalary.Text == string.Empty)
    //                                    //{
    //                                    //    rnt_gross.Text = "";
    //                                    //    rnt_basic.Text = "";
    //                                    //    return;
    //                                    //}
    //                                }
    //                            }
    //                            else
    //                            {
    //                                lbl_AnnualBasic.Text = string.Empty;
    //                                //lbl_AnnualGross.Text = string.Empty;
    //                                rnt_annualgross.Value = 0.0;
    //                                rnt_annualbasic.Value = 0.0;
    //                                getJob(Convert.ToString(dt_Details.Rows[0]["EMP_DESIGNATION_ID"]));
    //                                //if (lbl_GrossSalary.Text == string.Empty)
    //                                //{
    //                                //    rnt_gross.Text = "";
    //                                //    rnt_basic.Text = "";
    //                                //    return;
    //                                //}
    //                            }
    //                        }
    //                    }
    //                    else
    //                    {
    //                        BLL.ShowMessage(this, "Basic Is Not Defined For The Businessunit:" + rcmb_BU_group.SelectedItem.Text);
    //                        rnt_gross.Text = "";
    //                        return;
    //                    }
    //                }
    //                else
    //                {
    //                    BLL.ShowMessage(this, "Select Proper Businessunit");
    //                    rnt_gross.Text = "";
    //                }
    //            }
    //            else
    //            {
    //                //FOR CONTRACT AND CONSULTANT EMPLOYEE
    //                float emp_GrossSal = Convert.ToSingle(rnt_gross.Text.Replace("'", "''"));
    //                rnt_basic.Text = Convert.ToString(emp_GrossSal);

    //                //TO CALCULATE ANNUAL GROSS AND ANNUAL BASIC
    //                SMHR_ORGANISATION _obj_SMHR_ORGANISATION = new SMHR_ORGANISATION();
    //                _obj_SMHR_ORGANISATION.MODE = 2;
    //                _obj_SMHR_ORGANISATION.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                DataTable dt_Organisation = BLL.get_Organisation(_obj_SMHR_ORGANISATION);
    //                if (dt_Organisation.Rows.Count != 0)
    //                {
    //                    if (Convert.ToString(dt_Organisation.Rows[0]["ORGANISATION_ANNUALPROCESS"]) != "")
    //                    {
    //                        if (Convert.ToString(dt_Organisation.Rows[0]["ORGANISATION_ANNUALPROCESS"]).ToUpper() == "TRUE")
    //                        {
    //                            SMHR_SALARYSTRUCT _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
    //                            _obj_smhr_salaryStruct.OPERATION = operation.Select;
    //                            _obj_smhr_salaryStruct.SALARYSTRUCT_ID = Convert.ToInt32(rcmb_salstruct_group.SelectedItem.Value);
    //                            _obj_smhr_salaryStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                            DataTable dt_PeriodType = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
    //                            _obj_smhr_salaryStruct.SALARYSTRUCT_TYPE = Convert.ToInt32(dt_PeriodType.Rows[0]["SALARYSTRUCT_TYPE"]);
    //                            _obj_smhr_salaryStruct.OPERATION = operation.Validate;
    //                            DataTable dt_PeriodTypeName = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
    //                            if (dt_PeriodTypeName.Rows.Count != 0)
    //                            {
    //                                if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "MONTHLY")
    //                                {
    //                                    lbl_AnnualGross.Text = Convert.ToString(Convert.ToDouble(rnt_gross.Text) * 12);
    //                                    lbl_AnnualBasic.Text = Convert.ToString(lbl_AnnualGross.Text);
    //                                }
    //                                else if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "FORTNIGHT")
    //                                {
    //                                    lbl_AnnualGross.Text = Convert.ToString(Convert.ToDouble(rnt_gross.Text) * 26);
    //                                    lbl_AnnualBasic.Text = Convert.ToString(lbl_AnnualGross.Text);
    //                                }
    //                            }
    //                            getJobAnnual(Convert.ToString(dt_Details.Rows[0]["EMP_DESIGNATION_ID"]));
    //                            if (lbl_AnnualGross.Text != string.Empty && lbl_AnnualBasic.Text != string.Empty)
    //                            {
    //                                rnt_annualgross.Text = lbl_AnnualGross.Text;
    //                                rnt_annualbasic.Text = lbl_AnnualBasic.Text;
    //                            }
    //                            else
    //                            {
    //                                rnt_annualgross.Value = 0.0;
    //                                rnt_annualbasic.Value = 0.0;
    //                                rnt_gross.Text = "";
    //                                rnt_basic.Text = "";
    //                                lbl_GrossSalary.Text = string.Empty;
    //                                return;
    //                            }
    //                        }
    //                        else
    //                        {
    //                            lbl_AnnualBasic.Text = string.Empty;
    //                            lbl_AnnualGross.Text = string.Empty;
    //                            rnt_annualgross.Value = 0.0;
    //                            rnt_annualbasic.Value = 0.0;
    //                            getJob(Convert.ToString(dt_Details.Rows[0]["EMP_DESIGNATION_ID"]));
    //                            if (lbl_GrossSalary.Text == string.Empty)
    //                            {
    //                                rnt_gross.Text = "";
    //                                rnt_basic.Text = "";
    //                                return;
    //                            }
    //                        }
    //                    }
    //                    else
    //                    {
    //                        lbl_AnnualBasic.Text = string.Empty;
    //                        lbl_AnnualGross.Text = string.Empty;
    //                        rnt_annualgross.Value = 0.0;
    //                        rnt_annualbasic.Value = 0.0;
    //                        getJob(Convert.ToString(dt_Details.Rows[0]["EMP_DESIGNATION_ID"]));
    //                        if (lbl_GrossSalary.Text == string.Empty)
    //                        {
    //                            rnt_gross.Text = "";
    //                            rnt_basic.Text = "";
    //                            return;
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    protected void btn_submit_group_Click(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            int c = 0;
            for (int i = 0; i < rg_employees_group.Items.Count; i++)
            {
                CheckBox chk = rg_employees_group.Items[i].FindControl("chckbtn_Select") as CheckBox;
                RadNumericTextBox rnt = rg_employees_group.Items[i].FindControl("rtxt_gross_group") as RadNumericTextBox;
                if (chk.Checked)
                {
                    count++;
                    if (rnt.Value != null)
                    {
                        c++;
                    }
                }

            }
            if (count == 0)
            {
                BLL.ShowMessage(this, "Please Select Atleast one Employee.");
                return;
            }
            if (count != c)
            {
                BLL.ShowMessage(this, "Please Enter Gross for Selected Employees.");
                return;
            }
            //TO GET REPORTING EMPLOYEE BUSINESSUNIT
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(rcmb_reportemp_group.SelectedValue.ToString());
            //dt_Details = new DataTable();
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);
            _obj_Smhr_Promotions = new SMHR_EMPPROMOTIONS();
            _obj_Smhr_Promotions_2 = new SMHR_EMPPROMOTIONS();
            if (dt_Details.Rows.Count > 0)
            {
                _obj_Smhr_Promotions.BUID = Convert.ToInt32(dt_Details.Rows[0]["EMP_BUSINESSUNIT_ID"]);
            }
            _obj_Smhr_Promotions.EMPPRO_REPORTINGEMPLOYEE = Convert.ToInt32(rcmb_reportemp_group.SelectedItem.Value);
            if (rdtp_reptenddate_group.SelectedDate == null)
                _obj_Smhr_Promotions.EMPPRO_REPORTINGEMPLOYEE_ENDDATE = null;
            else
                _obj_Smhr_Promotions.EMPPRO_REPORTINGEMPLOYEE_ENDDATE = Convert.ToDateTime(rdtp_reptenddate_group.SelectedDate);
            _obj_Smhr_Promotions.EMPPRO_LEAVESTRUCT_ID = Convert.ToInt32(rcmb_levestruct_group.SelectedItem.Value);
            _obj_Smhr_Promotions.EMPPRO_SALALRYSTRUCT_ID = Convert.ToInt32(rcmb_salstruct_group.SelectedItem.Value);
            _obj_Smhr_Promotions.EMPPRO_STATUS = 0;
            if (rdtp_execdate_group.SelectedDate == null)
                _obj_Smhr_Promotions.EMPPRO_DATEOFPROMOTION = null;
            else
                _obj_Smhr_Promotions.EMPPRO_DATEOFPROMOTION = Convert.ToDateTime(rdtp_execdate_group.SelectedDate);
            bool status = false;
            for (int k = 0; k < rg_employees_group.Items.Count; k++)
            {
                Label lblempid = new Label();
                CheckBox chk = new CheckBox();
                chk = rg_employees_group.Items[k].FindControl("chckbtn_Select") as CheckBox;
                if (chk.Checked)
                {
                    RadNumericTextBox rnt_gross = new RadNumericTextBox();
                    RadNumericTextBox rnt_basic = new RadNumericTextBox();
                    RadNumericTextBox rnt_annualgross = new RadNumericTextBox();
                    RadNumericTextBox rnt_annualbasic = new RadNumericTextBox();
                    RadComboBox rcmb_Slab = new RadComboBox();  //To store SlabID
                    Label lblEmpSlabID = new Label();   //To store previous slabID


                    lblempid = rg_employees_group.Items[k].FindControl("lbl_emp_id") as Label;
                    rnt_gross = rg_employees_group.Items[k].FindControl("rtxt_gross_group") as RadNumericTextBox;
                    rnt_basic = rg_employees_group.Items[k].FindControl("rtxt_basic_group") as RadNumericTextBox;
                    rnt_annualgross = rg_employees_group.Items[k].FindControl("rtxt_annualgross") as RadNumericTextBox;
                    rnt_annualbasic = rg_employees_group.Items[k].FindControl("rtxt_annualbasic") as RadNumericTextBox;

                    rcmb_Slab = rg_employees_group.Items[k].FindControl("rcmb_GridSlabs") as RadComboBox;
                    lblEmpSlabID = rg_employees_group.Items[k].FindControl("lblEmpSlabID") as Label;    //To store previous slabID


                    _obj_Smhr_Promotions.EMPPRO_EMPID = Convert.ToInt32(lblempid.Text);
                    _obj_Smhr_Promotions.EMPPRO_GROSSSAL = Convert.ToDouble(rnt_gross.Value);
                    _obj_Smhr_Promotions.EMPPRO_BASIC = Convert.ToDouble(rnt_basic.Value);
                    _obj_Smhr_Promotions.EMPPRO_ANNUALGROSSSAL = Convert.ToDouble(rnt_annualgross.Value);
                    _obj_Smhr_Promotions.EMPPRO_ANNUALBASIC = Convert.ToDouble(rnt_annualbasic.Value);
                    _obj_Smhr_Promotions.EMP_SLAB_ID = Convert.ToInt32(rcmb_Slab.SelectedValue);
                    _obj_Smhr_Promotions_2.EMP_SLAB_ID = Convert.ToInt32(lblEmpSlabID.Text);
                    //31.5.2016
                    //_obj_Smhr_Promotions.EMPPRO_INCREMENTTYPE_ID = Convert.ToInt32(rcmb_IncrementType_Group.SelectedValue);
                    //31.5.2016
                    //_obj_Smhr_Promotions.EMP_INCRMENTMONTH = Convert.ToInt32(rcmb_IncrementMonth_group.SelectedValue);
                    _obj_Smhr_Promotions.OPERATION = operation.Insert_New;
                    status = BLL.set_EmpPromotion(_obj_Smhr_Promotions, _obj_Smhr_Promotions_2);
                }
            }
            if (status == true)
            {
                //if (Convert.ToDateTime(DateTime.Now) >= Convert.ToDateTime(Convert.ToDateTime(rdtp_DateofExecution.SelectedDate).ToShortDateString()))
                if (Convert.ToDateTime(DateTime.Now) >= Convert.ToDateTime(Convert.ToDateTime(rdtp_execdate_group.SelectedDate).ToShortDateString()))
                {
                    _obj_Smhr_Promotions_2.EMPPRO_STATUS = 1;
                    _obj_Smhr_Promotions.OPERATION = operation.Insert1;
                    if (BLL.set_EmpPromotion(_obj_Smhr_Promotions, _obj_Smhr_Promotions_2))
                    {
                    }
                }
                BLL.ShowMessage(this, "Employee Promotion Successfully Done");
            }
            ClearControls_Group();
            RM_PROMOTIONS.SelectedIndex = 0;
            LoadGrid();
            rg_Promotion.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_cancel_group_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls_Group();
            RM_PROMOTIONS.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void ClearControls_Group()
    {
        try
        {
            rcmb_BU_group.SelectedIndex = 0;
            rcmb_grade_group.SelectedIndex = 0;
            rcmb_levestruct_group.SelectedIndex = 0;
            rcmb_salstruct_group.SelectedIndex = 0;
            rcmb_reportemp_group.SelectedIndex = 0;
            rdtp_reptenddate_group.SelectedDate = null;
            rdtp_execdate_group.SelectedDate = null;
            rg_employees_group.Visible = false;
            btn_submit_group.Visible = false;
            rdb_choose.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Grade_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            /*rcmb_Slabs.Items.Clear();
            if (rcmb_Grade.SelectedIndex > 0)
            {
                rcmb_Slabs.DataValueField = "EMPLOYEEGRADE_SLAB_ID";    // "EMPLOYEEGRADE_SLAB_SRNO";
                rcmb_Slabs.DataTextField = "EMPLOYEEGRADE_SLAB_AMOUNT";
                rcmb_Slabs.DataSource = LoadSalarySlabs();
                rcmb_Slabs.DataBind();
                rcmb_Slabs.Items.Insert(0, new RadComboBoxItem { Text = "Select", Value = "0" });
            }*/


            SMHR_EMPLOYEEGRADE_SLAB _obj_SMHR_EMPLOYEEGRADE_SLAB = new SMHR_EMPLOYEEGRADE_SLAB();
            //rcmb_Slabs.Items.Clear();

            if (rcmb_Grade.SelectedIndex > 0)
            {
                rcmb_Slabs.Items.Clear();
                _obj_SMHR_EMPLOYEEGRADE_SLAB.OPERATION = operation.Get;
                _obj_SMHR_EMPLOYEEGRADE_SLAB.EMPLOYEEGRADE_SLAB_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_EMPLOYEEGRADE_SLAB.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID = Convert.ToInt32(rcmb_Grade.SelectedValue);
                _obj_SMHR_EMPLOYEEGRADE_SLAB.EMPLOYEEGRADE_SLAB_PERIOD_ID = Convert.ToInt32(rcmb_FinancialPeriod.SelectedValue);

                DataTable dtSlabs = LoadSalarySlabs1();

                if (dtSlabs.Rows.Count > 0)
                {
                    rcmb_Slabs.DataSource = dtSlabs;
                    rcmb_Slabs.DataTextField = "EMPLOYEEGRADE_SLAB_AMOUNT";
                    rcmb_Slabs.DataValueField = "EMPLOYEEGRADE_SLAB_ID";
                    rcmb_Slabs.DataBind();
                }
                rcmb_Slabs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
            else
            {
                rcmb_Slabs.SelectedIndex = 0;
                rtxt_Basic.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private DataTable LoadSalarySlabs1()
    {
        DataTable dt = new DataTable();
        try
        {
            SMHR_EMPLOYEEGRADE_SLAB _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE_SLAB();
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID = rcmb_Grade.SelectedValue != string.Empty ? Convert.ToInt32(rcmb_Grade.SelectedValue) : 0;
            _obj_Smhr_EmployeeGrade.OPERATION = operation.EmployeeSlabs;
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_PERIOD_ID = Convert.ToInt32(rcmb_FinancialPeriod.SelectedValue);

            dt = BLL.get_EmployeeGrades(_obj_Smhr_EmployeeGrade);


        }


        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
    }

    private DataTable LoadSalarySlabs()
    {
        DataSet ds = new DataSet();
        try
        {
            SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_ID = Convert.ToInt32(rcmb_Grade.SelectedValue);
            _obj_Smhr_EmployeeGrade.OPERATION = operation.EmployeeSlabs;
            _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            ds = BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return ds.Tables[0];
    }
    //protected void rtxt_GrossSalary_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (rtxt_GrossSalary.Value != 0)
    //        {
    //            if (rcmb_emptype.SelectedIndex <= 0)
    //            {
    //                BLL.ShowMessage(this, "Please Select Employee Type");
    //                rtxt_GrossSalary.Text = string.Empty;
    //                rtxt_GrossSalary.Focus();
    //                return;
    //            }
    //            if (rcmb_Desg.SelectedIndex <= 0 || rcmb_SalStruct.SelectedIndex <= 0)
    //            {
    //                BLL.ShowMessage(this, "Please Select Proper Information.");
    //                rtxt_GrossSalary.Text = string.Empty;
    //                return;
    //            }

    //            //TO GET EMPLOYEE DETAILS
    //            _obj_smhr_employee = new SMHR_EMPLOYEE();
    //            _obj_smhr_employee.OPERATION = operation.Select;
    //            _obj_smhr_employee.EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedItem.Value);
    //            //dt_Details = new DataTable();
    //            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);

    //            if (dt_Details.Rows.Count > 0)
    //            {
    //                if ((Convert.ToString(dt_Details.Rows[0]["EMP_EMPLOYEETYPE"]) == "Permanent and Pensionable") || (Convert.ToString(rcmb_emptype.SelectedItem.Text) == "Permanent and Pensionable"))
    //                {
    //                    // for cil
    //                    _obj_smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
    //                    _obj_smhr_BusinessUnit.OPERATION = operation.Validate1;
    //                    _obj_smhr_BusinessUnit.BUSINESSUNIT_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
    //                    _obj_smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    DataTable dt_BusinessUnit = BLL.get_BusinessUnit(_obj_smhr_BusinessUnit);
    //                    float F_BasicPercent = Convert.ToSingle(dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"]);
    //                    //rtxt_Basic.Value = Convert.ToDouble(0.55 * (rtxt_GrossSalary.Value));
    //                    rtxt_Basic.Value = Convert.ToDouble((F_BasicPercent * (rtxt_GrossSalary.Value)) / 100);
    //                    lbl_GrossSalary.Text = rtxt_GrossSalary.Text;

    //                    //TO CALCULATE ANNUAL GROSS AND ANNUAL BASIC
    //                    SMHR_ORGANISATION _obj_SMHR_ORGANISATION = new SMHR_ORGANISATION();
    //                    _obj_SMHR_ORGANISATION.MODE = 2;
    //                    _obj_SMHR_ORGANISATION.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    DataTable dt_Organisation = BLL.get_Organisation(_obj_SMHR_ORGANISATION);
    //                    if (dt_Organisation.Rows.Count != 0)
    //                    {
    //                        if (Convert.ToString(dt_Organisation.Rows[0]["ORGANISATION_ANNUALPROCESS"]) != "")
    //                        {
    //                            if (Convert.ToString(dt_Organisation.Rows[0]["ORGANISATION_ANNUALPROCESS"]).ToUpper() == "TRUE")
    //                            {
    //                                SMHR_SALARYSTRUCT _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
    //                                _obj_smhr_salaryStruct.OPERATION = operation.Select;
    //                                _obj_smhr_salaryStruct.SALARYSTRUCT_ID = Convert.ToInt32(rcmb_SalStruct.SelectedItem.Value);
    //                                _obj_smhr_salaryStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                                DataTable dt_PeriodType = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
    //                                _obj_smhr_salaryStruct.SALARYSTRUCT_TYPE = Convert.ToInt32(dt_PeriodType.Rows[0]["SALARYSTRUCT_TYPE"]);
    //                                _obj_smhr_salaryStruct.OPERATION = operation.Validate;
    //                                DataTable dt_PeriodTypeName = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
    //                                if (dt_PeriodTypeName.Rows.Count != 0)
    //                                {
    //                                    if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "MONTHLY")
    //                                    {
    //                                        lbl_AnnualGross.Text = Convert.ToString(Convert.ToDouble(rtxt_GrossSalary.Text) * 12);
    //                                        double IAnnualGross = Convert.ToDouble(lbl_AnnualGross.Text);
    //                                        //int IBasic = (IGross * 55) / 100;
    //                                        double IAnnualBasic = (IAnnualGross * F_BasicPercent) / 100;
    //                                        lbl_AnnualBasic.Text = Convert.ToString(IAnnualBasic);
    //                                    }
    //                                    else if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "FORTNIGHT")
    //                                    {
    //                                        lbl_AnnualGross.Text = Convert.ToString(Convert.ToDouble(rtxt_GrossSalary.Text) * 26);
    //                                        double IAnnualGross = Convert.ToDouble(lbl_AnnualGross.Text);
    //                                        //int IBasic = (IGross * 55) / 100;
    //                                        double IAnnualBasic = (IAnnualGross * F_BasicPercent) / 100;
    //                                        lbl_AnnualBasic.Text = Convert.ToString(IAnnualBasic);
    //                                    }
    //                                }
    //                                getJobAnnual(rcmb_Desg.SelectedItem.Value);
    //                                if (lbl_AnnualGross.Text == string.Empty && lbl_AnnualBasic.Text == string.Empty)
    //                                {
    //                                    return;
    //                                }
    //                            }
    //                            else
    //                            {
    //                                lbl_AnnualBasic.Text = string.Empty;
    //                                lbl_AnnualGross.Text = string.Empty;
    //                                getJob(rcmb_Desg.SelectedItem.Value);
    //                                if (lbl_GrossSalary.Text == string.Empty)
    //                                {
    //                                    return;
    //                                }
    //                            }
    //                        }
    //                        else
    //                        {
    //                            lbl_AnnualBasic.Text = string.Empty;
    //                            lbl_AnnualGross.Text = string.Empty;
    //                            getJob(rcmb_Desg.SelectedItem.Value);
    //                            if (lbl_GrossSalary.Text == string.Empty)
    //                            {
    //                                return;
    //                            }
    //                        }
    //                    }
    //                }
    //                else
    //                {
    //                    rtxt_Basic.Value = Convert.ToDouble(rtxt_GrossSalary.Value);
    //                    lbl_GrossSalary.Text = rtxt_GrossSalary.Text;
    //                    //TO CALCULATE ANNUAL GROSS AND ANNUAL BASIC
    //                    SMHR_ORGANISATION _obj_SMHR_ORGANISATION = new SMHR_ORGANISATION();
    //                    _obj_SMHR_ORGANISATION.MODE = 2;
    //                    _obj_SMHR_ORGANISATION.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                    DataTable dt_Organisation = BLL.get_Organisation(_obj_SMHR_ORGANISATION);
    //                    if (dt_Organisation.Rows.Count != 0)
    //                    {
    //                        if (Convert.ToString(dt_Organisation.Rows[0]["ORGANISATION_ANNUALPROCESS"]) != "")
    //                        {
    //                            if (Convert.ToString(dt_Organisation.Rows[0]["ORGANISATION_ANNUALPROCESS"]).ToUpper() == "TRUE")
    //                            {
    //                                SMHR_SALARYSTRUCT _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
    //                                _obj_smhr_salaryStruct.OPERATION = operation.Select;
    //                                _obj_smhr_salaryStruct.SALARYSTRUCT_ID = Convert.ToInt32(rcmb_SalStruct.SelectedItem.Value);
    //                                _obj_smhr_salaryStruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //                                DataTable dt_PeriodType = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
    //                                _obj_smhr_salaryStruct.SALARYSTRUCT_TYPE = Convert.ToInt32(dt_PeriodType.Rows[0]["SALARYSTRUCT_TYPE"]);
    //                                _obj_smhr_salaryStruct.OPERATION = operation.Validate;
    //                                DataTable dt_PeriodTypeName = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
    //                                if (dt_PeriodTypeName.Rows.Count != 0)
    //                                {
    //                                    if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "MONTHLY")
    //                                    {
    //                                        lbl_AnnualGross.Text = Convert.ToString(Convert.ToDouble(rtxt_GrossSalary.Text) * 12);
    //                                        lbl_AnnualBasic.Text = Convert.ToString(lbl_AnnualGross.Text);
    //                                    }
    //                                    else if (Convert.ToString(dt_PeriodTypeName.Rows[0]["PERIODTYPE_NAME"]).ToUpper() == "FORTNIGHT")
    //                                    {
    //                                        lbl_AnnualGross.Text = Convert.ToString(Convert.ToDouble(rtxt_GrossSalary.Text) * 26);
    //                                        lbl_AnnualBasic.Text = Convert.ToString(lbl_AnnualGross.Text);
    //                                    }
    //                                }
    //                                getJobAnnual(rcmb_Desg.SelectedItem.Value);
    //                                if (lbl_AnnualGross.Text == string.Empty && lbl_AnnualBasic.Text == string.Empty)
    //                                {
    //                                    return;
    //                                }
    //                            }
    //                            else
    //                            {
    //                                lbl_AnnualBasic.Text = string.Empty;
    //                                lbl_AnnualGross.Text = string.Empty;
    //                                getJob(rcmb_Desg.SelectedItem.Value);
    //                                if (lbl_GrossSalary.Text == string.Empty)
    //                                {
    //                                    return;
    //                                }
    //                            }
    //                        }
    //                        else
    //                        {
    //                            lbl_AnnualBasic.Text = string.Empty;
    //                            lbl_AnnualGross.Text = string.Empty;
    //                            getJob(rcmb_Desg.SelectedItem.Value);
    //                            if (lbl_GrossSalary.Text == string.Empty)
    //                            {
    //                                return;
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }


    //}
    protected void rcmb_Slabs_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //rtxt_GrossSalary.Text = string.Empty;
            if (rcmb_Slabs.SelectedIndex > 0)
            {
                DataTable dtSlabs = BLL.GetEmployeeGradeSlab(Convert.ToInt32(rcmb_Slabs.SelectedValue));

                if (dtSlabs.Rows.Count > 0)
                    rtxt_Basic.Text = Convert.ToString(Math.Round((Convert.ToDecimal(dtSlabs.Rows[0]["EMPLOYEEGRADE_SLAB_AMOUNT"]) / 12), 2));
                else
                    rtxt_Basic.Text = string.Empty;

                //rtxt_GrossSalary.Text = rcmb_Slabs.Text;
                //Calculate_Basic();
            }
            else
                rtxt_Basic.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //private void Calculate_Basic()
    //{
    //    if (rtxt_GrossSalary.Text != string.Empty)
    //    {
    //        if (Convert.ToDouble(rtxt_GrossSalary.Text) >= 0)
    //        {

    //            //code for getting Basic percentage of Gross For the businessunit selected
    //            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
    //            _obj_smhr_businessunit.OPERATION = operation.Select;
    //            _obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
    //            _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            DataTable dt_BusinessUnit = BLL.get_BusinessUnit(_obj_smhr_businessunit);
    //            if ((dt_BusinessUnit.Rows.Count > 0) && (rcmb_Businessunit.SelectedValue != string.Empty))
    //            {
    //                _obj_smhr_businessunit.OPERATION = operation.Get_BULocalization;
    //                DataTable dtBuLocal = BLL.get_BusinessUnit(_obj_smhr_businessunit);
    //                if (dtBuLocal.Rows.Count > 0)
    //                {
    //                    float strSuperAnnuation = Convert.ToSingle(0.00);

    //                    if (dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"] != System.DBNull.Value)
    //                    {
    //                        float IBasicPercent = Convert.ToSingle(dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"]);

    //                        float emp_GrossSal = Convert.ToSingle(rtxt_GrossSalary.Text.Replace("'", "''"));
    //                        //float emp_BasicSal = (55 * emp_GrossSal) / 100;
    //                        float emp_BasicSal = (IBasicPercent * emp_GrossSal) / 100;
    //                        rtxt_Basic.Text = Convert.ToString(emp_BasicSal);
    //                        //if (ddl_Jobs.SelectedValue != "Select")
    //                        //{
    //                        //    if (!((Convert.ToDouble(rtxt_GrossSalary.Text) >= minsal) && (Convert.ToDouble(rtxt_GrossSalary.Text) <= maxsal)))
    //                        //    {
    //                        //        BLL.ShowMessage(this, "Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
    //                        //        rtxt_GrossSalary.Text = "";
    //                        //        rtxt_Basic.Text = "";
    //                        //        return;
    //                        //    }
    //                        //}
    //                    }
    //                    else
    //                    {
    //                        BLL.ShowMessage(this, "Basic Is Not Defined For The Businessunit:" + rcmb_Businessunit.SelectedItem.Text);
    //                        rtxt_GrossSalary.Text = "";
    //                        return;
    //                    }
    //                    //}
    //                }
    //            }
    //            else
    //            {
    //                BLL.ShowMessage(this, "Select Proper Businessunit");
    //                rtxt_GrossSalary.Text = "";
    //            }

    //        }
    //    }
    //    else
    //    {
    //        BLL.ShowMessage(this, "Gross Must be Greater Than Zero!");
    //        rtxt_Basic.Text = "";
    //        //rtxt_GrossSalary.Focus();
    //    }
    //}
    protected void rdtp_DateofExecution_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            if (rcmb_Employee.SelectedValue == string.Empty)
            {
                BLL.ShowMessage(this, "Please Select Employee");
                return;
            }
            if (rcmb_FinancialPeriod.SelectedValue == string.Empty)
            {
                BLL.ShowMessage(this, "Please Select Financial Period");
                return;
            }
            if (rdtp_DateofExecution.SelectedDate != null && rcmb_Grade.SelectedValue != string.Empty)
            {
                _obj_Smhr_Promotions = new SMHR_EMPPROMOTIONS();
                _obj_Smhr_Promotions_2 = new SMHR_EMPPROMOTIONS();
                _obj_Smhr_Promotions.OPERATION = operation.CHECKSLABPERIODS;
                _obj_Smhr_Promotions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Promotions.EMPPRO_GRADE = Convert.ToInt32(rcmb_Grade.SelectedValue);
                _obj_Smhr_Promotions.VALIDATEPERIOD = Convert.ToDateTime(rdtp_DateofExecution.SelectedDate);

                bool status = BLL.set_EmpPromotion(_obj_Smhr_Promotions, _obj_Smhr_Promotions_2);
                if (status == false)
                {
                    BLL.ShowMessage(this, "Slabs Not Finalized For Selected Grade");
                    rdtp_DateofExecution.SelectedDate = null;
                    return;
                }
            }
            if (rdtp_DateofExecution.SelectedDate != null)
            {
                SMHR_EMPPROMOTIONS _obj_Smhr_Promotions = new SMHR_EMPPROMOTIONS();
                _obj_Smhr_Promotions_2 = new SMHR_EMPPROMOTIONS();
                _obj_Smhr_Promotions.OPERATION = operation.Check1;
                _obj_Smhr_Promotions.EMPPRO_EMPID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                _obj_Smhr_Promotions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Promotions.EMPPRO_PERIOD = Convert.ToInt32(rcmb_FinancialPeriod.SelectedValue);
                _obj_Smhr_Promotions.EMPPRO_DATEOFPROMOTION = Convert.ToDateTime(rdtp_DateofExecution.SelectedDate);
                //DataTable DT = new DataTable();
                bool status = BLL.set_EmpPromotion(_obj_Smhr_Promotions, _obj_Smhr_Promotions_2);

                if (status == false)
                {

                    BLL.ShowMessage(this, "Payroll already processed for the selected execution date, you may roll back and choose the execution date");
                    rdtp_DateofExecution.SelectedDate = null;
                    return;
                }
            }
            if (rdtp_DateofExecution.SelectedDate != null)
            {
                SMHR_EMPPROMOTIONS _obj_Smhr_Promotions = new SMHR_EMPPROMOTIONS();
                _obj_Smhr_Promotions_2 = new SMHR_EMPPROMOTIONS();
                _obj_Smhr_Promotions.OPERATION = operation.Check;
                _obj_Smhr_Promotions.EMPPRO_EMPID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                _obj_Smhr_Promotions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Promotions.EMPPRO_PERIOD = Convert.ToInt32(rcmb_FinancialPeriod.SelectedValue);
                _obj_Smhr_Promotions.EMPPRO_DATEOFPROMOTION = Convert.ToDateTime(rdtp_DateofExecution.SelectedDate);
                //DataTable DT = new DataTable();
                bool status = BLL.set_EmpPromotion(_obj_Smhr_Promotions, _obj_Smhr_Promotions_2);

                if (status == false)
                {

                    BLL.ShowMessage(this, "Payroll already processed and approved, you cannot select this execution date");
                    rdtp_DateofExecution.SelectedDate = null;
                    return;
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public DataTable LoadGridSalarySlabs()
    {
        DataSet ds = new DataSet();
        try
        {
            SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_ID = rcmb_grade_group.SelectedValue != "0" ? Convert.ToInt32(rcmb_grade_group.SelectedValue) : 0;
            _obj_Smhr_EmployeeGrade.OPERATION = operation.EmployeeSlabs;
            _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            ds = BLL.get_EmployeeGrade(_obj_Smhr_EmployeeGrade);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return ds.Tables[0];
    }
    protected void rcmb_GridSlabs_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            RadComboBox rcmb_GridSlabs = o as RadComboBox;
            RadNumericTextBox rtxt_GrossSalary = rcmb_GridSlabs.NamingContainer.FindControl("rtxt_gross_group") as RadNumericTextBox;
            RadNumericTextBox rtxt_basic_group = rcmb_GridSlabs.NamingContainer.FindControl("rtxt_basic_group") as RadNumericTextBox;

            if (rcmb_GridSlabs.SelectedIndex > 0)
            {
                rtxt_GrossSalary.Text = rcmb_GridSlabs.Text;
                rtxt_basic_group.Text = rcmb_GridSlabs.Text;
                //Calculate_GridBasic(rtxt_GrossSalary, rtxt_basic_group);
            }
            else
            {
                rtxt_GrossSalary.Text = string.Empty;
                rtxt_basic_group.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void Calculate_GridBasic(RadNumericTextBox rtxt_GrossSalary, RadNumericTextBox rtxt_Basic)
    {
        try
        {
            if (rtxt_GrossSalary.Text != string.Empty)
            {
                if (Convert.ToDouble(rtxt_GrossSalary.Text) >= 0)
                {

                    //code for getting Basic percentage of Gross For the businessunit selected
                    _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
                    _obj_smhr_businessunit.OPERATION = operation.Select;
                    _obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BU_group.SelectedValue);
                    _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_BusinessUnit = BLL.get_BusinessUnit(_obj_smhr_businessunit);
                    if ((dt_BusinessUnit.Rows.Count > 0) && (rcmb_BU_group.SelectedValue != string.Empty))
                    {
                        _obj_smhr_businessunit.OPERATION = operation.Get_BULocalization;
                        DataTable dtBuLocal = BLL.get_BusinessUnit(_obj_smhr_businessunit);
                        if (dtBuLocal.Rows.Count > 0)
                        {
                            float strSuperAnnuation = Convert.ToSingle(0.00);

                            if (dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"] != System.DBNull.Value)
                            {
                                float IBasicPercent = Convert.ToSingle(dt_BusinessUnit.Rows[0]["BUSINESSUNIT_BASICPERCENT"]);

                                float emp_GrossSal = Convert.ToSingle(rtxt_GrossSalary.Text.Replace("'", "''"));
                                //float emp_BasicSal = (55 * emp_GrossSal) / 100;
                                float emp_BasicSal = (IBasicPercent * emp_GrossSal) / 100;
                                rtxt_Basic.Text = Convert.ToString(emp_BasicSal);
                                //if (ddl_Jobs.SelectedValue != "Select")
                                //{
                                //    if (!((Convert.ToDouble(rtxt_GrossSalary.Text) >= minsal) && (Convert.ToDouble(rtxt_GrossSalary.Text) <= maxsal)))
                                //    {
                                //        BLL.ShowMessage(this, "Gross Must be in the range of Selected Job Min and Max Salary:" + minsal + "-" + maxsal);
                                //        rtxt_GrossSalary.Text = "";
                                //        rtxt_Basic.Text = "";
                                //        return;
                                //    }
                                //}
                            }
                            else
                            {
                                BLL.ShowMessage(this, "Basic Is Not Defined For The Businessunit:" + rcmb_BU_group.SelectedItem.Text);
                                rtxt_GrossSalary.Text = "";
                                return;
                            }
                            //}
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Select Proper Businessunit");
                        rtxt_GrossSalary.Text = "";
                    }

                }
            }
            else
            {
                BLL.ShowMessage(this, "Gross Must be Greater Than Zero!");
                rtxt_Basic.Text = "";
                rtxt_GrossSalary.Focus();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rdtp_execdate_group_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            if (rdtp_execdate_group.SelectedDate != null && rcmb_grade_group.SelectedValue != string.Empty)
            {
                _obj_Smhr_Promotions = new SMHR_EMPPROMOTIONS();
                _obj_Smhr_Promotions_2 = new SMHR_EMPPROMOTIONS();
                _obj_Smhr_Promotions.OPERATION = operation.CHECKSLABPERIODS;
                _obj_Smhr_Promotions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Promotions.EMPPRO_GRADE = Convert.ToInt32(rcmb_grade_group.SelectedValue);
                _obj_Smhr_Promotions.VALIDATEPERIOD = Convert.ToDateTime(rdtp_execdate_group.SelectedDate);

                bool status = BLL.set_EmpPromotion(_obj_Smhr_Promotions, _obj_Smhr_Promotions_2);
                if (status == false)
                {
                    BLL.ShowMessage(this, "Slabs Not Finalized For Selected Grade");
                    rdtp_execdate_group.SelectedDate = null;
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Job_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadPositions();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadPositions()
    {
        try
        {
            if (Session["ORG_ID"] != "")
            {
                if (rcmb_Businessunit.SelectedIndex > 0 && rcmb_Job.SelectedValue != string.Empty)
                {
                    rcmb_Desg.Items.Clear();
                    SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                    _obj_smhr_positions.OPERATION = operation.JOBPOSITIONS;
                    _obj_smhr_positions.POSITIONS_JOBSID = Convert.ToInt32(rcmb_Job.SelectedValue);
                    _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtPos = BLL.get_Positions(_obj_smhr_positions);
                    rcmb_Desg.DataSource = dtPos;
                    rcmb_Desg.DataTextField = "POSITIONS_CODE";
                    rcmb_Desg.DataValueField = "POSITIONS_ID";
                    rcmb_Desg.DataBind();
                    rcmb_Desg.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                }
                else
                {
                    rcmb_Desg.Items.Clear();
                    rcmb_Desg.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                    //rcmb_Grade.Items.Clear();
                    //rcmb_Grade.Text = string.Empty;
                    //rcmb_Slabs.Items.Clear();
                    //rcmb_Slabs.Text = string.Empty;
                }

                //if (rcmb_BU.SelectedIndex > 0)
                //{
                //    SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                //    _obj_smhr_positions.OPERATION = operation.Select;
                //    _obj_smhr_positions.JOBLOC_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BU.SelectedValue);
                //    _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    DataTable dtPos = BLL.get_BUPositions(_obj_smhr_positions);
                //    rcmb_Designation.DataSource = dtPos;
                //    rcmb_Designation.DataTextField = "POSITIONS_CODE";
                //    rcmb_Designation.DataValueField = "POSITIONS_ID";
                //    rcmb_Designation.DataBind();
                //    rcmb_Designation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));                   
                //}
                //else
                //{
                //    BLL.ShowMessage(this, "Please Select Business Unit");
                //    return;
                //}
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //31.5.2016
    /*protected void rcmb_IncrementType_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_IncrementType.SelectedIndex > 0 && rcmb_IncrementType.SelectedItem.Text == "Appointment")
            {
                //To check if previous designationID is same as current DesignationID
                if (lbl_Desg_ID.Text != string.Empty)
                {
                    if (lbl_Desg_ID.Text == rcmb_Desg.SelectedValue)
                    {
                        BLL.ShowMessage(this, "You cannot appoint employee to the same position");
                        rcmb_IncrementType.ClearSelection();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PromotionHikes", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }*/

    private void LoadPeriod()
    {
        try
        {
            rcmb_FinancialPeriod.Items.Clear();
            SMHR_PERIOD PRD = new SMHR_PERIOD();
            PRD.OPERATION = operation.PERIOD;
            PRD.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = new DataTable();
            DT = BLL.GetEmployeePeriod(PRD);
            //rcmb_Period.DataSource = BLL.GetEmployeePeriod(PRD);
            if (DT.Rows.Count > 0)
            {
                rcmb_FinancialPeriod.DataSource = DT;
                rcmb_FinancialPeriod.DataTextField = "PERIOD_NAME";
                rcmb_FinancialPeriod.DataValueField = "PERIOD_ID";
                rcmb_FinancialPeriod.DataBind();
            }
            rcmb_FinancialPeriod.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmemployeeadd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    /*protected void rcmb_FinancialPeriod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //if (rcmb_BU_group.SelectedIndex > 0)
        //{
            if (rcmb_FinancialPeriod.SelectedIndex > 0)
            {
                SMHR_PERIODDTL _obj_Smhr_Prddtl = new SMHR_PERIODDTL();
                _obj_Smhr_Prddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(rcmb_FinancialPeriod.SelectedValue);
                _obj_Smhr_Prddtl.OPERATION = operation.Select;
                DataTable dt_Details = new DataTable();
                dt_Details = BLL.get_PeriodDetails(_obj_Smhr_Prddtl);
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_Perioddtls.DataSource = dt_Details;
                    rcmb_Perioddtls.DataValueField = "PRDDTL_ID";
                    rcmb_Perioddtls.DataTextField = "PRDDTL_NAME";
                    rcmb_Perioddtls.DataBind();
                    rcmb_Perioddtls.Items.Insert(0, new RadComboBoxItem("Select"));
                   
                }
            }
            else
            {
                rcmb_Perioddtls.Items.Clear();
                rcmb_Perioddtls.Items.Insert(0, new RadComboBoxItem("", ""));
               
            }
       // }
    }*/
    protected void rcmb_FinancialPeriod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (rcmb_FinancialPeriod.SelectedIndex > 0)
        {
            rcmb_Grade.Items.Clear();
            rcmb_Slabs.Items.Clear();
            SMHR_EMPLOYEEGRADE_SLAB _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE_SLAB();
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID = Convert.ToInt32(rcmb_Grade.SelectedItem);
            _obj_Smhr_EmployeeGrade.OPERATION = operation.Employeegrades;
            _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_SLAB_PERIOD_ID = Convert.ToInt32(rcmb_FinancialPeriod.SelectedValue);

            DataTable dt = new DataTable();
            dt = BLL.get_EmployeeGrades(_obj_Smhr_EmployeeGrade);

            if (dt.Rows.Count > 0)
            {
                rcmb_Grade.DataSource = dt;
                rcmb_Grade.DataTextField = "EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_CODE";
                rcmb_Grade.DataValueField = "EMPLOYEEGRADE_SLAB_EMPLOYEEGRADE_ID";
                rcmb_Grade.DataBind();
            }
            rcmb_Grade.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            rcmb_Grade.Enabled = true;
            rcmb_Slabs.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            rcmb_Slabs.Enabled = true;
        }
        else
        {
            rcmb_Grade.SelectedIndex = 0;
            rcmb_Slabs.SelectedIndex = 0;
            rtxt_Basic.Text = string.Empty;
        }
    }
    protected void rdp_ContractEnd_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        if (rdp_ContractStart.SelectedDate != null || rdp_ContractEnd.SelectedDate != null)
        {
            if (rdp_ContractStart.SelectedDate > rdp_ContractEnd.SelectedDate)
            {
                BLL.ShowMessage(this, "Contract End Date Should Not Less Than Contract Start Date");
                rdp_ContractEnd.Focus();
                rdp_ContractEnd.SelectedDate = null;
                return;

            }
        }
    }
    protected void rdp_ContractStart_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        if (rdp_ContractStart.SelectedDate != null || rdp_ContractEnd.SelectedDate != null)
        {
            if (rdp_ContractEnd.SelectedDate < rdp_ContractStart.SelectedDate)
            {
                BLL.ShowMessage(this, "Contract Start Date Should Less Than Contract End Date");
                rdp_ContractStart.Focus();
                rdp_ContractStart.SelectedDate = null;
                return;

            }
        }

    }
}