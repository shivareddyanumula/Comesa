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

public partial class HR_DirectEmployerror : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Session["dt_fail1"] != null)
                {
                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["ds_data1"];
                    DataTable dtfail = new DataTable();
                    dtfail = (DataTable)Session["dt_fail1"];

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DirectEmployerror", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void RadTabStrip1_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
    {
        if (e.Tab.Index == 0)
        {
            if (Session["dt_fail1"] != null)
            {
                DataSet ds = new DataSet();
                ds = (DataSet)Session["ds_data1"];
                DataTable dtfail = new DataTable();
                dtfail = (DataTable)Session["dt_fail1"];

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
                                        grvExcelData.Rows[i].Cells[max - 1].Style["color"] = "Red";
                                        //grvExcelData.Rows[i].BackColor = System.Drawing.Color.Pink;
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
            if (Session["dt_fail_FAM1"] != null)
            {
                DataSet ds = new DataSet();
                ds = (DataSet)Session["ds_data_fam1"];
                DataTable dtfail = new DataTable();
                dtfail = (DataTable)Session["dt_fail_FAM1"];

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
                                        grvExcelData.Rows[i].Cells[max - 1].Style["color"] = "Red";
                                        //grvExcelData.Rows[i].BackColor = System.Drawing.Color.Pink;
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
            if (Session["dt_fail_weof1"] != null)
            {
                DataSet ds = new DataSet();
                ds = (DataSet)Session["ds_data_weof1"];
                DataTable dtfail = new DataTable();
                dtfail = (DataTable)Session["dt_fail_weof1"];

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
                                        grvExcelData.Rows[i].Cells[max - 1].Style["color"] = "Red";
                                        //grvExcelData.Rows[i].BackColor = System.Drawing.Color.Pink;
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
            if (Session["dt_fail_od1"] != null)
            {
                DataSet ds = new DataSet();
                ds = (DataSet)Session["ds_data_od1"];
                DataTable dtfail = new DataTable();
                dtfail = (DataTable)Session["dt_fail_od1"];

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
            if (Session["dt_fail_phd1"] != null)
            {
                DataSet ds = new DataSet();
                ds = (DataSet)Session["ds_data_phd1"];
                DataTable dtfail = new DataTable();
                dtfail = (DataTable)Session["dt_fail_phd1"];

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

                                grvExcelData.Rows[i].Cells[max - 1].Style["color"] = "Red";

                                grvExcelData.Rows[i].Style["color"] = "Green";
                            }

                        }
                    }
                }


            }
        }
        else if (e.Tab.Index == 5)
        {
            if (Session["DT_FAIL_QUALI1"] != null)
            {
                DataSet ds = new DataSet();
                ds = (DataSet)Session["DT_DATA_QUALI1"];
                DataTable dtfail = new DataTable();
                dtfail = (DataTable)Session["DT_FAIL_QUALI1"];

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
                                        grvExcelData.Rows[i].Cells[max - 1].Style["color"] = "Red";
                                        //grvExcelData.Rows[i].BackColor = System.Drawing.Color.Pink;
                                    }
                                    j++;
                                }

                                grvExcelData.Rows[i].Cells[max - 1].Style["color"] = "Red";

                                grvExcelData.Rows[i].Style["color"] = "Green";
                            }

                        }
                    }
                }

            }


        }


        else if (e.Tab.Index == 6)
        {

            if (Session["DT_FAIL_SKILLS1"] != null)
            {
                DataSet ds = new DataSet();
                ds = (DataSet)Session["DT_DATA_SKILLS1"];
                DataTable dtfail = new DataTable();
                dtfail = (DataTable)Session["DT_FAIL_SKILLS1"];

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

        else if (e.Tab.Index == 7)
        {
            if (Session["DT_FAIL_EXPERIANCE1"] != null)
            {
                DataSet ds = new DataSet();
                ds = (DataSet)Session["DT_DATA_EXPERIANCE1"];
                DataTable dtfail = new DataTable();
                dtfail = (DataTable)Session["DT_FAIL_EXPERIANCE1"];

                grvExcelData.DataSource = ds.Tables[0];

                grvExcelData.DataBind();
                //grvExcelData1.DataSource = ds.Tables[0];
                //grvExcelData1.DataBind();

                if (dtfail.Rows.Count > 0)
                {
                    grvExcelData.HeaderRow.Style["color"] = "White";
                }
                else
                {
                }

                //    grvExcelData.HeaderRow.Style["color"] = "White";





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
        else if (e.Tab.Index == 8)
        {
            if (Session["DT_FAIL_CONTACT1"] != null)
            {
                DataSet ds = new DataSet();
                ds = (DataSet)Session["DT_DATA_CONTACT1"];
                DataTable dtfail = new DataTable();
                dtfail = (DataTable)Session["DT_FAIL_CONTACT1"];

                grvExcelData.DataSource = ds.Tables[0];

                grvExcelData.DataBind();
                //grvExcelData1.DataSource = ds.Tables[0];
                //grvExcelData1.DataBind();
                if (dtfail.Rows.Count > 0)
                {
                    grvExcelData.HeaderRow.Style["color"] = "White";
                }
                else
                {
                }




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

        else if (e.Tab.Index == 9)
        {
            if (Session["DT_FAIL_LANGUAGE1"] != null)
            {
                DataSet ds = new DataSet();
                ds = (DataSet)Session["DT_DATA_LANGUAGE1"];
                DataTable dtfail = new DataTable();
                dtfail = (DataTable)Session["DT_FAIL_LANGUAGE1"];

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



}
