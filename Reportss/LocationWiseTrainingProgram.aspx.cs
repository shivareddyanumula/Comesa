using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Reportss_LocationWiseTrainingProgram : System.Web.UI.Page
{
    SMHR_ORGANISATION obj_smhr_Organisation;
    SMHR_BUSINESSUNIT obj_smhr_Businessunit;
    SMHR_EMPLOYEE obj_smhr_Employee;
    SMHR_PERIOD obj_smhr_Period;
    SMHR_TRAINING_LOCATION _obj_Smhr_Location;
    SMHR_LOGININFO obj_smhr_Logininfo;
    string Control;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Page.Validate();
            Control = Convert.ToString(Request.QueryString["Control"]);
            if (!Page.IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Location Wise Training Program");//COUNTRY");
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
                    //Rg_Countries.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    //btn_Save.Visible = false;
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
                if (Control != null)
                {
                    if (Control == "EmployeeAttendance")
                        lbl_header.Text = "Employee Attendance Details";//Employee Attendance";
                    Location.Visible = false;
                    Period.Visible = false;
                    PeriodElement.Visible = false;
                }
                else
                {
                    lbl_header.Text = "Location Wise Training Program";
                }
                LoadCombos();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LocationWiseTrainingProgram", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        Page.Validate();
    }

    private void LoadCombos()
    {
        try
        {
            obj_smhr_Period = new SMHR_PERIOD();
            obj_smhr_Period.OPERATION = operation.Select;
            obj_smhr_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_PeriodHeaderDetails(obj_smhr_Period);
            //DataTable dt_Details = BLL.get_PeriodHeaderDetails_Calendar(obj_smhr_Period);
            rcmb_Period.DataSource = dt_Details;
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select"));

            _obj_Smhr_Location = new SMHR_TRAINING_LOCATION();
            _obj_Smhr_Location.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Location.OPERATION = operation.Select1;
            rcmb_Location.DataSource = BLL.get_TrainingLocation(_obj_Smhr_Location);
            rcmb_Location.DataTextField = "Location_Name";
            rcmb_Location.DataValueField = "Location_ID";
            rcmb_Location.DataBind();
            rcmb_Location.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            if (string.Compare(Control, "EmployeeAttendance", true) == 0)
            {
                SMHR_COURSE _obj_Course = new SMHR_COURSE();
                _obj_Course.OPERATION = operation.Select2;
                _obj_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]); //Convert.ToInt32(Session["ORG_ID"]);
                rcmb_Course.DataSource = BLL.get_Course(_obj_Course);
                rcmb_Course.DataTextField = "COURSE_NAME";
                rcmb_Course.DataValueField = "COURSE_ID";
                rcmb_Course.DataBind();
                rcmb_Course.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LocationWiseTrainingProgram", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Course_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Course.SelectedIndex > 0)
            {
                SMHR_COURSESCHEDULE oSMHR_COURSESCHEDULE = new SMHR_COURSESCHEDULE();
                oSMHR_COURSESCHEDULE.OPERATION = operation.Course3;
                oSMHR_COURSESCHEDULE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                oSMHR_COURSESCHEDULE.COURSESCHEDULE_COURSEID = Convert.ToInt32(rcmb_Course.SelectedItem.Value);
                rcmb_batch.DataSource = BLL.get_CourseSchedule(oSMHR_COURSESCHEDULE);
                rcmb_batch.DataTextField = "CourseSchedule_Name";
                rcmb_batch.DataValueField = "CourseSchedule_ID";
                rcmb_batch.DataBind();
                rcmb_batch.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                rcmb_batch.ClearSelection();
                rcmb_batch.Items.Clear();
                rcmb_batch.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LocationWiseTrainingProgram", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Period.SelectedIndex != 0)
            {
                SMHR_PERIODDTL _obj_smhr_perioddtl = new SMHR_PERIODDTL();
                _obj_smhr_perioddtl.OPERATION = operation.Select;
                _obj_smhr_perioddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
                DataTable dt_Details = BLL.get_PeriodDetails(_obj_smhr_perioddtl);
                //DataTable dt_Details = BLL.get_PeriodDetails_Calendar(_obj_smhr_perioddtl);
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_PeriodElements.DataSource = dt_Details;
                    rcmb_PeriodElements.DataValueField = "PRDDTL_ID";
                    rcmb_PeriodElements.DataTextField = "PRDDTL_NAME";
                    rcmb_PeriodElements.DataBind();
                    rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select"));
                }
            }
            else
            {
                rcmb_PeriodElements.Items.Clear();
                rcmb_PeriodElements.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LocatinoWiseTrainingProgram", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            string RPT_NAME = string.Empty;
            if (Control != null)
            {
                if (Control == "EmployeeAttendance")
                    RPT_NAME = "Employee Attendance Details";
            }
            else
            {
                RPT_NAME = "Location Wise Training Programs";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_Location.SelectedValue) + "','" + Convert.ToString(rcmb_Course.SelectedValue) + "','" + Convert.ToString(rcmb_batch.SelectedValue) + "','" + Convert.ToString(rcmb_Period.SelectedValue) + "','" + Convert.ToString(rcmb_PeriodElements.SelectedValue) + "','" + RPT_NAME + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LocatinoWiseTrainingProgram", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_Location.SelectedIndex = 0;
            //rcmb_Course.Items.Clear();
            if (Control == "EmployeeAttendance")
            {
                rcmb_Course.Text = string.Empty;
                rcmb_Course.SelectedIndex = 0;
            }
            else
            {
                rcmb_Course.Text = string.Empty;
                rcmb_Course.Items.Clear();
            }
            rcmb_batch.Text = string.Empty;
            rcmb_batch.Items.Clear();
            rcmb_Period.SelectedIndex = 0;
            rcmb_PeriodElements.SelectedIndex = 0;
            rcmb_PeriodElements.Items.Clear();
            rcmb_PeriodElements.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LocatinoWiseTrainingProgram", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Location_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            SMHR_COURSESCHEDULE _obj_Course = new SMHR_COURSESCHEDULE();
            _obj_Course.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]); //Convert.ToInt32(Session["ORG_ID"]);
            _obj_Course.COURSESCHEDULE_LOCATIONID = Convert.ToInt32(rcmb_Location.SelectedValue);
            DataTable dt_Course = BLL.get_CourseProc(_obj_Course);
            rcmb_Course.DataSource = dt_Course;
            rcmb_Course.DataValueField = "COURSE_ID";
            rcmb_Course.DataTextField = "COURSE_NAME";
            rcmb_Course.DataBind();
            rcmb_Course.Items.Insert(0, new RadComboBoxItem("Select"));

            rcmb_batch.Items.Clear();
            rcmb_batch.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LocatinoWiseTrainingProgram", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}