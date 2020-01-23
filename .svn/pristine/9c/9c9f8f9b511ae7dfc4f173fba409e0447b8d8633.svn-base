using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.ReportingServices;
using Microsoft.Reporting.WebForms;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;

public partial class Reportss_frm_DesgLogReportDaily : System.Web.UI.Page
{
    SMHR_POSITIONS _obj_smhr_positions;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                LoadCombos();
                rdtp_logdate.SelectedDate = null;
                rcmb_Position.SelectedIndex = 0;
                rv_Department_DailyLog.Style.Add("Display", "none");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DesgLogReportDaily", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    private void LoadCombos()
    {
        try
        { 
        _obj_smhr_positions = new SMHR_POSITIONS();
        _obj_smhr_positions.OPERATION = operation.Select;
        DataTable dt = BLL.get_Positions(_obj_smhr_positions);
        rcmb_Position.DataSource = dt;
        rcmb_Position.DataTextField = "POSITIONS_CODE";
        rcmb_Position.DataValueField = "POSITIONS_ID";
        rcmb_Position.DataBind();
        rcmb_Position.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DesgLogReportDaily", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rdtp_logdate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        try
        {
            rcmb_Position.SelectedIndex = 0;
            rv_Department_DailyLog.Style.Add("Display", "none");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_DesgLogReportDaily", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Position_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //if (rcmb_Position.SelectedItem.Value != "0")
        //{
        //    DataTable Dt = BLL.ExecuteQuery_1("SELECT E.[EMP_ID] AS EMPID,E.FNAME +'  '+ E.LNAME AS ENAME," +
        //                                     " E.DESIGNATIONID AS DESIGNATIONID,DES.DESIGNATION AS DESIGNATION,  " +
        //                                     " DEPT.DEPTNAME AS DEPARTMENT,LOGDATE AS DATE,E.SHIFTID AS SHIFT," +  
        //                                     " CONVERT(VARCHAR,S.SHIFTSTART,108) AS SHIFTSTART,  " +
        //                                     " CONVERT(VARCHAR,S.SHIFTEND,108) AS SHIFTEND,  " +
        //                                     " CONVERT(VARCHAR,ER.LOGINTIME,108) AS LOGINTIME,  " +
        //                                     " CONVERT(VARCHAR,ER.LOGOUTTIME,108) AS LOGOUTTIME  " +
        //                                     " FROM EMP E LEFT JOIN DESIGNATION DES  " +
        //                                     " ON E.DESIGNATIONID=DES.DESIGNATIONID LEFT JOIN DEPARTMENT DEPT  " +
        //                                     " ON E.DEPTID = DEPT.DEPTID LEFT JOIN SHIFT S  " +
        //                                     " ON E.SHIFTID = S.SHIFTID LEFT JOIN EMPREPORTSAL ER  " +
        //                                     " ON E.EMP_ID = ER.EMP_ID WHERE E.DESIGNATIONID='" + Convert.ToInt32(rcmb_Position.SelectedValue) + "'" +
        //                                     " AND ER.LOGDATE='" + Convert.ToDateTime(rdtp_logdate.SelectedDate.Value).ToString("MM/dd/yyyy") + "'");

        //    ReportDataSource EmpReportDS = new ReportDataSource("DESIGNATION_LOG_REPORT", Dt);
        //    rv_Department_DailyLog.LocalReport.DataSources.Clear();
        //    rv_Department_DailyLog.LocalReport.ReportPath = @"Report_rdlc\DeptWiseDaily.rdlc";
        //    rv_Department_DailyLog.LocalReport.DataSources.Add(EmpReportDS);
        //    rv_Department_DailyLog.LocalReport.Refresh();
        //    rv_Department_DailyLog.Style.Add("Display", "block");
        //}
        //else
        //{
        //    rv_Department_DailyLog.Style.Add("Display", "none");
        //}
    }
}
