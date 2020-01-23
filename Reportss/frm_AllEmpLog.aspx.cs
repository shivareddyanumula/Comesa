using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using SMHR;
using Microsoft.ReportingServices;
using Microsoft.Reporting.WebForms;

public partial class Reportss_frm_AllEmpLog : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                rdtp_logdate.SelectedDate = null;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AllEmpLog", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
       
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
        
    }
    protected void rdtp_logdate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        //if (rdtp_logdate.SelectedDate.HasValue != null)
        //{
        //    DataTable Dt = BLL.ExecuteQuery_1("SELECT DISTINCT E.[EMP_ID] AS EMPID,E.FNAME +'  '+ E.LNAME AS ENAME, " +
        //                                     " E.DESIGNATIONID AS DESIGNATIONID,DES.DESIGNATION AS DESIGNATION," +
        //                                     " E.DEPTID AS DEPARTMENTID,DEPT.DEPTNAME AS DEPARTMENT, " + 
        //                                     " LOGDATE AS DATE,E.SHIFTID AS SHIFT,  " +
        //                                     " CONVERT(VARCHAR,S.SHIFTSTART,108) AS SHIFTSTART,  " +
        //                                     " CONVERT(VARCHAR,S.SHIFTEND,108) AS SHIFTEND,  " +
        //                                     " CONVERT(VARCHAR,ER.LOGINTIME,108) AS LOGINTIME,  " +
        //                                     " CONVERT(VARCHAR,ER.LOGOUTTIME,108) AS LOGOUTTIME  " +
        //                                     " FROM EMP E LEFT JOIN DESIGNATION DES  " +
        //                                     " ON E.DESIGNATIONID=DES.DESIGNATIONID LEFT JOIN DEPARTMENT DEPT  " +
        //                                     " ON E.DEPTID = DEPT.DEPTID LEFT JOIN SHIFT S  " +
        //                                     " ON E.SHIFTID = S.SHIFTID LEFT JOIN EMPREPORTSAL ER  " +
        //                                     " ON E.EMP_ID = ER.EMP_ID WHERE ER.LOGDATE = '" + Convert.ToDateTime(rdtp_logdate.SelectedDate.Value).ToString("MM/dd/yyyy") + "'");

        //    ReportDataSource EmpReportDS = new ReportDataSource("SMHRDataSet_RPT_EMPLOYEES_LOG_REPORT", Dt);
        //    rv_AllEmpLog.LocalReport.DataSources.Clear();
        //    rv_AllEmpLog.LocalReport.ReportPath = @"Report_rdlc\AllEmployeeLog.rdlc";
        //    rv_AllEmpLog.LocalReport.DataSources.Add(EmpReportDS);
        //    rv_AllEmpLog.LocalReport.Refresh();
        //    rv_AllEmpLog.Style.Add("Display", "block");
        //}
        //else
        //{
        //    rv_AllEmpLog.Style.Add("Display", "none");
        //}
    }
}
