using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMHR;
using Telerik.Web.UI;
using System.Text;
using System.Collections.Generic;

public partial class frm_FinaliseData : System.Web.UI.Page
{
    SMHR_LEAVEPROCESS obj_smhr_leave;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                Rg_Details.Visible = true;
                Loadgrid();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_FinaliseData", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void Loadgrid()
    {
        try
        {
            Rg_Details.Visible = true;
            obj_smhr_leave = new SMHR_LEAVEPROCESS();
            obj_smhr_leave.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            obj_smhr_leave.BUID = Convert.ToInt32(Session["Bu_Id"]);
            obj_smhr_leave.FROMPERIOD = Convert.ToInt32(Session["From_Period_id"]);
            obj_smhr_leave.TOPERIOD = Convert.ToInt32(Session["ToPeriod_id"]);
            obj_smhr_leave.MODE = 8;
            DataTable Dt_Leaves = new DataTable();
            Dt_Leaves = BLL.Get_LEAVEDETAILS(obj_smhr_leave);
            Rg_Details.DataSource = Dt_Leaves;
            Rg_Details.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_FinaliseData", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
      }
    protected void Btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("LeaveEncashment_New.aspx");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_FinaliseData", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    
}


