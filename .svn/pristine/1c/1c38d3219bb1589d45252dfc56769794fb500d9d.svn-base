using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using System.Text;
using Telerik.Web.UI;


public partial class Training_frm_CourseCalendar : System.Web.UI.Page
{
    SMHR_SCHEDULE _obj_Smhr_Schedule;
    private void Page_Load(object sender, EventArgs e)
    {
        LoadGrid();
        
        //RadScheduler1.FormCreating += new Telerik.Web.UI.SchedulerFormCreatingEventHandler(RadScheduler1_FormCreating);
    }

    //void RadScheduler1_FormCreating(object sender, Telerik.Web.UI.SchedulerFormCreatingEventArgs e)
    //{
    //    if (e.Mode == Telerik.Web.UI.SchedulerFormMode.Insert)
    //    {
    //        Telerik.Web.UI.RadScheduler scheduler = (Telerik.Web.UI.RadScheduler)sender;
    //        scheduler.InsertAppointment(e.Appointment);
    //        e.Cancel = true;
    //    }
    //} 

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
     }

    protected void LoadGrid()
    {

        try
        {

            _obj_Smhr_Schedule = new SMHR_SCHEDULE();
            _obj_Smhr_Schedule.Tr_Id = 1;
            _obj_Smhr_Schedule.OPERATION = operation.Select;
            DataTable dt = BLL.GetSceduleDetails(_obj_Smhr_Schedule);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int a = Convert.ToInt32(dt.Rows[i]["Tr_Id"].ToString());
                string b = Convert.ToString(dt.Rows[i]["Tr_Name"].ToString());
                string c = Convert.ToString(dt.Rows[i]["Tr_TrainerName"].ToString());
                RadScheduler1.InsertAppointment(new Appointment(a, Convert.ToDateTime(dt.Rows[i]["Tr_Date"].ToString()),Convert.ToDateTime(dt.Rows[i]["Tr_End"].ToString()),b));
                    //Convert.ToDateTime(dt.Rows[i]["Tr_Date"].ToString()), Convert.ToDateTime(dt.Rows[i]["Tr_Time"].ToString()),c, b));

                RadScheduler1.ToolTip = "<table width='250' border='0'> " +
                                        "<tr> " +
                                        "<td> <h4> Training Details </h4> </td>" +
                                        "</tr> " +

                                        "<tr> " +
                                        "<td> <br/>" +
                                        "</td> " +
                                        "</tr> " +
                                        "<tr> " +
                                        "<td> Training Title :" + Convert.ToString(dt.Rows[0]["Tr_Name"]) + " </td> " +
                                        "</tr> " +
                                        "<tr> " +
                                        "<td> From : " + Convert.ToString(dt.Rows[0]["Tr_Date"]) + "</td> " +
                                        "</tr> " +
                                        "<tr> " +
                                        "<td> To :  " + Convert.ToString(dt.Rows[0]["Tr_End"]) + "</td> " +
                                        "</tr> " +
                                         "</tr> " +
                                        "<tr> " +
                                        "<td> Time :  " + Convert.ToString(dt.Rows[0]["Tr_Time"]) + "</td> " +
                                        "</tr> " +
                                          "<tr> " +
                                        "<td> Trainer :  " + Convert.ToString(dt.Rows[0]["Tr_TrainerName"]) + "</td> " +
                                        "</tr> " +
                                        "</table><br/>";
                                      
                //Appointment a = new Appointment();
                //int a = Convert.ToInt32(dt.Rows[i]["Tr_Id"].ToString());
                //string b = Convert.ToString(dt.Rows[i]["Tr_Name"].ToString());
                ////string c = Convert.ToString(dt.Rows[i]["COURSESHD_AMOUNT"].ToString());
                //RadScheduler1.InsertAppointment(new Appointment(a));

            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CourseCalendar", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //    //DLC_COURSE_SCHEDULE _obj_Dlc_Course_Schedule = new DLC_COURSE_SCHEDULE();
    //    //_obj_Dlc_Course_Schedule.COURSESHD_ROOM_ID = Convert.ToInt32(rcmb_RoomNo.SelectedValue);
    //    //_obj_Dlc_Course_Schedule.COURSESHD_STARTDATE = Convert.ToDateTime(radStartDate.SelectedDate);
    //    //_obj_Dlc_Course_Schedule.COURSESHD_ENDDATE = Convert.ToDateTime(rdpEndDate.SelectedDate);
    //    //_obj_Dlc_Course_Schedule.COURSESHD_LOCATION_ID = Convert.ToInt32(rcmb_LocationName.SelectedValue);  
    //    //DataTable dt = new DataTable();
    //    //dt = Admin_Bll.CourseTimeTable(_obj_Dlc_Course_Schedule);
    //    //for (int i = 0; i < dt.Rows.Count; i++)
    //    //{
    //    //    int a = Convert.ToInt32(dt.Rows[i]["COURSESHD_ID"].ToString());
    //    //    string b = Convert.ToString(dt.Rows[i]["COURSESHD_NAME"].ToString());
    //    //   // string c = Convert.ToString(dt.Rows[i]["COURSESHD_AMOUNT"].ToString());
    //    //    RadScheduler1.InsertAppointment(new Appointment(a, Convert.ToDateTime(dt.Rows[i]["COURSESHD_STARTTIME"].ToString()), Convert.ToDateTime(dt.Rows[i]["COURSESHD_ENDTIME"].ToString()), b));
  
    //    //}

    protected void RadToolTipManager1_AjaxUpdate(object sender, ToolTipUpdateEventArgs e)
    {
    }
    }
