using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Text;
using SMHR;
using System.Drawing;
using SPMS;

public partial class Masters_Default3 : System.Web.UI.Page
{
    SMHR_DAHSBOARD _obj_smhr_Dashboard;
    SMHR_LEAVEAPP _obj_smhr_Leaveapp;
    SMHR_EMPCOMOFF _obj_smhr_Compoff;
    SMHR_EXPENSE _obj_smhr_Expense;
    SMHR_ANNOUNCEMENT _obj_smhr_Announcement;
    SMHR_EMPLOYEE _obj_smhr_employee;
    string STR_EMP_ID = string.Empty;
    SMHR_RECRUITMENTUPDATES _obj_smhr_Recruitmentupdates;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Request.QueryString["ctrl"]) == "SS")
            {
                BLL.ShowMessage(this, "You dont have enough priveleges to access this screen");
                return;
            }
            getDoj();
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){   }", true);
            if (!Page.IsPostBack)
            {

            }

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
                lbl_Birthday.Text = DateTime.Now.ToLongDateString().ToUpper();
                getBirthday();
            }


            //#region Displaying Employee Information
            //_obj_smhr_employee = new SMHR_EMPLOYEE();
            //_obj_smhr_employee.OPERATION = operation.Select;
            //_obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            //_obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);
            //if (dt_Details.Rows.Count > 0)
            //{
            //    if (Convert.ToString(dt_Details.Rows[0]["EMP_PICTURE"]) != string.Empty)
            //    {
            //        ViewState["fileLocation"] = dt_Details.Rows[0]["EMP_PICTURE"];
            //        EMP_IMAGE.ImageUrl = Convert.ToString(dt_Details.Rows[0]["EMP_PICTURE"]);
            //    }
            //    else
            //    {
            //        //EMP_IMAGE.Visible = false;
            //        EMP_IMAGE.ImageUrl = Convert.ToString("~/Images/nophoto.jpg");
            //    }
            //}

            //_obj_smhr_Dashboard = new SMHR_DAHSBOARD();
            //_obj_smhr_Dashboard.OPERATION = operation.Select_Emp;
            //_obj_smhr_Dashboard.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_smhr_Dashboard.SMHR_DASHBOARD_LOGIN_ID = Convert.ToInt32(Session["EMP_ID"]);
            //DataTable dt_getEMP_ID = BLL.get_EMP_ID(_obj_smhr_Dashboard);
            //if (dt_getEMP_ID.Rows.Count != 0)
            //{
            //    lbl_empcode.Text = Convert.ToString(dt_getEMP_ID.Rows[0][0]);
            //    lbl_EmpName.Text = Convert.ToString(dt_getEMP_ID.Rows[0][1]);
            //    lbl_EmpDesignation.Text = Convert.ToString(dt_getEMP_ID.Rows[0][2]);
            //    lbl_EmpDepartment.Text = Convert.ToString(dt_getEMP_ID.Rows[0][3]);
            //}
            //#endregion

            #region Notification-Text
            Table tbl = new Table();
            TableRow row;
            TableCell cell;
            System.Web.UI.WebControls.Image img;
            string str_Scroll = string.Empty;
            _obj_smhr_Announcement = new SMHR_ANNOUNCEMENT();
            _obj_smhr_Announcement.OPERATION = operation.Select;
            _obj_smhr_Announcement.ANNCE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Scroll = BLL.get_Announcement(_obj_smhr_Announcement);
            if (dt_Scroll.Rows.Count > 0)
            {
                for (int I_dtCount = 0; I_dtCount < dt_Scroll.Rows.Count; I_dtCount++)
                {
                    img = new System.Web.UI.WebControls.Image();
                    row = new TableRow();
                    cell = new TableCell();
                    cell.Text = Convert.ToString((I_dtCount) + 1) + ")" + " " + Convert.ToString(dt_Scroll.Rows[I_dtCount]["ANNCE_MESSAGE"]) + '\n';
                    row.Controls.Add(cell);
                    cell = new TableCell();
                    cell.Controls.Add(img);
                    img.ImageUrl = Convert.ToString("~/Images/new_animation.gif");
                    row.Controls.Add(cell);
                    tbl.Rows.Add(row);
                    pnl_Notification.Controls.Add(tbl);
                }
                //for (int I_dtCount = 0; I_dtCount < dt_Scroll.Rows.Count; I_dtCount++)
                //{
                //    str_Scroll = str_Scroll + Convert.ToString((I_dtCount)+1) +")" +  " " + Convert.ToString(dt_Scroll.Rows[I_dtCount]["ANNCE_MESSAGE"]) + '\n';
                //}
                //txt_Notification.Text = str_Scroll;
            }
            #endregion
            if (!Page.IsPostBack)
            {
                Session["DASHBOARD"] = "true";
                if (Session["PendingKra"] != null)
                {
                    //pms_kraform _obj_kra = new pms_kraform();
                    //_obj_kra.KRA_MODE = 9;
                    //_obj_kra.KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //_obj_kra.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                    //DataTable dt = Pms_Bll.get_kra(_obj_kra);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                    //    _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                    //    _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                    //    _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("KRA Approval");
                    //    DataTable dtformdtls = BLL.get_LoginInfo(_obj_Smhr_LoginInfo);
                    //    if (dtformdtls.Rows.Count > 0)
                    //    {
                    //        if (((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == true)) ||
                    //            ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false)))
                    //        {
                    //            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                    //            "function pageLoad(){  ShowPop(); }", true);
                    //        }
                    //    }
                    //}
                    Session.Remove("PendingKra");
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboradmngr", ex.StackTrace, DateTime.Now);
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
                tr_bday.Visible = true;
                lbl_Birthday.Visible = true;
            }
            else
            {
                //lbl_Reminders.Text = "NO BIRTHDAYS TODAY";
                tr_bday.Visible = false;
                lbl_Birthday.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboradmngr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_ApplyLeave_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Payroll/frm_Leaveapplication.aspx?Control=SELFLEAVE");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboradmngr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_CompOff_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Payroll/frm_comoffrequest.aspx?Control=SELFCOMP");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboradmngr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_Expense_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Payroll/frm_ExpenseTrans.aspx?Control=SELFEXPENSE");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboradmngr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_LoanAdvance_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/SelfService/LoanRequestEmp.aspx", false);
            //Response.Redirect("~/Masters/LoanRequest.aspx?Control=SELFLOANREQUEST&lnkType=DBLink", false);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboradmngr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_LeaveChart_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop_LeaveChart();", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboradmngr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_PendingLeave_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Approval/frm_LeaveApproval.aspx");
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboradmngr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_PendingCompOff_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Approval/frm_CompOffApproval.aspx");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboradmngr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_PendingExpense_Click(object sender, EventArgs e)
    {
        try
        {

            Response.Redirect("~/Approval/frm_ExpenseApproval.aspx");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboradmngr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_PendingLoan_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Approval/LoanManagerApproval.aspx");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboradmngr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    public void getDoj()
    {
        try
        {


            string strYear = string.Empty;
            string year = string.Empty;
            _obj_smhr_Dashboard = new SMHR_DAHSBOARD();
            _obj_smhr_Dashboard.OPERATION = operation.Count;
            _obj_smhr_Dashboard.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtCount = BLL.get_EMP_ID(_obj_smhr_Dashboard);
            if (dtCount.Rows.Count > 0)
            {
                if (Convert.ToString(dtCount.Rows[0][0]) == "0")
                {
                    // tr_Wishes.Visible = false;
                }
                else
                {
                    // tr_Wishes.Visible = true;
                    _obj_smhr_Dashboard.OPERATION = operation.Select_Doj;
                    DataTable dtEmpDesc = BLL.get_EMP_ID(_obj_smhr_Dashboard);
                    DataColumn dc = new DataColumn();
                    dtEmpDesc.Columns.Add(dc);
                    if (Convert.ToString(dtEmpDesc.Rows.Count) == "1")
                    {
                        DataRow dr;
                        dr = dtEmpDesc.NewRow();
                        dtEmpDesc.Rows.Add(dr);
                    }
                    if (dtEmpDesc.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtEmpDesc.Rows.Count; i++)
                        {
                            if (!(Convert.ToString(dtEmpDesc.Rows[i]["EMP_ID"]) == string.Empty))
                            {
                                if (Convert.ToString(dtEmpDesc.Rows[i]["EMP_PICTURE"]) == string.Empty)
                                {
                                    dtEmpDesc.Rows[i]["EMP_PICTURE"] = "~/Images/nophoto.jpg";
                                }
                                if (Convert.ToString(dtEmpDesc.Rows[i]["DIFFERENCE"]) == "1")
                                {
                                    strYear = "Year";
                                    year = Convert.ToString(dtEmpDesc.Rows[i]["DIFFERENCE"]);
                                    dtEmpDesc.Rows[i]["Column1"] = "On Successful Completion Of " + year + " " + strYear + " with Dhanush. And We look forword to go a long way together....Cheers.";
                                }
                                else if (Convert.ToString(dtEmpDesc.Rows[i]["DIFFERENCE"]) == "0")
                                {
                                    dtEmpDesc.Rows[i]["Column1"] = "We take this opportunity to join you in extending a warm welcome to the above employees, who have joined Dhanush InfoTech Family.";
                                }
                                else
                                {
                                    strYear = "Years";
                                    year = Convert.ToString(dtEmpDesc.Rows[i]["DIFFERENCE"]);
                                    dtEmpDesc.Rows[i]["Column1"] = "On Successful Completion Of " + year + " " + strYear + " with Dhanush. And We look forword to go a long way together....Cheers.";
                                }
                            }
                            else
                            {

                            }
                        }
                        //radRotate.DataSource = dtEmpDesc;
                        //radRotate.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboradmngr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_EmpSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/HR/frmEmployeeDetails.aspx", false);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboradmngr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnl_EmployeesCalender_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Payroll/EmployeesLeaveCalendar.aspx", false);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboradmngr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_MyCalender_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){  ShowPopForm(); }", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboradmngr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_LeaveBalances_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){  ShowLeaveBalance(); }", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Dashboradmngr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
