using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;
using SPMS;
using System.Text;
public partial class HR_TRAINING_frm_AttendanceDetails : System.Web.UI.Page
{
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Training Attendance Details");//TRAINING APPROVAL");
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
                    RG_TrainingApproval.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_submit.Visible = false;
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
                LoadCombos();
                //LoadData();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

        //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){ }", true);
    }


    private void LoadCombos()
    {

        btn_submit.Visible = false;
        Btn_cancel.Visible = false;
        RG_TrainingApproval.Visible = false;

        try
        {
            SMHR_COURSE _obj_Course = new SMHR_COURSE();
            _obj_Course.OPERATION = operation.Select2;
            _obj_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            rc_Course.DataSource = BLL.get_Course(_obj_Course);
            rc_Course.DataTextField = "COURSE_NAME";
            rc_Course.DataValueField = "COURSE_ID";
            rc_Course.DataBind();
            rc_Course.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            rc_CourseSchedule.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            rc_Days.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Apply_Command(object sender, CommandEventArgs e)
    {
        try
        {
            SMHR_TRAINING_REQUST _obj_Smhr_TrgRqst = new SMHR_TRAINING_REQUST();
            _obj_Smhr_TrgRqst.TRAINING_REQUST_ID = Convert.ToInt32(e.CommandArgument);
            _obj_Smhr_TrgRqst.OPERATION = operation.Update;
            _obj_Smhr_TrgRqst.TRAINING_APPROVEDBY = Convert.ToInt32(Session["EMP_ID"]);
            _obj_Smhr_TrgRqst.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_TrgRqst.LASTMDFDATE = DateTime.Now;
            switch (((LinkButton)sender).ID.ToUpper())
            {
                case "LNK_APPLY":
                    _obj_Smhr_TrgRqst.TRAINING_ISAPPROVED = 1;
                    _obj_Smhr_TrgRqst.OPERATION = operation.Check;
                    if (string.Compare(Convert.ToString(BLL.get_TrainigRequest(_obj_Smhr_TrgRqst).Rows[0][0]), "1", true) == 0)
                    {
                        BLL.ShowMessage(this, "There is No Vacancy for this Training");
                        return;
                    }
                    _obj_Smhr_TrgRqst.OPERATION = operation.Update;
                    if (BLL.set_TrainigRequest(_obj_Smhr_TrgRqst))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                case "LNK_REJECT":
                    _obj_Smhr_TrgRqst.TRAINING_ISAPPROVED = 2;
                    if (BLL.set_TrainigRequest(_obj_Smhr_TrgRqst))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }


    private void Load_Schedule()
    {


    }


    protected void radCourse_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            btn_submit.Visible = false;
            Btn_cancel.Visible = false;
            RG_TrainingApproval.Visible = false;

            rc_Days.SelectedIndex = -1;
            rc_Days.Items.Clear();
            rc_CourseSchedule.Items.Clear();
            rc_CourseSchedule.SelectedIndex = -1;
            RG_TrainingApproval.Visible = false;
            if (string.Compare(rc_Course.SelectedItem.Text, "Select", true) != 0)
            {
                SMHR_COURSESCHEDULE _obj_Smhr_TrgRqst = new SMHR_COURSESCHEDULE();
                _obj_Smhr_TrgRqst.OPERATION = operation.Select3;
                _obj_Smhr_TrgRqst.COURSESCHEDULE_COURSEID = Convert.ToInt32(rc_Course.SelectedValue);
                _obj_Smhr_TrgRqst.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);//YYY
                rc_CourseSchedule.DataSource = BLL.get_CourseSchedule(_obj_Smhr_TrgRqst);
                rc_CourseSchedule.DataValueField = "CourseSchedule_ID";
                rc_CourseSchedule.DataTextField = "CourseSchedule_Name";
                rc_CourseSchedule.DataBind();
                rc_CourseSchedule.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                Load_Days();

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void BindCourseCategory()
    {
        try
        {
            SMHR_COURSE _obj_Course = new SMHR_COURSE();
            _obj_Course.OPERATION = operation.Select;
            _obj_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            rc_Course.DataSource = BLL.get_Course(_obj_Course);
            rc_Course.DataTextField = "COURSE_NAME";
            rc_Course.DataValueField = "COURSE_ID";
            rc_Course.DataBind();
            rc_Course.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void clearControls()
    {
        try
        {
            rc_Course.SelectedIndex = -1;
            rc_CourseSchedule.Items.Clear();
            rc_Days.Items.Clear();
            rc_Days.SelectedIndex = -1;

            rc_CourseSchedule.SelectedIndex = -1;

            RG_TrainingApproval.Visible = false;
            btn_submit.Visible = false;
            Btn_cancel.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void Load_Days()
    {


    }

    protected void rc_CourseSchedule_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rc_CourseSchedule.SelectedIndex > 0)
            {
                rc_Days.SelectedIndex = -1;
                rc_Days.Items.Clear();
                Btn_cancel.Visible = false;
                btn_submit.Visible = false;
                RG_TrainingApproval.Visible = false;
                SMHR_COURSESCHEDULE _obj_Smhr_TrgRqst = new SMHR_COURSESCHEDULE();
                _obj_Smhr_TrgRqst.OPERATION = operation.Select4;
                _obj_Smhr_TrgRqst.COURSESCHEDULEID = Convert.ToInt32(rc_CourseSchedule.SelectedValue);
                DataTable dt = BLL.get_CourseSchedule(_obj_Smhr_TrgRqst);

                int noOfDays = Convert.ToInt32(dt.Rows[0]["CourseSchedule_NoOfSessions"]);
                if (noOfDays > 0)
                {
                    List<Days> lstDays = new List<Days>();
                    Days d = new Days();
                    d.DayID = 0; d.DayName = "Select";
                    lstDays.Add(d);
                    for (int i = 1; i <= noOfDays; i++)
                    {
                        d = new Days();
                        d.DayID = i;
                        d.DayName = "Day " + i.ToString();
                        lstDays.Add(d);
                    }

                    rc_Days.DataSource = lstDays.ToArray();
                    rc_Days.DataValueField = "DayID";
                    rc_Days.DataTextField = "DayName";
                    rc_Days.DataBind();
                }
            }
            else
            {
                rc_Days.Items.Clear();
                RG_TrainingApproval.Visible = false;
                Btn_cancel.Visible = false;
                btn_submit.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void rc_Days_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            Btn_cancel.Visible = true;
            btn_submit.Visible = true;
            RG_TrainingApproval.Visible = true;

            try
            {
                SMHR_TRAINING_REQUST _obj_Smhr_TrgRqst = new SMHR_TRAINING_REQUST();
                _obj_Smhr_TrgRqst.OPERATION = operation.Select2;
                _obj_Smhr_TrgRqst.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_TrgRqst.TRAINING_BATCHID = Convert.ToInt32(rc_CourseSchedule.SelectedValue);
                _obj_Smhr_TrgRqst.TRAINING_ATTENDANCE_DAYS = Convert.ToInt32(rc_Days.SelectedValue);
                DataTable DT = BLL.get_TrainigRequest(_obj_Smhr_TrgRqst);
                if (DT.Rows.Count != 0)
                {
                    RG_TrainingApproval.DataSource = DT;
                }

                else
                {
                    DataTable dt1 = new DataTable();
                    RG_TrainingApproval.DataSource = dt1;
                }
                RG_TrainingApproval.DataBind();
            }
            catch (Exception ex)
            {
                SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Course", ex.StackTrace, DateTime.Now);
                Response.Redirect("~/Frm_ErrorPage.aspx");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {

        try
        {
            if (RG_TrainingApproval.Items.Count <= 0)
            {
                BLL.ShowMessage(this, "No employee to Save");
                return;
            }
            StringBuilder empIDs = new StringBuilder();

            SMHR_TRAINING_ATTENDANCE _obj_attend = new SMHR_TRAINING_ATTENDANCE();

            _obj_attend.OPERATION = operation.Insert;
            _obj_attend.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_attend.TRAINING_ATTENDANCE_COURSESCHEDULE_ID = Convert.ToInt32(rc_CourseSchedule.SelectedValue);
            //string daySlctd = Convert.ToString(rc_Days.SelectedValue);
            //daySlctd = daySlctd.Replace("Day ", "");
            _obj_attend.TRAINING_ATTENDANCE_DAYS = Convert.ToInt32(rc_Days.SelectedValue);
            CheckBox rad_IsActive; Label lblRqstID;
            for (int index = 0; index < RG_TrainingApproval.Items.Count; index++)
            {
                rad_IsActive = new CheckBox();
                rad_IsActive = RG_TrainingApproval.Items[index].FindControl("rad_IsActive") as CheckBox;

                if (rad_IsActive.Checked)
                {
                    lblRqstID = new Label();
                    lblRqstID = RG_TrainingApproval.Items[index].FindControl("lblRqstID") as Label;
                    empIDs.Append(lblRqstID.Text + ",");
                }
            }

            if (string.IsNullOrEmpty(empIDs.ToString()))
            {
                BLL.ShowMessage(this, "Please select atleast one employee to mark attendance");
                return;
            }
            else
            {
                _obj_attend.TRAINING_ATTENDANCE_EMPLOYEE_ID = Convert.ToString(empIDs.ToString().Remove(empIDs.Length - 1));

                if (BLL.Set_TrainingAttendance(_obj_attend))
                {
                    BLL.ShowMessage(this, "Information Saved Successfully");
                    clearControls();
                }
                else
                {
                    BLL.ShowMessage(this, "Information Not Saved");
                    clearControls();
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
    protected void Btn_cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rc_Course.SelectedIndex = -1;
            rc_CourseSchedule.Items.Clear();
            rc_Days.Items.Clear();
            rc_Days.SelectedIndex = -1;
            btn_submit.Visible = false;
            Btn_cancel.Visible = false;
            RG_TrainingApproval.Visible = false;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }



    }
}
public class Days
{
    private int _dayID;

    public int DayID
    {
        get { return _dayID; }
        set { _dayID = value; }
    }
    private string _dayName;

    public string DayName
    {
        get { return _dayName; }
        set { _dayName = value; }
    }
}