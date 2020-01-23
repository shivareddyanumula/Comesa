using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SMHR;

public partial class Masters_Importresult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["ds_data"] != null)
                {
                    DataSet ds = Session["ds_data"] as DataSet;
                    DataTable dtfail = new DataTable();
                    dtfail = Session["dt_fail"] as DataTable;
                    RG_Import.DataSource = ds.Tables[0];
                    RG_Import.DataBind();
                    //RG_Import.HeaderRow.BackColor = System.Drawing.Color.Gray;
                    int cells = RG_Import.HeaderRow.Cells.Count;
                    RG_Import.HeaderRow.Cells[cells - 1].BackColor = System.Drawing.Color.Red;

                    for (int i = 0; i < RG_Import.Rows.Count; i++)
                    {
                        if (dtfail.Rows.Count > 0)
                        {
                            if (i % 2 == 0)
                            {
                                RG_Import.Rows[i].BackColor = System.Drawing.Color.White;
                                RG_Import.Rows[i].Style["color"] = "#566D7E";

                            }
                            foreach (DataRow item in dtfail.Rows)
                            {
                                if ((i + 2) == Convert.ToInt32(item["ROWNO"]))
                                {
                                    string Column_name = Convert.ToString(item["COLUMNS NAME"]);
                                    int j = 0;
                                    int max = ds.Tables[0].Columns.Count;
                                    foreach (DataColumn dc in ds.Tables[0].Columns)
                                    {
                                        if (Column_name.Contains(dc.ColumnName))
                                        {
                                            RG_Import.Rows[i].Cells[j].Style["color"] = "Red";

                                            //grvExcelData.Rows[i].BackColor = System.Drawing.Color.Pink;
                                        }
                                        j++;
                                    }
                                    RG_Import.Rows[i].Cells[max - 1].Style["color"] = "Red";
                                    RG_Import.Rows[i].Style["color"] = "Green";
                                }

                            }
                        }
                    }
                    Session["ds_data"] = null;
                    Session.Remove("dt_fail");
                    Session.Remove("ds_data");
                }
                else
                {
                    BLL.ShowMessage(this, "No Records are Imported");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "Close()", true);
                    //this.Page.Dispose();
                    //close This window..
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Importresult", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}

