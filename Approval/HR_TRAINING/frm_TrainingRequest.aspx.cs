using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SPMS;
using SMHR;
using Telerik.Web.UI;

public partial class Training_frm_TrainingRequest : System.Web.UI.Page
{
    SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst;
    //SMHR_RESOURCES _obj_Smhr_Resource;
    SMHR_MASTERS _obj_Smhr_Masters=new SMHR_MASTERS();
  static  DataTable dtreso1 = new DataTable();

  
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
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("TRAINING REQUEST");
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
                Rg_Tarining.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;

                Rg_Tarining.Enabled = false;

            }
            else
            {
                Rg_Tarining.Enabled = true;
            }

            LoadGrid();
            ClearTraining();
            Loadresourcetraining();
            //Loadtraineetraining();
            Loadcalendertraining();
            rtp_starttime.SelectedDate = null;
            rtp_endtime.SelectedDate = null;
            rdtp_strtdate.SelectedDate = null;
            //rdtp_enddate.SelectedDate = null;
            pnl_daily.Visible = false;
            pnl_weekly.Visible = false;
            pnl_monthly.Visible = false;
            pnl_yearly.Visible = false;
            rfv_rlistbox.Visible = false;
           
            Rm_Training_PAGE.SelectedIndex = 0;
            Rm_Trainingrequest_PAGE1.SelectedIndex = 0;


        }
        Page.Validate();

        }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }

    protected void rtp_starttime_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
        DateTime strttime = new DateTime();
        DateTime endtime = new DateTime();
        if (rtp_endtime.SelectedDate.HasValue)
        {
            strttime = rtp_starttime.SelectedDate.Value;
            endtime = rtp_endtime.SelectedDate.Value;

            if (endtime < strttime)
            {
                rtp_starttime.SelectedDate = null;
                //rtxt_duration.Text = string.Empty;
                BLL.ShowMessage(this, "Start Time Should Be Lesser End Time");
                return;
               
            }
            else
            {
                TimeSpan dur = endtime.Subtract(strttime);
                //rtxt_duration.Text = Convert.ToString(dur.TotalMinutes);

            }

        }
         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }

    }
    protected void rtp_endtime_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {

        DateTime strttime = new DateTime();
        DateTime endtime = new DateTime();

        if (rtp_starttime.SelectedDate.HasValue)
        {
            strttime = rtp_starttime.SelectedDate.Value;
            endtime = rtp_endtime.SelectedDate.Value;
            if (endtime >= strttime)
            {
                TimeSpan dur = endtime.Subtract(strttime);
                //rtxt_duration.Text = Convert.ToString(dur.TotalMinutes);
            }
            else
            {
                rtp_endtime.SelectedDate = null;
                //rtxt_duration.Text = string.Empty;
                BLL.ShowMessage(this, "End Time Should Be Greater Start Time");
                return;
            }

        }
        else
        {
            BLL.ShowMessage(this, "Please Select Start Time");
            return;
        }
         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }

    }
    protected void rbtnlist_recuerence_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        if (rbtnlist_recuerence_id.SelectedItem.Value == "0")
        {
            pnl_monthly.Visible = false;
            pnl_weekly.Visible = false;
            pnl_yearly.Visible = false;
          pnl_daily.Visible = true;

        }
        else if (rbtnlist_recuerence_id.SelectedItem.Value == "1")
        {
            pnl_monthly.Visible = false;
            pnl_yearly.Visible = false;
            pnl_daily.Visible = false;
            pnl_weekly.Visible = true;
            if (rdtp_strtdate.SelectedDate.HasValue)
            {
                DateTime strt = rdtp_strtdate.SelectedDate.Value;
                //string s = strt.Day.ToString();
                string s = rdtp_strtdate.SelectedDate.Value.DayOfWeek.ToString();
                //lbl_StartDate.Text = s;
                if (s == "Sunday")
                {
                    chk_Sunday.Checked = true;
                    chk_monday.Checked = false;
                    chk_Tuesday.Checked = false;
                    chk_Wednesday.Checked = false;
                    chk_Thursday.Checked = false;
                    chk_Friday.Checked = false;
                    chk_Saturday.Checked = false;
                }
                else if (s == "Monday")
                {
                    chk_Sunday.Checked = false;
                    chk_monday.Checked = true;
                    chk_Tuesday.Checked = false;
                    chk_Wednesday.Checked = false;
                    chk_Thursday.Checked = false;
                    chk_Friday.Checked = false;
                    chk_Saturday.Checked = false;
                }
                else if (s == "Tuesday")
                {
                    chk_Sunday.Checked = false;
                    chk_monday.Checked = false;
                    chk_Tuesday.Checked = true;
                    chk_Wednesday.Checked = false;
                    chk_Thursday.Checked = false;
                    chk_Friday.Checked = false;
                    chk_Saturday.Checked = false;
                }
                else if (s == "Wednesday")
                {
                    chk_Sunday.Checked = false;
                    chk_monday.Checked = false;
                    chk_Tuesday.Checked = false;
                    chk_Wednesday.Checked = true;
                    chk_Thursday.Checked = false;
                    chk_Friday.Checked = false;
                    chk_Saturday.Checked = false;
                }
                else if (s == "Thursday")
                {
                    chk_Sunday.Checked = false;
                    chk_monday.Checked = false;
                    chk_Tuesday.Checked = false;
                    chk_Wednesday.Checked = false;
                    chk_Thursday.Checked = true;
                    chk_Friday.Checked = false;
                    chk_Saturday.Checked = false;
                }
                else if (s == "Friday")
                {
                    chk_Sunday.Checked = false;
                    chk_monday.Checked = false;
                    chk_Tuesday.Checked = false;
                    chk_Wednesday.Checked = false;
                    chk_Thursday.Checked = false;
                    chk_Friday.Checked = true;
                    chk_Saturday.Checked = false;
                }
                else if (s == "Saturday")
                {
                    chk_Sunday.Checked = false;
                    chk_monday.Checked = false;
                    chk_Tuesday.Checked = false;
                    chk_Wednesday.Checked = false;
                    chk_Thursday.Checked = false;
                    chk_Friday.Checked = false;
                    chk_Saturday.Checked = true;
                }
                else if (s == string.Empty)
                {
                    chk_Sunday.Checked = false;
                    chk_monday.Checked = false;
                    chk_Tuesday.Checked = false;
                    chk_Wednesday.Checked = false;
                    chk_Thursday.Checked = false;
                    chk_Friday.Checked = false;
                    chk_Saturday.Checked = false;
                }
            }
            else
            {
                chk_Sunday.Checked = false;
                chk_monday.Checked = false;
                chk_Tuesday.Checked = false;
                chk_Wednesday.Checked = false;
                chk_Thursday.Checked = false;
                chk_Friday.Checked = false;
                chk_Saturday.Checked = false;

            }
        }

        else if (rbtnlist_recuerence_id.SelectedItem.Value == "2")
        {
            pnl_monthly.Visible = true;
            pnl_yearly.Visible = false;
            pnl_daily.Visible = false;
            pnl_weekly.Visible = false;
            if (rdtp_strtdate.SelectedDate.HasValue)
            {
                DateTime strt = rdtp_strtdate.SelectedDate.Value;
                string s = strt.Day.ToString();


                txt_monthly_id.Text = s;


            }
            else
            {
                txt_monthly_id.Text = string.Empty;

            }
            if (rdtp_strtdate.SelectedDate.HasValue)
            {
                DateTime strt = rdtp_strtdate.SelectedDate.Value;
                //string s = strt.Day.ToString();
                string s = rdtp_strtdate.SelectedDate.Value.DayOfWeek.ToString();

                ddl_monthly_id2.SelectedItem.Text = s;
            }
            else
            {
                ddl_monthly_id2.SelectedItem.Text = "Sunday";
            }

        }
        else if (rbtnlist_recuerence_id.SelectedItem.Value == "3")
        {
            pnl_monthly.Visible = false;
            pnl_yearly.Visible = true;
            pnl_daily.Visible = false;
            pnl_weekly.Visible = false;
            if (rdtp_strtdate.SelectedDate.HasValue)
            {
                DateTime strt = rdtp_strtdate.SelectedDate.Value;
                string s = strt.Day.ToString();

                //lbl_StartDate.Text = s;
                txt_yearly_id.Text = s;

            }
            else
            {
                txt_yearly_id.Text = string.Empty;
            }
            if (rdtp_strtdate.SelectedDate.HasValue)
            {
                DateTime strt1 = rdtp_strtdate.SelectedDate.Value;
                string i = strt1.Month.ToString();
                ddl_yearly_id2.SelectedIndex = Convert.ToInt32(i);
                ddl_yearly_id4.SelectedIndex = Convert.ToInt32(i);
            }
            else
            {
                ddl_yearly_id2.SelectedIndex = 0;
                ddl_yearly_id4.SelectedIndex = 0;
            }
            if (rdtp_strtdate.SelectedDate.HasValue)
            {
                DateTime strt = rdtp_strtdate.SelectedDate.Value;
                //string s = strt.Day.ToString();
                string s = rdtp_strtdate.SelectedDate.Value.DayOfWeek.ToString();

                ddl_yearly_id.SelectedItem.Text = s;
            }
            else
            {
                ddl_yearly_id.SelectedItem.Text = "Sunday";
            }

        }
         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }
    //protected void btn_ok_id_Click(object sender, EventArgs e)
    //{
    //    DateTime strt = rdtp_strtdate.SelectedDate.Value;
    //    string s = strt.Day.ToString();

    //    lbl_StartDate.Text = s;

    //    DateTime strt1 = rdtp_strtdate.SelectedDate.Value;
    // string i=   strt1.Month.ToString();

    //}

    //protected void rdtp_strtdate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    //{
    //    //if (rdtp_enddate.SelectedDate.HasValue)
    //    //{
    //    //    DateTime strtdate = rdtp_strtdate.SelectedDate.Value;

    //    //    DateTime enddate = rdtp_enddate.SelectedDate.Value;

    //    //    if (enddate < strtdate)
    //    //    {
    //    //        Pms_Bll.ShowMessage(this, "Start Date Should Be Lesser End Date");
    //    //        rdtp_strtdate.SelectedDate = null;

    //    //    }

    //    //}
    //    //else
    //    //{
    //    //    DateTime strtdate = rdtp_strtdate.SelectedDate.Value;

    //    //}


    //}
    //protected void rdtp_enddate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    //{
    //    if (rdtp_strtdate.SelectedDate.HasValue)
    //    {
    //        DateTime strtdate = rdtp_strtdate.SelectedDate.Value;

    //        DateTime enddate = rdtp_enddate.SelectedDate.Value;
    //        if (enddate < strtdate)
    //        {
    //            Pms_Bll.ShowMessage(this, "End Date Should Be Greater Start Date");
    //            rdtp_enddate.SelectedDate = null;

    //        }

    //    }
    //    else
    //    {
    //        rdtp_enddate.Clear();
    //        Pms_Bll.ShowMessage(this, "Please Enter Start Date");
    //        return;
           

    //    }
    //}

    #region load resources

    protected void Loadresources()
    {
        try
        {
        rcm_resource.Items.Clear();
        SMHR_MASTERS _obj_Smhr_Masters = new SMHR_MASTERS();
        _obj_Smhr_Masters.OPERATION = operation.Approve;
      
        _obj_Smhr_Masters.HR_MASTER_ORGANISATION_ID= Convert.ToInt32(Session["ORG_ID"]);
        DataTable dt = BLL.get_MasterRecords(_obj_Smhr_Masters);

        rcm_resource.DataSource = dt;
        rcm_resource.DataTextField = "HR_MASTER_CODE";
        rcm_resource.DataValueField = "HR_MASTER_ID";
        rcm_resource.DataBind();
        rcm_resource.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
       }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }

    }

    #endregion
    #region Add Command

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {

        Rm_Training_PAGE.SelectedIndex = 1;



        var tabNewYork = rdtstrp.FindTabByText("TrainingSchedule");

        tabNewYork.Enabled = false;


        var tabNewYork1 = rdtstrp.FindTabByText("Training");

        tabNewYork1.Enabled = false;

        Rm_Trainingrequest_PAGE1.SelectedIndex = 0;
        btn_Save.Visible = true;
        btn_cancel.Visible = true;
        btn_Save.Text = "Save";
        btn_cancel.Text = "Cancel";
        rtxt_title.Enabled = true;
        rcmb_CourseType.Items.Clear();
        rcmb_Course.Items.Clear();
        _obj_Smhr_Masters.MASTER_TYPE = "COURSE";
        _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        rcmb_Course.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
        rcmb_Course.DataTextField = "HR_MASTER_CODE";
        rcmb_Course.DataValueField = "HR_MASTER_ID";
        rcmb_Course.DataBind();
        rcmb_Course.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        Loadresourcetraining();
        LoadBusinessUnit();
        LoadTraingtrgname();
        //Loadtrainee();
        //Loadtraineetraining();
        rtxt_title.Text = string.Empty;
        rtxt_Location.Text = string.Empty;
        rtxt_Description.Text = string.Empty;
        rcmb_Status.SelectedIndex = 0;
        rcmb_CourseType.Enabled = true;
        rcmb_Course.Enabled = true;
        rcmb_Status.Enabled = true;
        //rcmb_Trainer.Enabled = true;
        rcmb_TRGType.SelectedIndex = 0;
        rcm_resource.SelectedIndex = 0;
        ClearTraining();
        panel_internal.Visible = false;
        panel_external.Visible = false;
        pnl_ext1.Visible = false;
        rdtstrp.SelectedIndex = 0;
        RadListBoxDestination.Items.Clear();
        rdlist_trainee.Visible = false;
        RadListBoxDestination.Visible = false;
        btn_save_traineelist.Visible = false;
        btn_cancel_traineelist.Visible = false;
        rcmb_Status.SelectedIndex = 1;
        btn_updatetrgrequest.Visible = false;
        btn_update_calender.Visible = false;
        rcmb_Status.SelectedItem.Text = "Pending";
        rcmb_Status.Enabled = false;
          }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }


    protected void ClearTraining()
    {
        try
        {
            //clears all controls
            rcmb_BusinessUnitType.Visible = false;
            rcmb_EmployeeType.Visible = false;
            lbl_BusinessUnitName.Visible = false;
            lbl_Employee.Visible = false;
            LBL_ORGANISATION.Visible = false;
            lbl_Employees.Visible = false;
            lbl_Designation.Visible = false;
            LBL_TRGINSTITUTE.Visible = false;
            lbl_address.Visible = false;
            lbl_PHONENO.Visible = false;
            lbl_ContactPerson.Visible = false;
            lbl_faculty.Visible = false;
            rtxt_address.Visible = false;
            rtxt_Employee.Visible = false;
            rtxt_Organisation.Visible = false;
            rtxt_Designation.Visible = false;
            rtxt_TrainingInstitute.Visible = false;
            rmtxt_phoneno.Visible = false;
            rtxt_contactperson.Visible = false;
            rtxt_Faculty.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }




    #endregion

    #region LoadCourse
    /// <summary>
    /// HERE I AM LOADING Goals DETAILS FROM PREVIOUS GOAL SETTING DETAILS TABLE
    /// </summary>

    protected void LoadCourse()
    {
        try
        {
        rcmb_CourseType.Items.Clear();
        SMHR_COURSE _obj_Smhr_Course = new SMHR_COURSE();
        _obj_Smhr_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
        _obj_Smhr_Course.OPERATION = operation.Select;
        DataTable dt = BLL.get_Course(_obj_Smhr_Course);
        rcmb_CourseType.DataSource = dt;
        rcmb_CourseType.DataTextField = "COURSE_NAME";
        rcmb_CourseType.DataValueField = "COURSE_ID";
        rcmb_CourseType.DataBind();
        rcmb_CourseType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        _obj_Smhr_Masters = new SMHR_MASTERS();
        //Load PayItem Type
       

         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }

    }
    protected void Loadresourcetraining()
    {
        try
        {
        rcm_resource_trg.Items.Clear();
        _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
        _obj_Smhr_TrgRqst.Mode = 10;
        _obj_Smhr_TrgRqst.TR_RAISEDBY = Convert.ToInt32(Session["EMP_ID"]);

        _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
        DataTable dt = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
        rcm_resource_trg.DataSource = dt;
        rcm_resource_trg.DataTextField = "TR_TITLE";
        rcm_resource_trg.DataValueField = "TR_ID";
        rcm_resource_trg.DataBind();
        rcm_resource_trg.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
          }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }


    }
    protected void LoadTraingtrgname()
    {
        try
        {
        rcm_trg_Traingname.Items.Clear();
        _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
        _obj_Smhr_TrgRqst.Mode = 10;
        _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
        _obj_Smhr_TrgRqst.TR_RAISEDBY = Convert.ToInt32(Session["EMP_ID"]);

        DataTable dt = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
        rcm_trg_Traingname.DataSource = dt;
        rcm_trg_Traingname.DataTextField = "TR_TITLE";
        rcm_trg_Traingname.DataValueField = "TR_ID";
        rcm_trg_Traingname.DataBind();
        rcm_trg_Traingname.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }


    protected void Loadtraineetraining()
    {
        try
        {
        //Rcmb_training.Items.Clear();
        //_obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
        //_obj_Smhr_TrgRqst.Mode = 11;
        //_obj_Smhr_TrgRqst.BUID = Convert.ToInt32(rcm_bu_trainee.SelectedItem.Value);
        //DataTable dt = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
        //Rcmb_training.DataSource = dt;
        //Rcmb_training.DataTextField = "TR_TITLE";
        //Rcmb_training.DataValueField = "TR_ID";
        //Rcmb_training.DataBind();
        //Rcmb_training.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        rcm_trg_calender.Items.Clear();
        _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
        _obj_Smhr_TrgRqst.Mode = 10;
        _obj_Smhr_TrgRqst.TR_RAISEDBY = Convert.ToInt32(Session["EMP_ID"]);

        _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
        DataTable dt = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
        Rcmb_training.DataSource = dt;
        Rcmb_training.DataTextField = "TR_TITLE";
        Rcmb_training.DataValueField = "TR_ID";
        Rcmb_training.DataBind();
        Rcmb_training.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
    catch (Exception ex)
    {
        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
        Response.Redirect("~/Frm_ErrorPage.aspx");
    }

    }
    protected void Loadcalendertraining()
    {
        try
        {
        rcm_trg_calender.Items.Clear();
        _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
        _obj_Smhr_TrgRqst.Mode = 10;
        _obj_Smhr_TrgRqst.TR_RAISEDBY = Convert.ToInt32(Session["EMP_ID"]);

        _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
        DataTable dt = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
        rcm_trg_calender.DataSource = dt;
        rcm_trg_calender.DataTextField = "TR_TITLE";
        rcm_trg_calender.DataValueField = "TR_ID";
        rcm_trg_calender.DataBind();
        rcm_trg_calender.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }
    protected void LoadBusinessUnit()
    {
        try
        {

            rcmb_BusinessUnitType.Items.Clear();
            SMHR_BUSINESSUNIT _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();


            SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            if (dt_BUDetails.Rows.Count != 0)
            {
                rcmb_BusinessUnitType.DataSource = dt_BUDetails;
                rcmb_BusinessUnitType.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BusinessUnitType.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BusinessUnitType.DataBind();
                rcmb_BusinessUnitType.Items.Insert(0, new RadComboBoxItem("Select"));
            }

            else
            {
                DataTable dt_Details = new DataTable();
                rcmb_BusinessUnitType.DataSource = dt_BUDetails;

                rcmb_BusinessUnitType.DataBind();
                rcmb_BusinessUnitType.Items.Insert(0, new RadComboBoxItem("Select"));
            }
      
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadBusinessUnitTrainee()
    {
        try
        {
            rcm_bu_trainee.Items.Clear();
      

        SMHR_BUSINESSUNIT _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();


        SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
        _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
        DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
        if (dt_BUDetails.Rows.Count != 0)
        {
            rcm_bu_trainee.DataSource = dt_BUDetails;
            rcm_bu_trainee.DataValueField = "BUSINESSUNIT_ID";
            rcm_bu_trainee.DataTextField = "BUSINESSUNIT_CODE";
            rcm_bu_trainee.DataBind();
            rcm_bu_trainee.Items.Insert(0, new RadComboBoxItem("Select"));
        }

        else
        {
            DataTable dt_Details = new DataTable();
            rcm_bu_trainee.DataSource = dt_BUDetails;

            rcm_bu_trainee.DataBind();
            rcm_bu_trainee.Items.Insert(0, new RadComboBoxItem("Select"));
        }

     
         }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion


    //protected void Loadtrainee()
    //{

    //    SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
    //    _obj_smhr_employee.OPERATION = operation.Select;
    //    DataTable dt = BLL.get_Employee(_obj_smhr_employee);
    //    rdlist_trainee.DataSource = dt;
    //    rdlist_trainee.DataTextField = "EMPNAME";
    //    rdlist_trainee.DataValueField = "EMP_ID";
    //    rdlist_trainee.DataBind();

    //}
    #region LoadGrid
    /// <summary>
    /// Here DataNeedSource Is Used To Bind Data To Grid 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>

    protected void Rg_Trg_NeedDatasource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {

            _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
            _obj_Smhr_TrgRqst.Mode = 1;
            _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_TrgRqst.TR_RAISEDBY = Convert.ToInt32(Session["EMP_ID"]);
            DataTable dt = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
            if (dt.Rows.Count != 0)
            {
                Rg_Tarining.DataSource = dt;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    /// <summary>
    ///In This Data Binding From Database To Datatable Binding to Radgrid
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>

    protected void LoadGrid()
    {
        try
        {

            _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
            _obj_Smhr_TrgRqst.Mode = 1;
            _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_TrgRqst.TR_RAISEDBY = Convert.ToInt32(Session["EMP_ID"]);

            DataTable dt = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
            if (dt.Rows.Count != 0)
            {
                Rg_Tarining.DataSource = dt;
                Rg_Tarining.DataBind();
            }
            else
            {
                DataTable dt1 = new DataTable();
                Rg_Tarining.DataSource = dt1;
                Rg_Tarining.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion










    #region EditCommand


    /// <summary>
    ///IN THIS BASED ON (COMMANDARGUMENT) ALL DATA WILL BE TAKEN TO DATATABLE THEN WE CAN BIND TO INDIVIDUAL FIELDS
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>

    protected void lnk_edit_command(object sender, CommandEventArgs e)
    {
        try
        {

            _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
            _obj_Smhr_TrgRqst.Mode = 15;
            _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            DataTable DT45 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
            if ((Convert.ToString(DT45.Rows[0]["TR_STATUS"]) == "Approved") || (Convert.ToString(DT45.Rows[0]["TR_STATUS"]) == "Rejected"))
            {

                BLL.ShowMessage(this, "Training  Cant Edited");
                return;
            }
            else
            {
                lbl_Tr_Id.Text = Convert.ToString(e.CommandArgument);

                _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                _obj_Smhr_TrgRqst.Mode = 7;
                _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));


                DataTable DT = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);


                _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                _obj_Smhr_TrgRqst.Mode = 12;
                _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
                DataTable DT23 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);



                if (DT.Rows.Count != 0)
                {

                    lbl_Tr_Id.Text = Convert.ToString(DT.Rows[0]["TR_ID"]);


                    rtxt_title.Text = Convert.ToString(DT.Rows[0]["TR_TITLE"]);
                    rtxt_Location.Text = Convert.ToString(DT.Rows[0]["TR_LOCATION"]);
                    rtxt_Description.Text = Convert.ToString(DT.Rows[0]["TR_DESCRIPTION"]);
                    LoadCourse();
                    rcmb_CourseType.SelectedIndex = rcmb_CourseType.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["TR_COURSEID"]));
                    // 

                    //rcmb_Trainer.SelectedIndex = rcmb_Trainer.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["TR_TRAINERDETAILSID"]));


                    rcmb_Status.SelectedItem.Text = Convert.ToString(DT.Rows[0]["TR_STATUS"]);
                    rcmb_Course.Enabled = false;
                    rcmb_CourseType.Enabled = false;
                    rcmb_Status.Enabled = false;
                    btn_updatetrgrequest.Visible = true;
                    btn_cancel.Visible = true;
                    btn_Save.Visible = false;

                    rtxt_title.Enabled = false;
                     if (Convert.ToString(DT.Rows[0]["TRAINERDETAILS_EMPLOYEEID"]) != string.Empty)
                    {
                        if (Convert.ToInt32(DT.Rows[0]["TRAINERDETAILS_EMPLOYEEID"]) != 0)
                        {
                            rcmb_TRGType.SelectedItem.Text = "Internal Trainer";
                            rcmb_TRGType.Enabled = false;


                            if (DT.Rows[0]["TRAINERDETAILS_TR_ID"] != System.DBNull.Value)
                            {
                                LoadTraingtrgname();
                                rcm_trg_Traingname.SelectedIndex = rcm_trg_Traingname.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["TRAINERDETAILS_TR_ID"]));
                                rcm_trg_Traingname.Enabled = false;
                            }
                            else
                            {
                                LoadTraingtrgname();
                                rcm_trg_Traingname.SelectedIndex = 0;
                                rcm_trg_Traingname.Enabled = true;
                            }
                            if (DT.Rows[0]["TRAINERDETAILS_BUSINESSUNITID"] != System.DBNull.Value)
                            {

                                LoadBusinessUnit();
                                rcmb_BusinessUnitType.SelectedIndex = rcmb_BusinessUnitType.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["TRAINERDETAILS_BUSINESSUNITID"]));
                                rcmb_BusinessUnitType.Enabled = false;
                            }
                            else
                            {
                                LoadBusinessUnit();
                                rcmb_BusinessUnitType.SelectedIndex = 0;
                                rcmb_BusinessUnitType.Enabled = true;


                            }

                       

                        rcmb_EmployeeType.Items.Clear();

                        SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
                        _obj_Smhr_BusinessUnit.OPERATION = operation.SELECTEMPLOYEE;
                        _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        //rcmb_BU.DataSource = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
                        _obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                        DataTable dtemp = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
                        rcmb_EmployeeType.DataSource = dtemp;

                        //Cur = Convert.ToString(dtemp.Rows[0]["BUSINESSUNIT_CURRENCY_ID"]).ToString();
                        rcmb_EmployeeType.DataTextField = "EMPNAME";
                        rcmb_EmployeeType.DataValueField = "EMP_ID";
                        rcmb_EmployeeType.DataBind();
                        rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

                        rcmb_EmployeeType.SelectedIndex = rcmb_EmployeeType.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["TRAINERDETAILS_EMPLOYEEID"]));

                        panel_internal.Visible = true;
                        //Session["employee"] = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);




                        btn_save_trg_internal.Visible = false;
                        btn_cancel_internal.Visible = true;
                        btn_update_internal.Visible = true;
                        btn_save_trgexte.Visible = false;
                        btn_cancel_trgexte.Visible = false;
                        btn_save_trg.Visible = false;
                        btn_cancel_trg.Visible = false;
                        lbl_BusinessUnitName.Visible = true;
                        rcmb_BusinessUnitType.Visible = true;
                        lbl_Employee.Visible = true;
                        rcmb_EmployeeType.Visible = true;
                        }

                    }
                     if (Convert.ToString(DT.Rows[0]["TRAINERDETAILS_ORGANISATIONNAME"]) != String.Empty)
                    {
                        if (DT.Rows[0]["TRAINERDETAILS_TR_ID"] != System.DBNull.Value)
                        {
                            LoadTraingtrgname();
                            rcm_trg_Traingname.SelectedIndex = rcm_trg_Traingname.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["TRAINERDETAILS_TR_ID"]));

                            rcm_trg_Traingname.Enabled = false;
                        }
                        else
                        {
                            LoadTraingtrgname();
                            rcm_trg_Traingname.SelectedIndex = 0;
                            rcm_trg_Traingname.Enabled = true;
                        }

                        rcmb_TRGType.SelectedItem.Text = "External Trainer";
                        rcmb_TRGType.Enabled = false;

                        rtxt_Organisation.Text = Convert.ToString(DT.Rows[0]["TRAINERDETAILS_ORGANISATIONNAME"]);
                        rtxt_Designation.Text = Convert.ToString(DT.Rows[0]["TRAINERDETAILS_DESIGNATION"]);
                        rtxt_Employee.Text = Convert.ToString(DT.Rows[0]["TRAINERDETAILS_EMPLOYEENAME"]);
                        btn_save_trgexte.Visible = false;
                        btn_cancel_trgexte.Visible = true;
                        btn_update_exter.Visible = true;
                        btn_save_trg.Visible = false;
                        btn_cancel_trg.Visible = false;
                        btn_save_trg_internal.Visible = false;
                        btn_cancel_internal.Visible = false;
                        LBL_ORGANISATION.Visible = true;
                        rtxt_Organisation.Visible = true;
                        lbl_Employees.Visible = true;
                        rtxt_Employee.Visible = true;
                        lbl_Designation.Visible = true;
                        rtxt_Designation.Visible = true;
                        panel_internal.Visible = false;
                        pnl_ext1.Visible = false;

                    }

                     if (Convert.ToString(DT.Rows[0]["TRAINERDETAILS_TRAININGINSTITUENAME"]) != String.Empty)
                    {
                        if (DT.Rows[0]["TRAINERDETAILS_TR_ID"] != System.DBNull.Value)
                        {
                            LoadTraingtrgname();
                            rcm_trg_Traingname.SelectedIndex = rcm_trg_Traingname.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["TRAINERDETAILS_TR_ID"]));
                            rcm_trg_Traingname.Enabled = false;
                        }
                        else
                        {
                            LoadTraingtrgname();
                            rcm_trg_Traingname.SelectedIndex = 0;
                            rcm_trg_Traingname.Enabled = true;

                        }
                        rcmb_TRGType.SelectedItem.Text = "External Training";
                        rcmb_TRGType.Enabled = false;

                        rtxt_TrainingInstitute.Text = Convert.ToString(DT.Rows[0]["TRAINERDETAILS_TRAININGINSTITUENAME"]);
                        rtxt_address.Text = Convert.ToString(DT.Rows[0]["TRAINERDETAILS_ADDRESS"]);
                        rmtxt_phoneno.Text = Convert.ToString(DT.Rows[0]["TRAINERDETAILS_CONTACTNO"]);
                        rtxt_contactperson.Text = Convert.ToString(DT.Rows[0]["TRAINERDETAILS_CONTACTPERSON"]);
                        rtxt_Faculty.Text = Convert.ToString(DT.Rows[0]["TRAINERDETAILS_FACULTY"]);
                        btn_update_extertrg.Visible = true;
                        btn_save_trg.Visible = false;
                        btn_cancel_trg.Visible = true;

                        btn_save_trg_internal.Visible = false;
                        btn_cancel_internal.Visible = false;
                        btn_save_trgexte.Visible = false;
                        btn_cancel_trgexte.Visible = false;

                        LBL_TRGINSTITUTE.Visible = true;
                        rtxt_TrainingInstitute.Visible = true;
                        lbl_address.Visible = true;
                        rtxt_address.Visible = true;
                        lbl_PHONENO.Visible = true;
                        rmtxt_phoneno.Visible = true;
                        lbl_ContactPerson.Visible = true;
                        rtxt_contactperson.Visible = true;
                        lbl_faculty.Visible = true;
                        rtxt_Faculty.Visible = true;
                        panel_internal.Visible = false;
                        panel_external.Visible = false;

                    }

                    else
                    {

                        btn_save_trg_internal.Visible = false;
                        btn_save_trgexte.Visible = false;
                        btn_save_trg.Visible = false;
                        btn_cancel_trg.Visible = false;
                        btn_cancel_trgexte.Visible = false;
                        btn_cancel_internal.Visible = false;
                    }

                    if (DT.Rows[0]["RESOUCE_TRID"] != System.DBNull.Value)
                    {

                        Loadresourcetraining();
                        rcm_resource_trg.SelectedIndex = rcm_resource_trg.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["RESOUCE_TRID"]));
                        rcm_resource_trg.Enabled = false;
                        btn_update_resou.Visible = true;
                        btn_Add_resource.Visible = true;
                        btn_save_resource.Visible = false;
                        Rg_Resource_Grid.DataSource = DT;
                        Rg_Resource_Grid.DataBind();
                    }
                    else
                    {
                        Loadresourcetraining();
                        rcm_resource_trg.SelectedIndex = 0;
                        rcm_resource_trg.Enabled = true;
                        DataTable dt11 = new DataTable();
                        Rg_Resource_Grid.DataSource = dt11;
                        Rg_Resource_Grid.DataBind();
                        btn_Add_resource.Visible = true;
                        btn_save_resource.Visible = true;
                        btn_update_resou.Visible = false;
                        rcm_resource.SelectedIndex = 1;

                    }
                    //if (DT.Rows[0]["RESOURCE_TYPEID"] != System.DBNull.Value)
                    //{

                    //    Loadresources();
                    //    rcm_resource.SelectedIndex = rcm_resource.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["RESOURCE_TYPEID"]));

                    //    rcm_resource.Enabled = false;
                    //}

                    //else
                    //{
                    //    Loadresources();
                    //    rcm_resource.SelectedIndex = 0;
                    //    rcm_resource.Enabled = true;
                    //}

                    //rtxt_Resourcename.Text = Convert.ToString(DT.Rows[0]["RESOURCE_NAME"]);
                    //rtxt_ResoDesc.Text = Convert.ToString(DT.Rows[0]["RESOURCE_DESC"]);

                    //if (DT.Rows[0]["RESOUCE_QTY"] != System.DBNull.Value)
                    //{
                    //    RNT_ResourceQty.Value = Convert.ToInt32(DT.Rows[0]["RESOUCE_QTY"]);
                    //}
                    //else
                    //{
                    //    RNT_ResourceQty.Value = 0;
                    //}
                    //if (DT.Rows[0]["RESOURCE_ESTIMATEDBUDGET"] != System.DBNull.Value)
                    //{
                    //    rnt_estbudget.Value = Convert.ToDouble(DT.Rows[0]["RESOURCE_ESTIMATEDBUDGET"]);
                    //}
                    //else
                    //{
                    //    rnt_estbudget.Value = 0;
                    //}

                    Loadresources();
                    rcm_resource.SelectedIndex = rcm_resource.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["RESOURCE_TYPEID"]));
                    rtxt_Resourcename.Text = string.Empty;
                    rtxt_ResoDesc.Text = string.Empty;
                    RNT_ResourceQty.Value = 0;
                    rnt_estbudget.Value = 0;
                    rcmb_Course.Items.Clear();
                    _obj_Smhr_Masters.MASTER_TYPE = "COURSE";
                    _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    rcmb_Course.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
                    rcmb_Course.DataTextField = "HR_MASTER_CODE";
                    rcmb_Course.DataValueField = "HR_MASTER_ID";
                    rcmb_Course.DataBind();
                    rcmb_Course.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    rcmb_Course.SelectedIndex = rcmb_Course.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["COURSE_CATEGORYID"]));

                    dtreso1.Columns.Clear();
                    dtreso1.Columns.Add("S_No");
                    dtreso1.Columns.Add("RESOURCE_TYPEID");
                    dtreso1.Columns.Add("Resource_Name");
                    dtreso1.Columns.Add("Resource_Desc");
                    dtreso1.Columns.Add("RESOUCE_QTY");
                    dtreso1.Columns.Add("RESOURCE_ESTIMATEDBUDGET");
                    ViewState["dtreso1"] = dtreso1;

                    _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                    _obj_Smhr_TrgRqst.Mode = 30;
                    _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(lbl_Tr_Id.Text);


                    DataTable DT1 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
                    if (DT.Rows.Count != 0)
                    {

                        ViewState["dtreso1"] = DT1;
                        Rg_Resource_Grid.DataSource = DT1;
                        Rg_Resource_Grid.DataBind();
                    }

                    else
                    {
                        DataTable dte = new DataTable();
                        dtreso1.Rows.Clear();
                        ViewState["dtreso1"] = dtreso1;
                        Rg_Resource_Grid.DataSource = dtreso1;
                        Rg_Resource_Grid.DataBind();
                    }

                    //DT = (DataTable)ViewState["dtreso1"];




                    btn_cancel_resource.Visible = true;


                    if (DT23.Rows[0]["TRAINEE_BUSINESSUNIT_ID"] != System.DBNull.Value)
                    {
                        LoadBusinessUnitTrainee();
                        rcm_bu_trainee.SelectedIndex = rcm_bu_trainee.Items.FindItemIndexByValue(Convert.ToString(DT23.Rows[0]["TRAINEE_BUSINESSUNIT_ID"]));
                        rcm_bu_trainee.Enabled = false;

                    }
                    else
                    {
                        LoadBusinessUnitTrainee();
                        rcm_bu_trainee.SelectedIndex = 0;
                        rcm_bu_trainee.Enabled = true;
                    }

                    if (DT23.Rows[0]["TRAINEE_TR_ID"] != System.DBNull.Value)
                    {
                        Loadtraineetraining();
                        Rcmb_training.SelectedIndex = Rcmb_training.Items.FindItemIndexByValue(Convert.ToString(DT23.Rows[0]["TRAINEE_TR_ID"]));
                        Rcmb_training.Enabled = false;
                        btn_updatetrainee.Visible = true;
                        btn_save_traineelist.Visible = false;
                        RadListBoxDestination.DataSource = DT23;
                        RadListBoxDestination.DataValueField = "TRAINEE_EMPID";
                        RadListBoxDestination.DataTextField = "APPLICANT_TITLE";
                        RadListBoxDestination.DataBind();

                     


                    }
                    else
                    {
                        Loadtraineetraining();
                        Rcmb_training.SelectedIndex = 0;
                        Rcmb_training.Enabled = true;
                        btn_save_traineelist.Visible = true;
                        btn_updatetrainee.Visible = false;

                        DataTable dt2 = new DataTable();
                        RadListBoxDestination.DataSource = dt2;
                        RadListBoxDestination.DataBind();

                       
                    }


                    if ((DT23.Rows[0]["TRAINEE_BUSINESSUNIT_ID"] != System.DBNull.Value) && (DT23.Rows[0]["TRAINEE_BUSINESSUNIT_ID"] != System.DBNull.Value))
                    {
                    rdlist_trainee.Items.Clear();
                    SMHR_TRAINER _obj_Smhr_Trner = new SMHR_TRAINER();
                    _obj_Smhr_Trner.Mode = 6;
                    _obj_Smhr_Trner.TRAINERDETAILS_BUSINESSUNITID = Convert.ToInt32(rcm_bu_trainee.SelectedItem.Value);
                    _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(Rcmb_training.SelectedItem.Value);
                    DataTable dt121 = BLL.get_TRAINer(_obj_Smhr_Trner);


                    SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();

                    _obj_Smhr_BusinessUnit.OPERATION = operation.SELECTEMPLOYEE1;
                    _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //rcmb_BU.DataSource = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
                    _obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcm_bu_trainee.SelectedItem.Value);
                    if (dt121.Rows.Count != 0)
                    {

                        _obj_Smhr_BusinessUnit.BUID = Convert.ToInt32(dt121.Rows[0]["TRAINERDETAILS_EMPLOYEEID"]);
                    }
                    else
                    {
                        _obj_Smhr_BusinessUnit.BUID = 0;
                    }
                    DataTable dtemp21 = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
                    rdlist_trainee.DataSource = dtemp21;
                    if (dtemp21.Rows.Count != 0)
                    {

                        rdlist_trainee.DataTextField = "EMPNAME";
                        rdlist_trainee.DataValueField = "EMP_ID";
                        rdlist_trainee.DataBind();

                   
                        rdlist_trainee.Visible = true;
                        RadListBoxDestination.Visible = true;
                        //btn_save_traineelist.Visible = true;
                        //btn_cancel_traineelist.Visible = true;
                        rfv_rlistbox.Visible = true;
                    }

                    else
                    {
                       
                        rdlist_trainee.Items.Clear();
                        RadListBoxDestination.Items.Clear();

                    }
                }




                    btn_cancel_traineelist.Visible = true;
                    if (DT.Rows[0]["TS_TR_ID"] != System.DBNull.Value)
                    {
                        Loadcalendertraining();
                        rcm_trg_calender.SelectedIndex = rcm_trg_calender.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["TS_TR_ID"]));
                        rcm_trg_calender.Enabled = false;
                        btn_save_calender.Visible = false;
                        btn_update_calender.Visible = true;
                    }

                    else
                    {
                        Loadcalendertraining();
                        rcm_trg_calender.SelectedIndex = 0;
                        rcm_trg_calender.Enabled = true;
                        btn_save_calender.Visible = true;
                        btn_update_calender.Visible = false;
                    }
                    if (DT.Rows[0]["TS_STARTDATE"] != System.DBNull.Value)
                    {
                        rdtp_strtdate.SelectedDate = Convert.ToDateTime(DT.Rows[0]["TS_STARTDATE"]);
                    }
                    else
                    {
                        rdtp_strtdate.SelectedDate = null;
                    }


                    rtxt_sessions.Text = Convert.ToString(DT.Rows[0]["TS_SESSIONS"]);
                    if (Convert.ToString(DT.Rows[0]["TS_RECURRENCETYPE"]) == "D")
                    {
                        rbtnlist_recuerence_id.SelectedValue = Convert.ToString(0);
                        if (Convert.ToInt32(DT.Rows[0]["TS_SELECTIONPARAM"]) == 1)
                        {
                            rd_every_id_daily.Checked = true;
                            txt_daily_id.Text = Convert.ToString(DT.Rows[0]["TS_PARAM1"]);
                        }
                        else
                        {
                            rd_daily_weekday_id.Checked = true;

                        }


                    }
                    else if (Convert.ToString(DT.Rows[0]["TS_RECURRENCETYPE"]) == "W")
                    {
                        rbtnlist_recuerence_id.SelectedValue = Convert.ToString(1);
                        txt_weekly_id.Value = Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]);
                        if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 1)
                        {
                            chk_monday.Checked = true;
                        }
                        else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 1)
                        {
                            chk_Tuesday.Checked = true;
                        }
                        else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM4"]) == 1)
                        {
                            chk_Wednesday.Checked = true;
                        }
                        else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM5"]) == 1)
                        {
                            chk_Thursday.Checked = true;
                        }
                        else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM6"]) == 1)
                        {
                            chk_Friday.Checked = true;
                        }

                        else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM7"]) == 1)
                        {
                            chk_Saturday.Checked = true;
                        }
                        else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM8"]) == 1)
                        {
                            chk_Sunday.Checked = true;
                        }




                    }

                    else if (Convert.ToString(DT.Rows[0]["TS_RECURRENCETYPE"]) == "M")
                    {
                        rbtnlist_recuerence_id.SelectedValue = Convert.ToString(2);
                        if (Convert.ToInt32(DT.Rows[0]["TS_SELECTIONPARAM"]) == 1)
                        {
                            rd_monthly_id.Checked = true;
                            txt_monthly_id.Text = Convert.ToString(DT.Rows[0]["TS_PARAM1"]);
                            txt_monthly_id1.Text = Convert.ToString(DT.Rows[0]["TS_PARAM2"]);
                        }
                        else
                        {
                            rd_monthly_id5.Checked = true;
                            txt_monthly_id3.Text = Convert.ToString(DT.Rows[0]["TS_PARAM3"]);
                            if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 0)
                            {
                                ddl_monthly_id.SelectedItem.Text = "First";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 1)
                            {
                                ddl_monthly_id.SelectedItem.Text = "Second";
                            }
                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 2)
                            {
                                ddl_monthly_id.SelectedItem.Text = "Third";
                            }
                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 3)
                            {
                                ddl_monthly_id.SelectedItem.Text = "Fourth";
                            }
                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 4)
                            {
                                ddl_monthly_id.SelectedItem.Text = "Last";
                            }

                            if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 0)
                            {
                                ddl_monthly_id2.SelectedItem.Text = "Sunday";
                            }
                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 1)
                            {
                                ddl_monthly_id2.SelectedItem.Text = "Monday";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 2)
                            {
                                ddl_monthly_id2.SelectedItem.Text = "Tuesday";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 3)
                            {
                                ddl_monthly_id2.SelectedItem.Text = "Wednesday";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 4)
                            {
                                ddl_monthly_id2.SelectedItem.Text = "Thrusday";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 5)
                            {
                                ddl_monthly_id2.SelectedItem.Text = "Friday";
                            }
                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 6)
                            {
                                ddl_monthly_id2.SelectedItem.Text = "Saturday";
                            }


                        }

                    }

                    else if (Convert.ToString(DT.Rows[0]["TS_RECURRENCETYPE"]) == "Y")
                    {
                        rbtnlist_recuerence_id.SelectedValue = Convert.ToString(3);
                        if (Convert.ToInt32(DT.Rows[0]["TS_SELECTIONPARAM"]) == 1)
                        {
                            rd_yearly_id.Checked = true;
                            txt_yearly_id.Text = Convert.ToString(DT.Rows[0]["TS_PARAM2"]);
                            if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 1)
                            {
                                ddl_yearly_id2.SelectedItem.Text = "January";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 2)
                            {
                                ddl_yearly_id2.SelectedItem.Text = "February";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 3)
                            {
                                ddl_yearly_id2.SelectedItem.Text = "March";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 4)
                            {
                                ddl_yearly_id2.SelectedItem.Text = "April";
                            }
                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 5)
                            {
                                ddl_yearly_id2.SelectedItem.Text = "May";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 6)
                            {
                                ddl_yearly_id2.SelectedItem.Text = "June";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 7)
                            {
                                ddl_yearly_id2.SelectedItem.Text = "July";
                            }


                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 8)
                            {
                                ddl_yearly_id2.SelectedItem.Text = "August";
                            }
                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 9)
                            {
                                ddl_yearly_id2.SelectedItem.Text = "September";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 10)
                            {
                                ddl_yearly_id2.SelectedItem.Text = "October";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 11)
                            {
                                ddl_yearly_id2.SelectedItem.Text = "November";
                            }


                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 12)
                            {
                                ddl_yearly_id2.SelectedItem.Text = "December";
                            }







                        }
                        else
                        {
                            rd_yearly_id3.Checked = true;
                            //FIRST
                            if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 0)
                            {
                                ddl_yearly_id3.SelectedItem.Text = "First";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 1)
                            {
                                ddl_yearly_id3.SelectedItem.Text = "Second";
                            }
                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 2)
                            {
                                ddl_yearly_id3.SelectedItem.Text = "Third";
                            }
                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 3)
                            {
                                ddl_yearly_id3.SelectedItem.Text = "Fourth";
                            }
                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 4)
                            {
                                ddl_yearly_id3.SelectedItem.Text = "Last";
                            }


                            //DAYS
                            if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 0)
                            {
                                ddl_yearly_id.SelectedItem.Text = "Sunday";
                            }
                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 1)
                            {
                                ddl_yearly_id.SelectedItem.Text = "Monday";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 2)
                            {
                                ddl_yearly_id.SelectedItem.Text = "Tuesday";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 3)
                            {
                                ddl_yearly_id.SelectedItem.Text = "Wednesday";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 4)
                            {
                                ddl_yearly_id.SelectedItem.Text = "Thrusday";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 5)
                            {
                                ddl_yearly_id.SelectedItem.Text = "Friday";
                            }
                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 6)
                            {
                                ddl_yearly_id.SelectedItem.Text = "Saturday";
                            }



                            //YERALY
                            if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 1)
                            {
                                ddl_yearly_id4.SelectedItem.Text = "January";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 2)
                            {
                                ddl_yearly_id4.SelectedItem.Text = "February";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 3)
                            {
                                ddl_yearly_id4.SelectedItem.Text = "March";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 4)
                            {
                                ddl_yearly_id4.SelectedItem.Text = "April";
                            }
                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 5)
                            {
                                ddl_yearly_id4.SelectedItem.Text = "May";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 6)
                            {
                                ddl_yearly_id4.SelectedItem.Text = "June";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 7)
                            {
                                ddl_yearly_id4.SelectedItem.Text = "July";
                            }


                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 8)
                            {
                                ddl_yearly_id4.SelectedItem.Text = "August";
                            }
                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 9)
                            {
                                ddl_yearly_id4.SelectedItem.Text = "September";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 10)
                            {
                                ddl_yearly_id4.SelectedItem.Text = "October";
                            }

                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 11)
                            {
                                ddl_yearly_id4.SelectedItem.Text = "November";
                            }


                            else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 12)
                            {
                                ddl_yearly_id4.SelectedItem.Text = "December";
                            }






                        }

                    }



                    var tabNewYork = rdtstrp.FindTabByText("TrainingRequest");

                    tabNewYork.Enabled = true;
                    var tabNewYork1 = rdtstrp.FindTabByText("Training");

                    tabNewYork1.Enabled = true;
                    var tabNewYork2 = rdtstrp.FindTabByText("Resources");

                    tabNewYork2.Enabled = true;
                    var tabNewYork3 = rdtstrp.FindTabByText("Trainee");

                    tabNewYork3.Enabled = true;
                    var tabNewYork4 = rdtstrp.FindTabByText("TrainingSchedule");

                    tabNewYork4.Enabled = true;


                    if (DT.Rows[0]["TRAINERDETAILS_TR_ID"] == System.DBNull.Value)
                    {
                        tabNewYork1.Enabled = false;
                        tabNewYork2.Enabled = false;
                        tabNewYork3.Enabled = false;
                        tabNewYork4.Enabled = false;
                    }
                    if (DT.Rows[0]["RESOUCE_TRID"] == System.DBNull.Value)
                    {
                        tabNewYork2.Enabled = false;
                        tabNewYork3.Enabled = false;
                        tabNewYork4.Enabled = false;
                    }
                    if (DT23.Rows[0]["TRAINEE_TR_ID"] == System.DBNull.Value)
                    {

                        tabNewYork3.Enabled = false;
                        tabNewYork4.Enabled = false;
                    }

                    if (DT.Rows[0]["TS_TR_ID"] == System.DBNull.Value)
                    {



                    }
                    //rcm_bu_trainee.Enabled = false;
                    //Rcmb_training.Enabled = false;




                    btn_Update_resource.Visible = false;
                    //rcm_trg_calender.Enabled = false;
                    //DateTime str_date=Convert.ToDateTime((DT.Rows[0]["TS_STARTTIME"]));


                    //rtp_starttime.TimeView.StartTime=new TimeSpan(int.Parse(("7")),0,0);
                    // rtp_endtime.TimeView.StartTime = new TimeSpan(int.Parse(("8")), 0, 0);

                    if (DT.Rows[0]["TS_STARTTIME"] != System.DBNull.Value)
                    {
                        rtp_starttime.SelectedDate = Convert.ToDateTime(DT.Rows[0]["TS_STARTTIME"]);
                    }
                    else
                    {
                        rtp_starttime.SelectedDate = null;
                    }
                    if (DT.Rows[0]["TS_endTIME"] != System.DBNull.Value)
                    {
                        rtp_endtime.SelectedDate = Convert.ToDateTime(DT.Rows[0]["TS_endTIME"]);
                    }
                    else
                    {
                        rtp_endtime.SelectedDate = null;
                    }
                    Rm_Training_PAGE.SelectedIndex = 1;

                }
                else
                {

                    BLL.ShowMessage(this, "Error Occured");
                    return;
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

 
    }

    #endregion




    protected void btn_updatetrgrequest_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();


            _obj_Smhr_TrgRqst.TR_COURSEID = Convert.ToInt32(rcmb_CourseType.SelectedItem.Value);
            _obj_Smhr_TrgRqst.TR_TITLE = BLL.ReplaceQuote(Convert.ToString(rtxt_title.Text));
            _obj_Smhr_TrgRqst.TR_LOCATION = BLL.ReplaceQuote(Convert.ToString(rtxt_Location.Text));
            _obj_Smhr_TrgRqst.TR_DESCRIPTION = BLL.ReplaceQuote(Convert.ToString(rtxt_Description.Text));
            _obj_Smhr_TrgRqst.TR_STATUS = Convert.ToString(rcmb_Status.SelectedItem.Text);
            _obj_Smhr_TrgRqst.TR_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_TrgRqst.TR_LASTMDFDATE = DateTime.Now;
            _obj_Smhr_TrgRqst.TR_RAISEDBY=Convert.ToInt32(Session["emp_id"]);
            _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(lbl_Tr_Id.Text);
            _obj_Smhr_TrgRqst.Mode = 4;

            bool status = BLL.set_TrgRqst(_obj_Smhr_TrgRqst);
            if (status == true)
            {
                BLL.ShowMessage(this, "Training Request Updated Successfully");
                LoadGrid();
                Rg_Tarining.DataBind();


                var tabNewYork = rdtstrp.FindTabByText("Resources");

                tabNewYork.Enabled = true;
                var tabNewYork1 = rdtstrp.FindTabByText("Training");

                tabNewYork1.Enabled = true;
                var tabNewYork2 = rdtstrp.FindTabByText("TrainingRequest");

                tabNewYork2.Enabled = false;

                if (rcmb_TRGType.SelectedItem.Text == "Internal Trainer")
                {
                panel_external.Visible = false;
                pnl_ext1.Visible = false;
                panel_internal.Visible = true;
           
            }
                else if (rcmb_TRGType.SelectedItem.Text == "External Trainer")
                {
                    panel_external.Visible = true;
                    pnl_ext1.Visible = false;
                    panel_internal.Visible = false;
                }
                else if (rcmb_TRGType.SelectedItem.Text == "External Training")
                {
                    panel_external.Visible = false;
                    pnl_ext1.Visible = true;
                    panel_internal.Visible = false;
                }
                else
                {

                    panel_external.Visible = false;
                    pnl_ext1.Visible = false;
                    tabNewYork.Enabled = false;
                    LoadTraingtrgname();
                    LoadBusinessUnit();
                    //if (rcmb_TRGType.SelectedItem.Text == "Internal Trainer")
                    //{
                    //    LoadTraingtrgname();
                    //    LoadBusinessUnit();

                    //    btn_save_trg_internal.Visible = true;
                    //    btn_cancel_internal.Visible = true;
                    //}
                    //else if (rcmb_TRGType.SelectedItem.Text == "External Trainer")
                    //{
                    //    LoadTraingtrgname();
                    //    btn_save_trgexte.Visible = true;

                    //    btn_cancel_trgexte.Visible = true;
                      
                    //}
                    //else if (rcmb_TRGType.SelectedItem.Text == "External Training")
                    //{
                    //    LoadTraingtrgname();
                    //    btn_save_trg.Visible = true;
                    //    btn_cancel_trg.Visible = true;
                    //}

                    

                }

                btn_Save.Visible = true;
                Rm_Training_PAGE.SelectedIndex = 1;
               
                Rm_Trainingrequest_PAGE1.SelectedIndex = 1;
               
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void btn_update_internal_click(object sender, EventArgs e)
    {
        try
        {
        SMHR_TRAINER _obj_Smhr_Trner = new SMHR_TRAINER();


        _obj_Smhr_Trner.TRAINERDETAILS_BUSINESSUNITID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
        _obj_Smhr_Trner.TRAINERDETAILS_EMPLOYEEID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

        _obj_Smhr_Trner.TRAINERDETAILS_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);// ### Need to Get the Session
        _obj_Smhr_Trner.TRAINERDETAILS_LASTMDFDATE = DateTime.Now;
        _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(lbl_Tr_Id.Text);
        _obj_Smhr_Trner.Mode = 4;

        bool status = BLL.set_Trgtriner(_obj_Smhr_Trner);
        if (status == true)
        {


            SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();
            _obj_Smhr_TrnEE.Mode = 10;
            _obj_Smhr_TrnEE.TRAINEE_EMPID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            bool status1 = BLL.set_TrgtrinEE(_obj_Smhr_TrnEE);
            BLL.ShowMessage(this, "Internal Trainer Details Updated Successfully");
            LoadGrid();
            Rg_Tarining.DataBind();
            Rm_Training_PAGE.SelectedIndex = 1;
            rcmb_TRGType.SelectedIndex = 0;
            panel_internal.Visible = true;
            var tabNewYork = rdtstrp.FindTabByText("TrainingRequest");

            tabNewYork.Enabled = false;
            var tabNewYork1 = rdtstrp.FindTabByText("Training");

            tabNewYork1.Enabled = false;
            //SMHR_ASSIGNFEEDBACK_EMPLOYEE _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE = new SMHR_ASSIGNFEEDBACK_EMPLOYEE();
            //_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.Mode = 4;
            //_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = Convert.ToInt32(Session["employee"]);
            //_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGNFEED_FEEBAK_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            
            //_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_CREATEDBY = 1;
            //_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_CREATEDDATE = DateTime.Now;
            //bool st = BLL.set_SMHR_ASSIGNFEEDBACK_EMPLOYEE(_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE);

            //Loadresourcetraining();


            //dtreso1.Rows.Clear();
            dtreso1.Columns.Clear();
            dtreso1.Columns.Add("S_No");
            dtreso1.Columns.Add("RESOURCE_TYPEID");
            dtreso1.Columns.Add("Resource_Name");
            dtreso1.Columns.Add("Resource_Desc");
            dtreso1.Columns.Add("RESOUCE_QTY");
            dtreso1.Columns.Add("RESOURCE_ESTIMATEDBUDGET");
            ViewState["dtreso1"] = dtreso1;

            _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
            _obj_Smhr_TrgRqst.Mode = 30;
            _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(lbl_Tr_Id.Text);


            DataTable DT = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
            if (DT.Rows.Count != 0)
            {

                ViewState["dtreso1"] = DT;
                Rg_Resource_Grid.DataSource = DT;
                Rg_Resource_Grid.DataBind();
            }

            else
            {
                DataTable dte = new DataTable();
                dtreso1.Rows.Clear();
                ViewState["dtreso1"] = dtreso1;
                Rg_Resource_Grid.DataSource = dtreso1;
                Rg_Resource_Grid.DataBind();
            }
            Rm_Trainingrequest_PAGE1.SelectedIndex = 2;
            return;


        }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        

    }
    protected void btn_update_exter_click(object sender, EventArgs e)
    {
        try
        {
        SMHR_TRAINER _obj_Smhr_Trner = new SMHR_TRAINER();


        _obj_Smhr_Trner.TRAINERDETAILS_ORGANISATIONNAME = Convert.ToString(rtxt_Organisation.Text);
        _obj_Smhr_Trner.TRAINERDETAILS_EMPLOYEENAME = Convert.ToString(rtxt_Employee.Text);
        _obj_Smhr_Trner.TRAINERDETAILS_DESIGNATION = Convert.ToString(rtxt_Designation.Text);
        _obj_Smhr_Trner.TRAINERDETAILS_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);// ### Need to Get the Session
        _obj_Smhr_Trner.TRAINERDETAILS_LASTMDFDATE = DateTime.Now;
        _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(lbl_Tr_Id.Text);
        _obj_Smhr_Trner.Mode = 4;

        bool status = BLL.set_Trgtriner(_obj_Smhr_Trner);
        if (status == true)
        {
            BLL.ShowMessage(this, "External Trainer Details Updated Successfully");
            LoadGrid();
            Rg_Tarining.DataBind();
            Rm_Training_PAGE.SelectedIndex = 1;
            rcmb_TRGType.SelectedIndex = 0;
            panel_internal.Visible = true;
            var tabNewYork = rdtstrp.FindTabByText("TrainingRequest");

            tabNewYork.Enabled = false;
            var tabNewYork1 = rdtstrp.FindTabByText("Training");

            tabNewYork1.Enabled = false;
            dtreso1.Columns.Clear();
            dtreso1.Columns.Add("S_No");
            dtreso1.Columns.Add("RESOURCE_TYPEID");
            dtreso1.Columns.Add("Resource_Name");
            dtreso1.Columns.Add("Resource_Desc");
            dtreso1.Columns.Add("RESOUCE_QTY");
            dtreso1.Columns.Add("RESOURCE_ESTIMATEDBUDGET");
            ViewState["dtreso1"] = dtreso1;

            _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
            _obj_Smhr_TrgRqst.Mode = 30;
            _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(lbl_Tr_Id.Text);


            DataTable DT = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
            if (DT.Rows.Count != 0)
            {

                ViewState["dtreso1"] = DT;
                Rg_Resource_Grid.DataSource = DT;
                Rg_Resource_Grid.DataBind();
            }

            else
            {
                DataTable dte = new DataTable();
                dtreso1.Rows.Clear();
                ViewState["dtreso1"] = dtreso1;
                Rg_Resource_Grid.DataSource = dtreso1;
                Rg_Resource_Grid.DataBind();
            }
            //Loadresourcetraining();
            Rm_Trainingrequest_PAGE1.SelectedIndex = 2;
            return;
        }

         }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_update_extertrg_click(object sender, EventArgs e)
    {
        try
        {
        SMHR_TRAINER _obj_Smhr_Trner = new SMHR_TRAINER();


        _obj_Smhr_Trner.TRAINERDETAILS_TRAININGINSTITUENAME = Convert.ToString(rtxt_TrainingInstitute.Text);
        _obj_Smhr_Trner.TRAINERDETAILS_CONTACTPERSON = Convert.ToString(rtxt_contactperson.Text);
        _obj_Smhr_Trner.TRAINERDETAILS_ADDRESS = Convert.ToString(rtxt_address.Text);
        _obj_Smhr_Trner.TRAINERDETAILS_CONTACTNO = Convert.ToString(rmtxt_phoneno.Text);
        _obj_Smhr_Trner.TRAINERDETAILS_FACULTY = Convert.ToString(rtxt_Faculty.Text);
        _obj_Smhr_Trner.TRAINERDETAILS_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
        _obj_Smhr_Trner.TRAINERDETAILS_LASTMDFDATE = DateTime.Now;
        _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(lbl_Tr_Id.Text);
        _obj_Smhr_Trner.Mode = 4;

        bool status = BLL.set_Trgtriner(_obj_Smhr_Trner);
        if (status == true)
        {
            BLL.ShowMessage(this, "External Training Details Updated Successfully");
            LoadGrid();
            Rg_Tarining.DataBind();
            Rm_Training_PAGE.SelectedIndex = 1;
            rcmb_TRGType.SelectedIndex = 0;
            panel_internal.Visible = true;
            var tabNewYork = rdtstrp.FindTabByText("TrainingRequest");

            tabNewYork.Enabled = false;
            var tabNewYork1 = rdtstrp.FindTabByText("Training");

            tabNewYork1.Enabled = false;

            dtreso1.Columns.Clear();
            dtreso1.Columns.Add("S_No");
            dtreso1.Columns.Add("RESOURCE_TYPEID");
            dtreso1.Columns.Add("Resource_Name");
            dtreso1.Columns.Add("Resource_Desc");
            dtreso1.Columns.Add("RESOUCE_QTY");
            dtreso1.Columns.Add("RESOURCE_ESTIMATEDBUDGET");
            ViewState["dtreso1"] = dtreso1;

            _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
            _obj_Smhr_TrgRqst.Mode = 30;
            _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(lbl_Tr_Id.Text);


            DataTable DT = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
            if (DT.Rows.Count != 0)
            {

                ViewState["dtreso1"] = DT;
                Rg_Resource_Grid.DataSource = DT;
                Rg_Resource_Grid.DataBind();
            }

            else
            {
                DataTable dte = new DataTable();
                dtreso1.Rows.Clear();
                ViewState["dtreso1"] = dtreso1;
                Rg_Resource_Grid.DataSource = dtreso1;
                Rg_Resource_Grid.DataBind();
            }
            //Loadresourcetraining();
            Rm_Trainingrequest_PAGE1.SelectedIndex = 2;
            return;
        }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }



    /// <summary>
    /// WHILE INSERTING THERE IS NO NEED TO ADD LAST MDF BY,LAST MDF DATE,BASED ON LABEL _KRAID IF IT IS NULL THEN PERFORM INSERTION 
    /// IF END DATE IS NULL THEN WE HAVE TO USE THIS AND IT IS TO BE DEFINED IN TRANSLAYER
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>


    protected void btn_Save_Click(object sender, EventArgs e)
    {

        try
        {
           
                _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                _obj_Smhr_TrgRqst.Mode = 5;
                _obj_Smhr_TrgRqst.TR_TITLE = BLL.ReplaceQuote(Convert.ToString(rtxt_title.Text));
                _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
                if (dt.Rows.Count != 0)
                {
                    BLL.ShowMessage(this, "Training Already Exist");
                    return;
                }
                else
                {

                    _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();


                    _obj_Smhr_TrgRqst.TR_COURSEID = Convert.ToInt32(rcmb_CourseType.SelectedItem.Value);
                    _obj_Smhr_TrgRqst.TR_TITLE = BLL.ReplaceQuote(Convert.ToString(rtxt_title.Text));
                    _obj_Smhr_TrgRqst.TR_LOCATION = BLL.ReplaceQuote(Convert.ToString(rtxt_Location.Text));
                    _obj_Smhr_TrgRqst.TR_DESCRIPTION = BLL.ReplaceQuote(Convert.ToString(rtxt_Description.Text));
                    _obj_Smhr_TrgRqst.TR_STATUS = Convert.ToString(rcmb_Status.SelectedItem.Text);
                    _obj_Smhr_TrgRqst.TR_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);// ### Need to Get the Session
                    _obj_Smhr_TrgRqst.TR_CREATEDDATE = DateTime.Now;
                    _obj_Smhr_TrgRqst.Mode = 3;
                    _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_TrgRqst.TR_RAISEDBY=Convert.ToInt32(Session["emp_id"]);

                    bool status = BLL.set_TrgRqst(_obj_Smhr_TrgRqst);
                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Training Request Inserted Successfully");
                        LoadGrid();
                        Rg_Tarining.DataBind();
                        LoadTraingtrgname();//loading tranings
                        btn_Save.Visible = true;
                        Rm_Training_PAGE.SelectedIndex = 1;
                        var tabNewYork = rdtstrp.FindTabByText("Resources");

                        tabNewYork.Enabled = false;
                        var tabNewYork1 = rdtstrp.FindTabByText("Training");

                        tabNewYork1.Enabled = true;
                        var tabNewYork2 = rdtstrp.FindTabByText("TrainingRequest");

                        tabNewYork2.Enabled = false;
                        Rm_Trainingrequest_PAGE1.SelectedIndex = 1;
                        return;
                    }
                }
            //}
            //else
            //{
            //    _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();

            //    _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(lbl_Tr_Id.Text);
            //    _obj_Smhr_TrgRqst.TR_COURSEID = Convert.ToInt32(rcmb_CourseType.SelectedItem.Value);
            //    _obj_Smhr_TrgRqst.TR_TITLE = BLL.ReplaceQuote(Convert.ToString(rtxt_title.Text));
            //    _obj_Smhr_TrgRqst.TR_LOCATION = BLL.ReplaceQuote(Convert.ToString(rtxt_Location.Text));
            //    _obj_Smhr_TrgRqst.TR_DESCRIPTION = BLL.ReplaceQuote(Convert.ToString(rtxt_Description.Text));
            //    _obj_Smhr_TrgRqst.TR_STATUS = Convert.ToString(rcmb_Status.SelectedItem.Text);

            //    _obj_Smhr_TrgRqst.TR_LASTMDFBY = 1; // ### Need to Get the Session
            //    _obj_Smhr_TrgRqst.TR_LASTMDFDATE = DateTime.Now;
            //    _obj_Smhr_TrgRqst.Mode = 4;
            //    bool status = BLL.set_TrgRqst(_obj_Smhr_TrgRqst);
            //    if (status == true)
            //    {
            //        Pms_Bll.ShowMessage(this, "Training Request Updated Successfully");
            //        LoadGrid();
            //        Rg_Tarining.DataBind();
            //        LoadTraingtrgname();
            //        btn_Save.Visible = true;
            //        Rm_Training_PAGE.SelectedIndex = 0;
            //        var tabNewYork = rdtstrp.FindTabByText("Resources");
            //        var tabNewYork1 = rdtstrp.FindTabByText("Training");

            //        tabNewYork1.Enabled = true;
            //        var tabNewYork2 = rdtstrp.FindTabByText("TrainingRequest");

            //        tabNewYork2.Enabled = true;
            //        tabNewYork.Enabled = true;
            //        Rm_Trainingrequest_PAGE1.SelectedIndex = 1;
            //        return;
            //    }

            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #region internaltrgtrainersave

    protected void btn_save_trg_internal_click(object sender, EventArgs e)
    {

        try
        {
            SMHR_TRAINER _obj_Smhr_Trner = new SMHR_TRAINER();


            _obj_Smhr_Trner.TRAINERDETAILS_BUSINESSUNITID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
            //_obj_Smhr_Trner.TRAINERDETAILS_EMPLOYEEID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);


            _obj_Smhr_Trner.TRAINERDETAILS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(rcm_trg_Traingname.SelectedItem.Value);
            _obj_Smhr_Trner.Mode = 13;

            DataTable dttrgexist = BLL.get_TRAINer(_obj_Smhr_Trner);

            if (dttrgexist.Rows.Count != 0)
            {
                BLL.ShowMessage(this, "Trainer Already Assigned For This Training");
            }
            else
            {
                //SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();


            //IT IS NOT NEEDED 



                //_obj_Smhr_TrgRqst.Mode = 6;
                //DataTable DT3 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);

              _obj_Smhr_Trner = new SMHR_TRAINER();


                _obj_Smhr_Trner.TRAINERDETAILS_BUSINESSUNITID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                _obj_Smhr_Trner.TRAINERDETAILS_EMPLOYEEID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                _obj_Smhr_Trner.TRAINERDETAILS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_Smhr_Trner.TRAINERDETAILS_CREATEDDATE = DateTime.Now;
                //_obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(DT3.Rows[0]["temp"]);not useful
                _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(rcm_trg_Traingname.SelectedItem.Value);
                _obj_Smhr_Trner.TRAINERDETAILS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Trner.Mode = 3;

                bool status = BLL.set_Trgtriner(_obj_Smhr_Trner);
                if (status == true)
                {
                    BLL.ShowMessage(this, "Internal Trainer Details Inserted Successfully");
                    Rm_Training_PAGE.SelectedIndex = 1;
                    rcmb_TRGType.SelectedIndex = 0;
                    panel_internal.Visible = true;
                    var tabNewYork = rdtstrp.FindTabByText("TrainingRequest");

                    tabNewYork.Enabled = false;
                    var tabNewYork1 = rdtstrp.FindTabByText("Training");

                    tabNewYork1.Enabled = false;
                    //var tabNewYork12 = rdtstrp.FindTabByText("Resources");

                    //tabNewYork12.Enabled = true;

                   
                    Loadresourcetraining();
                    Rm_Trainingrequest_PAGE1.SelectedIndex = 2;


                    dtreso1.Rows.Clear();
                    dtreso1.Columns.Clear();
                    dtreso1.Columns.Add("S_No");
                    dtreso1.Columns.Add("RESOURCE_TYPEID");
                    dtreso1.Columns.Add("Resource_Name");
                    dtreso1.Columns.Add("Resource_Desc");
                    dtreso1.Columns.Add("RESOUCE_QTY");
                    dtreso1.Columns.Add("RESOURCE_ESTIMATEDBUDGET");


                    ViewState["dtreso1"] = dtreso1;
                    Rg_Resource_Grid.DataSource = dtreso1;
                    Rg_Resource_Grid.DataBind();
                    btn_Add_resource.Visible = true;
                    btn_Update_resource.Visible = false;
                    return;
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }



    }
    #endregion
    #region externaltrgtrainersave

    protected void btn_save_trgexte_click(object sender, EventArgs e)
    {

        try

        { 
            SMHR_TRAINER _obj_Smhr_Trner=new SMHR_TRAINER();
          

          
           
            _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(rcm_trg_Traingname.SelectedItem.Value);
            _obj_Smhr_Trner.Mode = 14;
            _obj_Smhr_Trner.TRAINERDETAILS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dttrgexist = BLL.get_TRAINer(_obj_Smhr_Trner);

            if (dttrgexist.Rows.Count != 0)
            {
                BLL.ShowMessage(this, "Trainer Already Assigned For This Training");
            }
            else
            {

                //SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();

                //_obj_Smhr_TrgRqst.Mode = 6;
                //DataTable DT3 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);

                _obj_Smhr_Trner = new SMHR_TRAINER();

                _obj_Smhr_Trner.TRAINERDETAILS_ORGANISATIONNAME = BLL.ReplaceQuote(Convert.ToString(rtxt_Organisation.Text));
                _obj_Smhr_Trner.TRAINERDETAILS_EMPLOYEENAME = BLL.ReplaceQuote(Convert.ToString(rtxt_Employee.Text));
                _obj_Smhr_Trner.TRAINERDETAILS_DESIGNATION = BLL.ReplaceQuote(Convert.ToString(rtxt_Designation.Text));
                _obj_Smhr_Trner.TRAINERDETAILS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_Smhr_Trner.TRAINERDETAILS_CREATEDDATE = DateTime.Now;
                _obj_Smhr_Trner.TRAINERDETAILS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(DT3.Rows[0]["temp"]);nouseful
                _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(rcm_trg_Traingname.SelectedItem.Value);
                _obj_Smhr_Trner.Mode = 3;

                bool status = BLL.set_Trgtriner(_obj_Smhr_Trner);
                if (status == true)
                {
                    BLL.ShowMessage(this, "External Trainer Details Inserted Successfully");
                    Rm_Training_PAGE.SelectedIndex = 1;
                    rcmb_TRGType.SelectedIndex = 0;
                    panel_external.Visible = true;
                    var tabNewYork = rdtstrp.FindTabByText("TrainingRequest");

                    tabNewYork.Enabled = false;
                    var tabNewYork1 = rdtstrp.FindTabByText("Training");

                    tabNewYork1.Enabled = false;
                    Loadresourcetraining();
                    dtreso1.Rows.Clear();
                    dtreso1.Columns.Clear();
                    dtreso1.Columns.Add("S_No");
                    dtreso1.Columns.Add("RESOURCE_TYPEID");
                    dtreso1.Columns.Add("Resource_Name");
                    dtreso1.Columns.Add("Resource_Desc");
                    dtreso1.Columns.Add("RESOUCE_QTY");
                    dtreso1.Columns.Add("RESOURCE_ESTIMATEDBUDGET");
                    ViewState["dtreso1"] = dtreso1;
                    Rg_Resource_Grid.DataSource = dtreso1;
                    Rg_Resource_Grid.DataBind();
                    Rm_Trainingrequest_PAGE1.SelectedIndex = 2;

                    btn_Add_resource.Visible = true;
                    btn_Update_resource.Visible = false;

                    rcm_resource_trg.Enabled = true;
                    return;
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }



    }
    #endregion
    #region externaltrgtrainingsave

    protected void btn_save_trg_click(object sender, EventArgs e)
    {

        try
        {
            SMHR_TRAINER _obj_Smhr_Trner=new SMHR_TRAINER();
          

          
           
            _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(rcm_trg_Traingname.SelectedItem.Value);
            _obj_Smhr_Trner.Mode = 14;
            _obj_Smhr_Trner.TRAINERDETAILS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dttrgexist = BLL.get_TRAINer(_obj_Smhr_Trner);

            if (dttrgexist.Rows.Count != 0)
            {
                BLL.ShowMessage(this, "Trainer Already Assigned For This Training");
            }
            else
            {
                SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();

                _obj_Smhr_TrgRqst.Mode = 6;
                DataTable DT3 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);


                _obj_Smhr_Trner = new SMHR_TRAINER();

                _obj_Smhr_Trner.TRAINERDETAILS_TRAININGINSTITUENAME = BLL.ReplaceQuote(Convert.ToString(rtxt_TrainingInstitute.Text));
                _obj_Smhr_Trner.TRAINERDETAILS_ADDRESS = BLL.ReplaceQuote(Convert.ToString(rtxt_address.Text));
                _obj_Smhr_Trner.TRAINERDETAILS_CONTACTNO = Convert.ToString(rmtxt_phoneno.Text);
                _obj_Smhr_Trner.TRAINERDETAILS_CONTACTPERSON = BLL.ReplaceQuote(Convert.ToString(rtxt_contactperson.Text));
                _obj_Smhr_Trner.TRAINERDETAILS_FACULTY = BLL.ReplaceQuote(Convert.ToString(rtxt_Faculty.Text));
                _obj_Smhr_Trner.TRAINERDETAILS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_Smhr_Trner.TRAINERDETAILS_CREATEDDATE = DateTime.Now;
                //_obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(DT3.Rows[0]["temp"]);no used
                _obj_Smhr_Trner.Mode = 3;
                _obj_Smhr_Trner.TRAINERDETAILS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(rcm_trg_Traingname.SelectedItem.Value);
                bool status = BLL.set_Trgtriner(_obj_Smhr_Trner);
                if (status == true)
                {
                    BLL.ShowMessage(this, "External Training Details Inserted Successfully");
                    Rm_Training_PAGE.SelectedIndex = 1;
                    rcmb_TRGType.SelectedIndex = 0;
                    pnl_ext1.Visible = true;
                    var tabNewYork = rdtstrp.FindTabByText("TrainingRequest");

                    tabNewYork.Enabled = false;
                    var tabNewYork1 = rdtstrp.FindTabByText("Training");

                    tabNewYork1.Enabled = false;
                    Loadresourcetraining();
                    dtreso1.Rows.Clear();
                    dtreso1.Columns.Clear();
                    dtreso1.Columns.Add("S_No");
                    dtreso1.Columns.Add("RESOURCE_TYPEID");
                    dtreso1.Columns.Add("Resource_Name");
                    dtreso1.Columns.Add("Resource_Desc");
                    dtreso1.Columns.Add("RESOUCE_QTY");
                    dtreso1.Columns.Add("RESOURCE_ESTIMATEDBUDGET");
                    ViewState["dtreso1"] = dtreso1;
                    Rg_Resource_Grid.DataSource = dtreso1;
                    Rg_Resource_Grid.DataBind();
                    Rm_Trainingrequest_PAGE1.SelectedIndex = 2;
                    btn_Add_resource.Visible = true;
                    btn_Update_resource.Visible = false;
                    rcm_resource_trg.Enabled = true;
                    return;
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }



    }
    #endregion
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_Training_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_cancel_trg_click(object sender, EventArgs e)
    {
        try
        {
            Rm_Training_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void rcmb_TRGType_SelectedIndexChanged1(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
        if (rcmb_TRGType.SelectedItem.Text == "Select")
        {
            BLL.ShowMessage(this, "Please Select Training Type");
            ClearTraining();
            panel_internal.Visible = false;
            panel_external.Visible = false;
            pnl_ext1.Visible = false;
            btn_save_trg.Visible = false;
            btn_cancel_trg.Visible = false;

        }
        else if (rcmb_TRGType.SelectedItem.Text == "Internal Trainer")
        {
            ClearTraining();
            rcmb_BusinessUnitType.Visible = true;
            rcmb_EmployeeType.Visible = true;
            lbl_BusinessUnitName.Visible = true;
            lbl_Employee.Visible = true;
            panel_internal.Visible = true;
            panel_external.Visible = false;
            pnl_ext1.Visible = false;
            btn_save_trg.Visible = true;
            btn_cancel_trg.Visible = true;
            rcmb_BusinessUnitType.SelectedIndex = 0;
            rcmb_EmployeeType.SelectedIndex = 0;
            DataTable dt = new DataTable();
            rcmb_EmployeeType.DataSource = dt;
            rcmb_EmployeeType.DataBind();

            btn_save_trg_internal.Visible = true;
            btn_cancel_internal.Visible = true;
        }
        else if (rcmb_TRGType.SelectedItem.Text == "External Trainer")
        {
            ClearTraining();


            LBL_ORGANISATION.Visible = true;
            lbl_Employees.Visible = true;
            lbl_Designation.Visible = true;
            rtxt_Employee.Visible = true;
            rtxt_Organisation.Visible = true;
            rtxt_Designation.Visible = true;
            panel_internal.Visible = false;
            panel_external.Visible = true;
            pnl_ext1.Visible = false;
            btn_save_trg.Visible = true;
            btn_cancel_trg.Visible = true;
            rtxt_Organisation.Text = string.Empty;
            rtxt_Employee.Text = string.Empty;
            rtxt_Designation.Text = string.Empty;
            btn_save_trgexte.Visible = true;
            btn_cancel_trgexte.Visible = true;
        }
        else if (rcmb_TRGType.SelectedItem.Text == "External Training")
        {
            ClearTraining();
            LBL_TRGINSTITUTE.Visible = true;
            lbl_address.Visible = true;
            lbl_PHONENO.Visible = true;
            lbl_ContactPerson.Visible = true;
            lbl_faculty.Visible = true;
            rtxt_address.Visible = true;
            rtxt_TrainingInstitute.Visible = true;
            rmtxt_phoneno.Visible = true;
            rtxt_contactperson.Visible = true;
            rtxt_Faculty.Visible = true;
            panel_internal.Visible = false;
            panel_external.Visible = false;
            pnl_ext1.Visible = true;
            btn_save_trg.Visible = true;
            btn_cancel_trg.Visible = true;
            rtxt_TrainingInstitute.Text = string.Empty;
            rtxt_address.Text = string.Empty;
            rtxt_contactperson.Text = string.Empty;
            rmtxt_phoneno.Text = string.Empty;
            rtxt_Faculty.Text = string.Empty;
            btn_save_trg.Visible = true;
            btn_cancel_trg.Visible = true;
        }
         }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void rcmb_BusinessUnitType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
        rcmb_EmployeeType.Items.Clear();

        SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
        _obj_Smhr_BusinessUnit.OPERATION = operation.SELECTEMPLOYEE;
        _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        //rcmb_BU.DataSource = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
        _obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
        DataTable dtemp = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
        rcmb_EmployeeType.DataSource = dtemp;
        if (dtemp.Rows.Count != 0)
        {
            //Cur = Convert.ToString(dtemp.Rows[0]["BUSINESSUNIT_CURRENCY_ID"]).ToString();
            rcmb_EmployeeType.DataTextField = "EMPNAME";
            rcmb_EmployeeType.DataValueField = "EMP_ID";
            rcmb_EmployeeType.DataBind();
            rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

        }

        else
        {
            BLL.ShowMessage(this, "There are No employees in this Business Unit, Please select another");
        }
         }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }


    protected void btn_cancel_resource_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_Training_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_cancel_traineelist_Click1(object sender, EventArgs e)
    {
        try
        {
            Rm_Training_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_cancel_internal_click(object sender, EventArgs e)
    {
        try
        {
            Rm_Training_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_cancel_trgexte_click(object sender, EventArgs e)
    {
        try
        {
            Rm_Training_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_cancel_calender_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_Training_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_save_calender_Click1(object sender, EventArgs e)
    {

        try
        {

            if (rdtp_strtdate.SelectedDate < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
            {
                rdtp_strtdate.Clear();

                BLL.ShowMessage(this, "StartDate Should Be Greater Than Current Date");
                return;
            }
            if ((rdtp_strtdate.SelectedDate == Convert.ToDateTime(DateTime.Now.ToShortDateString())) & (rtp_starttime.SelectedDate < DateTime.Now))
            {
                rtp_starttime.Clear();
                BLL.ShowMessage(this, "StartTime Should Be Greater Than Current Time");
                return;
            }
            if ((rdtp_strtdate.SelectedDate == Convert.ToDateTime(DateTime.Now.ToShortDateString())) & (rtp_endtime.SelectedDate < DateTime.Now))
            {
                rtp_starttime.Clear();
                BLL.ShowMessage(this, "EndTime Should Be Greater Than Current Time");
                return;
            }


            SMHR_TRAININGSCHEDULE _obj_Smhr_TRAININGSCHEDULE = new SMHR_TRAININGSCHEDULE();

            _obj_Smhr_TRAININGSCHEDULE.Mode = 8;
            _obj_Smhr_TRAININGSCHEDULE.TS_TR_ID = Convert.ToInt32(rcm_trg_calender.SelectedItem.Value);
            _obj_Smhr_TRAININGSCHEDULE.TS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtcalenderexist = BLL.get_TRAININGSCHEDULE(_obj_Smhr_TRAININGSCHEDULE);
            _obj_Smhr_TRAININGSCHEDULE = new SMHR_TRAININGSCHEDULE();
           
            
            if (dtcalenderexist.Rows.Count != 0)
            {
                BLL.ShowMessage(this, "Already Scheduled");
                return;

            }
                                       
            else
            {

                _obj_Smhr_TRAININGSCHEDULE = new SMHR_TRAININGSCHEDULE();

             //  for (int i = 0; i < RadListBoxDestination.Items.Count; i++)
               // {
                   // ListItem li = new ListItem();
                  //  li.Text = RadListBoxDestination.Items[i].Text;
                   // li.Value = RadListBoxDestination.Items[i].Value;
                   // int K = Convert.ToInt32(li.Value);
                   // _obj_Smhr_TRAININGSCHEDULE.TS_SCHEDULEID = Convert.ToInt32(K);

                   // _obj_Smhr_TRAININGSCHEDULE.TS_TR_ID = Convert.ToInt32(Rcmb_training.SelectedItem.Value);
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM1 = Convert.ToInt32(rcm_bu_trainee.SelectedItem.Value);

                    _obj_Smhr_TRAININGSCHEDULE.TS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_TRAININGSCHEDULE.Mode = 11;
                    _obj_Smhr_TRAININGSCHEDULE.TS_STARTDATE = Convert.ToDateTime(rdtp_strtdate.SelectedDate.Value);
                    _obj_Smhr_TRAININGSCHEDULE.TS_STARTTIME = Convert.ToString(Convert.ToDateTime(rtp_starttime.SelectedDate).TimeOfDay);
                    _obj_Smhr_TRAININGSCHEDULE.TS_ENDTIME = Convert.ToString(Convert.ToDateTime(rtp_endtime.SelectedDate).TimeOfDay);
                    _obj_Smhr_TRAININGSCHEDULE.TS_STARTDATE = Convert.ToDateTime(rdtp_strtdate.SelectedDate.Value);
                    int count = Convert.ToInt32(rtxt_sessions.Text);

                    for (int i = 0; i < count; i++)
                    {
                        
                        DataTable dt = new DataTable();
                        dt = BLL.get_TRAININGSCHEDULE(_obj_Smhr_TRAININGSCHEDULE);
                        if (Convert.ToString(dt.Rows[0][0]) == "TRUE")
                        {
                            BLL.ShowMessage(this, "Already Scheduled For This Period");
                            return;
                        }
                        else
                        {
                            _obj_Smhr_TRAININGSCHEDULE.TS_STARTDATE = Convert.ToDateTime(rdtp_strtdate.SelectedDate.Value).AddDays(1);
                        }
                    }
               // }



                _obj_Smhr_TRAININGSCHEDULE.TS_TR_ID = Convert.ToInt32(rcm_trg_calender.SelectedItem.Value);
                _obj_Smhr_TRAININGSCHEDULE.TS_STARTDATE = Convert.ToDateTime(rdtp_strtdate.SelectedDate.Value);
                ////_obj_Smhr_TRAININGSCHEDULE.TS_ENDDATE = Convert.ToDateTime(rdtp_enddate.SelectedDate.Value);
                _obj_Smhr_TRAININGSCHEDULE.TS_ENDDATE = DateTime.Now;

                _obj_Smhr_TRAININGSCHEDULE.TS_ENDTIME = Convert.ToString(Convert.ToDateTime(rtp_endtime.SelectedDate).TimeOfDay);

                _obj_Smhr_TRAININGSCHEDULE.TS_STARTTIME = Convert.ToString(Convert.ToDateTime(rtp_starttime.SelectedDate).TimeOfDay);

                _obj_Smhr_TRAININGSCHEDULE.TS_SESSIONS = Convert.ToInt32(rtxt_sessions.Text);
                //_obj_Smhr_TRAININGSCHEDULE.TS_MINUTESINTERVAL = Convert.ToInt32(rtxt_duration.Text);
                _obj_Smhr_TRAININGSCHEDULE.TS_RECURRENCETYPE = Convert.ToString(rbtnlist_recuerence_id.SelectedItem.Text);
                if (rbtnlist_recuerence_id.SelectedItem.Value == "0")
                {
                    if (rd_every_id_daily.Checked)
                    {
                        _obj_Smhr_TRAININGSCHEDULE.TS_SELECTIONPARAM = 1;
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM1 = Convert.ToInt32(txt_daily_id.Text);
                    }
                    else
                    {
                        _obj_Smhr_TRAININGSCHEDULE.TS_SELECTIONPARAM = 2;
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM2 = 1;
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM3 = 1;
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM4 = 1;
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM5 = 1;
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM6 = 1;
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM7 = 1;
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM8 = 1;
                    }
                }

                else if (rbtnlist_recuerence_id.SelectedItem.Value == "1")
                {
                    _obj_Smhr_TRAININGSCHEDULE.TS_SELECTIONPARAM = 1;
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM1 = Convert.ToInt32(txt_weekly_id.Text);
                    if (chk_monday.Checked)
                    {
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM2 = 1;
                    }
                    if (chk_Tuesday.Checked)
                    {
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM3 = 1;
                    }
                    if (chk_Wednesday.Checked)
                    {
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM4 = 1;
                    }
                    if (chk_Thursday.Checked)
                    {
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM5 = 1;

                    }
                    if (chk_Friday.Checked)
                    {
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM6 = 1;
                    }
                    if (chk_Saturday.Checked)
                    {
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM7 = 1;
                    }
                    if (chk_Sunday.Checked)
                    {
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM8 = 1;

                    }
                }
                else if (rbtnlist_recuerence_id.SelectedItem.Value == "2")
                {

                    if (rd_monthly_id.Checked)
                    {
                        _obj_Smhr_TRAININGSCHEDULE.TS_SELECTIONPARAM = 1;
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM1 = Convert.ToInt32(txt_monthly_id.Text);
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM2 = Convert.ToInt32(txt_monthly_id1.Value);
                    }

                    else
                    {
                        _obj_Smhr_TRAININGSCHEDULE.TS_SELECTIONPARAM = 2;
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM1 = Convert.ToInt32(ddl_monthly_id.SelectedItem.Value);
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM2 = Convert.ToInt32(ddl_monthly_id2.SelectedItem.Value);
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM3 = Convert.ToInt32(txt_monthly_id3.Text);
                    }

                }
                else if (rbtnlist_recuerence_id.SelectedItem.Value == "3")
                {

                    if (rd_yearly_id.Checked)
                    {
                        _obj_Smhr_TRAININGSCHEDULE.TS_SELECTIONPARAM = 1;
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM1 = Convert.ToInt32(ddl_yearly_id2.SelectedItem.Value);
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM2 = Convert.ToInt32(txt_yearly_id.Text);

                    }
                    else
                    {
                        _obj_Smhr_TRAININGSCHEDULE.TS_SELECTIONPARAM = 2;
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM1 = Convert.ToInt32(ddl_yearly_id3.SelectedItem.Value);
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM2 = Convert.ToInt32(ddl_yearly_id.SelectedItem.Value);
                        _obj_Smhr_TRAININGSCHEDULE.TS_PARAM3 = Convert.ToInt32(ddl_yearly_id4.SelectedItem.Value);
                    }
                }

                _obj_Smhr_TRAININGSCHEDULE.TS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_Smhr_TRAININGSCHEDULE.TS_CREATEDDATE = DateTime.Now;
                _obj_Smhr_TRAININGSCHEDULE.TS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_TRAININGSCHEDULE.Mode = 3;

                bool status = BLL.set_TRAININGSCHEDULE(_obj_Smhr_TRAININGSCHEDULE);
                if (status == true)
                {
                    BLL.ShowMessage(this, "Schedule Inserted Successfully");


                    SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();

                    _obj_Smhr_TrgRqst.Mode = 6;
                    DataTable DT3 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);

                    SMHR_RESOURCE _obj_Smhr_Resourc = new SMHR_RESOURCE();
                    _obj_Smhr_Resourc.Mode = 5;
                    //_obj_Smhr_Resourc.RESOUCE_TRID = Convert.ToInt32(DT3.Rows[0]["temp"]);

                    _obj_Smhr_Resourc.RESOUCE_TRID = Convert.ToInt32(rcm_trg_calender.SelectedItem.Value);
                    bool status1 = BLL.set_Resourc(_obj_Smhr_Resourc);

                    bool status11;
                    _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                    _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(rcm_trg_calender.SelectedItem.Value);
                    _obj_Smhr_TrgRqst.Mode = 17;
                    DataTable dt_ger_tr1 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
                    if (dt_ger_tr1.Rows.Count != 0)
                    {
                        for (int i = 0; i < dt_ger_tr1.Rows.Count; i++)
                        {
                            Dal.ExecuteNonQuery("EXEC USP_SEND_EMAIL_TRAINING_REQUEST  @LOGIN_EMAILID ='" + Convert.ToString(dt_ger_tr1.Rows[i]["LOGIN_EMAILID"]) + "',@EMPLOYEE ='" + Convert.ToString(dt_ger_tr1.Rows[i]["EMPLOYEE"]) + "', @TR_TITLE ='" + Convert.ToString(dt_ger_tr1.Rows[i]["TR_TITLE"]) + "',@MANAGER ='" + Convert.ToString(dt_ger_tr1.Rows[i]["MANAGER"]) + "'");

                        }
                        status11 = true;
                    }

                    else
                    {
                        status11 = false;
                    }
                    if ((status11 == true) || (status11 == false))
                    {
                        BLL.ShowMessage(this, "Notification Send");

                        Rm_Training_PAGE.SelectedIndex = 0;

                        return;
                    }
                }

            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void btn_update_calender_Click1(object sender, EventArgs e)
    {

        try
        {

            if (rdtp_strtdate.SelectedDate < Convert.ToDateTime( DateTime.Now.ToShortDateString()))
            {
                rdtp_strtdate.Clear();

                BLL.ShowMessage(this, "StartDate Should Be Greater Than Current Date");
                return;
            }
            if ((rdtp_strtdate.SelectedDate == Convert.ToDateTime( DateTime.Now.ToShortDateString()))&(rtp_starttime.SelectedDate < DateTime.Now))
            {
                rtp_starttime.Clear();
                BLL.ShowMessage(this, "StartTime Should Be Greater Than Current Time");
                return;
            }
            if ((rdtp_strtdate.SelectedDate == Convert.ToDateTime(DateTime.Now.ToShortDateString())) & (rtp_endtime.SelectedDate < DateTime.Now))
            {
                rtp_starttime.Clear();
                BLL.ShowMessage(this, "EndTime Should Be Greater Than Current Time");
                return;
            }

            SMHR_TRAININGSCHEDULE _obj_Smhr_TRAININGSCHEDULE = new SMHR_TRAININGSCHEDULE();
            _obj_Smhr_TRAININGSCHEDULE = new SMHR_TRAININGSCHEDULE();

            for (int i = 0; i < RadListBoxDestination.Items.Count; i++)
            {
                ListItem li = new ListItem();
                li.Text = RadListBoxDestination.Items[i].Text;
                li.Value = RadListBoxDestination.Items[i].Value;
                int K = Convert.ToInt32(li.Value);
                _obj_Smhr_TRAININGSCHEDULE.TS_SCHEDULEID = Convert.ToInt32(K);

                // _obj_Smhr_TRAININGSCHEDULE.TS_TR_ID = Convert.ToInt32(Rcmb_training.SelectedItem.Value);
                _obj_Smhr_TRAININGSCHEDULE.TS_PARAM1 = Convert.ToInt32(rcm_bu_trainee.SelectedItem.Value);

                _obj_Smhr_TRAININGSCHEDULE.TS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_TRAININGSCHEDULE.Mode = 11;
                _obj_Smhr_TRAININGSCHEDULE.TS_STARTDATE = Convert.ToDateTime(rdtp_strtdate.SelectedDate.Value);
                _obj_Smhr_TRAININGSCHEDULE.TS_STARTTIME = Convert.ToString(Convert.ToDateTime(rtp_starttime.SelectedDate).TimeOfDay);
                _obj_Smhr_TRAININGSCHEDULE.TS_ENDTIME = Convert.ToString(Convert.ToDateTime(rtp_endtime.SelectedDate).TimeOfDay);
                _obj_Smhr_TRAININGSCHEDULE.TS_STARTDATE = Convert.ToDateTime(rdtp_strtdate.SelectedDate.Value);
                int count = Convert.ToInt32(rtxt_sessions.Text);

                for (i = 0; i < count; i++)
                {

                    DataTable dt = new DataTable();
                    dt = BLL.get_TRAININGSCHEDULE(_obj_Smhr_TRAININGSCHEDULE);
                    if (Convert.ToString(dt.Rows[0][0]) == "TRUE")
                    {
                        BLL.ShowMessage(this, "Already Scheduled For This Period");
                        return;
                    }
                    else
                    {
                        _obj_Smhr_TRAININGSCHEDULE.TS_STARTDATE = Convert.ToDateTime(rdtp_strtdate.SelectedDate.Value).AddDays(1);
                    }
                }
            }


            _obj_Smhr_TRAININGSCHEDULE.TS_TR_ID = Convert.ToInt32(rcm_trg_calender.SelectedItem.Value);
            _obj_Smhr_TRAININGSCHEDULE.TS_STARTDATE = Convert.ToDateTime(rdtp_strtdate.SelectedDate.Value);
            ////_obj_Smhr_TRAININGSCHEDULE.TS_ENDDATE = Convert.ToDateTime(rdtp_enddate.SelectedDate.Value);
            _obj_Smhr_TRAININGSCHEDULE.TS_ENDDATE = DateTime.Now;

            _obj_Smhr_TRAININGSCHEDULE.TS_ENDTIME = Convert.ToString(Convert.ToDateTime(rtp_endtime.SelectedDate).TimeOfDay);

            _obj_Smhr_TRAININGSCHEDULE.TS_STARTTIME = Convert.ToString(Convert.ToDateTime(rtp_starttime.SelectedDate).TimeOfDay);

            _obj_Smhr_TRAININGSCHEDULE.TS_SESSIONS = Convert.ToInt32(rtxt_sessions.Text);
            //_obj_Smhr_TRAININGSCHEDULE.TS_MINUTESINTERVAL = Convert.ToInt32(rtxt_duration.Text);
            _obj_Smhr_TRAININGSCHEDULE.TS_RECURRENCETYPE = Convert.ToString(rbtnlist_recuerence_id.SelectedItem.Text);
            if (rbtnlist_recuerence_id.SelectedItem.Value == "0")
            {
                if (rd_every_id_daily.Checked)
                {
                    _obj_Smhr_TRAININGSCHEDULE.TS_SELECTIONPARAM = 1;
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM1 = Convert.ToInt32(txt_daily_id.Text);
                }
                else
                {
                    _obj_Smhr_TRAININGSCHEDULE.TS_SELECTIONPARAM = 2;
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM2 = 1;
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM3 = 1;
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM4 = 1;
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM5 = 1;
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM6 = 1;
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM7 = 1;
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM8 = 1;
                }
            }

            else if (rbtnlist_recuerence_id.SelectedItem.Value == "1")
            {
                _obj_Smhr_TRAININGSCHEDULE.TS_SELECTIONPARAM = 1;
                _obj_Smhr_TRAININGSCHEDULE.TS_PARAM1 = Convert.ToInt32(txt_weekly_id.Text);
                if (chk_monday.Checked)
                {
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM2 = 1;
                }
                if (chk_Tuesday.Checked)
                {
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM3 = 1;
                }
                if (chk_Wednesday.Checked)
                {
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM4 = 1;
                }
                if (chk_Thursday.Checked)
                {
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM5 = 1;

                }
                if (chk_Friday.Checked)
                {
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM6 = 1;
                }
                if (chk_Saturday.Checked)
                {
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM7 = 1;
                }
                if (chk_Sunday.Checked)
                {
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM8 = 1;

                }
            }
            else if (rbtnlist_recuerence_id.SelectedItem.Value == "2")
            {

                if (rd_monthly_id.Checked)
                {
                    _obj_Smhr_TRAININGSCHEDULE.TS_SELECTIONPARAM = 1;
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM1 = Convert.ToInt32(txt_monthly_id.Text);
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM2 = Convert.ToInt32(txt_monthly_id1.Value);
                }

                else
                {
                    _obj_Smhr_TRAININGSCHEDULE.TS_SELECTIONPARAM = 2;
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM1 = Convert.ToInt32(ddl_monthly_id.SelectedItem.Value);
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM2 = Convert.ToInt32(ddl_monthly_id2.SelectedItem.Value);
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM3 = Convert.ToInt32(txt_monthly_id3.Text);
                }

            }
            else if (rbtnlist_recuerence_id.SelectedItem.Value == "3")
            {

                if (rd_yearly_id.Checked)
                {
                    _obj_Smhr_TRAININGSCHEDULE.TS_SELECTIONPARAM = 1;
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM1 = Convert.ToInt32(ddl_yearly_id2.SelectedItem.Value);
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM2 = Convert.ToInt32(txt_yearly_id.Text);

                }
                else
                {
                    _obj_Smhr_TRAININGSCHEDULE.TS_SELECTIONPARAM = 2;
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM1 = Convert.ToInt32(ddl_yearly_id3.SelectedItem.Value);
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM2 = Convert.ToInt32(ddl_yearly_id.SelectedItem.Value);
                    _obj_Smhr_TRAININGSCHEDULE.TS_PARAM3 = Convert.ToInt32(ddl_yearly_id4.SelectedItem.Value);
                }
            }

            _obj_Smhr_TRAININGSCHEDULE.TS_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_TRAININGSCHEDULE.TS_LASTMDFDATE = DateTime.Now;

            _obj_Smhr_TRAININGSCHEDULE.TS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            _obj_Smhr_TRAININGSCHEDULE.TS_CREATEDDATE = DateTime.Now;
          
           
                BLL.ShowMessage(this, "Schedule Updated Successfully");


                SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();

                _obj_Smhr_TrgRqst.Mode = 6;
                DataTable DT3 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);



                SMHR_RESOURCE _obj_Smhr_Resourc = new SMHR_RESOURCE();
               

                _obj_Smhr_TRAININGSCHEDULE.TS_TR_ID = Convert.ToInt32(rcm_trg_calender.SelectedItem.Value);

                _obj_Smhr_TRAININGSCHEDULE.Mode = 8;//TO GET SCHDEULE ID
                DataTable DTSCH = BLL.get_TRAININGSCHEDULE(_obj_Smhr_TRAININGSCHEDULE);


                _obj_Smhr_TRAININGSCHEDULE.TS_TR_ID = Convert.ToInt32(rcm_trg_calender.SelectedItem.Value);
                _obj_Smhr_TRAININGSCHEDULE.CREATEDBY = Convert.ToInt32(DTSCH.Rows[0]["TS_SCHEDULEID"]);
                _obj_Smhr_TRAININGSCHEDULE.Mode = 10;//WHICH DELETES SESSIONS FIRST AND SCHDEULE
                bool status8 = BLL.set_TRAININGSCHEDULE(_obj_Smhr_TRAININGSCHEDULE);


                _obj_Smhr_TRAININGSCHEDULE.Mode = 3;
                _obj_Smhr_TRAININGSCHEDULE.TS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                bool status = BLL.set_TRAININGSCHEDULE(_obj_Smhr_TRAININGSCHEDULE);

                 _obj_Smhr_Resourc = new SMHR_RESOURCE();
                _obj_Smhr_Resourc.Mode = 5;
                //_obj_Smhr_Resourc.RESOUCE_TRID = Convert.ToInt32(DT3.Rows[0]["temp"]);

                _obj_Smhr_Resourc.RESOUCE_TRID = Convert.ToInt32(rcm_trg_calender.SelectedItem.Value);
                bool status9 = BLL.set_Resourc(_obj_Smhr_Resourc);


                bool status12;
                _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(rcm_trg_calender.SelectedItem.Value);
                _obj_Smhr_TrgRqst.Mode = 17;
                DataTable dt_ger_tr1 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
                if (dt_ger_tr1.Rows.Count != 0)
                {
                    for (int i = 0; i < dt_ger_tr1.Rows.Count; i++)
                    {
                        Dal.ExecuteNonQuery("EXEC USP_SEND_EMAIL_TRAINING_REQUEST_UPDATE  @LOGIN_EMAILID ='" + Convert.ToString(dt_ger_tr1.Rows[i]["LOGIN_EMAILID"]) + "',@EMPLOYEE ='" + Convert.ToString(dt_ger_tr1.Rows[i]["EMPLOYEE"]) + "', @TR_TITLE ='" + Convert.ToString(dt_ger_tr1.Rows[i]["TR_TITLE"]) + "',@MANAGER ='" + Convert.ToString(dt_ger_tr1.Rows[i]["MANAGER"]) + "'");

                    }
                    status12 = true;
                }
                else
                {
                    status12 = false;
                }
            if((status12 == true) || (status12 == false))
            {
                BLL.ShowMessage(this, "Notification Send");
                Rm_Training_PAGE.SelectedIndex = 0;

                return;
            }


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }


    protected void rcm_resource_trg_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            if (rcm_resource_trg.SelectedItem.Text != "Select")
            {
                Loadresources();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_edit_res_command(object sender, CommandEventArgs e)
    {
        try
        {
        dtreso1 = (DataTable)ViewState["dtreso1"];
        btn_Add_resource.Visible = false;
        btn_Update_resource.Visible = true;
        lbl_res_serail.Text = Convert.ToString(e.CommandArgument);
        rcm_resource_trg.Enabled = false;
        rcm_resource.Enabled = true;
        foreach (DataRow item in dtreso1.Rows)
        {
            if (item["S_No"].ToString() == Convert.ToString(e.CommandArgument))
            {

                rcm_resource.SelectedItem.Value = Convert.ToString(item["RESOURCE_TYPEID"]);
               rtxt_Resourcename.Text = Convert.ToString(item["Resource_Name"]);
               rtxt_ResoDesc.Text = Convert.ToString(item["Resource_Desc"]);
               RNT_ResourceQty.Value = Convert.ToDouble(item["RESOUCE_QTY"]);
               rnt_estbudget.Value = Convert.ToDouble(item["RESOURCE_ESTIMATEDBUDGET"]);
               
            }
        }
         }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_Add_resource_Click(object sender, EventArgs e)
    {
        try
        {

            if (btn_update_resou.Visible == false)
            {



                dtreso1 = (DataTable)ViewState["dtreso1"];
                DataRow dr1 = dtreso1.NewRow();
                dr1[0] = dtreso1.Rows.Count + 1;
                dr1[1] = rcm_resource.SelectedItem.Value;
                dr1[2] = rtxt_Resourcename.Text;
                dr1[3] = rtxt_ResoDesc.Text;
                dr1[4] = RNT_ResourceQty.Value;
                dr1[5] = rnt_estbudget.Value;
                dtreso1.Rows.Add(dr1);
                ViewState["dtreso1"] = dtreso1;

                Rg_Resource_Grid.DataSource = dtreso1;
                Rg_Resource_Grid.DataBind();
                btn_Update_resource.Visible = false;

                rtxt_Resourcename.Text = string.Empty;
                rtxt_ResoDesc.Text = string.Empty;
                rnt_estbudget.Value = 0;
                RNT_ResourceQty.Value = 0;

                rcm_resource.SelectedIndex = 0;

                rcm_resource_trg.Enabled = false;
            }

            else
            {


                //dtreso1.Rows.Clear();
                dtreso1.Columns.Clear();
                dtreso1.Columns.Add("S_No");
                dtreso1.Columns.Add("RESOURCE_TYPEID");
                dtreso1.Columns.Add("Resource_Name");
                dtreso1.Columns.Add("Resource_Desc");
                dtreso1.Columns.Add("RESOUCE_QTY");
                dtreso1.Columns.Add("RESOURCE_ESTIMATEDBUDGET");
                ////ViewState["dtreso1"] = dtreso1;
                ////Rg_Resource_Grid.DataSource = dtreso1;
                ////Rg_Resource_Grid.DataBind();
                dtreso1 = (DataTable)ViewState["dtreso1"];
                DataRow dr1 = dtreso1.NewRow();
                dr1[0] = dtreso1.Rows.Count + 1;
                dr1[1] = rcm_resource.SelectedItem.Value;
                dr1[2] = rtxt_Resourcename.Text;
                dr1[3] = rtxt_ResoDesc.Text;
                dr1[4] = RNT_ResourceQty.Value;
                dr1[5] = rnt_estbudget.Value;
                dtreso1.Rows.Add(dr1);
                ViewState["dtreso1"] = dtreso1;

                Rg_Resource_Grid.DataSource = dtreso1;
                Rg_Resource_Grid.DataBind();
                btn_Update_resource.Visible = false;
                
                rtxt_Resourcename.Text = string.Empty;
                rtxt_ResoDesc.Text = string.Empty;
                rnt_estbudget.Value = 0;
                RNT_ResourceQty.Value = 0;

                rcm_resource_trg.Enabled = false;

            }
         }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void btn_Update_resource_Click(object sender, EventArgs e)
    {
        try
        {
        dtreso1 = (DataTable)ViewState["dtreso1"];
        foreach (DataRow item in dtreso1.Rows)
        {
            if (item["S_No"].ToString() == Convert.ToString(lbl_res_serail.Text))
            {
                item["RESOURCE_TYPEID"] = rcm_resource.SelectedItem.Value;
                item["Resource_Name"] = rtxt_Resourcename.Text;
                item["Resource_Desc"] = rtxt_ResoDesc.Text;
                item["RESOUCE_QTY"] = RNT_ResourceQty.Value;
                item["RESOURCE_ESTIMATEDBUDGET"] = rnt_estbudget.Value;
              

            }
        }
        ViewState["dtreso1"] = dtreso1;

        Rg_Resource_Grid.DataSource = dtreso1;
        Rg_Resource_Grid.DataBind();
        btn_Update_resource.Visible = false;
        btn_Add_resource.Visible = true;
        rtxt_Resourcename.Text = string.Empty;
        rtxt_ResoDesc.Text = string.Empty;
        rnt_estbudget.Value = 0;
        RNT_ResourceQty.Value = 0;
        rcm_resource.Enabled = true;
        rcm_resource_trg.Enabled = false;
         }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_save_resource_Click(object sender, EventArgs e)
    {
        try
        {

        if (Rg_Resource_Grid.Items.Count != 0)
        {
            SMHR_RESOURCE _obj_Smhr_Resourc = new SMHR_RESOURCE();
            _obj_Smhr_Resourc.Mode = 5;
            _obj_Smhr_Resourc.RESOUCE_TRID = Convert.ToInt32(rcm_resource_trg.SelectedItem.Value);
            _obj_Smhr_Resourc.RESOURCE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtresexist = BLL.get_Resourc(_obj_Smhr_Resourc);
            if (dtresexist.Rows.Count != 0)
            {
                BLL.ShowMessage(this, "Resource Already Assigned");
                rcm_resource_trg.Enabled = true;
            }
            else
            {


                _obj_Smhr_Resourc = new SMHR_RESOURCE();

                Label lbl_res_typee = new Label();
                Label lbl_res_namee = new Label();
                Label lbl_res_descee = new Label();
                Label lbl_res_Quantityee = new Label();
                Label lbl_res_EstBudget = new Label();
                Label LBLSNOO = new Label();
                for (int a = 0; a < Rg_Resource_Grid.Items.Count; a++)
                {
                    lbl_res_typee = Rg_Resource_Grid.Items[a].FindControl("lbl_res_typee") as Label;
                    lbl_res_namee = Rg_Resource_Grid.Items[a].FindControl("lbl_res_namee") as Label;
                    lbl_res_descee = Rg_Resource_Grid.Items[a].FindControl("lbl_res_descee") as Label;
                    lbl_res_Quantityee = Rg_Resource_Grid.Items[a].FindControl("lbl_res_Quantityee") as Label;
                    lbl_res_EstBudget = Rg_Resource_Grid.Items[a].FindControl("lbl_res_EstBudget") as Label;
                    LBLSNOO = Rg_Resource_Grid.Items[a].FindControl("lbl_res_sno") as Label;

                    _obj_Smhr_Resourc.RESOUCE_TRID = Convert.ToInt32(rcm_resource_trg.SelectedItem.Value);
                    //_obj_Smhr_Resourc.RESOURCE_TYPEID = Convert.ToInt32(rcm_resource.SelectedItem.Value);
                    //_obj_Smhr_Resourc.RESOURCE_NAME = BLL.ReplaceQuote(Convert.ToString(rtxt_Resourcename.Text));
                    //_obj_Smhr_Resourc.RESOURCE_DESC = BLL.ReplaceQuote(Convert.ToString(rtxt_ResoDesc.Text));
                    //_obj_Smhr_Resourc.RESOUCE_QTY = Convert.ToInt32(RNT_ResourceQty.Value);
                    //_obj_Smhr_Resourc.RESOURCE_ESTIMATEDBUDGET = Convert.ToDecimal(rnt_estbudget.Value);

                    _obj_Smhr_Resourc.RESOURCE_S_NO = Convert.ToInt32(LBLSNOO.Text);
                    _obj_Smhr_Resourc.RESOURCE_TYPEID = Convert.ToInt32(lbl_res_typee.Text);
                    _obj_Smhr_Resourc.RESOURCE_NAME = BLL.ReplaceQuote(Convert.ToString(lbl_res_namee.Text));
                    _obj_Smhr_Resourc.RESOURCE_DESC = BLL.ReplaceQuote(Convert.ToString(lbl_res_descee.Text));
                    _obj_Smhr_Resourc.RESOUCE_QTY = Convert.ToInt32(lbl_res_Quantityee.Text);
                    _obj_Smhr_Resourc.RESOURCE_ESTIMATEDBUDGET = Convert.ToDecimal(lbl_res_EstBudget.Text);
                    _obj_Smhr_Resourc.RESOURCE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_Resourc.RESOURCE_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                    _obj_Smhr_Resourc.RESOURCE_CREATEDDATE = DateTime.Now;
                    _obj_Smhr_Resourc.Mode = 3;

                    bool status = BLL.set_Resourc(_obj_Smhr_Resourc);
                    //if (status == true)
                    //{

                    //}

                }
                BLL.ShowMessage(this, "Resource Inserted Successfully");
                Rm_Training_PAGE.SelectedIndex = 1;
                rcm_resource.SelectedIndex = 0;
                rcm_resource_trg.SelectedIndex = 0;
                DataTable dt = new DataTable();
                rcm_resource.DataSource = dt;
                rcm_resource.DataBind();

                rtxt_Resourcename.Text = string.Empty;
                rtxt_ResoDesc.Text = string.Empty;
                RNT_ResourceQty.Value = null;
                rnt_estbudget.Value = null;
                var tabNewYork = rdtstrp.FindTabByText("Trainee");

                tabNewYork.Enabled = true;
                var tabNewYork1 = rdtstrp.FindTabByText("Training");

                tabNewYork1.Enabled = false;
                var tabNewYork2 = rdtstrp.FindTabByText("TrainingRequest");

                tabNewYork2.Enabled = false;
                var tabNewYork3 = rdtstrp.FindTabByText("Resources");
                LoadBusinessUnitTrainee();
                tabNewYork3.Enabled = false;

                Rm_Trainingrequest_PAGE1.SelectedIndex = 3;
                rfv_rlistbox.Visible = false;
            }
        }
        else
        {

            BLL.ShowMessage(this, "Please Add Resources To Training");
            return;
        }
            
        
         }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }



    protected void btn_update_resou_click(object sender, EventArgs e)
    {


        try
        {


          

         if (Rg_Resource_Grid.Items.Count != 0)
        {

             //FIST DELETE RESOURCES WID THAT TR_ID
            SMHR_RESOURCE _obj_Smhr_Resourc = new SMHR_RESOURCE();
            _obj_Smhr_Resourc.RESOUCE_TRID = Convert.ToInt32(lbl_Tr_Id.Text);
              _obj_Smhr_Resourc.Mode = 7;
              bool status1 = BLL.set_Resourc(_obj_Smhr_Resourc);


            Label lbl_res_typee = new Label();
            Label lbl_res_namee = new Label();
            Label lbl_res_descee = new Label();
            Label lbl_res_Quantityee = new Label();
            Label lbl_res_EstBudget = new Label();
            Label lblssno = new Label();
            for (int a = 0; a < Rg_Resource_Grid.Items.Count; a++)
            {
                lbl_res_typee = Rg_Resource_Grid.Items[a].FindControl("lbl_res_typee") as Label;
                lbl_res_namee = Rg_Resource_Grid.Items[a].FindControl("lbl_res_namee") as Label;
                lbl_res_descee = Rg_Resource_Grid.Items[a].FindControl("lbl_res_descee") as Label;
                lbl_res_Quantityee = Rg_Resource_Grid.Items[a].FindControl("lbl_res_Quantityee") as Label;
                lbl_res_EstBudget = Rg_Resource_Grid.Items[a].FindControl("lbl_res_EstBudget") as Label;
                lblssno = Rg_Resource_Grid.Items[a].FindControl("lbl_res_sno") as Label;
                _obj_Smhr_Resourc.RESOUCE_TRID = Convert.ToInt32(rcm_resource_trg.SelectedItem.Value);

                _obj_Smhr_Resourc.RESOURCE_S_NO = Convert.ToInt32(lblssno.Text);
                //_obj_Smhr_Resourc.RESOURCE_TYPEID = Convert.ToInt32(rcm_resource.SelectedItem.Value);
                //_obj_Smhr_Resourc.RESOURCE_NAME = BLL.ReplaceQuote(Convert.ToString(rtxt_Resourcename.Text));
                //_obj_Smhr_Resourc.RESOURCE_DESC = BLL.ReplaceQuote(Convert.ToString(rtxt_ResoDesc.Text));
                //_obj_Smhr_Resourc.RESOUCE_QTY = Convert.ToInt32(RNT_ResourceQty.Value);
                //_obj_Smhr_Resourc.RESOURCE_ESTIMATEDBUDGET = Convert.ToDecimal(rnt_estbudget.Value);



                _obj_Smhr_Resourc.RESOURCE_TYPEID = Convert.ToInt32(lbl_res_typee.Text);
                _obj_Smhr_Resourc.RESOURCE_NAME = BLL.ReplaceQuote(Convert.ToString(lbl_res_namee.Text));
                _obj_Smhr_Resourc.RESOURCE_DESC = BLL.ReplaceQuote(Convert.ToString(lbl_res_descee.Text));
                _obj_Smhr_Resourc.RESOUCE_QTY = Convert.ToInt32(lbl_res_Quantityee.Text);
                _obj_Smhr_Resourc.RESOURCE_ESTIMATEDBUDGET = Convert.ToDecimal(lbl_res_EstBudget.Text);

                _obj_Smhr_Resourc.RESOURCE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Resourc.RESOURCE_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_Smhr_Resourc.RESOURCE_CREATEDDATE = DateTime.Now;
                _obj_Smhr_Resourc.Mode = 6;

                bool status = BLL.set_Resourc(_obj_Smhr_Resourc);
                //if (status == true)
                //{
                    


                //}


            }

            BLL.ShowMessage(this, "Resource Updated Successfully");
            Rm_Training_PAGE.SelectedIndex = 1;
            rcm_resource.SelectedIndex = 0;
            rcm_resource_trg.SelectedIndex = 0;
            DataTable dt = new DataTable();
            rcm_resource.DataSource = dt;
            rcm_resource.DataBind();

            rtxt_Resourcename.Text = string.Empty;
            rtxt_ResoDesc.Text = string.Empty;
            RNT_ResourceQty.Value = null;
            rnt_estbudget.Value = null;
            var tabNewYork = rdtstrp.FindTabByText("Trainee");

            tabNewYork.Enabled = true;
            var tabNewYork1 = rdtstrp.FindTabByText("Training");

            tabNewYork1.Enabled = false;
            var tabNewYork2 = rdtstrp.FindTabByText("TrainingRequest");

            tabNewYork2.Enabled = false;
            var tabNewYork3 = rdtstrp.FindTabByText("Resources");
            //LoadBusinessUnitTrainee();


            tabNewYork3.Enabled = false;

            _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
            _obj_Smhr_TrgRqst.Mode = 12;
            _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(lbl_Tr_Id.Text);
            DataTable DT23 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);


            if (DT23.Rows[0]["TRAINEE_BUSINESSUNIT_ID"] != System.DBNull.Value)
            {
                LoadBusinessUnitTrainee();
                rcm_bu_trainee.SelectedIndex = rcm_bu_trainee.Items.FindItemIndexByValue(Convert.ToString(DT23.Rows[0]["TRAINEE_BUSINESSUNIT_ID"]));
                rcm_bu_trainee.Enabled = false;
                Rcmb_training.Enabled = false;
                rcm_bu_trainee.Enabled = false;
            }
            else
            {
                LoadBusinessUnitTrainee();
                rcm_bu_trainee.SelectedIndex = 0;
                rcm_bu_trainee.Enabled = true;

                Rcmb_training.Enabled = true;
                rcm_bu_trainee.Enabled = true;
            }

            if (DT23.Rows[0]["TRAINEE_TR_ID"] != System.DBNull.Value)
            {
                Loadtraineetraining();
                Rcmb_training.SelectedIndex = Rcmb_training.Items.FindItemIndexByValue(Convert.ToString(DT23.Rows[0]["TRAINEE_TR_ID"]));
                Rcmb_training.Enabled = false;
                btn_updatetrainee.Visible = true;
                btn_save_traineelist.Visible = false;
                RadListBoxDestination.DataSource = DT23;
                RadListBoxDestination.DataValueField = "TRAINEE_EMPID";
                RadListBoxDestination.DataTextField = "APPLICANT_TITLE";
                RadListBoxDestination.DataBind();




            }
            else
            {
                Loadtraineetraining();
                Rcmb_training.SelectedIndex = 0;
                Rcmb_training.Enabled = true;
                btn_save_traineelist.Visible = true;
                btn_updatetrainee.Visible = false;

                DataTable dt2 = new DataTable();
                RadListBoxDestination.DataSource = dt2;
                RadListBoxDestination.DataBind();

               

            }


            if ((DT23.Rows[0]["TRAINEE_BUSINESSUNIT_ID"] != System.DBNull.Value) && (DT23.Rows[0]["TRAINEE_BUSINESSUNIT_ID"] != System.DBNull.Value))
            {
                rdlist_trainee.Items.Clear();
                SMHR_TRAINER _obj_Smhr_Trner = new SMHR_TRAINER();
                _obj_Smhr_Trner.Mode = 6;
                _obj_Smhr_Trner.TRAINERDETAILS_BUSINESSUNITID = Convert.ToInt32(rcm_bu_trainee.SelectedItem.Value);
                _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(Rcmb_training.SelectedItem.Value);
                DataTable dt121 = BLL.get_TRAINer(_obj_Smhr_Trner);

                //SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();
                //_obj_Smhr_TrnEE.Mode = 13;
               
                //_obj_Smhr_TrnEE.TRAINEE_TR_ID = Convert.ToInt32(Rcmb_training.SelectedItem.Value);

                //DataTable dttraineeexisted = BLL.get_TRAINEE(_obj_Smhr_TrnEE);


                SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();

                _obj_Smhr_BusinessUnit.OPERATION = operation.SELECTEMPLOYEE1;
                _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //rcmb_BU.DataSource = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
                _obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcm_bu_trainee.SelectedItem.Value);
                if (dt121.Rows.Count != 0)
                {

                    _obj_Smhr_BusinessUnit.BUID = Convert.ToInt32(dt121.Rows[0]["TRAINERDETAILS_EMPLOYEEID"]);
                }
                else
                {
                    _obj_Smhr_BusinessUnit.BUID = 0;
                }
                

                DataTable dtemp21 = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
                rdlist_trainee.DataSource = dtemp21;
                if (dtemp21.Rows.Count != 0)
                {

                    rdlist_trainee.DataTextField = "EMPNAME";
                    rdlist_trainee.DataValueField = "EMP_ID";
                    rdlist_trainee.DataBind();


                    rdlist_trainee.Visible = true;
                    RadListBoxDestination.Visible = true;
                    //btn_save_traineelist.Visible = true;
                    //btn_cancel_traineelist.Visible = true;
                    rfv_rlistbox.Visible = true;
                }

                else
                {

                    rdlist_trainee.Items.Clear();
                    RadListBoxDestination.Items.Clear();

                }
            }


          
            Rm_Trainingrequest_PAGE1.SelectedIndex = 3;
            }
             else
         {
             BLL.ShowMessage(this, "Please Add Resources To Training");
             return;

             }
       }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
    protected void btn_save_traineelist_Click(object sender, EventArgs e)
    {

        try
        {
            if (RadListBoxDestination.Items.Count != 0)
            {

                SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();

                _obj_Smhr_TrnEE.Mode = 9;
                _obj_Smhr_TrnEE.TRAINEE_BUSINESSUNIT_ID = Convert.ToInt32(rcm_bu_trainee.SelectedItem.Value);
                _obj_Smhr_TrnEE.TRAINEE_TR_ID = Convert.ToInt32(Rcmb_training.SelectedItem.Value);
                _obj_Smhr_TrnEE.TRAINEE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dttraineeexist = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
                if (dttraineeexist.Rows.Count != 0)
                {
                    BLL.ShowMessage(this, "Trainee Already Assigned To This Training");


                }
                else
                {


                    _obj_Smhr_TrnEE = new SMHR_TRAINEE();




                    for (int i = 0; i < RadListBoxDestination.Items.Count; i++)
                    {
                        ListItem li = new ListItem();
                        li.Text = RadListBoxDestination.Items[i].Text;
                        li.Value = RadListBoxDestination.Items[i].Value;
                        int K = Convert.ToInt32(li.Value);
                        _obj_Smhr_TrnEE.TRAINEE_EMPID = Convert.ToInt32(K);

                        _obj_Smhr_TrnEE.TRAINEE_TR_ID = Convert.ToInt32(Rcmb_training.SelectedItem.Value);
                        _obj_Smhr_TrnEE.TRAINEE_BUSINESSUNIT_ID = Convert.ToInt32(rcm_bu_trainee.SelectedItem.Value);



                        _obj_Smhr_TrnEE.TRAINEE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Smhr_TrnEE.TRAINEE_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                        _obj_Smhr_TrnEE.TRAINEE_CREATEDDATE = DateTime.Now;
                        _obj_Smhr_TrnEE.Mode = 3;

                        bool status = BLL.set_TrgtrinEE(_obj_Smhr_TrnEE);

                        if (status == true)
                        {

                            Rm_Training_PAGE.SelectedIndex = 1;



                            var tabNewYork = rdtstrp.FindTabByText("Trainee");

                            tabNewYork.Enabled = false;
                            var tabNewYork1 = rdtstrp.FindTabByText("Training");

                            tabNewYork1.Enabled = false;
                            var tabNewYork2 = rdtstrp.FindTabByText("TrainingRequest");

                            tabNewYork2.Enabled = false;
                            var tabNewYork3 = rdtstrp.FindTabByText("Resources");

                            tabNewYork3.Enabled = false;
                            var tabNewYork4 = rdtstrp.FindTabByText("TrainingSchedule");

                            tabNewYork4.Enabled = true;

                            Rm_Trainingrequest_PAGE1.SelectedIndex = 4;

                            Loadcalendertraining();
                            //Appoint_panel.Visible = false;
                            //panel_Recuer_id.Visible = false;
                            //btn_save_calender.Visible = false;
                            //btn_cancel_calender.Visible = false;
                        }


                    }
                }

            }

            else
            {
                BLL.ShowMessage(this, "No Trainee Selected");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }



    }





    protected void btn_updatetrainee_click(object sender, EventArgs e)
    {

        try
        {



            SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();

            _obj_Smhr_TrnEE.TRAINEE_TR_ID = Convert.ToInt32(Rcmb_training.SelectedItem.Value);
            _obj_Smhr_TrnEE.Mode = 11;
            bool status1 = BLL.set_TrgtrinEE(_obj_Smhr_TrnEE);

            for (int i = 0; i < RadListBoxDestination.Items.Count; i++)
            {
                ListItem li = new ListItem();
                li.Text = RadListBoxDestination.Items[i].Text;
                li.Value = RadListBoxDestination.Items[i].Value;
                int K = Convert.ToInt32(li.Value);


                _obj_Smhr_TrnEE.TRAINEE_EMPID = Convert.ToInt32(K);

                _obj_Smhr_TrnEE.TRAINEE_TR_ID = Convert.ToInt32(Rcmb_training.SelectedItem.Value);
                _obj_Smhr_TrnEE.TRAINEE_BUSINESSUNIT_ID = Convert.ToInt32(rcm_bu_trainee.SelectedItem.Value);

                _obj_Smhr_TrnEE.TRAINEE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_TrnEE.TRAINEE_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
                _obj_Smhr_TrnEE.TRAINEE_CREATEDDATE = DateTime.Now;
                _obj_Smhr_TrnEE.Mode = 3;


                //_obj_Smhr_TrnEE.TRAINEE_LASTMDFBY = 1; // ### Need to Get the Session
                //_obj_Smhr_TrnEE.TRAINEE_LASTMDFDATE = DateTime.Now;
                //_obj_Smhr_TrnEE.Mode = 4;

                bool status = BLL.set_TrgtrinEE(_obj_Smhr_TrnEE);

                if (status == true)
                {

                   

                   
                  
                }


            }

            _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
            _obj_Smhr_TrgRqst.Mode = 7;
            _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(lbl_Tr_Id.Text);


            DataTable DT = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
            if (DT.Rows[0]["TS_TR_ID"] != System.DBNull.Value)
            {
                Loadcalendertraining();
                rcm_trg_calender.SelectedIndex = rcm_trg_calender.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["TS_TR_ID"]));
                rcm_trg_calender.Enabled = false;
                btn_save_calender.Visible = false;
                btn_update_calender.Visible = true;
            }

            else
            {
                Loadcalendertraining();
                rcm_trg_calender.SelectedIndex = 0;
                rcm_trg_calender.Enabled = true;
                btn_save_calender.Visible = true;
                btn_update_calender.Visible = false;
            }

         
            if (DT.Rows[0]["TS_STARTDATE"] != System.DBNull.Value)
            {
                rdtp_strtdate.SelectedDate = Convert.ToDateTime(DT.Rows[0]["TS_STARTDATE"]);
            }
            else
            {
                rdtp_strtdate.SelectedDate = null;
            }


            rtxt_sessions.Text = Convert.ToString(DT.Rows[0]["TS_SESSIONS"]);
            if (Convert.ToString(DT.Rows[0]["TS_RECURRENCETYPE"]) == "D")
            {
                rbtnlist_recuerence_id.SelectedValue = Convert.ToString(0);
                if (Convert.ToInt32(DT.Rows[0]["TS_SELECTIONPARAM"]) == 1)
                {
                    rd_every_id_daily.Checked = true;
                    txt_daily_id.Text = Convert.ToString(DT.Rows[0]["TS_PARAM1"]);
                }
                else
                {
                    rd_daily_weekday_id.Checked = true;

                }


            }
            else if (Convert.ToString(DT.Rows[0]["TS_RECURRENCETYPE"]) == "W")
            {
                rbtnlist_recuerence_id.SelectedValue = Convert.ToString(1);
                txt_weekly_id.Value = Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]);
                if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 1)
                {
                    chk_monday.Checked = true;
                }
                else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 1)
                {
                    chk_Tuesday.Checked = true;
                }
                else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM4"]) == 1)
                {
                    chk_Wednesday.Checked = true;
                }
                else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM5"]) == 1)
                {
                    chk_Thursday.Checked = true;
                }
                else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM6"]) == 1)
                {
                    chk_Friday.Checked = true;
                }

                else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM7"]) == 1)
                {
                    chk_Saturday.Checked = true;
                }
                else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM8"]) == 1)
                {
                    chk_Sunday.Checked = true;
                }




            }

            else if (Convert.ToString(DT.Rows[0]["TS_RECURRENCETYPE"]) == "M")
            {
                rbtnlist_recuerence_id.SelectedValue = Convert.ToString(2);
                if (Convert.ToInt32(DT.Rows[0]["TS_SELECTIONPARAM"]) == 1)
                {
                    rd_monthly_id.Checked = true;
                    txt_monthly_id.Text = Convert.ToString(DT.Rows[0]["TS_PARAM1"]);
                    txt_monthly_id1.Text = Convert.ToString(DT.Rows[0]["TS_PARAM2"]);
                }
                else
                {
                    rd_monthly_id5.Checked = true;
                    txt_monthly_id3.Text = Convert.ToString(DT.Rows[0]["TS_PARAM3"]);
                    if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 0)
                    {
                        ddl_monthly_id.SelectedItem.Text = "First";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 1)
                    {
                        ddl_monthly_id.SelectedItem.Text = "Second";
                    }
                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 2)
                    {
                        ddl_monthly_id.SelectedItem.Text = "Third";
                    }
                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 3)
                    {
                        ddl_monthly_id.SelectedItem.Text = "Fourth";
                    }
                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 4)
                    {
                        ddl_monthly_id.SelectedItem.Text = "Last";
                    }

                    if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 0)
                    {
                        ddl_monthly_id2.SelectedItem.Text = "Sunday";
                    }
                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 1)
                    {
                        ddl_monthly_id2.SelectedItem.Text = "Monday";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 2)
                    {
                        ddl_monthly_id2.SelectedItem.Text = "Tuesday";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 3)
                    {
                        ddl_monthly_id2.SelectedItem.Text = "Wednesday";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 4)
                    {
                        ddl_monthly_id2.SelectedItem.Text = "Thrusday";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 5)
                    {
                        ddl_monthly_id2.SelectedItem.Text = "Friday";
                    }
                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 6)
                    {
                        ddl_monthly_id2.SelectedItem.Text = "Saturday";
                    }


                }

            }

            else if (Convert.ToString(DT.Rows[0]["TS_RECURRENCETYPE"]) == "Y")
            {
                rbtnlist_recuerence_id.SelectedValue = Convert.ToString(3);
                if (Convert.ToInt32(DT.Rows[0]["TS_SELECTIONPARAM"]) == 1)
                {
                    rd_yearly_id.Checked = true;
                    txt_yearly_id.Text = Convert.ToString(DT.Rows[0]["TS_PARAM2"]);
                    if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 1)
                    {
                        ddl_yearly_id2.SelectedItem.Text = "January";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 2)
                    {
                        ddl_yearly_id2.SelectedItem.Text = "February";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 3)
                    {
                        ddl_yearly_id2.SelectedItem.Text = "March";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 4)
                    {
                        ddl_yearly_id2.SelectedItem.Text = "April";
                    }
                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 5)
                    {
                        ddl_yearly_id2.SelectedItem.Text = "May";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 6)
                    {
                        ddl_yearly_id2.SelectedItem.Text = "June";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 7)
                    {
                        ddl_yearly_id2.SelectedItem.Text = "July";
                    }


                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 8)
                    {
                        ddl_yearly_id2.SelectedItem.Text = "August";
                    }
                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 9)
                    {
                        ddl_yearly_id2.SelectedItem.Text = "September";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 10)
                    {
                        ddl_yearly_id2.SelectedItem.Text = "October";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 11)
                    {
                        ddl_yearly_id2.SelectedItem.Text = "November";
                    }


                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 12)
                    {
                        ddl_yearly_id2.SelectedItem.Text = "December";
                    }







                }
                else
                {
                    rd_yearly_id3.Checked = true;
                    //FIRST
                    if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 0)
                    {
                        ddl_yearly_id3.SelectedItem.Text = "First";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 1)
                    {
                        ddl_yearly_id3.SelectedItem.Text = "Second";
                    }
                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 2)
                    {
                        ddl_yearly_id3.SelectedItem.Text = "Third";
                    }
                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 3)
                    {
                        ddl_yearly_id3.SelectedItem.Text = "Fourth";
                    }
                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM1"]) == 4)
                    {
                        ddl_yearly_id3.SelectedItem.Text = "Last";
                    }


                    //DAYS
                    if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 0)
                    {
                        ddl_yearly_id.SelectedItem.Text = "Sunday";
                    }
                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 1)
                    {
                        ddl_yearly_id.SelectedItem.Text = "Monday";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 2)
                    {
                        ddl_yearly_id.SelectedItem.Text = "Tuesday";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 3)
                    {
                        ddl_yearly_id.SelectedItem.Text = "Wednesday";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 4)
                    {
                        ddl_yearly_id.SelectedItem.Text = "Thrusday";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 5)
                    {
                        ddl_yearly_id.SelectedItem.Text = "Friday";
                    }
                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM2"]) == 6)
                    {
                        ddl_yearly_id.SelectedItem.Text = "Saturday";
                    }



                    //YERALY
                    if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 1)
                    {
                        ddl_yearly_id4.SelectedItem.Text = "January";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 2)
                    {
                        ddl_yearly_id4.SelectedItem.Text = "February";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 3)
                    {
                        ddl_yearly_id4.SelectedItem.Text = "March";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 4)
                    {
                        ddl_yearly_id4.SelectedItem.Text = "April";
                    }
                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 5)
                    {
                        ddl_yearly_id4.SelectedItem.Text = "May";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 6)
                    {
                        ddl_yearly_id4.SelectedItem.Text = "June";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 7)
                    {
                        ddl_yearly_id4.SelectedItem.Text = "July";
                    }


                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 8)
                    {
                        ddl_yearly_id4.SelectedItem.Text = "August";
                    }
                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 9)
                    {
                        ddl_yearly_id4.SelectedItem.Text = "September";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 10)
                    {
                        ddl_yearly_id4.SelectedItem.Text = "October";
                    }

                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 11)
                    {
                        ddl_yearly_id4.SelectedItem.Text = "November";
                    }


                    else if (Convert.ToInt32(DT.Rows[0]["TS_PARAM3"]) == 12)
                    {
                        ddl_yearly_id4.SelectedItem.Text = "December";
                    }






                }

            }
            if (DT.Rows[0]["TS_STARTTIME"] != System.DBNull.Value)
            {
                rtp_starttime.SelectedDate = Convert.ToDateTime(DT.Rows[0]["TS_STARTTIME"]);
            }
            else
            {
                rtp_starttime.SelectedDate = null;
            }
            if (DT.Rows[0]["TS_endTIME"] != System.DBNull.Value)
            {
                rtp_endtime.SelectedDate = Convert.ToDateTime(DT.Rows[0]["TS_endTIME"]);
            }
            else
            {
                rtp_endtime.SelectedDate = null;
            }
            Rm_Training_PAGE.SelectedIndex = 1;



            var tabNewYork = rdtstrp.FindTabByText("Trainee");

            tabNewYork.Enabled = false;
            var tabNewYork1 = rdtstrp.FindTabByText("Training");

            tabNewYork1.Enabled = false;
            var tabNewYork2 = rdtstrp.FindTabByText("TrainingRequest");

            tabNewYork2.Enabled = false;
            var tabNewYork3 = rdtstrp.FindTabByText("Resources");

            tabNewYork3.Enabled = false;
            var tabNewYork4 = rdtstrp.FindTabByText("TrainingSchedule");

            tabNewYork4.Enabled = true;

            Rm_Trainingrequest_PAGE1.SelectedIndex = 4;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }



    }
    protected void Rcmb_training_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
        if (Rcmb_training.SelectedItem.Text != "Select")
        {
            rdlist_trainee.Items.Clear();
            SMHR_TRAINER _obj_Smhr_Trner = new SMHR_TRAINER();
            _obj_Smhr_Trner.Mode = 6;//TO GET TRAINER IN THAT BUSINESS UNIT
            _obj_Smhr_Trner.TRAINERDETAILS_BUSINESSUNITID = Convert.ToInt32(rcm_bu_trainee.SelectedItem.Value);
            _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(Rcmb_training.SelectedItem.Value);
            DataTable dt1 = BLL.get_TRAINer(_obj_Smhr_Trner);



            SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            _obj_Smhr_BusinessUnit.OPERATION = operation.SELECTEMPLOYEE1;
            _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //rcmb_BU.DataSource = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            _obj_Smhr_BusinessUnit.BUSINESSUNIT_ID = Convert.ToInt32(rcm_bu_trainee.SelectedItem.Value);
            if (dt1.Rows.Count != 0)
            {

                _obj_Smhr_BusinessUnit.BUID = Convert.ToInt32(dt1.Rows[0]["TRAINERDETAILS_EMPLOYEEID"]);
            }
            else
            {
                _obj_Smhr_BusinessUnit.BUID = 0;
            }
            DataTable dtemp = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            rdlist_trainee.DataSource = dtemp;
            if (dtemp.Rows.Count != 0)
            {
                //Cur = Convert.ToString(dtemp.Rows[0]["BUSINESSUNIT_CURRENCY_ID"]).ToString();
                rdlist_trainee.DataTextField = "EMPNAME";
                rdlist_trainee.DataValueField = "EMP_ID";
                rdlist_trainee.DataBind();

                //rdlist_trainee.Items.Insert(0, new Telerik.Web.UI.RadListBoxItem("Select", "0"));
                rdlist_trainee.Visible = true;
                RadListBoxDestination.Visible = true;
                btn_save_traineelist.Visible = true;
                btn_cancel_traineelist.Visible = true;
                rfv_rlistbox.Visible = true;
            }

            else
            {
                BLL.ShowMessage(this, "There are No employees in this Business Unit, Please select another");
                rdlist_trainee.Items.Clear();
                RadListBoxDestination.Items.Clear();
                btn_save_traineelist.Visible = false;
                btn_cancel_traineelist.Visible = false;
            }
        }

        else
        {
            BLL.ShowMessage(this, "Please Select Training");
            rdlist_trainee.Items.Clear();
            RadListBoxDestination.Items.Clear();
            btn_save_traineelist.Visible = false;
            btn_cancel_traineelist.Visible = false;
        }


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
       
    }

    //protected void rcm_trg_calender_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    if (rcm_trg_calender.SelectedItem.Text != "Select")
    //    {
    //        Appoint_panel.Visible = true;
    //        panel_Recuer_id.Visible = true;
    //        btn_save_calender.Visible = true;
    //        btn_cancel_calender.Visible = true;
    //        rcm_trg_calender.Enabled = false;
    //    }
    //    else
    //    {
    //        BLL.ShowMessage(this, "Please Select Training");
    //        Appoint_panel.Visible = false;
    //        panel_Recuer_id.Visible = false;
    //        btn_save_calender.Visible = false;
    //        btn_cancel_calender.Visible = false;
    //        rcm_trg_calender.Enabled = true;
    //    }
    //}
    protected void rcm_bu_trainee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
     {
         try
        {
        if (rcm_bu_trainee.SelectedItem.Text != "Select")
        {
            Loadtraineetraining();
           
            rfv_rlistbox.Visible = false;
            RadListBoxDestination.Items.Clear();
            rdlist_trainee.Visible = false;
            RadListBoxDestination.Visible = false;
            btn_save_traineelist.Visible = false;
            btn_cancel_traineelist.Visible = false;

        }

        else
        {
            DataTable dt = new DataTable();
            Rcmb_training.DataSource = dt;

            Rcmb_training.DataBind();
            RadListBoxDestination.Items.Clear();
            rdlist_trainee.Visible = false;
            RadListBoxDestination.Visible = false;
            btn_save_traineelist.Visible = false;
            btn_cancel_traineelist.Visible = false;

        }
        }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
       

    }

    protected void rcmb_Course_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            int Course_selected = Convert.ToInt32(rcmb_Course.SelectedItem.Value);
            rcmb_CourseType.Items.Clear();
            SMHR_COURSE _obj_Smhr_Course = new SMHR_COURSE();
            _obj_Smhr_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Course.OPERATION = operation.Select_New;
            _obj_Smhr_Course.COURSE_BUSINESSUNIT_ID = Course_selected;
            DataTable dt = BLL.get_Course(_obj_Smhr_Course);
            rcmb_CourseType.DataSource = dt;
            rcmb_CourseType.DataTextField = "COURSE_NAME";
            rcmb_CourseType.DataValueField = "COURSE_ID";
            rcmb_CourseType.DataBind();
            rcmb_CourseType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            _obj_Smhr_Masters = new SMHR_MASTERS();
            //Load PayItem Type


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingRequest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}


