using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;
using System.Drawing;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Text;



public partial class Payroll_frm_AttendanceDetails : System.Web.UI.Page
{
    public static DataTable dt_ds;
    SMHR_PAYROLL _obj_smhr_payroll;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;
    //private DateTime[] dates = new DateTime[] { DateTime.Today, DateTime.Today.AddDays(1), DateTime.Today.AddMonths(1), DateTime.Today.AddMonths(-1) }; 
    int index;
    bool _isConfirmNeeded = true;
    string _confirmMessage = string.Empty;
    public bool IsConfirmNeeded
    {
        get { return _isConfirmNeeded; }
        set { _isConfirmNeeded = value; }
    }
    public string ConfirmMessage
    {
        get { return _confirmMessage; }
        set { _confirmMessage = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {


                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Attendance Details");//ATTENDANCEDETAILS");
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
                    //btn_AttDtls_Submit.Visible = false;
                    btn_AttDtls_Finalize.Visible = false;
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
                loadDropdown();
                //rdtp_AttDtls_AttDt.MaxDate = DateTime.Now;
                Label1.Text = null;
                btn_AttDtls_Finalize.Attributes.Add("onclick", "return confirmationSave();");
                //SMHR_ATTENDANCE _obj_Smhr_Attendance = new SMHR_ATTENDANCE();

                //foreach (DateTime date in dates)

                //{

                //    RadCalendarDay specialDay = new RadCalendarDay();
                //    rdtp_AttDtls_AttDt.Calendar.SpecialDays.Add(specialDay);
                //    specialDay.Date = date;
                //    specialDay.ItemStyle.BackColor = Color.Red;
                //}

            }

            IsConfirmNeeded = true;
            ConfirmMessage = "You want to continue with LOP?";
            ClientScript.GetPostBackEventReference(this, string.Empty);
            if (IsPostBack)
            {
                string eventTarget = Request["__EVENTTARGET"] ?? string.Empty;
                string eventArgument = Request["__EVENTARGUMENT"] ?? string.Empty;

                switch (eventTarget)
                {
                    case "UserConfirmationPostBack":
                        if (Convert.ToBoolean(eventArgument))
                        {
                            RadComboBox rcmb_AttDtls_Status = new RadComboBox();
                            index = Convert.ToInt32(Session["rowIndex"]);
                            rcmb_AttDtls_Status = rgd_AttDtls_Emp.Items[index].FindControl("rcmb_AttDtls_Status") as RadComboBox;
                            rcmb_AttDtls_Status.SelectedIndex = 1;

                            //Telerik.Web.UI.RadComboBox rcmb_status = sender as Telerik.Web.UI.RadComboBox;
                            //GridItem gvRow = rcmb_status.Parent.Parent as GridItem;
                            //RadComboBox ddl_status = (RadComboBox)gvRow.FindControl("rcmb_AttDtls_Status");
                            //ddl_status.SelectedIndex = 1;

                        }
                        else
                        {
                            return;
                        }
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void loadDropdown()
    {
        try
        {
            rcmb_Attdtls_BU.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_Attdtls_BU.DataSource = dt_BUDetails;
            rcmb_Attdtls_BU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_Attdtls_BU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_Attdtls_BU.DataBind();
            rcmb_Attdtls_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
            DataTable dt_Details = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmb_Attdtls_Period.DataSource = dt_Details;
            rcmb_Attdtls_Period.DataValueField = "PERIOD_ID";
            rcmb_Attdtls_Period.DataTextField = "PERIOD_NAME";
            rcmb_Attdtls_Period.DataBind();
            rcmb_Attdtls_Period.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void loadEmployees()
    {
        try
        {
            Telerik.Web.UI.RadComboBox ddlList = new RadComboBox();
            Telerik.Web.UI.RadNumericTextBox rntxt = new RadNumericTextBox();
            CheckBox chk = new CheckBox();
            Label lblempid = new Label();
            int i = 0;
            Label1.Text = null;
            SMHR_ATTENDANCE _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
            _obj_Smhr_Attendance.OPERATION = operation.Check;
            _obj_Smhr_Attendance.ATTENDANCE_MODE = true;
            _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedItem.Value);
            _obj_Smhr_Attendance.ATTENDANCE_DATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);
            _obj_Smhr_Attendance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT_Employee = new DataTable();
            DT_Employee = BLL.get_Attendance(_obj_Smhr_Attendance);
            if (DT_Employee.Rows.Count == 0)
            {
                _obj_Smhr_Attendance.OPERATION = operation.Select;
                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_Attdtls_PeriodElements.SelectedItem.Value);
                DT_Employee = BLL.get_Attendance(_obj_Smhr_Attendance);
                if (DT_Employee.Rows.Count != 0)
                {
                    rgd_AttDtls_Emp.Visible = true;
                    rgd_AttDtls_Emp.DataSource = DT_Employee;
                    rgd_AttDtls_Emp.DataBind();
                    Label1.Text = "Insert";
                    int EMP_COUNT = 0;
                    for (i = 0; i <= rgd_AttDtls_Emp.Items.Count - 1; i++)
                    {
                        ddlList = rgd_AttDtls_Emp.Items[i].FindControl("rcmb_AttDtls_Status") as RadComboBox;
                        rntxt = rgd_AttDtls_Emp.Items[i].FindControl("rntxt_noofhours") as RadNumericTextBox;
                        rntxt.Enabled = false;
                        //TO GET PAYROLL STATUS
                        chk = rgd_AttDtls_Emp.Items[i].FindControl("chckbtn_Select") as CheckBox;
                        lblempid = rgd_AttDtls_Emp.Items[i].FindControl("lbl_empid") as Label;
                        _obj_Smhr_Attendance.OPERATION = operation.Select1;
                        _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedItem.Value);
                        _obj_Smhr_Attendance.ATTENDANCE_PERIOD_ID = Convert.ToInt32(rcmb_Attdtls_Period.SelectedItem.Value);
                        _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_Attdtls_PeriodElements.SelectedItem.Value);
                        _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lblempid.Text);
                        DataTable dt_status = BLL.get_Attendance(_obj_Smhr_Attendance);
                        bool st = false;
                        if (dt_status.Rows.Count > 0)
                        {
                            for (int count = 0; count < dt_status.Rows.Count; count++)
                            {
                                if (Convert.ToString(dt_status.Rows[count]["COUNT"]) != "0")
                                {
                                    st = true;//IF PAYROLL IS IN PENDING OR APPROVED
                                }
                            }
                        }
                        if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][2]))).Trim() != "")
                        {
                            if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][3]))).Trim() == "0")
                            {
                                ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("P"));
                                //ddlList.BackColor = Color.Red;
                                ddlList.ForeColor = Color.Black;
                                rntxt.Enabled = true;
                            }
                            else if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][3]))).Trim() == "1")
                            {
                                ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("L"));
                                ddlList.ForeColor = Color.Magenta;
                                rntxt.Enabled = false;
                                rntxt.Text = "0.00";
                            }
                            else if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][3]))).Trim() == "2")
                            {
                                ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("W"));
                                ddlList.ForeColor = Color.Blue;
                                rntxt.Enabled = false;
                                rntxt.Text = "0.00";
                            }
                            else if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][3]))).Trim() == "3")
                            {
                                ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("H"));
                                ddlList.ForeColor = Color.DarkGreen;
                                rntxt.Enabled = false;
                                rntxt.Text = "0.00";
                            }

                            else if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][3]))).Trim() == "4")
                            {
                                ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("HL"));
                                ddlList.ForeColor = Color.DarkGoldenrod;
                                rntxt.Enabled = false;
                                rntxt.Text = "0.00";
                            }
                            else if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][3]))).Trim() == "5")
                            {
                                ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("A"));
                                ddlList.ForeColor = Color.Red;
                                rntxt.Enabled = false;
                                rntxt.Text = "0.00";
                            }
                            else if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][3]))).Trim() == "-1")
                            {
                                ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("A"));
                                ddlList.ForeColor = Color.Red;
                                ddlList.Enabled = false;
                                rntxt.Enabled = false;
                                rntxt.Text = "0.00";
                            }

                        }
                        else if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][2]))).Trim() == "")
                        {
                            ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("A"));
                            ddlList.ForeColor = Color.Red;
                            rntxt.Enabled = false;
                            rntxt.Text = "0.00";
                        }
                        if (st == true)
                        {
                            ddlList.Enabled = false;
                            rntxt.Enabled = false;
                            chk.Enabled = false;
                        }
                        else
                        {
                            ddlList.Enabled = true;
                            rntxt.Enabled = true;
                            chk.Enabled = true;
                            EMP_COUNT++;
                        }
                        //if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][3])) == "0")
                        //    ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("P"));
                        //else if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][3])) == "1")
                        //    ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("L"));
                        //else if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][3])) == "2")
                        //    ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("W"));
                        //else if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][3])) == "3")
                        //    ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("H"));
                        //else if (Convert.ToString(Convert.ToString(DT_Employee.Rows[i][3])) == " ")
                        //    ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("A"));
                    }
                    //code for security
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {
                        //btn_AttDtls_Submit.Visible = false;
                        btn_AttDtls_Finalize.Visible = false;
                    }
                    else
                    {
                        //btn_AttDtls_Submit.Visible = true;
                        if (EMP_COUNT == 0)
                            btn_AttDtls_Finalize.Visible = false;
                        else
                            btn_AttDtls_Finalize.Visible = true;
                    }
                }
                else
                {
                    rgd_AttDtls_Emp.Visible = false;
                    //btn_AttDtls_Submit.Visible = false;
                    btn_AttDtls_Finalize.Visible = false;
                }
            }
            else
            {
                _obj_Smhr_Attendance.OPERATION = operation.Check_New;
                _obj_Smhr_Attendance.ATTENDANCE_MODE = true;
                _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedItem.Value);
                _obj_Smhr_Attendance.ATTENDANCE_DATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);
                //_obj_Smhr_Attendance.OPERATION = operation.Select;
                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_Attdtls_PeriodElements.SelectedItem.Value);
                DT_Employee = BLL.get_Attendance(_obj_Smhr_Attendance);
                //for (int iIndex = 0; iIndex < DT_Employee.Rows.Count; iIndex++)
                //{
                //    if (Convert.ToString(DT_Employee.Rows[iIndex]["ATTENDANCE_NOOFHOURS"]) != string.Empty)
                //    {
                //        if (Convert.ToDouble(DT_Employee.Rows[iIndex]["ATTENDANCE_NOOFHOURS"]) == 0.00)
                //        {
                //            DT_Employee.Rows[iIndex]["ATTENDANCE_NOOFHOURS"] = DT_Employee.Rows[iIndex]["BUSINESSUNIT_NOOFHOURS"];
                //        }
                //    }
                //    else if (Convert.ToString(DT_Employee.Rows[iIndex]["ATTENDANCE_NOOFHOURS"]) == string.Empty)
                //    {
                //        DT_Employee.Rows[iIndex]["ATTENDANCE_NOOFHOURS"] = DT_Employee.Rows[iIndex]["BUSINESSUNIT_NOOFHOURS"];
                //    }
                //}
                rgd_AttDtls_Emp.Visible = true;
                rgd_AttDtls_Emp.DataSource = DT_Employee;
                rgd_AttDtls_Emp.DataBind();
                Label1.Text = "Update";
                ////TO GET WHETHER PAYROLL IS APPROVED OR NOT
                //_obj_Smhr_Attendance.OPERATION = operation.Select3;
                //_obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedItem.Value);
                //_obj_Smhr_Attendance.ATTENDANCE_PERIOD_ID = Convert.ToInt32(rcmb_Attdtls_Period.SelectedItem.Value);
                //_obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_Attdtls_PeriodElements.SelectedItem.Value);
                //DataTable dt_status = BLL.get_Attendance(_obj_Smhr_Attendance);
                //bool st = false;
                //if (dt_status.Rows.Count > 0)
                //{
                //    for (int count = 0; count < dt_status.Rows.Count; count++)
                //    {
                //        if (Convert.ToString(dt_status.Rows[count]["COUNT"]) != "0")
                //        {
                //            st = true;//IF PAYROLL IS IN PENDING OR APPROVED
                //        }
                //    }
                //}
                int EMP_COUNT = 0;
                for (i = 0; i <= rgd_AttDtls_Emp.Items.Count - 1; i++)
                {
                    ddlList = rgd_AttDtls_Emp.Items[i].FindControl("rcmb_AttDtls_Status") as RadComboBox;
                    rntxt = rgd_AttDtls_Emp.Items[i].FindControl("rntxt_noofhours") as RadNumericTextBox;
                    //TO GET PAYROLL STATUS
                    chk = rgd_AttDtls_Emp.Items[i].FindControl("chckbtn_Select") as CheckBox;
                    lblempid = rgd_AttDtls_Emp.Items[i].FindControl("lbl_empid") as Label;
                    _obj_Smhr_Attendance.OPERATION = operation.Select1;
                    _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedItem.Value);
                    _obj_Smhr_Attendance.ATTENDANCE_PERIOD_ID = Convert.ToInt32(rcmb_Attdtls_Period.SelectedItem.Value);
                    _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_Attdtls_PeriodElements.SelectedItem.Value);
                    _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lblempid.Text);
                    DataTable dt_status = BLL.get_Attendance(_obj_Smhr_Attendance);
                    bool st = false;
                    if (dt_status.Rows.Count > 0)
                    {
                        for (int count = 0; count < dt_status.Rows.Count; count++)
                        {
                            if (Convert.ToString(dt_status.Rows[count]["COUNT"]) != "0")
                            {
                                st = true;//IF PAYROLL IS IN PENDING OR APPROVED
                            }
                        }
                    }
                    rntxt.Enabled = false;
                    if (DT_Employee.Rows[i]["ATTENDANCE_FINALIZE"] != System.DBNull.Value)
                    {
                        if (Convert.ToString(DT_Employee.Rows[i]["ATTENDANCE_FINALIZE"]) == "1")
                            chk.Checked = true;
                        else
                            chk.Checked = false;
                    }
                    else
                    {
                        chk.Checked = false;
                    }
                    if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][2]))).Trim() == "P")
                    {
                        ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("P"));
                        ddlList.ForeColor = Color.Black;
                        rntxt.Enabled = true;
                    }
                    else if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][2]))).Trim() == "A")
                    {
                        ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("A"));
                        ddlList.ForeColor = Color.Red;
                    }
                    else if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][2]))).Trim() == "L")
                    {
                        ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("L"));
                        ddlList.ForeColor = Color.Magenta;
                    }
                    else if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][2]))).Trim() == "W")
                    {
                        ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("W"));
                        ddlList.ForeColor = Color.Blue;
                    }
                    else if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][2]))).Trim() == "T")
                    {
                        ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("T"));
                        ddlList.ForeColor = Color.DodgerBlue;
                    }
                    else if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][2]))).Trim() == "C")
                    {
                        ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("C"));
                        ddlList.ForeColor = Color.Maroon;
                    }
                    else if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][2]))).Trim() == "H")
                    {
                        ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("H"));
                        ddlList.ForeColor = Color.DarkGreen;
                    }
                    else if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][2]))).Trim() == "HD")
                    {
                        ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("HD"));
                        ddlList.ForeColor = Color.Gray;
                    }
                    else if ((Convert.ToString(Convert.ToString(DT_Employee.Rows[i][2]))).Trim() == "HL")
                    {
                        ddlList.SelectedIndex = ddlList.FindItemIndexByValue(Convert.ToString("HL"));
                        ddlList.ForeColor = Color.DarkGoldenrod;
                    }
                    //if (DT_Employee.Rows[0][3].ToString() == "1")
                    //{
                    if (st == true)
                    {
                        ddlList.Enabled = false;
                        rntxt.Enabled = false;
                        chk.Enabled = false;
                    }
                    else
                    {
                        ddlList.Enabled = true;
                        rntxt.Enabled = true;
                        chk.Enabled = true;
                        EMP_COUNT++;
                    }
                    //}
                }
                //if (DT_Employee.Rows[0][3].ToString() == "1")
                //{
                ////if (st == true)
                ////{
                ////    ddlList.Enabled = false;
                ////    rntxt.Enabled = false;
                ////    btn_AttDtls_Submit.Visible = false;
                ////    btn_AttDtls_Finalize.Visible = false;
                ////}
                ////else
                ////{
                ////    ddlList.Enabled = true;
                ////    rntxt.Enabled = true;
                ////    btn_AttDtls_Submit.Visible = true;
                ////    btn_AttDtls_Finalize.Visible = true;
                ////}
                //}
                //else
                //{
                //code for security
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    ddlList.Enabled = false;
                    rntxt.Enabled = false;
                    //btn_AttDtls_Submit.Visible = false;
                    btn_AttDtls_Finalize.Visible = false;

                }

                else
                {
                    if (EMP_COUNT == 0)
                    {
                        //btn_AttDtls_Submit.Visible = false;
                        btn_AttDtls_Finalize.Visible = false;
                    }
                    else
                    {
                        //btn_AttDtls_Submit.Visible = true;
                        btn_AttDtls_Finalize.Visible = true;
                    }
                }

                //}
            }
            dt_ds = DT_Employee;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rdtp_AttDtls_AttDt_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            if (rdtp_AttDtls_AttDt.SelectedDate != null)
            {
                if (rcmb_Attdtls_BU.SelectedIndex > 0)
                {
                    _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
                    _obj_Smhr_BusinessUnit.OPERATION = operation.Select;
                    _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(Convert.ToString(rcmb_Attdtls_BU.SelectedValue));
                    DataTable dt = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
                    if (dt.Rows.Count > 0)
                    {
                        if ((Convert.ToString(dt.Rows[0]["BUSINESSUNIT_NOOFHOURS"]) != string.Empty) && (Convert.ToString(dt.Rows[0]["BUSINESSUNIT_NOOFHOURS"]) != "0.00"))
                        {
                            foreach (GridTemplateColumn col in rgd_AttDtls_Emp.Columns)
                            {
                                if (col.UniqueName.ToUpper() == "NOOFHOURS")
                                {
                                    col.Visible = true;
                                }
                            }
                        }
                    }
                    loadEmployees();
                }
                else
                {
                    BLL.ShowMessage(this, "Please Select Business Unit");
                }
            }
            else
            {
                rgd_AttDtls_Emp.Visible = false;
                btn_AttDtls_Finalize.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcmb_AttDtls_Status_DataBinding(object sender, EventArgs e)
    {

    }

    protected bool InsertUpdate()
    {
        bool status = false;

        try
        {
            string opstatus = Label1.Text;
            if (opstatus != null)
            {

                SMHR_ATTENDANCE _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
                switch (opstatus)
                {
                    case "Insert":
                        {
                            _obj_Smhr_Attendance.OPERATION = operation.Insert;
                            _obj_Smhr_Attendance.ATTENDANCE_FINALIZE = 0;
                        }
                        break;
                    case "Finalize":
                        {
                            _obj_Smhr_Attendance.OPERATION = operation.Insert;
                            _obj_Smhr_Attendance.ATTENDANCE_FINALIZE = 1;
                        }
                        break;
                    case "Update":
                        {
                            _obj_Smhr_Attendance.OPERATION = operation.Update;
                            _obj_Smhr_Attendance.ATTENDANCE_MODE = true;
                            _obj_Smhr_Attendance.ATTENDANCE_FINALIZE = 0;
                        }
                        break;
                    case "UpdateFinalize":
                        {
                            _obj_Smhr_Attendance.OPERATION = operation.Update;
                            _obj_Smhr_Attendance.ATTENDANCE_MODE = false;
                            _obj_Smhr_Attendance.ATTENDANCE_FINALIZE = 1;
                        }
                        break;
                }

                Label lblID = new Label();
                RadComboBox rcmb_Status = new RadComboBox();
                RadNumericTextBox rntxt = new RadNumericTextBox();
                CheckBox chk = new CheckBox();
                int count = 0;
                for (int i = 0; i <= rgd_AttDtls_Emp.Items.Count - 1; i++)
                {
                    lblID = rgd_AttDtls_Emp.Items[i].FindControl("lbl_empid") as Label;
                    rcmb_Status = rgd_AttDtls_Emp.Items[i].FindControl("rcmb_AttDtls_Status") as RadComboBox;
                    rntxt = rgd_AttDtls_Emp.Items[i].FindControl("rntxt_noofhours") as RadNumericTextBox;
                    chk = rgd_AttDtls_Emp.Items[i].FindControl("chckbtn_Select") as CheckBox;
                    if (chk.Checked)
                    {
                        count++;
                        _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedValue);
                        _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_Attdtls_PeriodElements.SelectedValue);
                        _obj_Smhr_Attendance.ATTENDANCE_DATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);
                        _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lblID.Text);
                        _obj_Smhr_Attendance.ATTENDANCE_STATUS = Convert.ToString(rcmb_Status.SelectedValue);
                        _obj_Smhr_Attendance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        if (rntxt.Text != string.Empty)
                            _obj_Smhr_Attendance.ATTENDANCE_NOOFHOURS = Convert.ToDouble(rntxt.Value);
                        else
                            _obj_Smhr_Attendance.ATTENDANCE_NOOFHOURS = 0.00;
                        _obj_Smhr_Attendance.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_Smhr_Attendance.CREATEDDATE = DateTime.Now;
                        _obj_Smhr_Attendance.LASTMDFBY = Convert.ToInt32(Session["EMP_ID"]);
                        _obj_Smhr_Attendance.LASTMDFDATE = DateTime.Now;
                        if (BLL.set_Attendance(_obj_Smhr_Attendance))
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                }
                if (count == 0)
                {
                    BLL.ShowMessage(this, "Please Select Atleast One Employee.");

                }
                return status;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");

        }
        return status;
    }

    protected void btn_AttDtls_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            string opstatus = Label1.Text;
            switch (opstatus)
            {
                case "Insert":
                    opstatus = "Submit";
                    break;
                case "Submit":
                    opstatus = "UpdateSub";
                    break;
                case "Update":
                    opstatus = "UpdateSub";
                    break;
            }
            bool Submit = InsertUpdate();
            if (Submit)
                BLL.ShowMessage(this, "Attendance Details have been saved");
            else
                BLL.ShowMessage(this, "Attendance Details not saved");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_AttDtls_Finalize_Click(object sender, EventArgs e)
    {
        try
        {
            FinalizeAttDtls();
            bool Finalized;
            Finalized = InsertUpdate();
            if (Finalized)
            {
                BLL.ShowMessage(this, "Attendace Details have been finalized");
                //btn_AttDtls_Finalize.Visible = false;
                ////btn_AttDtls_Submit.Visible = false;
                //RadComboBox ddlList = new RadComboBox();
                //RadNumericTextBox rntxt = new RadNumericTextBox();
                //for (int i = 0; i <= rgd_AttDtls_Emp.Items.Count - 1; i++)
                //{
                //    ddlList = rgd_AttDtls_Emp.Items[i].FindControl("rcmb_AttDtls_Status") as RadComboBox;
                //    ddlList.Enabled = false;
                //    rntxt = rgd_AttDtls_Emp.Items[i].FindControl("rntxt_noofhours") as RadNumericTextBox;
                //    rntxt.Enabled = false;
                //}
                loadEmployees();
                Attendance_color();
            }
            else
            {
                BLL.ShowMessage(this, "Attendace Details hasn't finalized");
                //code for security
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_AttDtls_Finalize.Visible = false;
                    //btn_AttDtls_Submit.Visible = false;

                }

                else
                {
                    btn_AttDtls_Finalize.Visible = true;
                    //btn_AttDtls_Submit.Visible = true;
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void FinalizeAttDtls()
    {
        try
        {
            Telerik.Web.UI.RadComboBox ddlList = new RadComboBox();
            Label1.Text = null;
            SMHR_ATTENDANCE _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
            _obj_Smhr_Attendance.OPERATION = operation.Check;
            _obj_Smhr_Attendance.ATTENDANCE_MODE = true;
            _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedItem.Value);
            _obj_Smhr_Attendance.ATTENDANCE_DATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);

            DataTable DT_Employee = new DataTable();
            DT_Employee = BLL.get_Attendance(_obj_Smhr_Attendance);
            if (DT_Employee.Rows.Count == 0)
            {
                _obj_Smhr_Attendance.OPERATION = operation.Select;
                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_Attdtls_PeriodElements.SelectedItem.Value);
                DT_Employee = BLL.get_Attendance(_obj_Smhr_Attendance);
                if (DT_Employee.Rows.Count != 0)
                {
                    Label1.Text = "Finalize";
                }
            }
            else
            {
                Label1.Text = "UpdateFinalize";
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcmb_Attdtls_BU_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_Attdtls_Period.SelectedIndex = -1;
            tblr_AttDtls_AttDt.Visible = false;
            tblr_AttDtls_PeriodElements.Visible = false;
            rgd_AttDtls_Emp.Visible = false;
            rdtp_AttDtls_AttDt.SelectedDate = null;
            btn_AttDtls_Finalize.Visible = false;
            //rdtp_AttDtls_AttDt.Calendar.BackColor=Color.Empty;

            // Attendance_color();
            //SMHR_ATTENDANCE _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
            //_obj_Smhr_Attendance.OPERATION = operation.Get;
            //_obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedValue);
            //DataTable dt_attendance = BLL.get_Attendance(_obj_Smhr_Attendance);
            //for (int k = 0; k < dt_attendance.Rows.Count; k++)
            //{

            //    RadCalendarDay specialDay = new RadCalendarDay();
            //    rdtp_AttDtls_AttDt.Calendar.SpecialDays.Add(specialDay);
            //    specialDay.Date = Convert.ToDateTime(dt_attendance.Rows[k]["ATTENDANCE_DATE"]);
            //    specialDay.ItemStyle.BackColor = Color.Green;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_AttDtls_Status_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            ////Telerik.Web.UI.RadNumericTextBox rntxt = new RadNumericTextBox();
            Telerik.Web.UI.RadComboBox rcmb_status = sender as Telerik.Web.UI.RadComboBox;
            GridItem gvRow = rcmb_status.Parent.Parent as GridItem;
            Session["rowIndex"] = gvRow.DataSetIndex;
            RadNumericTextBox rntxt = (RadNumericTextBox)gvRow.FindControl("rntxt_noofhours");
            RadComboBox ddl_status = (RadComboBox)gvRow.FindControl("rcmb_AttDtls_Status");
            Label lblID = new Label();

            if (ddl_status.SelectedValue == "P")
            {
                rntxt.Enabled = true;
                ddl_status.ForeColor = Color.Black;
            }
            else
            {
                rntxt.Enabled = false;
                rntxt.Text = "0.00";
            }
            if (ddl_status.SelectedValue == "A")
            {
                ddl_status.ForeColor = Color.Red;
            }
            else if (ddl_status.SelectedValue == "L")
            {
                ddl_status.ForeColor = Color.Magenta;
            }
            else if (ddl_status.SelectedValue == "W")
            {
                ddl_status.ForeColor = Color.Blue;
            }
            else if (ddl_status.SelectedValue == "H")
            {
                ddl_status.ForeColor = Color.DarkGreen;
            }
            else if (ddl_status.SelectedValue == "HL")
            {
                ddl_status.ForeColor = Color.DarkGoldenrod;
            }
            else if (ddl_status.SelectedValue == "HD")
            {
                ddl_status.ForeColor = Color.Gray;
            }
            else if (ddl_status.SelectedValue == "C")
            {
                ddl_status.ForeColor = Color.Maroon;

            }
            else if (ddl_status.SelectedValue == "T")
            {
                ddl_status.ForeColor = Color.DodgerBlue;
            }
            else
            {
                ddl_status.ForeColor = Color.Black;
            }
            if (ddl_status.SelectedValue == "L")
            {
                //lblID = rgd_AttDtls_Emp.Items[i].FindControl("lbl_empid") as Label;
                Label lbl = (Label)gvRow.FindControl("lbl_empid");
                SMHR_ATTENDANCE _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
                _obj_Smhr_Attendance.OPERATION = operation.Select_New;
                _obj_Smhr_Attendance.ATTENDANCE_EMP_ID = Convert.ToInt32(lbl.Text);
                _obj_Smhr_Attendance.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = new DataTable();
                dt = BLL.get_Attendance(_obj_Smhr_Attendance);
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToString(dt.Rows[0]["LT_CURRENTBALANCE"]) == "0.00")
                    {
                        if (IsConfirmNeeded)
                        {
                            StringBuilder javaScript = new StringBuilder();
                            string scriptKey = "ConfirmationScript";
                            javaScript.AppendFormat("var userConfirmation = window.confirm('{0}');\n", ConfirmMessage);
                            javaScript.Append("__doPostBack('UserConfirmationPostBack', userConfirmation);\n");
                            ScriptManager.RegisterStartupScript(this, GetType(), scriptKey, javaScript.ToString(), true);
                        }

                        //ScriptManager.RegisterStartupScript(this, this.GetType(),"ajax", "<script language='javascript'>OnConfirm();</script>", false);
                        //BLL.ShowConfirmMessage(this,"Do you want to Proceed?");

                        //MsgBoxResult mresult = Interaction.MsgBox("Employee does not have LeaveBalances.You want to continue with LOP?", MsgBoxStyle.OkCancel, "Confirmation");

                        //if (mresult.ToString() == "Ok")
                        //{
                        //    ddl_status.SelectedIndex = ddl_status.FindItemIndexByValue(Convert.ToString("A"));
                        //}
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rntxt_noofhours_TextChanged(object sender, EventArgs e)
    {
        try
        {
            SMHR_ATTENDANCE _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
            _obj_Smhr_Attendance.OPERATION = operation.Check;
            _obj_Smhr_Attendance.ATTENDANCE_MODE = true;
            _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedItem.Value);
            _obj_Smhr_Attendance.ATTENDANCE_DATE = Convert.ToDateTime(rdtp_AttDtls_AttDt.SelectedDate);

            DataTable DT_Employee = new DataTable();
            DT_Employee = BLL.get_Attendance(_obj_Smhr_Attendance);
            if (DT_Employee.Rows.Count == 0)
            {
                _obj_Smhr_Attendance.OPERATION = operation.Select;
                _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_Attdtls_PeriodElements.SelectedItem.Value);
                DT_Employee = BLL.get_Attendance(_obj_Smhr_Attendance);

            }


            Telerik.Web.UI.RadNumericTextBox rntxt = sender as Telerik.Web.UI.RadNumericTextBox;
            GridItem gvRow = rntxt.Parent.Parent as GridItem;
            RadNumericTextBox rnt = (RadNumericTextBox)gvRow.FindControl("rntxt_noofhours");
            if (rntxt.Text != string.Empty)
            {
                //if ((Convert.ToDouble(rntxt.Text) > Convert.ToDouble(DT_Employee.Rows[gvRow.ItemIndex]["BUSINESSUNIT_NOOFHOURS"])))
                if ((Convert.ToDouble(rntxt.Text) > Convert.ToDouble(DT_Employee.Rows[0]["BUSINESSUNIT_NOOFHOURS"])))
                {

                    BLL.ShowMessage(this, "No. Of Hours Should be Less Than " + DT_Employee.Rows[0]["BUSINESSUNIT_NOOFHOURS"] + "");
                    rntxt.Text = "0.00";
                    rntxt.Focus();
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void Attendance_color()
    {
        try
        {
            SMHR_ATTENDANCE _obj_Smhr_Attendance = new SMHR_ATTENDANCE();
            _obj_Smhr_Attendance.OPERATION = operation.Get;
            _obj_Smhr_Attendance.ATTENDANCE_BU_ID = Convert.ToInt32(rcmb_Attdtls_BU.SelectedValue);
            _obj_Smhr_Attendance.ATTENDANCE_PERIOD_DTL_ID = Convert.ToInt32(rcmb_Attdtls_PeriodElements.SelectedItem.Value);
            DataTable dt_attendance = BLL.get_Attendance(_obj_Smhr_Attendance);
            if (dt_attendance.Rows.Count > 0)
            {
                for (int k = 0; k < dt_attendance.Rows.Count; k++)
                {
                    RadCalendarDay specialDay = new RadCalendarDay();
                    specialDay.Date = Convert.ToDateTime(dt_attendance.Rows[k]["ATTENDANCE_DATE"]);
                    specialDay.ItemStyle.BackColor = Color.Green;
                    rdtp_AttDtls_AttDt.Calendar.SpecialDays.Add(specialDay);

                }
            }
            else
            {

                rdtp_AttDtls_AttDt.Calendar.SpecialDays.Clear();



            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void rcmb_Attdtls_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Attdtls_Period.SelectedIndex > 0)
            {
                _obj_smhr_payroll = new SMHR_PAYROLL();
                _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_Attdtls_Period.SelectedValue);
                _obj_smhr_payroll.MODE = 28;
                DataTable dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_Attdtls_PeriodElements.DataSource = dt_Details;
                    rcmb_Attdtls_PeriodElements.DataValueField = "PRDDTL_ID";
                    rcmb_Attdtls_PeriodElements.DataTextField = "PRDDTL_NAME";
                    rcmb_Attdtls_PeriodElements.DataBind();
                    rcmb_Attdtls_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select"));
                    tblr_AttDtls_PeriodElements.Visible = true;
                }
                else
                {
                    tblr_AttDtls_PeriodElements.Visible = false;
                    tblr_AttDtls_AttDt.Visible = false;
                }
            }
            else
            {
                rcmb_Attdtls_PeriodElements.ClearSelection();
                rcmb_Attdtls_PeriodElements.Items.Clear();
                rcmb_Attdtls_PeriodElements.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            tblr_AttDtls_AttDt.Visible = false;
            rgd_AttDtls_Emp.Visible = false;
            btn_AttDtls_Finalize.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcmb_Attdtls_PeriodElements_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Attdtls_PeriodElements.SelectedIndex > 0)
            {
                rdtp_AttDtls_AttDt.SelectedDate = null;
                rgd_AttDtls_Emp.Visible = false;
                btn_AttDtls_Finalize.Visible = false;
                SMHR_PERIODDTL _obj_smhr_prddtl = new SMHR_PERIODDTL();
                DataTable dt_Details = new DataTable();
                _obj_smhr_prddtl.OPERATION = operation.Select;
                _obj_smhr_prddtl.PRDDTL_ID = Convert.ToInt32(rcmb_Attdtls_PeriodElements.SelectedValue);
                Attendance_color();
                dt_Details = BLL.get_PeriodDetails(_obj_smhr_prddtl);
                if (dt_Details.Rows.Count > 0)
                {
                    if (Convert.ToDateTime(dt_Details.Rows[0][3].ToString()) <= DateTime.Now)
                    //if (Convert.ToDateTime(dt_Details.Rows[0][3].ToString()).Month <= DateTime.Now.Month)
                    {
                        rdtp_AttDtls_AttDt.MinDate = Convert.ToDateTime(dt_Details.Rows[0]["PRDDTL_STARTDATE"].ToString());
                        if (Convert.ToDateTime(dt_Details.Rows[0]["PRDDTL_ENDDATE"].ToString()) > DateTime.Now)
                        //if (Convert.ToDateTime(dt_Details.Rows[0]["PRDDTL_ENDDATE"].ToString()).Month > DateTime.Now.Month)
                        {
                            //DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                            //DateTime end = start.AddMonths(1).AddDays(-1);
                            //rdtp_AttDtls_AttDt.MaxDate = end;
                            rdtp_AttDtls_AttDt.MaxDate = DateTime.Now;
                        }
                        else
                        {
                            rdtp_AttDtls_AttDt.MaxDate = Convert.ToDateTime(dt_Details.Rows[0]["PRDDTL_ENDDATE"].ToString());
                        }
                        tblr_AttDtls_AttDt.Visible = true;
                        rdtp_AttDtls_AttDt.Visible = true;
                    }
                }
            }
            else
            {
                tblr_AttDtls_AttDt.Visible = false;
                rdtp_AttDtls_AttDt.Visible = false;
            }
            rgd_AttDtls_Emp.Visible = false;
            btn_AttDtls_Finalize.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    protected void chk_selectall_checkedchanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < rgd_AttDtls_Emp.Items.Count; i++)
            {
                CheckBox Chk_All = (CheckBox)sender;
                if (Chk_All.Checked)
                {
                    for (int index = 0; index < rgd_AttDtls_Emp.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)rgd_AttDtls_Emp.Items[index].FindControl("chckbtn_Select");
                        if (c.Enabled)
                            c.Checked = true;
                        else
                            c.Checked = false;
                    }
                }
                else
                {
                    for (int index = 0; index < rgd_AttDtls_Emp.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)rgd_AttDtls_Emp.Items[index].FindControl("chckbtn_Select");
                        if (c.Enabled)
                            c.Checked = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


}
