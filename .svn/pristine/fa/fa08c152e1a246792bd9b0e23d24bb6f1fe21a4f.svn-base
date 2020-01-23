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

public partial class Security_frm_UserLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void rgUserlog_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        LoadGrid();
    }

    private void LoadGrid()
    {
        try
        {
            SMHR_USERLOG _obj_SMHR_USERLOG = new SMHR_USERLOG();
            _obj_SMHR_USERLOG.USERLOG_USER_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt = BLL.GET_USER_LOG_CHECK(_obj_SMHR_USERLOG);
            rgUserlog.DataSource = dt;
//            ClearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_UserLog", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}
