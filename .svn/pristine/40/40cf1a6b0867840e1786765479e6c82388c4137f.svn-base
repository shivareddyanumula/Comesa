using System;
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

public partial class HR_Employeerror : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
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
                            if (i % 2 == 0)
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
                                            //grvExcelData.Rows[i].BackColor = System.Drawing.Color.Pink;
                                            grvExcelData.Rows[i].Cells[max - 1].Style["color"] = "Red";

                                        }
                                        j++;
                                    }



                                    grvExcelData.Rows[i].Style["color"] = "Green";
                                }

                            }
                        }
                    }

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employees", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    protected void RadTabStrip1_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
    {
        try
        {
            if (e.Tab.Index == 0)
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
                            if (i % 2 == 0)
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
                                            //grvExcelData.Rows[i].BackColor = System.Drawing.Color.Pink;
                                            grvExcelData.Rows[i].Cells[max - 1].Style["color"] = "Red";

                                        }
                                        j++;
                                    }



                                    grvExcelData.Rows[i].Style["color"] = "Green";
                                }

                            }
                        }
                    }

                }



                else
                {
                    BLL.ShowMessage(this, "No Records are Imported");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:Close();", true);

                }
                // BLL.ShowMessage(this, "Qualification");





            }
            else if (e.Tab.Index == 1)
            {
                if (Session["dt_fail_FAM"] != null)
                {
                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["ds_data_fam"];
                    DataTable dtfail = new DataTable();
                    dtfail = (DataTable)Session["dt_fail_FAM"];

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
                            if (i % 2 == 0)
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
                                            //grvExcelData.Rows[i].BackColor = System.Drawing.Color.Pink;
                                            grvExcelData.Rows[i].Cells[max - 1].Style["color"] = "Red";

                                        }
                                        j++;
                                    }



                                    grvExcelData.Rows[i].Style["color"] = "Green";
                                }

                            }
                        }
                    }

                }


            }


            else if (e.Tab.Index == 2)
            {
                if (Session["dt_fail_weof"] != null)
                {
                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["ds_data_weof"];
                    DataTable dtfail = new DataTable();
                    dtfail = (DataTable)Session["dt_fail_weof"];

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
                            if (i % 2 == 0)
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
                                            //grvExcelData.Rows[i].BackColor = System.Drawing.Color.Pink;
                                            grvExcelData.Rows[i].Cells[max - 1].Style["color"] = "Red";

                                        }
                                        j++;
                                    }



                                    grvExcelData.Rows[i].Style["color"] = "Green";
                                }

                            }
                        }
                    }

                }


            }
            else if (e.Tab.Index == 3)
            {
                if (Session["dt_fail_od"] != null)
                {
                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["ds_data_od"];
                    DataTable dtfail = new DataTable();
                    dtfail = (DataTable)Session["dt_fail_od"];

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
                            if (i % 2 == 0)
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
                                            //grvExcelData.Rows[i].BackColor = System.Drawing.Color.Pink;
                                            grvExcelData.Rows[i].Cells[max - 1].Style["color"] = "Red";
                                        }
                                        j++;
                                    }



                                    grvExcelData.Rows[i].Style["color"] = "Green";
                                }

                            }
                        }
                    }

                }


            }




            else if (e.Tab.Index == 4)
            {
                if (Session["dt_fail_phd"] != null)
                {
                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["ds_data_phd"];
                    DataTable dtfail = new DataTable();
                    dtfail = (DataTable)Session["dt_fail_phd"];

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
                            if (i % 2 == 0)
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
                                            //grvExcelData.Rows[i].BackColor = System.Drawing.Color.Pink;
                                            grvExcelData.Rows[i].Cells[max - 1].Style["color"] = "Red";
                                        }
                                        j++;
                                    }



                                    grvExcelData.Rows[i].Style["color"] = "Green";
                                }

                            }
                        }
                    }


                }
            }



        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employees", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
