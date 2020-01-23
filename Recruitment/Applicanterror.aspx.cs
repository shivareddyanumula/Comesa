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

public partial class Recruitment_Applicanterror : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Session["dt_fail_per"] != null)
                {
                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["ds_data_per"];
                    DataTable dtfail = new DataTable();
                    dtfail = (DataTable)Session["dt_fail_per"];

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Applicanterror", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void RadTabStrip1_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
    {
        try
        {
            if (e.Tab.Index == 0)
            {
                if (Session["dt_fail_per"] != null)
                {
                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["ds_data_per"];
                    DataTable dtfail = new DataTable();
                    dtfail = (DataTable)Session["dt_fail_per"];

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
                if (Session["DT_FAIL_QUALI"] != null)
                {
                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["DT_DATA_QUALI"];
                    DataTable dtfail = new DataTable();
                    dtfail = (DataTable)Session["DT_FAIL_QUALI"];

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

                if (Session["DT_FAIL_SKILLS"] != null)
                {
                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["DT_DATA_SKILLS"];
                    DataTable dtfail = new DataTable();
                    dtfail = (DataTable)Session["DT_FAIL_SKILLS"];

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

            else if (e.Tab.Index == 3)
            {
                if (Session["DT_FAIL_EXPERIANCE"] != null)
                {
                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["DT_DATA_EXPERIANCE"];
                    DataTable dtfail = new DataTable();
                    dtfail = (DataTable)Session["DT_FAIL_EXPERIANCE"];

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
            else if (e.Tab.Index == 4)
            {
                if (Session["DT_FAIL_CONTACT"] != null)
                {
                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["DT_DATA_CONTACT"];
                    DataTable dtfail = new DataTable();
                    dtfail = (DataTable)Session["DT_FAIL_CONTACT"];

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

            else if (e.Tab.Index == 5)
            {
                if (Session["DT_FAIL_LANGUAGE"] != null)
                {
                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["DT_DATA_LANGUAGE"];
                    DataTable dtfail = new DataTable();
                    dtfail = (DataTable)Session["DT_FAIL_LANGUAGE"];

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Applicanterror", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }







    }
}
