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
public partial class Training_frm_TrainingSchedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                rtp_starttime.SelectedDate = null;
                rtp_endtime.SelectedDate = null;
                rdtp_strtdate.SelectedDate = null;
                rdtp_enddate.SelectedDate = null;
                pnl_daily.Visible = false;
                pnl_weekly.Visible = false;
                pnl_monthly.Visible = false;
                pnl_yearly.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingSchedule", ex.StackTrace, DateTime.Now);
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
                    rtxt_duration.Text = Convert.ToString(dur.TotalHours);
                }
                else
                {
                    Pms_Bll.ShowMessage(this, "End Time Should Be Greater Start Time");
                    rtp_endtime.SelectedDate = null;
                }

            }
            else
            {
                Pms_Bll.ShowMessage(this, "Please Select Start Time");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingSchedule", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingSchedule", ex.StackTrace, DateTime.Now);
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
    protected void rdtp_enddate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            if (rdtp_strtdate.SelectedDate.HasValue)
            {
                DateTime strtdate = rdtp_strtdate.SelectedDate.Value;

                DateTime enddate = rdtp_enddate.SelectedDate.Value;
                if (enddate < strtdate)
                {
                    Pms_Bll.ShowMessage(this, "End Date Should Be Greater Start Date");
                    rdtp_enddate.SelectedDate = null;

                }

            }
            else
            {
                Pms_Bll.ShowMessage(this, "Please Enter Start Date");
                rdtp_enddate.SelectedDate = null;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingSchedule", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
