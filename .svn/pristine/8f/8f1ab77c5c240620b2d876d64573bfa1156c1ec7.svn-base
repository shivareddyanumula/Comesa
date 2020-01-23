using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;

public partial class Payroll_frm_AttendanceChart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = BLL.ExecuteQuery("EXEC USP_ATTENDANCE_CHART @PERIOD_ID = 39");
                CreateColumns(dt);
            }
        }
        catch(Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("", ""), "frm_AttendanceChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void CreateColumns(DataTable dt)
    {
        try
        {
            DataTable dtDet = new DataTable();
            dtDet.Columns.Clear();
            dtDet.Columns.Add("Month/Day");
            dtDet.Columns.Add("Attendance");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dtDet.NewRow();
                dr[0] = Convert.ToString(dt.Rows[i][1]);
                dr[1] = "";
                dtDet.Rows.Add(dr);


            }
            DataTable dtVal = getData();
            if (dtVal.Rows.Count > 0)
            {
                for (int j = 0; j < dtVal.Rows.Count; j++)
                {
                    DataRow dr = dt.Rows[j];
                    dr.BeginEdit();
                    if (Convert.ToString(dtDet.Rows[j][0]) == Convert.ToString(dtVal.Rows[j][0]))
                    {
                        dr[1] = "Y";
                    }
                    else
                    {
                        dr[1] = "N";
                    }
                    dr.EndEdit();
                }
            }
            else
            {
                for (int i = 0; i < dtDet.Rows.Count; i++)
                {
                    DataRow dr = dtDet.Rows[i];
                    dr.BeginEdit();
                    dr[1] = "N";
                    dr.EndEdit();
                }
            }

            //DataTable dtVal = getData();
            //if (dtVal.Rows.Count != 0)
            //{

            //    for (int j = 0; j < dtVal.Rows.Count; j++)
            //    {

            //        if (Convert.ToString(dtDet.Columns[j].ColumnName).Trim() == Convert.ToString(dtVal.Rows[j][0]).Trim())
            //        {
            //            dr[j] = "Y";
            //        }
            //        else
            //        {
            //            dr[j] = "N";

            //        }
            //    }
            //    dtDet.Rows.Add(dr);
            //}
            //else
            //{
            //    DataRow dr = dtDet.NewRow();
            //    for (int j = 0; j < dtDet.Columns.Count; j++)
            //    {

            //        dr[j] = "N";
            //    }
            //    dtDet.Rows.Add(dr);
            //}
            GridView1.DataSource = dtDet;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("", ""), "frm_AttendanceChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private DataTable getData()
    {
        DataTable dt = new DataTable();
        try
        {
             dt = BLL.ExecuteQuery(" SELECT DISTINCT SUBSTRING(PRDDTL_NAME,1,LEN(SMHR_PERIODDETAILS.PRDDTL_NAME)-4) AS PRDDTL_NAME " +
                                            "    FROM SMHR_PERIODDETAILS LEFT JOIN SMHR_ATTENDANCE  " +
                                            " ON SMHR_ATTENDANCE.ATTENDANCE_PERIOD_DTL_ID = SMHR_PERIODDETAILS.PRDDTL_ID " +
                                            " WHERE ATTENDANCE_BU_ID = 26 AND SMHR_PERIODDETAILS.PRDDTL_ID = 530 ");
            
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("", ""), "frm_AttendanceChart", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt; 
    }
}
