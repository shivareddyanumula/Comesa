using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;
using System.Text;
using System.Collections;



public partial class Selfservice_frmOverTimeCalc : System.Web.UI.Page
{
    SMHR_EMPOTTRANS _obj_smhr_ottrans = new SMHR_EMPOTTRANS();
    SMHR_EMPLOYEEGRADE _obj_smhr_grade = new SMHR_EMPLOYEEGRADE();
    static int otid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //code for security privilage
                /*Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Over Time Calculations Employee");
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
                    Rg_OverTime.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                }*/

                if (Convert.ToInt32(Session["EMP_ID"]) == 0)
                    Response.Redirect("~/Masters/Default.aspx?ctrl=SS", false);
                else
                {
                    LoadGrid();
                    Rg_OverTime.DataBind();
                }


            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmOverTimeCalc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_OverTime_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmOverTimeCalc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //if (rcmb_BusinessUnit.SelectedIndex > 0)
        //{
        //    //loademployee();
        //}
        //else
        //{
        //    BLL.ShowMessage(this, "Please select Businessunit");
        //    rcmb_BusinessUnit.Focus();
        //    return;
        //}
    }
    private void LoadGrid()
    {
        try
        {
            //if (Convert.ToInt32(Session["EMP_ID"]) == 0)
            _obj_smhr_ottrans = new SMHR_EMPOTTRANS();
            _obj_smhr_ottrans.MODE = 0;
            _obj_smhr_ottrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_ottrans.EMPOTTRANS_EMPID = Convert.ToInt32(Session["EMP_ID"]);
            DataTable dt_Load = new DataTable();
            dt_Load = BLL.calculate_OT(_obj_smhr_ottrans);
            Rg_OverTime.DataSource = dt_Load;
            
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmOverTimeCalc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Employee_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Employee.SelectedIndex > 0)
            {
                int empID = Convert.ToInt32(rcmb_Employee.SelectedValue);

                SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.Select;
                _obj_smhr_employee.EMP_ID = empID;
                _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);


                DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);
                if (dt_Details.Rows.Count > 0)
                {
                    LoadBusinessUnits();
                   
                }
                rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_BUSINESSUNIT_ID"]));


            }
            //else
            //{
            //    BLL.ShowMessage(this, "Please select Employee");
            //    rcmb_Employee.Focus();
            //    return;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmOverTimeCalc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rdtp_OTDt_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            if (rdtp_OTDt.SelectedDate != null)
            {

            }
            else
            {
                BLL.ShowMessage(this, "Please select Date of OverTime");
                rdtp_OTDt.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmOverTimeCalc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            decimal actHrs = 0, actMins = 0;

            if (rtbActHrs.Text == string.Empty)
                rtbActHrs.Text = actHrs.ToString();
            else
                actHrs = Convert.ToDecimal(rtbActHrs.Text);

            if (rtbActMins.Text == string.Empty)
                rtbActMins.Text = actMins.ToString();
            else
                actMins = Convert.ToDecimal(rtbActMins.Text);

            decimal OTHRS = 0, OTMINS = 0;
            if (rtbOTHrs.Text == string.Empty)
                rtbOTHrs.Text = OTHRS.ToString();
            else
                OTHRS = Convert.ToDecimal(rtbOTHrs.Text);

            if (rtbOTMins.Text == string.Empty)
                rtbOTMins.Text = OTMINS.ToString();
            else
                OTMINS = Convert.ToDecimal(rtbOTMins.Text);


            _obj_smhr_ottrans = new SMHR_EMPOTTRANS();
            _obj_smhr_ottrans.EMPOTTRANS_EMPID = Convert.ToInt32(rcmb_Employee.SelectedValue);
            _obj_smhr_ottrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_ottrans.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            //_obj_smhr_ottrans.OTCALC_EMPCODE = rntb_code.Text;
            _obj_smhr_ottrans.EMPOTTRANS_DATE = Convert.ToDateTime(rdtp_OTDt.SelectedDate);
            /*_obj_smhr_ottrans.OTCALC_ACTUALHOURS = Convert.ToInt32((Convert.ToInt32(rtbOTHrs.Text) * 60) + Convert.ToInt32(rntb_Mins.Text));
            _obj_smhr_ottrans.EMPOTTRANS_HOURS = Convert.ToInt32((Convert.ToInt32(rtbOTHrs.Text) * 60) + Convert.ToInt32(rtbOTMins.Text));*/
            _obj_smhr_ottrans.OTCALC_ACTUALHOURS = Convert.ToInt32((actHrs * 60) + actMins);
            _obj_smhr_ottrans.EMPOTTRANS_HOURS = Convert.ToInt32((OTHRS * 60) + OTMINS);
            /*_obj_smhr_ottrans.EMPOTTRANS_HOURS = Convert.ToDecimal(rtbOTHrs.Text);
            _obj_smhr_ottrans.EMPOTTRANS_HOURS = Convert.ToDecimal(rtbOTMins.Text);
            _obj_smhr_ottrans.OTCALC_ACTUALHOURS = Convert.ToInt32(rtbOTHrs.Text);
            _obj_smhr_ottrans.OTCALC_ACTUALHOURS = Convert.ToInt32(rntb_Mins.Text);*/
            TimeSpan fromtime = new TimeSpan(Convert.ToDateTime(rdp_fromtime.SelectedDate).Hour, Convert.ToDateTime(rdp_fromtime.SelectedDate).Minute, Convert.ToDateTime(rdp_fromtime.SelectedDate).Second);
            _obj_smhr_ottrans.OTCALC_FROMTIME = fromtime;
            TimeSpan totime = new TimeSpan(Convert.ToDateTime(rdp_totime.SelectedDate).Hour, Convert.ToDateTime(rdp_totime.SelectedDate).Minute, Convert.ToDateTime(rdp_totime.SelectedDate).Second);
            _obj_smhr_ottrans.OTCALC_TOTIME = totime;
            _obj_smhr_ottrans.OTCALC_COMMENTS = rtxt_Comments.Text;
            _obj_smhr_ottrans.CREATEDBY = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_ottrans.LASTMDFBY = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_ottrans.EMPOTTRANS_STATUS = 0;
            //  _obj_smhr_ottrans.OPERATION = operation.checkOThours;
            //DataTable checkhours = BLL.Checkhourexceed(_obj_smhr_ottrans.EMPOTTRANS_EMPID, _obj_smhr_ottrans.EMPOTTRANS_DATE);



            _obj_smhr_ottrans.OPERATION = operation.Insert;
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SUBMIT":
                    bool status = BLL.SetOT(_obj_smhr_ottrans);

                    if (status == true)
                        BLL.ShowMessage(this, "Information Saved successfully");
                    else
                        BLL.ShowMessage(this, "Information not Saved");

                    break;
                case "BTN_UPDATE":

                    _obj_smhr_ottrans.OPERATION = operation.Update;
                    _obj_smhr_ottrans.EMPOTTRANS_ID = otid;
                    if (BLL.SetOT(_obj_smhr_ottrans))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");

                    break;
                default:
                    break;
            }
            Rm_OverTime_page.SelectedIndex = 0;
            LoadGrid();
            Rg_OverTime.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmOverTimeCalc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {


            Rm_OverTime_page.SelectedIndex = 0;
            clearControls();
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmOverTimeCalc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void clearControls()
    {
        try
        {
            rcmb_BusinessUnit.SelectedIndex = rcmb_Employee.SelectedIndex = 0;
            // rntb_code.Text = "";
            rdtp_OTDt.SelectedDate = null;
            rtbActHrs.Text = rtbActMins.Text = rtbOTHrs.Text = rtbOTMins.Text = string.Empty;
            //rtbOTHrs.Text = "";
            //rtbActHrs.Text = rtbActMins.Text = string.Empty;
            //rtbOTHrs.Text = rtbOTMins.Text = "";
            rtxt_Comments.Text = "";
            rdp_fromtime.SelectedDate = null;
            rdp_totime.SelectedDate = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmOverTimeCalc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rdtp_OTDt.MinDate = DateTime.Now.AddMonths(-1).AddDays(-DateTime.Now.Day + 1);
            rdtp_OTDt.MaxDate = DateTime.Now.AddDays(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) - DateTime.Now.Day);
            rdtp_OTDt.MaxDate = DateTime.Today;
            SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
            SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();

            bool empGradeStatus = false;

            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

            DataTable dtGetEmp = BLL.get_Employee(_obj_smhr_employee);

            if (dtGetEmp.Rows.Count > 0 && Convert.ToString(dtGetEmp.Rows[0]["EMP_GRADE"]) != string.Empty)
            {
                _obj_Smhr_EmployeeGrade.OPERATION = operation.Select1;
                _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_EmployeeGrade.EMPLOYEEGRADE_ID = Convert.ToInt32(dtGetEmp.Rows[0]["EMP_GRADE"]);

                DataTable dtGetEmpGradeOTStatus = BLL.GetEmployeeGrade(_obj_Smhr_EmployeeGrade);

                if (dtGetEmpGradeOTStatus.Rows.Count > 0 && Convert.ToString(dtGetEmpGradeOTStatus.Rows[0]["EMPLOYEEGRADE_OT_STATUS"]) != string.Empty)
                {
                    if (Convert.ToBoolean(dtGetEmpGradeOTStatus.Rows[0]["EMPLOYEEGRADE_OT_STATUS"]) == true)
                        empGradeStatus = true;
                    else
                        empGradeStatus = false;
                }

            }
            else
            {
                BLL.ShowMessage(this, "you are not eligible for overtime");
                return;
            }
            if (empGradeStatus == true)
            {
                Rm_OverTime_page.SelectedIndex = 1;
                // Rp_OverTime_ViewMain.Selected = false;
                // RPV_OT.Selected = true;
                btn_Update.Visible = false;
                btn_Submit.Visible = true;
                btn_Cancel.Visible = true;
                LoadEmployees();
                //if (rtbOTHrs.Text!=string.Empty)
                //{
                //    rtbOTHrs.Enabled = false;
                //}
                //else
                //    rtbOTHrs.Enabled = true;

                clearControls();
                // rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));
                rcmb_Employee_SelectedIndexChanged(null, null);

            }
            else
            {
                BLL.ShowMessage(this, "you are not eligible for overtime");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmOverTimeCalc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadCombos()
    {
        try
        {

            SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BusinessUnit.DataSource = dt_BUDetails;
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));


            SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();

            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_employee.EMP_LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dtEmp = BLL.get_Employee(_obj_smhr_employee);

            rcmb_Employee.DataSource = dtEmp;
            rcmb_Employee.DataTextField = "EMP_NAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));



        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmOverTimeCalc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadBusinessUnits()
    {
        try
        {


            SMHR_LOGININFO _obj_SMHR_LOGININFO = new SMHR_LOGININFO();

            _obj_SMHR_LOGININFO.OPERATION = operation.Select;
            _obj_SMHR_LOGININFO.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dtBU = BLL.get_Sup_BusinessUnit(_obj_SMHR_LOGININFO);

            rcmb_BusinessUnit.DataSource = dtBU;
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataBind();

            rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmOverTimeCalc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadEmployees()
    {
        try
        {
            SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();

            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_employee.EMP_LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            //_obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            DataTable dtEmp = BLL.get_Employee(_obj_smhr_employee);

            rcmb_Employee.DataSource = dtEmp;
            rcmb_Employee.DataTextField = "EMP_NAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmOverTimeCalc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    /*protected void rntb_Hours_TextChanged(object sender, EventArgs e)
    {
        try
        {
            decimal hrs = 0, mins = 0, val = 0, final = 0;
            string weekDay = string.Empty;

            if (rdtp_OTDt.SelectedDate != null)
            {
                weekDay = Convert.ToDateTime(rdtp_OTDt.SelectedDate).DayOfWeek.ToString();

                if (weekDay == "Saturday" || weekDay == "Sunday")
                    val = 2;
                else
                    val = Convert.ToDecimal(1.5);

                if (rtbOTHrs.Text != string.Empty || rntb_Mins.Text != string.Empty)
                {
                    if (rtbOTHrs.Text != string.Empty)
                        hrs = Convert.ToDecimal(rtbOTHrs.Text) * 60;      //to convert hours into minutes
                    if (rntb_Mins.Text != string.Empty)
                        mins = Convert.ToDecimal(rntb_Mins.Text);

                    final = (hrs + mins) * val;

                    if (final > 0)
                    {
                        rtbOTHrs.Text = Convert.ToString(final / 60).Substring(0, 2);
                        rtbOTMins.Text = Convert.ToString(final % 60);
                    }
                }
                else
                {
                    if (rtbOTHrs.Text != string.Empty && rntb_Mins.Text != string.Empty)
                        rtbOTHrs.Text = rntb_Mins.Text = rtbOTHrs.Text = rtbOTMins.Text = string.Empty;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please select Date of Over Time before entering Actual hours");
                rtbOTHrs.Text = rntb_Mins.Text = rtbOTHrs.Text = rtbOTMins.Text = string.Empty;
                rdtp_OTDt.Focus();
                return;
            }
        }
        catch (Exception ex)
        {            
            throw ex;
        }
    }*/
    protected void rtbActHrs_TextChanged(object sender, EventArgs e)
    {
        timecalculate();
    }
    protected void lbtn_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {


            //clearControls();
            btn_Submit.Visible = false;
            btn_Update.Visible = true;
            btn_Cancel.Visible = true;
            LoadEmployees();
            LoadBusinessUnits();
            otid = Convert.ToInt32(e.CommandArgument);

            SMHR_EMPOTTRANS _obj_smhr_ottrans = new SMHR_EMPOTTRANS();
            _obj_smhr_ottrans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_ottrans.EMPOTTRANS_ID = otid;
            _obj_smhr_ottrans.MODE = 1;
            _obj_smhr_ottrans.OPERATION = operation.Select;
            DataTable dt = BLL.calculate_OT(_obj_smhr_ottrans);
            if (dt.Rows.Count > 0)
            {
                rcmb_Employee.SelectedIndex = rcmb_Employee.FindItemIndexByValue(dt.Rows[0]["OTCALC_EMPID"].ToString());
                rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.FindItemIndexByValue(dt.Rows[0]["OTCALC_BUID"].ToString());            
                if (!string.IsNullOrEmpty(dt.Rows[0]["OTCALC_DATE"].ToString()))
                {
                    DateTime dts;
                    DateTime.TryParse(dt.Rows[0]["OTCALC_DATE"].ToString(), out dts);
                    rdtp_OTDt.SelectedDate = dts;
                    //Convert.ToDateTime((Convert.ToDateTime(dt.Rows[0]["OTCALC_DATE"].ToString()).ToString("dd-MMM-yyyy")));
                }

                // rdtp_OTDt.SelectedDate = DateTime.Today + new TimeSpan(((System.TimeSpan)((dt.Rows[0]["OTCALC_DATE"]))).Hours, ((System.TimeSpan)((dt.Rows[0]["OTCALC_DATE"]))).Minutes, ((System.TimeSpan)((dt.Rows[0]["OTCALC_DATE"]))).Seconds);
                rtbActHrs.Text = Convert.ToString(Convert.ToInt32(Convert.ToDecimal(dt.Rows[0]["OTCALC_ACTUALHOURS"]) / 60));
                rtbActMins.Text = Convert.ToString(Convert.ToInt32(Convert.ToDecimal(dt.Rows[0]["OTCALC_ACTUALHOURS"]) % 60));
                rtbOTHrs.Text = Convert.ToString(Convert.ToInt32(Convert.ToDecimal(dt.Rows[0]["OTCALC_WORKINGHOURS"]) / 60));
                rtbOTMins.Text = Convert.ToString(Convert.ToInt32(Convert.ToDecimal(dt.Rows[0]["OTCALC_WORKINGHOURS"]) % 60));
                rtxt_Comments.Text = Convert.ToString(dt.Rows[0]["OTCALC_COMMENTS"]);
                //rdp_fromtime.SelectedDate = Convert.ToDateTime(dt.Rows[0]["OTCALC_FROMTIME"]);
                //rdp_totime.SelectedDate = Convert.ToDateTime(dt.Rows[0]["OTCALC_TOTIME"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["OTCALC_FROMTIME"].ToString()))
                    rdp_fromtime.SelectedDate = DateTime.Today + new TimeSpan(((System.TimeSpan)((dt.Rows[0]["OTCALC_FROMTIME"]))).Hours, ((System.TimeSpan)((dt.Rows[0]["OTCALC_FROMTIME"]))).Minutes, ((System.TimeSpan)((dt.Rows[0]["OTCALC_FROMTIME"]))).Seconds);
                if (!string.IsNullOrEmpty(dt.Rows[0]["OTCALC_TOTIME"].ToString()))
                    rdp_totime.SelectedDate = DateTime.Today + new TimeSpan(((System.TimeSpan)((dt.Rows[0]["OTCALC_TOTIME"]))).Hours, ((System.TimeSpan)((dt.Rows[0]["OTCALC_TOTIME"]))).Minutes, ((System.TimeSpan)((dt.Rows[0]["OTCALC_TOTIME"]))).Seconds);
                if (Convert.ToInt32(dt.Rows[0]["OTCALC_STATUS"]) != 0)
                    btn_Update.Visible = false;
                else
                    btn_Update.Visible = true;
            }
            Rm_OverTime_page.SelectedIndex = 1;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmOverTimeCalc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    protected void rdp_fromtime_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            rdp_totime.SelectedDate = null;
            DateTime date1 = System.Convert.ToDateTime(rdp_fromtime.SelectedDate);
            DateTime date2 = System.Convert.ToDateTime(rdp_totime.SelectedDate);
            // rdp_totime.TimeView.StartTime = new TimeSpan(date1.Hour, date1.Minute, date1.Second);

            loadtimer(date1, date2);
            timecalculate();

        }
        catch (Exception ex)
        {

            throw;
        }
    }

    protected void rdp_totime_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            DateTime date1 = System.Convert.ToDateTime(rdp_fromtime.SelectedDate);
            DateTime date2 = System.Convert.ToDateTime(rdp_totime.SelectedDate);          
            loadtimer(date1, date2);
            timecalculate();
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    private void loadtimer(DateTime date1, DateTime date2)
    {
        try
        {
            if (date2.ToString() != "01/01/0001 12:00:00 AM")
            {
                TimeSpan ts = new TimeSpan();
                TimeSpan t1 = new TimeSpan(date1.Hour, date1.Minute, date1.Second);
                TimeSpan t2 = new TimeSpan(date2.Hour, date2.Minute, date2.Second);
                if (t2 < t1)
                {
                    BLL.ShowMessage(this, "To time should not be less than from time");
                    rdp_totime.SelectedDate = null;
                    return;
                }
                if (t1 > t2)
                {
                    ts = new TimeSpan(24 - t1.Hours, 0 - t1.Minutes, 0 - t1.Seconds) + t2;
                }
                else
                {
                    ts = t2 - t1;
                }

                rtbActHrs.Text = ts.Hours.ToString();
                rtbActMins.Text = t2.Hours > 12 ? "0" : ts.Minutes.ToString();
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    private void timecalculate()
    {
        try
        {
            decimal hrs = 0, mins = 0, val = 0, final = 0, hldyval = 0, hldyfinal = 0;
            string weekDay = string.Empty;
            string holiday = string.Empty;
            int maxHrs = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["maxHrs"]);
            int maxMins = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["maxMins"]);

            SMHR_HOLIDAY _obj_Smhr_Holiday = new SMHR_HOLIDAY();
            _obj_Smhr_Holiday.OPERATION = operation.chkholiday;
            _obj_Smhr_Holiday.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Holiday.HOLMST_BUSINESSUNITID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            _obj_Smhr_Holiday.HOLMST_DATE = Convert.ToDateTime(rdtp_OTDt.SelectedDate);

            if (rdtp_OTDt.SelectedDate == null)
            {
                BLL.ShowMessage(this, "Please select Date of Over Time before entering Actual hours");
                rtbActHrs.Text = rtbActMins.Text = rtbOTHrs.Text = rtbOTMins.Text = string.Empty;
                rdtp_OTDt.Focus();
                return;
            }
            DataTable dthld = new DataTable();
            dthld = BLL.get_HolidayMaster(_obj_Smhr_Holiday);

            if (Convert.ToInt32(dthld.Rows[0]["HOLMST_DATE"]) > 0)
            {
                if (rdtp_OTDt.SelectedDate != null)
                {
                    holiday = Convert.ToDateTime(rdtp_OTDt.SelectedDate).DayOfWeek.ToString();

                    if (holiday == "Saturday" || holiday == "Sunday")
                        hldyval = 2;
                    else
                        hldyval = Convert.ToInt32(2);

                    if (rtbActHrs.Text != string.Empty || rtbActMins.Text != string.Empty)
                    {
                        if (rtbActHrs.Text != string.Empty)
                        {
                            if (Convert.ToInt32(rtbActHrs.Text) > 12)
                                rtbActHrs.Text = maxHrs.ToString();
                        }
                        if (rtbActMins.Text != string.Empty)
                        {
                            if (Convert.ToInt32(rtbActMins.Text) > 59)
                                rtbActMins.Text = maxMins.ToString();
                        }
                        if (rtbActHrs.Text != string.Empty)
                            hrs = Convert.ToDecimal(rtbActHrs.Text) * 60;      //to convert hours into minutes
                        if (rtbActMins.Text != string.Empty)
                            mins = Convert.ToDecimal(rtbActMins.Text);

                        hldyfinal = (hrs + mins) * hldyval;
                        if (hldyval > 0)
                        {
                            if (Convert.ToString(hldyfinal / 60).Contains('.'))
                                rtbOTHrs.Text = Convert.ToString(hldyfinal / 60).Substring(0, Convert.ToString(hldyfinal / 60).IndexOf('.'));
                            else
                                rtbOTHrs.Text = Convert.ToString(Convert.ToInt32(hldyfinal / 60));

                            rtbOTMins.Text = Convert.ToString(Convert.ToInt32((hldyfinal % 60) + Convert.ToDecimal(0.1)));
                        }

                    }
                    else
                    {
                        if (rtbActHrs.Text == string.Empty && rtbActMins.Text == string.Empty)
                            rtbActHrs.Text = rtbActMins.Text = rtbOTHrs.Text = rtbOTMins.Text = string.Empty;
                    }
                }
            }

            else if (rdtp_OTDt.SelectedDate != null)
            {
                weekDay = Convert.ToDateTime(rdtp_OTDt.SelectedDate).DayOfWeek.ToString();

                if (weekDay == "Saturday" || weekDay == "Sunday")
                    val = 2;
                else
                    val = Convert.ToDecimal(1.5);



                if (rtbActHrs.Text != string.Empty || rtbActMins.Text != string.Empty)
                {
                    if (rtbActHrs.Text != string.Empty)
                    {
                        if (Convert.ToInt32(rtbActHrs.Text) > 12)
                            rtbActHrs.Text = Convert.ToInt32(rtbActHrs.Text) > 12 ? "16" : maxHrs.ToString();
                    }
                    if (rtbActMins.Text != string.Empty)
                    {
                        if (Convert.ToInt32(rtbActMins.Text) > 59)
                            rtbActMins.Text = maxMins.ToString();
                    }
                    if (rtbActHrs.Text != string.Empty)
                        hrs = Convert.ToDecimal(rtbActHrs.Text) * 60;      //to convert hours into minutes
                    if (rtbActMins.Text != string.Empty)
                        mins = Convert.ToDecimal(rtbActMins.Text);

                    final = (hrs + mins) * val;
                    //hldyfinal = (hrs + mins) * hldyval;
                    //if (hldyval>0)
                    //{
                    //    if (Convert.ToString(hldyfinal / 60).Contains('.'))
                    //        rtbOTHrs.Text = Convert.ToString(hldyfinal / 60).Substring(0, Convert.ToString(hldyfinal / 60).IndexOf('.'));
                    //    else
                    //        rtbOTHrs.Text = Convert.ToString(Convert.ToInt32(hldyfinal / 60));

                    //    rtbOTMins.Text = Convert.ToString(Convert.ToInt32((hldyfinal % 60) + Convert.ToDecimal(0.1)));
                    //}
                    if (final > 0)
                    {
                        if (Convert.ToString(final / 60).Contains('.'))
                            rtbOTHrs.Text = Convert.ToString(final / 60).Substring(0, Convert.ToString(final / 60).IndexOf('.'));
                        else
                            rtbOTHrs.Text = Convert.ToString(Convert.ToInt32(final / 60));

                        rtbOTMins.Text = Convert.ToString(Convert.ToInt32((final % 60) + Convert.ToDecimal(0.1)));

                        if (CheckHoursValid(final))
                        {
                            rtbOTHrs.Text = rtbOTMins.Text = rtbActHrs.Text = rtbActMins.Text = string.Empty;
                            rdp_totime.SelectedDate = rdp_fromtime.SelectedDate = null;
                        }
                    }


                }
                else
                {
                    if (rtbActHrs.Text == string.Empty && rtbActMins.Text == string.Empty)
                        rtbActHrs.Text = rtbActMins.Text = rtbOTHrs.Text = rtbOTMins.Text = string.Empty;
                }
            }

            else
            {
                BLL.ShowMessage(this, "Please select Date of Over Time before entering Actual hours");
                rtbActHrs.Text = rtbActMins.Text = rtbOTHrs.Text = rtbOTMins.Text = string.Empty;
                rdtp_OTDt.Focus();
                return;
            }
        }


        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmOverTimeCalc", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    bool CheckHoursValid(decimal final)
    {
        bool res = false;
        TimeSpan fromtime = new TimeSpan(Convert.ToDateTime(rdp_fromtime.SelectedDate).Hour, Convert.ToDateTime(rdp_fromtime.SelectedDate).Minute, Convert.ToDateTime(rdp_fromtime.SelectedDate).Second);
        TimeSpan totime = new TimeSpan(Convert.ToDateTime(rdp_totime.SelectedDate).Hour, Convert.ToDateTime(rdp_totime.SelectedDate).Minute, Convert.ToDateTime(rdp_totime.SelectedDate).Second);
        DataTable checkhours = BLL.Checkhourexceed(Convert.ToInt32(rcmb_Employee.SelectedValue), Convert.ToDateTime(rdtp_OTDt.SelectedDate), fromtime, totime); //.Rows[0]["OTCALC_ACTUALHOURS"]);
        if (checkhours != null && checkhours.Rows.Count > 0)
        {
            foreach (DataRow dr in checkhours.Rows)
            {
                if (!string.IsNullOrEmpty(dr["OTCALC_FROMTIME"].ToString()) && !string.IsNullOrEmpty(dr["OTCALC_TOTIME"].ToString()))
                {
                    int maxOThours = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["maxOThours"]);
                    TimeSpan fromtimespan = TimeSpan.Parse(dr["OTCALC_FROMTIME"].ToString()), totimespan = TimeSpan.Parse(dr["OTCALC_TOTIME"].ToString());
                    decimal submin = Convert.ToInt32(dr["otcalc_workinghours"]) + final;
                    if (submin > maxOThours)
                    {
                        BLL.ShowMessage(this, "Your OT Hours for today has exceed");
                        res = true; break;
                    }
                    else if (totimespan > fromtime)
                    {
                        BLL.ShowMessage(this, "To time for this Employee is" + " " + totimespan + " " + "From time Should be greater than To time");
                        res = true; break;
                    }
                    else if (fromtimespan == fromtime)
                    {
                        BLL.ShowMessage(this, "From Time Already Selected");
                        res = true; break;
                    }
                    else if (totimespan == totime)
                    {
                        BLL.ShowMessage(this, "To Time Already Selected");
                        res = true; break;
                    }
                }

            }
        }
        return res;


    }
}