using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using System.Web.UI.HtmlControls;

public partial class Payroll_frmLeaveBalances : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SMHR_LEAVEBALANCE _obj_Smhr_LeaveBalance = new SMHR_LEAVEBALANCE();
            _obj_Smhr_LeaveBalance.LT_EMPID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_Smhr_LeaveBalance.MODE = 0;
            DataTable dt = BLL.get_leavebalances(_obj_Smhr_LeaveBalance);
            //HtmlTableRow ht_row;
            HtmlTableRow ht_row1;
            HtmlTableCell ht_cell;
            //ht_row = new HtmlTableRow();
            ht_row1 = new HtmlTableRow();

            tbl_Leavebalance.Rows.Clear();
            tbl_Leavebalance.Border = 1;

            foreach (DataRow item in dt.Rows)
            {
                //ht_cell = new HtmlTableCell();
                //ht_cell.InnerText = Convert.ToString(item["LT_EMPID"]);
                //ht_row.Cells.Add(ht_cell);

                ht_cell = new HtmlTableCell();
                ht_cell.InnerText = Convert.ToString(item["LT_CURRENTBALANCE"]);
                ht_cell.Align = "center";

                ht_row1.Cells.Add(ht_cell);
            }

            //tbl_Leavebalance.Rows.Add(ht_row);
            tbl_Leavebalance.Rows.Add(ht_row1);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmLeaveBalances", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}