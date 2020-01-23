using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using SMHR;

public partial class Masters_Default3 : System.Web.UI.Page
{
    SMHR_DAHSBOARD _obj_smhr_Dashboard;
    SMHR_LEAVEAPP _obj_smhr_Leaveapp;
    SMHR_EMPCOMOFF _obj_smhr_Compoff;
    SMHR_EXPENSE _obj_smhr_Expense;
    SMHR_RECRUITMENTUPDATES _obj_smhr_Recruitmentupdates;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                Session["DASHBOARD"] = "true";

            }

            if (Convert.ToString(Session["EMP_ID"]) == "")
            {
                Response.Redirect("Login.aspx", false);
            }
            if (!Page.IsPostBack)
            {
                lbl_Birthday.Text = "BIRTHDAY REMINDERS - " + DateTime.Now.ToLongDateString().ToUpper();
                getBirthday();

                string str_Loginid = Convert.ToString(Session["USER_ID"]);

                _obj_smhr_Dashboard = new SMHR_DAHSBOARD();

                //CODE FOR FETCHING EMPLOYEE NAME
                _obj_smhr_Dashboard.OPERATION = operation.Select;
                _obj_smhr_Dashboard.SMHR_DASHBOARD_EMP_ID = Convert.ToInt32(str_Loginid);
                DataTable dt_getEMP_NAME = BLL.get_EMP_ID(_obj_smhr_Dashboard);
                if (dt_getEMP_NAME.Rows.Count != 0)
                {
                    lbl_EmpName.Text = Convert.ToString(dt_getEMP_NAME.Rows[0][0]);
                    lbl_EmpBloodGroup.Text = Convert.ToString(dt_getEMP_NAME.Rows[0][1]);
                }
                else
                {
                    BLL.ShowMessage(this, "No employee name exists for this login id");
                    //Response.Redirect("~/Login.aspx");
                }

                //CODE FOR FETCHING EMPLOYEE ID
                _obj_smhr_Dashboard.OPERATION = operation.Select_Emp;
                _obj_smhr_Dashboard.SMHR_DASHBOARD_LOGIN_ID = Convert.ToInt32(str_Loginid);
                DataTable dt_getEMP_ID = BLL.get_EMP_ID(_obj_smhr_Dashboard);

                string STR_EMP_ID = Convert.ToString(dt_getEMP_ID.Rows[0][0]);
                lbl_EmpId.Text = STR_EMP_ID;

                //CODE FOR FETCHING EMPLOYEE DESIGNATION
                _obj_smhr_Dashboard.OPERATION = operation.Select_Pos;
                _obj_smhr_Dashboard.SMHR_DASHBOARD_EMP_ID = Convert.ToInt32(STR_EMP_ID);
                DataTable dt_getEMP_DESG = BLL.get_EMP_ID(_obj_smhr_Dashboard);

                lbl_EmpDesignation.Text = Convert.ToString(dt_getEMP_DESG.Rows[0][0]);

                //CODE FOR FETCHING EMPLOYEE DEPARTMENT
                _obj_smhr_Dashboard.OPERATION = operation.Select_Dept;
                _obj_smhr_Dashboard.SMHR_DASHBOARD_EMP_ID = Convert.ToInt32(STR_EMP_ID);
                DataTable dt_getEMP_DEPT = BLL.get_EMP_ID(_obj_smhr_Dashboard);

                lbl_EmpDepartment.Text = Convert.ToString(dt_getEMP_DEPT.Rows[0][0]);


                //NO of Pending Leave Applications
                _obj_smhr_Leaveapp = new SMHR_LEAVEAPP();
                _obj_smhr_Leaveapp.OPERATION = operation.Check_New;
                _obj_smhr_Leaveapp.LEAVEAPP_STATUS = Convert.ToInt32(0);
                _obj_smhr_Leaveapp.LEAVEAPP_APPROVEDBY = Convert.ToInt32(STR_EMP_ID);
                DataTable dt_NoOfPendingLeave = BLL.get_LeaveApp(_obj_smhr_Leaveapp);
                lbl_pendingleave.Text = Convert.ToString(dt_NoOfPendingLeave.Rows[0][0]);


                //No of Pending Comp-Off Application
                _obj_smhr_Compoff = new SMHR_EMPCOMOFF();
                _obj_smhr_Compoff.OPERATION = operation.Check_New;
                _obj_smhr_Compoff.EMPCOMPOFF_STATUS = Convert.ToInt32(0);
                _obj_smhr_Compoff.EMPCOMPOFF_APPROVEDBY = Convert.ToInt32(STR_EMP_ID);
                DataTable dt_NoOfPendingCOMPOFF = BLL.get_empcompffs(_obj_smhr_Compoff);
                lbl_pendingcompoff.Text = Convert.ToString(dt_NoOfPendingCOMPOFF.Rows[0][0]);

                //No of Pending Expense Applications
                _obj_smhr_Expense = new SMHR_EXPENSE();
                _obj_smhr_Expense.OPERATION = operation.Check_New;
                _obj_smhr_Expense.EXPENSE_STATUS = Convert.ToInt32(0);
                _obj_smhr_Expense.EXPENSE_APPROVEDBY = Convert.ToInt32(STR_EMP_ID);
                DataTable dt_NoOfPendingExpense = BLL.get_Expense(_obj_smhr_Expense);
                lbl_pendingexpense.Text = Convert.ToString(dt_NoOfPendingExpense.Rows[0][0]);


                //No of Pending Loan Applications


                //EMPLOYEE LEAVE APPLICATION STATUS
                _obj_smhr_Leaveapp = new SMHR_LEAVEAPP();
                _obj_smhr_Leaveapp.OPERATION = operation.Select_New;

                _obj_smhr_Leaveapp.EMP_ID = Convert.ToInt32(STR_EMP_ID);
                DataTable dt_leavestatus = BLL.get_LeaveApp(_obj_smhr_Leaveapp);
                int int_NoOfLeaves = dt_leavestatus.Rows.Count;
                if (int_NoOfLeaves == 0)
                {
                    lbl_MgrLeaveAppStatus.Text = "No leave application status available";
                    //BLL.ShowMessage(this, "No data available");
                }
                else
                {
                    int lastLeaveStatus = Convert.ToInt32(dt_leavestatus.Rows[int_NoOfLeaves - 1][0]);
                    if (lastLeaveStatus == 0)
                        lbl_MgrLeaveAppStatus.Text = "Leave Application Pending";
                    else if (lastLeaveStatus == 1)
                        lbl_MgrLeaveAppStatus.Text = "Leave Application Approved";
                    else if (lastLeaveStatus == 2)
                        lbl_MgrLeaveAppStatus.Text = "Leave Application Rejected";
                    else if (lastLeaveStatus == 3)
                        lbl_MgrLeaveAppStatus.Text = "Leave Application Cancelled";
                    else
                        lbl_MgrLeaveAppStatus.Text = "Leave Application Not Found";
                }

                //EMPLOYEE COMP-OFF APPLICATION STATUS
                _obj_smhr_Compoff = new SMHR_EMPCOMOFF();
                _obj_smhr_Compoff.OPERATION = operation.Select_New;
                _obj_smhr_Compoff.EMP_ID = Convert.ToInt32(STR_EMP_ID);
                DataTable dt_compoff = BLL.get_empcompffs(_obj_smhr_Compoff);
                int int_NoOfCompOff = dt_compoff.Rows.Count;
                if (int_NoOfCompOff == 0)
                {
                    lbl_MgrCompOffAppStatus.Text = "No comp-off application status available";
                    // BLL.ShowMessage(this, "No data available");
                }
                else
                {
                    int lastCompOffStatus = Convert.ToInt32(dt_compoff.Rows[(int_NoOfCompOff) - 1][0]);
                    if (lastCompOffStatus == 0)
                        lbl_MgrCompOffAppStatus.Text = "Comp-Off Application Pending";
                    else if (lastCompOffStatus == 1)
                        lbl_MgrCompOffAppStatus.Text = "Comp-Off Application Approved";
                    else if (lastCompOffStatus == 2)
                        lbl_MgrCompOffAppStatus.Text = "Comp-Off Applicaiton Rejected";
                    else if (lastCompOffStatus == 3)
                        lbl_MgrCompOffAppStatus.Text = "Comp-Off Application Cancelled";
                    else
                        lbl_MgrCompOffAppStatus.Text = "Comp-Off Application Not Found";
                }


                //EMPLOYEE EXPENSE APPLICATION STATUS
                _obj_smhr_Expense = new SMHR_EXPENSE();
                _obj_smhr_Expense.OPERATION = operation.Select_New;
                _obj_smhr_Expense.EMP_ID = Convert.ToInt32(STR_EMP_ID);
                DataTable dt_expense = BLL.get_Expense(_obj_smhr_Expense);

                int int_NoOfExpense = dt_compoff.Rows.Count;
                if (int_NoOfExpense == 0)
                {
                    lbl_MgrExpenseAppStatus.Text = "No expense application status available";
                }
                else
                {
                    int lastExpenseStatus = Convert.ToInt32(dt_compoff.Rows[(int_NoOfExpense) - 1][0]);
                    if (lastExpenseStatus == 0)
                        lbl_MgrExpenseAppStatus.Text = "Expense Application Pending";
                    else if (lastExpenseStatus == 1)
                        lbl_MgrExpenseAppStatus.Text = "Expense Application Approved";
                    else if (lastExpenseStatus == 2)
                        lbl_MgrExpenseAppStatus.Text = "Expense Application Rejected";
                    else if (lastExpenseStatus == 3)
                        lbl_MgrExpenseAppStatus.Text = "Expense Application Cancelled";
                    else
                        lbl_MgrExpenseAppStatus.Text = "Expense Application Not Found";
                }



                //Modified
                #region Pie-Chart for Ytd Balances
                _obj_smhr_Dashboard = new SMHR_DAHSBOARD();

                string str_MonthNo = DateTime.Now.Month.ToString();
                System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                string str_Period_Month = mfi.GetMonthName(Convert.ToInt32(str_MonthNo));

                string str_Period_Year = DateTime.Now.Year.ToString();
                string str_PeriodName = str_Period_Month.ToUpper() + " " + str_Period_Year;
                _obj_smhr_Dashboard.OPERATION = operation.Check_New;
                _obj_smhr_Dashboard.SMHR_DASHBOARD_PERIODNAME = str_PeriodName;
                DataTable dt_PeriodID = BLL.get_EMP_ID(_obj_smhr_Dashboard);
                if (dt_PeriodID.Rows.Count == 0)
                {
                    //DataTable dt_ZeroYtdBalance = new DataTable();

                    //BLL.ShowMessage(this, "No data available");
                }
                string str_PeriodId = Convert.ToString(dt_PeriodID.Rows[0][0]);
                _obj_smhr_Dashboard.OPERATION = operation.Check1;
                _obj_smhr_Dashboard.SMHR_DASHBOARD_EMP_ID = Convert.ToInt32(STR_EMP_ID);
                _obj_smhr_Dashboard.SMHR_DASHBOARD_PERIODID = Convert.ToInt32(str_PeriodId);
                DataTable dt_YtdBalance = BLL.get_EMP_ID(_obj_smhr_Dashboard);
                if (dt_YtdBalance.Rows.Count == 0)
                {
                    DataTable dt_ZeroYtdBalance = new DataTable();
                    DataRow dr_ZeroYtdBalance = dt_ZeroYtdBalance.NewRow();
                    DataColumn dc_ZeroYtdBalance = new DataColumn();
                    DataColumn dc_ZeroPayItem_PayDesc = new DataColumn();
                    dc_ZeroYtdBalance.ColumnName = "YtdBalance";
                    dc_ZeroPayItem_PayDesc.ColumnName = "payitem_paydesc";
                    dt_ZeroYtdBalance.Columns.Add(dc_ZeroYtdBalance);
                    dt_ZeroYtdBalance.Columns.Add(dc_ZeroPayItem_PayDesc);
                    dr_ZeroYtdBalance["YtdBalance"] = "0.00";
                    dr_ZeroYtdBalance["payitem_paydesc"] = "Ytd Balances";
                    dt_ZeroYtdBalance.Rows.Add(dr_ZeroYtdBalance);
                    RadChart_YtdBalances.DataSource = dt_ZeroYtdBalance;
                    RadChart_YtdBalances.DataBind();

                    //RadChart_YtdBalances.Visible = false;
                    //BLL.ShowMessage(this, "No data  available for ytd balances");
                }
                else
                {
                    RadChart_YtdBalances.DataSource = dt_YtdBalance;
                    RadChart_YtdBalances.DataBind();
                }

                #endregion

                //Pie-chart
                #region Pie-Chart for Leave Balance
                bool status = false;
                _obj_smhr_Dashboard = new SMHR_DAHSBOARD();
                string str_Current_Year = DateTime.Now.Year.ToString();
                _obj_smhr_Dashboard.SMHR_DASHBOARD_PERIODNAME = str_Current_Year;
                _obj_smhr_Dashboard.OPERATION = operation.Select_Period;
                DataTable dt_Period_ID = BLL.get_EMP_ID(_obj_smhr_Dashboard);
                string str_Period_Name = Convert.ToString(dt_Period_ID.Rows[0][0]);
                _obj_smhr_Dashboard.OPERATION = operation.Select_New;
                _obj_smhr_Dashboard.SMHR_DASHBOARD_PERIODNAME = str_Period_Name;
                _obj_smhr_Dashboard.SMHR_DASHBOARD_EMP_ID = Convert.ToInt32(STR_EMP_ID);
                DataTable dt_LeaveBalance = BLL.get_EMP_ID(_obj_smhr_Dashboard);
                if (dt_LeaveBalance.Rows.Count != 0)
                {

                    for (int int_rowcount = 0; int_rowcount < dt_LeaveBalance.Rows.Count; int_rowcount++)
                    {

                        if (Convert.ToDouble(dt_LeaveBalance.Rows[int_rowcount]["LT_CURRENTBALANCE"]) == 0.00)
                        {
                            //BLL.ShowMessage(this, "No leaves to have fun");
                            lbl_zeroleave.Visible = true;
                            lbl_zeroleave.Text = "No leaves available";
                            status = true;
                        }
                    }
                    if (status == false)
                    {
                        RadChart2.Visible = true;
                        RadChart2.DataSource = dt_LeaveBalance;
                        RadChart2.DataBind();
                    }
                }
                else
                {
                    lbl_zeroleave.Visible = true;
                    lbl_zeroleave.Text = "No leaves available";
                    //BLL.ShowMessage(this, "No data available for leave balances");
                }
                #endregion

                #region Pie-Chart for Performance Hikes
                _obj_smhr_Dashboard = new SMHR_DAHSBOARD();
                _obj_smhr_Dashboard.OPERATION = operation.Select_Hike;
                _obj_smhr_Dashboard.SMHR_DASHBOARD_EMP_ID = Convert.ToInt32(STR_EMP_ID);
                DataTable dt_Hike = BLL.get_EMP_ID(_obj_smhr_Dashboard);
                if (dt_Hike.Rows.Count != 0)
                {

                    for (int int_rowcount = 0; int_rowcount < dt_Hike.Rows.Count; int_rowcount++)
                    {

                        if (Convert.ToDouble(dt_Hike.Rows[int_rowcount]["Hike"]) == 0.00)
                        {
                            //BLL.ShowMessage(this, "No leaves to have fun");
                            lbl_zerohike.Visible = true;
                            lbl_zerohike.Text = "No leaves available";
                            status = true;
                        }
                    }
                    if (status == false)
                    {

                        RadChart_Performance.Visible = true;
                        RadChart_Performance.DataSource = dt_Hike;
                        RadChart_Performance.DataBind();
                    }
                }
                else
                {
                    lbl_zerohike.Visible = true;
                    lbl_zerohike.Text = "No leaves to have fun";
                    //BLL.ShowMessage(this, "No data available for leave balances");
                }
                #endregion

                //Code For scrolling text
                //_obj_smhr_Recruitmentupdates = new SMHR_RECRUITMENTUPDATES();
                //_obj_smhr_Recruitmentupdates.OPERATION = operation.Select_New;
                //_obj_smhr_Recruitmentupdates.SMHR_CURRENTDATE = DateTime.Now;
                //DataTable dt_RecruitmentUpdates = BLL.get_RecruitmentUpdates(_obj_smhr_Recruitmentupdates);
                //if (dt_RecruitmentUpdates.Rows.Count != 0)
                //{
                //    //string str_ReqName = dt_RecruitmentUpdates.Rows[0]["JOBREQ_REQNAME"].ToString();
                //    Radticker1.DataSource = dt_RecruitmentUpdates;// dt_RecruitmentUpdates;
                //    Radticker1.DataTextField = "JOBREQ_UPDATE";
                //    //Radticker1.DataMember = str_ReqName;
                //    Radticker1.DataBind();
                //}
                //else
                //{
                //    BLL.ShowMessage(this, "Recruitment are closed now");
                //}

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboard1", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


        

        
    }

    private void getBirthday()
    {
        try
        {
            SMHR_EMPLOYEE _obj_smhr_Employee = new SMHR_EMPLOYEE();
            _obj_smhr_Employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtDetails = BLL.get_Birthday(_obj_smhr_Employee);
            if (dtDetails.Rows.Count != 0)
            {
                RTicker.DataSource = dtDetails;
                RTicker.DataTextField = "EMPNAME";
                RTicker.DataBind();
            }
            else
            {
                lbl_Reminders.Text = "NO BIRTHDAYS TODAY";
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboard1", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
        
    protected void RadChart2_ItemDataBound(object sender, Telerik.Charting.ChartItemDataBoundEventArgs e)
    {
        try
        {
            e.SeriesItem.Name = ((DataRowView)e.DataItem)["LeaveMaster_description"].ToString();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboard1", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void RadChart_YtdBalances_ItemDataBound(object sender, Telerik.Charting.ChartItemDataBoundEventArgs e)
    {
        try
        {
            e.SeriesItem.Name = ((DataRowView)e.DataItem)["payitem_paydesc"].ToString();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboard1", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void RadChart_Performance_ItemDataBound(object sender, Telerik.Charting.ChartItemDataBoundEventArgs e)
    {
        try
        {
            e.SeriesItem.Name = ((DataRowView)e.DataItem)["Hike"].ToString();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboard1", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}
