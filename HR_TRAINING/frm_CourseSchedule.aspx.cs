using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class HR_TRAINING_frm_CourseSchedule : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_MASTERS _obj_Smhr_Masters;
    SMHR_TRAINING_LOCATION _obj_Smhr_Location;
    SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Course Schedule");//COURSE");
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
                    Rg_Course.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;

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
                radStartdate.MinDate = DateTime.Now;
                radEndDate.MinDate = DateTime.Now;
                lbl_CourseHeader.Visible = true;
                Page.Validate();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CourseSchedule", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            //lbl_CourseHeader.Visible = false;
            // rcmb_CC.Enabled = false;

            radBatchDetail.Enabled = false;
            clearControls();
            LoadCombos();
            SMHR_COURSESCHEDULE _obj_Smhr_CourseSchedule = new SMHR_COURSESCHEDULE();
            _obj_Smhr_CourseSchedule.COURSESCHEDULEID = Convert.ToInt32(e.CommandArgument);
            _obj_Smhr_CourseSchedule.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_CourseSchedule.OPERATION = operation.Get;
            DataTable dt = BLL.get_CourseSchedule(_obj_Smhr_CourseSchedule);
            if (dt.Rows.Count != 0)
            {
                radStartdate.MinDate = new DateTime();
                radEndDate.MinDate = new DateTime();
                LoadCombos();
                lblCourseScheduleID.Text = dt.Rows[0]["CourseSchedule_ID"].ToString();
                radBatchDetail.Text = dt.Rows[0]["CourseSchedule_Name"].ToString();
                radCourse.SelectedIndex = radCourse.FindItemIndexByValue(dt.Rows[0]["CourseSchedule_CourseID"].ToString());
                radCourse_SelectedIndexChanged(null, null);
                radCourseType.SelectedIndex = radCourseType.FindItemIndexByValue(dt.Rows[0]["CourseSchedule_CourseTypeID"].ToString());
                radLocation.SelectedIndex = radLocation.FindItemIndexByValue(dt.Rows[0]["CourseSchedule_LocationID"].ToString());
                radLocation_SelectedIndexChanged(null, null);
                radTrainingRoom.SelectedIndex = radTrainingRoom.FindItemIndexByValue(dt.Rows[0]["CourseSchedule_RoomID"].ToString());
                radTrainingRoom.Enabled = false;
                radLocation.Enabled = false;
                radTrainers.SelectedIndex = radTrainers.FindItemIndexByValue(dt.Rows[0]["CourseSchedule_TrainerID"].ToString());
                radSessions.Text = dt.Rows[0]["CourseSchedule_NoOfSessions"].ToString();
                radSeats.Text = dt.Rows[0]["CourseSchedule_NoOfSeats"].ToString();
                radStartdate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["CourseSchedule_StartDate"]);
                radStartTime.SelectedDate = Convert.ToDateTime(dt.Rows[0]["CourseSchedule_SatartTime"]);
                radEndDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["CourseSchedule_EndDate"]);
                radEndTime.SelectedDate = Convert.ToDateTime(dt.Rows[0]["CourseSchedule_EndTime"]);
                rad_IsActive.Checked = Convert.ToBoolean(dt.Rows[0]["CourseSchedule_Status"]);

                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Update.Visible = false;

                }

                else
                {
                    btn_Update.Visible = true;
                }
                Rm_Course_page.SelectedIndex = 1;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CourseSchedule", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            radLocation.Enabled = true;
            //lbl_CourseHeader.Visible = false;

            radTrainingRoom.Enabled = true;
            radBatchDetail.Enabled = true;
            clearControls();
            LoadCombos();
            btn_Save.Visible = true;
            Rm_Course_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CourseSchedule", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void LoadGrid()
    {
        try
        {
            SMHR_COURSESCHEDULE _obj_Smhr_CourseSchedule = new SMHR_COURSESCHEDULE();
            _obj_Smhr_CourseSchedule.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_CourseSchedule.OPERATION = operation.Select;
            DataTable DT = BLL.get_CourseSchedule(_obj_Smhr_CourseSchedule);
            if (DT.Rows.Count != 0)
            {
                Rg_Course.DataSource = DT;
            }

            else
            {
                DataTable dt1 = new DataTable();
                Rg_Course.DataSource = dt1;
            }
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CourseSchedule", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_Course_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CourseSchedule", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime startDate = radStartdate.SelectedDate.Value.Date;
            DateTime endDate = radEndDate.SelectedDate.Value.Date;
            double NumberOfDays = endDate.AddDays(1).Subtract(startDate).TotalDays;
            if (Convert.ToInt32(radSessions.Text) > Convert.ToInt32(NumberOfDays))
            {
                BLL.ShowMessage(this, "Please Check Number Of Days should be between Start Date and End Date");
                return;
            }


            SMHR_COURSESCHEDULE _obj_Smhr_CourseSchedule = new SMHR_COURSESCHEDULE();
            _obj_Smhr_CourseSchedule.COURSESCHEDULE_COURSEID = Convert.ToInt32(radCourse.SelectedValue);
            _obj_Smhr_CourseSchedule.COURSESCHEDULE_COURSETYPEID = Convert.ToInt32(radCourseType.SelectedValue);
            _obj_Smhr_CourseSchedule.COURSESCHEDULE_LOCATIONID = Convert.ToInt32(radLocation.SelectedValue);
            _obj_Smhr_CourseSchedule.COURSESCHEDULE_ROOMID = Convert.ToInt32(radTrainingRoom.SelectedValue);
            _obj_Smhr_CourseSchedule.COURSESCHEDULE_TRAINERID = Convert.ToInt32(radTrainers.SelectedValue);
            _obj_Smhr_CourseSchedule.COURSESCHEDULE_NOOFSESSIONS = Convert.ToInt32(radSessions.Text);
            _obj_Smhr_CourseSchedule.COURSESCHEDULE_NOOFSEATS = Convert.ToInt32(radSeats.Text);
            _obj_Smhr_CourseSchedule.COURSESCHEDULE_STARTDATE = Convert.ToDateTime(radStartdate.SelectedDate);
            _obj_Smhr_CourseSchedule.COURSESCHEDULE_SATARTTIME = Convert.ToDateTime(radStartTime.SelectedDate);
            _obj_Smhr_CourseSchedule.COURSESCHEDULE_ENDDATE = Convert.ToDateTime(radEndDate.SelectedDate);
            _obj_Smhr_CourseSchedule.COURSESCHEDULE_ENDTIME = Convert.ToDateTime(radEndTime.SelectedDate);
            _obj_Smhr_CourseSchedule.COURSESCHEDULE_NAME = radBatchDetail.Text;
            _obj_Smhr_CourseSchedule.COURSESCHEDULE_STATUS = rad_IsActive.Checked;

            _obj_Smhr_CourseSchedule.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_CourseSchedule.CREATEDDATE = DateTime.Now;
            _obj_Smhr_CourseSchedule.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_CourseSchedule.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_CourseSchedule.LASTMDFDATE = DateTime.Now;

            SMHR_TRAINING_ROOM _obj_Smhr_Room; DataTable dtRooms;
            switch (((Button)sender).ID.ToUpper())
            {

                case "BTN_SAVE":

                    _obj_Smhr_Room = new SMHR_TRAINING_ROOM();
                    _obj_Smhr_Room.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_Room.ROOMID = Convert.ToInt32(radTrainingRoom.SelectedValue);
                    _obj_Smhr_Room.SMHR_COURSESCHEDULE = new SMHR_COURSESCHEDULE();
                    _obj_Smhr_Room.SMHR_COURSESCHEDULE.COURSESCHEDULE_STARTDATE = (DateTime)radStartdate.SelectedDate;
                    _obj_Smhr_Room.SMHR_COURSESCHEDULE.COURSESCHEDULE_SATARTTIME = (DateTime)radStartTime.SelectedDate;
                    _obj_Smhr_Room.OPERATION = operation.Select1;
                    dtRooms = BLL.get_TrainingRooms(_obj_Smhr_Room);
                    if (Convert.ToBoolean(dtRooms.Rows[0]["Status"]))
                    {
                        int roomStrength = Convert.ToInt32(dtRooms.Rows[0]["ROOMS_STRENGTH"]);
                        if (Convert.ToInt32(radSeats.Text) > roomStrength)
                        {
                            BLL.ShowMessage(this, "Number of Seats should be less than or equal to " + Convert.ToString(roomStrength));
                            return;
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Selected Training Room is Already Allocated");
                        return;
                    }

                    _obj_Smhr_CourseSchedule.COURSESCHEDULE_COURSEID = Convert.ToInt32(radCourse.SelectedValue);
                    _obj_Smhr_CourseSchedule.OPERATION = operation.Check;

                    if (Convert.ToString(BLL.get_CourseSchedule(_obj_Smhr_CourseSchedule).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Course Schedule Name Already Exists");
                        return;
                    }
                    _obj_Smhr_CourseSchedule.OPERATION = operation.Insert;
                    if (BLL.set_CourseSchedule(_obj_Smhr_CourseSchedule))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;



                case "BTN_UPDATE":
                    _obj_Smhr_Room = new SMHR_TRAINING_ROOM();
                    _obj_Smhr_Room.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_Room.ROOMID = Convert.ToInt32(radTrainingRoom.SelectedValue);
                    _obj_Smhr_Room.SMHR_COURSESCHEDULE = new SMHR_COURSESCHEDULE();
                    _obj_Smhr_Room.SMHR_COURSESCHEDULE.COURSESCHEDULE_STARTDATE = (DateTime)radStartdate.SelectedDate;
                    _obj_Smhr_Room.SMHR_COURSESCHEDULE.COURSESCHEDULE_SATARTTIME = (DateTime)radStartTime.SelectedDate;
                    _obj_Smhr_Room.OPERATION = operation.Select1;
                    dtRooms = BLL.get_TrainingRooms(_obj_Smhr_Room);

                    int roomStrength1 = Convert.ToInt32(dtRooms.Rows[0]["ROOMS_STRENGTH"]);
                    if (Convert.ToInt32(radSeats.Text) > roomStrength1)
                    {
                        BLL.ShowMessage(this, "Number of Seats should be less than or equal to " + Convert.ToString(roomStrength1));
                        return;
                    }
                    _obj_Smhr_CourseSchedule.COURSESCHEDULEID = Convert.ToInt32(lblCourseScheduleID.Text);
                    if (Convert.ToBoolean(rad_IsActive.Checked) == false)
                    {
                        SMHR_COURSESCHEDULE _obj_CourseSchedule = new SMHR_COURSESCHEDULE();
                        _obj_CourseSchedule.OPERATION = operation.MODE;
                        _obj_CourseSchedule.COURSESCHEDULEID = Convert.ToInt32(lblCourseScheduleID.Text);


                        DataTable dt = BLL.get_CourseSchedule(_obj_CourseSchedule);

                        if (!Convert.ToBoolean(dt.Rows[0]["Status"]))
                        {
                            BLL.ShowMessage(this, "Cannot make inactive");
                            rad_IsActive.Checked = true;
                            return;
                        }
                    }
                    _obj_Smhr_CourseSchedule.OPERATION = operation.Update;

                    if (BLL.set_CourseSchedule(_obj_Smhr_CourseSchedule))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_Course_page.SelectedIndex = 0;
            LoadGrid();
            Rg_Course.DataBind();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CourseSchedule", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        clearControls();
    }

    private void LoadCombos()
    {
        try
        {
            SMHR_COURSE _obj_Course = new SMHR_COURSE();
            _obj_Course.OPERATION = operation.Select2;
            _obj_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"].ToString()); //Convert.ToInt32(Session["ORG_ID"]);
            radCourse.DataSource = BLL.get_Course(_obj_Course);
            radCourse.DataTextField = "COURSE_NAME";
            radCourse.DataValueField = "COURSE_ID";
            radCourse.DataBind();
            radCourse.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.MASTER_TYPE = "COURSETYPE";
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            radCourseType.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
            radCourseType.DataTextField = "HR_MASTER_CODE";
            radCourseType.DataValueField = "HR_MASTER_ID";
            radCourseType.DataBind();
            radCourseType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            _obj_Smhr_Location = new SMHR_TRAINING_LOCATION();
            _obj_Smhr_Location.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Location.OPERATION = operation.Select1;
            radLocation.DataSource = BLL.get_TrainingLocation(_obj_Smhr_Location);
            radLocation.DataTextField = "Location_Name";
            radLocation.DataValueField = "Location_ID";
            radLocation.DataBind();
            radLocation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));



        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CourseSchedule", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void radLocation_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (radLocation.SelectedIndex > 0)
            {
                SMHR_TRAINING_ROOM _obj_Smhr_Room = new SMHR_TRAINING_ROOM();
                _obj_Smhr_Room.ROOMS_LOCATION_ID = Convert.ToInt32(radLocation.SelectedValue);
                _obj_Smhr_Room.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Room.OPERATION = operation.Select2;
                radTrainingRoom.DataSource = BLL.get_TrainingRooms(_obj_Smhr_Room);
                radTrainingRoom.DataTextField = "ROOMS_NAME";
                radTrainingRoom.DataValueField = "ROOMS_ID";
                radTrainingRoom.DataBind();
                radTrainingRoom.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            }
            else
            {
                radTrainingRoom.Items.Clear();
                radTrainingRoom.ClearSelection();
                radTrainingRoom.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CourseSchedule", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void clearControls()
    {
        try
        {
            radBatchDetail.Text = string.Empty;
            radCourse.Text = string.Empty;
            radCourseType.Text = string.Empty;
            radLocation.Text = string.Empty;
            radTrainingRoom.Text = string.Empty;
            radTrainers.Text = string.Empty;
            radSessions.Text = string.Empty;
            radSeats.Text = string.Empty;
            radStartdate.SelectedDate = null;
            radStartTime.SelectedDate = null;
            radEndDate.SelectedDate = null;
            radEndTime.SelectedDate = null;
            radTrainers.Items.Clear();
            radTrainingRoom.Items.Clear();
            radTrainingRoom.ClearSelection();

            btn_Save.Visible = false;
            btn_Update.Visible = false;
            Rm_Course_page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CourseSchedule", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void radCourse_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            SMHR_TRAINERPROFILE _obj_smhr_Trainerprofile = new SMHR_TRAINERPROFILE();
            _obj_smhr_Trainerprofile.TRAINER_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_Trainerprofile.Trainer_CourseCategory = Convert.ToInt32(radCourse.SelectedValue);
            _obj_smhr_Trainerprofile.OPERATION = operation.Select2;
            radTrainers.DataSource = BLL.get_TrainingProfile(_obj_smhr_Trainerprofile);
            radTrainers.DataTextField = "Trainer_Name";
            radTrainers.DataValueField = "Trainer_TrainerProfile_ID";
            radTrainers.DataBind();
            radTrainers.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CourseSchedule", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
