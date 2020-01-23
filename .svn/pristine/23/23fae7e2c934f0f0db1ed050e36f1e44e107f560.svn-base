using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;

public partial class PMS_frmRatingScale : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                LoadGrid();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmRatingScale", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadGrid()
    {
        try
        {
            //_obj_Pms_RoleKra = new SPMS_ROLEKRA();
            //_obj_Pms_RoleKra.ROLE_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["ROLE_ID"]));
            //_obj_Pms_RoleKra.Mode = 6;
            //_obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt1 = BLL.ExecuteQuery("SELECT * FROM PMS_RATING_SCALE");
            RG_RatingScale.DataSource = BLL.ExecuteQuery("SELECT * FROM PMS_RATING_SCALE");
            RG_RatingScale.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmRatingScale", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
