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
using System.IO;
using System.Text;
using System.Drawing;
using System.Data.OleDb;
using Telerik.Web.UI.GridExcelBuilder;


public partial class PMS_frm_AttendanceImportProcess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {try
    {

        if (!Page.IsPostBack)
        {
            if (Session["dt_fail"] != null)
            {
                DataSet ds = new DataSet();
                ds = (DataSet)Session["ds_data"];
                DataTable dtfail = new DataTable();
                dtfail = (DataTable)Session["dt_fail"];

                grvExcelData.DataSource = ds.Tables[0];

                grvExcelData.DataBind();
                //grvExcelData1.DataSource = ds.Tables[0];
                //grvExcelData1.DataBind();

                grvExcelData.HeaderRow.Style["color"] = "White";

            
       


         for (int i = 0; i < grvExcelData.Rows.Count; i++)
            {
               
            
                if (dtfail.Rows.Count > 0)
                {

                   
                        //for (int j = 0; j < item.Table.Columns.Count - 1; j++)
                        //{

                        //}
                        if (i% 2 == 0)
                        {
                            grvExcelData.Rows[i].BackColor = System.Drawing.Color.White;
                            grvExcelData.Rows[i].Style["color"] = "#566D7E";

                        }
                    
                    foreach (DataRow item in dtfail.Rows)
                    {
                        
                       
                        if ((i + 2) == Convert.ToInt32(item["ROWNO"]))
                        {
                            string Column_name = Convert.ToString(item["COLUMNS NAMES"]);
                            int j = 0;
                            int max = ds.Tables[0].Columns.Count;
                            foreach (DataColumn dc in ds.Tables[0].Columns)
                            {
                                if (Column_name.Contains(dc.ColumnName))
                                {
                                    grvExcelData.Rows[i].Cells[j].Style["color"] = "Red";
                                   // grvExcelData.Rows[i].BackColor = System.Drawing.Color.Gray;
                                   
                                }
                                grvExcelData.Rows[i].Cells[max - 1].Style["color"] = "Red";
                                j++;
                            }



                            grvExcelData.Rows[i].Style["color"] = "Green";
                        }
                        
                    }
                }
            }
            Session.Remove("dt_fail");
            Session.Remove("ds_data");
        }
        
            
            
            else
        {
            BLL.ShowMessage(this, "No Records are Imported");
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:Close();", true);
            
        }




        }


        }
    catch (Exception ex)
    {
        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_AttendanceImportProcess", ex.StackTrace, DateTime.Now);
        Response.Redirect("~/Frm_ErrorPage.aspx");
        return;
    }
    }

}



