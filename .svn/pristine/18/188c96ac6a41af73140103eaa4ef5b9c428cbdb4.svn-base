using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SPMS;

public partial class PMS_frm_ViewKRA : System.Web.UI.Page
{
    SPMS_ROLEKRA _obj_Pms_RoleKra;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                //LoadGrid();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewKRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            _obj_Pms_RoleKra = new SPMS_ROLEKRA();
            _obj_Pms_RoleKra.ROLE_ID = Convert.ToInt32(Convert.ToString(Request.QueryString["ROLE_ID"]));
            _obj_Pms_RoleKra.BUID = Convert.ToInt32(Request.QueryString["BU_ID"]);
            //_obj_Pms_RoleKra.Mode = 6;
            _obj_Pms_RoleKra.Mode = 12;
            _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt1 = Pms_Bll.get_RoleKra(_obj_Pms_RoleKra);
            RG_ViewKRA.DataSource = dt1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewKRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void RG_ViewKRA_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewKRA", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
