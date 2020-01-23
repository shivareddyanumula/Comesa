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

public partial class Training_frm_rgerid : System.Web.UI.Page
{
    static DataTable dt_resource = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
              

            //loadgrid();

        }
 


    }

    protected void loadgrid()
    {
        try
        {
            Rg_Resourcegrid.DataSource = dt_resource;
            Rg_Resourcegrid.DataBind();
            Rg_Resourcegrid.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_rgerid", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    
    protected void createcontrols()
    {

        //DataTable dt_goal = new DataTable();

        ////create table with primary id,and add to view state

        //dt_goal.Columns.Add("GSDTL_ID");
        //dt_goal.Columns.Add("GSDTL_NAME");

      
        //ViewState["dtgoal"] = dt_goal;
       
    }


    protected void btn_Add_click(object sender, EventArgs e)
    {
        try
        {
            dt_resource.Columns.Clear();
            dt_resource.Columns.Add("S_No");
            dt_resource.Columns.Add("Hotel_Name");


            DataRow dr1;
            dr1 = dt_resource.NewRow();
            dr1[0] = dt_resource.Rows.Count + 1;
            dr1[1] = Convert.ToString(_txt_res.Text);
            dt_resource.Rows.Add(dr1);
            loadgrid();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_rgerid", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
