using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Microsoft.ReportingServices;
using Microsoft.Reporting.WebForms;
using Telerik.Web.UI;

public partial class Reportss_frm_dailylogreport : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                LoadCombos();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_dailylogreport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadCombos()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_businessunit.OPERATION = operation.Select;
            _obj_smhr_businessunit.ISDELETED = true;
            DataTable dt_Details = BLL.get_BusinessUnit(_obj_smhr_businessunit);
            rcmb_BusinessUnit.DataSource = dt_Details;
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_dailylogreport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_Employee.Items.Clear();
            rv_DailyLog.Style.Add("Display", "none");
            SMHR_LEAVEAPP _obj_Smhr_LeaveApp = new SMHR_LEAVEAPP();
            _obj_Smhr_LeaveApp.MODE = 2;
            _obj_Smhr_LeaveApp.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            DataTable dtemp = BLL.get_EmpLeaveDetails(_obj_Smhr_LeaveApp);
            rcmb_Employee.DataSource = dtemp;
            if (dtemp.Rows.Count != 0)
            {

                rcmb_Employee.DataTextField = "EMPNAME";
                rcmb_Employee.DataValueField = "EMP_ID";
                rcmb_Employee.DataBind();
                rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            }
            else
            {
                BLL.ShowMessage(this, "There are No employees in this Business Unit, Please select another");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_dailylogreport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Employee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //if (rcmb_Employee.SelectedItem.Value != "0")
        //{
        //    DataTable Dt = BLL.ExecuteQuery_1("SELECT DISTINCT E.[EMP_ID] AS EMPID,E.FNAME +'  '+ E.LNAME AS ENAME,DES.DESIGNATION AS DESIGNATION, " +   
        //                        " DEPT.DEPTNAME AS DEPARTMENT,LOGDATE AS DATE,E.SHIFTID AS SHIFT,CONVERT(VARCHAR,S.SHIFTSTART,108) AS SHIFTSTART, " +   
        //                        " CONVERT(VARCHAR,S.SHIFTEND,108) AS SHIFTEND,CONVERT(VARCHAR,ER.LOGINTIME,108) AS LOGINTIME, " +   
        //                        " CONVERT(VARCHAR,ER.LOGOUTTIME,108) AS LOGOUTTIME FROM EMP E " +
        //                        " LEFT JOIN DESIGNATION DES ON E.DESIGNATIONID=DES.DESIGNATIONID  " +  
        //                        " LEFT JOIN DEPARTMENT DEPT ON E.DEPTID = DEPT.DEPTID LEFT JOIN SHIFT S " +   
        //                        " ON E.SHIFTID = S.SHIFTID LEFT JOIN EMPREPORTSAL ER ON E.EMP_ID = ER.EMP_ID " +   
        //                        " WHERE E.EMP_ID= '1'" +
        //                        " AND ER.LOGDATE = '" + Convert.ToDateTime(rdtp_logdate.SelectedDate.Value).ToString("MM/dd/yyyy") + "'");
        //    if (Dt.Rows.Count != 0)
        //    {
        //        ReportDataSource EmpReportDS = new ReportDataSource("SMHRDataSet_RPT_LOG", Dt);
        //        rv_DailyLog.LocalReport.DataSources.Clear();
        //        rv_DailyLog.LocalReport.ReportPath = @"Report_rdlc\Log_Report.rdlc";
        //        rv_DailyLog.LocalReport.DataSources.Add(EmpReportDS);
        //        rv_DailyLog.LocalReport.Refresh();
        //        rv_DailyLog.Style.Add("Display", "block");
        //    }
        //    else
        //    {
        //        rv_DailyLog.Style.Add("Display", "none");
        //    }
        //}
        //else
        //{
        //    rv_DailyLog.Style.Add("Display", "none");
        //}
    }
    protected void rdtp_logdate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            rcmb_BusinessUnit.SelectedIndex = 0;
            rcmb_Employee.Items.Clear();
            rv_DailyLog.Style.Add("Display", "none");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_dailylogreport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
